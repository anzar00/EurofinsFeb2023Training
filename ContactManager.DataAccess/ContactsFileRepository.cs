using ContactManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess
{//Contact Manager Console App - Data Access Layer - File Repository
    public class ContactsFileRepository : IContactsRepository
    {
        public ContactsFileRepository()
        {
            //Checking if file contacts.csv exists

            if(File.Exists("C:\\Training\\Day 11\\contacts.csv"))
            {
                StreamReader reader = new StreamReader("C:\\Training\\Day 11\\contacts.csv");
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] contactDetails = line.Split(',');
                    Contact contact = new Contact();
                    contact.ContactID = int.Parse(contactDetails[0]);
                    contact.Name = contactDetails[1];
                    contact.EmailID = contactDetails[2];
                    contact.Mobile = contactDetails[3];
                    contact.Location = contactDetails[4];
                    line = reader.ReadLine();
                }
                reader.Close();
            }
        }
        
        public void AddContact(Contact contact)
        {
            // Adding new contact to the memory and then storing it in the file 
            Contact c = new Contact();
            Console.WriteLine("Enter Contact ID:");
            c.ContactID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Contact Name:");
            c.Name = Console.ReadLine();
            Console.WriteLine("Enter Email ID:");
            c.EmailID = Console.ReadLine();
            Console.WriteLine("Enter Mobile:");
            c.Mobile = Console.ReadLine();
            Console.WriteLine("Enter Location:");
            c.Location = Console.ReadLine();
            
            string csvData = $"{c.ContactID},{c.Name},{c.EmailID},{c.Mobile},{c.Location}";

            StreamReader reader = new StreamReader("C:\\Training\\Day 11\\contacts.csv");
            List<Contact> contacts = new List<Contact>();
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');
                c.ContactID = int.Parse(data[0]);
                c.Name = data[1];
                c.EmailID = data[2];
                c.Mobile = data[3];
                c.Location = data[4];
            }

            StreamWriter writer = new StreamWriter("C:\\Training\\Day 11\\contacts.csv",append: true);
            
            




        }

        public void DeleteContact(int contactID)
        {
            // Delete a contact from the file and the memory
            
        }

        public void EditContact(Contact contact)
        {
            // Updating contact details
            
        }

        public Contact GetContact(Contact contact)
        {
            //get contact details
            
        }

        public List<Contact> GetContacts()
        {
            // get all contacts in the file 
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            // get all contacts in the file based on location
        }
    }
}
