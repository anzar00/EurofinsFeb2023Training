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

    class Receptionsit : Employee
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
       
        



       //Get Total Patients by Ward.

       //Get Total Doctors count. 

       //Get Doctors by specialization.

       //Get Total Junior Doctors count.

       //Get Ward Cost by Type.


    }
}

