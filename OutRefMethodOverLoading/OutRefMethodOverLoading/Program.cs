using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutRefMethodOverLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass a = new MyClass();
            int aa, bb = 1;
            a.Method(bb);
            a.Method(out aa);
            Console.WriteLine("now aa =  {0}", aa);
        }
    }

    class MyClass
    {
        public void Method(int a)
        {
            Console.WriteLine("in plain method");
        }
        public void Method(out int a)
        {
            a = 9;
            Console.WriteLine("in out method");

        }
    }
}
