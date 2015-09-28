using System;

public class Trekking
{
    public int findCamps(string trail, string[] plans)
    {
        int minNights = int.MaxValue;
        for (int i = 0; i < plans.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < trail.Length; j++)
            {
                if (trail[j] == '^' && plans[i][j] == 'C') break;
                else if (trail[j] == '.' && plans[i][j] == 'C') count++;

                if (j == trail.Length - 1 && count < minNights) minNights = count;
            }
        }

        if (minNights == int.MaxValue) minNights = -1;//don't forget this case

        return minNights;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new Trekking()).findCamps("^^....^^^...", new string[] {"CwwCwwCwwCww",
                "wwwCwCwwwCww",
                "wwwwCwwwwCww"}), 2);
            eq(1, (new Trekking()).findCamps("^^^^", new string[] {"wwww",
                "wwwC"
               }), 0);
            eq(2, (new Trekking()).findCamps("^^.^^^^", new string[] {"wwCwwwC",
                "wwwCwww",
                "wCwwwCw"}), -1);
            eq(3, (new Trekking()).findCamps("^^^^....^.^.^.", new string[] {"wwwwCwwwwCwCwC",
                "wwwwCwwCwCwwwC",
                "wwwCwwwCwwwCww",
                "wwwwwCwwwCwwwC"}), 3);
            eq(4, (new Trekking()).findCamps("..............", new string[] {"CwCwCwCwCwCwCw",
                "CwwCwwCwwCwwCw"}), 5);
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
