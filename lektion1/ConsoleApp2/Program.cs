using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class newClass
    {
        private int MyMethodWithError(int num)
        {
            return num / 0;
        }
        public void MyNormalMethod(int num)
        {
            try
            {
                MyMethodWithError(num);
            }
            catch
            {
                Console.WriteLine("error");
            }
            finally
            {
                Console.WriteLine("Run lige meget hvad");
            }
         }
        static void Main(string[] args)
        {
            newClass nc = new newClass();

            nc.MyNormalMethod(3);

            Console.ReadKey();
        }
    }
}
