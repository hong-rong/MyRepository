// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class CarBuyer
{
    public double lowestCost(string[] cars, int fuelPrice, int annualDistance, int years)
    {
        double minCost = int.MaxValue;
        double price = 0;
        for (int i = 0; i < cars.Length; i++)
        {
            var car = cars[i].Split(new char[] { ' ' });
            price = int.Parse(car[0]) + (int.Parse(car[1]) + fuelPrice * annualDistance / double.Parse(car[2])) * years;

            if (price < minCost)
                minCost = price;
        }

        return minCost;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            //eq(0, (new CarBuyer()).lowestCost(new string[] { "10000 50 50", "12000 500 10", "15000 100 65", "20000 20 80", "25000 10 90" }, 2, 5000, 2), 10500.0);
            //eq(1, (new CarBuyer()).lowestCost(new string[] { "10000 50 50", "12000 500 10", "15000 100 65", "20000 20 80", "25000 10 90" }, 8, 25000, 10), 45200.0);
            eq(2, (new CarBuyer()).lowestCost(new string[] {
                "8426 774 19","29709 325 31","30783 853 68","20796 781 3"
               ,"27726 4 81","20788 369 69","17554 359 34","12039 502 24"
               ,"6264 230 69","14151 420 65","25115 528 70","22234 719 55"
               ,"2050 926 40","18618 714 29","173 358 57"}, 33, 8673, 64), 254122.44444444444);
        }
        catch (Exception exx)
        {
            System.Console.WriteLine(exx);
            System.Console.WriteLine(exx.StackTrace);
        }

        Console.ReadKey();
    }
    private static void eq(int n, object have, object need)
    {
        if (eq(have, need))
        {
            Console.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Console.Write("Case " + n + " failed: expected ");
            print(need);
            Console.Write(", received ");
            print(have);
            Console.WriteLine();
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (have == null || have.Length != need.Length)
        {
            Console.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Console.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Console.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Console.Write("\"{0}\"", a);
        }
        else if (a is long)
        {
            Console.Write("{0}L", a);
        }
        else
        {
            Console.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('}');
    }
    // END CUT HERE
}
