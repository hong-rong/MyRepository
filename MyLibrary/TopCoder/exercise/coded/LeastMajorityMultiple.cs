using System;

public class LeastMajorityMultiple
{
    public int leastMajorityMultiple(int a, int b, int c, int d, int e)
    {
        int count = 0;
        for (int i = 4; i <= int.MaxValue; i++)
        {
            count = 0;
            if (i % a == 0) count++;
            if (i % b == 0) count++;
            if (i % c == 0) count++;
            if (i % d == 0) count++;
            if (i % e == 0) count++;

            if (count >= 3) return i;
        }

        return -1;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new LeastMajorityMultiple()).leastMajorityMultiple(1, 2, 3, 4, 5), 4);
            eq(1, (new LeastMajorityMultiple()).leastMajorityMultiple(30, 42, 70, 35, 90), 210);
            eq(2, (new LeastMajorityMultiple()).leastMajorityMultiple(30, 45, 23, 26, 56), 1170);
            eq(3, (new LeastMajorityMultiple()).leastMajorityMultiple(3, 14, 15, 92, 65), 195);
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
