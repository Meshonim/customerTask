using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class AnotherCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public static int CompareBy<T>(Func<AnotherCustomer, T> comparison, AnotherCustomer x, AnotherCustomer y)
        {
            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));
            IComparable a = comparison(x) as IComparable;
            if (a == null)
                throw new ArgumentException(nameof(comparison));
            return a.CompareTo(comparison(y));
        }

        public static bool operator ==(AnotherCustomer x, AnotherCustomer y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(AnotherCustomer x, AnotherCustomer y)
        {
            return !(x == y);
        }

        public static bool GreaterThan(AnotherCustomer x, AnotherCustomer y)
        {
            return string.Compare(x.Name, y.Name) > 0;
        }

        public static bool LessThan(AnotherCustomer x, AnotherCustomer y)
        {
            return string.Compare(x.Name, y.Name) < 0;
        }

        public static bool operator >(AnotherCustomer x, AnotherCustomer y)
        {
            return GreaterThan(x, y);
        }

        public static bool operator <(AnotherCustomer x, AnotherCustomer y)
        {
            return LessThan(x, y);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AnotherCustomer))
                return false;
            AnotherCustomer item  = (AnotherCustomer)obj;
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
