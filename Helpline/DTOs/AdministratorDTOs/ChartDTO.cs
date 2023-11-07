using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.AdministratorDTOs
{
    /// <summary>
    /// This DTO is used to be converted 
    /// into JSON data for the line and 
    /// bar charts within Reports page. 
    /// The x and y properties must be 
    /// exactly named those properties 
    /// in order for the line and bar 
    /// charts to work. The x property 
    /// reprents the column label while 
    /// the y property represents the 
    /// numeric value.
    /// </summary>
    public class ChartDTO
    {

        public string Label { get; set; }
        public double Value { get; set; }

        public ChartDTO()
        {

        }

        public ChartDTO(string label, double value)
        {
            this.Label = label;
            this.Value = value;
        }

    }
}