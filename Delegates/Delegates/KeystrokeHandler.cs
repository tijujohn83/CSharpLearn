using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public delegate void Keypressdelegate(char key);
    public delegate void Quitelegate();

    public class KeystrokeHandler
    {
        //public Keypressdelegate OnKey;
        //public Quitelegate OnQuitting;

        public event Keypressdelegate OnKey;  
        public event Quitelegate OnQuitting;

        public void Run()
        {
            Console.WriteLine("Keystroke handler is running. Press q to quit.");
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;

                if (key == 'q')
                {
                    if (OnQuitting != null)
                        OnQuitting();
                    break;
                }

                if (OnKey != null)
                {
                    OnKey(key);
                }
            }
        }
    }
}
