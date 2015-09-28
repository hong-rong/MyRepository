using System;

public class DownloadingFiles
{
    public double actualTime(string[] tasks)
    {
        Array.Sort(tasks, (a, b) =>
        {
            int timeA = int.Parse(a.Split(new char[] { ' ' })[1]);
            int timeB = int.Parse(b.Split(new char[] { ' ' })[1]);

            if (timeA < timeB) return -1;
            else if (timeA == timeB) return 0;
            else return -1;
        });

        double elapse = 0.0;
        double bandwidth = 0.0;
        for (int i = 0; i < tasks.Length; i++)
        {
            if (i == 0)
            {
                bandwidth = bandwidth + double.Parse(tasks[i].Split(new char[] { ' ' })[0]);
                elapse = elapse + double.Parse(tasks[i].Split(new char[] { ' ' })[1]);
            }
            else
            {
                double tempBandwidth = double.Parse(tasks[i].Split(new char[] { ' ' })[0]);
                double tempElapse = double.Parse(tasks[i].Split(new char[] { ' ' })[1]);

                bandwidth = bandwidth + tempBandwidth;
                elapse = elapse + (tempElapse - elapse) * tempBandwidth / bandwidth;
            }
        }

        return elapse;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new DownloadingFiles()).actualTime(new string[] { "3 57", "2 22" }), 43.0);
            eq(1, (new DownloadingFiles()).actualTime(new string[] { "3 1057", "2 1022" }), 1043.0);
            eq(2, (new DownloadingFiles()).actualTime(new string[] { "25 1000", "5 5000", "10 5000" }), 2500.0);
            eq(3, (new DownloadingFiles()).actualTime(new string[] { "1 10", "1 20", "2 40" }), 27.5);
            eq(4, (new DownloadingFiles()).actualTime(new string[] { "6 88", "39 7057", "63 2502", "45 2285", "28 8749", "62 3636", "1 5546", "49 5741" }), 4414.542662116041);
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
