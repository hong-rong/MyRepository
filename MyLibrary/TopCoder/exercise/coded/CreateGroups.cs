using System;
using System.Linq;

public class CreateGroups
{
    public int minChanges(int[] groups, int minSize, int maxSize)
    {
        if (groups.Sum() < minSize * groups.Length || groups.Sum() > maxSize * groups.Length) return -1;

        int mustAdd = 0;
        int mustRemove = 0;
        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i] < minSize) mustAdd = mustAdd + minSize - groups[i];
            if (groups[i] > maxSize) mustRemove = mustRemove + groups[i] - maxSize;
        }

        return mustAdd > mustRemove ? mustAdd : mustRemove;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new CreateGroups()).minChanges(new int[] { 10, 20 }, 10, 15), 5);
            eq(1, (new CreateGroups()).minChanges(new int[] { 20, 8, 6 }, 10, 15), 6);
            eq(2, (new CreateGroups()).minChanges(new int[] { 10, 20, 30 }, 1, 18), -1);
            eq(3, (new CreateGroups()).minChanges(new int[] { 50, 10, 20, 20, 5 }, 15, 30), 20);
            eq(4, (new CreateGroups()).minChanges(new int[] { 100, 200, 301 }, 200, 200), -1);
            eq(5, (new CreateGroups()).minChanges(new int[] { 1, 10, 10 }, 9, 20), -1);
            eq(6, (new CreateGroups()).minChanges(new int[] { 55, 33, 45, 71, 27, 89, 16, 14, 61 }, 33, 56), 53);
            eq(7, (new CreateGroups()).minChanges(new int[] { 49, 60, 36, 34, 36, 52, 60, 43, 52, 59 }, 45, 51), 31);
            eq(8, (new CreateGroups()).minChanges(new int[] { 5, 5, 5, 5, 5 }, 5, 5), 0);
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
