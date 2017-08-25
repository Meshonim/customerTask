using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public static int CompareBy<T>(Func<Customer, T> comparison, Customer x, Customer y)
        {
            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            IComparable a = comparison(x) as IComparable;
            if (a == null)
                throw new ArgumentException(nameof(comparison));
            return a.CompareTo(comparison(y));
        }

        public static bool operator ==(Customer x, Customer y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Customer x, Customer y)
        {
            return !(x == y);
        }

        public static bool GreaterThan(Customer x, Customer y)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            return string.Compare(x.Name, y.Name) > 0;
        }

        public static bool LessThan(Customer x, Customer y)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            return string.Compare(x.Name, y.Name) < 0;
        }

        public static bool operator >(Customer x, Customer y)
        {
            return GreaterThan(x, y);
        }

        public static bool operator <(Customer x, Customer y)
        {
            return LessThan(x, y);
        }

        public override bool Equals(object obj)
        {
            var item = obj as Customer;

            if (item == null)
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override string ToString()
        {
            return string.Format($"{Id}: {Name} {LastName}");
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
