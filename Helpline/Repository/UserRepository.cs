using Helpline.Repository.Interfaces;
using Helpline.Data;
using Helpline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpline.ViewModels.UserViewModels;

namespace Helpline.Repository
{
    public class UserRepository : IUserRepository
    {
        private HelplineDbContext _dbContext;

        public UserRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        public UserRepository(HelplineDbContext context)
        {
            _dbContext = context;
        }

        protected void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }


        #region Query
                


        // Determines if the user is an administrator
        public bool IsAdministrator(string userName)
        {
            bool isAdministrator = _dbContext.Users.Include("Role")
                .Where(user => user.UserName == userName)
                .Select(user => user.Role.Name == "Supervisor")
                .FirstOrDefault();

            return isAdministrator;
        }

        // Determines if the user can edit information
        public bool CanEditInformation(string userName)
        {
            bool canEditInformation = _dbContext.Users.Include("Role")
                .Where(user => user.UserName == userName)
                .Select(user => user.Role.Name == "Supervisor"
                    || user.Role.Name == "Helpline Operator"
                    || user.Role.Name == "Coordinator")
                .FirstOrDefault();

            return canEditInformation;
        }

        public bool IsCoordinator(string userName)
        {
            bool isCoordinator = _dbContext.Users.Include("Role")
                .Where(user => user.UserName == userName)
                .Select(user => user.Role.Name == "Supervisor" || user.Role.Name == "Coordinator")
                .FirstOrDefault();

            return isCoordinator;
        }

        public string GetFullName(string userName)
        {
            string fullName = _dbContext.Users.Where(u => u.UserName == userName)
                .Select(u => u.FirstName+" "+u.LastName).FirstOrDefault();

            fullName = fullName ?? userName;

            return fullName;
        }
        

        #endregion

    }
}