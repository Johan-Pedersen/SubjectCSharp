using DelegateExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises {
    class Program {

        public static string FirstName { get; set; }
        public static string LastName { get; set; }

        //a
        public delegate string DELPrintNameAll();


        public static void PrintNameAll(DELPrintNameAll func)
        {
            Console.WriteLine(func());
        }

        public static string LastNameFirst()
        {
            return $"{LastName}, {FirstName}";
        }

        static void Main(string[] args)
        {
            LastName = "Søren";
            FirstName = "Bo";

            DELPrintNameAll DPN = LastNameFirst;

            Console.WriteLine("1 LastName First:");
            PrintNameAll(DPN);

            Console.WriteLine();

            Console.WriteLine("2 ALL CAPS:");
            PrintNameAll(() => $"{FirstName.ToUpper()},{LastName.ToUpper()} ");

            Console.WriteLine();

            Console.WriteLine("3 lowercase:");
            PrintNameAll(() => $" {FirstName.ToLower()},{LastName.ToLower()}");

            Console.WriteLine();

            Console.WriteLine("4 short name:");
            PrintNameAll(() => $"{FirstName[0]}.{FirstName[1]}, {LastName}");

            Console.ReadKey();
        }
    }
}
