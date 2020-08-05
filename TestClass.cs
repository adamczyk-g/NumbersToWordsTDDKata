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
        public void FromZeroToNineteen_Test(string expected, int number)
        {
            string words = new NumbersToWords().FromZeroToNineteen(number);
            Assert.AreEqual(expected,words);
        }
        
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

        public void FromTwentyToNinetyNine_Test(string expected, int number)
        {
            string words = new NumbersToWords().FromTwentyToNinetyNine(number);
            Assert.AreEqual(expected, words);
        }

        public class NumbersToWords
        {
            private readonly Dictionary<int, string> words = new Dictionary<int, string>(){
                { 0, "zero"}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight" },
                { 9, "nine"}, {10, "ten"}, { 11, "eleven"}, {12, "twelve"}, {13, "thirteen"}, {14, "fourteen"}, {15, "fifteen"},
                { 16, "sixteen"}, {17, "seventeen"}, {18, "eighteen"}, {19, "ninteen" }, {20, "twenty"}, {30, "thirty"},
                { 40, "fourty"}, {50, "fifty"}, {60, "sixty"}, {70, "seventy"}, {80, "eighty"}, {90, "ninety" }};
            
            public NumbersToWords() { }

            public string FromZeroToNineteen(int number)
            {
                return words[number];
            }

            public string FromTwentyToNinetyNine(int number)
            {
                string result = words[number - number % 10];

                if (number % 10 != 0)
                {
                    result += "-" + words[number % 10];
                }

                return result;
            }
        }
    }
}
