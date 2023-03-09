using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.EFDataAccess
{
    public class ContactsEFRepository : IContactsRepository
    {
        private ContactsDBContext db = new ContactsDBContext();
        public void AddContact(Entities.Contact contact)
        {
            db.Contacts.Add(new Contact
            {
                Name = contact.Name,
                Email = contact.EmailID,
                Phone = contact.Mobile,
                Location = contact.Location
            });
            db.SaveChanges();
        }

        public void DeleteContact(int contactID)
        {
            db.Contacts.Remove(db.Contacts.Find(contactID));
            db.SaveChanges();
        }

        public void EditContact(Entities.Contact contact)
        {
            //var contactToEdit = db.Contacts.Find(contact.ContactID);
            //contactToEdit.Name = contact.Name;
            //contactToEdit.Email = contact.EmailID;
            //contactToEdit.Phone = contact.Mobile;
            //contactToEdit.Location = contact.Location;
            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Entities.Contact GetContact(Entities.Contact contact)
        {
            var contacts = db.Contacts.Find(contact.ContactID);
            return new Entities.Contact
            {
                ContactID = contacts.ContactID,
                Name = contacts.Name,
                EmailID = contacts.Email,
                Mobile = contacts.Phone,
                Location = contacts.Location
            };
        }

        public List<Entities.Contact> GetContacts()
        {
            //return db.Contacts.ToList();
            return db.Contacts.Select(c => new Entities.Contact
            {
                ContactID = c.ContactID,
                Name = c.Name,
                EmailID = c.Email,
                Mobile = c.Phone,
                Location = c.Location
            }).ToList();
        }

        public List<Entities.Contact> GetContactsByLocation(string location)
        {
            return db.Contacts.Where(c => c.Location == location).Select(c => new Entities.Contact
            {
                ContactID = c.ContactID,
                Name = c.Name,
                EmailID = c.Email,
                Mobile = c.Phone,
                Location = c.Location
            }).ToList();
        }
    }
}
