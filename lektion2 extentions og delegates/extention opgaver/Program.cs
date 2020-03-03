using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extention_opgaver
{
    static class hej
    {

        //1
        public static int Factorial(this int n)
        {
            if (n==1)
            {
                return 1;
            }

            return n * Factorial(n - 1); 
        }

        //2
        public static int Power(this int n, int p)
        {
            if(p == 0)
            {
                return 1;
            }

            return Power(n, p - 1) * n;
        }


        //3
        public static bool IsPalindrome(this string str)
        {
            if (str[0] != str[str.Length - 1])
            {
                return false;
            }
            else if (str.Length> 2)
            {
                IsPalindrome(str.Substring(1, str.Length - 1));
            }

            return true;
        }
        static void Main(string[] args)
        {

            Console.WriteLine($"opg 1: {3.Factorial()}");

            Console.WriteLine($"opg 2: {3.Power(3)}");

            Console.WriteLine($"opg 3 {"ABBa".IsPalindrome()}");

            Console.ReadKey();
        }

    }
}
