using Helpline.DTOs.AdministratorDTOs;
using Helpline.Models;
using Helpline.Repository;
using Helpline.ViewModels.AdminViewModels;
using Helpline.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Helpline.Services
{
    /// <summary>
    /// This class controls all methods that involve 
    /// creating and editing users. This class also 
    /// acts as the validator and contains methods 
    /// that determine if the user is authorized 
    /// for certain tasks.
    /// </summary>
    public class UserServices
    {        
        private UnitOfWork _data;

        public UserServices()
        {            
            _data = new UnitOfWork();
        }

        #region Methods used for validation

        /// <summary>
        /// Checks if user is a supervisor
        /// </summary>
        /// <param name="userName">DOACS Username</param>
        /// <returns>True/false that user is an administrator</returns>
        public bool IsSupervisor(string userName)
        {
            User user = _data.Users.GetFirst(u => u.UserName == userName, "Role");

            // The ? operator prevents null reference exceptions
            return user?.Role?.Name == "Supervisor";
        }

        /// <summary>
        /// Checks if the user is a Coordinator 
        /// </summary>
        /// <param name="userName">DOACS Username</param>
        /// <returns>True if the user is a Coordinator or Supervisor, false if any other user role.</returns>
        public bool IsCoordinator(string userName)
        {
            User user = _data.Users.GetFirst(u => u.UserName == userName, "Role");

            return user?.Role?.Name == "Supervisor"
                || user?.Role?.Name == "Coordinator";
        }

        /// <summary>
        /// Determines of the user has the ability 
        /// to update any information within CTS.
        /// </summary>
        /// <param name="userName">DOACS username</param>
        /// <returns>True if authorized, false if not authorized</returns>
        public bool CanEditInformation(string userName)
        {
            User user = _data.Users.GetFirst(u => u.UserName == userName, "Role");

            return user?.Role?.Name == "Supervisor"
                || user?.Role?.Name == "Helpline Operator"
                || user?.Role?.Name == "Coordinator";
        }       

        #endregion


        #region Public Methods that Create View Models for Views        
      

        /// <summary>
        /// The purpose of this method is to get the Full Name of the User.
        /// </summary>
        /// <param name="userName">DOACS Username</param>
        /// <returns>Full Name of the User</returns>
        public string GetFullName(string userName)
        {
            User user = _data.Users.GetFirst(u => u.UserName == userName);

            if (user != null) return $"{user.FirstName} {user.LastName}";
            else return userName;            
        }

        /// <summary>
        /// Gathers a list of objects that is converted into JSON data for the User Index View.
        /// </summary>
        /// <param name="statusNumber">Integer to determine what results the administrator wants back</param>
        /// <returns>List of Objects that are used as JSON data for the Data Table</returns>
        public IEnumerable<UserListDTO> GetUserData(bool? status)
        {            
            return _data.Users
                .GetList(u => status == null || u.IsActive == status, "Role")
                .OrderBy(u => u.LastName)
                .Select(u => new UserListDTO()
                {
                    Id = u.Id,
                    UserName = u.UserName.Substring(6),
                    FullName = GetFullName(u.UserName),
                    Role = u.Role.Name,
                    Status = new StatusFieldDTO(u.IsActive)
                });            
        }

        /// <summary>
        /// Gets the initial Update User View Model including the drop down lists for the Create User View
        /// </summary>
        /// <param name="userName">DOACS user name that is being updated</param>
        /// <returns>The view model for update user view</returns>
        public UpdateUserViewModel GetCreateViewModel(string userName)
        {
            try
            {                
                UpdateUserViewModel model = new UpdateUserViewModel()
                {
                    IsActive = true,
                    Select_Role = _data.Roles.GetList(),
                    Select_OfficeLocations = _data.OfficeLocations.GetList(o => o.IsActive)
                };

                return model;
            }
            catch(Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Get Update Model for Users", 
                    exception.Message, 
                    userName);
                throw;
            }
        }

        /// <summary>
        /// Gets the Update User View Model for Edit User View
        /// </summary>
        /// <param name="id">ID number for user</param>
        /// <param name="userName">DOACS user name</param>
        /// <returns>view model for Edit User View</returns>
        public UpdateUserViewModel GetEditViewModel(int id, string userName)
        {
            try
            {
                User user = _data.Users.GetFirst(u => u.Id == id);
                
                UpdateUserViewModel model = new UpdateUserViewModel()
                {
                    Id = user.Id,
                    RoleId = user.RoleId,
                    OfficeLocationId = user.OfficeLocationId,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    Select_Role = _data.Roles.GetList(),
                    Select_OfficeLocations = _data.OfficeLocations.GetList(o => o.IsActive),
                    StatusId = user.IsActive == true ? 1 : 2,
                    Select_Status = new List<DropDownListItem>()
                    {
                        new DropDownListItem() { Id = 1, Name = "Active" },
                        new DropDownListItem() { Id = 2, Name = "Disabled"}
                    }
                };

                return model;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Get Update User Model for editing", 
                    exception.Message, 
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Get Update User Model for editing", 
                    exception.Message, 
                    userName);
                throw;
            }
        }


        #endregion


        #region Public Methods that Involve the Creation and update of Users

        /// <summary>
        /// This method is used in both service and controller class, checks for pre-existing user names
        /// </summary>
        /// <param name="userName">DOACS user name</param>
        /// <param name="id">ID number for user</param>
        /// <returns>true/false if user exists</returns>
        public bool DuplicateUserName(string userName, int id = 0)
        {
            try
            {                
                userName = userName?.Trim();

                userName = formatUserName(userName);

                if (id > 0)
                {
                    string preExistingName = _data.Users
                        .GetFirst(u => u.Id == id)
                        .UserName;

                    /*If the pre existing user name of the user being updated 
                     * is the same user name in the form then the administrator 
                     * has no intention to update the user name and other fields 
                     * are being updated instead.*/

                    if (userName == preExistingName) return false;
                }

                return _data.Users.GetList().Any(u => u.UserName == userName);
            }
            catch (Exception exception) // Exception is very unlikely
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Check for existing user names",
                    exception.Message,
                    "Administrator");
                throw;
            }
        }


        /// <summary>
        /// This method is used in creation of a user
        /// </summary>
        /// <param name="model">View Model holding user info</param>
        /// <param name="userName">DOACS user name</param>
        /// <returns>ID number of the created user</returns>
        public int CreateUser(UpdateUserViewModel model, string userName)
        {            
            bool alreadyExist = DuplicateUserName(model.UserName);
            try
            {
                if (alreadyExist)
                {
                    //Executes if there is a pre-existing user with the same user name,
                    //returns 0 and user does not get created
                    return 0;
                }
                else
                {
                    model.UserName = formatUserName(model.UserName);
                    User user = new User()
                    {
                        UserName = model.UserName.Trim(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        RoleId = model.RoleId,
                        OfficeLocationId = model.OfficeLocationId,
                        IsActive = model.IsActive,
                        CreatedBy_UserName = userName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = userName,
                        ModifiedDate = DateTime.Now
                    };

                    _data.Users.Create(user);
                    _data.Save();

                    return user.Id;
                }
            }
            catch(EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Create User", 
                    exception.Message, 
                    userName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Create User", 
                    exception.Message, 
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Create User", 
                    exception.Message, 
                    userName);
                throw;
            }

        }


        /// <summary>
        /// Update user in the database.
        /// </summary>
        /// <param name="model">View model that holds form data.</param>
        /// <param name="userName">User name of the admin doing the update. </param>
        /// <returns>Id of the updated user.</returns>
        public int Edit(UpdateUserViewModel model, string userName)
        {
            try
            {
                model.IsActive = model.StatusId == 2 ? false : true;                
                model.UserName = formatUserName(model.UserName);

                User user = _data.Users.GetFirst(u => u.Id == model.Id);
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.RoleId = model.RoleId;
                user.OfficeLocationId = model.OfficeLocationId;
                user.IsActive = model.IsActive;
                user.LastModifiedBy_UserName = userName;
                user.ModifiedDate = DateTime.Now;

                if (!user.IsActive)
                {
                    // When a user is deactivated then the user role is
                    // automatically set to View Only.
                    user.RoleId = _data.Roles
                        .GetFirst(r => r.Name == "View Only")
                        .Id;                                                
                }

                _data.Users.Edit(user);
                _data.Save();

                return user.Id;
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Update User",
                    exception.Message, 
                    userName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Update User", 
                    exception.Message, 
                    userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Update User", 
                    exception.Message, 
                    userName);
                throw;
            }
        }

        #endregion


        #region Private Methods that help shape objects

        /// <summary>
        /// This method keeps all usernames in the database where they consistently start with "DOACS\"
        /// </summary>
        /// <param name="userName">user name that needs to be formatted</param>
        /// <returns>the reformatted user name as a string</returns>
        private string formatUserName(string userName)
        {
            if (!userName.StartsWith(@"DOACS\", StringComparison.OrdinalIgnoreCase))
            {
                userName = userName.Trim();
                userName = userName.Replace(@"\", "");
                userName = userName.Replace(" ", "");
                userName = userName.ToLower();
                userName = $"DOACS\\{userName}";
            }
            else
            {
                userName = userName.Substring(6);
                userName = userName.Trim();
                userName = userName.Replace(@"\", "");
                userName = userName.Replace(" ", "");
                userName = userName.ToLower();
                userName = $"DOACS\\{userName}";
            }

            return userName;
        }

        #endregion


    }
}