using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace opg1
{
    public class Person

    {
        private string name;
        public Person(string name, int age, int weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        //2
        public Person(string input)
        {
            bool success = false;

            int num;

            Name = input.Split(';')[0];
            success = int.TryParse(input.Split(';')[1], out num);
            if (!success)
            {
                Console.WriteLine("This went wrong");
            }
            success = int.TryParse(input.Split(';')[2], out num);

            if (!success)
            {
                Console.WriteLine("This went wrong");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age { get; set; }

        public int Weight
        {
            get;
            set;
        }
        public string Bob { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age} {Weight}";
        }

        //3
        public static List<Person> ReadCSVFile(string filename)
        {
            List<Person> persons = new List<Person>();
            using (var file = new StreamReader(filename))
            {
                while (!file.EndOfStream)
                {
                    persons.Add(new Person(file.ReadLine()));
                }
            }

                return persons;
        }
        static void Main(string[] args)
        {

            //1 og 2
            Person hej = new Person("hej", 42, 123);
            string bob = "Søren;32;13";
            Person hej2 = new Person(bob);

            Console.WriteLine(hej.ToString());
            Console.WriteLine(hej2.ToString());

            //3
            string filename = @"LectureProjects\data.csv"; 
            var people = Person.ReadCSVFile(filename); 
            Console.WriteLine("Number of people in data file : " + people.Count);


            //4
            

            Console.WriteLine("\n");
            people.Sort(new SortByWeight());
            people.ForEach(e => Console.WriteLine($" {e}"));
            
            Console.WriteLine("\n");
            people.Sort(new SortByName());
            people.ForEach(e => Console.WriteLine($" {e}"));

            Console.WriteLine("\n");
            people.Sort(new SortByAge());
            people.ForEach(e => Console.WriteLine($" {e}"));



            // 5
            /**
             * lambda:
             * -pros: nemt at skrive, behøver ikke skrive en hel klasse som implementerer compare
             * -cons: Kan være svært at 
             */

            int i = people.Count();

            List<Person> people1 = new List<Person>();

            people.ForEach(e =>
            {
                if (10 > i || people.Count()-10 < i)
                {
                    people1.Add(e);
                }
                i--;
            });
            people1.ForEach(e => Console.WriteLine($" people1 {e}"));

            Console.ReadKey();
        }
    }


    //4
    public class SortByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }

    public class SortByWeight : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }

    public class SortByName : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
