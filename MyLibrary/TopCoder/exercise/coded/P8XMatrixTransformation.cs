using System;

public class P8XMatrixTransformation
{
    public string solve(string[] original, string[] target)
    {
        int countOriginal = 0;
        int countTarget = 0;
        for (int i = 0; i < original.Length; i++)
        {
            for (int j = 0; j < original[i].Length; j++)
            {
                if (original[i][j] == '1') countOriginal++;
                if (target[i][j] == '1') countTarget++;
            }
        }

        if (countOriginal == countTarget) return "YES";

        return "NO";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new P8XMatrixTransformation()).solve(new string[] {"01"
               ,"11"}, new string[] {"11"
               ,"10"}), "YES");
            eq(1, (new P8XMatrixTransformation()).solve(new string[] {"0111"
               ,"0011"}, new string[] {"1011"
               ,"1100"}), "YES");
            eq(2, (new P8XMatrixTransformation()).solve(new string[] { "0" }, new string[] { "1" }), "NO");
            eq(3, (new P8XMatrixTransformation()).solve(new string[] {"1111"
               ,"1111"
               ,"0000"
               ,"0000"}, new string[] {"1111"
               ,"1111"
               ,"0000"
               ,"0000"}), "YES");
            eq(4, (new P8XMatrixTransformation()).solve(new string[] {"0110"
               ,"1001"
               ,"0110"}, new string[] {"1111"
               ,"0110"
               ,"0000"}), "YES");
            eq(5, (new P8XMatrixTransformation()).solve(new string[] {"0000"
               ,"1111"
               ,"0000"}, new string[] {"1111"
               ,"0000"
               ,"1111"}), "NO");
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
