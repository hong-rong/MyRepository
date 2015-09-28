using System;

public class EasyHomework
{
    public string determineSign(int[] A)
    {
        int neg = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] < 0) neg++;
            else if (A[i] == 0) return "ZERO";
        }

        return neg % 2 == 0 ? "POSITIVE" : "NEGATIVE";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new EasyHomework()).determineSign(new int[] { 5, 7, 2 }), "POSITIVE");
            eq(1, (new EasyHomework()).determineSign(new int[] { -5, 7, 2 }), "NEGATIVE");
            eq(2, (new EasyHomework()).determineSign(new int[] { 5, 7, 2, 0 }), "ZERO");
            eq(3, (new EasyHomework()).determineSign(new int[] { 3, -14, 159, -26 }), "POSITIVE");
            eq(4, (new EasyHomework()).determineSign(new int[] { -1000000000 }), "NEGATIVE");
            eq(5, (new EasyHomework()).determineSign(new int[] { 123, -456, 789, -101112, 131415, 161718, 192021, 222324, 252627, 282930, 313233, 343536, 373839, 404142, 434445, 464748, 495051, 525354, 555657 }), "POSITIVE");
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
