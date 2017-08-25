using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Customer() { Id = 10, Name = "bbb", LastName = "zzz" };
            var c1 = new Customer() { Id = 10, Name = "ccc", LastName = "yyy" };
            Console.WriteLine(Customer.CompareBy(e => e.LastName, c, c1));
            var c2 = new AnotherCustomer() { Id = 10, Name = "bbb", LastName = "fff" };
            var c3 = new AnotherCustomer() { Id = 10, Name = "ccc", LastName = "yyy" };
            Console.WriteLine(AnotherCustomer.CompareBy(e => e.Id, c2, c3));
            Console.WriteLine(c2 > c3);
        }
    }
}
