using Helpline.DTOs.AdministratorDTOs;
using Helpline.Models;
using Helpline.Repository;
using Helpline.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace Helpline.Services
{
    /// <summary>
    /// Contains a list of methods that involve 
    /// creating and editing models that administrators 
    /// have control over including programs, routing 
    /// categories, and office locations.
    /// </summary>
    public class AdministratorServices 
    {                
        private UnitOfWork _data;

        public AdministratorServices()
        {            
            _data = new UnitOfWork();
        }        


        #region Methods that deal with Programs

        /// <summary>
        /// Gathers a list of object that is translated into JSON data for the Program Index View.
        /// </summary>
        /// <param name="status">integer value that determines if the user wants to see active, disabled or all programs</param>
        /// <returns>List of objects used in the Data Tables</returns>
        public IEnumerable<AdminListDTO> GetPrograms(bool? status)
        {            
            return _data.Programs
                .GetList(program => status == null || program.IsActive == status)
                .OrderBy(program => program.LongName)
                .Select(program => new AdminListDTO()
                {
                    Id = program.Id,
                    Name = program.LongName,
                    Abbreviation = program.ShortName,
                    Status = new StatusFieldDTO(program.IsActive)
                });                        
        }

        /// <summary>
        /// This method returns the view model 
        /// for the Edit Program View.
        /// </summary>
        /// <param name="id">Id of the Program</param>
        /// <returns>View Model for Edit Program View</returns>
        public UpdateProgramViewModel GetUpdateProgramViewModel(int id)
        {
            try
            {
                Program program = _data.Programs.GetFirst(p => p.Id == id);                                        

                UpdateProgramViewModel model = new UpdateProgramViewModel()
                {
                    ProgramId = program.Id,
                    LongName = program.LongName,
                    ShortName = program.ShortName == "None" ? null : program.ShortName,
                    IsActive = program.IsActive
                };

                return model;
            }
            catch (NullReferenceException exception)
            {
                //Returns a blank Program
                UpdateProgramViewModel model = new UpdateProgramViewModel()
                {
                    ProgramId = 0
                };

                return model;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Get Program", exception.Message, "Administrator");
                throw;
            }

        }

        /// <summary>
        /// Edit Program
        /// </summary>
        /// <param name="model">Program being updated</param>
        /// <param name="userName">Used for recording user actions</param>
        /// <returns>
        ///     integer id of the Program, returns 0 is there is a pre-existing name, 
        ///     and update doesn't take place
        /// </returns>
        public int Edit(UpdateProgramViewModel model)
        {
            try
            {
                Program program = _data.Programs.GetFirst(p => p.Id == model.ProgramId);

                program.LongName = model.LongName;
                program.ShortName = model.ShortName ?? "None";
                program.IsActive = model.IsActive;
                program.LastModifiedBy_UserName = model.UserName;
                program.ModifiedDate = DateTime.Now;

                _data.Programs.Edit(program);
                _data.Save();

                return model.ProgramId;                
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Updating Program", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Updating Program", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Updating Program", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
        }

        /// <summary>
        /// Create New Program
        /// </summary>
        /// <param name="model">View model that holds user input</param>
        /// <param name="userName">Used to record user activities</param>
        /// <returns>integer value of the new program, returns 0 if there 
        /// is a pre-existing program and update didn't take place</returns>
        public int Create(UpdateProgramViewModel model)
        {
            try
            {
                Program program = new Program()
                {
                    LongName = model.LongName.Trim(),
                    ShortName = model.ShortName ?? "None",
                    IsActive = true,
                    CreatedBy_UserName = model.UserName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = model.UserName,
                    ModifiedDate = DateTime.Now
                };

                _data.Programs.Create(program);
                _data.Save();

                return program.Id;

            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Creating Program", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Creating Program", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Creating Program", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
        }

        /// <summary>
        /// This method checks to see if the user 
        /// entered a duplicate program name. If 
        /// there is a duplicate then return value 
        /// is true.
        /// </summary>
        /// <param name="name">Program Name</param>
        /// <param name="id">If user is updating program then Id of that program. </param>
        /// <returns>True if duplicate false if unique. </returns>
        public bool PreExistingProgram(string name, int id = 0)
        {
            name = name.ToLower().Trim();

            if (id != 0)
            {
                string preExistingName = _data.Programs
                    .GetFirst(p => p.Id == id)
                    .LongName.ToLower();

                if (name == preExistingName)
                {
                    /*This code will execute if the user goes into the edit view of the object, but doesn't
                     update the name of the object, or just changes the status of the object, and therefore
                     this code allows the user to do that. */
                    
                    return false;
                }
            }

            bool duplicate = _data.Programs
                .GetList()
                .Any(program => program.LongName.ToLower() == name);

            return duplicate;
        }

        #endregion


        #region Methods that deal with Request Types

        /// <summary>
        /// Gathers a list of objects that used translated into JSON data for the Request Type Index View.
        /// </summary>
        /// <param name="statusNumber">integer value that determines what results the user wants to see</param>
        /// <returns>List of Objects that is used as JSON data for the Data Tables</returns>
        public IEnumerable<AdminListDTO> GetRequestTypes(bool? status)
        {            
            return _data.RequestTypes
                .GetList(requestType => status == null || requestType.IsActive == status)
                .OrderBy(requestType => requestType.Name)
                .Select(requestType => new AdminListDTO()
                {
                    Id = requestType.Id,
                    Name = requestType.Name,
                    Status = new StatusFieldDTO(requestType.IsActive)
                });            
        }

        /// <summary>
        /// Get the view model for the 
        /// form that edits request types.
        /// </summary>
        /// <param name="id">Id of request type</param>
        /// <returns>View model</returns>
        public UpdateRequestTypeViewModel GetEditRequestTypeViewModel(int id)
        {
            try
            {
                RequestType requestType = _data.RequestTypes.GetFirst(rt => rt.Id == id);
                UpdateRequestTypeViewModel model = new UpdateRequestTypeViewModel()
                {
                    RequestTypeId = requestType.Id,
                    Name = requestType.Name,
                    IsActive = requestType.IsActive
                };

                return model;
            }
            catch (NullReferenceException exception)
            {
                UpdateRequestTypeViewModel model = new UpdateRequestTypeViewModel()
                {
                    RequestTypeId = 0
                };

                return model;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Get Request Type", exception.Message, "Administrator");
                throw;
            }
        }

        /// <summary>
        /// Method that updates Request Type
        /// </summary>
        /// <param name="requestType">Request Type being updated</param>
        /// <param name="userName">Used to record user actions</param>
        /// <returns>
        /// Id of Request Type being update, returns 0 if there is a pre-existing name and update didn't take place.
        /// </returns>
        public int Edit(UpdateRequestTypeViewModel model)
        {
            try
            {
                RequestType requestType = _data.RequestTypes
                    .GetFirst(r => r.Id == model.RequestTypeId);

                requestType.Name = model.Name;
                requestType.IsActive = model.IsActive;
                requestType.LastModifiedBy_UserName = model.UserName;
                requestType.ModifiedDate = DateTime.Now;


                _data.RequestTypes.Edit(requestType);
                _data.Save();                               

                return requestType.Id;                
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Update Request Type", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Update Request Type", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Update Request Type", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }

        }

        /// <summary>
        /// Method used for creating a Request Type
        /// </summary>
        /// <param name="model">Request Type being created</param>
        /// <param name="userName">Used to record user's actions</param>
        /// <returns>Id of the created request type.</returns>
        public int Create(UpdateRequestTypeViewModel model)
        {
            try
            {
                RequestType requestType = new RequestType()
                {
                    Name = model.Name.Trim(),
                    Area = "Helpline",
                    IsActive = true,
                    CreatedBy_UserName = model.UserName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = model.UserName,
                    ModifiedDate = DateTime.Now
                };

                _data.RequestTypes.Create(requestType);
                _data.Save();

                return requestType.Id;                
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Create Request Type", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Create Request Type", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Create Request Type", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }

        }

        /// <summary>
        /// This Method checks to see if the request type's 
        /// name already exist in the database.
        /// </summary>
        /// <param name="name">The name the user input</param>
        /// <param name="id">Id of the request type being updated</param>
        /// <returns>True if pre-existing name or invalid, false if unique name or valid</returns>
        public bool PreExistingRequestType(string name, int id = 0)
        {
            name = name?.Trim();
            
            if(id > 0)
            {
                string preExistingName = _data.RequestTypes
                    .GetFirst(r => r.Id == id)
                    .Name;

                if(preExistingName.ToLower() == name.ToLower())
                {

                    /*This code will execute if the user goes into the edit view 
                     * of the object, but doesn't update the name of the object, or 
                     * just changes the status of the object, and therefore this 
                     * code allows the user to do that. */
                    
                    return false;
                }
            }

            // If the any clause returns a positive then the input is duplicate and not valid.
            return _data.RequestTypes
                .GetList()
                .Any(r => r.Name.ToLower() == name.ToLower());                                
        }

        #endregion


        #region Methods that deal with Routing Categories      

        /// <summary>
        /// Gets a list of objects that is translated into JSON data that is used for the Routing Category Index View.
        /// </summary>
        /// <param name="statusNumber">Integer value that determines what results user wants to see</param>
        /// <returns>List of Objects that is used for the JSON data in the Data Table</returns>
        public IEnumerable<AdminListDTO> GetRoutingCategories(bool? status)
        {            

            return _data.RoutingCategories
                .GetList(r => status == null || r.IsActive == status)
                .Select(r => new AdminListDTO()
                {
                    Id = r.Id,
                    Name = r.Name,                    
                    Status = new StatusFieldDTO(r.IsActive)
                });            
        }

        /// <summary>
        /// This is used for the Edit Routing Category View. Unlike other administrator objects, 
        /// the Routing Category has a separate view model for the creation and update of the 
        /// Routing Category, because updating the Routing Category involves a list of emails.
        /// </summary>
        /// <param name="id">Id of the Routing Category</param>
        /// <returns>View Model used for updating Routing Category</returns>
        public UpdateRoutingCategoryViewModel GetEditRoutingCategoryViewModel(int id)
        {
            RoutingCategory routingCategory = _data.RoutingCategories.GetFirst(rc => rc.Id == id);

            //Used for the list of emails in view model.
            IEnumerable<string> emails = _data.RoutingEmails
                    .GetList(re => re.RoutingCategoryId == routingCategory.Id)
                    .Select(re => re.EmailAddress);

            UpdateRoutingCategoryViewModel model = new UpdateRoutingCategoryViewModel()
            {
                Id = routingCategory.Id,
                Name = routingCategory.Name,
                IsActive = routingCategory.IsActive,
                Emails = emails
            };

            return model;
        }

        /// <summary>
        /// Edit Routing Category
        /// </summary>
        /// <param name="model">View Model for updating Routing Category</param>
        /// <param name="userName">Used to record user actions</param>
        /// <returns>
        /// Id of Routing Category that was updated, or returns 0 if there is a pre-existing name, and update never took place
        /// </returns>
        public int Edit(UpdateRoutingCategoryViewModel model, string userName)
        {
            try
            {
                RoutingCategory routingCategory = _data.RoutingCategories                    
                    .GetFirst(r => r.Id == model.Id);

                routingCategory.Name = model.Name;
                routingCategory.IsActive = model.IsActive;
                routingCategory.LastModifiedBy_UserName = userName;
                routingCategory.ModifiedDate = DateTime.Now;

                _data.RoutingCategories.Edit(routingCategory);
                _data.Save();

                updateRoutingEmails(model, userName);

                return model.Id;
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", "Update Routing Category", exception.Message, userName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", "Update Routing Category", exception.Message, userName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Update Routing Category", exception.Message, userName);
                throw;
            }

        }
        

        /// <summary>
        /// Create New Routing Category
        /// </summary>
        /// <param name="model">View model that holds form data</param>
        /// <param name="userName">user</param>
        /// <returns>
        /// Id of the new Routing Category, returns 0 if there is a pre-existing name.
        /// </returns>
        public int Create(UpdateRoutingCategoryViewModel model, string userName) 
        {
            try
            {
                RoutingCategory routingCategory = new RoutingCategory()
                {
                    Name = model.Name.Trim(),
                    Area = "Helpline",
                    IsActive = true,
                    CreatedBy_UserName = userName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = userName,
                    ModifiedDate = DateTime.Now

                };

                _data.RoutingCategories.Create(routingCategory);
                _data.Save();                

                model.Id = routingCategory.Id;

                updateRoutingEmails(model, userName);

                return routingCategory.Id;

            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Create Routing Category", 
                    exception.Message, 
                    userName);
                
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Create Routing Category", 
                    exception.Message, 
                    userName);
                
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Create Routing Category", 
                    exception.Message, 
                    userName);
                
                throw;
            }
        }

        /// <summary>
        /// Makes sure there is no pre-existing routing categories.
        /// </summary>
        /// <param name="name">The name the user typed in</param>
        /// <param name="id">Id of the routing category being updated.</param>
        /// <returns>True if duplicate or invalid, false if unique or valid.</returns>
        public bool PreExistingRoutingCategory(string name, int id = 0)
        {
            name = name.Trim();
            if (id != 0)
            {
                string preExstingName = _data.RoutingCategories
                    .GetFirst(r => r.Id == id)
                    .Name;
                
                if (name.ToLower() == preExstingName.ToLower())
                {
                    /*This code will execute if the user goes into the edit view of the object, but doesn't
                     update the name of the object, or just changes the status of the object, and therefore
                     this code allows the user to do that. */
                    return false;
                }
            }
            
            // If the any clause returns a positive then the input is duplicate and not valid.
            return _data.RoutingCategories
                .GetList()
                .Any(r => r.Name.ToLower() == name.ToLower());            
        }

        
        private void updateRoutingEmails(UpdateRoutingCategoryViewModel model, string userName)
        {
            // Create or edit emails linked to Routing Category  
            IEnumerable<RoutingEmail> routingEmails = _data.RoutingEmails
                .GetList(r => r.RoutingCategoryId == model.Id);

            if (routingEmails?.Count() > 0)
            {
                foreach (RoutingEmail email in routingEmails)
                {
                    _data.RoutingEmails.Remove(email);
                }
                _data.Save();
            }

            if (model.Emails?.Count() > 0)
            {
                foreach (string email in model.Emails)
                {
                    RoutingEmail routingEmail = new RoutingEmail()
                    {
                        RoutingCategoryId = model.Id,
                        EmailAddress = email,
                        CreatedBy_UserName = userName,
                        CreationDate = DateTime.Now,
                        LastModifiedBy_UserName = userName,
                        ModificationDate = DateTime.Now
                    };

                    _data.RoutingEmails.Create(routingEmail);
                }
                _data.Save();
            }
        }


        #endregion


        #region Methods that deal with Office Locations

        /// <summary>
        /// Returns a list of objects that gets translated into JSON data for the Office Location Index View
        /// </summary>
        /// <param name="statusNumber">integer that determines what results the user wants back</param>
        /// <returns>List of objects used as JSON data for the Data Tables</returns>
        public IEnumerable<AdminListDTO> GetOfficeLocations(bool? status)
        {
            return _data.OfficeLocations
                .GetList(o => status == null || o.IsActive == status)
                .Select(o => new AdminListDTO()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Status = new StatusFieldDTO(o.IsActive)
                });            
        }

        /// <summary>
        /// Get view model for the edit office location view.
        /// </summary>
        /// <param name="id">Id of office location being updated</param>
        /// <returns>View model.</returns>
        public UpdateOfficeLocationViewModel GetOfficeLocation(int id)
        {
            try
            {
                OfficeLocation officeLocation = _data.OfficeLocations.GetFirst(ol => ol.Id == id);
                
                UpdateOfficeLocationViewModel model = new UpdateOfficeLocationViewModel()
                {
                    OfficeLocationId = officeLocation.Id,
                    Name = officeLocation.Name,
                    IsActive = officeLocation.IsActive
                };

                return model;
            }
            catch (NullReferenceException exception)
            {
                UpdateOfficeLocationViewModel model = new UpdateOfficeLocationViewModel()
                {
                    OfficeLocationId = 0
                };

                return model;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Get Office Location", exception.Message, "Administrator");
                throw;
            }
        }

        /// <summary>
        /// Method that updates an office location.
        /// </summary>
        /// <param name="model">Office Location being updated</param>
        /// <param name="userName">Used to record user actions</param>
        /// <returns>
        /// Id of the Office location being updated, returns 0 of there is 
        /// a pre-existing name and update didn't happen.
        /// </returns>
        public int Edit(UpdateOfficeLocationViewModel model)
        {
            try
            {
                OfficeLocation officeLocation = _data.OfficeLocations
                    .GetFirst(o => o.Id == model.OfficeLocationId);
                
                officeLocation.Name = model.Name;
                officeLocation.IsActive = model.IsActive;
                officeLocation.LastModifiedBy_UserName = model.UserName;
                officeLocation.ModifiedDate = DateTime.Now;                                

                if (!model.IsActive) officeLocation.CloseDate = DateTime.Now;                
                else officeLocation.CloseDate = null;

                _data.OfficeLocations.Edit(officeLocation);
                _data.Save();                

                return model.OfficeLocationId;
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Update Office Location", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Update Office Location", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Update Office Location", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
        }

        /// <summary>
        /// Create new office location
        /// </summary>
        /// <param name="model">View model that holds form data.</param>
        /// <param name="userName">User name</param>
        /// <returns>Id of new office location.</returns>
        public int Create(UpdateOfficeLocationViewModel model)
        {
            try
            {
                OfficeLocation officeLocation = new OfficeLocation()
                {
                    Name = model.Name.Trim(),
                    IsActive = true,
                    CreatedBy_UserName = model.UserName,
                    CreationDate = DateTime.Now,
                    LastModifiedBy_UserName = model.UserName,
                    ModifiedDate = DateTime.Now
                };

                _data.OfficeLocations.Create(officeLocation);
                _data.Save();

                return officeLocation.Id;

            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", 
                    "Create Office Location", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", 
                    "Create Office Location", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Create Office Location", 
                    exception.Message, 
                    model.UserName);
                
                throw;
            }
        }

        /// <summary>
        /// Check for pre-existing office locations.
        /// </summary>
        /// <param name="name">User input</param>
        /// <param name="id">Id of the office location being updated.</param>
        /// <returns>True of duplicate or invalid, false if unique or valid. </returns>
        public bool PreExistingOfficeLocation(string name, int id = 0)
        {
            name = name?.Trim();

            if(id > 0)
            {
                string preExistingName = _data.OfficeLocations
                    .GetFirst(o => o.Id == id)
                    .Name;

                if(preExistingName.ToLower() == name.ToLower())
                {
                    /*This code will execute if the user goes into the edit view of the object, but doesn't
                     update the name of the object, or just changes the status of the object, and therefore
                     this code allows the user to do that. */
                    
                    return false;
                }
            }

            return _data.OfficeLocations.GetList().Any(o => o.Name.ToLower() == name.ToLower());            
        }

        #endregion


        #region Methods that deal with Reports

        /// <summary>
        /// This method creates the view model 
        /// for the reports view
        /// </summary>
        /// <returns>View model for Reports View</returns>
        public ReportViewModel GetReportViewModel()
        {
            try
            {
                ReportViewModel model = new ReportViewModel()
                {
                    //Get only the active Programs
                    Select_Program = _data.Programs.GetList(p => p.IsActive),
                    Select_RoutingCategory = _data.RoutingCategories.GetList(p => p.IsActive),                                        
                    Select_RequestType = _data.RequestTypes.GetList(r => r.IsActive),
                    Select_CommunicationType = _data.CommunicationTypes.GetList(),
                    Select_County = _data.Counties.GetList(c => c.Id > 0).OrderBy(c => c.Name)
                };


                return model;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Get Program View Model", exception.Message, "un-recorded");
                throw;
            }

        }

        /// <summary>
        /// This method gets a list of DTOs 
        /// that gets translated into JSON 
        /// data for the bar charts that 
        /// display a number of tickets made 
        /// under each problem in a given 
        /// timespan.
        /// </summary>
        /// <param name="startDate">Start date is required</param>
        /// <param name="endDate">If end date is null then it will be today.</param>
        /// <returns>Data for the bar graph on the Reports View.</returns>
        public IEnumerable<ChartDTO> GetBarChartData(DateTime startDate, DateTime? endDate)
        {
            try
            {
                /*If end date is null then default date is today. */
                if (endDate == null)
                {
                    endDate = DateTime.Now;
                }
                else
                {
                    TimeSpan oneDay = TimeSpan.FromDays(1);
                    endDate += oneDay;
                }

                //Get the Id of the disabled status to filter out disabled tickets.
                int disabledStatusId = _data.Statuses
                    .GetFirst(status => status.Name == "Disabled").Id;

                /*This gets a list of each distinct program that the ticket was routed to 
                 in a given time span.*/
                IEnumerable<Program> programs = _data.Tickets
                    .GetList(ticket => ticket.CreationDate >= startDate 
                            && ticket.CreationDate < endDate
                            && ticket.StatusId != disabledStatusId,
                        "Routes.Program")
                    .Select(ticket =>
                        /*This retrieves all routes that are the 
                         latest route under the ticket because 
                        those are the relevant routes. */
                        ticket.Routes
                            .OrderByDescending(r => r.CreationDate)
                            .FirstOrDefault()
                            .Program)
                    .Distinct();

                /*This list object had to be create because this list object uses the Add 
                 Method in the following foreach loop. */

                IList<ChartDTO> data = new List<ChartDTO>();

                foreach (Program program in programs)
                {
                    /*This foreach loop gets the number of tickets made where the latest 
                     route under the ticket is under the program. */

                    int ticketCount = _data.Tickets
                        .GetList(predicate: ticket => ticket.CreationDate >= startDate 
                                && ticket.CreationDate < endDate
                                && ticket.StatusId != disabledStatusId,
                            includedProperties: "Routes")
                        .Where(ticket =>
                            /*This retrieves all routes that are the 
                            latest route under the ticket because 
                            those are the relevant routes. */
                            ticket.Routes
                                .OrderByDescending(r => r.CreationDate)
                                .FirstOrDefault()
                                .ProgramId == program.Id)
                        .Count();

                    data.Add(new ChartDTO(program.LongName, ticketCount));

                }

                return data;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", 
                    "Get Bar Chart Data", 
                    exception.Message, 
                    "un-recorded");
                
                throw;
            }

        }

        /// <summary>
        /// This methods gets a list of DTOs that will be converted 
        /// into JSON data for the line chart on the Reports View 
        /// that displays the number of tickets under a program 
        /// within each month.
        /// </summary>
        /// <param name="programId">Program Id parameter is required.</param>
        /// <param name="startDate">Start date is required.</param>
        /// <param name="endDate">If end date is null then it will be today. </param>
        /// <param name="routingCategoryId">This parameter is nullable.</param>
        /// <param name="requestTypeId">This parameter is nullable. </param>
        /// <param name="communicationTypeId">This parameter is nullable.</param>
        /// <param name="countyId">This parameter is nullable.</param>
        /// <param name="city">This parameter is nullable.</param>
        /// <param name="streetName">This parameter is nullable.</param>
        /// <returns>Data for the line chart on the Reports View.</returns>
        public IEnumerable<ChartDTO> GetLineChartData(int programId, 
            DateTime startDate,
            DateTime? endDate,
            int? routingCategoryId,
            int? requestTypeId,
            int? communicationTypeId,
            int? countyId, 
            string city,
            string streetName)
        {
            try
            {
                /*If end date is null then default date is today. */
                if (endDate == null)
                {
                    endDate = DateTime.Now;
                }
                else
                {
                    TimeSpan oneDay = TimeSpan.FromDays(1);
                    endDate += oneDay;
                }

                //Format strings parameters for query.
                city = city?.Trim()?.ToLower();
                streetName = streetName?.Trim()?.ToLower(); 

                /*The following to int ids are used in the upcoming LINQ queries. */

                // Id used to filter out disabled tickets.
                int disabledStatusId = _data.Statuses
                    .GetFirst(status => status.Name == "Disabled")
                    .Id;

                // Id used to retrieved physical location of ticket. 
                int physicalAddressTypeId = _data.AddressTypes
                    .GetFirst(addressType => addressType.Name == "Physical")
                    .Id;

                /*In order to get a list of months between the start date 
                 * and the end date, the start date must be changed to where 
                 * it is the first day of it's month.*/
                startDate = new DateTime(startDate.Year, startDate.Month, 1);

                IList<DateTime> months = new List<DateTime>();

                /*A while loop is used to add values into the months list. This 
                 * list of months consist of date time objects that start on the 
                 * first of every month. These must be on the first of every month 
                 * to make sure that the month of the end date will be included in 
                 * the list. */
                while (endDate >= startDate)
                {
                    months.Add(startDate);
                    startDate = startDate.AddMonths(1);
                }

                IList<ChartDTO> data = new List<ChartDTO>();

                /*This foreach loop iterates through each month, and gathers the 
                 * number of tickets within each month. */
                foreach (DateTime month in months)
                {
                    //Get the label which is the month displayed.
                    string label = month.ToString("MMMM yyyy");

                    /*This gets a count of all tickets within the given month and under 
                     * the selected program. The generic where method is called to include 
                     * the routes and addresses under the tickets because the program id is 
                     * used and the program id is related to the route model. Optional Address 
                     * filters are used as well. Only the latest route under each ticket matters 
                     * and only the physical address under the ticket matters. */
                    int value = _data.Tickets
                        .GetList(ticket => ticket.CreationDate.Month == month.Month
                                && ticket.CreationDate.Year == month.Year,
                            "Routes",
                            "Addresses")
                        .Where(ticket => ticket.StatusId != disabledStatusId)
                        .Where(ticket => requestTypeId == null
                            || ticket.RequestTypeId == requestTypeId)
                        .Where(ticket => communicationTypeId == null
                            || ticket.CommunicationTypeId == communicationTypeId)                        
                        .Where(ticket =>                                
                                ticket.Routes
                                    .OrderByDescending(r => r.CreationDate)
                                    .FirstOrDefault()
                                    .ProgramId == programId)
                        .Where(ticket => routingCategoryId == null                            
                            || ticket.Routes                                
                                    .OrderByDescending(r => r.CreationDate)
                                    .FirstOrDefault()
                                    .RoutingCategoryId == routingCategoryId)
                        .Where(ticket => countyId == null
                            || ticket.Addresses.Any(a => 
                                a.AddressTypeId == physicalAddressTypeId 
                                && a.CountyId == countyId))
                        .Where(ticket => city == ""
                            || ticket.Addresses.Any(a => 
                                a.AddressTypeId == physicalAddressTypeId
                                && a.City != null 
                                && a.City.ToLower().Contains(city)))
                        .Where(ticket => streetName == ""
                            || ticket.Addresses.Any(a => 
                                a.AddressTypeId == physicalAddressTypeId
                                && a.StreetName != null
                                && a.StreetName.ToLower().Contains(streetName)))
                        .Count();

                    //Create new DTO and add it to list.
                    data.Add(new ChartDTO(label, value));
                }

                return data;
            }
            catch(FormatException exception)
            {
                _data.ErrorRepository.LogError("Format Exception",
                    "Get Line Chart Data",
                    exception.Message,
                    "un-recorded");
                throw;
            }
            catch(EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception",
                    "Get Line Chart Data",
                    exception.Message,
                    "un-recorded");
                throw;
            }
            catch(NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference",
                    "Get Line Chart Data",
                    exception.Message,
                    "un-recorded");
                throw;
            }
            catch(Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown",
                    "Get Line Chart Data",
                    exception.Message,
                    "un-recorded");
                throw;
            }
            
        }

        #endregion

    }
}