using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    public class InformationLink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public bool IsActive { get; set; }
        public string CreateBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}