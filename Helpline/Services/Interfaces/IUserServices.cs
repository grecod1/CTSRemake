using Helpline.ViewModels.AdminViewModels;
using Helpline.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    interface IUserServices
    {
        //Public Methods that create View Models for Views        
        UserViewModel GetUserViewModel(string userName);
        bool IsAdministrator(string userName);
        bool CanEditInformation(string userName);
        string GetFullName(string userName);
        AdminIndexViewModel GetInitialUserIndexViewModel(int statusNumber, string userName);
        List<Object> GetUserData(int statusNumber);
        UpdateUserViewModel GetInitialUpdateUserViewModel(string userName);
        UpdateUserViewModel GetEditUpdateUserViewModel(int id, string userName);
        bool CheckExistingUser(string userName, int userId);        
        //Public Methods that Involve the Creation of Users
        int CreateUser(UpdateUserViewModel model, string userName);
        int UpdateUser(UpdateUserViewModel model, string userName);
    }
}
