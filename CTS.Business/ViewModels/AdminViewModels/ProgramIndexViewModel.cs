using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.AdminViewModels
{
    public class ProgramIndexViewModel
    {        
        public int StatusId { get; set; }
        public IEnumerable<Object>? Select_Status { get; set; }
    }
}