using System;

public class IncredibleMachineEasy
{
    public double gravitationalAcceleration(int[] height, int T)
    {
        double tempSum = 0;
        for (int i = 0; i < height.Length; i++)
        {
            tempSum = tempSum + Math.Sqrt(2 * height[i]);
        }

        return Math.Pow(tempSum, 2) / Math.Pow(T, 2);
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new IncredibleMachineEasy()).gravitationalAcceleration(new int[] { 16, 23, 85, 3, 35, 72, 96, 88, 2, 14, 63 }, 30), 9.803799620759717);
            eq(1, (new IncredibleMachineEasy()).gravitationalAcceleration(new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 5 }, 12), 26.73924541044107);
            eq(2, (new IncredibleMachineEasy()).gravitationalAcceleration(new int[] { 8, 8 }, 3), 7.111111111111111);
            eq(3, (new IncredibleMachineEasy()).gravitationalAcceleration(new int[] { 3, 1, 3, 1, 3 }, 12), 0.7192306901503684);
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
