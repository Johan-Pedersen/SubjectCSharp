using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExercises
{
    public static class IntGeneratorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfIntegers">Number of random integers to return</param>
        /// <returns>List<int> with numberOfIntegers between 0 and 99</int></returns>
        public static List<int> GenerateListOfRandomInts(int numberOfIntegers)
        {
            List<int> listOfInts = new List<int>();
            Random rand = new Random();
            while (numberOfIntegers > 0)
            {
                listOfInts.Add(rand.Next(99));
                numberOfIntegers--;
            }
            return listOfInts;
        }
    }
}
