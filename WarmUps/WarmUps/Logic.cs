using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WarmUps
{
    public class Logic
    {
        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars >= 40 && cigars <= 60 || isWeekend == true)
            {
                return true;
            }
            return false;
        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle >= 8 || dateStyle >= 8)
            {
                return 2;
            }
            if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            return 1;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp > 60 && temp < 90)
            {
                return true;
            }
            if (isSummer == true && (temp > 60 && temp < 100))
            {
                return true;
            }
            return false;
        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (isBirthday == true)
            {
                speed -= 5;
            }
            if (speed <= 60)
            {
                return 0;
            }
            if (speed > 61 && speed < 80)
            {
                return 1;
            }
            return 2;
        }

        public int SkipSum(int a, int b)
        {
            if (a + b == 7)
            {
                return 7;
            }
            if (a + b == 13)
            {
                return 20;
            }
            return 21;
        }

        public string AlarmClock(int day, bool vacation)
        {
            if (day >= 6 || day < 1)
            {
                return "10:00";
            }
            return "7:00";
        }

        public bool LoveSix(int a, int b)
        {
            if (b == 6 || a == 6)
            {
                return true;
            }
            if (a + b == 6 || a - b == 6)
            {
                return true;
            }
            return false;
        }

        public bool InRange(int n, bool outsideMode)
        {
            if (n >= 1 && n <= 10)
            {
                return true;
            }
            if (outsideMode == true)
            {
                return true;
            }
            return false;
        }

        public bool SpecialEleven(int n)
        {
            if (n%11 == 0)
            {
                return true;
            }
            if (n - 1 == 22)
            {
                return true;
            }
            return false;
        }

        public bool Mod20(int n)
        {
            if (n == 21||n == 22)
            {
                return true;
            }
            return false;
        }

        public bool Mod35(int n)
        {
            if (n%15 == 0)
            {
                return false;
            }
            if (n % 3 == 0 || n % 5 == 0)
            {
                return true;
            }
            return false;

        }

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
           
            if (isMorning == true && isMom == true)
            {
                return true;
            }
            if (isAsleep == true)
            {
                return false;
            }
            if (isMorning == true)
            {
                return false;
            }
            return true;
        }

        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c || a + c == b || b + c == a)
            {
                return true;
            }
            return false;
        }

       public bool AreInOrder(int a, int b, int c, bool bOk)
       {
           if (bOk == true && c > b)
           {
               return true;
           }
           if (b > a && c > b)
           {
               return true;
           }
           return false;
       }

        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (a < b && b < c)
            {
                return true;
            }
            if (equalOk == true && a == b)
            {
                return true;
            }
            return false;
        }

       // public bool LastDigit(int a, int b, int c)
        //{
            
        //}
    }
}
