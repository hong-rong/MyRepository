using System;

public class TheBestName
{
    public string[] sort(string[] names)
    {
        Array.Sort(names, (a, b) =>
        {
            if (a == "JOHN" && b != "JOHN") return -1;
            else if (a == "JOHN" && b == "JOHN") return 0;
            else if (a != "JOHN" && b == "JOHN") return 1;

            int sumA = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sumA = sumA + a[i] - 'A' + 1;
            }
            int sumB = 0;
            for (int j = 0; j < b.Length; j++)
            {
                sumB = sumB + b[j] - 'A' + 1;
            }

            if (sumA > sumB) return -1;
            else if (sumA == sumB)
            {
                return a.CompareTo(b);
            }
            else return 1;
        });

        return names;
    }


    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TheBestName()).sort(new string[] { "JOHN", "PETR", "ACRUSH" }), new string[] { "JOHN", "ACRUSH", "PETR" });
            eq(1, (new TheBestName()).sort(new string[] { "GLUK", "MARGARITKA" }), new string[] { "MARGARITKA", "GLUK" });
            eq(2, (new TheBestName()).sort(new string[] { "JOHN", "A", "AA", "AAA", "JOHN", "B", "BB", "BBB", "JOHN", "C", "CC", "CCC", "JOHN" }), new string[] { "JOHN", "JOHN", "JOHN", "JOHN", "CCC", "BBB", "CC", "BB", "AAA", "C", "AA", "B", "A" });
            eq(3, (new TheBestName()).sort(new string[] { "BATMAN", "SUPERMAN", "SPIDERMAN", "TERMINATOR" }), new string[] { "TERMINATOR", "SUPERMAN", "SPIDERMAN", "BATMAN" });
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
