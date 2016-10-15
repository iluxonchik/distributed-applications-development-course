using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /* Answers to questions:
     * 1. [Marked in code]
     * 2. In the order they're added
     * 3. NullReferrenceException
     * 4. Sure, why not?
     * 5. Well, nah, it gets replaced
     * 6. Sure thang (code example below)
     */
    delegate void MyDelegate(string s);

    class MyClass
    {
        public static void Hello(string s)
        {
            Console.WriteLine("  Hello, {0}!", s);
        }

        public static void Goodbye(string s)
        {
            Console.WriteLine("  Goodbye, {0}!", s);
        }

        public static void CallMe(MyDelegate del)
        {
            del.Invoke("Straight Outta CallMe!");
            // or even
            del("it's CallMe!");
        }

        public static void Main()
        {
            MyDelegate a, b, c, d, none;

            // Create the delegate object a that references
            // the method Hello:
            a = new MyDelegate(Hello); // [Creation]
            // Create the delegate object b that references
            // the method Goodbye:
            b = new MyDelegate(Goodbye);  // [Creation]
            // The two delegates, a and b, are composed to form c:
            c = a + b; // [Assignment] 
            // Remove a from the composed delegate, leaving d,
            // which calls only the method Goodbye:
            d = c - a; // [Removal] 

            Console.WriteLine("Invoking delegate a:");
            a("A");
            Console.WriteLine("Invoking delegate b:");
            b("B");
            Console.WriteLine("Invoking delegate c:");
            c("C");
            Console.WriteLine("Invoking delegate d:");
            d("D");
            Console.WriteLine("Passing a delegate as an argument:");
            CallMe(a);

            Console.WriteLine("Calling a null delegate:");
            none = null;
            try
            {
                none("Too Pythonish?");
            }
            catch (NullReferenceException e)
            {

                Console.WriteLine("  A NullReferenceExeption was caught, WHAT A SAVE!");
            }
        }
    }
}
