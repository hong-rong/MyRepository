// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class TeamSplit
{
    public int difference(int[] strengths)
    {
        Array.Sort(strengths, (a, b) => -1 * a.CompareTo(b));

        int teamOne = 0;
        int teamTwo = 0;
        for (int i = 0; i < strengths.Length; i++)
        {
            if (i % 2 == 0)
                teamOne = teamOne + strengths[i];
            else
                teamTwo = teamTwo + strengths[i];
        }

        return Math.Abs(teamOne - teamTwo);
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TeamSplit()).difference(new int[] { 5, 7, 8, 4, 2 }), 4);
            eq(1, (new TeamSplit()).difference(new int[] { 100 }), 100);
            eq(2, (new TeamSplit()).difference(new int[] { 1000, 1000 }), 0);
            eq(3, (new TeamSplit()).difference(new int[] { 9, 8, 7, 6 }), 2);
            eq(4, (new TeamSplit()).difference(new int[] { 1, 5, 10, 1, 5, 10 }), 0);
            eq(5, (new TeamSplit()).difference(new int[] {824, 581,   9, 776, 149, 493, 531, 558, 995, 637,
                394, 526, 986, 548, 344, 509, 319,  37, 790, 491,
                479,  34, 776, 321, 258, 851, 711, 365, 763, 355,
                386, 877, 596,  96, 151, 166, 558, 109, 874, 959,
                845, 181, 976, 335, 930,  22,  78, 120, 907, 584}), 478);
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
