using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.AdministratorDTOs
{
    /// <summary>
    /// This DTO is called within other DTOs. 
    /// This is used for the column that displays
    /// the status.That Status Class is used
    /// for a CSS class that controls the color of
    /// the text while the status name is displayed
    /// </summary>
    public class StatusFieldDTO
    {

        /// <summary>
        /// Displayed Name of the status
        /// </summary>
        public string StatusName { get; set; }
        
        /// <summary>
        /// CSS color of the status
        /// </summary>
        public string StatusClass { get; set; }

        /// <summary>
        /// Contructs the sub dto
        /// </summary>
        /// <param name="isActive">
        /// Determines if status is active or inactive.
        /// </param>
        public StatusFieldDTO(bool isActive)
        {
            if (isActive)
            {
                StatusName = "Active";
                StatusClass = "text-success";
            }
            else
            {
                StatusName = "Disabled";
                StatusClass = "text-warning";
            }
        }
    }
}