using Helpline.Models;
using Helpline.ViewModels;
using Helpline.ViewModels.TicketViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Services.Interfaces
{
    interface ITicketServices
    {
        //Public methods that create View Models for Views
        TicketDetailsViewModel Details(int id, string userName, bool emailSent);
        TicketIndexViewModel Index(string userName);        
        UpdateTicketViewModel GetCreateViewModel(string UserName);
        UpdateTicketViewModel GetEditViewModel(int id, string userName);
        UpdateNoteViewModel GetUpdateNotesViewModel(int id, string userName);
        //Public method that involves the creation of the ticket and it's related objects
        int Create(UpdateTicketViewModel model);
        bool Update(UpdateTicketViewModel model);        
        void CreateNote(UpdateTicketViewModel model);
        void UpdateNote(UpdateNoteViewModel model);
        //Public methods that deal with the excel generator 

        byte[] GetExcelTicketData(TicketIndexViewModel model, string userName);
        //Public methods that gather data for JSON objects        
        IEnumerable<TicketListViewModel> GetTicketData(int? routingCategoryId, int? programId, int? requestTypeId, int? communicationTypeId, string referredFrom, string bureau, 
            string phoneNumber, string streetNumber, string streetName, string city, int? countyId, string state, int? statusId,  DateTime? startDate, DateTime? endDate, 
            string trackingNumber, string lastName, string firstName, string affilation, string createdByUserName, string userName);
        IEnumerable<dynamic> GetTicketArchiveData(int? routingCategoryId, int? programId, int? requestTypeId, int? communicationTypeId, string phoneNumber, int? countyId, string state,
            int? statusId, DateTime? startDate, DateTime? endDate, string streetNumber, string streetName, string city, 
            string trackingNumber, string lastName, string firstName, string createdByUserName, string userName);
        Object GetTicketSatistics(TicketIndexViewModel model);
    }
}
