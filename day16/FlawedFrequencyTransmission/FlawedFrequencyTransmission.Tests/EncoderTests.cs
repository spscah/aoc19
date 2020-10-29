using System;
using FlawedFrequencyTransmission.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlawedFrequencyTransmission.Tests
{
    [TestClass]
    public class EncoderTests
    {
        [TestMethod]
        public void TestGivenA()
        {
            Encoder e = new Encoder("12345678");
            e.GenerateNextEncoding();
            Assert.AreEqual("48226158", e.First(8));
            e.GenerateNextEncoding();
            Assert.AreEqual("34040438", e.First(8));
            e.GenerateNextEncoding();
            Assert.AreEqual("03415518", e.First(8));
            e.GenerateNextEncoding();
            Assert.AreEqual("01029498", e.First(8));        
        }

        [TestMethod]
        [DataRow("80871224585914546619083218645595","24176176")]
        [DataRow("19617804207202209144916044189917","73745418")]
        [DataRow("69317163492948606335995924319873","52432133")]
        public void TestGivenB(string input, string expected)
        {
            Encoder e = new Encoder(input);
            for (int i = 0; i < 100; ++i)
                e.GenerateNextEncoding();
            Assert.AreEqual(expected, e.First(8));
        }

        [TestMethod]
        [DataRow("80871224585914546619083218645595", "0303673")]
        [DataRow("19617804207202209144916044189917", "0293510")]
        [DataRow("69317163492948606335995924319873", "0308177")]
        public void TestFirstSeven(string input, string expected)
        {
            Encoder e = new Encoder(input,10000);
            int f7 = e.FirstSeven();
            Assert.AreEqual(expected, f7);
        }
    }
}
