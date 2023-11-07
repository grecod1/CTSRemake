using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.TicketViewModels
{
    /// <summary>
    /// This view model is made to build up the 
    /// Images View. The images are viewed through 
    /// an API call.
    /// </summary>
    public class TicketImagesViewModel
    {
        public int TicketId { get; set; }

        [Display(Name = "Upload Image")]
        [Required]
        public HttpPostedFile Image { get; set; }        

        [RegularExpression(@"^[^@|$\|%\|/\|^\|(\|)\|?\|*\|<|>|+\|=]*$", ErrorMessage = "Invalid characters")]
        [MaxLength(10000, ErrorMessage = "Too many characters")]
        public string Description { get; set; }

        /// <summary>
        /// Builds the Ticket Images 
        /// View Model. 
        /// </summary>
        /// <param name="ticketId">Id of the ticket the images are under.</param>
        public TicketImagesViewModel(int ticketId)
        {
            TicketId = ticketId;
        }
    }
}