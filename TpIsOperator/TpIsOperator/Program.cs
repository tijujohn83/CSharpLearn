using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace TpIsOperator
{
    struct Mutable
    {
        private int x;
        public int Mutate()
        {
            this.x = this.x + 1;
            return this.x;
        }
    }

    class Program
    {

        public readonly Mutable m = new Mutable();

        delegate int myDel(int intMyNum);

        static void Main(string[] args)
        {
            myDel myDelegate = myExp => myExp / 10;

            int intRes = myDelegate(110);

            Console.WriteLine("Output {0}", intRes);

            Console.ReadLine();



            //Create an expression tree type

            //This needs System.Linq.Expressions

            Expression<myDel> myExpDel = myExp => myExp / 10;

            /*
            Program t = new Program();
            System.Console.WriteLine(t.m.Mutate());
            System.Console.WriteLine(t.m.Mutate());
            System.Console.WriteLine(t.m.Mutate());

            
            var x = new object();

            var b = x is FooBar;

            var fooBar = (FooBar)x;*/


        }

        class FooBar
        {

        }

        /*
        static void M<T>(T x)
        {

            bool b = x is FooBar;

            FooBar foobar = (FooBar)x;

        }*/




    }
}
