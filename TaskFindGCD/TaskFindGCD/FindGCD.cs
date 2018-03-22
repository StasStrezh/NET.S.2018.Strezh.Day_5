using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFindGCD
{
    /// <summary>
    /// Two methods to find GDC
    /// </summary>
    public class FindGCD
    {
        /// <summary>
        /// Euclid method fo two numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>GCD</returns>
        public static long SearchByEuclid(long num1, long num2)
        {
            while (num1 != 0)
            {
                long buff = num1;
                num1 = num2 % num1;
                num2 = buff;
            }

            return Math.Abs(num2);
        }
        /// <summary>
        /// Euclid method for some numbers
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>GCD</returns>
        public static long SearchByEuclid(params long[] nums) => GCD(SearchByEuclid, nums);


        /// <summary>
        /// Stein method for two numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>GCD</returns>
        public static long SearchByStein(long num1, long num2)
        {
            long? gcd = null;

            if (num1 == 0)
                gcd = num2;
            else if (num2 == 0)
                gcd = num1;
            else if (num1 == num2)
                gcd = num1;
            else if (num1 == 1 || num2 == 1)
                gcd = 1;

            if (gcd != null)
                return Math.Abs((long)gcd);

            if ((num1 & 1) == 0)
                gcd = ((num2 & 1) == 0)
                    ? SearchByStein(num1 >> 1, num2 >> 1) << 1
                    : SearchByStein(num1 >> 1, num2);
            else
                gcd = ((num2 & 1) == 0)
                    ? SearchByStein(num1, num2 >> 1)
                    : SearchByStein(num2, num1 > num2 ? num1 - num2 : num2 - num1);

            return Math.Abs((long)gcd);
        }
        /// <summary>
        /// Stein method for some numbers
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>GCD</returns>
        public static long SearchByStein(params long[] nums) => GCD(SearchByStein, nums);


        /// <summary>
        /// Some private methods
        /// </summary>
        private static void CheckInputArray(long[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();

            if (nums.Length < 2)
                throw new ArgumentException();
        }
        private static long GCD(Func<long[], long> gcdFunc, params long[] nums)
        {
            long gcd = gcdFunc(nums);
            return gcd;
        }

    }
}
