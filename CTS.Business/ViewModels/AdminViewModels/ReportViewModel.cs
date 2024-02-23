using CTS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helpline.ViewModels.AdminViewModels
{
    /// <summary>
    /// This is the view model for the 
    /// Report View.
    /// </summary>
    public class ReportViewModel
    {
        //Search Criteria for Program Chart Report
        /// <summary>
        /// Determines the selected program for the 
        /// line chart.
        /// </summary>
        [Display(Name = "Program")]
        public int? ProgramId { get; set; }
        public IEnumerable<Program> Select_Program { get; set; }

        /// <summary>
        /// Start date for the line chart.
        /// </summary>
        [Display(Name = "Start Date")]
        public DateTime? StartDate_SelectedProgram { get; set; }

        /// <summary>
        /// End date for the line chart.
        /// </summary>
        [Display(Name = "End Date")]
        public DateTime? EndDate_SelectedProgram { get; set; }

        /// <summary>
        /// Optional filter for the line chart.
        /// </summary>
        [Display(Name = "Routing Category")]
        public int? RoutingCategoryId { get; set; }
        public IEnumerable<RoutingCategory> Select_RoutingCategory { get; set; }

        /// <summary>
        /// Optional filter for the line chart.
        /// </summary>
        [Display(Name = "Request Type")]
        public int? RequestTypeId { get; set; }
        public IEnumerable<RequestType> Select_RequestType { get; set; }

        /// <summary>
        /// Optional filter for the line chart.
        /// </summary>
        [Display(Name = "Communication Type")]
        public int? CommunicationTypeId { get; set; }
        public IEnumerable<CommunicationType> Select_CommunicationType { get; set; }

        /// <summary>
        /// Optional filter for the line chart.
        /// </summary>
        [Display(Name = "County")]
        public int? CountyId { get; set; }
        public IEnumerable<County> Select_County { get; set; }

        /// <summary>
        /// Optional filter for the line chart.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Optional filter for the line chart.
        /// </summary>
        [Display(Name = "Street Name")]
        public string? StreetName { get; set; }

        //End Search Criteria for Program Chart

        //Search Criteria for Total Programs

        /// <summary>
        /// Start date for the bar chart.
        /// </summary>
        [Display(Name = "Start Date")]
        public DateTime? StartDate_TotalPrograms { get; set; }

        /// <summary>
        /// Start date for the bar chart.
        /// </summary>
        [Display(Name = "End Date")]
        public DateTime? EndDate_TotalPrograms { get; set; }

        //End Search Criterai for Total Programs        

    }
}