// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class SerialNumbers
{
    public string[] sortSerials(string[] serialNumbers)
    {
        Array.Sort(serialNumbers, (a, b) =>
        {
            if (a.Length > b.Length) return 1;
            else if (a.Length < b.Length) return -1;
            else
            {
                int sumA = 0;
                int sumB = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] >= '0' && a[i] <= '9')
                        sumA = sumA + int.Parse(a[i].ToString());

                    if (b[i] >= '0' && b[i] <= '9')
                        sumB = sumB + int.Parse(b[i].ToString());
                }

                if (sumA > sumB) return 1;
                else if (sumA < sumB) return -1;
                else
                {
                    return a.CompareTo(b);
                }
            }
        });

        return serialNumbers;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SerialNumbers()).sortSerials(new string[] { "ABCD", "145C", "A", "A910", "Z321" }), new string[] { "A", "ABCD", "Z321", "145C", "A910" });
            eq(1, (new SerialNumbers()).sortSerials(new string[] { "Z19", "Z20" }), new string[] { "Z20", "Z19" });
            eq(2, (new SerialNumbers()).sortSerials(new string[] { "34H2BJS6N", "PIM12MD7RCOLWW09", "PYF1J14TF", "FIPJOTEA5" }), new string[] { "FIPJOTEA5", "PYF1J14TF", "34H2BJS6N", "PIM12MD7RCOLWW09" });
            eq(3, (new SerialNumbers()).sortSerials(new string[] { "ABCDE", "BCDEF", "ABCDA", "BAAAA", "ACAAA" }), new string[] { "ABCDA", "ABCDE", "ACAAA", "BAAAA", "BCDEF" });
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
