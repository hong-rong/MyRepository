using System;

namespace CSharpProfessional
{
    #region hide method

    public class BaseClass
    {
        public int HideMethod()
        {
            Console.WriteLine("In BaseClass, HideMethod()");

            return 0;
        }

        public virtual void Foo()
        {
            Console.WriteLine("In BaseClass, Foo()");
        }

        public void Both()
        {
            Console.WriteLine("In BaseClass, Both()");
        }
    }

    public class DerivedClass : BaseClass
    {
        public int X = 1;

        public new int HideMethod()
        {
            Console.WriteLine("In DerivedClass, HideMethod()");

            return 0;
        }

        public override void Foo()
        {
            Console.WriteLine("In DerivedClass, Foo()");
        }

        public new virtual void Both()
        {
            Console.WriteLine("In DerivedClass, Both()");
        }
    }

    public class FurtherDerivedClass : DerivedClass
    {
        //public override void Both()
        //{
        //    Console.WriteLine("In FurtherDerivedClass, override Both()");
        //}

        public new void Both()
        {
            Console.WriteLine("In FurtherDerivedClass, new Both()");
        }
    }

    #endregion

    public class Ch4 : ITest
    {
        public void Test()
        {
            MethodHiding();

            //MethodOverriding();
        }

        private static void MethodHiding()
        {
            BaseClass bc = new BaseClass();
            bc.HideMethod();

            DerivedClass bc2 = new DerivedClass();
            bc2.HideMethod();

            BaseClass bc3 = new DerivedClass();
            bc3.HideMethod();
            Console.WriteLine(((DerivedClass)bc3).X);
        }

        private static void MethodOverriding()
        {
            BaseClass bc = new BaseClass();
            bc.Foo();

            DerivedClass bc2 = new DerivedClass();
            bc2.Foo();

            BaseClass bc3 = new DerivedClass();
            bc3.Foo();

            bc = new DerivedClass();
            bc.Foo();
        }
    }
}
