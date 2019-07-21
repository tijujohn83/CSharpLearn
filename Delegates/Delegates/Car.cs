using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public class Car
    {
        static int s_count;

        static Car()
        {
            s_count = 0;
        }

        public Car()
        {

        }

        public Car(int a, int b)
        {       
            string s1 = "abc";
            string s2 = "abc";

            bool result = s1 == s2;

            result = s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase);

        }
    }
}
