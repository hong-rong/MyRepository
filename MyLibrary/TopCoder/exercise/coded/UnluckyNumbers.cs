using System;
using System.Linq;

public class UnluckyNumbers
{
    public int getCount(int[] luckySet, int n)
    {
        Array.Resize(ref luckySet, luckySet.Length + 1);
        luckySet[luckySet.Length - 1] = 0;
        Array.Sort(luckySet);

        int i = 0;
        for (; i < luckySet.Length - 1; i++)
            if (n >= luckySet[i] && n <= luckySet[i + 1])
                break;

        if (n == luckySet[i] || n == luckySet[i + 1])
            return 0;

        return (n - luckySet[i]) //numbers before n, inculding n
                * (luckySet[i + 1] - n)  //numbers after n, including n
                - 1; //exclude [n,n] interval
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new UnluckyNumbers()).getCount(new int[] { 1, 7, 14, 10 }, 2), 4);
            eq(1, (new UnluckyNumbers()).getCount(new int[] { 4, 8, 13, 24, 30 }, 10), 5);
            eq(2, (new UnluckyNumbers()).getCount(new int[] { 10, 20, 30, 40, 50 }, 30), 0);
            eq(3, (new UnluckyNumbers()).getCount(new int[] { 3, 7, 12, 18, 25, 100, 33, 1000 }, 59), 1065);
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
