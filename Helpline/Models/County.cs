using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// County the address is under. 
    /// One to many relationship to 
    /// the Address Model.
    /// </summary>
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}