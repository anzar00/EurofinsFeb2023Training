using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Hospital hospital = new Hospital();
            Console.WriteLine("Created Hospital");
            int n = random.Next(15, 20);
            Console.WriteLine($"Creating {n} Wards");
            WardType[] types = { WardType.IntensiveCare, WardType.GeneralUnit, WardType.PediatricUnit, WardType.SurgicalUnit };
            for (int i = 0; i < n; i++)
            {
                Ward ward = new Ward()
                {
                    WardName = $"Ward{i}",
                    WardType = types[random.Next(types.Length)],
                    BasicCost = random.NextDouble()*5000+5000
                };
                int n2 = random.Next(20, 25);
                Console.WriteLine($"Creating {n2} Patients");
                for (int j = 0; j<n2; j++)
                {
                    ward.Patients.Add(new Patient());
                }
                hospital.Wards.Add(ward);
            }
            n = random.Next(135, 150);
            Console.WriteLine($"Creating {n} Doctors");
            for (int i = 0; i < n; i++)
            {
                double roulete = random.NextDouble();
                Employee emp = new Employee();
                if (roulete < 0.1) emp = new ConsultantDoctor();
                else if (roulete < 0.2) emp = new InternalDoctor();
                else if (roulete < 0.8) emp = new Doctor() { Speciality = $"S{random.Next(5, 9)}" };
                else if (roulete < 0.9) emp = new Receptionist();
                else emp = new Nurse();
                hospital.Employees.Add(emp);
            }
            Console.WriteLine(hospital.GetTotalPatients());
            Console.WriteLine(hospital.GetTotalDoctors());
        }
    }

    class Person
        {
            public string Name { get; set; }
            public string Title { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string ResidentialAddress { get; set; }
            public char Gender { get; set; }
            public string Phone { get; set; }
        }

    class Patient : Person
        {
            public DateTime AdmittedDate { get; set; }
            public string[] Allergies { get; set; }
            public string PatientName { get; set; }
            public int Age { get; set; }

        }

    class Employee : Person
        {
            public DateTime DateOfJoin { get; set; }
            public string Education { get; set; }
        }

    class Doctor : Employee
        {
            public string Speciality { get; set; }
        }

    class ConsultantDoctor : Doctor
        {
            
        }

    class InternalDoctor : Doctor
        {

        }

    class Receptionist : Employee
        {

        }

    class Nurse : Employee
        {
            

        }

    class Ward
    {
        public string WardName { get; set; }
        public WardType WardType { get; set; }
        public double BasicCost { get; set; }

        // Ward has many Patients
        public List<Patient> Patients { get; set; } = new List<Patient>();

        public double GetWardCost()
        {
            return WardCostCalculator.FindWardCost(BasicCost, WardType);
        }

    }
     
    class WardCostCalculator
    {
        public static double FindWardCost(double BasicCost, WardType WardType)
        {
            double WardCost = 0;
            switch (WardType)
            {
                case WardType.IntensiveCare:
                    WardCost = BasicCost * 1.2; // 20%
                    break;
                case WardType.GeneralUnit:
                    WardCost = BasicCost * 1.1; //10%
                    break;
                case WardType.PediatricUnit:
                    WardCost = BasicCost * 1.25; // 25%
                    break;
                case WardType.SurgicalUnit:
                    WardCost = BasicCost * 1.4; // 40%
                    break;
                default:
                    break;
            }
            return WardCost;
        }

    }


    public enum WardType
    {
        IntensiveCare,
        GeneralUnit,
        PediatricUnit,
        SurgicalUnit
    }

    class Hospital
    {
        public string Name;
        public long Phone;
        public string Address;

        //Hospital has many Employees

        public List<Employee> Employees { get; set; } = new List<Employee>();

        //Hospital has many Wards
        public List<Ward> Wards { get; set; } = new List<Ward>();

        //Get Total Patients count.

        public int GetTotalPatients()
        {
            int count = 0;
            foreach (var ward in Wards)
            {
                count += ward.Patients.Count;
            }
            return count;
        }

        //Get Total Patients by Ward.

        public int GetTotalPatientsByWard(WardType wardType)
        {
            int count = 0;
            foreach (var ward in Wards)
            {
                if (ward.WardType == wardType)
                {
                    count += ward.Patients.Count;
                }
            }
            return count;
        }

        //Get Total Doctors count. 

        public int GetTotalDoctors()
        {
            int count = 0;
            foreach (var employee in Employees)
            {
                if (employee is Doctor)
                    count++;
            }
            return count;
        }

        //Get Doctors by specialization.

        public int GetDoctorsBySpecialization(string Speciality)
        {
            int count = 0;
            foreach(var employee in Employees)
            {
                if (employee is Doctor)
                    if((employee as Doctor).Speciality == Speciality)
                        count++;
            }
            return count;
        }

        //Get Total Junior Doctors count.
        
        public int GetTotalInternalDoctors()
        {
            int count = 0;
            foreach (var employee in Employees)
            {
                if (employee is InternalDoctor)
                    count++;
            }
            return count;
        }

        //Get Ward Cost by Type.
        public double GetWardCostByType(WardType wardType)
        {
            double cost = 0;
            foreach (var ward in Wards)
            {
                if (ward.WardType == wardType)
                    cost += ward.GetWardCost();
            }
            return cost;
        }
    }
}

