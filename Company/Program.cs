using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Driver Code
            Company company = new Company();
            company.Name = "ABC";
            company.IncDate = new DateTime(2010, 1, 1);

            // Create Branches
            Branch Reg = new Branch();
            Branch Corp = new Branch();

            // Create Employees
            Employee emp1 = new Employee();
            emp1.Name = "John";
            emp1.Age = 25;
            emp1.Address = "123, ABC Street";
            emp1.EmpId = 1;
            emp1.Basic = 10000;
            emp1.Experience = 1;

            Employee emp2 = new Employee();
            emp2.Name = "Mary";
            emp2.Age = 30;
            emp2.Address = "456, XYZ Street";
            emp2.EmpId = 2;
            emp2.Basic = 15000;
            emp2.Experience = 3;

            // Add Employees to Company
            company.Employees.Add(emp1);
            company.Employees.Add(emp2);

            // Create Customers
            Customer cust1 = new Customer();
            cust1.Name = "Peter";
            cust1.Age = 35;
            cust1.Address = "789, PQR Street";
            cust1.CustomerId = 1;
            cust1.Email = "axa@aa.com";

            Customer cust2 = new Customer();
            cust2.Name = "Sam";
            cust2.Age = 40;
            cust2.Address = "101, LMN Street";
            cust2.CustomerId = 2;
            cust2.Email = "xxx@sss.com";

            // Add Customers to Company
            company.Customers.Add(cust1);
            company.Customers.Add(cust2);

            // Get Total Salary Payout 
            double TotalSalary = company.GetTotalSalaryPayout();
            Console.WriteLine("Total Salary Payout: " + TotalSalary);

            // Get Total Customers
            int TotalCustomers = company.GetTotalCustomers();
            Console.WriteLine("Total Customers: " + TotalCustomers);

            // Get Total Employees
            int TotalEmployees = company.GetTotalEmployees();
            Console.WriteLine("Total Employees: " + TotalEmployees);

            // Get Employee by EmpId
            Employee emp = company.GetEmployee(2);
            Console.WriteLine("Employee Name: " + emp.Name);
            Console.WriteLine("Employee Salary: " + emp.GetSalary());

            Console.ReadLine();
            
        }
    }

    class Company
    {
        public string Name { get; set; }    
        public DateTime IncDate { get; set; }

        public Branch Reg { get; set; }
        
        public Branch Corp { get; set; }

        public List<Branch> Branches { get; set;} = new List<Branch>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Customer> Customers { get; set; } = new List<Customer> ();

        public Employee GetEmployee(int EmpId)
        {
            Employee emp = Employees.Find(e => e.EmpId == EmpId);
            return emp;
        }
        public double GetTotalSalaryPayout()
        {
            double TotalSalary = 0;
            foreach (Employee emp in Employees)
            {
                TotalSalary += emp.GetSalary();
            }
            return TotalSalary;
        }

        public int GetTotalCustomers()
        {
            return Customers.Count;
        }

        public int GetTotalEmployees()
        {
            return Employees.Count;
        }



    }

    class Branch
    {

    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }

    class Employee : Person
    {
        public int EmpId { get; set; }
        public double Basic { get; set; }
        public double Experience { get; set; }

        // GetSalary Method
        public double GetSalary()
        {
            double Salary = SalaryCalculator.CalculateSalary(Experience, Basic);
            return Salary;
        }


    }

    class Customer : Person
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
    }

    class SalaryCalculator
    {
        public static double CalculateSalary(double Experience, double Basic)
        {
            double TotalAllowance = Basic;
            if(Experience <= 2)
            {
                TotalAllowance += Basic * .3;
            }
            else if(Experience <= 4)
            {
                TotalAllowance += Basic * .4;
            }
            else if(Experience <= 6)
            {
                TotalAllowance += Basic * .5;
            }
            else
            {
                TotalAllowance += Basic * .65;
            }

            return TotalAllowance;
        }
    }
}
