using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace StaticTrials
{
    class Program
    {
        static void Main(string[] args)
        {
            //A a = new A();
            /*
            Class1 c = new Class1();
            A.someMEthod();
            Console.WriteLine(ConfigurationManager.AppSettings["Myname"].ToString());
            Console.Read();*/

            /*

            TP t = new TP(2, "hello");           
            TP.someStaticMethod();
            t.someMethod();
            
            string str = "Hello World!";
            Console.WriteLine(String.Compare(str, "Hello World?").GetType());

            
            String s1 = "Kicit";
            Console.WriteLine(s1.IndexOf('c') + " ");
            Console.WriteLine(s1.Length);

            s1 = "hello";
            string s2 = "hello";
            int i = s1.CompareTo(s2);
            if (s1 == s2)
            {
                Console.WriteLine("same");
            }

            */

            
            //Derived1 d = new Derived1();
            //d.fun();

            
            Derived2 d2 = new Derived2();
            d2.fun(); 
            
        }
    }


    class Baseclass
    {
        public void fun()
        {
            Console.WriteLine("Base class" + " ");
        }
    }
    class Derived1 : Baseclass
    {
        public Derived1()
        {
            fun();
        }
        //public new void fun()
        new void fun()
        {
            Console.WriteLine("Derived1 class" + " ");
        }
    }
    class Derived2 : Derived1
    {
        public Derived2()
        {
            fun();
        }
        //public new void fun()
        new void fun()
        {
            Console.WriteLine("Derived2 class" + " ");
        }
    }

    /*
    class Baseclass
    {
        private int i;
        protected int j;
        public int k;
    }
    class Derived : Baseclass
    {
        private int x;
        protected int y;
        public int z;
    } */

    class TP 
    {
        public int A;
        string str = "Yogi";
        static int B;

        public TP()
        {

        }

        static TP()
        {
            B = 7;
        }

        public TP(int a, string s)
        {
            A = a;
            str = s;
        }

        public static void someStaticMethod()
        {
            Console.WriteLine("Some Static Method");
            //Console.WriteLine(A); // error
            Console.WriteLine(B);        
        }

        public void someMethod()
        {
            Console.WriteLine("Some instance method");
            A = 11;
            B = 22;
            Console.WriteLine(A);
            Console.WriteLine(B);

        }
    }

    interface IA
    {
        void someM();
    }
    //static class A : IA // Error: static classes cannot implement interfaces
    static class A 
    {
        //int a;
        //int b;

        static A()
        {
        }

        public static void someMEthod()
        {
            Console.WriteLine("Static method");
        }        
    }
}
