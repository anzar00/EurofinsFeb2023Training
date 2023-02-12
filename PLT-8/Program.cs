using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PLT_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A vendor offers software services to a client. Each resource is billed at some dollar rate
            //per hour.The total cost of the project for the client is therefore, the total number of
            //hours contributed by all the vendor resources * the dollar rate / hour.There are however
            //some variants.
            //The vendor might have purchased hardware/infrastructure or software licenses
            //needed for the project. 
            //The vendor might have utilized external consultants for the project. 
            //The client looks at the vendor as a one-stop solution and hence external resources
            //employed by the vendor need to be paid by the vendor.
            //It might however be possible that the vendor’s hardware and software
            //purchases are borne by the client.In this case, the client pays the vendor
            //30% of the hardware/infrastructure costs.In case of software licenses, the
            //client pays the vendor 50% of the cost, if they are commonly available and
            //used, or 100% if the software is infrequently used or is proprietary client
            //technology.
            //The external consultants employed by the vendor will come at a dollar rate per
            //hour.
            //Accept the suitable inputs and display the profits / loss realized by the vendor.

            double totalHours, ratePerHour = 0.0;
            
            char hasExtCon = ' ';
            double extConRate = 0.0;
            double extConHours = 0.0;

            char hasHardware = ' ';
            double hardwareCost = 0.0;

            char hasSoftwareLic = ' ';
            double softwareLicCost = 0.0;

            char isCommonlyUsed = ' ';

            double projectCost = 0.0;
            double softwareCost = 0.0;

            double profit = 0.0;

            Console.WriteLine("Enter total hours: ");
            totalHours = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter rate per hour: ");
            ratePerHour = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Does the vendor have external consultants? (Y/N)");
            hasExtCon = Convert.ToChar(Console.ReadLine());

            if (hasExtCon == 'Y' || hasExtCon == 'y')
            {
                Console.WriteLine("Enter external consultant rate per hour: ");
                extConRate = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter external consultant hours: ");
                extConHours = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Does the project requie hardware? (Y/N)");
            hasHardware = Convert.ToChar(Console.ReadLine());

            if (hasHardware == 'Y' || hasHardware == 'y')
            {
                Console.WriteLine("Enter hardware cost: ");
                hardwareCost = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Does the project require software licenses? (Y/N)");
            hasSoftwareLic = Convert.ToChar(Console.ReadLine());

            if (hasSoftwareLic == 'Y' || hasSoftwareLic == 'y')
            {
                Console.WriteLine("Enter software license cost: ");
                softwareLicCost = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Is the software commonly used? (Y/N)");
                isCommonlyUsed = Convert.ToChar(Console.ReadLine());
            }

            projectCost = (totalHours * ratePerHour) + (hardwareCost * .3);

            if (isCommonlyUsed == 'Y' || isCommonlyUsed == 'y')
            {
                softwareCost = softwareLicCost * .5;
            }
            else
            {
                softwareCost = softwareLicCost;
            }

            projectCost += softwareCost;

            Console.WriteLine("Project cost: {0}", projectCost);

            profit = projectCost - (extConHours * extConRate) + (hardwareCost) + (softwareLicCost);

            Console.WriteLine("Profit: {0}", profit);

            if (profit > 0)
            {
                Console.WriteLine("Vendor made a profit of {0}", profit);
            }
            else if (profit < 0)
            {
                Console.WriteLine("Vendor made a loss of {0}", profit);
            }
            else
            {
                Console.WriteLine("Vendor broke even.");
            }












        }
    }
}
