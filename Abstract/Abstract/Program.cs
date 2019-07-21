using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDerivedC mC = new MyDerivedC();
            mC.MyMethod();
            Console.WriteLine("x = {0}, y = {1}", mC.GetX, mC.GetY);

            MyD md = new MyD();
            md.MyMethod();
            Console.WriteLine("x = {0}", md.GetX);

            MyExample myExample = new MyExample();
            myExample.Print();

        }
    }

    public class MyExample
    {
        private static int StaticVariable;
        public MyExample()
        {
            if (StaticVariable < 10)
            {
                StaticVariable = 20;
            }
            else
            {
                StaticVariable = 100;
            }
        }

        public void Print()
        {
            Console.WriteLine(StaticVariable);
        }
    }


    class Base
    {
        public virtual void Somemethod()
        {
            Console.WriteLine("Base: Somemethod");
        }
    }
    abstract class A : Base
    {
        //public abstract override void Somemethod() // cannot declare a body because its mark abstract
        //{
        //    Console.WriteLine("Derived: Somemethod");
        //}

        //public abstract virtual void Somemethod(); // cannot be marked virtual

        //public abstract void Somemethod(); // valid

        public abstract override void Somemethod();

        //public abstract sealed void Somemethod(); // cannot be marked both abstract and sealed; cannot be sealed because it is not an override

        //public sealed override void Somemethod() { } // valid; but the derived classes cannot override inherited members because they are sealed.

        //public sealed void Somemethod() { } //cannot be sealed because it is not an override



    }
    class Derived : Base
    {
        public override void Somemethod()
        {
            Console.WriteLine("Derived: Somemethod");
        }
    }

    class B : A
    {
        public override void Somemethod()
        {
            Console.WriteLine("B: Somemethod");

        }
    }


    abstract class MyBaseC   // Abstract class
    {
        protected int x = 100;
        protected int y = 150;
        public abstract void MyMethod();   // Abstract method

        public abstract int GetX   // Abstract property
        {
            get;
        }

        public abstract int GetY   // Abstract property
        {
            get;
        }
    }

    class MyDerivedC : MyBaseC
    {        
        public override void MyMethod()
        {
            x++;
            y++;
        }

        public override int GetX   // overriding property
        {
            get
            {
                return x + 10;
            }
        }

        public override int GetY   // overriding property
        {
            get
            {
                return y + 10;
            }
        }
    }

    class MyD : MyDerivedC
    {
        public override void MyMethod()
        {            
            x++;
            y++;
        }
        public override int GetX   // overriding property
        {
            get
            {
                return x + 10;
            }
        }

    }

    interface ABA
    {
        void TTT();
        //int A; // interface cannot contain fields
        int GetX
        {
            get;
            set;
        }
    }
}
