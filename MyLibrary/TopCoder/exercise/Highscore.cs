// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class Highscore
{
    public int getRank(int[] scores, int newscore, int places)
    {
        //int place = 1;
        //int count = 0;

        //for (int i = 0; i < scores.Length; i++)
        //{
        //    if (scores[i] > newscore)
        //    {
        //        ++place;
        //    }
        //    if (scores[i] >= newscore)
        //    {
        //        ++count;
        //    }
        //}

        //if (count >= places)
        //{
        //    place = -1;
        //}

        //return place;

        int place = 1;
        for (int i = 0; i < scores.Length; i++)
        {
            if (newscore < scores[i])
            {
                place++;
            }
        }

        if (place == places + 1)
            return -1;

        if (scores.Length == places && scores[scores.Length - 1] == newscore)
            return -1;

        return place;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new Highscore()).getRank(new int[] { 100, 90, 80 }, 90, 10), 2);
            eq(1, (new Highscore()).getRank(new int[] { }, 0, 50), 1);
            eq(2, (new Highscore()).getRank(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 1, 10), -1);
            eq(3, (new Highscore()).getRank(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 3, 0 }, 1, 10), 10);
            eq(4, (new Highscore()).getRank(new int[] {2000000000, 19539, 19466, 19146, 17441, 17002, 16348, 16343,
               15981, 15346, 14748, 14594, 13752, 13684, 13336, 13290, 12939,
               12208, 12163, 12133, 11621, 11119, 10872, 10710, 10390, 9934,
               9296, 8844, 8662, 8653, 8168, 7914, 7529, 7354, 6016, 5428,
               5302, 5158, 4853, 4538, 4328, 3443, 3222, 2107, 2107, 1337,
               951, 586, 424, 31}, 1337, 50), 46);
            eq(5, (new Highscore()).getRank(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1, 10), -1);
            eq(6, (new Highscore()).getRank(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 9 },
                10, 50), 1);
            eq(8, (new Highscore()).getRank(new int[] { 10, 10, 9, 9, 9, 8, 8, 8, 8, 7, 7, 7, 7, 7, 6, 6, 6, 6, 6, 6, 5, 5, 5, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 2 },
                2, 50), 45);
            eq(8, (new Highscore()).getRank(new int[] { 2000000000, 2000000000, 2000000000, 2000000000, 2000000000, 2000000000, 2000000000, 2000000000, 2000000000, 2000000000 }, 2000000000, 10), -1);
            eq(8, (new Highscore()).getRank(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, 10), 1);

            eq(8, (new Highscore()).getRank(new int[] { 1994545937, 1938943236, 1902605580, 1707491184, 1377509761, 1347571835, 1217847778, 1140345403, 1103320943, 856465388 },
                496673726, 42), 11);

            //eq(7, (new Highscore()).getRank(new int[] { 500, 400, 400, 400, 400 }, 400, 10), 2);
            //eq(8, (new Highscore()).getRank(new int[] ), );
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
