using System;

public class MixtureDensity
{
    public double getDensity(string[] ingredients)
    {
        int mass = 0;
        int volume = 0;
        for (int i = 0; i < ingredients.Length; i++)
        {
            string[] ingredient = ingredients[i].Split(new char[] { ' ' });
            mass = mass + int.Parse(ingredient[ingredient.Length - 2]);
            volume = volume + int.Parse(ingredient[0]);
        }

        return (double)mass / volume;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new MixtureDensity()).getDensity(new string[] { "200 ml of oil, weighing 180 g" }), 0.9);
            eq(1, (new MixtureDensity()).getDensity(new string[] { "100 ml of dichloromethane, weighing 130 g", "100 ml of sea water, weighing 103 g" }), 1.165);
            eq(2, (new MixtureDensity()).getDensity(new string[] { "1000 ml of water, weighing 1000 g", "500 ml of orange juice concentrate, weighing 566 g" }), 1.044);
            eq(3, (new MixtureDensity()).getDensity(new string[] { "1000 ml of something   l i g h t, weighing 1 g" }), 0.0010);
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
