using ContactManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess
{
    public interface IContactsRepository
    {
        void AddContact(Contact contact);
        void DeleteContact(int contactID);
        void EditContact(Contact contact);
        Contact GetContact(Contact contact);
        object GetContact(int v);
        List<Contact> GetContacts();
        List<Contact> GetContactsByLocation(string location);
    }
}
