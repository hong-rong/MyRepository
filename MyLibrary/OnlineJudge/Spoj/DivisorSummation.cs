using System;
using System.IO;
using Lib.Common.Watch;

namespace OnlineJudge.Spoj
{
    public class DivisorSummation
    {
        private static void Solve()
        {
            using (StreamWriter stdout = new StreamWriter(Console.OpenStandardOutput()))
            using (StreamReader stdin = new StreamReader(Console.OpenStandardInput()))
            {
                stdout.AutoFlush = true;

                string inputCount = stdin.ReadLine();
                int count = int.Parse(inputCount);
                while (count-- != 0)
                {
                    string inputNumber = stdin.ReadLine();
                    int number = int.Parse(inputNumber);
                    int sum = 1;
                    int upperBound = Convert.ToInt32((Math.Sqrt(number)));
                    for (int i = 2; i <= upperBound; i++)
                    {
                        if (number % i == 0)
                        {
                            int result = number / i;
                            if (i != result)
                            {
                                sum = sum + result;
                            }
                            sum = sum + i;
                        }
                    }
                    stdout.WriteLine(sum);
                }
            }
        }

        public static void TimeExceedLimitTest()
        {
            using (StreamWriter stdout = new StreamWriter(Console.OpenStandardOutput()))
            using (StreamReader stdin = new StreamReader(Console.OpenStandardInput()))
            {
                stdout.AutoFlush = true;
                Console.SetOut(stdout);

                string input = stdin.ReadLine();
                //Console.SetIn(stdin);
                //string input = Console.ReadLine();
                int number;
                int sum;
                int upperBound;
                using (new TimeWatch())
                    for (int i = 0; i < 200000; i++)
                    {
                        number = int.Parse(input);

                        sum = 1;
                        upperBound = Convert.ToInt32((Math.Sqrt(number)));
                        for (int k = 2; k <= upperBound; k++)
                        {
                            if (number % k == 0)
                            {
                                int result = number / k;
                                if (k != result)
                                {
                                    sum = sum + result;
                                }

                                sum = sum + k;
                            }
                        }

                        stdout.WriteLine(sum);
                    }
            }

            Console.ReadLine();
        }

        private static void CalculateSummation(string input, StreamWriter stdout)
        {
            int number = int.Parse(input);

            int sum = 1;
            int upperBound = Convert.ToInt32((Math.Sqrt(number)));
            for (int k = 2; k <= upperBound; k++)
            {
                if (number % k == 0)
                {
                    int result = number / k;
                    if (k != result)
                    {
                        sum = sum + result;
                    }

                    sum = sum + k;
                }
            }

            stdout.WriteLine(sum);
        }
    }
}