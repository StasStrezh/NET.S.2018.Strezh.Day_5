using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertingToOtherSystem
{
    /// <summary>
    /// Notation class
    /// </summary>
    public class Notation
    {
        private int p;
        public const string card = "0123456789ABCDEF";
        private int minBoarder = 2, maxBoarder = 16;

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="p"></param>
        public Notation(int p)
        {
            if (p < minBoarder || p > maxBoarder)
            {
                throw new ArgumentException("Wrong notation. Notation must be: 2<=Notation<=16");
            }

            this.p = p;
        }
        /// <summary>
        /// Two properties, for base and symbols
        /// </summary>
        public int @Base { get { return p; } }
        public string Symbols { get { return card; } }

    }

    /// <summary>
    /// Converter class
    /// </summary>
    public static class Converter
    {
        public static double Convert(string number, Notation notation)
        {
            if (String.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("Number can't be null or empty!");
            }
            double rank = 1, result = 0;
            for (var i = number.Length - 1; i >= 0; i--)
            {
                var index = notation.Symbols.IndexOf(number[i]);
                if (index < 0 || index >= notation.Base)
                    throw new ArgumentException();

                result += rank * index;
                rank *= notation.Base;
            }
            return result;
        }
    }
    
}
