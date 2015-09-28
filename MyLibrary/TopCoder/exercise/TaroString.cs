using System;
using System.Text;

public class TaroString
{
    public string getAnswer(string S)
    {
        //for (int i = 65; i <= 90; i++)
        //{
        //    if (i != 'C' && i != 'A' && i != 'T')
        //    {
        //        S = S.Replace(new string((char)i, 1), "");
        //    }
        //}

        //return S == "CAT" ? "Possible" : "Impossible";

        int[] counts = new int[3];
        int[] location = new int[3];

        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == 'C')
            {
                if (++counts[0] > 1) return "Impossible";

                location[0] = i;
            }

            if (S[i] == 'A')
            {
                if (++counts[1] > 1) return "Impossible";

                location[1] = i;
            }

            if (S[i] == 'T')
            {
                if (++counts[2] > 1) return "Impossible";

                location[2] = i;
            }
        }

        if (counts[0] == 1 && counts[1] == 1 && counts[2] == 1 && location[0] < location[1] && location[1] < location[2])
            return "Possible";

        return "Impossible";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new TaroString()).getAnswer("XCYAZTX"), "Possible");
            eq(1, (new TaroString()).getAnswer("CTA"), "Impossible");
            eq(2, (new TaroString()).getAnswer("ACBBAT"), "Impossible");
            eq(3, (new TaroString()).getAnswer("SGHDJHFIOPUFUHCHIOJBHAUINUIT"), "Possible");
            eq(4, (new TaroString()).getAnswer("CCCATT"), "Impossible");
            eq(5, (new TaroString()).getAnswer("CAT"), "Possible");
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
