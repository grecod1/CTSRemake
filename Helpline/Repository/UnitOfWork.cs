using Helpline.Data;
using Helpline.Models;
using Helpline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{
    public class UnitOfWork : IDisposable
    {
        private HelplineDbContext context;

        //Non Generic Repositories that return non crud database calls                
        private TicketRepository ticketRepository;
        private EventLogServices eventLogServices;        
        private ErrorRepository errorRepository;
        

        #region private properties

        // Generic Repositories that return basic Crud actions            

        private GenericRepository<Address> addresses;
        private GenericRepository<AddressType> addressTypes;
        private GenericRepository<CommunicationType> communicationTypes;
        private GenericRepository<County> counties;
        private GenericRepository<DropDownListItem> dropDownListItems;
        private GenericRepository<Email> emails;
        private GenericRepository<ErrorLog> errorLogs;
        private GenericRepository<EventLog> eventLogs;
        private GenericRepository<EventType> eventTypes;
        private GenericRepository<Image> images;
        private GenericRepository<Note> notes;
        private GenericRepository<OfficeLocation> officeLocations;
        private GenericRepository<PhoneNumber> phoneNumbers;
        private GenericRepository<PhoneType> phoneTypes;
        private GenericRepository<Program> programs;
        private GenericRepository<RequestType> requestTypes;
        private GenericRepository<Role> roles;
        private GenericRepository<Route> routes;
        private GenericRepository<RoutingCategory> routingCategories;
        private GenericRepository<RoutingEmail> routingEmails;
        private GenericRepository<Status> statuses;
        private GenericRepository<Ticket> tickets;
        private GenericRepository<User> users;


        public UnitOfWork()
        {
            context = new HelplineDbContext();
        }

        private bool disposed = false;

        #endregion

        #region Public Non Generic Repository Properties 

        public EventLogServices EventLogServices
        {
            get
            {
                if(this.eventLogServices == null)
                {
                    this.eventLogServices = new EventLogServices();
                }

                return eventLogServices;
            }
        }                

        public TicketRepository TicketRepository
        {
            get
            {
                if(this.ticketRepository == null)
                {
                    this.ticketRepository = new TicketRepository(context);
                }

                return ticketRepository;
            }
        }        

        public ErrorRepository ErrorRepository
        {
            get
            {
                if(this.errorRepository == null)
                {
                    this.errorRepository = new ErrorRepository(context);
                }

                return errorRepository;
            }
        }

        #endregion

        #region Generic Repositories for Entity Models

        public GenericRepository<Address> Addresses
        {
            get
            {
                if (this.addresses == null)
                {
                    this.addresses = new GenericRepository<Address>(context);
                }

                return addresses;
            }
        }

        public GenericRepository<AddressType> AddressTypes
        {
            get
            {
                if (this.addressTypes == null)
                {
                    this.addressTypes = new GenericRepository<AddressType>(context);
                }

                return addressTypes;
            }
        }

        public GenericRepository<CommunicationType> CommunicationTypes
        {
            get
            {
                if (this.communicationTypes == null)
                {
                    this.communicationTypes = new GenericRepository<CommunicationType>(context);
                }

                return communicationTypes;
            }
        }

        public GenericRepository<County> Counties
        {
            get
            {
                if (this.counties == null)
                {
                    this.counties = new GenericRepository<County>(context);
                }

                return counties;
            }
        }

        public GenericRepository<DropDownListItem> DropDownListItems
        {
            get
            {
                if (this.dropDownListItems == null)
                {
                    this.dropDownListItems = new GenericRepository<DropDownListItem>(context);
                }

                return dropDownListItems;
            }
        }

        public GenericRepository<Email> Emails
        {
            get
            {
                if (this.emails == null)
                {
                    this.emails = new GenericRepository<Email>(context);
                }

                return emails;
            }
        }

        public GenericRepository<ErrorLog> ErrorLogs
        {
            get
            {
                if (this.errorLogs == null)
                {
                    this.errorLogs = new GenericRepository<ErrorLog>(context);
                }

                return errorLogs;
            }
        }

        public GenericRepository<EventLog> EventLogs
        {
            get
            {
                if (this.eventLogs == null)
                {
                    this.eventLogs = new GenericRepository<EventLog>(context);
                }

                return eventLogs;
            }
        }

        public GenericRepository<EventType> EventTypes
        {
            get
            {
                if (this.eventTypes == null)
                {
                    this.eventTypes = new GenericRepository<EventType>(context);
                }

                return eventTypes;
            }
        }

        public GenericRepository<Image> Images 
        {
            get
            {
                if(this.images == null)
                {
                    this.images = new GenericRepository<Image>(context);
                }

                return images;
            }
        }

        public GenericRepository<Note> Notes
        {
            get
            {
                if (this.notes == null)
                {
                    this.notes = new GenericRepository<Note>(context);
                }

                return notes;
            }
        }

        public GenericRepository<OfficeLocation> OfficeLocations
        {
            get
            {
                if (this.officeLocations == null)
                {
                    this.officeLocations = new GenericRepository<OfficeLocation>(context);
                }

                return officeLocations;
            }
        }

        public GenericRepository<PhoneNumber> PhoneNumbers
        {
            get
            {
                if (this.phoneNumbers == null)
                {
                    this.phoneNumbers = new GenericRepository<PhoneNumber>(context);
                }

                return phoneNumbers;
            }
        }

        public GenericRepository<PhoneType> PhoneTypes
        {
            get
            {
                if (this.phoneTypes == null)
                {
                    this.phoneTypes = new GenericRepository<PhoneType>(context);
                }

                return phoneTypes;
            }
        }

        public GenericRepository<Program> Programs
        {
            get
            {
                if (this.programs == null)
                {
                    this.programs = new GenericRepository<Program>(context);
                }

                return programs;
            }
        }

        public GenericRepository<RequestType> RequestTypes
        {
            get
            {
                if (this.requestTypes == null)
                {
                    this.requestTypes = new GenericRepository<RequestType>(context);
                }

                return requestTypes;
            }
        }

        public GenericRepository<Role> Roles
        {
            get
            {
                if (this.roles == null)
                {
                    this.roles = new GenericRepository<Role>(context);
                }

                return roles;
            }
        }

        public GenericRepository<Route> Routes
        {
            get
            {
                if (this.routes == null)
                {
                    this.routes = new GenericRepository<Route>(context);
                }

                return routes;
            }
        }

        public GenericRepository<RoutingCategory> RoutingCategories
        {
            get
            {
                if (this.routingCategories == null)
                {
                    this.routingCategories = new GenericRepository<RoutingCategory>(context);
                }

                return routingCategories;
            }
        }

        public GenericRepository<RoutingEmail> RoutingEmails
        {
            get
            {
                if (this.routingEmails == null)
                {
                    this.routingEmails = new GenericRepository<RoutingEmail>(context);
                }

                return routingEmails;
            }
        }

        public GenericRepository<Status> Statuses
        {
            get
            {
                if (this.statuses == null)
                {
                    this.statuses = new GenericRepository<Status>(context);
                }

                return statuses;
            }
        }

        public GenericRepository<Ticket> Tickets
        {
            get
            {
                if (this.tickets == null)
                {
                    this.tickets = new GenericRepository<Ticket>(context);
                }

                return tickets;
            }
        }

        public GenericRepository<User> Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new GenericRepository<User>(context);
                }

                return users;
            }
        }

        #endregion


        #region Save and Dispose Methods

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}