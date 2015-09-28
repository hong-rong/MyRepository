using System;
using System.Linq;

public class BootsExchange
{
    public int leastAmount(int[] left, int[] right)
    {
        int[] leftCount = new int[1000];
        int[] rightCount = new int[1000];
        for (int i = 0; i < left.Length; i++)
        {
            leftCount[left[i] - 1]++;
        }

        for (int j = 0; j < right.Length; j++)
        {
            rightCount[right[j] - 1]++;
        }

        int sum = 0;
        for (int k = 0; k < leftCount.Length; k++)
        {
            sum = sum + (int)Math.Abs(leftCount[k] - rightCount[k]);
        }

        return sum / 2;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new BootsExchange()).leastAmount(new int[] { 1, 3, 1 }, new int[] { 2, 1, 3 }), 1);
            eq(1, (new BootsExchange()).leastAmount(new int[] { 1, 3 }, new int[] { 2, 2 }), 2);
            eq(2, (new BootsExchange()).leastAmount(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 4, 6, 1, 3, 7, 5 }), 0);
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
