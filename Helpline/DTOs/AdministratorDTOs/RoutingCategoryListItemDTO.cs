using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.AdministratorDTOs
{
    /// <summary>
    /// This view model is used to display a 
    /// list of routing categories within the 
    /// Routing Index View.
    /// </summary>
    public class RoutingCategoryListItemDTO
    {
        /// <summary>
        /// Id of the routing Category
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the Routing Category
        /// </summary>
        public string Name { get; set; }
        public string Email { get; set; }
        public StatusFieldDTO Status { get; set; }
    }
}