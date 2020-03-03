using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2 {

    public interface IRunnableDemo {
        void Run();
    }

    public class DelegatesDemo : IRunnableDemo {
        //
        // Delegates
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/delegate
        //

        public delegate int MyDelegate(string s);

        public int SomeMethod(string txt) {
            if (txt is null)
                return -1;
            return txt.Length;
        }

        public static string CallerOfDelegate(MyDelegate f) {
            return "CallerOfDelegate : " + f("CallerOfDelegate");
        }

        public void Run() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Running " + GetType().Name + "Demo");
            Console.WriteLine("----------------------------------------");

            // Fundamental idea!
            MyDelegate f1 = new MyDelegate(SomeMethod);
            MyDelegate f2 = SomeMethod;

            // With Anonymous methods
            MyDelegate f3 = delegate (string s) { return s.Length; };
            MyDelegate f4 = delegate (string s) { return (s is null) ? -1 : s.Length; }; // better but harder to read!

            // With Lambda expression
            MyDelegate f5 = (s) => { return s.Length; };
            MyDelegate f6 = (s) => { return (s is null) ? -1 : s.Length; };              // lambda expression

            // Using the delegates
            Console.WriteLine("From function f1 : " + f1.Invoke("hi there"));  // Invoke            
            Console.WriteLine("From function f2 : " + f2("hi there"));         // Not using Invoke
            Console.WriteLine("From function f3 : " + f3("hi there"));
            Console.WriteLine("From function f4 : " + f4("hi there"));
            Console.WriteLine("From function f5 : " + f5("hi there"));
            Console.WriteLine("From function f6 : " + f6("hi there"));
            Console.WriteLine(CallerOfDelegate(SomeMethod));
            Console.WriteLine(CallerOfDelegate(delegate (string s) { return s.Length; }));

            Console.WriteLine("----------------------------------------");
        }
    }

    public class AnonymousMethodDemo : IRunnableDemo {
        //
        // Anonymous Methods
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-methods
        //

        public delegate int MyDelegate(string s);

        public void Run() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Running " + GetType().Name + "Demo");
            Console.WriteLine("----------------------------------------");

            MyDelegate f1 = delegate (string s) { return s.Length; };
            MyDelegate f2 = delegate (string s) { return (s is null) ? -1 : s.Length; };

            int res1 = f1("Hello world");
            int res2 = f2("Hello world");

            Console.WriteLine("f returned " + res2);

            Console.WriteLine("----------------------------------------");
        }
    }

    public class LambdaDemo : IRunnableDemo {
        //
        // Lambdas
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
        //

        public delegate int MySimpleDelegate();
        public delegate int MyDelegate(string s);
        public delegate int MyDelegate2(string s, int i);

        public MyDelegate GetNewDelegate() {
            int local_variable = 666;
            return (string arg) => { return local_variable; };
        }

        public void Run() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Running " + GetType().Name + "Demo");
            Console.WriteLine("----------------------------------------");

            MySimpleDelegate f1 = () => 4;
            MySimpleDelegate f2 = () => { return 4; };                // Statement Lambda

            MyDelegate       f3 =         s  => { return s.Length; }; // Statement Lambda with arguments
            MyDelegate       f4 =        (s) => { return s.Length; }; 
            MyDelegate       f5 = (string s) => { return s.Length; };

            MyDelegate2      f6 = (string s, int i) => { return s.Length + i; };

            Console.WriteLine("From function f1 : " + f1());
            Console.WriteLine("From function f2 : " + f2());

            Console.WriteLine("From function f3 : " + f3("Hello world 1"));
            Console.WriteLine("From function f4 : " + f4("Hello world 22"));
            Console.WriteLine("From function f5 : " + f5("Hello world 333"));

            Console.WriteLine("From function f6 : " + f6("Hello world 444",5));

            MyDelegate f7 = GetNewDelegate(); // Google stackoverflow : What are Closures in .NET?
            Console.WriteLine("From function f7 : " + f7("Hello world 5555"));            

            Console.WriteLine("----------------------------------------");            
        }
    }

    public class EventDemo : IRunnableDemo {
        //
        // Events
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/event
        // 
        public delegate void MySimpleEvent(string s);

        public event MySimpleEvent EventListener;

        public void EventListener1(string s) {
            Console.WriteLine("EventListener1 took action on : " + s);
        }

        public void EventListener2(string s) {
            Console.WriteLine("EventListener2 took action on : " + s);
        }

        public void Notify(string s) {
            if (EventListener != null)
                EventListener(s);
        }

        public void Run() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Running " + GetType().Name + "Demo");
            Console.WriteLine("----------------------------------------");

            if (EventListener == null) {
                EventListener += EventListener1;
                EventListener += EventListener2;
            }

            Notify("Hello world (First)");

            EventListener += (s) => Console.WriteLine("LambdaListener took action on : " + s);
            EventListener -= EventListener1;            

            Notify("Hello world (Second)");

            Console.WriteLine("----------------------------------------");
        }
    }

    public static class MyExtensions {

        public static int NumberOfAs(this string str, bool invert=false) {
            int res = 0;
            foreach (char c in str) {
                if (c == 'a' || c == 'A')
                    res += 1;
            }
            if (invert)
                res = str.Length - res;
            return res;
        }

    }

    public class ExtensionDemo : IRunnableDemo {
        public void Run() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Running " + GetType().Name + "Demo");
            Console.WriteLine("----------------------------------------");

            string s = "Hi there A, how are you doing? Having a good day? Mine is a mess.";

            Console.WriteLine("Number of letters in sentence is " + s.Length);
            Console.WriteLine("Number of a's in sentence is " + s.NumberOfAs());
            Console.WriteLine("Number of other letters in sentence is " + s.NumberOfAs(true));

            Console.WriteLine("----------------------------------------");
        }
    }


    class Program {        
        
        static void Main(string[] args) {

            List<IRunnableDemo> demos = new List<IRunnableDemo>() {
                new DelegatesDemo(),
                new AnonymousMethodDemo(),
                new LambdaDemo(),
                new EventDemo(),
                new ExtensionDemo()
            };

            foreach (var demo in demos)
                demo.Run();

            Console.ReadKey();
        }
    }
}
