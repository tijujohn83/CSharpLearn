using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrivateVsStaticConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            //A obj = new A(5);

            BB b = new BB();
            b.SomeMethod();
            Console.WriteLine("-----");
            AA a = new AA();
            a.SomeMethod();
        }
    }

    class A
    {
        A()
        {
            Console.WriteLine("in private constructor");
        }
        static A()
        {
            Console.WriteLine("in static constructor");
        }
        public A(int a)
        {
            new A();
            Console.WriteLine("in parameterized constructor");

        }

        //public void SomeMethod()
        //{
        //    new A();
        //}

    }

    public static class AStatic
    {
        //public static AStatic() { } //access modifiers are not allowed on static constructors
        //static AStatic(int a) { } // a static constructor must be parameterless
        static AStatic()
        { Console.WriteLine("Static constructor"); }
        static public void somemethod()
                { Console.WriteLine("Static constructor"); }

    }

    public class AA
    {
        static AA() { Console.WriteLine("AA static constructor"); }
        public AA() { Console.WriteLine("AA public constructor"); }
        public virtual void SomeMethod()
        {
            Console.WriteLine("AA public mthod");
        }
    }

    public class BB : AA
    {
        static BB() { Console.WriteLine("BB static constructor"); }
        public BB() { Console.WriteLine("BB public constructor"); }
        public override void SomeMethod()
        {
            Console.WriteLine("BB public mthod");
        }
    }

}
