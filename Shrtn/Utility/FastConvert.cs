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
        /// <returns>A converted string</returns>
        public static string IntToStringFast(ulong value, char[] baseChars)
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
        public static string IntToStringFast(this BaseEncoder encoder, ulong value)
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
        public static string IntToStringFast(ulong value, BaseEncoder encoder)
        {
            return IntToStringFast(value, encoder.Characters);
        }

        /// <summary>
        /// Also print character value to debug unreadable unicode symbols
        /// </summary>
        /// <param name="value">Value t obe converted</param>
        /// <param name="baseChars">The characters to be used for encoding</param>
        /// <returns>An encoded value</returns>
        public static string IntToStringFastDebug(ulong value, BaseEncoder encoder)
        {
            // 64 is the worst cast buffer size for base 2 and UInt64.MaxValue
            int i = 64;
            char[] buffer = new char[i];
            int[] bufferVal = new int[i];
            UInt64 targetBase = (UInt64)encoder.Characters.Length;

            do
            {
                buffer[--i] = encoder.Characters[(int)(value % targetBase)];
                bufferVal[i] = (int)(value % targetBase);
                value = value / targetBase;
            }
            while (value > 0);

            char[] result = new char[64 - i];
            int[] resultVal = new int[64 - i];

            Array.Copy(buffer, i, result, 0, 64 - i);
            Array.Copy(bufferVal, i, resultVal, 0, 64 - i);

            StringBuilder b = new StringBuilder();
            b.Append(new string(result));
            b.Append("\n");

            foreach (int val in resultVal)
                b.AppendFormat("{0},", val);

            b.Append("\n");
            return b.ToString();
        }

        /// <summary>
        /// An optimized method using a dictionary populated with characters and values
        /// to avoid iterating over characters to find value
        /// </summary>
        /// <param name="encodedValue">The encoded string</param>
        /// <param name="baseChars">The characters used to encode an integer to this string</param>
        /// <returns>A converted integer</returns>
        public static ulong StringToIntFast(string encodedValue, Dictionary<char, int> baseChars)
        {
            ulong result = 0;
            int sourceBase = baseChars.Count;
            int nextCharIndex = 0;
            int encodedValueLength = encodedValue.Length;

            for (int currentChar = encodedValueLength - 1; currentChar >= 0; currentChar--)
            {
                char next = encodedValue[currentChar];

                if (!baseChars.TryGetValue(next, out nextCharIndex))
                {
                    throw new ArgumentException("Input includes illegal characters.");
                }

                // For character N (from the end of the string), we multiply our value
                // by 64^N. eg. if we have "CE" in hex, F = 16 * 13.
                // CAST CAST CAST CAST!!1!!!!ONE@!
                result += Shrtn.Utility.Math.Pow((ulong)sourceBase, (ulong)encodedValueLength - 1 - (ulong)currentChar) * (ulong)nextCharIndex;
            }

            return result;
        }

        /// <summary>
        /// An optimized method using a dictionary populated with characters and values
        /// to avoid iterating over characters to find value
        /// </summary>
        /// <param name="encoder">The encoder used to encode this string</param>
        /// <param name="encodedValue">The encoded string</param>
        /// <returns>A converted integer</returns>
        public static ulong StringToIntFast(this BaseEncoder encoder, string encodedValue)
        {
            return StringToIntFast(encodedValue, encoder.CharactersToValues);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encodedValue">The encoded string</param>
        /// <param name="encoder">The encoder used to encode this string</param>
        /// <returns>A converted integer</returns>
        public static ulong StringToIntFast(string encodedValue, BaseEncoder encoder)
        {
            return StringToIntFast(encodedValue, encoder.CharactersToValues);
        }
    }
}
