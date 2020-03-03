using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrangeImpl {

    public static class MyExt {
        public static int Guf(this int me) {
            return 45;
        }
    }

    class Program {
        static void Main(string[] args) {
            // This is possible but very strange. Dont use extensions like this
            Console.WriteLine("34 " + 65.Guf());
        }
    }
}
