using System;

namespace CSharpProfessional
{
    internal struct Vector
    {
        public double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(Vector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }

        public static Vector operator +(Vector lhs, Vector rhs)
        {
            return new Vector(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vector operator *(double lhs, Vector rhs)
        {
            return new Vector(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        public static Vector operator *(Vector lhs, double rhs)
        {
            return rhs * lhs;
        }

        public static double operator *(Vector lhs, Vector rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }

        public override string ToString()
        {
            return "( " + x + ", " + y + ", " + z + " )";
        }
    }

    internal struct Currency
    {
        public uint Dollars;
        public ushort Cents;

        public Currency(uint dollars, ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }

        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }

        public static explicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                //ushort cents = (ushort)((value - dollars) * 100);
                ushort cents = System.Convert.ToUInt16(((value - dollars) * 100));

                return new Currency(dollars, cents);
            }
        }

        public override string ToString()
        {
            return string.Format("${0}.{1,-2:00}", Dollars, Cents);
        }
    }

    internal class BaseA
    {

    }

    internal class DerivedA : BaseA
    {
        //public static explicit operator Derived(Base value)
        //{
        //    throw new NotImplementedException();
        //}
    }

    internal class BaseB
    {
        public static implicit operator BaseB(BaseA value)
        {
            throw new NotImplementedException();
        }

        public static explicit operator BaseA(BaseB value)
        {
            throw new NotImplementedException();
        }
    }

    public class Ch7 : ITest
    {
        public void Test()
        {
            BaseA a = new BaseA();
            DerivedA da = new DerivedA();

            da = (DerivedA)a;
        }

        private static void CastBetweenClassesTest()
        {
            BaseA a = new BaseA();
            BaseB b = new BaseB();
            a = (BaseA)b;
            b = a;
        }

        private static void UserDefinedCastTest()
        {
            try
            {
                Currency balance = new Currency(50, 35);
                Console.WriteLine(balance);
                Console.WriteLine("balance is " + balance);
                Console.WriteLine("balance is (using ToString()) " + balance.ToString());

                float balance2 = balance;
                Console.WriteLine("After converting to float, = " + balance2);

                balance = (Currency)balance2;
                Console.WriteLine("After converting back to Currency, = " + balance);
                Console.WriteLine("Now attempt to convert out of range value of " + "-$50.50 to a Currency:");

                checked
                {
                    balance = (Currency)(-50.50);
                    Console.WriteLine("Result is " + balance.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
            }
        }

        private static void CastTest()
        {
            Currency c = new Currency(11, 30);
            Console.WriteLine(c);

            float f = c;
            Console.WriteLine(f);

            f = 11.30f;
            c = (Currency)f;
            Console.WriteLine(c);
        }

        private static void OperatorTest()
        {
            Vector v = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);

            Console.WriteLine(v + v2);
            Console.WriteLine(2 * v);
            Console.WriteLine(v * 2);
            Console.WriteLine(v2 * v);
        }

        private static void TestReferenceEquals()
        {
            Ch7 x, y;
            x = new Ch7();
            y = new Ch7();

            bool B1 = ReferenceEquals(null, null); // returns true
            bool B2 = ReferenceEquals(null, x); // returns false
            bool B3 = ReferenceEquals(x, y); // returns false because x and y point to different objects
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        private static void CheckTest()
        {
            long val = 3000000000;
            int i = checked((int)val);
        }

        private static void CoalescingTest()
        {
            int? a = null;
            int b;

            b = a ?? 10;
            Console.WriteLine(b);
            a = 3;
            b = a ?? 10;
            Console.WriteLine(b);
        }
    }
}
