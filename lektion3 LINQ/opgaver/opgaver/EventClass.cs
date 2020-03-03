using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgaver
{
   public class EventClass
    {

        //5
        public delegate int StringToInt(string str);

        public static int CountChars(string str)
        {
            return str.Length;
        }

        //7
        public static int DelegateUser(StringToInt ST, string str)
        {
            return ST(str);
        }

    }
}
