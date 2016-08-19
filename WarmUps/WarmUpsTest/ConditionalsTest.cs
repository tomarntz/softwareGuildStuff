using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using NUnit.Framework;
using WarmUps;

namespace WarmUpsTest
{
    public class ConditionalsTest
    {
        [TestCase(true, true, true)]
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        public void AreWeInTrouble(bool asmile, bool bSmile, bool expected)
        {
            Conditionals obj = new Conditionals();
            bool result = obj.AreWeInTrouble(asmile, bSmile);

            Assert.AreEqual(result, expected);
        }

        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, true)]
        public void SleepIn(bool isWeekday, bool isVacation, bool expected)
        {
            Conditionals obj = new Conditionals();
            bool result = obj.SleepIn(isWeekday, isVacation);

            Assert.AreEqual(result, expected);
        }

        [TestCase(1, 2, 3)]
        [TestCase(3, 2, 5)]
        [TestCase(2, 2, 8)]
        public void SumDouble(int a, int b, int expected)
        {
            Conditionals obj = new Conditionals();
            int result = obj.SumDouble(a, b);

            Assert.AreEqual(result, expected);
        }

        [TestCase(23, 4)]
        [TestCase(10, 11)]
        [TestCase(21, 0)]
        public void Diff21(int n, int expected)
        {
            Conditionals obj = new Conditionals();
            int result = obj.Diff21(n);

            Assert.AreEqual(result, expected);
        }

        [TestCase(true, 6, true)]
        [TestCase(true, 7, false)]
        [TestCase(false, 6, false)]
        public void parrotTrouble(bool isTalking, int hour, bool expected)
        {
            Conditionals obj = new Conditionals();
            bool result = obj.ParrotTrouble(isTalking, hour);

            Assert.AreEqual(result, expected);
        }

        [TestCase(9, 10, true)]
        [TestCase(9, 9, false)]
        [TestCase(1, 9, true)]
        public void Makes10(int a, int b, bool expected)
        {
            Conditionals obj = new Conditionals();
            bool result = obj.Makes10(a, b);

            Assert.AreEqual(result, expected);
        }

        [TestCase(103, true)]
        [TestCase(90, true)]
        [TestCase(83, false)]
        public void NearHundered(int n, bool expected)
        {
            Conditionals obj = new Conditionals();
            bool result = obj.NearHundred(n);

            Assert.AreEqual(result, expected);
        }

        [TestCase(1, -1, false, true)]
        [TestCase(-1, 1, false, true)]
        [TestCase(-4, -5, true, true)]
        public void PosNeg(int a, int b, bool negative, bool expected)
        {
            Conditionals obj = new Conditionals();
            bool result = obj.PosNeg(a, b, negative);

            Assert.AreEqual(result, expected);
        }

        [TestCase("candy", "not candy")]
        [TestCase("bad", "not bad")]
        [TestCase("x", "not x")]
        public void NotString(string str, string expected)
        {
            Conditionals obj = new Conditionals();
            string result = obj.NotString(str);

            Assert.AreEqual(expected, result);
        }


        [TestCase("kitten", 1, "ktten")]
        [TestCase("kitten", 0, "itten")]
        [TestCase("kitten", 4, "kittn")]
        public void MissingChar(string str, int n, string expected)
        {
            Conditionals obj = new Conditionals();
            string result = obj.MissingChar(str, n);

            Assert.AreEqual(expected, result);
        }

       /* [TestCase("code", "eodc")]
        [TestCase("a", "a")]
        [TestCase("ab", "ba")]
        public void FrontBack(string str, string expected)
        {
            Conditionals obj = new Conditionals();
            string result = obj.FrontBack(str);

            Assert.AreEqual(expected, result);
        }*/
    }
}