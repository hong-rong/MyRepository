using System;

public class MinCostPalindrome
{
    public int getMinimum(string s, int oCost, int xCost)
    {
        int count = 0;
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] == s[s.Length - 1 - i] && s[i] == '?')
                count = count + (oCost > xCost ? xCost : oCost) * 2;
            else if (s[i] == 'o' && s[s.Length - 1 - i] == '?')
                count = count + oCost;
            else if (s[i] == 'x' && s[s.Length - 1 - i] == '?')
                count = count + xCost;
            else if (s[i] == '?' && s[s.Length - 1 - i] == 'o')
                count = count + oCost;
            else if (s[i] == '?' && s[s.Length - 1 - i] == 'x')
                count = count + xCost;
            else if (s[i] != s[s.Length - 1 - i])
                return -1;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new MinCostPalindrome()).getMinimum("oxo?xox?", 3, 5), 8);
            eq(1, (new MinCostPalindrome()).getMinimum("x??x", 9, 4), 8);
            eq(2, (new MinCostPalindrome()).getMinimum("ooooxxxx", 12, 34), -1);
            eq(3, (new MinCostPalindrome()).getMinimum("oxoxooxxxxooxoxo", 7, 4), 0);
            eq(4, (new MinCostPalindrome()).getMinimum("?o", 6, 2), 6);
            eq(5, (new MinCostPalindrome()).getMinimum("????????????????????", 50, 49), 980);
            eq(6, (new MinCostPalindrome()).getMinimum("o??oxxo?xoox?ox??x??", 3, 10), 38);
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
