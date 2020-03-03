using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MyExternalClass : IMyExternal
    {
        public string GetMeAsText()
        {
            return "Hej jeg er hej";
        }
    }

    public interface IMyExternal
    {
        string GetMeAsText();
    }
}
