using System;

public class RoomNumber
{
    public int numberOfSets(int roomNumber)
    {
        string numbers = roomNumber.ToString();
        int[] counts = new int[10];
        for (int i = 0; i < numbers.Length; i++)
        {
            counts[int.Parse(numbers[i].ToString())]++;
        }

        int countSix = counts[6] < counts[9] ? counts[6] : counts[9];
        int diff = Math.Abs(counts[6] - counts[9]);
        if (diff % 2 == 0) countSix = countSix + diff / 2;
        else countSix = countSix + (diff - 1) / 2 + 1;
        counts[6] = countSix;
        counts[9] = countSix;

        int maxCount = int.MinValue;
        for (int j = 0; j < counts.Length; j++)
        {
            if (counts[j] > maxCount)
                maxCount = counts[j];
        }

        return maxCount;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new RoomNumber()).numberOfSets(122), 2);
            eq(1, (new RoomNumber()).numberOfSets(9999), 2);
            eq(2, (new RoomNumber()).numberOfSets(12635), 1);
            eq(3, (new RoomNumber()).numberOfSets(888888), 6);
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
