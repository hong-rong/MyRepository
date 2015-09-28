using System;
using System.Linq;

public class PackingParts
{
    public int pack(int[] partSizes, int[] boxSizes)
    {
        int count = 0;
        int index = 0;
        for (int i = 0; i < partSizes.Length; i++)
        {
            while (index < boxSizes.Length)
            {
                if (partSizes[i] <= boxSizes[index++])
                {
                    count++;
                    break;
                }
            }

            if (index == boxSizes.Length) break;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new PackingParts()).pack(new int[] { 2, 2, 2 }, new int[] { 1, 2, 2, 3 }), 3);
            eq(1, (new PackingParts()).pack(new int[] { 1, 5 }, new int[] { 2, 5 }), 2);
            eq(2, (new PackingParts()).pack(new int[] { 10, 10, 10, 10 }, new int[] { 9, 9, 9, 10, 10, 10 }), 3);
            eq(3, (new PackingParts()).pack(new int[] { 1, 1, 1, 1 }, new int[] { 1, 2, 2, 3, 6, 7 }), 4);
            eq(4, (new PackingParts()).pack(new int[] { 1, 1, 1, 1 }, new int[] { 2, 3, 6 }), 3);
            eq(5, (new PackingParts()).pack(new int[] { 10, 32, 46, 55, 55, 84, 100 }, new int[] { 15, 31, 34, 46, 59, 68, 83, 99 }), 6);
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
