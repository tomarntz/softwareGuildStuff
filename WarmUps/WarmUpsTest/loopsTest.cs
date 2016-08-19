using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WarmUps;

namespace WarmUpsTest
{
    public class LoopsTest
    {
        [TestFixture]
        public class loopsTest
        {
            [TestCase("Hi", 2, "HiHi")]
            [TestCase("Hi", 3, "HiHiHi")]
            [TestCase("Hi", 1, "Hi")]
            public void StringTimes(string str, int n, string expected)
            {
                loops obj = new loops();
                string result = obj.StringTimes(str, n);

                Assert.AreEqual(expected,result);
            }

            [TestCase("chocolate", 2, "chocho")]
            [TestCase("chocolate", 3, "chochocho")]
            [TestCase("abc", 3, "abcabcabc")]
            public void FrontTimes(string str, int n, string expected)
            {
                loops obj = new loops();
                string result = obj.FrontTimes(str, n);

                Assert.AreEqual(expected, result);
            }

            [TestCase("abcxx", 1)]
            [TestCase("xxx", 2)]
            [TestCase("xxxx", 3)]
            public void Countxx(string str, int expected)
            {
                loops obj = new loops();
                int result = obj.CountXX(str);

                Assert.AreEqual(expected, result);
            }

            [TestCase("axxbb", true)]
            [TestCase("axaxxax", false)]
            [TestCase("xxxxx", true)]
            public void DoubleX(string str, bool expected)
            {
                loops obj = new loops();
                bool result = obj.DoubleX(str);

                Assert.AreEqual(expected, result);
            }
        }
    }
}
