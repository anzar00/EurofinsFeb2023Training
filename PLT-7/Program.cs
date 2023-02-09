using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLT_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a pseudocode to accept name, empId, basic, special allowances, percentage of
            //bonus and monthly tax saving investments. The gross monthly salary is basic + special
            //allowances.
            //
            //Compute the annual salary.
            //The gross annual salary also includes the bonus. 
            //
            //Compute the annual net salary, by deducting taxes as suggested.
                //Income upto 1 lac – exempted
                //Income from 1 to 1.5 lac – 20%
                //Income from 1.5 lac onwards – 30%
            //
            //However if there is any tax saving investment, then there is further exemption of upto 1
            //lac annually. This would mean that by having tax saving investments of about 1 lac, an
            //income of 2 lacs is non-taxable.Display the annual gross, annual net and tax payable.

            Console.WriteLine("Enter the name :");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the employee id :");
            int empId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the basic salary :");
            int basic = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the special allowances :");
            int specialAllowances = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the percentage of bonus :");
            int bonusPercentage = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the monthly tax saving investments :");
            int monthlyTaxSavingInvestments = Convert.ToInt32(Console.ReadLine());

            int grossMonthlySalary = basic + specialAllowances;

            int annualSalary = grossMonthlySalary * 12;

            int bonus = (annualSalary * bonusPercentage) / 100;

            int grossAnnualSalary = annualSalary + bonus;

            int taxPayable = 0;

            if (grossAnnualSalary <= 100000)
                taxPayable = 0;
            else if (grossAnnualSalary > 100000 && grossAnnualSalary <= 150000)
                taxPayable = (grossAnnualSalary * 20) / 100;
            else if (grossAnnualSalary > 150000)
                taxPayable = (grossAnnualSalary * 30) / 100;

            int taxSavingInvestments = monthlyTaxSavingInvestments * 12;

            if (taxSavingInvestments > 100000)
                taxSavingInvestments = 100000;

            int annualNetSalary = grossAnnualSalary - taxPayable + taxSavingInvestments;

            Console.WriteLine($"Annual gross salary is - {grossAnnualSalary}");
            Console.WriteLine($"Annual net salary is - {annualNetSalary}");
            Console.WriteLine($"Tax payable is - {taxPayable}");

            Console.ReadLine();
        }
    }
}
