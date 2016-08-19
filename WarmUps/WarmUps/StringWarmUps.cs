using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WarmUps
{
    public class StringWarmUps
        
    {
        public string SayHi(string name)
        {
            return string.Format("Hello {0}!", name);
        }

        public string Abba(string a, string b)
        {
            return string.Format("{0}{1}{1}{0}", a, b);
        }

        public string MakeTags(string tag, string content)
        {
            return string.Format("<{0}>{1}</{0}>", tag, content);
        }

        public string InsertWord(string container, string word)
        {
            string a = container.Substring(0, container.Length/2);
            string b = container.Substring(container.Length/2);
            return string.Format("{0}{1}{2}", a, word, b);
        }

        public string MultipleEndings(string str)
        {
            string a = str.Substring((str.Length - 2), 2);
            return string.Format("{0}{0}{0}", a);
        }

        public string FirstHalf(string str)
        {
            string a = str.Substring(0, (str.Length/2));
            return string.Format("{0}", a);
        }

        public string TrimOne(string str)
        {
            string a = str.Substring(1, (str.Length - 2));
            return string.Format("{0}", a);

        }

        public string LongInMiddle(string a, string b)
        {
            if (b.Length > a.Length)
            {
                return string.Format("{0}{1}{0}", a, b);
            }
            else
            {
                return String.Format("{1}{0}{1}", a, b);
            }
        }

        public string Rotateleft2(string str)
        {
            string a = str.Substring(0, 2);
            string b = str.Substring(2);
            return string.Format("{0}{1}",b, a);
        }
       
        public string RoatateRight2(string str)
        {
            string a = str.Substring(str.Length -2);//removes last two from string
            string b = str.Substring(0, str.Length -2);//removes goes to end - 2
            return string.Format("{1}{0}", b, a);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
                return str.Substring(0, 1);
            }
            return str.Substring(str.Length - 1);
        }

        public string MiddleTwo(string str)
        {
            string a = str.Substring((str.Length/2) - 1, 1);
            string b = str.Substring((str.Length / 2), 1);
            return string.Format("{0}{1}", a, b);
        }

        public bool EndsWithLy(string str)
        {
            if (str.EndsWith("ly") == true)
            {
                return true;
            }
            return false;
        }

        public string FrontAndBack(string str, int n)
        {

            string a = str.Substring(0, n);
            string b = str.Substring(str.Length-n);
            return string.Format("{0}{1}", a,b);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n > 2)
            {
                return str.Substring(0, 2);
            }
            return str.Substring(n, 2);

        }

        public bool HasBad(string str)
        {
            if (str.StartsWith("bad") || str.StartsWith("xbad"))
            {
                return true;
            }
            return false;
        }

        public string AtFirst(string str)
        {
            if (str.Length<2)
            {
                return str.Substring(0, 1)+"@";
            }
            return str.Substring(0, 2);
        }

        public string LastChars(string a, string b)
        {
            if (b == "")
            {
                return a.Substring(0, 1) +"@";
            }
            string str1 = a.Substring(0, 1);
            string str2 = b.Substring(b.Length-1);
            return string.Format("{0}{1}", str1, str2);
        }

        public string ConCat(string a, string b)
        {
            if (a.Substring(a.Length - 1) == b.Substring(0, 1))
            {
                string trim = a.Substring(0, a.Length - 1);
                return string.Format("{0}{1}", trim, b);
            }
            if (b == " ")
            {
                return a;
            }
            return string.Format("{0}{1}", a, b);
        }

     //   public string SwapLast(string str)
      //  {
            //if (str.Length > 3)
            //{
   

            //    string one = str.Substring(0, str.Length - 2);
            //    string two = str.Substring(-1, 0);
            //    string three = str.Substring(-2, 1);
            //    return string.Format("{0}{1}{2}", one, three, two);
            //}
         //   if (str.Length < 3)
          //  {
         //       return str.Reverse().ToString();
       //     }
        //    else
        //    {
        //        return "";
        //    }

       // }
    }
}