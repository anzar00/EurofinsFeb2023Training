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

            Address addr = new Address { Area="Brookefield" };

            customer.Address = addr;

            //Employee e1 = new Employee(1, "Test1",60000);

            // Object Initilization Syntax


            Employee e2 = new Employee { EmpId=1 };
            Employee e3 = new Employee { EmpId=2, Name="Test2" };
            Employee e4 = new Employee { EmpId=3, Name="Test 3", Salary=30000 };
            Employee e5 = new Employee { EmpId=1, Salary=500000, Address = new Address { City="Bengaluru" } };
            Employee e6 = new Employee { EmpId=41, Salary=500000, Address = new Address { City="Bengaluru" } };
            Console.ReadKey();
        }
    }

    class Employee
    {
        public int EmpId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        int salary;
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value<10000)
                    salary = 10000;
                salary = value;
            }
        }
        //public Employee(int id, string name, int salary) : this(id,name)
        //{
        //    Salary = salary;
        //}

        //public Employee(int id)
        //{
        //    EmpId = id;
        //}

        //public Employee(int id, string name): this(id)
        //{
        //    Name = name;
        //}
        public Address Address{ get; set; }
    }


    class Customer // Author
    {
        private int id; // field

        //Property with set and get block

        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}

        // Automatic Property
        public int Id
        {
            get;
            set;
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

        public Address Address { get; set; }


    }

    class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; } 
    }
}
