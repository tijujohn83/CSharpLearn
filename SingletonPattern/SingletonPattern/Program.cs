using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton s = new Singleton(); // error: inaccessible due to its protection level
            Console.WriteLine(Singleton.SingleInstance);
            Console.WriteLine(Singleton.A);

            Console.WriteLine(Singleton2.Instance);
        }
    }

    public class SingletonWithLock
    {
        static object _syncRoot;
        static SingletonWithLock _instance;

        SingletonWithLock()
        {

        }

        public static SingletonWithLock GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonWithLock();
                    }
                }
            }

            return _instance;
        }

    }

    public sealed class Singleton3
    {
        private static volatile Singleton3 _instance;
        private static object syncRoot = new Object();

        public static Singleton3 Instance
        {
            get 
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton3();
                        }
                    }
                }
                return _instance; 
            }
        }

        Singleton3()
        {

        }
    }

    public sealed class Singleton2
    {
        static readonly Singleton2 _instance = new Singleton2();

        public static Singleton2 Instance
        {
            get 
            { 
                return _instance; 
            }
        }

        Singleton2()
        {

        }

    }

    class Singleton
    {
        static Singleton _singleInstance;
        static int a;

        public static int A
        {
            get
            {
                //a = 4;
                return Singleton.a;
            }
        }

        public static Singleton SingleInstance
        {
            get
            {
                if (_singleInstance == null)
                {
                    _singleInstance = new Singleton();
                }
                a = 2;
                return _singleInstance;
            }
        }
        Singleton()
        {
        }

    }
}
