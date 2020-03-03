using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Sudoku
    {
        static void Main(string[] args)
        {

            Sudoku s = new Sudoku("083020000041003825702000000020085036050301080430290050000000308896100540000040160");
            Sudoku s2 = new Sudoku("400030000000600800000000001000050090080000600070200000000102700503000040900000000");
            
            Sudoku s3 = new Sudoku("040010200000009070010000000000430600800000050000200000705008000000600300900000000");



            Console.WriteLine(s);

            Console.WriteLine(s.Solve());
           
            Console.ReadKey();

        }

        private byte[] board = new byte[81];

        public byte[] Board { get; set; }

        public Sudoku(String strBoard)
        {

            for (int i = 0; i < strBoard.Length; i++)
            {
                board[i] = Convert.ToByte(char.GetNumericValue(strBoard[i]));
            }
        }


        /**
         * Exercise 3   
         */
        public override string ToString()
        {
            string s = "";
            for(int i = 0; i<board.Length; i++)
            {
                if (i%9 == 0)
                {
                    s += "\n";

                    if(i % 27 == 0)
                    {
                        s += "\n";
                    }
                }
                else if (i % 3 == 0)
                {
                    s += " ";
                }
                s += board[i]+ " ";
            }
            return s;
        }


        /**
        * Exercise 4
        */
        public bool HasConflict()
        {

            return (ColumnCheck() || RowCheck() || SquareCheck()) ? true : false;
        }

        /**
         * Exercise 4 hjælpemetode
         */
        //tjekker hen af
        private bool RowCheck()
        {
            for (int k = 0; k < board.Length; k+=9)
            {
                for (int i = k; i < k + 9; i++)
                {
                    if (board[i] != 0)
                    {
                        for (int l = i + 1; l < k + 9; l++)
                        {
                            if (board[l] == board[i])
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
       /**
         * Exercise 4 hjælpemetode
         */
         //tjekker ned af
        private bool ColumnCheck()
        {
            for (int k = 0; k < 9; k++)
            {
                for (int i = k; i < 81; i += 9)
                {
                    if (board[i] != 0)
                    {
                        for (int l = i + 9; l <81; l += 9)
                        {
                            if (board[l] == board[i])
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /**
        * Exercise 4 hjælpe metode
        */

        private bool SquareCheck()
        {
            //index styre hvor i array'et tallene skal sættes ind
            int index = 0;

            //arrayet man tjekker i gennem
            int[] numsInSquare = new int[9];

            //i styre hvilken kolonne man kigger i
            for (int i = 0; i<=63; i++)
            {


                //Når man har kørt 3 kolonner i gennem tjekker man om der er dupletter, hvis ja retunere man ellers fortsætter man.
                if (i % 3 == 0 && i != 0)
                {
                    if (Duplicates(numsInSquare))
                    {
                        return true;
                    }
                    
                    //Hvis man er begyndt på en ny række går den 18 rækker ned.
                    if (i % 9 == 0)
                    {
                        i += 18;
                    //Når hele rækken er kørt i gennem betyder det der ikke var dupletter
                        if (i == 81) return false;
                    }

                    //resetter counter til næste square
                    index = 0;
                }
                
                //J styre bestemmer hvilket tal man kigger på
                for (int j = i; j<=i+18; j += 9)
                {
                    //Index sætter tallene i vores array
                    
                    numsInSquare[index] = board[j];
                    index++;
                }
            }

            return false;
        }

        /**
        * Exercise 4 hjælpe metode
        */

        //tjekker om der er dupletter i arrayet
        private bool Duplicates(int[] arr)
        {

            //i er tallet man kigger efter
            int counter = 0;
            for (int i = 1; i<9; i++)
            {

            //L løber array'et i gennem 
                for(int j = 0; j<9; j++)
                {

                    //Hvis i matcher et tal i array'et tælles count op, hvis i har matchet mere end 1 retuneres true.
                    if (i == arr[j])
                    {
                        counter++;

                        if(counter > 1)
                        {
                            return true;
                        }
                    }
                }
                counter = 0;
            }
            return false;
        }

        /**
         * Exercise 5
         */


        /**
         * Metoden bliver kun kaldt på positioner hvor board[pos] == 0
         */

        private List<byte> PossibleNumbers(int i, int j)
        {
            List<byte> bytes = new List<byte>();

            
            
            //position = i+ j*9
            int pos = i + j * 9;
            byte initialvalue = board[pos];

                for (byte k = 1; k <= 9; k++)
                {
                    board[pos] = k;

                    if (!HasConflict())
                    {
                        bytes.Add(k);
                    }
            }

            board[pos] = initialvalue;

            return bytes;
        }
            

        /**
        * Exercise 6
        */

       private int OptimalPosition(out int I, out int J)
        {
            int leastX = 0;
            int leastY = 0;
            int possibleNumsCount;
            int fewestNums = 9;

            //Går ned af
            for (int y = 0; y <=8 ; y++)
            {
                //går hen af 
                for (int x = 0; x <=8; x++)
                {
                    //Position = x+ y*9
                    if (board[x + y * 9] == 0)
                    {
                        possibleNumsCount = PossibleNumbers(x, y).Count;
                        if (fewestNums > possibleNumsCount)
                        {
                            leastX = x;
                            leastY = y;
                            fewestNums = possibleNumsCount;
                        }
                    }
                }
            }
            
            I = leastX;
            J = leastY;
            return fewestNums;
        }

        /**
         * Exercise 7
         */

        private Sudoku Clone()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i<board.Length; i++)
            {
                sb.Append(Convert.ToInt32(board[i]));
            }
            return new Sudoku(sb.ToString());
        }

        /**
         * Exercise 8
         */
        private bool IsSolved()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == 0)
                {
                    return false;
                }
            }

            if (HasConflict())
            {
                return false;
            }

            return true;
        }

        /**
         * Exercise 9
         */
        public Sudoku Solve()
        {

            //lav en ny sudoku for hver mulig løsning og løs dem indtil den retunere null / ikke kan løses.
            int optimalX;
            int optimalY;
            int numOfPossibilities;
            if (!IsSolved())
            {
                numOfPossibilities = OptimalPosition(out optimalX, out optimalY);
                for (int i = 0; i<numOfPossibilities; i++)
                {
                    Sudoku s = Clone();

                    s.board[optimalX + optimalY * 9] = PossibleNumbers(optimalX, optimalY)[i];

                    Console.WriteLine(s);

                    return s.Solve();
                    }
                }
            return null;
            }

        }
    }
