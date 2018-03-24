using System;
using ConvertingToOtherSystem;
using NUnit.Framework;

namespace ConvertingToOtherSystem
{
    [TestFixture]
    public class TestConverting
    {
        [TestCase(2, "0110111101100001100001010111111", 934331071)]
        [TestCase(2, "01101111011001100001010111111", 233620159)]
        [TestCase(2, "11101101111011001100001010111111", 3991716543)]
        [TestCase(16, "1AEF101", 28242177)]
        [TestCase(16, "1ACB67", 1756007)]
        [TestCase(8, "764241", 256161)]
        public void TestConverting_ReturnResult(int p, string num, double expectedRes)
        {
            double res = num.Convert(new Notation(p));
            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(2, "1AEF101")]
        [TestCase(2, "SA123")]
        public void TestConverting_ReturnExeption(int p, string num)
        {
            var ex = Assert.Catch<ArgumentException>(() => num.Convert(new Notation(p)));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }
    }
}
