using System;

public class LoveCalculator
{
    public string findBoy(string girl, string[] boys)
    {
        Array.Sort(boys);
        //((L+O)*(L+V)*(L+E)*(O+V)*(O+E)*(V+E))%100
        int girlL = GetFrequency(girl, 'L');
        int girlO = GetFrequency(girl, 'O');
        int girlV = GetFrequency(girl, 'V');
        int girlE = GetFrequency(girl, 'E');
        double maxPercent = double.MinValue;
        string name = null;
        for (int i = 0; i < boys.Length; i++)
        {
            int L = GetFrequency(boys[i], 'L') + girlL;
            int O = GetFrequency(boys[i], 'O') + girlO;
            int V = GetFrequency(boys[i], 'V') + girlV;
            int E = GetFrequency(boys[i], 'E') + girlE;
            double percent = ((L + O) * (L + V) * (L + E) * (O + V) * (O + E) * (V + E)) % 100;
            if (maxPercent < percent)
            {
                maxPercent = percent;
                name = boys[i];
            }
        }

        return name;
    }

    private int GetFrequency(string name, char c)
    {
        int count = 0;
        for (int i = 0; i < name.Length; i++)
        {
            if (name[i] == c) count++;
        }

        return count;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new LoveCalculator()).findBoy("LOVE", new string[] { "JACOB", "FRANK", "DANO" }), "FRANK");
            eq(1, (new LoveCalculator()).findBoy("JANE", new string[] { "THOMAS", "MICHAEL", "INDY", "LIU" }), "INDY");
            eq(2, (new LoveCalculator()).findBoy("LILLY", new string[] { "PIERRE" }), "PIERRE");
            eq(3, (new LoveCalculator()).findBoy("MERYLOV", new string[] { "JOHN", "DAVE", "STEVE", "JOHN", "DAVE" }), "DAVE");
            eq(4, (new LoveCalculator()).findBoy("LLOL", new string[] { "BVERON", "CVERON", "AVERON", "DVERON" }), "AVERON");
            eq(5, (new LoveCalculator()).findBoy("VELYLEOCEVE", new string[] { "YVXHOVE", "LCOKO", "OGWSJVEVEDLE", "WGFVSJEL", "VLOLUVCBLLQVESWHEEKC" }), "VLOLUVCBLLQVESWHEEKC");
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
