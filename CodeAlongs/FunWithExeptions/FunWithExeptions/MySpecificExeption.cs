using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithExeptions
{
    public class MySpecificExeption : Exception
    {
        public MySpecificExeption(string Message) : base(Message)
        {
            HelpLink = "http://www.google.com";
        }
    }
}
