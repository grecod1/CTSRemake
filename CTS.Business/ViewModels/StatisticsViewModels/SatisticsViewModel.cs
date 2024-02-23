using CTS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Helpline.ViewModels.StatisticsViewModels
{
    public class SatisticsViewModel
    {
        /*Index view model for the County Satistic View, consist of 
         *the date and list of programs user can select. List information 
         *is represented as JSON data.*/
        public DateTime? Date { get; set; }        
        [Display(Name = "Programs")]
        public int? ProgramId { get; set; }
        public IEnumerable<Program> Programs { get; set; }
    }
}