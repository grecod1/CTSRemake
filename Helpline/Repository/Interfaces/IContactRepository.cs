using Helpline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface IContactRepository
    {
        //QUERY
        int GetContactTypeId(string contactType);
        int GetAddressTypeId(string addressType);
        int GetPhoneTypeId(string phoneType);
        //INSERT
        //int AddContact(Caller contact); //Class Removed
        int AddAddress(Address address);
        int AddPhoneNumber(PhoneNumber phoneNumber);
        int AddEmail(Email email);
    }
}
