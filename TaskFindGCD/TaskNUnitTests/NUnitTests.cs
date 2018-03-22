using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFindGCD;
using NUnit.Framework;

namespace TaskFindGCD
{
    /// <summary>
    /// NUnit tests
    /// </summary>
    [TestFixture]
    public class NUnitTests
    {
        /// <summary>
        /// NUnit tests for Euclid
        /// </summary>
        [TestCase(18, -12, 6)]
        [TestCase(1000, 975, 25)]
        [TestCase(24, 24, 24)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        public void SearchByEuclid_LeftNumGreaterThenRight_ReturnsGCD(long a, long b, long expectedRes)
        {
            long gcd = FindGCD.SearchByEuclid(a, b);
            Assert.AreEqual(expectedRes, gcd);
        }
        [TestCase(18, -12, 24, 6)]
        [TestCase(1000, 975, 250, 25)]
        [TestCase(24, 24, -24, 24)]
        [TestCase(1, 0, 0, 1)]
        public void SearchByEuclid_ThreeParams_ReturnsGCD(long a, long b, long c, long expectedRes)
        {
            long gcd = FindGCD.SearchByEuclid(a, b, c);
            Assert.AreEqual(expectedRes, gcd);
        }
        [TestCase(6, 18, -12, 24, 36)]
        [TestCase(25, 1000, 975, 250, -1250, 250, -625)]
        [TestCase(24, 24, -24, 24, 24, 24, -24)]
        public void SearchByEuclid_GoodNums_ReturnsGCD(long expectedRes, params long[] nums)
        {
            long gcd = FindGCD.SearchByEuclid(nums);
            Assert.AreEqual(expectedRes, gcd);
        }

        /// <summary>
        /// NUnit tests for Stein
        /// </summary>
        [TestCase(18, -12, 6)]
        [TestCase(1000, 975, 25)]
        [TestCase(24, 24, 24)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        public void SearchByStein_LeftNumGreaterThenRight_ReturnsGCD(long a, long b, long expectedRes)
        {
            long gcd = FindGCD.SearchByStein(a, b);
            Assert.AreEqual(expectedRes, gcd);
        }
        [TestCase(6, 18, -12, 24, 36)]
        [TestCase(25, 1000, 975, 250, -1250, 250, -625)]
        [TestCase(24, 24, -24, 24, 24, 24, -24)]
        [TestCase(1, 0, 0, 0, 0, 0, 0, 1)]
        public void SearchByStein_GoodNums_ReturnsGCD(long expectedRes, params long[] nums)
        {
            long gcd = FindGCD.SearchByStein(nums);
            Assert.AreEqual(expectedRes, gcd);
        }

        [TestCase(new long[] { })]
        [TestCase(new long[] { 1 })]
        public void SearchByStein_ArrayLengthLessThanTwo_ThrowsArgumentExceptions(params long[] nums)
        {
            var ex = Assert.Catch<ArgumentException>(() => FindGCD.SearchByEuclid(nums));
            StringAssert.Contains("Value does not fall within the expected range.", ex.Message);
        }
    }
}
