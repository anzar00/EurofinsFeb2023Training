using ContactManager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactsFileRepository contactsFileRepository = new ContactsFileRepository();

            Console.WriteLine("Contact Manager Application");

            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Get Contact Details");
            Console.WriteLine("5. Get All Contacts");
            Console.WriteLine("6. Get Contacts By Location");
            Console.WriteLine("7. Exit");

            Console.WriteLine("Enter your choice");

            int choice = int.Parse(Console.ReadLine());

            //switch (choice)
            //{
            //    case 1:
            //        contactsFileRepository.AddContact();
            //        break;
            //    case 2:
            //        contactsFileRepository.EditContact();
            //        break;
            //    case 3:
            //        contactsFileRepository.DeleteContact();
            //        break;
            //    case 4:
            //        contactsFileRepository.GetContact();
            //        break;
            //    case 5:
            //        contactsFileRepository.GetContacts();
            //        break;
            //    case 6:
            //        contactsFileRepository.GetContactsByLocation();
            //        break;
            //    case 7:
            //        Environment.Exit(0);
            //        break;
            //    default:
            //        Console.WriteLine("Invalid Choice");
            //        break;
            //}
        }
    }
}
