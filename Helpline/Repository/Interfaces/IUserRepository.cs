using Helpline.Models;
using Helpline.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface IUserRepository
    {
        //Query        
        bool IsAdministrator(string userName);
        bool CanEditInformation(string userName);
        bool IsCoordinator(string userName);
        string GetFullName(string userName);                
                        
    }
}
