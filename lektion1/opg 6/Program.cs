using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opg_6
{
    class MySortingClass
    {
        List<int> tal = new List<int>();

        public MySortingClass(List<int> i)
        {
            tal = i;
        }

        public void getTal()
        {
            Console.WriteLine("\n");
            tal.ForEach(e =>
            {
                Console.WriteLine(e);
            });
        }
        public void bubbleSort()
        {
            for (int l = 0; l < tal.Count; l++)
            {
                for (int i = 1; i < tal.Count; i++)
                {
                    if (tal[i] < tal[i - 1])
                    {
                        swap(i, i - 1);
                    }
                }
            }
        }
        private void swap( int s1, int s2)
        {
            int temp = tal[s1];
            tal[s1] = tal[s2];
            tal[s2] = temp;
        }

        static void Main(string[] args)
        {
            List<int> hej = new List<int>() { 4, 2, 3, 1 };
     
            MySortingClass msc = new MySortingClass(hej);


            msc.getTal();
            msc.bubbleSort();
            msc.getTal();

            Console.ReadKey();
        }
    }
}
