using System;
using System.Collections.Generic;
using System.Collections;

namespace CSharpProfessional
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            int result = string.Compare(this.LastName, other.LastName);
            if (result == 0)
            {
                result = string.Compare(this.FirstName, other.FirstName);
            }
            return result;
        }
    }

    public enum PersonCompareType
    {
        FirstName,
        LastName
    }

    public class PersonComparer : IComparer<Person>
    {
        private PersonCompareType compareType;

        public PersonComparer(PersonCompareType compareType)
        {
            this.compareType = compareType;
        }

        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            switch (compareType)
            {
                case PersonCompareType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case PersonCompareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                default:
                    throw new ArgumentException("unexpected compare type");
            }
        }
    }

    public class HelloCollection
    {
        public IEnumerator WhateverName()
        {
            yield return "hello";
            yield return "world";
        }

        //public IEnumerator GetEnumerator()
        //{
        //    yield return "hello";
        //    yield return "world";
        //}

        public IEnumerator<string> GetEnumerator()
        {
            yield return "hello";
            yield return "world";
        }

        public IEnumerable<string> AnyName()
        {
            yield return "111";
            yield return "222";
        }
    }

    //public class HelloCollection
    //{
    //    public IEnumerator GetEnumerator()
    //    {
    //        return new Enumerator(0);
    //    }
    //    public class Enumerator : IEnumerator<string>, IEnumerator, IDisposable
    //    {
    //        private int state;
    //        private string current;
    //        public Enumerator(int state)
    //        {
    //            this.state = state;
    //        }
    //        bool System.Collections.IEnumerator.MoveNext()
    //        {
    //            switch (state)
    //            {
    //                case 0:
    //                    current = "Hello";
    //                    state = 1;
    //                    return true;
    //                case 1:
    //                    current = "World";
    //                    state = 2;
    //                    return true;
    //                case 2:
    //                    break;
    //            }
    //            return false;
    //        }
    //        void System.Collections.IEnumerator.Reset()
    //        {
    //            throw new NotSupportedException();
    //        }
    //        string System.Collections.Generic.IEnumerator<string>.Current
    //        {
    //            get
    //            {
    //                return current;
    //            }
    //        }
    //        object System.Collections.IEnumerator.Current
    //        {
    //            get
    //            {
    //                return current;
    //            }
    //        }
    //        void IDisposable.Dispose()
    //        {
    //        }
    //    }
    //}

    public class MusicTitles
    {
        string[] names = { "Tubular Bells", "Hergest Ridge", "Ommadawn", "Platinum" };

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < 4; i++)
            {
                yield return names[i];
            }
        }
        public IEnumerable<string> Reverse()
        {
            for (int i = 3; i >= 0; i--)
            {
                yield return names[i];
            }
        }
        public IEnumerable<string> Subset(int index, int length)
        {
            for (int i = index; i < index + length; i++)
            {
                yield return names[i];
            }
        }
    }

    public class GameMoves
    {
        private IEnumerator cross;
        private IEnumerator circle;

        public GameMoves()
        {
            cross = Cross();
            circle = Circle();
        }

        private int move = 0;
        const int MaxMoves = 9;

        public IEnumerator Cross()
        {
            while (true)
            {
                Console.WriteLine("Cross, move {0}", move);
                if (++move >= MaxMoves)
                    yield break;

                yield return circle;
            }
        }

        public IEnumerator Circle()
        {
            while (true)
            {
                Console.WriteLine("Circle, move {0}", move);
                if (++move >= MaxMoves)
                    yield break;

                yield return cross;
            }
        }
    }

    public class Ch6 : ITest
    {
        public void Test()
        {
            IStructuralEquatable se;
            IStructuralComparable sc;
        }

        private static void CreateTupleTest()
        {
            var tuple = Tuple.Create<string, string, string, int, int, int, double, Tuple<int, int>>
                ("Stephanie", "Alina", "Nagel", 2009, 6, 2, 1.37, Tuple.Create<int, int>(52, 3490));
        }

        private static void TestTuple()
        {
            Tuple<int, int> result = Divide(5, 2);
            Console.WriteLine("result of division: {0}, reminder: {1}",
                              result.Item1, result.Item2);
        }

        public static Tuple<int, int> Divide(int dividend, int divisor)
        {
            int result = dividend / divisor;
            int reminder = dividend % divisor;

            return Tuple.Create<int, int>(result, reminder);
        }

        private static void ReturningEnumeratorsTest()
        {
            var game = new GameMoves();
            IEnumerator enumerator = game.Cross();
            while (enumerator.MoveNext())
            {
                enumerator = enumerator.Current as IEnumerator;
            }
        }

        private static void MultiWaysIteratorCollections()
        {
            var titles = new MusicTitles();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
            Console.WriteLine("reverse");
            foreach (var title in titles.Reverse())
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
            Console.WriteLine("subset");
        }

        private static void EnumeratorTest()
        {
            var helloCollection = new HelloCollection();
            foreach (var s in helloCollection)
            {
                Console.WriteLine(s);
            }

            foreach (var s in helloCollection.AnyName())
            {
                Console.WriteLine(s);
            }

            //foreach (var s in helloCollection.WhateverName())
            //{
            //    Console.WriteLine(s);
            //}
        }

        private static void ForEachTest()
        {
            Person[] persons = CreatePersons();

            //foreach (Person p in persons)
            //{
            //    Console.WriteLine(p);
            //}

            IEnumerator enumerator = persons.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        private static void TestArraySegment()
        {
            int[] ar1 = { 1, 4, 5, 11, 13, 18 };
            int[] ar2 = { 3, 4, 5, 18, 21, 27, 33 };

            var segment = new ArraySegment<int>[2]
            {
                new ArraySegment<int>(ar1,0,3),
                new ArraySegment<int>(ar2,3,3)
            };

            var sum = SumOfSegments(segment);

            Console.WriteLine(sum);
        }

        static int SumOfSegments(ArraySegment<int>[] segments)
        {
            int sum = 0;
            foreach (var segment in segments)
            {
                for (int i = segment.Offset; i < segment.Offset +
                segment.Count; i++)
                {
                    sum += segment.Array[i];
                }
            }
            return sum;
        }

        private void TestArrayCovariant()
        {
            Person[] persons = CreatePersons();

            DisplayArray(persons);
        }

        private static Person[] CreatePersons()
        {
            Person[] persons = 
            {
                new Person { FirstName="Damon", LastName="Hill" },
                new Person { FirstName="Niki", LastName="Lauda" },
                new Person { FirstName="Ayrton", LastName="Senna" },
                new Person { FirstName="Graham", LastName="Hill" },
            };
            return persons;
        }

        static void DisplayArray(object[] data)
        {

        }

        private static void TestComparer()
        {
            Person[] persons = CreatePersons();

            Array.Sort(persons, new PersonComparer(PersonCompareType.FirstName));
            foreach (var p in persons)
            {
                Console.WriteLine(p);
            }
        }

        private static void ComparableTest()
        {
            Person[] persons = CreatePersons();

            Array.Sort(persons);
            foreach (var p in persons)
            {
                Console.WriteLine(p);
            }
        }

        private static void CreateArrayTest()
        {
            Array array = Array.CreateInstance(typeof(int), 5);
            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(i * 10, i);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array.GetValue(i));
            }

            int[] array2 = (int[])array;
        }

        private static void TestJaggedArray()
        {
            int[][] jagged = new int[3][];
        }
    }
}
