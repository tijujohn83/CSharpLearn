using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTrials
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Technology";
            Console.WriteLine("IS string null or empty: {0}", String.IsNullOrEmpty(s));
            bool contains = s.Contains("Tech");
            Console.WriteLine("String contains tech? {0}", contains );

            int? t;
            int? a = 1;
            //a = null;
            Console.WriteLine("Value of a is {0}", a);

            int b = a ?? -1; // if a = null then b= -1, else b will have same value as of a
            Console.WriteLine("Value of b is {0}", b);

            int? e = 11;
            int? f = 19;

            e = null;
            //f = null;
            // g = e or f, unless e and f are both null, in which case g = -1.
            int g = e ?? f ?? -1; // if e n f both are null g= -1, else g will have value of e or f, who so ever is not null, if both are not null, g=e will get its precedence.

            Console.WriteLine("e = {0}, f= {1}, g={2} ", e, f, g);

        }
    }
}
