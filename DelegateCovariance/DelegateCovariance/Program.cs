using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateCovariance
{
    class Program
    {
        static string GetString() 
        {
            Console.WriteLine("in GetString");
            return "returned from GetString"; 
        }

        static void SetObject(object objPara) 
        { 
            Console.WriteLine("in setObject"); 
            Console.WriteLine(objPara.ToString()); 
        }
        static void SetString(string strPara) { }

        static void Main(string[] args)
        {
            Func<object> delegateObject = GetString;
            //string strObject = delegateObject(); // cannot implicitly convert object to string.
            Console.WriteLine(delegateObject());
            //delegateObject();

            Func<string> delegateString = GetString;
            Func<Object> delObj = delegateString;


            Action<string> delString = SetObject;
            object a = "object string";
            SetObject(a);
            //Console.WriteLine();

        }
    }
}
