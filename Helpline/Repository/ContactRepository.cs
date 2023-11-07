using Helpline.Data;
using Helpline.Models;
using Helpline.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{
    public class ContactRepository : IContactRepository
    {
        private HelplineDbContext _dbContext;

        public ContactRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        protected void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        #region QUERY

        public int GetContactTypeId(string contactType)
        {
             return _dbContext.ContactTypes.Where(c => c.Name == contactType).Select(c => c.Id).FirstOrDefault();            
        }

        public int GetAddressTypeId(string addressType)
        {
            return _dbContext.AddressTypes.Where(a => a.Name == addressType).Select(a => a.Id).FirstOrDefault();
        }

        public int GetPhoneTypeId(string phoneType)
        {
            return _dbContext.PhoneTypes.Where(p => p.PhoneTypeName == phoneType).Select(p => p.Id).FirstOrDefault();
        }

        #endregion

        
    }
}