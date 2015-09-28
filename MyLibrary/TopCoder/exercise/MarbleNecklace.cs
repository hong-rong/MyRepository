// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class MarbleNecklace
{
    public string normalize(string necklace)
    {
        if (necklace.Length <= 1) return necklace;

        string min = necklace;
        char[] arr = necklace.ToCharArray();

        min = GetMin(necklace, min);

        string reverse = new string(necklace.Reverse().ToArray());

        min = GetMin(reverse, min);

        return min;
    }

    private static string GetMin(string necklace, string min)
    {
        for (int i = 0; i < necklace.Length; i++)
        {
            string temp = necklace.Substring(i + 1, necklace.Length - i - 1) + necklace.Substring(0, i + 1);
            if (temp.CompareTo(min) < 0) min = temp;
        }
        return min;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new MarbleNecklace()).normalize("CDAB"), "ABCD");
            eq(1, (new MarbleNecklace()).normalize("RGB"), "BGR");
            eq(2, (new MarbleNecklace()).normalize("TOPCODER"), "CODERTOP");
            eq(3, (new MarbleNecklace()).normalize("SONBZELGFEQMSULZCNPJODOWPEWLHJFOEW"), "BNOSWEOFJHLWEPWODOJPNCZLUSMQEFGLEZ");
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
