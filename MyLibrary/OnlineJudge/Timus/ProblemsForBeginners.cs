using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Text;

namespace OnlineJudge.Timus
{
    [TestClass]
    public class ProblemsForBeginners
    {
        private static int[] GetInput()
        {
            return new[] { 1, 2, 3, 4, 5, 6 };
        }

        #region Rope 1020

        [TestMethod]
        public void Rope_1020()
        {
            //string[] input = Console.In.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] input = new string[] 
                { 
                    "4 1",
                    "0.0 0.0",
                    "2.0 0.0",
                    "2.0 2.0",
                    "0.0 2.0"
                };

            string[] firstLine = input[0].Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int count = int.Parse(firstLine[0]);
            double r = double.Parse(firstLine[1]);

            double[][] points = new double[count][];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new double[2];
                string[] point1 = input[i + 1].Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                points[i][0] = double.Parse(point1[0]);
                points[i][1] = double.Parse(point1[1]);
            }

            double length = 0.0;
            for (int i = 1; i < points.Length; i++)
            {
                length = length +
                Math.Sqrt(Math.Pow(points[i - 1][0] - points[i][0], 2) +
                          Math.Pow(points[i - 1][1] - points[i][1], 2));
            }

            length = length +
                    Math.Sqrt(Math.Pow(points[points.Length - 1][0] - points[0][0], 2) +
                              Math.Pow(points[points.Length - 1][1] - points[0][1], 2));

            length = length + 2 * Math.PI * r;

            Console.WriteLine(Math.Round(length, 2));
        }

        #endregion

        #region Donald is a postman 2023

        [TestMethod]
        public void Donald_Is_A_Postman_2023()
        {
            string[] input = new string[] { "4", "Aurora", "Tiana", "Ariel", "Mulan" };

            string[][] names = new string[][]
             {
                 new string[]{"Alice", "Ariel", "Aurora", "Phil", "Peter", "Olaf", "Phoebus", "Ralph", "Robin"}, 
                 new string[]{"Bambi", "Belle", "Bolt", "Mulan", "Mowgli", "Mickey", "Silver", "Simba", "Stitch"}, 
                 new string[]{"Dumbo", "Genie", "Jiminy", "Kuzko", "Kida", "Kenai", "Tarzan", "Tiana", "Winnie"}, 
             };

            int currentPos = 0;
            int count = 0;
            for (int i = 1; i < int.Parse(input[0]) + 1; i++)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    if (names[j].Contains(input[i]))
                    {
                        count = count + Math.Abs(j - currentPos);
                        currentPos = j;
                        break;
                    }
                }
            }

            Console.WriteLine(count);
        }

        #endregion

        #region Hotl 1319

        /// <summary>
        /// 0,2
        /// 0,1 1,2
        /// 0,0 1,1 2,2
        /// 
        /// 1,0 2,1
        /// 2,0
        /// </summary>
        [TestMethod]
        public void Hotel_1319()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] matix = new int[n][];
            int count = 1;
            for (int i = 0; i < n; i++)
            {
                matix[i] = new int[n];
                for (int j = 0; j <= i; j++)
                {
                    matix[j][n - 1 - i + j] = count++;
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= n - 1 - i; j++)
                {
                    matix[i + j][j] = count++;
                }
            }

            for (int i = 0; i < matix.Length; i++)
            {
                for (int j = 0; j < matix[i].Length; j++)
                {
                    if (j == matix[i].Length - 1)
                        Console.Write(matix[i][j]);
                    else
                        Console.Write(string.Format("{0} ", matix[i][j]));
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Maximum 1079

        [TestMethod]
        public void Maximum_1079()
        {
            string[] input = new string[] { "5", "10", "0" };
            //string[] input = GetInput();

            int k = 0;
            while (input[k] != "0")
            {
                int[] value = new int[int.Parse(input[k]) + 1];
                for (int i = 0; i < value.Length; i++)
                {
                    value[i] = -1;
                }

                int max = 0;
                for (int i = int.Parse(input[k]); i >= 0; i--)
                {
                    if (value[i] == -1)
                    {
                        value[i] = GetAi(value, i);
                    }

                    if (value[i] > max)
                    {
                        max = value[i];
                    }
                }

                Console.WriteLine(max);

                k = k + 1;
            }
        }

        private static int GetAi(int[] value, int i)
        {
            if (i == 0)
            {
                value[i] = 0;
            }
            else if (i == 1)
            {
                value[i] = 1;
            }
            else if (i % 2 == 0)
            {
                if (value[i] == -1)
                {
                    value[i] = GetAi(value, i / 2);
                }
            }
            else
            {
                if (value[i] == -1)
                {
                    value[i] = GetAi(value, i / 2) + GetAi(value, i / 2 + 1);
                }
            }

            return value[i];
        }

        #endregion

        #region Lucky tickets. easy 1044

        [TestMethod]
        public void Lucky_Ticket_Easy_1044()
        {
            //int input = int.Parse(Console.ReadLine());
            int input = 4;

            int max = GetMax(input / 2);
            int[] counts = new int[(input / 2) * 9 + 1];

            for (int i = 0; i <= max; i++)
            {
                int sum = GetDigitsSum(i);
                counts[sum]++;
            }

            int luckyCount = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                luckyCount = luckyCount +
                                (counts[i] == 1 ? 1 : counts[i] * (counts[i] - 1)) +//all permutation
                                (counts[i] == 1 ? 0 : counts[i]);//combination itself but excluding one element. E.g., 00, 99
            }

            Console.WriteLine(luckyCount);
        }

        private static int GetDigitsSum(int i)
        {
            int sum = 0;
            char[] digits = i.ToString().ToArray();
            for (int j = 0; j < digits.Length; j++)
            {
                sum = sum + int.Parse(digits[j].ToString());
            }

            return sum;
        }

        private static int GetMax(int digits)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < digits; i++)
            {
                sb.Append("9");
            }

            return int.Parse(sb.ToString());
        }

        #endregion

        #region Some Words about Sports 1313

        [TestMethod]
        public void Some_Words_About_Sports_1313()
        {
            string[] input = new[] { "4", "1 3 6 10", "2 5 9 13", "4 8 12 15", "7 11 14 16" };
            //string[] input = Console.In.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(input[0]);
            int[][] pixels = new int[n][];
            for (int i = 0; i < n; i++)
            {
                pixels[i] = new int[n];
                string[] pixelsString = input[i + 1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    pixels[i][j] = int.Parse(pixelsString[j]);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    sb.Append(string.Format("{0} ", pixels[i - j][j]));
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    sb.Append(string.Format("{0} ", pixels[n - 1 - j][i + j + 1]));
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        #endregion

        #region Product of Digits 1014

        public void Product_Of_Digits_1014()
        {
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.WriteLine(10);
            }
            else if (input == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                StringBuilder digits = new StringBuilder();
                for (int i = 9; i > 1; i--)
                {
                    while (input % i == 0)
                    {
                        digits.Append(i);
                        input = input / i;
                    }
                }

                if (digits.ToString() == "" || input.ToString().Length > 1)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    char[] arr = digits.ToString().ToCharArray();
                    Array.Reverse(arr);
                    Console.WriteLine(new string(arr));
                }
            }
        }

        #endregion

        #region 1197 Lonesome Knight

        public void Lonesome_Knight_1197()
        {
            string[] input = Console.In.ReadToEnd().Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int count = int.Parse(input[0]);

            int attack = 0;
            for (int i = 0; i < count; i++)
            {
                attack = GetAttacks(input[i + 1].ToCharArray());
                Console.WriteLine(attack);
            }
        }

        private static int GetAttacks(char[] location)
        {
            int attack = 0;

            if (location[0] + 2 <= 'h')
            {
                if (int.Parse(location[1].ToString()) + 2 <= 8)
                {
                    attack = attack + 2;
                }
                else if (int.Parse(location[1].ToString()) + 1 <= 8)
                {
                    attack = attack + 1;
                }

                if (int.Parse(location[1].ToString()) - 2 >= 1)
                {
                    attack = attack + 2;
                }
                else if (int.Parse(location[1].ToString()) - 1 >= 1)
                {
                    attack = attack + 1;
                }
            }
            else if (location[0] + 1 <= 'h')
            {
                if (int.Parse(location[1].ToString()) + 2 <= 8)
                {
                    attack = attack + 1;
                }
                //care following case is wrong
                //else if (int.Parse(location[1].ToString()) + 1 <= 8)
                //{
                //    attack = attack + 1;
                //}

                if (int.Parse(location[1].ToString()) - 2 >= 1)
                {
                    attack = attack + 1;
                }
            }

            if (location[0] - 2 >= 'a')
            {
                if (int.Parse(location[1].ToString()) + 2 <= 8)
                {
                    attack = attack + 2;
                }
                else if (int.Parse(location[1].ToString()) + 1 <= 8)
                {
                    attack = attack + 1;
                }

                if (int.Parse(location[1].ToString()) - 2 >= 1)
                {
                    attack = attack + 2;
                }
                else if (int.Parse(location[1].ToString()) - 1 >= 1)
                {
                    attack = attack + 1;
                }
            }
            else if (location[0] - 1 >= 'a')
            {
                if (int.Parse(location[1].ToString()) + 2 <= 8)
                {
                    attack = attack + 1;
                }

                if (int.Parse(location[1].ToString()) - 2 >= 1)
                {
                    attack = attack + 1;
                }
            }

            return attack;
        }

        #endregion

        #region 1083 Factorials!!!

        [TestMethod]
        public void Factorials_1086_AC()
        {
            string[] input = Console.In.ReadToEnd().Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(input[0]);
            int k = input[1].Length;

            int product = n;
            for (int i = 1; n - i * k > k; i++)
            {
                product = product * (n - k * i);
            }

            if (n > k)
            {
                if (n % k == 0)
                    product = product * k;
                else
                    product = product * (n % k);
            }

            Console.WriteLine(product);
        }

        #endregion

        #region 1086 Cryptography

        [TestMethod]
        public void Cryptograpy_1086_AC()
        {
            int[] orders = new[] { 3, 2, 5, 7 };
            long[] primes = new long[orders.Max()];
            int orderInex = 0;

            int j = 2;
            int currentOrderIndex;
            for (int i = 0; i < orders.Length; i++)
            {
                currentOrderIndex = orders[i] - 1;
                if (primes[currentOrderIndex] != 0)
                {
                    Console.WriteLine(primes[currentOrderIndex]);
                    continue;
                }

                while (j <= long.MaxValue)
                {
                    if (IsPrime(j))
                    {
                        primes[orderInex] = j;

                        if (currentOrderIndex == orderInex++)
                        {
                            Console.WriteLine(j);
                            j++;//don't forget this line

                            break;
                        }
                    }

                    j++;
                }
            }
        }

        public static bool IsPrime(long number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            if (number == 1)
                return false;

            return true;
        }

        #endregion

        #region 1209 1, 10, 100, 1000...

        [TestMethod]
        public void One_Ten_Hundred_1209_AC()
        {
            long[] numbers = new long[] { 3, 14, 7, 6 }; ;

            using (var stdout = new StreamWriter(Console.OpenStandardOutput()))//can increase the speed a bit at the cost of memory comsumption
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (Math.Sqrt(8 * numbers[i] - 7) % 1 == 0)//1. don't ask me why use this formula 2. you need to use long type
                    {
                        stdout.WriteLine("1");
                    }
                    else
                    {
                        stdout.WriteLine("0");
                    }
                }
            }
        }

        [TestMethod]
        public void One_Ten_Hundred_1209_Time_Limited_Exceeded()
        {
            int[] numbers = new[] { 3, 14, 7, 6 };

            using (StreamWriter stdout = new StreamWriter(Console.OpenStandardOutput()))
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int index = numbers[i];
                    for (int j = 0; j < numbers[i]; j++)
                    {
                        index = index - j - 1;
                        if (index == 1)
                        {
                            stdout.WriteLine(1);
                            break;
                        }

                        if (index <= 0)
                        {
                            stdout.WriteLine(0);
                            break;
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void One_Ten_Hundred_1209_Memory_Limited_Exceed()
        {
            int[] numbers = GetInput();

            int max = numbers.Max();
            List<int> ones = new List<int>();

            int index = 0;
            for (int j = 0; j <= max; j++)
            {
                index = index + j;
                ones.Add(index + 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(ones.Contains(numbers[i]) ? "1" : "0");
            }
        }

        #endregion

        #region 1068 sum

        [TestMethod]
        public void Sum_1068()
        {
            int input = int.Parse(Console.In.ReadToEnd());
            int sum = 0;

            for (int i = input >= 1 ? 1 : input; i <= (input >= 1 ? input : 1); i++)
            {
                sum = sum + i;
            }

            Console.WriteLine(sum);
        }

        #endregion

        #region 1005 stone pile

        [TestMethod]
        public void Stone_Pile_1005_Memory_Limited_Exceeded()
        {
            List<int> all = new List<int> { 5, 8, 13, 27, 14 };
            List<List<int>> allSubsets = Lib.Common.Algorithm.GeneralAlgorithm.GetAllSubsets(all);

            int total = all.Sum();
            int minDiff = int.MaxValue;
            int subSum = 0;
            for (int i = 0; i < allSubsets.Count; i++)
            {
                for (int j = 0; j < allSubsets[i].Count; j++)
                {
                    subSum = allSubsets[i].Sum();
                }

                int diff = Math.Abs(total - 2 * subSum);
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }

            Console.WriteLine(string.Format("{0}", minDiff));
        }

        [TestMethod]
        public void Stone_Pile_1005_AC()
        {
            string[] input = Console.In.ReadToEnd().Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int num = int.Parse(input[0]);

            List<int> all = new List<int>();
            for (int i = 1; i < 1 + num; i++)
            {
                all.Add(int.Parse(input[i]));
            }

            GetAllCombination_V1(all);
        }

        public void GetAllCombination_V1(List<int> list)
        {
            int min = int.MaxValue;
            int sum = list.Sum();
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                int sumTemp = 0;
                string str = Convert.ToString(i, 2).PadRight(list.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        sumTemp = sumTemp + list[j];
                    }
                }

                int dealta = Math.Abs(sum - 2 * sumTemp);
                if (min > dealta)
                {
                    min = dealta;
                }
            }

            Console.WriteLine(min);
        }

        [TestMethod]
        public void Stone_Pile_1005_Time_Limited_Exceeded()
        {
            GetAllCombinations_V2(new[] { 5, 8, 13, 27, 14 });
        }

        public void GetAllCombinations_V2(int[] elements)
        {
            int sum = elements.Sum();
            int minDiff = int.MaxValue;
            double count = Math.Pow(2, elements.Length);

            for (int i = 1; i <= count - 1; i++)
            {
                int tempSum = 0;
                int index = i;
                for (int j = 0; j < count; j++)
                {
                    if (index % 2 == 1)
                    {
                        tempSum = tempSum + elements[j];
                    }
                    //index = index / 2;
                    index = index >> 1;
                }

                int dealta = Math.Abs(sum - 2 * tempSum);
                if (minDiff > dealta)
                {
                    minDiff = dealta;
                }
            }

            Console.WriteLine(minDiff);
        }

        [TestMethod]
        private void GetBinaryForm(int n)
        {
            string binary = "";
            for (int i = n; n > 0; i = i / 2)
            {
                binary = (i % 2) + binary;
            }

            Debug.WriteLine(binary);
        }

        #endregion

        #region General algorithm test

        public void SolveSubset<T>(List<T> set)
        {
            List<List<T>> allSubsets = Lib.Common.Algorithm.GeneralAlgorithm.GetAllSubsets(set);

            for (int i = 0; i < allSubsets.Count; i++)
            {
                for (int j = 0; j < allSubsets[i].Count; j++)
                {
                    Console.Write(string.Format("{0}    ", allSubsets[i][j]));
                }
                Console.WriteLine();

                if (i == allSubsets.Count - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine(allSubsets.Count);
                }
            }
        }

        public void SolvePermutaion(string input)
        {
            string[] result = Lib.Common.Algorithm.GeneralAlgorithm.GetAllPermutaions(input);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(string.Format("   {0}", result[i]));
                if (i == result.Length - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine(result.Count());
                    Console.WriteLine();
                }
            }
        }

        #endregion
    }
}
