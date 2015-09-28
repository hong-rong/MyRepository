// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class RoadOrFlightEasy
{
    public int minTime(int N, int[] roadTime, int[] flightTime, int K)
    {
        int[] dat = new int[N];
        int total = 0;
        for (int i = 0; i < N; i++)
        {
            dat[i] = roadTime[i] - flightTime[i];
            total = total + roadTime[i];
        }
        
        Array.Sort(dat, (a, b) => -1 * a.CompareTo(b));


        for (int i = 0; i < K; i++)
        {
            if (dat[i] <= 0)
                break;

            total = total - dat[i];
        }

        return total;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new RoadOrFlightEasy()).minTime(3, new int[] { 4, 6, 7 }, new int[] { 1, 2, 3 }, 1), 13);
            eq(1, (new RoadOrFlightEasy()).minTime(3, new int[] { 4, 6, 7 }, new int[] { 1, 2, 3 }, 2), 9);
            eq(2, (new RoadOrFlightEasy()).minTime(3, new int[] { 4, 6, 7 }, new int[] { 1, 2, 3 }, 3), 6);
            eq(3, (new RoadOrFlightEasy()).minTime(3, new int[] { 1, 2, 3 }, new int[] { 2, 3, 4 }, 2), 6);
            eq(4, (new RoadOrFlightEasy()).minTime(7, new int[] { 50, 287, 621, 266, 224, 68, 636 }, new int[] { 797, 661, 644, 102, 114, 452, 420 }, 2), 1772);
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
