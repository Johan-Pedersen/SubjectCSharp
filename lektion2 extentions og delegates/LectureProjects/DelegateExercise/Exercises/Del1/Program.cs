using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExercise
{
    class Program
    {
        public static string PrintFullNameLastNameFirst(string first, string last)
        {
            return $"{last}, {first}";
        }

        public static string PrintFullNameAllCaps(string first, string last)
        {
            return $"{last.ToUpper()}, {first.ToUpper()}";
        }

        public static string PrintFullNameLowerCase(string first, string last)
        {
            return $"{last.ToLower()}, {first.ToLower()}";
        }

        public static string PrintShortName(string first, string last)
        {
            return $"{first.Substring(0, 1)}. {last}";
        }

        static void Main(string[] args)
        {
            var people = GenerateTestData.CreateListOfPeople();
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Hvordan vil du have udskrevet navnene?");
                Console.WriteLine("1: Efternavn efterfulgt af fornavn");
                Console.WriteLine("2: Efternavn efterfulgt af fornavn, store bogstaver");
                Console.WriteLine("3: Efternavn efterfulgt af fornavn, små bogstaver");
                Console.WriteLine("4: Kun forbogstav af fornavn efterfulgt af efternavn");
                Console.WriteLine("5: Call delegate");
                Console.WriteLine();
                Console.WriteLine("q: For at afslutte!");
                Console.Write("> ");
                var input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":  people.ForEach(p => p.PrintFullNameLastNameFirst()); break;
                    case "1s":  people.ForEach(p => p.CallDelegate((F, L) => PrintFullNameLastNameFirst(F, L))); break;

                    case "2":  people.ForEach(p => p.PrintFullNameAllCaps()); break;
                    case "2s": people.ForEach(p => p.CallDelegate((F, L) => PrintFullNameAllCaps(F, L))); break;

                    case "3":  people.ForEach(p => p.PrintFullNameLowerCase()); break;
                    case "3s": people.ForEach(p => p.CallDelegate((F, L) => PrintFullNameLowerCase(F, L))); break;

                    case "4":  people.ForEach(p => p.PrintShortName()); break;
                    case "4s": people.ForEach(p => p.CallDelegate((F, L) => PrintShortName(F, L))); break;

                    case "5": people.ForEach(p => p.CallDelegate((F,L) => $"{F.ToUpper()}, {L.ToUpper()}")); break;
                    
                    case "q": return;
                    default: Console.WriteLine("Ukendt valg, prøv igen");
                        break;
                }
            }

        }
    }


}
