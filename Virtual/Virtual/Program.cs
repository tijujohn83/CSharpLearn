using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual
{
    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            Base b = d;
            
            b.someFunc();
            d.someFunc();

            Console.WriteLine(d.ToString());
            Console.WriteLine(b.ToString());
            
            Func<int, int> f1 = (int x) => x + 1;
            Func<int, int> f2 = (int x) => x + 1;
            bool bo = object.ReferenceEquals(f1, f2);// f1 == f2; //both are false
            Console.WriteLine(bo);
            
            
        }

        public void sum(int a)
        {

        }

        public int sum(int a, int b)
        {
            return 0;
        }
    }
     
    abstract class Base
    {
        public virtual void someFunc()
        {
            Console.WriteLine("Base");
        }

        public abstract override string ToString();
    }

    class Derived : Base
    {
        public int someFunc(int a)
        {
            Console.WriteLine("int derived");
            return 0;
        }

        public override void someFunc()
        {
            Console.WriteLine("void derived");
        }

        public override string ToString()
        {
            return "Doggy";
        }
    }
}
