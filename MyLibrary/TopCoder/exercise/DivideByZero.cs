// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DivideByZero
{
    public int CountNumbers(int[] numbers)
    {
        List<int> nums = numbers.ToList();

        bool added = true;
        while (added)
        {
            added = false;
            nums.Sort((a, b) => -1 * a.CompareTo(b));
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    int div = nums[i] / nums[j];
                    if (!nums.Contains(div))
                    {
                        nums.Add(div);
                        added = true;
                        break;
                    }
                }

                if (added) break;
            }
        }

        return nums.Count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new DivideByZero()).CountNumbers(new int[] { 9, 2 }), 3);
            eq(1, (new DivideByZero()).CountNumbers(new int[] { 8, 2 }), 3);
            eq(2, (new DivideByZero()).CountNumbers(new int[] { 50 }), 1);
            eq(3, (new DivideByZero()).CountNumbers(new int[] { 1, 5, 8, 30, 15, 4 }), 11);
            eq(4, (new DivideByZero()).CountNumbers(new int[] { 1, 2, 4, 8, 16, 32, 64 }), 7);
            eq(5, (new DivideByZero()).CountNumbers(new int[] { 6, 2, 18 }), 7);
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
