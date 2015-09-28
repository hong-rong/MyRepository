using System;

public class RaiseThisBarn
{
    public int calc(string str)
    {
        //int countC = 0;
        //for (int i = 0; i < str.Length; i++)
        //    if (str[i] == 'c') countC++;

        //if (countC % 2 != 0) return 0;
        //if (countC == 0) return str.Length - 1;

        //int countHalf = 0;
        //int countWay = 0;
        //for (int j = 0; j < str.Length; j++)
        //{
        //    if (str[j] == 'c')
        //        countHalf++;

        //    if (countHalf == countC / 2) countWay++;
        //    else if (countHalf > countC / 2) break;
        //}

        //return countWay;

        int count = 0;
        for (int i = 1; i < str.Length; i++)
        {
            int left = 0;
            int right = 0;

            for (int j = 0; j < i; j++)
                if (str[j] == 'c') left++;
            
            for (int k = i; k < str.Length; k++)
                if (str[k] == 'c') right++;

            if (left == right) count++;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new RaiseThisBarn()).calc("cc..c.c"), 3);
            eq(1, (new RaiseThisBarn()).calc("c....c....c"), 0);
            eq(2, (new RaiseThisBarn()).calc("............"), 11);
            eq(3, (new RaiseThisBarn()).calc(".c.c...c..ccc.c..c.c.cc..ccc"), 3);
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
