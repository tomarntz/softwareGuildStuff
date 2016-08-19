using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WarmUps;

namespace WarmUpsTest
{
    public class arraytest
    {
        [TestCase(new int[] {1, 2, 6,}, true)]
        [TestCase(new int[] {6, 1, 2, 3}, true)]
        [TestCase(new int[] {13, 6, 1, 2, 3}, false)]
        public void FirstLast6(int[] numbers, bool expected)
        {
            arrays obj = new arrays();
            bool result = obj.FirstLast6(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] {1, 2, 3}, false)]
        [TestCase(new int[] {1, 2, 3, 1}, true)]
        [TestCase(new int[] {1, 2, 1}, true)]
        [TestCase(new int[] {1}, false)]
        public void SameFirstLast(int[] numbers, bool expected)
        {
            arrays obj = new arrays();
            bool result = obj.SameFirstLast(numbers);

            Assert.AreEqual(expected, result);
        }

    /*   [TestCase(3, new int[] {3,1,4})]
       public void MakePi(int[] n, int [] expected)
       {
           arrays array = new arrays();
           var result = array.MakePi(n);
            
           Assert.AreEqual(expected, result);
       }*/

        [TestCase(new int[] {1, 2, 3}, new int[] {7, 3}, true)]
        [TestCase(new int[] {1, 2, 3}, new int[] {7, 3, 2}, false)]
        [TestCase(new int[] {1, 2, 3}, new int[] {1, 3}, true)]
        public void commonEnd(int[] a, int[] b, bool expected)
        {
            arrays obj = new arrays();
            bool result = obj.commonEnd(a, b);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] {1, 2, 3}, 6)]
        [TestCase(new int[] {5, 11, 2}, 18)]
        [TestCase(new int[] {7, 0, 0}, 7)]
        public void Sum(int[] numbers, int expected)
        {
            arrays obj = new arrays();
            int result = obj.Sum(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] {1, 2, 3},new int [] { 2, 3, 1})]
        [TestCase(new int[] {5, 11, 9},new int[] { 11, 9, 5})]
        [TestCase(new int[] {7, 0, 0},new int[] { 0, 0, 7})]
        public void RotateLeft(int[] numbers, int []expected)
        {
            arrays obj = new arrays();
            var result = obj.RotateLeft(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] {1, 2, 3}, new int[] {3, 2, 1})]
        public void Reverse(int[] numbers, int[] expected)
        {
            arrays obj = new arrays();
            var result = obj.Reverse(numbers);
            
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int [] {1, 2, 3}, new int[] {3, 3, 3})]
        [TestCase(new int[] {11, 5, 9}, new int[] {11, 11, 11})]
        [TestCase(new int[] {2, 11, 3}, new int[] {3, 3, 3})]
        public void HigherWins(int[] numbers, int[] expected)
        {
            arrays obj = new arrays();
            var result = obj.HigherWins(numbers);

            Assert.AreEqual(expected,result);
        }

      /*  [TestCase(new int[] {1, 2, 3}, new int[] {4, 5, 6}, new int[] {2, 5})]
        [TestCase(new int[] {7, 7, 7}, new int[] {3, 8, 0}, new int[] {7, 8})]
        [TestCase(new int[] {5, 2, 9}, new int[] {1, 4, 5}, new int[] {2, 4})]
        public void GetMiddle(int[] a, int[] b, int[] expected)
        {
            arrays obj  = new arrays();
            var result = obj.GetMiddle(a, b);

            Assert.AreEqual(expected,result);
        }
        */

    }
}
