using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    public partial class Model1Container 
    {
        static void TesTOneToMany()
        {
            Console.WriteLine("One to many association");
            using (ModelOneToManyContainer context =
                new ModelOneToManyContainer())
            {
                Customer c = new Customer()
                {
                    Name = "Customer 1",
                    City = "Iasi"
                };
                Order o1 = new Order()
                {
                    TotalValue = 200,
                    Date = DateTime.Now,
                    Customer = c
                };
                Order o2 = new Order()
                {
                    TotalValue = 300,
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();
                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                        x.CustomerId, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                            ox.OrderId, ox.Date, ox.TotalValue);
                }
            }
        }
    }

}
