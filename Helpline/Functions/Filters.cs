using Helpline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Helpline.Functions
{
    public class Filters
    {
        public Expression<Func<RequestType, bool>> RequestTypesByStatus(bool isActive)
        {
            return (RequestType requestType) => requestType.IsActive == isActive;
        }

        public Expression<Func<RoutingCategory, bool>> RoutingCategoriesByStatus(bool isActive)
        {
            return (RoutingCategory routingCategory) => routingCategory.IsActive == isActive;
        }

        public Expression<Func<RoutingCategory, bool>> RoutingCategoryName(string name)
        {
            return (RoutingCategory routingCategory) => routingCategory.Name == name;
        }

        public Expression<Func<Program, bool>> ProgramsByStatus(bool isActive)
        {
            return (Program program) => program.IsActive == isActive;
        }

        public Expression<Func<Status, bool>> StatusId(int id)
        {
            return (Status status) => status.Id == id;  
        }

        public Expression<Func<Status, bool>> StatusName(string name)
        {
            return (Status status) => status.Name == name;
        }

        public Expression<Func<Ticket, bool>> TicketId(int id)
        {
            return (Ticket ticket) => ticket.Id == id;
        }

        public Expression<Func<Route, bool>> RoutesUnderTicket(int ticketId)
        {
            return (Route route) => route.TicketId == ticketId;
        }

        public Expression<Func<Note, bool>> NoteId(int id)
        {
            return (Note note) => note.Id == id;
        }

        public Expression<Func<County, bool>> CountyName(string name)
        {
            return (County county) => county.Name == name;
        }

        public Expression<Func<AddressType, bool>> AddressTypeName(string name)
        {
            return (AddressType addressType) => addressType.Name == name;
        }

        public Expression<Func<Address, bool>> AddressesUnderTicket(int ticketId)
        {
            return (Address address) => address.TicketId == ticketId;
        }

        public Expression<Func<Address, bool>> AddressUnderTicket(int ticketId, int addressTypeId)
        {
            return (Address address) => address.TicketId == ticketId && address.AddressTypeId == addressTypeId;
        }

        public Expression<Func<PhoneType, bool>> PhoneTypeName(string name)
        {
            return (PhoneType phoneType) => phoneType.PhoneTypeName == name;
        }

        public Expression<Func<PhoneNumber, bool>> PhoneNumbersUnderTicket(int ticketId)
        {
            return (PhoneNumber phoneNumber) => phoneNumber.TicketId == ticketId;
        }

        public Expression<Func<Email, bool>> EmailAddressesUnderTicket(int ticketId)
        {
            return (Email email) => email.TicketId == ticketId;
        }

        public Expression<Func<Note, bool>> NotesUnderTicket(int ticketId)
        {
            return (Note note) => note.TicketId == ticketId;
        }

        public Expression<Func<RoutingEmail, bool>> RoutingEmailsUnderRoutingCategory(int routingCategoryId)
        {
            return (RoutingEmail routingEmail) => routingEmail.RoutingCategoryId == routingCategoryId;
        }
    }
}