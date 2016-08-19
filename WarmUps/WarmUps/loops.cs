using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmUps
{
    public class loops
    {

        public string StringTimes(string str, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += str;
            }
            return result;
        }

        public string FrontTimes(string str, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += str.Substring(0, 3);
            }
            return result;
        }

        public int CountXX(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x' && str[i + 1] == 'x')
                {
                    result++;
                }
            }
            return result;
        }

        public bool DoubleX(string str)
        {
            for (int i = 2; i < str.Length; i++)
            {
                if (str[i] == 'x' && str[i + 1] != 'x')
                {
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
