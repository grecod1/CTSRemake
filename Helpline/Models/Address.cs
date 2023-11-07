using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// There are exactly two addresses per ticket-- one physical address and one mailing address. 
    /// </summary>
    public class Address
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AptNumber { get; set; }        
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IsPOBox { get; set; }
        public int CountyId { get; set; }
        public County County { get; set; }
        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }                
        public string CreatedBy_UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedBy_UserName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}