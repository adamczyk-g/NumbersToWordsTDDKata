// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NumbersToWordsTDDKata
{
    [TestFixture]
    public class NumbersToWordsTests
    {
        /*
        public void From_0_To_19_Test(string expected, int number)
        {
            string words = new NumbersToWords().From0To19(number);
            Assert.AreEqual(expected,words);
        }*/
        [TestCase("zero", 0)]
        [TestCase("one", 1)]
        [TestCase("two", 2)]
        [TestCase("three", 3)]
        [TestCase("four", 4)]
        [TestCase("five", 5)]
        [TestCase("six", 6)]
        [TestCase("seven", 7)]
        [TestCase("eight", 8)]
        [TestCase("nine", 9)]
        [TestCase("ten", 10)]
        [TestCase("eleven", 11)]
        [TestCase("twelve", 12)]
        [TestCase("thirteen", 13)]
        [TestCase("fourteen", 14)]
        [TestCase("fifteen", 15)]
        [TestCase("sixteen", 16)]
        [TestCase("seventeen", 17)]
        [TestCase("eighteen", 18)]
        [TestCase("ninteen", 19)]
        [TestCase("twenty", 20)]
        [TestCase("thirty", 30)]
        [TestCase("fourty", 40)]
        [TestCase("fifty", 50)]
        [TestCase("sixty", 60)]
        [TestCase("seventy", 70)]
        [TestCase("eighty", 80)]
        [TestCase("ninety", 90)]        
        [TestCase("twenty-one", 21)]
        [TestCase("twenty-two", 22)]
        [TestCase("twenty-three", 23)]
        [TestCase("twenty-four", 24)]
        [TestCase("twenty-five", 25)]
        [TestCase("twenty-six", 26)]
        [TestCase("twenty-seven", 27)]
        [TestCase("twenty-eight", 28)]
        [TestCase("twenty-nine", 29)]
        [TestCase("ninety-nine", 99)]
        public void From_0_To_99_Test(string expected, int number)
        {
            string words = new NumbersToWords().From0To99(number);
            Assert.AreEqual(expected, words);
        }

        [TestCase("one hundred", 100)]
        [TestCase("two hundred", 200)]
        [TestCase("three hundred", 300)]
        [TestCase("four hundred", 400)]
        [TestCase("five hundred", 500)]
        [TestCase("six hundred", 600)]
        [TestCase("seven hundred", 700)]
        [TestCase("eight hundred", 800)]
        [TestCase("nine hundred", 900)]
        [TestCase("one hundred twenty-one", 121)]
        [TestCase("one hundred eleven", 111)]
        [TestCase("nine hundred ninety-nine", 999)]
        public void From_100_To_999_Test(string expected, int number)
        {
            string words = new NumbersToWords().From100To999(number);
            Assert.AreEqual(expected, words);
        }
        
        [TestCase("one thousand", 1000)]
        [TestCase("two thousand", 2000)]
        [TestCase("three thousand", 3000)]
        [TestCase("four thousand", 4000)]
        [TestCase("five thousand", 5000)]
        [TestCase("one thousand one hundred", 1100)]
        [TestCase("one thousand one hundred ten", 1110)]
        [TestCase("one thousand one hundred eleven", 1111)]
        [TestCase("nine thousand nine hundred ninety-nine", 9999)]
        [TestCase("ten thousand", 10000)]
        [TestCase("eleven thousand", 11000)]
        [TestCase("ninety-nine thousand", 99000)]
        [TestCase("ninety-nine thousand one hundred", 99100)]
        [TestCase("ninety-nine thousand nine hundred", 99900)]
        [TestCase("ninety-nine thousand nine hundred ninety", 99990)]
        [TestCase("ninety-nine thousand nine hundred ninety-nine", 99999)]        
        public void From_1000_To_99999_Test(string expected, int number)
        {
            string words = new NumbersToWords().From1000To99999(number);
            Assert.AreEqual(expected, words);
        }

        [TestCase("one hundred thousand", 100000)]
        [TestCase("one hundred ten thousand", 110000)]
        [TestCase("one hundred eleven thousand", 111000)]
        [TestCase("one hundred eleven thousand one hundred", 111100)]
        [TestCase("one hundred eleven thousand one hundred ten", 111110)]
        [TestCase("one hundred eleven thousand one hundred eleven", 111111)]
        [TestCase("nine hundred thousand", 900000)]
        [TestCase("nine hundred ninety thousand", 990000)]
        [TestCase("nine hundred ninety-nine thousand", 999000)]
        [TestCase("nine hundred ninety-nine thousand nine hundred", 999900)]
        [TestCase("nine hundred ninety-nine thousand nine hundred ninety", 999990)]
        [TestCase("nine hundred ninety-nine thousand nine hundred ninety-nine", 999999)]
        public void From_100000_To_999999_Test(string expected, int number)
        {
            string words = new NumbersToWords().From100000To999999(number);
            Assert.AreEqual(expected, words);
        }

        [TestCase(123, 1234123)]
        public void LastThreeDigit_Test(int expected, int number)
        {
            int result = number % 1000;
            Assert.AreEqual(expected, result);
        }

        public class NumbersToWords
        {
            private readonly Dictionary<int, string> NameOfNumber = new Dictionary<int, string>(){
                { 0, "zero"}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight" },
                { 9, "nine"}, {10, "ten"}, { 11, "eleven"}, {12, "twelve"}, {13, "thirteen"}, {14, "fourteen"}, {15, "fifteen"},
                { 16, "sixteen"}, {17, "seventeen"}, {18, "eighteen"}, {19, "ninteen" }, {20, "twenty"}, {30, "thirty"},
                { 40, "fourty"}, {50, "fifty"}, {60, "sixty"}, {70, "seventy"}, {80, "eighty"}, {90, "ninety" }, {100, "hundred" }
            };

            public NumbersToWords() { }

            public string From0To99(int number)
            {
                if (number >= 0 && number <= 19)
                    return NameOfNumber[number];

                string result = NameOfNumber[RoundNumberToNearestTen(number)];

                if (IsNotMultipleOfTen(number))       
                    result += "-" + NameOfNumber[GetLastDigit(number)];

                return result;
            }

            public string From100To999(int number)
            {                
                string result = NameOfNumber[GetNumberOfHundreds(number)] + " " + NameOfNumber[100];                

                if (IsNotMultipleOfHundred(number))            
                    result += " " + From0To99(GetLastTwoDigit(number));                

                return result;
            }

            public string From1000To99999(int number)
            {
                string result = From0To99(GetNumberOfThousands(number)) + " " + "thousand";

                if (IsNotMultipleOfThousand(number))                
                    result += " " + From100To999(GetLastThreeDigit(number));
                
                return result;
            }

            public string From100000To999999(int number)
            {
                string result = From100To999(GetNumberOfThousands(number)) + " " + "thousand";

                if (IsNotMultipleOfThousand(number))                
                    result += " " + From100To999(GetLastThreeDigit(number));

                return result;
            }

            private int GetNumberOfHundreds(int number)
            {
                return number/100;
            }

            private int GetLastThreeDigit(int number)
            {
                return number % 1000;
            }

            private int GetLastTwoDigit(int number)
            {
                return number % 100;
            }

            private int GetLastDigit(int number)
            {
                return number % 10;
            }

            private int RoundNumberToNearestTen(int number)
            {
                return number - GetLastDigit(number);
            }

            private int GetNumberOfThousands(int number)
            {
                return number / 1000;
            }

            private bool IsNotMultipleOfTen(int number)
            {
                return GetLastDigit(number) != 0;
            }

            private bool IsNotMultipleOfHundred(int number)
            {
                return GetLastTwoDigit(number) != 0;
            }

            private bool IsNotMultipleOfThousand(int number)
            {
                return GetLastThreeDigit(number) != 0;
            }
        }
    }
}
