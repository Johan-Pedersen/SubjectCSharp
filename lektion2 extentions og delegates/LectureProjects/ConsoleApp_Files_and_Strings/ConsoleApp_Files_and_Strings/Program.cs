using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Files_and_Strings {

    public class DataBlock {
        public DataBlock(int id, double number) {
            Id = id;
            Number = number;
        }
        public int    Id { get; set; }
        public double Number { get; set; }
        public override string ToString() {
            return $"Id:{Id}, Number:{Number}";
        }
    }
    public class SortById : IComparer<DataBlock> {
        // Read this
        // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=netframework-4.7.2
        //
        public int Compare(DataBlock x, DataBlock y) {
            return x.Id.CompareTo(y.Id);
        }
    }

    class Program {

        public static void ReadFile(string filename) {
            using (var file = new StreamReader(filename)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }            
        }

        public static string[] SplitString(string txt) {
            var res = txt.Split(';');
            foreach (var s in res) {
                //Console.WriteLine("<" + s + ">");
                Console.WriteLine("<" + s.Trim() + ">");
            }
            return res;
        }

        public static void ParseNumbers(string txt) {
            string[] numbers = SplitString(txt);
            foreach (var n in numbers) {
                int resi;
                if (int.TryParse(n, out resi)) {
                    Console.WriteLine("Got integer : " + resi);
                    continue;
                }
                double resd;
                if (double.TryParse(n, out resd)) {
                    Console.WriteLine("Got double : " + resd);
                    continue;
                }
            }
        }

        public static List<DataBlock> GetListOfDataBlocks() {
            var lst = new List<DataBlock>() {
                new DataBlock(55,34),
                new DataBlock(49,51),
                new DataBlock(76,40),
                new DataBlock(6,51),
                new DataBlock(78,90),
                new DataBlock(27,3),
                new DataBlock(57,66),
                new DataBlock(51,63),
                new DataBlock(24,38),
                new DataBlock(33,68),
            };
            return lst;
        }

        static void Main(string[] args) {
            ReadFile("data.csv"); // Remember to set up path to file

            Console.WriteLine("--------------------------------------------------");
            SplitString("string;txt;  anton  ;22  ;  56;shit er det hjemis bilen...farvel");

            Console.WriteLine("--------------------------------------------------");
            ParseNumbers("34;54;655,45");

            List<DataBlock> dataBlocks = GetListOfDataBlocks();
            dataBlocks.Sort(new SortById());
            foreach(var db in dataBlocks)
                Console.WriteLine(db);

            Console.ReadKey();
        }
    }
}
