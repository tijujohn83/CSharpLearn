using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //AppDomain.CurrentDomain.UnhandledException += (x, y) =>
            //{
            //    Console.WriteLine("Unhandled exception");
            //};
            //AppDomain.CurrentDomain.FirstChanceException += (x, y) =>
            //{
            //    Console.WriteLine("First Chance exception");
            //    throw new Exception();
            //};

            try
            {
                Console.WriteLine("In try");
                throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("In catch");                
            }

            Console.WriteLine("After try..catch");

            Console.ReadKey();
            


            /*
            AppDomain.CurrentDomain.UnhandledException += (x, y) =>
            {
                Console.WriteLine("Unhandled exception");
                throw new Exception();
            };
            AppDomain.CurrentDomain.FirstChanceException += (x, y) =>
            {
                Console.WriteLine("First Chance exception");
            };

            try
            {
                Console.WriteLine("In try");
                throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("In catch");
                throw;
            }
            Console.WriteLine("After try..catch");

            Console.ReadKey();
 
            */
 
        }
    }
}
