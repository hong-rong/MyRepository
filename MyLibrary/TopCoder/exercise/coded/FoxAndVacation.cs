using System;

public class FoxAndVacation
{
    public int maxCities(int total, int[] d)
    {
        Array.Sort(d);
        int count = 0;
        int sum = 0;
        for (int i = 0; i < d.Length; i++)
        {
            if (sum + d[i] <= total)
            {
                sum = sum + d[i];
                count++;
            }
            else
                break;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new FoxAndVacation()).maxCities(5, new int[] { 2, 2, 2 }), 2);
            eq(1, (new FoxAndVacation()).maxCities(5, new int[] { 5, 6, 1 }), 1);
            eq(2, (new FoxAndVacation()).maxCities(5, new int[] { 6, 6, 6 }), 0);
            eq(3, (new FoxAndVacation()).maxCities(6, new int[] { 1, 1, 1, 1, 1 }), 5);
            eq(4, (new FoxAndVacation()).maxCities(10, new int[] { 7, 1, 5, 6, 1, 3, 4 }), 4);
            eq(5, (new FoxAndVacation()).maxCities(50, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }), 9);
            eq(6, (new FoxAndVacation()).maxCities(21, new int[] { 14, 2, 16, 9, 9, 5, 5, 23, 25, 20, 8, 25, 6, 12, 3, 2, 4, 5, 10, 14, 19, 12, 25, 15, 14 }), 6);
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
