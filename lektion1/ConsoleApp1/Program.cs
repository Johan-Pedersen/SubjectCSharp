using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class myClass
    {
        private static int _i;

        public myClass(int i)
        {
            _i = i;
        }

        public int I 
        {
            /**
            get => _i;
            set => _i = value;
            */
            get{
                return _i;
            }
            set{ _i = value;
            
            }


        }
        //opgave 3  
        public override String ToString()
        { 
            return $"{_i}";
        }

            
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");
            Console.WriteLine($"Min var er {_i}");


            var hej = new myClass(7);

            Console.WriteLine(hej.ToString());

            hej.I = 42;

            Console.WriteLine(hej.ToString());


            var hej2 = new ClassLibrary1.MyExternalClass();

            Console.WriteLine(hej2.GetMeAsText());

            Console.ReadKey();
        }
    }
}
