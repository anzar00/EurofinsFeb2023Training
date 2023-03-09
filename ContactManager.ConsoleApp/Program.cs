using ContactManager.DataAccess;
using ContactManager.DataAccess.EFDataAccess;
using ContactManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////ContactsFileRepository contactsFileRepository = new ContactsFileRepository();

            //Console.WriteLine("Contact Manager Application");

            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Get Contact Details");
            Console.WriteLine("5. Get All Contacts");
            Console.WriteLine("6. Get Contacts By Location");
            Console.WriteLine("7. Exit");

            Console.WriteLine("Enter your choice");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //contactsFileRepository.AddContact();
                    //Contact contact = new Contact { Name = "Sachin", EmailID = "sachin@bcci.org", Location = "Mumbai", Mobile = "234234234" };
                    //repo.AddContact(contact);
                    //System.Console.WriteLine("Contact Added");

                    //EF Repository

                    

                    //Add Contact
                    



                    break;
                case 2:
                    //contactsFileRepository.EditContact();
                    break;
                case 3:
                    //contactsFileRepository.DeleteContact();
                    break;
                case 4:
                    //contactsFileRepository.GetContact();

                    //Get contact 
                    IContactsRepository repo = new ContactsEFRepository();
                    

                    break;
                case 5:
                    //contactsFileRepository.GetContacts();

                    //Print the contacts from the database
                    //foreach (Contact con in contacts)
                    //{
                    //    Console.WriteLine(con.ContactID);
                    //    Console.WriteLine(con.Name);
                    //    Console.WriteLine(con.EmailID);
                    //    Console.WriteLine(con.Location);
                    //    Console.WriteLine(con.Mobile);
                    //}
                    
                    break;
                case 6:
                    //contactsFileRepository.GetContactsByLocation();
                    //Print the contacts from the database
                    //foreach (Contact con in contactsByLocation)
                    //{
                    //    Console.WriteLine(con.ContactID);
                    //    Console.WriteLine(con.Name);
                    //    Console.WriteLine(con.EmailID);
                    //    Console.WriteLine(con.Location);
                    //    Console.WriteLine(con.Mobile);
                    //}
                    //Get Contacts by Location
                    

                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            
            //Transfer();
        }

        private static void Transfer()
        {
            Program p = new Program();
            try
            {
                bool isDone = p.TransferFunds(111, 222, 1000);
                if (isDone)
                    System.Console.WriteLine("Transfer successful....");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Transfer failed....");
                System.Console.WriteLine(ex.Message);
            }
        }

        public bool TransferFunds(int fromAcc, int toAcc, int amount)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;

            SqlCommand cmd1 = new SqlCommand($"UPDATE accounts set balance = balance - {amount} WHERE accno = {fromAcc}", conn);

            SqlCommand cmd2 = new SqlCommand($"UPDATE accounts set balance = balance + {amount} WHERE accno = {toAcc}", conn);

            conn.Open();

            SqlTransaction tx = conn.BeginTransaction();

            cmd1.Transaction = tx;
            cmd2.Transaction = tx; 
            
            try
            {
                cmd1.ExecuteNonQuery();
                throw new Exception("Server Error");
                cmd2.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            
            return true;
        }
    }
}
