using System;
using System.Collections.Generic;
using System.Linq;

public class InterestingParty
{
    public int bestInvitation(string[] first, string[] second)
    {
        Dictionary<string, int> count = new Dictionary<string, int>();
        for (int i = 0; i < first.Length; i++)
        {
            if (!count.ContainsKey(first[i]))
                count.Add(first[i], 1);
            else
                count[first[i]]++;

            if (!count.ContainsKey(second[i]))
                count.Add(second[i], 1);
            else
                count[second[i]]++;
        }

        return count.Values.Max();
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new InterestingParty()).bestInvitation(new string[] { "fishing", "gardening", "swimming", "fishing" }, new string[] { "hunting", "fishing", "fishing", "biting" }), 4);
            eq(1, (new InterestingParty()).bestInvitation(new string[] { "variety", "diversity", "loquacity", "courtesy" }, new string[] { "talking", "speaking", "discussion", "meeting" }), 1);
            eq(2, (new InterestingParty()).bestInvitation(new string[] { "snakes", "programming", "cobra", "monty" }, new string[] { "python", "python", "anaconda", "python" }), 3);
            eq(3, (new InterestingParty()).bestInvitation(new string[] {"t", "o", "p", "c", "o", "d", "e", "r", "s", "i", "n", "g", "l", "e", "r",
                "o", "u", "n", "d", "m", "a", "t", "c", "h", "f", "o", "u", "r", "n", "i"}, new string[] {"n", "e", "f", "o", "u", "r", "j", "a", "n", "u", "a", "r", "y", "t", "w", 
                "e", "n", "t", "y", "t", "w", "o", "s", "a", "t", "u", "r", "d", "a", "y"}), 6);
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
