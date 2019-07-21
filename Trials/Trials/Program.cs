using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trials
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Event

            //EventTest e = new EventTest(5);
            //e.SetValue(7);
            //e.SetValue(11);

            #endregion


            /*
            #region Delegate

            //Testelegate tg = new Testelegate();

            NumberChanger nc1 = new NumberChanger(Testelegate.Add);
            NumberChanger nc2 = new NumberChanger(Testelegate.Multiply);

            nc1(3);

            Console.WriteLine("Delegate add called {0}", nc1(3));
            Console.WriteLine("elegate multiply called {0}", nc2(3));

            NumberChanger nc;

            nc = nc1;
            //nc += nc2;

            Console.WriteLine("elegate multiply called {0}", nc(5));

            #endregion
            */

            AAA aa = new AAA();
            aa.SomeMethod();
            Console.WriteLine("-------------------");

            BBB bb = new BBB();
            bb.SomeMethod();
            Console.WriteLine("-------------------");

            //aa = new BBB();
            //aa.SomeMethod();

            //bb = (BBB)aa; // no complie time error; but exception at runtime.
            //bb.SomeMethod();

            //BBB b2 = (BBB)aa; // no complie time error; but exception at runtime.
            //b2.SomeMethod();

            AAA a2 = bb;
            a2.SomeMethod();
            Console.WriteLine("-------------------");

            BBB b3 = (BBB)a2;
            b3.SomeMethod();





            /*
            // calling the overriden method
            DerivedClass objDC = new DerivedClass();
            objDC.Method1();
            // calling the baesd class method
            BaseClass objBC = (BaseClass)objDC;
            objDC.Method1();
            */

            /*
            CC c = new CC("a");
            ((AA)c).SomeMethod();
            */


            /*
            A a = new A("A");
            a.SomeMethod();

            B b = new B("B");
            b.SomeMethod();

            A aa = new B("B");
            aa.SomeMethod();/*

            /*
            B bb =  (B)(new A()); // error
            bb.SomeMethod();*/


            //a.name = "In main";
            //Temp t = new Temp();
            //t.Somefunc(a.name);
            //Console.WriteLine(a.name);
        }
    }

    //class SafeCasting
    //{
    //    class Animal
    //    {
    //        public void Eat() { Console.WriteLine("Eating."); }
    //        public override string ToString()
    //        {
    //            return "I am an animal.";
    //        }
    //    }
    //    class Mammal : Animal { }
    //    class Giraffe : Mammal { }

    //    class SuperNova { }

    //    static void Main()
    //    {
    //        SafeCasting app = new SafeCasting();

    //        // Use the is operator to verify the type.
    //        // before performing a cast.
    //        Giraffe g = new Giraffe();
    //        app.UseIsOperator(g);

    //        // Use the as operator and test for null
    //        // before referencing the variable.
    //        app.UseAsOperator(g);

    //        // Use the as operator to test
    //        // an incompatible type.
    //        SuperNova sn = new SuperNova();
    //        app.UseAsOperator(sn);

    //        // Use the as operator with a value type.
    //        // Note the implicit conversion to int? in 
    //        // the method body.
    //        int i = 5;
    //        app.UseAsWithNullable(i);


    //        double d = 9.78654;
    //        app.UseAsWithNullable(d);

    //        // Keep the console window open in debug mode.
    //        System.Console.WriteLine("Press any key to exit.");
    //        System.Console.ReadKey();
    //    }

    //    void UseIsOperator(Animal a)
    //    {
    //        if (a is Mammal)
    //        {
    //            Mammal m = (Mammal)a;
    //            m.Eat();
    //        }
    //    }

    //    void UseAsOperator(object o)
    //    {
    //        Mammal m = o as Mammal;
    //        if (m != null)
    //        {
    //            Console.WriteLine(m.ToString());
    //        }
    //        else
    //        {
    //            Console.WriteLine("{0} is not a Mammal", o.GetType().Name);
    //        }
    //    }

    //    void UseAsWithNullable(System.ValueType val)
    //    {
    //        int? j = val as int?;
    //        if (j != null)
    //        {
    //            Console.WriteLine(j);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Could not convert " + val.ToString());
    //        }
    //    }
    //}

    public class EventTest
    {
        private int value;
        public delegate void NumManipulationHandler();
        public event NumManipulationHandler ChangeNum;

        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("Event fired!");
            }
        }

        public EventTest(int n)
        {
            SetValue(n);
        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }


    }


    delegate int NumberChanger(int n);
    class Testelegate
    {
        public static int Add(int a)
        {
            return a + a;
        }

        public static int Multiply(int a)
        {
            return a * a;
        }        
    }


    // Base class
    public class BaseClass
    {
        public virtual void Method1()
        {
            Console.WriteLine("Base Class Method");
        }
    }
    // Derived class
    public class DerivedClass : BaseClass
    {
        public override void Method1()
        {
            Console.WriteLine("Derived Class Method");
        }
    }
    // Using base and derived class
    public class Sample
    {
        public void TestMethod()
        {
            // calling the overriden method
            DerivedClass objDC = new DerivedClass();
            objDC.Method1();
            // calling the baesd class method
            BaseClass objBC = (BaseClass)objDC;
            objDC.Method1();
        }
    }

    public interface IA
    {
        void SomeMethod();
    }

    public class AAA : IA
    {
        public AAA()
        {
            Console.WriteLine("In Constructor AAA");
        }

        public virtual void SomeMethod()
        {
            Console.WriteLine("In Method AAA");
        }
    }

    public class BBB : AAA, IA
    {
        public BBB()
        {
            Console.WriteLine("In Constructor BBB");
        }

        public override void SomeMethod()
        {
            Console.WriteLine("In Method BBB");
        }
    }
    public class AA
    {
        public AA()
        {
            Console.WriteLine("In Constructor AA");
        }

        public AA(string a) 
        {
            Console.WriteLine("In parameterized Constructor AA");
        }

        public virtual void SomeMethod()
        {
            Console.WriteLine("In Method AA");
        }
    }

    public class BB : AA
    {
        public BB()
        {
            Console.WriteLine("In Constructor BB");
        }

        public BB(string a)//: base(a)
        {
            Console.WriteLine("In parameterized Constructor BB");
        }

        public override void SomeMethod()
        {
            Console.WriteLine("In Method BB");
        }
    }

    public class CC : BB
    {
        public CC()
        {
            Console.WriteLine("In Constructor CC");
        }

        public CC(string a)//:base(a)
        {
            Console.WriteLine("In parameterized Constructor CC");
        }

        public override void SomeMethod()
        {
            Console.WriteLine("In Method CC");
        }
    }


    public abstract class absClass
    {
        public abstract void method1();
    }

    //public static class StaA : absClass//static class cannot derive from abstract class, it must dervive from object
    public static class StaA
    {
    }

    public static class StaB: Object
    {
    }

    public class Temp
    {
        public void Somefunc(string s)
        {
            s = "in temp";
        }
    }

    public class A
    {
        public A()
        {
            Console.WriteLine("In Constructor A");
        }

        public A(string a)
        {
            Console.WriteLine("In parameterized Constructor A");
        }

        public virtual void SomeMethod()
        {
            Console.WriteLine("In Method A");
        }

        public string name;
    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine("In Constructor B");
        }

        public B(string b)
            : base(b)
        {
            Console.WriteLine("In parameterized Constructor B");
        }

        public override void SomeMethod()
        {
            Console.WriteLine("In Method B");
        }
    }
}
