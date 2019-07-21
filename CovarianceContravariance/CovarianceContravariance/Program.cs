using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CovarianceContravariance
{
    class Animal
    {
    }

    class Dog : Animal
    {
    }

    class Cat : Animal
    {
    }

    class Program
    {
        public delegate Small covarDel(Big objBig);

        static void Main(string[] args)
        {
            // Dynamic polymorphism - take child obj and point it to parent obj
            Animal objAnimal = new Dog(); // complies
            objAnimal = new Cat(); // complies

            // Animal can point to Dog

            // Can group of Animals point to group of Dogs??

            //IList<Animal> listAnimal = new List<Dog>(); //Cannot implicitly convert type 'System.Collections.Generic.List<CovarianceContravariance.Dog>' to 'System.Collections.Generic.IList<CovarianceContravariance.Animal>'. An explicit conversion exists (are you missing a cast?)

            IEnumerable<Animal> animals = new List<Dog>(); // complies and valid only in .net 4.0
            // IEnumerable interface is covariant enabled.

            // Covariance preserves assignment compatibility between parent and child relationship during dynamic polymorphism.

            #region SmallBig Example
            /*
            Small objSmall = new Small();
            Small objSmall1 = new Big();
            Small objSmall2 = new Bigger();
            Big objBig = new Bigger();
            //Big objBig1 = new Small(); //base class can hold a derived class but a derived class cannot hold a base class.
            //In other word, an instance can accept big even if it demands small, but it cannot accept small if it demands big.

            covarDel del = Method1;
            del += Method2;
            del += Method3;
            Small sm = del(new Big());
            */

            #endregion

            ///////////////

            // Assignment compatibility

            String stringObject = "A String Object";
            Object anObject = stringObject;
            //An Object of a derived class (stringObject) is being assigned to a variable of a base class (anObject).

            //The Array data type has supported Covariance since .NET 1.0. While working with arrays, you can successfully make the following assignment.

            object[] objArray = new String[10];

            //The code shown above assigns a string array to an object array variable. 
            //That is, a more derived class object's array (String []) is being assigned to the less derived class object array variable (object []). 
            //This is called covariance in array.

            //Array Covariance is not safe. Consider the following statement

            // objArray[0] = 5; // no compile error; runtime error: ArrayTypeMismatchException exception. It is due to the fact that the objArray variable actually holds a reference of a string Array.

            Func<object> delegateObj = GetString;
            Console.WriteLine(Convert.ToString(delegateObj()));
            //string strObj = delegateObj(); //Cannot implicitly convert type 'object' to 'string'. An explicit conversion exists (are you missing a cast?)

            // contravariant

            //In the following example a delegate specifies a parameter type as string. Still we can assign a method that has object as parameter.

            // delegate System.Action<in T>
            Action<string> del = SetObject;
            del("string");

            //delegate variant

            Func<string> del3 = GetString;
            Func<object> del4 = del3; // Compiler error here until C# 4.0.
            // Console.WriteLine(Convert.ToString(del3()));
            Console.WriteLine(Convert.ToString(del4()));


        }

        //class Sample<out T> { }  // Compiler error here. Invalid variance modifier. Only interface and delegate type parameters can be specified as variant.


        interface ICovariant<out R>
        {
            R GetSomething();
            // The following statement generates a compiler error.

            // void SetSomething(R sampleArg); //Invalid variance: The type parameter 'R' must be contravariantly valid on 'CovarianceContravariance.Program.ICovariant<R>.SetSomething(R)'.
            //'R' is covariant.
        }

        // If you have a contravariant generic delegate as a method parameter, you can use the type as a generic type parameter for the delegate.

        interface ICovariant1<out R>
        {
            void DoSomething(Action<R> callback);
        }

        // also possible to support both covariance and contravariance in the same interface, but for different type parameters, as shown in the following code example.

        interface IVariant<out R, in A>
        {
            R GetSomething();
            void SetSomething(A sampleArg);
            R GetSetSometings(A sampleArg);
        } 




        //------------------------------
        // Delegate Covariance
        static string GetString()
        {
            return "String Returned";
        }

        // Contravariance Delegate

        static void SetObject(object objParameter) { Console.WriteLine("in Set object"); }
        static void SetString(string strParameter) { Console.WriteLine("in Set string"); }



        //------------------------------


        static Big Method1(Big objBig)
        {
            Console.WriteLine("Method 1 ");
            return new Big();
        }

        static Small Method2(Big objBig)
        {
            Console.WriteLine("Method 2 ");
            return new Small();
        }

        static Small Method3(Small sml)
        {
            Console.WriteLine("Method 3 ");

            return new Small();
        }


    }

    class Small
    {
    }

    class Big : Small
    {
    }

    class Bigger : Big
    {
    }



}
