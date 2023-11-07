using Helpline.Models;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Helpline.Data
{
    public class HelplineDbContext : DbContext
    {
        public HelplineDbContext() : base("HelplineContext")
        {

        }

        public static HelplineDbContext Create()
        {
            return new HelplineDbContext();
        }

        public DbSet<Ticket> Tickets { get; set; }        
        public DbSet<Route> Routes { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<RoutingCategory> RoutingCategories { get; set; }
        public DbSet<RoutingEmail> RoutingEmails { get; set; }
        public DbSet<CommunicationType> CommunicationTypes { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Program> Programs { get; set; }                
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<OfficeLocation> OfficeLocations { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<EventType> EventTypes { get; set; }        
    }
}