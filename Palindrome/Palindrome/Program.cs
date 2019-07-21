using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = 12321;
            string strNum = num.ToString();
            char[] numChar = strNum.ToCharArray();
            Array.Reverse(numChar);

            string revNum = new string(numChar);

            if (revNum == strNum)
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not palindrome");
            }
        }
    }
}
