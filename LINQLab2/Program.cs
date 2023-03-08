using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LINQLab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQ to XML
            XDocument xml = XDocument.Load("DataFile.xml");

            //Load the entire XML document and display the xml content on to the screen 

            Console.WriteLine(xml);

            //Show only the name of all Employees 

            XmlNodeList employeeNodes = xml.SelectNodes("//Employee/Name");
            foreach (XmlNode node in employeeNodes)
            {
                Console.WriteLine(node.InnerText);
            }


            //Show the Employee name and ID of all the employees

            //List the names of all female employees only

            //List all the Home Phone numbers 

            //List all the employee names living in ‘Alta’ city 

            //List and sort all the Zip codes

            //List the details of first 2 employees 

            //Count the number of employees living in the state ‘CA’

            //List all female employee names and city only 
        }
    }
}
