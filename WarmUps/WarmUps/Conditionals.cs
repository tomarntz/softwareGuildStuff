using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmUps
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == false || isVacation == true)
            {
                return true;
            }
            return false;
        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return (a + b)*2;
            }
            return (a + b);

        }

        public int Diff21(int n)
        {
            if (n > 21)
            {
                return Math.Abs(n - 21)*2;
            }
            return Math.Abs(n - 21);
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true && hour <7 || hour > 20)
            {
                return true;
            }
            return false;
        }

        public bool Makes10(int a, int b)
        {
            if (b == 10)
            {
                return true;
            }
            if (a+b == 10)
            {
                return true;
            }
            return false;
        }

        public bool NearHundred(int n)
        {
            if (n >= 90 && n <= 110)
            {
                return true;
            }
            return false;

        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (a<0 && b>0 || a>0 && b<0)
            {
                return true;
            }
            if (negative == true && (a < 0 && b < 0))
            {
                return true;
            }
            return false;
        }

        public string NotString(string str)
        {
            string a = "not";
            string b = str.Substring(0);
            return string.Format("{0} {1}", a, b);
        }


        public string MissingChar(string str, int n)
        {
            string a = str.Remove(n, 1);
            return a;
        }

      /*  public string FrontBack(string str)
        {
            string a = str.Replace(str.to);
            return a;
        }*/
    }
}

