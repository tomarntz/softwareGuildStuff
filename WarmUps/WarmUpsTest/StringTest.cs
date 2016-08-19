using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WarmUps;

namespace WarmUpsTest
{
    [TestFixture]
    public class StringTest
    {
        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void SayHi(string name, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.SayHi(name);

            Assert.AreEqual(result, expected);
        }

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Yo", "Alice", "YoAliceAliceYo")]
        [TestCase("What", "Up", "WhatUpUpWhat")]
        public void Abba(string a, string b, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.Abba(a, b);

            Assert.AreEqual(result, expected);

        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]
        public void MakeTags(string tag, string content, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.MakeTags(tag, content);

            Assert.AreEqual(result, expected);
        }

        [TestCase("<<>>", "Yay", "<<Yay>>")]
        [TestCase("<<>>", "WooHoo", "<<WooHoo>>")]
        [TestCase("[[]]", "word", "[[word]]")]
        public void InsertWord(string continer, string word, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.InsertWord(continer, word);

            Assert.AreEqual(result, expected);
        }

        [TestCase("Hello", "lololo")]
        [TestCase("ab", "ababab")]
        [TestCase("Hi", "HiHiHi")]
        public void MultipleEndings(string str, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.MultipleEndings(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("WooHoo", "Woo")]
        [TestCase("HelloThere", "Hello")]
        [TestCase("abcdef", "abc")]
        public void FirstHalf(string str, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.FirstHalf(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("Hello", "ell")]
        [TestCase("java", "av")]
        [TestCase("coding", "odin")]
        public void TrimOne(string str, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.TrimOne(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("Hello", "hi", "hiHellohi")]
        [TestCase("hi", "Hello", "hiHellohi")]
        [TestCase("aaa", "b", "baaab")]
        public void LongInMiddle(string a, string b, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.LongInMiddle(a, b);

            Assert.AreEqual(result, expected);
        }

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateLeft2(string str, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.Rotateleft2(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        [TestCase("florida", "daflori")]
        public void RotateRight2(string str, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.RoatateRight2(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]
        public void TakeOne(string str, bool fromFront, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.TakeOne(str, fromFront);

            Assert.AreEqual(expected, result);
        }

        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("Practice", "ct")]
        public void MiddleTwo(string str, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.MiddleTwo(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]
        public void EndsWithLy(string str, bool expected)
        {
            StringWarmUps obj = new StringWarmUps();
            bool result = obj.EndsWithLy(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]
        public void FrontAndBack(string str, int n, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.FrontAndBack(str, n);

            Assert.AreEqual(expected, result);
        }

        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TakeTwoFromPosition(string str, int n, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.TakeTwoFromPosition(str, n);

            Assert.AreEqual(expected, result);
        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        public void HasBad(string str, bool expected)
        {
            StringWarmUps obj = new StringWarmUps();
            bool result = obj.HasBad(str);

            Assert.AreEqual(expected, result);
        }

        [TestCase("Hello", "He")]
        [TestCase("Hi", "Hi")]
        [TestCase("H", "H@")]
        public void AtFirst(string str, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.AtFirst(str);

            Assert.AreEqual(expected, result);

        }

        [TestCase("last", "chars", "ls")]
        [TestCase("yo", "mama", "ya")]
        [TestCase("hi", "", "h@")]
        public void LastChars(string a, string b, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.LastChars(a, b);

            Assert.AreEqual(expected, result);
        }

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc", " ", "abc")]
        public void ConCat(string a, string b, string expected)
        {
            StringWarmUps obj = new StringWarmUps();
            string result = obj.ConCat(a, b);

            Assert.AreEqual(expected, result);
        }

        //[TestCase("coding", "codign")]
        //[TestCase("cat", "cta")]
        //[TestCase("ab", "ba")]
        //public void SwapLast(string str, string expected)
        //{
        //    StringWarmUps obj = new StringWarmUps();
        //    string result = obj.SwapLast(str);

        //    Assert.AreEqual(expected, result);
        //}
    }
} 