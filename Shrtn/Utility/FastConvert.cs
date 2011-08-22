using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Entity;
using Shrtn.Entity.Encoders;

namespace Shrtn.Utility
{
    /// <summary>
    /// A class for efficient base conversion.
    /// </summary>
    /// <remarks>Credit to 0xA3</remarks>
    /// <see cref="http://stackoverflow.com/questions/923771/"/>
    public static class FastConvert
    {
        /// <summary>
        /// An optimized method using an array as buffer instead of 
        /// string concatenation. This is faster for return values having 
        /// a length > 1.
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="baseChars">The characters to be used for encoding</param>
        public static string IntToStringFast(UInt64 value, char[] baseChars)
        {
            // 64 is the worst cast buffer size for base 2 and UInt64.MaxValue
            int i = 64;
            char[] buffer = new char[i];
            UInt64 targetBase = (UInt64)baseChars.Length;

            do
            {
                buffer[--i] = baseChars[(int)(value % targetBase)];
                value = value / targetBase;
            }
            while (value > 0);

            char[] result = new char[64 - i];
            Array.Copy(buffer, i, result, 0, 64 - i);

            return new string(result);
        }

        /// <summary>
        /// An optimized method using an array as buffer instead of 
        /// string concatenation. This is faster for return values having 
        /// </summary>
        /// <param name="encoder">this</param>
        /// <param name="value">Value to be converted</param>
        /// <returns>A converted string</returns>
        public static string IntToStringFast(this BaseEncoder encoder, UInt64 value)
        {
            return IntToStringFast(value, encoder.Characters);
        }

        /// <summary>
        /// An optimized method using an array as buffer instead of 
        /// string concatenation. This is faster for return values having 
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="encoder"></param>
        /// <returns></returns>
        public static string IntToStringFast(UInt64 value, BaseEncoder encoder)
        {
            return IntToStringFast(value, encoder.Characters);
        }
    }
}
