using System;

public class TheProgrammingContestDivTwo
{
    public int[] find(int T, int[] requiredTime)
    {
        Array.Sort(requiredTime);
        int solve = 0;
        int sum = 0;
        for (int i = 0; i < requiredTime.Length; i++)
        {
            if (sum + requiredTime[i] <= T)
            {
                solve++;
                sum = sum + requiredTime[i];
            }
        }

        int num = solve;
        int penalty = 0;
        for (int j = 0; j < solve; j++)
        {
            penalty = penalty + requiredTime[j] * num--;
        }

        return new int[] { solve, penalty };
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TheProgrammingContestDivTwo()).find(74, new int[] { 47 }), new int[] { 1, 47 });
            eq(1, (new TheProgrammingContestDivTwo()).find(74, new int[] { 4747 }), new int[] { 0, 0 });
            eq(2, (new TheProgrammingContestDivTwo()).find(47, new int[] { 8, 5 }), new int[] { 2, 18 });
            eq(3, (new TheProgrammingContestDivTwo()).find(47, new int[] { 12, 3, 21, 6, 4, 13 }), new int[] { 5, 86 });
            eq(4, (new TheProgrammingContestDivTwo()).find(58, new int[] { 4, 5, 82, 3, 4, 65, 7, 6, 8, 7, 6, 4, 8, 7, 6, 37, 8 }), new int[] { 10, 249 });
            eq(5, (new TheProgrammingContestDivTwo()).find(100000, new int[] { 100000 }), new int[] { 1, 100000 });
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
