using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WarmUps
{
    public class arrays
    {
        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0]==6|| numbers[numbers.Length-1]==6)
            {
                return true;
            }
            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length > 1 && numbers[0] == numbers[numbers.Length - 1])
            {
                return true;
            }
            return false;
        }

     /*   public int[] MakePi(int n)
        {
            var output = new List<int>();

            string pi = Math.PI.ToString();
            pi = pi.Replace(".", "");
            pi = pi.Substring(0, n);
            foreach (var c in pi)
            {
                var i = int.Parse(c.ToString());
                output.Add(1);

            }
            return output.ToArray();
        }*/

        public bool commonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0]||a[a.Length-1]==b[b.Length-1])
            {
                return true;
            }
            return false;
        }

        public int Sum(int[] numbers)
        {
            int sum = numbers.Sum();
            return sum;
        }

        public int[] RotateLeft(int[] numbers)
        {
            int first = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[i - 1] = numbers[i];
            }

            numbers[numbers.Length - 1] = first;

            return numbers;
        }

        public int[] Reverse(int[] numbers)
        {
            int first = numbers[0];
            int last = numbers[2];
            numbers[0] = last;
            numbers[numbers.Length - 1] = first;

            return numbers;

        }

        public int[] HigherWins(int[] numbers)
        {
            int higher;
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                higher = numbers[0];
            }
            else
            {
                higher = numbers[numbers.Length - 1];
            }
            
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = higher;
            }
            return numbers;
        }

     /*  public int[] GetMiddle(int[] a, int[] b)
       {
           
       }*/
    }
}
