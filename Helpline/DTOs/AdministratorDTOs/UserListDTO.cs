using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.AdministratorDTOs
{
    /// <summary>
    /// This dto is used as JSON data for the
    /// user index table in the User Index View.
    /// </summary>
    public class UserListDTO
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// User name without the DOACS
        /// </summary>
        public string UserName { get; set; }
        public string FullName { get; set; }
        
        /// <summary>
        /// Role Name
        /// </summary>
        public string Role { get; set; }
        public StatusFieldDTO Status { get; set; }
    }
}