using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PLT_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a pseudocode to do the following: 
            //Accept the item code, description, qty and price of an item.Compute the total for
            //the item. 

            //Accept the user’s choice.If the choice is ‘y’ then accept the next set of inputs for
            //a new item and compute the total.In this manner, compute the grand total for all
            //the items purchased by the customer.


            //If the grand total is more than Rs. 10, 000/-then, the customer is allowed a
            //discount of 10%.

            //If the grand total is less than Rs. 1,000/-and the customer chooses to pay by card, 
            //then a surcharge of 2.5% is levied on the grand total.

            //Display the grand total for the customer.

            Console.WriteLine("Enter the item code: ");
            int itemCode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the item description: ");
            string itemDescription = Console.ReadLine();

            Console.WriteLine("Enter the quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the price: ");
            double price = Convert.ToInt32(Console.ReadLine());
            
            double total = quantity * price;

            Console.WriteLine("The total for the item is: " + total);

            Console.WriteLine("Do you want to continue? (y/n)");

            string choice = Console.ReadLine();

            double grandTotal = 0;

            while (choice == "y")
            {
                Console.WriteLine("Enter the item code: ");
                itemCode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the item description: ");
                itemDescription = Console.ReadLine();

                Console.WriteLine("Enter the quantity: ");
                quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the price: ");
                price = Convert.ToInt32(Console.ReadLine());

                total = quantity * price;

                Console.WriteLine("The total for the item is: " + total);

                grandTotal += total;

                Console.WriteLine("Do you want to continue? (y/n)");

                choice = Console.ReadLine();
            }

            if (grandTotal > 10000)
            {
                grandTotal = grandTotal - (grandTotal * 10 / 100);
            }
            else if (grandTotal < 1000)
            {
                Console.WriteLine("Do you want to pay by card? (y/n)");
                string cardChoice = Console.ReadLine();

                if (cardChoice == "y")
                {
                    grandTotal = grandTotal + (grandTotal * 2.5 / 100);
                }
            }

            Console.WriteLine("The grand total is: " + grandTotal);

            Console.ReadKey();
        }
    }
}
