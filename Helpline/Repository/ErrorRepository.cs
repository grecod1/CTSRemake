using Helpline.Data;
using Helpline.Models;
using Helpline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{
    public class ErrorRepository    {
        private HelplineDbContext _dbContext;        

        public ErrorRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        public ErrorRepository(HelplineDbContext context)
        {
            _dbContext = context;
        }

        protected void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        public void LogError(string errorType, string task, string message, string userName)
        {
            try
            {
                EmailServices EmailServices = new EmailServices();
                EmailServices.SendErrorEmail(errorType, task, message, userName, DateTime.Now);
                ErrorLog errorLog = new ErrorLog()
                {
                    Type = errorType,
                    Task = task != null ? task : "",
                    Message = message != null? message : "",                    
                    UserName = userName != null? userName : "",
                    Time = DateTime.Now
                };

                _dbContext.ErrorLogs.Add(errorLog);
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                throw;
            }
            
        }

    }
}