using System;

public class AverageAverage
{
    public double average(int[] numList)
    {
        int total = (int)Math.Pow(2, numList.Length);
        double[] ave = new double[total];
        for (int i = 1; i < total; i++)
        {
            string s = Convert.ToString(i, 2).PadLeft(numList.Length, '0');
            int count = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '1')
                {
                    ave[i] = ave[i] + numList[j];
                    count++;
                }
            }

            ave[i] = ave[i] / count;
        }

        double sum = 0.0;
        for (int k = 0; k < ave.Length; k++)
        {
            sum = sum + ave[k];
        }

        return sum / (ave.Length - 1);
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new AverageAverage()).average(new int[] { 1, 2, 3 }), 2.0);
            eq(1, (new AverageAverage()).average(new int[] { 42 }), 42.0);
            eq(2, (new AverageAverage()).average(new int[] { 3, 1, 4, 15, 9 }), 6.4);
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
