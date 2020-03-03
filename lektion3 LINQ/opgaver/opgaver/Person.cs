using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * This is how my Person class looks by now.
 * I removed my IComparer<Person> implementations
 */
public class Person {
    public Person(string data) {
        // Name, Age, Weight, Score 
        var L = data.Split(';');
        Name = L[0];
        Age = int.Parse(L[1]);
        Weight = int.Parse(L[2]);
        Score = int.Parse(L[3]);
        Accepted = false; // <- nobody accepted by default
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public int Score { get; set; }
    public bool Accepted { get; set; }
    public override string ToString() {
        return String.Format("{0,-10} : {1,4} points, {2,4} years, {3,4} kg, {4,4} Accepted", Name, Score, Age, Weight, Accepted ? "" : "NOT");
    }
    public static List<Person> ReadCSVFile(string filename) {
        List<Person> list = new List<Person>();
        using (var file = new StreamReader(filename)) {
            string line;
            while ((line = file.ReadLine()) != null) {
                var p = new Person(line);
                list.Add(p);
                //Console.WriteLine(p);
            }
        }
        return list;
    }
    // My IComparer<Person> implementations go here ...
}
