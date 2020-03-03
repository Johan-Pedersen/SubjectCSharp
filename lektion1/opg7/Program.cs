using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace opg7
{
    class ran
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            for(int i = 0; i<6; i++)
            {
                Console.WriteLine( rand.Next(1001));
                
            }
            Console.ReadKey();
        }
    }
}
