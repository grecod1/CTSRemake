using Helpline.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Helpline.ViewModels
{
    /// <summary>
    /// This is the view model that builds up 
    /// the view for the create and edit ticket views.
    /// </summary>
    public class UpdateTicketViewModel
    {

        #region Ids
        
        /// <summary>
        /// This has a value in the Edit 
        /// Ticket View
        /// </summary>
        public int TicketId { get; set; }

        #endregion

        #region Dropdown lists

        [Display(Name = "Program")]
        public int ProgramId { get; set; }
        public IEnumerable<Program> Select_Program { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public IEnumerable<Status> Select_Status { get; set; }

        [Display(Name = "Request Type")]
        public int RequestTypeId { get; set; }
        public IEnumerable<RequestType> Select_RequestType { get; set; }

        [Display(Name = "Communication Type")]
        public int CommunicationTypeId { get; set; }
        public IEnumerable<CommunicationType> Select_CommunicationType { get; set; }


        [Display(Name = "Routing Category")]
        public int RouteCategoryId { get; set; }
        public IEnumerable<RoutingCategory> Select_RoutingCategory { get; set; }


        [Display(Name = "Caller Affilation")]
        public string Affilation { get; set; }

        public string Bureau { get; set; }
        public IEnumerable<string> Select_Bureau { get; set; }

        [Display(Name = "How did you hear about us?")]
        public string ReferredFrom { get; set; }
        public IEnumerable<string> Select_ReferredFrom { get; set; }

        //Select list used for county and state of both Mailing and Physical Address
        public IEnumerable<string> Select_States { get; set; }
        public List<County> Select_Counties { get; set; }

        //Only used in Edit View, determines what the user wants to edit with the ticket
        
        /// <summary>
        /// This is a magical string that is determined 
        /// by the Select_EditOption drop down list. This
        /// will determine if the user wants to update ticket
        ///  and/or routing information, update the status, 
        ///  or just add notes.
        /// </summary>
        [Display(Name = "Choose your action")]
        public string EditOption { get; set; }
        
        /// <summary>
        /// This is a list of magical strings 
        /// that determines the value for the 
        /// EditOption string property.
        /// </summary>
        public IEnumerable<string> Select_EditOption { get; set; }

        #endregion


        #region Phone related fields
        /*Integer values that represent the phone type Id.These values are assigned 
         when the Create or Edit Ticket View loads and are added as html attributes that 
         work with the jQuery Script that handles the add phone list. */

        /// <summary>
        /// This stores Home Phone Type Id 
        /// in a hidden input field.This is 
        /// meant to work with the jQuery code.
        /// </summary>
        public int HomePhoneTypeId { get; set; }

        /// <summary>
        /// This stores Work Phone Type Id 
        /// in a hidden input field. This is 
        /// meant to work with the jQuery code.
        /// </summary>
        public int WorkPhoneTypeId { get; set; }

        /// <summary>
        /// This stores Moblile phone Type Id 
        /// in a hidden input field. This is 
        /// meant to work with the jQuery code.
        /// </summary>
        public int MobilePhoneTypeId { get; set; }        
        
        /// <summary>
        /// List of phone numbers being returned from the view. 
        /// The JavaScript creates a list of html tags that represent 
        /// phone numbers and the name property of the HTML tags represnt 
        /// the array value of each phone number.
        /// </summary>
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        #endregion

        //Input for Name and Email

        #region Name and Email

        [Display(Name = "First Name")]                
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]                
        public string LastName { get; set; }        

        [Display(Name = "Contact Email")]        
        public string Email { get; set; }

        #endregion

        #region Mailing Address fields

        //Mailing Address input fields
        [Display(Name ="Post Office Box")]
        public string MailingAddress_POBox { get; set; }

        [Display(Name = "Number")]
        public string MailingAddress_StreetNumber { get; set; }

        [Display(Name = "Street Name")]
         public string MailingAddress_StreetName { get; set; }

        [Display(Name = "Apt #")]
         public string MailingAddress_AptNumber { get; set; }

        [Display(Name = "City")]  
        public string MailingAddress_City { get; set; }

        //Uses the list States
        [Display(Name = "State")]        
        public string MailingAddress_State { get; set; }

        [Display(Name = "Zip Code")]    
        public string MailingAddress_Zip { get; set; }

        //Uses the list of Counties
        [Display(Name = "County")]
        [Required(ErrorMessage = "County is required, if the address is outside of florida or you are not sure then select \"NONE\" ")]
        public int MailingAddress_CountyId { get; set; }

        #endregion

        #region Physcial Address

        //Physical Address input fields
        [Display(Name = "Number")]     
        public string PhysicalAddress_StreetNumber { get; set; }

        [Display(Name = "Street Name")]   
        public string PhysicalAddress_StreetName { get; set; }

        [Display(Name = "Apt #")] 
        public string PhysicalAddress_AptNumber { get; set; }

        [Display(Name = "City")]   
        public string PhysicalAddress_City { get; set; }

        //Uses the list States
        [Display(Name = "State")]        
        public string PhysicalAddress_State { get; set; }

        [Display(Name = "Zip Code")]       
        public string PhysicalAddress_Zip { get; set; }

        //Uses the list of Counties
        [Display(Name = "County")]
        [Required(ErrorMessage ="County is required, if the address is outside of florida select \"NONE\" ")]
        public int PhysicalAddress_CountyId { get; set; }

        #endregion

        #region Notes and Image fields 
        //Input field for notes
        [Display(Name = "Reason for Contact")]
        [Required]
        public string CallerRemarks { get; set; }

        [Display(Name = "Notes")]
        public string Comments { get; set; }

        [Display(Name = "Resolution")]
        public string Resolution { get; set; }

        [Display(Name = "Upload Image")]        
        public HttpPostedFileBase TicketImage { get; set; }

        #endregion

        //Values and drop down lists used to determine multiple factors

        #region Other properties




        //Used to determine if the user will add or edit an address
        [Display(Name = "This there an address involved")]
        public bool AddressInvolved { get; set; }

        //Used to determine if the Physical Address will be the same as the Mailing Address
        [Display(Name = "Same as mailing address?")]
        public bool PhysicalSameAsMailingAddress { get; set; }

        //Determines if the Mailing Address is a PO Box
        [Display(Name ="Is this a Post Office Box?")]
        public bool IsPOBox { get; set; }
                      
        /// <summary>
        /// Represents the user who created the ticket
        /// </summary>
        public string AssignedUserName { get; set; }

        #endregion
    }
}