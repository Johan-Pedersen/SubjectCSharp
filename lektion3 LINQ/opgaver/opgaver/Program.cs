using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace opgaver
{
    static class Lektion3
    {
        public static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            try {

                using (var file = new StreamReader("data1.csv"))
                {
                    string line = file.ReadLine();
                    while (!file.EndOfStream)
                    {

                        people.Add(new Person(line));

                        line = file.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not read file");
                Console.WriteLine(e.Message);
            }
            return people;
        }
        public static List<Person> GetPeople2()
        {
            List<Person> people = new List<Person>();
            try
            {

                using (var file = new StreamReader("data2.csv"))
                {
                    string line = file.ReadLine();
                    while (!file.EndOfStream)
                    {

                        people.Add(new Person(line));

                        line = file.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not read file");
                Console.WriteLine(e.Message);
            }
            return people;
        }



        /**
       * Ex 3
       */
        public static void SetAccepted(this List<Person> inputPeople, Predicate<Person> predicate)
        {
            inputPeople.ForEach(e =>
            {
                if (predicate(e))
                {
                    e.Accepted = true;
                }
            });
        }

        //9a:
        public static int OwnCompare9a(Person x, Person y)
        {
            IEnumerable<int> peopleAge = from p in GetPeople()
                     select p.Age;

            double avgAge = peopleAge.Average();

            return (x.Age / avgAge).CompareTo(y.Age / avgAge);


        }

        //9b:
        public static int OwnCompare9b(Person x, Person y)
        {
            return Math.Sqrt(Math.Pow(x.Weight, 2) + Math.Pow(x.Age, 2)).CompareTo(
               Math.Sqrt(Math.Pow(y.Weight, 2) + Math.Pow(y.Age, 2)));
        }

        //11:
        public static void Reset(this List<Person> people)
        {
            people.ForEach(e => e.Accepted = false);
        }

        static void Main(string[] args)
        {

            List<Person> people = GetPeople();

            people.ForEach(e => Console.WriteLine(e.ToString()));
            /**
             * exercise 1
             */
            //a:
            Console.WriteLine("\n1.a:");
            List<Person> belowScore = people.FindAll(e => e.Score <=2);
            belowScore.ForEach(e => Console.WriteLine(e.ToString()));
            

            //b:
            Console.WriteLine("\n1.b:");
            List<Person> EvenScore = people.FindAll(e => e.Score % 2 == 0);
            EvenScore.ForEach(e => Console.WriteLine(e.ToString()));
            

            //c:
            Console.WriteLine("\n1.c:");
            List<Person> WeightAndScore = people.FindAll(e => e.Score % 2 == 0 && e.Weight> 60);
            WeightAndScore.ForEach(e => Console.WriteLine(e.ToString()));
            
            //d:

            Console.WriteLine("\n1.d:");
            List<Person> weightDiv3 = people.FindAll(e => e.Score % 3 == 0);
            weightDiv3.ForEach(e => Console.WriteLine(e.ToString()));



            /** 
             * exercise 2
             */

            Console.WriteLine("\n2.a:");
            Console.WriteLine($"{people.FindIndex(e => e.Score == 3)}");
            
            
            Console.WriteLine("\n2.b:");
            Console.WriteLine($"{people.FindIndex(e => e.Score == 3 && e.Age<=10)}");
            
            
            Console.WriteLine("\n2.c:");
            Console.WriteLine($"{people.FindAll(e => e.Score == 3 && e.Age <= 10).Count}");
            
            Console.WriteLine("\n2.d:");
            Console.WriteLine($"{people.FindIndex(e => e.Score == 3 && e.Age < 8)}");

            Console.WriteLine();

            //2e:
            //If the predicate has no match, then -1 is returned.


            //3:
            
            Console.WriteLine("\n3:");
            //people.SetAccepted(predicateAsMethod);
            people.SetAccepted(p =>p.Score >= 6 && p.Age <= 40);
            people.ForEach(e => Console.WriteLine($"{e}"));

            //4
            Console.WriteLine("\n4:");
            //Ascending
            Console.WriteLine("\nAscending:");
            ScoreAgeSortAscending comparerAscending = new ScoreAgeSortAscending();
            people.Sort(comparerAscending);
            people.ForEach(e => Console.WriteLine($"{e}"));

            Console.WriteLine("\n******** Decending ********");
            //Decending
            ScoreAgeSortDecending comparerDecending = new ScoreAgeSortDecending();
            people.Sort(comparerDecending);
            people.ForEach(e => Console.WriteLine($"{e}"));



            //5
            
            EventClass.StringToInt del = EventClass.CountChars;

            //6
            Console.WriteLine("\n6:");
            Console.WriteLine(del("hejMedDig1"));
            Console.WriteLine(del("hejMedDig12"));
            Console.WriteLine(del("hejMedDig123"));

            //7

            Console.WriteLine("\n7:");
            Console.WriteLine(EventClass.DelegateUser(del, "hejMedDig1"));


            //8
            Console.WriteLine("\n8 Ascending:");
            //Ascending
            var s = from p in people
                    orderby p.Score, p.Age
                    select p;

            s.ToList().ForEach(e => Console.WriteLine(e.ToString()));

            Console.WriteLine("\n8 Decending:");
            //Decending
            var s2 = from p in people
                    orderby p.Score descending, p.Age descending
                    select p;

            s2.ToList().ForEach(e => Console.WriteLine(e.ToString()));


            //9a
            
            Console.WriteLine("\n9a");
            int avgAge = 0;
            people.Sort(OwnCompare9a);
            people.ForEach(e =>
            {
                Console.WriteLine($"{e}");
                avgAge = e.Age;
            }
            );

            Console.WriteLine($"Average age {avgAge}");

            //b
            Console.WriteLine("\n9b");
            people.Sort(OwnCompare9b);
            people.ForEach(e => Console.WriteLine(e));

            //10

            //10.a

            Console.WriteLine("\n10a");
            int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };

            IEnumerable<int> a = from i in numbers
                                 orderby i
                                 where i >= 10
                                 select i;
            a.ToList().ForEach(e => Console.WriteLine(e));



            //10.b
            Console.WriteLine("\n10b");

            IEnumerable<int> b = from i in numbers
                                 orderby i descending
                                 where i >= 10
                                 select i;

            b.ToList().ForEach(e => Console.WriteLine(e));

            //10.c
            Console.WriteLine("\n10c");
            IEnumerable<string> c = from i in numbers 
                                    where i>= 10
                                    select i + " stuff" ;

            c.ToList().ForEach(e => Console.WriteLine(e));


            //10.d
            Console.WriteLine("\n10d");
            IEnumerable<string> d = from i in numbers
                                    where i >= 10
                                    select i%2 == 0? i + "even": i+"uneven";

            d.ToList().ForEach(e => Console.WriteLine(e));

            //10.e

            var m = from i in numbers
                      where i >= 10
                      select new { Number = i, Even = i % 2 == 0 ? "even" : "uneven" };

            m.ToList().ForEach(e => Console.WriteLine(e));

            //11
            Console.WriteLine("\n11:");
            people.Reset();
            people.ForEach(e => Console.WriteLine(e));


            //12
            Random rnd = new Random();
            List<int> randInts = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                randInts.Add(rnd.Next(1, 101));
            }

            //12a
            int totalOddNums = randInts.Where(e => e % 2 != 0).Count();


            Console.WriteLine($"\n 12a: {totalOddNums}");
            //12b
            int totalDistincNums = randInts.Distinct().Count();

            Console.WriteLine($"\n 12b: {totalDistincNums}");

            //12c
            Console.WriteLine("\n 12c");

            IEnumerable<int> odds = (randInts.Where(e => e % 2 != 0).Select(e => e)).Take(3);

            foreach(int i in odds)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n 12d:");
            //12d
            IEnumerable<int> distinctOdds = randInts.Distinct().Where(e => e % 2 != 0).Select(e => e);
            foreach (int i in distinctOdds)
            {
                Console.WriteLine(i);
            }


            //13
            Console.WriteLine("\n 13:");

            var peopleFirstLetter = from p in people
            group p by p.Name[0] into studentGroup
            orderby studentGroup.Key
            select studentGroup;

            foreach(var v in peopleFirstLetter)
            {
                Console.WriteLine(v.Key);
                foreach (var p in v) Console.WriteLine(p.Name);
            }


            //14
            Console.WriteLine("\n14");

            List<Person> p1 = GetPeople();
            List<Person> p2 = GetPeople2();

             var p3 = from person1 in p1
                    join person2 in p2 on person1.Name equals person2.Name
                    select new {person2.Name, person1.Age, person2.Weight, person1.Score};

            foreach(var p in p3)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();
        }

        //3
        public static bool predicateAsMethod(Person p)
        {
            return p.Score >= 6 && p.Age <= 40;
        }
    }


    //4
    class ScoreAgeSortAscending : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
           if(x.Score == y.Score)
            {
                return x.Age.CompareTo(y.Age);
            }

            return x.Score.CompareTo(y.Score);
        }
    }

    //4
    class ScoreAgeSortDecending : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Score == y.Score)
            {
                return y.Age.CompareTo(x.Age);
            }

            return y.Score.CompareTo(x.Score);
        }
    }

}
