// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

public class SnowyWinter
{
    public int snowyHighwayLength(int[] startPoints, int[] endPoints)
    {
        for (int i = 0; i < startPoints.Length; i++)
        {
            for (int j = i + 1; j < startPoints.Length; j++)
            {
                if (endPoints[i] >= startPoints[j] && endPoints[i] <= endPoints[j])
                {
                    startPoints[j] = startPoints[i] < startPoints[j] ? startPoints[i] : startPoints[j];
                    startPoints[i] = 0;
                    endPoints[i] = 0;
                    break;
                }
                else if (startPoints[i] >= startPoints[j] && startPoints[i] <= endPoints[j])
                {
                    endPoints[j] = endPoints[i] < endPoints[j] ? endPoints[j] : endPoints[i];
                    startPoints[i] = 0;
                    endPoints[i] = 0;
                    break;
                }
                else if (startPoints[i] <= startPoints[j] && endPoints[i] >= endPoints[j])
                {
                    startPoints[j] = startPoints[i];
                    endPoints[j] = endPoints[i];
                    startPoints[i] = 0;
                    endPoints[i] = 0;
                    break;
                }
            }
        }

        int total = 0;
        for (int k = 0; k < startPoints.Length; k++)
        {
            total = total + (endPoints[k] - startPoints[k]);
        }

        return total;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SnowyWinter()).snowyHighwayLength(new int[] { 17, 85, 57 }, new int[] { 33, 86, 84 }), 44);
            eq(1, (new SnowyWinter()).snowyHighwayLength(new int[] { 45, 100, 125, 10, 15, 35, 30, 9 }, new int[] { 46, 200, 175, 20, 25, 45, 40, 10 }), 132);
            eq(2, (new SnowyWinter()).snowyHighwayLength(new int[] { 4387, 711, 2510, 1001, 4687, 3400, 5254, 584, 284, 1423, 3755, 929, 2154, 5719, 1326, 2368, 554 }, new int[] { 7890, 5075, 2600, 6867, 7860, 9789, 6422, 5002, 4180, 7086, 8615, 9832, 4169, 7188, 9975, 8690, 1423 }), 9691);
            eq(3, (new SnowyWinter()).snowyHighwayLength(new int[] { 4906, 5601, 5087, 1020, 4362, 2657, 6257, 5509, 5107, 5315, 277, 6801, 2136, 2921, 5233, 5082, 497, 8250, 3956, 5720 }, new int[] { 4930, 9130, 9366, 2322, 4687, 4848, 8856, 6302, 5496, 5438, 829, 9053, 4233, 4119, 9781, 8034, 3956, 9939, 4908, 5928 }), 9510);
            eq(4, (new SnowyWinter()).snowyHighwayLength(new int[] { 51, 807, 943, 4313, 8319, 3644, 481, 220, 2161, 448, 465, 1657, 6290, 22, 6152, 647, 3185, 4474, 2168 }, new int[] { 1182, 912, 1832, 7754, 9557, 7980, 4144, 3194, 7129, 5535, 1172, 2043, 6437, 7252, 9508, 4745, 8313, 8020, 4017 }), 9535);
            eq(5, (new SnowyWinter()).snowyHighwayLength(new int[] { 8786, 7391, 201, 4414, 5822, 5872, 157, 1832, 7487, 7518, 2267, 1763, 3984, 3102, 7627, 4099, 524, 1543, 1022, 3060 }, new int[] { 9905, 7957, 3625, 6475, 9314, 9332, 4370, 8068, 8295, 8177, 7772, 2668, 7191, 8480, 9211, 4802, 2625, 1924, 9970, 4180 }), 9813);
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
