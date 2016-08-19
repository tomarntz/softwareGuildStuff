using NUnit.Framework;
using string_calculator_kata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringcalculatorkata.test
{
    [TestFixture]
    class Calculatortest
    {
        [Test]
        public void step1_NoParameters()
        {
            Calculator calc = new Calculator();
            int result = calc.Add("");

            Assert.AreEqual(0, result);
        }

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("17", 17)]
        public void Step1_Parameter(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2", 3)]
        [TestCase("1234, 10000", 11234)]
        public void Step1_TwoParameters(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3,4,5,6", 21)]
        public void Step2(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1\n2, 3", 6)]
        [TestCase("1,2,3,4,5,6", 21)]
        public void Step3(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        [TestCase("//;\n1;2", 3)]
        [TestCase("//|\n1|2|3", 6)]
        public void Step4(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }
        [TestCase()]
        public void Step5(string numbers, int expected)
        {
            Calculator calc = new Calculator();
            int result = calc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

    }
}