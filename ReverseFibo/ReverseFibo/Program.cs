using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseFibo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = 8;
            int n2 = 5;

            int temp=1;
           // do
            while(temp!=0)
            {
                Console.WriteLine(n1);                
                temp = n1 - n2;
                n1 = n2;
                n2 = temp;

            }//while(temp!=0);




        }
    }
}
