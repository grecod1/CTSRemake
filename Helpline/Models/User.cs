using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// This model represnts every user 
    /// of the CTS application. The doacs username 
    /// is matched with ther username field to determine 
    /// whow the user is.
    /// </summary>
    public class User 
    {
        public int Id { get; set; }
        
        /// <summary>
        /// This field has to be unique within 
        /// the database. This is used to match 
        /// the User Identity DOACS name.
        /// </summary>
        public string UserName { get; set; }        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        
        public int RoleId { get; set; }
        public Role Role { get; set; }
        
        public int OfficeLocationId { get; set; }
        public OfficeLocation OfficeLocation { get; set; }
        
        public bool IsActive { get; set; }
        public string CreatedBy_UserName { get; set; }        
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }        
        public DateTime ModifiedDate { get; set; }        
    }
}