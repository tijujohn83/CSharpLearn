using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {

            Car c = new Car(3, 2);
            //Car c = new Car();


        //    QuitTracker bob = new QuitTracker{Name="bob"};
        //    QuitTracker sandy = new QuitTracker{Name="sandy"};



        //    KeystrokeHandler keystrokeHandler = new KeystrokeHandler();
        //    keystrokeHandler.OnKey = GotKey;
        //    //keystrokeHandler.OnQuitting = OnQuit;
        //    keystrokeHandler.OnQuitting=bob.QuitHandler;
        //    keystrokeHandler.OnQuitting+=sandy.QuitHandler;
        //    keystrokeHandler.OnQuitting = OnQuit;
        //    keystrokeHandler.Run();
        }

        static void GotKey(char key)
        {
            Console.WriteLine("Got key: {0}", key);
        }

        static void OnQuit()
        {
            Console.WriteLine("Quitting...  ");
        }

    }

    //public class QuitTracker
    //{
    //    public string Name { get; set;}
    //    public void QuitHandler
    //    {
    //        Console.WriteLine("My name is {0} n i js got a  quit notification.", Name);
    //    }
    //}
}
