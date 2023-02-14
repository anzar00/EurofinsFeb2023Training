using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            Customer customer = new Customer();
            
            Order order = new Order();
            

            RegCustomer regCustomer = new RegCustomer();

            
            OrderedItem orderedItem = new OrderedItem();

            
            Item i1 = new Item {Desc="This is item 1", Rate=500.65 };
            Item i2 = new Item { Desc="This is item 2", Rate=505.05 };
            Item i3 = new Item { Desc="This is item 3", Rate=500.30 };
            Item i4 = new Item { Desc="This is item 4", Rate=2500};
            Item i5 = new Item { Desc="This is item 5", Rate=1500};

            orderedItem.Item = i5;
            orderedItem.Qty=5;

            order.OrderedItems.Add(orderedItem);

            customer.Orders.Add(order);
            regCustomer.Orders.Add(order);
            regCustomer.splDiscount= 50;

            company.Customers.Add(customer);
            company.Customers.Add(regCustomer);

            Console.WriteLine($"Total worth of orders placed : {company.GetTotalWorthOfOrdersPlaced()}");


        }
    }

    class Company
    {

        // Company has many items
        public List<Item> Items { get; set; } = new List<Item>();

        // Company has many customers
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public double GetTotalWorthOfOrdersPlaced()
        {
            double total = 0;
            //Calculate total worth of orders placed
            //foreach(Customer customer in Customers)
            //{
            //    foreach(Order order in customer.Orders)
            //    {
            //        foreach(OrderedItem orderedItem in order.OrderedItems)
            //        {
            //            total = orderedItem.Qty * orderedItem.Item.Rate; 
                        
            //        }
            //    }
            //    if (customer is RegCustomer)
            //    {
            //        RegCustomer regCustomer = (RegCustomer)customer; //Downcasting
            //        //RegCustomer temp = customer as RegCustomer;
            //        total -= total - regCustomer.splDiscount;
            //    }
            //} --> This becomes a god class taht does everyhing on its own, we should rather divide the tasks and make objects talk only with the nearby objects
            foreach(Customer customer in Customers)
            {
                total += customer.GetTotalWorth();
                //if(customer is RegCustomer)
                //{
                //    RegCustomer regCustomer = customer as RegCustomer;
                //    total -= regCustomer.GetTotalWorth();
                //}
            }
            return total;
        }


    }

    class Item
    {
        public string Desc { get; set; }
        public double Rate { get; set; }

    }

    class Customer
    {
        public virtual double GetTotalWorth()
        {
            double total = 0;
            //for each order
            foreach(Order order in Orders)
            {
                total += order.GetTotalWorth();
            }
            return total;
        }
        //Customer has many orders
        public List<Order> Orders { get; set; } = new List<Order> ();

    }

    class RegCustomer : Customer
    {
        public double splDiscount { get; set; }

        //Overriding GetTotalWorth derived from parent class

        public override double GetTotalWorth()
        {
            
            return base.GetTotalWorth() - splDiscount;
        }
    }

    class Order 
    {

        public double GetTotalWorth()
        {
            double total = 0;
            foreach(OrderedItem orderedItem in OrderedItems)
            {
                total += orderedItem.GetTotalWorth();
            }
            return total;
        }
        //Order has a Customer
        public Customer Customer { get; set; }

        //Order has Many Ordered Items
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();
    }

    class OrderedItem
    {
        public int Qty { get; set; }

        //Ordered Items has an item

        public Item Item { get; set; }

        internal double GetTotalWorth()
        {
            return Qty * Item.Rate;
        }
    }


}
