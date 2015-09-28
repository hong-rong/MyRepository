using System;
using System.Collections.Generic;

namespace CSharpProfessional
{
    #region generics

    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }

    public class Document : IDocument
    {
        public Document()
        { }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class DocumentManager<TDocument, T2> where TDocument : T2, IDocument, new()
    {
        //public void DisplayAllDocuments()
        //{
        //    foreach (TDocument doc in documentQueue)
        //    {
        //        Console.WriteLine(doc.Title);
        //    }
        //}
    }

    #endregion

    #region generic interface

    public interface IComparable<in T, out TU>
    {
        TU CompareTo(T other);
    }

    #endregion

    #region generic struct

    public struct MyStruct<T> where T : struct
    {

    }

    #endregion

    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString()
        {
            return String.Format("Width: {0}, Height: {1}", Width, Height);
        }
    }
    public class Rectangle : Shape
    { }

    #region generic method

    public interface IAccount
    {
        decimal Balance { get; }
        string Name { get; }
    }

    public class Account : IAccount
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public Account(string name, Decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }

    public class Algorithm
    {
        #region generic method

        public static decimal AccumulateSimple(IEnumerable<Account> source)
        {
            decimal sum = 0;
            foreach (Account a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }

        #endregion

        #region generic method with constrains

        public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source) where TAccount : IAccount
        {
            decimal sum = 0;
            foreach (TAccount a in source)
            {
                sum += a.Balance;
            }

            return sum;
        }

        #endregion

        #region generic methods with delegates

        public static T2 Accumulate<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action)
        {
            T2 sum = default(T2);
            foreach (T1 item in source)
            {
                sum = action(item, sum);
            }
            return sum;
        }

        #endregion
    }

    #endregion

    public class Ch5 : ITest
    {
        public void Test()
        {

        }

        private static void TestGenericMethod()
        {
            var accounts = new List<Account>()
                {
                    new Account("Christian", 1500),
                    new Account("Stephanie", 2200),
                    new Account("Angela", 1800),
                    new Account("Matthias", 2400)
                };

            //decimal amount = Algorithm.AccumulateSimple(accounts);
            decimal amount = Algorithm.Accumulate<Account, decimal>(accounts, (item, sum) => sum += item.Balance);
        }
    }
}
