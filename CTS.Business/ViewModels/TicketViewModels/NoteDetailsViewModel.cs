using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.TicketViewModels
{
    /// <summary>
    /// This is a sub view model that is used 
    /// within the Ticket Details View Model. 
    /// This is only to display the notes under the 
    /// ticket.    
    /// </summary>
    public class NoteDetailsViewModel
    {
        public int Id { get; set; }
        public string? CallerRemarks { get; set; }
        public string? Comments { get; set; }
        public string? Resolutions { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? UserName { get; set; }
        public string? CreatedBy_UserName { get; set; }
    }
}