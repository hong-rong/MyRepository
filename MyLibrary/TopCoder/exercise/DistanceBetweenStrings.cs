using System;

public class DistanceBetweenStrings
{
    public int getDistance(string a, string b, string letterSet)
    {
        a = a.ToLower();
        b = b.ToLower();

        int distance = 0;
        for (int i = 0; i < letterSet.Length; i++)
        {
            distance = distance + (int)Math.Pow(GetFrequency(a, letterSet[i]) - GetFrequency(b, letterSet[i]), 2);
        }

        return distance;
    }

    private int GetFrequency(string text, char c)
    {
        int count = 0;
        for (int i = 0; i < text.Length; i++)
            if (text[i] == c) count++;

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new DistanceBetweenStrings()).getDistance("topcoder", "contest", "tcp"), 2);
            eq(1, (new DistanceBetweenStrings()).getDistance("abcdef", "fedcba", "fed"), 0);
            eq(2, (new DistanceBetweenStrings()).getDistance("aaaaa", "bbbbb", "a"), 25);
            eq(3, (new DistanceBetweenStrings()).getDistance("aaAaB", "BbaAa", "ab"), 2);
            eq(4, (new DistanceBetweenStrings()).getDistance("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", "ba"), 5000);
            eq(5, (new DistanceBetweenStrings()).getDistance("ToPcOdEr", "tOpCoDeR", "wxyz"), 0);
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
