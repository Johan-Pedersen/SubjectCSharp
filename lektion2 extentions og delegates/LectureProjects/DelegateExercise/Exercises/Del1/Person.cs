using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExercise.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public delegate string Formatter(string first, string last);

        public void PrintFullNameLastNameFirst()
        {
            Console.WriteLine($"{LastName}, {FirstName}");
        }

        public void PrintFullNameAllCaps()
        {
            Console.WriteLine($"{LastName.ToUpper()}, {FirstName.ToUpper()}");
        }

        public void PrintFullNameLowerCase()
        {
            Console.WriteLine($"{LastName.ToLower()}, {FirstName.ToLower()}");
        }

        public void PrintShortName()
        {
            Console.WriteLine($"{FirstName.Substring(0, 1)}. {LastName}");
        }

        public void CallDelegate(Formatter f)
        {
            Console.WriteLine(f(FirstName,LastName));
        }

	public static List<Person> CreateListOfPeople()
        {
            return new List<Person>()
            {
                new Person() { FirstName = "Stephen", LastName = "King" },
		new Person() { FirstName = "George", LastName = "Martin" },
		new Person() { FirstName = "Ernest", LastName = "Hemingway" },
		new Person() { FirstName = "William", LastName = "Shakespeare" }
            };
        }
    }
}
