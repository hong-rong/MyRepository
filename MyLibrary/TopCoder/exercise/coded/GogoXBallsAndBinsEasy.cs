using System;
using System.Linq;

public class GogoXBallsAndBinsEasy
{
    public int solve(int[] T)
    {
        int[] sorted = new int[T.Length];
        Array.Copy(T, sorted, T.Length);
        Array.Sort(sorted, (a, b) => -1 * a.CompareTo(b));
        int sum = 0;
        for (int i = 0; i < T.Length; i++)
        {
            if (T[i] - sorted[i] > 0) sum = sum + T[i] - sorted[i];
        }

        return sum;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new GogoXBallsAndBinsEasy()).solve(new int[] { 0, 2, 5 }), 5);
            eq(1, (new GogoXBallsAndBinsEasy()).solve(new int[] { 5, 6, 7, 8 }), 4);
            eq(2, (new GogoXBallsAndBinsEasy()).solve(new int[] { 0, 1, 2, 10 }), 11);
            eq(3, (new GogoXBallsAndBinsEasy()).solve(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }), 16);
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
