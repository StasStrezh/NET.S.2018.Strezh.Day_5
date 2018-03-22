using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertingToOtherSystem
{
    public class Converting
    {
        /// <summary>
        /// Converting numbers
        /// </summary>
        /// <param name="p"></param>
        /// <param name="num"></param>
        public static double ConvertingNumbers(int p, string num)
        {
            if (p < 2 || p > 16)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(num.Length<0 || num.Length>31)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Convert(p, num);
        }

        /// <summary>
        /// Converting method
        /// </summary>
        /// <param name="p"></param>
        /// <param name="num"></param>
        /// <returns>Result</returns>
        private static double Convert(int p, string num)
        {
            const string card = "0123456789ABCDEF";
            double rank = 1, result = 0;
            for (var i = num.Length - 1; i >= 0; i--)
            {
                var index = card.IndexOf(num[i]);
                if (index < 0 || index >= p)
                    throw new ArgumentException();

                result += rank * index;
                rank *= p;
            }
            return result;
        }
    }
}
