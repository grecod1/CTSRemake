using Helpline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.InformationLinkViewModels
{
    public class InformationLinkIndexViewModel
    {        
        /*View Model for the Information Link View */
        public IEnumerable<InformationLink> InformationLinks { get; set; }
    }
}