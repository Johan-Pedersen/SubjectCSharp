using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersLessThan50 = GetNumbersLessThan50(IntGeneratorService.GenerateListOfRandomInts(20));
            PrintListToConsole("Alle tal mindre end 50: ", numbersLessThan50);
            List<int> evenNumbers = GetEvenNumbers(IntGeneratorService.GenerateListOfRandomInts(20));
            PrintListToConsole("Alle lige tal: ", evenNumbers);
            List<int> squareNumbers = GetSquareNumbers(IntGeneratorService.GenerateListOfRandomInts(50));
            PrintListToConsole("Alle kvadrat tal: ", squareNumbers);
            Console.WriteLine("Done...");
            Console.Read();
        }

        private static List<int> GetNumbersLessThan50(List<int> listOfIntegers)
        {
            List<int> numbersLessThan50 = new List<int>();
            foreach (var number in listOfIntegers)
            {
                if (number < 50)
                {
                    numbersLessThan50.Add(number);
                }
            }
            return numbersLessThan50;
        }

        private static List<int> GetEvenNumbers(List<int> listOfIntegers)
        {
            List<int> evenNumbers = new List<int>();
            foreach (var number in listOfIntegers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;
        }

        private static List<int> GetSquareNumbers(List<int> listOfIntegers)
        {
            List<int> squareNumbers = new List<int>();
            foreach (var number in listOfIntegers)
            {
                double sqrt = Math.Sqrt(number);
                if (Math.Floor(sqrt) == sqrt)
                {
                    squareNumbers.Add(number);
                }
            }
            return squareNumbers;
        }

        private static void PrintListToConsole(string msg, List<int> listToPrint)
        {
            Console.Write(msg);
            Console.Write("[ ");
            foreach (int i in listToPrint)
            {
                Console.Write(i + " ,");
            }
            Console.WriteLine(" ]");
        }
    }
}
