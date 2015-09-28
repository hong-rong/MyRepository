using System;

public class ANDEquation
{
    public int restoreY(int[] A)
    {
        for (int i = 0; i < A.Length; i++)
        {
            int andResult = (int)Math.Pow(2, 20) - 1;//1048575
            for (int j = 0; j < A.Length; j++)
            {
                if (j == i) continue;

                andResult = andResult & A[j];
            }

            if (A[i] == andResult) return A[i];
        }

        return -1;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ANDEquation()).restoreY(new int[] { 1, 3, 5 }
               ), 1);
            eq(1, (new ANDEquation()).restoreY(new int[] { 31, 7 }
               ), -1);
            eq(2, (new ANDEquation()).restoreY(new int[] { 31, 7, 7 }
               ), 7);
            eq(3, (new ANDEquation()).restoreY(new int[] {1,0,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,0,
                0,0,0,0,0,0,1,0,1,0,1,1,0,0,0,1}), 0);
            eq(4, (new ANDEquation()).restoreY(new int[] {191411,256951,191411,191411,191411,256951,195507,191411,192435,191411,
                191411,195511,191419,191411,256947,191415,191475,195579,191415,191411,
                191483,191411,191419,191475,256947,191411,191411,191411,191419,256947,
                191411,191411,191411}), 191411);
            eq(5, (new ANDEquation()).restoreY(new int[] { 1362, 1066, 1659, 2010, 1912, 1720, 1851, 1593, 1799, 1805, 1139, 1493, 1141, 1163, 1211 }), -1);
            eq(6, (new ANDEquation()).restoreY(new int[] { 2, 3, 7, 19 }), -1);
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
