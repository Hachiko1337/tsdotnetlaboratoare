using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
            TestPerson();

            Console.ReadKey();
        }

        static void TestPerson()
        {
            using (Model1Container context = new Model1Container())
            {
                Person p = new Person(
                    "Julie",
                    "Andrew",
                    "T",
                    "1234567890"
                );
                ;
                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }

        public static int Id { get; set; }
    }

    internal class Person
    {
        public Person(string firstName, string lastName, string middleName, string TelephonNumber)
        {
            throw new NotImplementedException();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string TelephonNumber { get; set; }
    }

    internal class Customer
    {
        public Customer(int CustomerId, string Name, String City)
        {
            throw new NotImplementedException();
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
