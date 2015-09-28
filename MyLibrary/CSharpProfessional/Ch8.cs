using System;
using System.Collections.Generic;

namespace CSharpProfessional
{
    class MathOperations
    {
        public static double MultiplyByTwo(double value)
        {
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }

        public static void MultiplyByTwoAction(double value)
        {
            double result = value * 2;
            Console.WriteLine("Multiplying by 2: {0} gives {1}", value, result);
        }
        public static void SquareAction(double value)
        {
            double result = value * value;
            Console.WriteLine("Squaring: {0} gives {1}", value, result);
        }
    }

    internal delegate double DoubleOp(double x);

    class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; private set; }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}, {1:C}", Name, Salary);
        }

        public static bool CompareSalary(Employee e1, Employee e2)
        {
            return e1.Salary < e2.Salary;
        }
    }

    class BubbleSorter
    {
        static public void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (comparison(sortArray[i + 1], sortArray[i]))
                    {
                        T temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }

    public class Ch8 : ITest
    {
        private delegate string GetAString();

        public void Test()
        {

        }

        private static void ClosureTest2()
        {
            var values = new List<int>() {10, 20, 30};
            var funcs = new List<Func<int>>();

            foreach (var val in values)
            {
                funcs.Add(() => val);
            }

            foreach (var f in funcs)
            {
                Console.WriteLine((f()));
            }
        }

        private static void ClosureTest3()
        {
            var values = new List<int>() {10, 20, 30};
            var funcs = new List<Func<int>>();
            foreach (var val in values)
            {
                var v = val;
                funcs.Add(() => v);
            }
            foreach (var f in funcs)
            {
                Console.WriteLine((f()));
            }
        }

        private static void ClosureTest()
        {
            int someVal = 5;
            Func<int, int> f = x => x + someVal;

            someVal = 7;
            Console.WriteLine(f(3));
        }

        private static void LambdaExpressionParametersTest()
        {
            Func<string, string> oneParam = s => String.Format("change uppercase {0}", s.ToUpper());
            Console.WriteLine(oneParam("test"));

            Func<double, double, double> twoParams = (x, y) => x * y;
            Console.WriteLine(twoParams(3, 2));

            Func<double, double, double> twoParamsWithTypes = (x, y) => x * y;
            Console.WriteLine(twoParamsWithTypes(4, 2));
        }

        private static void LambdaExpressionTest()
        {
            string mid = ", middle part,";

            Func<string, string> lambda = param =>
                {
                    param += mid;
                    param += " and this was added to the string.";
                    return param;
                };

            Console.WriteLine(lambda("Start of string"));
        }

        private static void AnonymousMethodTest()
        {
            const string mid = ", middle part,";
            Func<string, string> anonDel = delegate(string param)
                {
                    param += mid;
                    param += " and this was added to the string.";
                    return param;
                };

            Console.WriteLine(anonDel("Start of string"));
        }

        private static void AvoidExceptionInMulticastDelegatesTest()
        {
            Action d1 = One;
            d1 += Two;

            Delegate[] delegates = d1.GetInvocationList();
            foreach (Action d in delegates)
            {
                try
                {
                    d();
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception caught");
                }
            }

            //try
            //{
            //    d1();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Exception caught");
            //}
        }

        private static void One()
        {
            Console.WriteLine("One");
            throw new Exception("Error in one");
        }

        private static void Two()
        {
            Console.WriteLine("Two");
        }

        private static void MulticastDelegateTest()
        {
            Action<double> operations = MathOperations.MultiplyByTwoAction;
            operations += MathOperations.SquareAction;

            operations += MathOperations.MultiplyByTwoAction;
            operations -= MathOperations.MultiplyByTwoAction;

            ProcessAndDisplayNumber(operations, 2.0);
            ProcessAndDisplayNumber(operations, 7.94);
            ProcessAndDisplayNumber(operations, 1.414);

            Console.WriteLine();
        }

        private static void FuncDelegateTest()
        {
            Employee[] employees =
                {
                    new Employee("Bugs Bunny", 20000),
                    new Employee("Elmer Fudd", 10000),
                    new Employee("Daffy Duck", 25000),
                    new Employee("Wile Coyote", 1000000.38m),
                    new Employee("Foghorn Leghorn", 23000),
                    new Employee("RoadRunner", 50000)
                };

            BubbleSorter.Sort(employees, Employee.CompareSalary);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        private static void FuncTest()
        {
            Func<double, double>[] operations = new Func<double, double>[]
                {
                    MathOperations.MultiplyByTwo,
                    MathOperations.Square
                };

            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Using operations[{0}]:", i);

                ProcessAndDisplayName(operations[i], 2.0);
                ProcessAndDisplayName(operations[i], 7.94);
                ProcessAndDisplayName(operations[i], 1.414);

                Console.WriteLine();
            }
        }

        static void ProcessAndDisplayNumber(Action<double> action, double value)
        {
            Console.WriteLine();
            Console.WriteLine("ProcessAndDisplayNumber called with value = {0}",
            value);
            action(value);
        }

        private static void ProcessAndDisplayName(Func<double, double> action, double value)
        {
            double result = action(value);

            Console.WriteLine("Value is {0}, result of operation is {1}", value, result);
        }

        private static void DelegateTest()
        {
            DoubleOp[] operations = new DoubleOp[]
                {
                    MathOperations.MultiplyByTwo,
                    MathOperations.Square
                };

            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine("Using operations[{0}]:", i);

                ProcessAndDisplayName(operations[i], 2.0);
                ProcessAndDisplayName(operations[i], 7.94);
                ProcessAndDisplayName(operations[i], 1.414);

                Console.WriteLine();
            }
        }

        private static void ProcessAndDisplayName(DoubleOp action, double value)
        {
            double result = action(value);

            Console.WriteLine("Value is {0}, result of operation is {1}", value, result);
        }

        private static void BasicDelegateTest()
        {
            int x = 40;
            GetAString firstStringMethod = x.ToString;
            Console.WriteLine("String is {0}", firstStringMethod());
            // With firstStringMethod initialized to x.ToString(),
            // the above statement is equivalent to saying
            // Console.WriteLine("String is {0}", x.ToString());
        }
    }
}


