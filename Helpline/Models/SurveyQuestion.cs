using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}