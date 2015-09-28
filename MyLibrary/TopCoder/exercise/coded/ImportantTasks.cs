using System;

public class ImportantTasks
{
    public int maximalCost(int[] complexity, int[] computers)
    {
        Array.Sort(complexity);
        Array.Sort(computers);

        int cpl = 0;
        int cpu = 0;
        int count = 0;
        while (cpu != computers.Length && cpl != complexity.Length)
        {
            if (computers[cpu] >= complexity[cpl])
            {
                count++;
                cpl++;
            }

            cpu++;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ImportantTasks()).maximalCost(new int[] { 1, 2, 3 }, new int[] { 2, 2, 2 }), 2);
            eq(1, (new ImportantTasks()).maximalCost(new int[] { 1, 2, 3 }, new int[] { 3 }), 1);
            eq(2, (new ImportantTasks()).maximalCost(new int[] { 3, 5, 1, 7 }, new int[] { 9, 4, 1, 1, 1 }), 3);
            eq(3, (new ImportantTasks()).maximalCost(new int[] { 5, 2, 7, 8, 6, 4, 2, 10, 2, 3 }, new int[] { 4, 1, 3, 6, 2, 10, 11, 1, 1, 3, 4, 2 }), 8);
            eq(4, (new ImportantTasks()).maximalCost(new int[] { 100 }, new int[] { 100, 100 }), 1);
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
