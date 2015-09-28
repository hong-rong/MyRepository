// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class GradingSystem
{
    public int fairness(int[] scores, int[] grades)
    {
        int[] firstSchema = new int[scores.Length];

        for (int i = 0; i < scores.Length; i++)
        {
            if (i == 0) firstSchema[i] = grades[i];
            else
            {
                if (scores[i] >= scores[i - 1] && grades[i] < firstSchema[i - 1])
                    firstSchema[i] = firstSchema[i - 1];
                else
                    firstSchema[i] = grades[i];
            }
        }

        int[] secondSchema = new int[scores.Length];
        for (int m = 0; m < grades.Length; m++)
            secondSchema[m] = grades[m];

        for (int j = scores.Length - 1; j >= 0; j--)
        {
            if (j == scores.Length - 1) secondSchema[j] = grades[j];
            else
            {
                if (scores[j] <= scores[j + 1] && grades[j] > secondSchema[j + 1])
                    secondSchema[j] = secondSchema[j + 1];
                else
                    secondSchema[j] = grades[j];
            }
        }

        int diffSum = 0;
        for (int k = 0; k < firstSchema.Length; k++)
        {
            diffSum = diffSum + Math.Abs(firstSchema[k] - secondSchema[k]);
        }

        return diffSum;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new GradingSystem()).fairness(new int[] { 60, 80, 80 }, new int[] { 3, 8, 6 }), 4);
            eq(1, (new GradingSystem()).fairness(new int[] { 0, 25, 50, 75, 100 }, new int[] { 0, 1, 3, 6, 8 }), 0);
            eq(2, (new GradingSystem()).fairness(new int[] { 0, 25, 50, 75, 100 }, new int[] { 8, 6, 3, 1, 0 }), 40);
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
