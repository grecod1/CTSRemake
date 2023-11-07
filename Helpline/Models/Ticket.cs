
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{    
    /// <summary>
    /// Tickets are used to store information 
    /// regarding calls to the Helpline office. 
    /// The Ticket Model is considered the main 
    /// model for CTS.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// The Id is also used as the tracking 
        /// number for the ticket.
        /// </summary>
        public int Id { get; set; }        
        
        public string AssignedUser { get; set; }        
        
        /// <summary>
        /// Determines if the ticket is 
        /// in a pending, complete, or diabled 
        /// status.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Determines if the ticket is 
        /// in a pending, complete, or diabled 
        /// status.
        /// </summary>
        public Status Status { get; set; }                
        
        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
                
        public int CommunicationTypeId { get; set; }
        public CommunicationType CommunicationType { get; set; }
        
        /// <summary>
        /// There can be a maxium of 5 for any 
        /// type of phone number under a ticket.
        /// </summary>
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        
        /// <summary>
        /// A ticket can be routed to multiple areas. 
        /// Every time a routing category or program 
        /// gets updated a new route is created under 
        /// a ticket. The most recently created route 
        /// is considered the current route of the ticket.
        /// </summary>
        public ICollection<Route> Routes { get; set; }
        
        /// <summary>
        /// There is always two addresses under a ticket. 
        /// One is the mailing address and the other is 
        /// the physical address.
        /// </summary>
        public ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Emails that were provided or associated with a ticket
        /// </summary>
        public ICollection<Email> Emails { get; set; }

        /// <summary>
        /// This is the same value as the 
        /// Id of the Ticket.
        /// </summary>
        public string TrackingNumber { get; set; }
        
        /// <summary>
        /// First name of the caller.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last name of the caller.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Any company or office the caller
        /// represents.
        /// </summary>
        public string Affiliation { get; set; }
        
        /// <summary>
        /// This is determined by a list of strings 
        /// that represent every bureau in DPI.
        /// </summary>
        public string Bureau { get; set; }
        
        /// <summary>
        /// How did the caller hear about Helpline, 
        /// this can be from a newspaper, article, 
        /// .etc
        /// </summary>
        public string ReferredFrom { get; set; }
        
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}