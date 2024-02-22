using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.TicketViewModels
{
    public class UpdateNoteViewModel
    {
        /* View Model used in the Edit Note View */
        public int NoteId { get; set; }
        public int TicketId { get; set; }

        [Display(Name = "Update Caller Remarks")]
        [MaxLength(100000, ErrorMessage = "Too many characters")]
        public string CallerRemarks { get; set; }

        [Display(Name = "Update Comments")]
        [MaxLength(100000, ErrorMessage = "Too many characters")]
        public string Comments { get; set; }

        [Display(Name = "Update Call Resolution")]
        [MaxLength(100000, ErrorMessage = "Too many characters")]
        public string Resolution { get; set; }

        public string CreatedByUser { get; set; }
        public string CreationDate { get; set; }
        public string LastModifiedByUserName { get; set; }
    }
}