using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.SurveyViewModels
{
    public class TicketSurveyViewModel
    {
        /*View Model for displaying Ticket Survey information to the user */
        public int TicketId { get; set; }
        public string SurveyQuestion { get; set; }
        public IEnumerable<string> SurveyAnswers { get; set; }
    }
}