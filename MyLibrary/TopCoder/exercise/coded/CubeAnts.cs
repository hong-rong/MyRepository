using System;

public class CubeAnts
{
    public int getMinimumSteps(int[] pos)
    {
        int max = 0;
        for (int i = 0; i < pos.Length; i++)
        {
            int step = GetSteps(pos[i]);
            if (step > max) max = step;
        }

        return max;
    }

    private int GetSteps(int startPos)
    {
        if (startPos == 0) return 0;
        if (startPos == 1) return 1;
        if (startPos == 2) return 2;
        if (startPos == 3) return 1;
        if (startPos == 4) return 1;
        if (startPos == 5) return 2;
        if (startPos == 6) return 3;

        return 2;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new CubeAnts()).getMinimumSteps(new int[] { 0, 1, 1 }), 1);
            eq(1, (new CubeAnts()).getMinimumSteps(new int[] { 5, 4 }), 2);
            eq(2, (new CubeAnts()).getMinimumSteps(new int[] { 0 }), 0);
            eq(3, (new CubeAnts()).getMinimumSteps(new int[] { 6, 1, 6 }), 3);
            eq(4, (new CubeAnts()).getMinimumSteps(new int[] { 7, 7, 3, 3, 7, 7, 3, 3 }), 2);
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
