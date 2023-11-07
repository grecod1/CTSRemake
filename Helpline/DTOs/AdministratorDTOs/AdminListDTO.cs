using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.AdministratorDTOs
{
    /// <summary>
    /// This DTO is used as JSON data 
    /// for the data tables in all 
    /// administrator related index views 
    /// including programs, request types, 
    /// routing categories, and office 
    /// locations.
    /// </summary>
    public class AdminListDTO
    {
        
        /// <summary>
        /// Id of the object
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the object
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Short abbrevation of the object.
        /// Only used for programs.
        /// </summary>
        public string Abbreviation { get; set; }
        public StatusFieldDTO Status { get; set; }
    }
}