using System;

public class CountryGroup
{
    public int solve(int[] a)
    {
        int[] count = new int[100];
        for (int i = 0; i < a.Length; i++)
        {
            count[a[i] - 1]++;
        }

        int diffCountries = 0;
        for (int j = 0; j < count.Length; j++)
        {
            if (j == 0)
                diffCountries = diffCountries + count[j]; //there is no way to verify 1, so count them on
            else if (count[j] != 0)
            {
                if (count[j] != j + 1)
                    return -1;
                else
                    diffCountries++;
            }
        }

        return diffCountries;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new CountryGroup()).solve(new int[] { 2, 2, 3, 3, 3 }), 2);
            eq(1, (new CountryGroup()).solve(new int[] { 1, 1, 1, 1, 1 }), 5);
            eq(2, (new CountryGroup()).solve(new int[] { 3, 3 }), -1);
            eq(3, (new CountryGroup()).solve(new int[] { 4, 4, 4, 4, 1, 1, 2, 2, 3, 3, 3 }), 5);
            eq(4, (new CountryGroup()).solve(new int[] { 2, 1, 2, 2, 1, 2 }), -1);
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
