using System;

namespace CSharpProfessional
{
    #region partial

    public partial interface IA
    {
        void Method1();
    }

    public partial class A : IA
    {
        public void Method1()
        {
            throw new NotImplementedException();
        }

        public void Method2()
        {
            throw new NotImplementedException();
        }
    }

    public partial class A : IA
    {
        public void M1()
        { }
    }

    public partial interface IA
    {
        void Method2();
    }

    public partial class MyClass
    {
        private int count = 0;
        partial void NastyMethod();
    }

    public partial class MyClass
    {
        partial void NastyMethod()
        {
            Console.WriteLine(count);
        }
    }

    public partial interface IA
    { }

    public partial interface IA
    { }

    #endregion

    #region struct

    struct StructTest : IDisposable
    {
        public int aa;
        public int bb;

        //public StructTest()
        //{ }

        //public StructTest(int a)
        //{
        //    aa = a;
        //}

        public StructTest(int a, int b)
        {
            aa = a;
            bb = b;
        }
        public override string ToString()
        {
            return base.ToString();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region extension method

    public static class stringExtension
    {
        public static void Test(this string s, int a)
        {
            Console.WriteLine("Test extension {0}", a);
        }
    }

    #endregion

    public class Ch3 : ITest
    {
        private string _name;

        public string Name
        {
            private get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get;
            private set;
        }

        public void Test()
        {
        
        }

        private static void ExtensionMethod()
        {
            string s = "a";
            s.Test(2);
        }

        private static void WeakReference()
        {
            WeakReference ch2Ref = new WeakReference(new Ch2());
            Ch2 ch2;
            if (ch2Ref.IsAlive)
            {
                Console.WriteLine("ch2Ref still alive");
            }
            else
            {
                Console.WriteLine("Ref is not avaliable");
            }

            // GC.Collect();
            if (ch2Ref.IsAlive)
            {
                ch2 = ch2Ref.Target as Ch2;
            }
            else
            {
                Console.WriteLine("Ref is not available");
            }
        }

        private static void Struct()
        {
            StructTest st; //= new StructTest();
            st.aa = 2;

            int a = st.aa;
            //int b = st.bb;
        }

        private static void AnonymousType()
        {
            var captain = new { FirstName = "James", MiddleName = "T", LastName = "Kirk" };
            var doctor = new { FirstName = "Leonard", MiddleName = "", LastName = "MocCoy" };
            captain = doctor;

            var person = new { captain.FirstName, captain.MiddleName, captain.LastName };
        }
    }
}
