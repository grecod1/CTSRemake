using Helpline.Models;
using Helpline.Repository;
using Helpline.Repository.Interfaces;
using Helpline.Services.Interfaces;
using Helpline.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Services
{
    public class ContactServices : IContactServices
    {
        // Must create interface


        IContactRepository ContactRepository = new ContactRepository();

        #region Public Methods that involve the creation of Contact Objects

        //public int Post(UpdateTicketViewModel model)  //FIX
        //{
        //    try
        //    {
        //        //int contactId = createContact(model); Class Removed
        //        if (model.PhysicalSameAsMailingAddress)
        //        {
        //            sameAsMailingAddress(model);
        //        }
        //        else if(model.IsPOBox)
        //        {
        //            model.MailingAddress_StreetNumber = "";
        //            model.PhysicalAddress_AptNumber = "";
        //            model.MailingAddress_StreetName = $"PO BOX #{model.MailingAddress_POBox}";
        //        }

        //        createAddress("Mailing", model.MailingAddress_StreetNumber, model.MailingAddress_StreetName, model.MailingAddress_AptNumber, model.MailingAddress_City, model.MailingAddress_State, model.MailingAddress_Zip, 
        //            model.MailingAddress_CountyId, model.AssignedUserName, (int)model.TicketId);
        //        createAddress("Physical", model.PhysicalAddress_StreetNumber, model.PhysicalAddress_StreetName, model.PhysicalAddress_AptNumber, model.PhysicalAddress_City, model.PhysicalAddress_State, model.PhysicalAddress_Zip, 
        //            model.PhysicalAddress_CountyId, model.AssignedUserName, (int)model.TicketId);
                
        //        foreach(PhoneNumber phoneNumber in model.PhoneNumbers)
        //        {
        //            createPhoneNumber(phoneNumber.PhoneTypeId, phoneNumber.Number, model.AssignedUserName, (int)model.TicketId);
        //        }

        //        int emailId = model.Email != null ? createEmail(model.Email, model.AssignedUserName, (int)model.TicketId) : 0;

        //        return contactId;
        //    }
        //    catch(Exception exception)
        //    {
        //        throw;
        //    }            
        //}

        #endregion


        #region private methods that create database objects          

        //private int createContact(UpdateTicketViewModel model)  //Class Removed
        //{
        //    int contactTypeId = ContactRepository.GetContactTypeId("OTHER"); //Needs to edit 
        //    Caller contact = new Caller()
        //    {                
        //        TicketId = (int)model.TicketId,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        CreatedBy_UserName = model.AssignedUserName,
        //        CreationDate = DateTime.Now,
        //        LastModifiedBy_UserName = model.AssignedUserName,
        //        ModifiedDate = DateTime.Now
        //    };

        //    contact.Id = ContactRepository.AddContact(contact);

        //    return contact.Id;
        //}
        
        
        

        

    }
}