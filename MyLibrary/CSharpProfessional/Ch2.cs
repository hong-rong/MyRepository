#define WIN7
using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpProfessional
{
    public class @class
    { }

    public class \u005fClass
    { }

    public class Überfluß
    { }

    public enum TimeOfDay
    {
        Morning = 0,
        Afternoon = 1,
        Evening = 2
    }

    public class Ch2 : ITest
    {
        public void Test()
        {

        }

#pragma warning disable
        private static void ProProcessorDirectives_PragmaWarning()
        {
            int fieldNotUsed = 1;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("field not used test.");
            }
        }
#pragma warning restore

        private static void ProProcessorDirectrives_Define()
        {
#if MARK
            Console.WriteLine("defined MARK");
#endif

#if DEBUG
            Console.WriteLine("defined DEBUG");
#endif

#if MARK && DEBUG
            //#error "You've defined DEBUG and MARK simultaneously!"
#warning "You've defined DEBUG and MARK simultaneously!"
#endif
        }

        private void ShowComment()
        {
            int a = 1;
            string s = "s";
            XmlDocumentation(a, s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <c>int a = 10</c>
        /// <exception cref="IOException"></exception>
        /// <include file='App.config' path='[@name=""]'/>
        /// <param name="a"></param>
        /// <param name="s"></param>
        private void XmlDocumentation(int a, string s)
        {
            throw new NotImplementedException();
        }

        private static void Comment()
        {
            Console.WriteLine( /* comment */"This will compile.");
            Console.WriteLine("{0},{1}", "300", /*height*/"400");
            Console.WriteLine("/* This is just normal string. */");
        }

        private static void ConsoleIoFormat()
        {
            decimal i = 940.23m;
            decimal j = 73.7m;
            Console.WriteLine(" {0,9:C2}\n+{1,9:C2}\n-----\n {2,9:C2}", i, j, i + j);

            int m = 100;
            Console.WriteLine("{0,8:D4}", m);

            double d = 1.23;
            Console.WriteLine("{0,8:E4}", d);

            float f = 2.13F;
            Console.WriteLine("{0,8:F8}", f);

            Console.WriteLine("{0,8:G8}, {1,8:G8}", d, f);

            long l = 1234567678;
            Console.WriteLine("{0,8:N}", l);

            int p = 12345;
            Console.WriteLine("{0,8:P}", p);

            int x = 123;
            Console.WriteLine("{0,8:X}", x);
        }

        private static void ConsoleIo()
        {
            Console.WriteLine("{0}, {1}", "hello", "world ");

            int i = 940;
            int j = 73;
            //{n,w}
            Console.WriteLine(" {0,4}\n+{1,4}\n — — \n {2,4}", i, j, i + j);
            Console.WriteLine();
            Console.WriteLine(" {0,-4}\n+{1,-4}\n — — \n {2,-4}", i, j, i + j);
            Console.WriteLine();
        }

        private void Enum()
        {
            //WriteGreeting(TimeOfDay.Afternoon);

            TimeOfDay time = TimeOfDay.Afternoon;
            Console.WriteLine(time.ToString());

            TimeOfDay time2 = (TimeOfDay)System.Enum.Parse(typeof(TimeOfDay), "evening", true);
            Console.WriteLine((int)time2);
        }

        private static void WriteGreeting(TimeOfDay timeOfDay)
        {
            switch (timeOfDay)
            {
                case TimeOfDay.Morning:
                    Console.WriteLine("Good morning!");
                    break;
                case TimeOfDay.Afternoon:
                    Console.WriteLine("Good afternoon");
                    break;
                case TimeOfDay.Evening:
                    Console.WriteLine("Good evening");
                    break;
                default:
                    Console.WriteLine("Hello!");
                    break;
            }
        }

        private static void ForEach()
        {
            List<KeyValuePair<int, string>> arr = new List<KeyValuePair<int, string>>();
            foreach (var array in arr)
            {
                Console.WriteLine(array.Value);
                //array.Value = 1;
            }
        }

        private void Switch()
        {
            string a = "a";

            const string england = "uk";
            const string britain = "uka";

            switch (a)
            {
                case england:
                    Console.WriteLine("a");
                    break;
                case britain:
                    Console.WriteLine("b");
                    break;
                default:
                    Console.WriteLine("U");
                    break;
            }
        }
    }
}
