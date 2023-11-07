using Helpline.DTOs.AdministratorDTOs;
using Helpline.Models;
using Helpline.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    interface IAdministratorServices
    {
        //Method that gets the Admin Index View Model for the Index view for Office Locations, Programs, Request Types, and Information Links
        AdminIndexViewModel Index(int statusNumber);
        //Methods that deal with Programs        
        IEnumerable<AdminListDTO> GetPrograms(int statusId);
        UpdateProgramViewModel GetUpdateProgramViewModel(int id);
        int Edit(UpdateProgramViewModel model);
        int Create(UpdateProgramViewModel model);
        bool PreExistingProgram(string name, int id = 0);
        //Methods that deal with Request Types        
        IEnumerable<AdminListDTO> GetRequestTypes(int statusNumber);        
        UpdateRequestTypeViewModel GetEditRequestTypeViewModel(int id);
        int Edit(UpdateRequestTypeViewModel model);
        int Create(UpdateRequestTypeViewModel model);
        bool PreExistingRequestType(string name, int id = 0);
        //Methods that deal with Routing Categories        
        IEnumerable<AdminListDTO> GetRoutingCategories(int statusNumber);
        UpdateRoutingCategoryViewModel GetEditRoutingCategoryViewModel(int id);
        int Edit(UpdateRoutingCategoryViewModel model, string userName);        
        int Create(UpdateRoutingCategoryViewModel model, string userName);
        bool PreExistingRoutingCategory(string name, int id = 0);
        //Methods that deal with Regions        
        IEnumerable<AdminListDTO> GetOfficeLocations(int statusNumber);
        UpdateOfficeLocationViewModel GetOfficeLocation(int id);
        int Edit(UpdateOfficeLocationViewModel model);
        int Create(UpdateOfficeLocationViewModel model);
        bool PreExistingOfficeLocation(string name, int id = 0);
        ReportViewModel GetReportViewModel();
        IEnumerable<ChartDTO> GetBarChartData(DateTime startDate, DateTime? endDate);
        IEnumerable<ChartDTO> GetLineChartData(int programId,
            DateTime startDate,
            DateTime? endDate,
            int? routingCategoryId,
            int? requestTypeId,
            int? communicationTypeId,
            int? countyId,
            string city,
            string streetName);
    }
}
