using System;

public class ValueHistogram
{
    public string[] build(int[] values)
    {
        int[] counts = new int[10];
        for (int i = 0; i < values.Length; i++)
        {
            counts[Convert.ToInt32(values[i])]++;
        }

        int max = int.MinValue;
        for (int j = 0; j < counts.Length; j++)
        {
            if (max < counts[j])
                max = counts[j];
        }

        string[] histogram = new string[max + 1];
        for (int k = histogram.Length - 1; k >= 0; k--)
        {
            char[] charArr = new char[counts.Length];
            for (int m = 0; m < counts.Length; m++)
            {
                if (counts[m] > 0)
                {
                    charArr[m] = 'X';
                    counts[m]--;
                }
                else
                    charArr[m] = '.';
            }
            histogram[k] = new string(charArr);
        }

        return histogram;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ValueHistogram()).build(new int[] { 2, 3, 5, 5, 5, 2, 0, 8 }), new string[] { "..........", ".....X....", "..X..X....", "X.XX.X..X." });
            eq(1, (new ValueHistogram()).build(new int[] { 9, 9, 9, 9 }), new string[] { "..........", ".........X", ".........X", ".........X", ".........X" });
            eq(2, (new ValueHistogram()).build(new int[] { 6, 4, 0, 0, 3, 9, 8, 8 }), new string[] { "..........", "X.......X.", "X..XX.X.XX" });
            eq(3, (new ValueHistogram()).build(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }), new string[] { "..........", "XXXXXXXXXX" });
            eq(4, (new ValueHistogram()).build(new int[] { 6, 2, 3, 3, 3, 7, 8, 1, 0, 9, 2, 2, 4, 3 }), new string[] { "..........", "...X......", "..XX......", "..XX......", "XXXXX.XXXX" });
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
