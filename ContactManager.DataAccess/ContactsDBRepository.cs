using ContactManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess
{
    public class ContactsDBRepository : IContactsRepository
    {
        public void AddContact(Contact contact)
        {
            IDbConnection conn = GetConnection();

            //Step 2: Prepare SQL Insert Statemnet and Send

            string insertSql = $"insert into Contacts (Name, Email, Phone, Location) values (@name, @email, @phone, @location)";
            IDbCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = insertSql;

            //sqlCommand.Connection = conn;

            //sqlCommand.CommandText = insertSql;
            //sqlCommand.Parameters.AddWithValue(@"name", contact.Name);
            //sqlCommand.Parameters.AddWithValue(@"email", contact.EmailID);
            //sqlCommand.Parameters.AddWithValue(@"mobile", contact.Mobile);
            //sqlCommand.Parameters.AddWithValue(@"mobile", contact.Location);'

            IDbDataParameter p1 = command.CreateParameter();
            p1.ParameterName = "@name";
            p1.Value = contact.Name;
            command.Parameters.Add(p1);

            IDbDataParameter p2 = command.CreateParameter();
            p2.ParameterName = "@email";
            p2.Value = contact.EmailID;
            command.Parameters.Add(p2);

            IDbDataParameter p3 = command.CreateParameter();
            p3.ParameterName = "@phone";
            p3.Value = contact.Mobile;
            command.Parameters.Add(p3);

            IDbDataParameter p4 = command.CreateParameter();
            p4.ParameterName = "@location";
            p4.Value = contact.Location;
            command.Parameters.Add(p4);

            using(conn)
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            //Step 3: Close the connection
            conn.Close();

        }

        public void DeleteContact(int contactID)
        {
            //Delete Contact based on ContactID



        }

        public void EditContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContacts()
        {
            //Display all contacts in the Database
            IDbConnection conn = GetConnection();
            //Step 2: Prepare SQL Select Statemnet and Send
            //string selectSql = $"select * from Contacts";
            IDbCommand command = conn.CreateCommand();
            command.Connection= conn;
            //command.CommandText= selectSql;
            //Using stored procedure
            command.CommandText = "sp_GetAllContacts";
            command.CommandType = CommandType.StoredProcedure;
            //Step 3: Read the data and display
            List<Contact> contacts = new List<Contact>();
            using(conn)
            {
                conn.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Contact c = new Contact();
                    c.ContactID = Convert.ToInt32(reader["ContactID"]);
                    c.Name = reader["Name"].ToString();
                    c.EmailID = reader["Email"].ToString();
                    c.Mobile = reader["Phone"].ToString();
                    c.Location = reader["Location"].ToString();
                    contacts.Add(c);
                }
                reader.Close();
            }
            conn.Close();
            return contacts;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            //Display all contacts in the Database
            IDbConnection conn = GetConnection();
            //Step 2: Prepare SQL Select Statemnet and Send
            string selectSql = $"select * from Contacts where Location = {location}";
            IDbCommand command = conn.CreateCommand();
            command.Connection= conn;
            command.CommandText= selectSql;
            //Step 3: Read the data and display
            List<Contact> contacts = new List<Contact>();
            using (conn)
            {
                conn.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Contact c = new Contact();
                    c.ContactID = Convert.ToInt32(reader["ContactID"]);
                    c.Name = reader["Name"].ToString();
                    c.EmailID = reader["Email"].ToString();
                    c.Mobile = reader["Phone"].ToString();
                    c.Location = reader["Location"].ToString();
                    contacts.Add(c);
                }
                reader.Close();
            }
            conn.Close();
            return contacts;
        }

        private static IDbConnection GetConnection()
        {
            //Step 1. Connect with DB

            //SqlConnection conn = new SqlConnection();
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            IDbConnection conn = factory.CreateConnection();
            string constr = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            conn.ConnectionString = constr;
            return conn;
        }
    }
}
