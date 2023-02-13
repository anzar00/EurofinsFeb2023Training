using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace OOCode1
{
    internal class Program
    {
        Customer customer = new Customer(); // HAS - A relationship

        static void Main(string[] args)
        {
            Customer customer = new Customer(); // USES relationship // Consumer
            //customer.SetId(1);
            //customer.SetName("John");
            //customer.SetAge(28);

            //int id = customer.GetId();
            //string name = customer.GetName();
            //int age = customer.GetAge();

            // Setting values using set block of the property
            customer.Id = 5;
            customer.Name = "Jack";
            customer.Age = 25;
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);
            Console.WriteLine(customer.Age);
        }
    }

    class Customer // Author
    {
        private int id; // field

        //Property with set and get block

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //public void SetId(int id) // method
        //{
        //    if (id < 0)
        //    {
        //        id = 0;
        //    }
        //    this.id = id;
        //}
        //public int GetId() // method
        //{
        //    return id;
        //}

        private string name; // field

        // Readonly property 

        public string Name
        {
            get { return name;  }
            set { name = value; }
        }
        //public void SetName(string name) // method
        //{
        //    if (name == null)
        //    {
        //        name = "No name";
        //    }
        //    this.name = name;
        //}
        //public string GetName() // method
        //{
        //    return name;
        //}

        private int age; // field

        //Write only property

        public int Age
        {
            get { return age; }
            set 
            {
                if (age < 18 || age >60)
                {
                    age = 18;
                }
                age = value;
            }
        }

        //public void SetAge(int age) // method
        //{
        //    if(age < 18 || age >60)
        //    {
        //        age = 18;
        //    }
        //    this.age = age;
        //}
        
        //public int GetAge() //method
        //{
        //    return age;
        //}

        
    }
}
