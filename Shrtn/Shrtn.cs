using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Entity;
using Shrtn.Entity.Encoders;

namespace Shrtn
{
    /// <summary>
    /// Utility class that takes integers such as a primary key id and turns them into short strings using base conversion.
    /// </summary>
    public static class Shorten
    {
        /// <summary>
        /// Encode an integer using the default encoder
        /// </summary>
        /// <param name="value">Value to be encoded</param>
        /// <returns>An integer encoded to a string</returns>
        public static string Encode(ulong value)
        {
            return Encode(value, EncoderTypes.CrockfordLower);
        }

        /// <summary>
        /// Encode an integer and specify one of the builtin encoders
        /// </summary>
        /// <param name="value">Value to be encoded</param>
        /// <param name="encoderType">The encoder to be used</param>
        /// <returns>An integer encoded to a string</returns>
        public static string Encode(ulong value, EncoderTypes encoderType)
        {
            EncoderFactory factory = new EncoderFactory();
            BaseEncoder encoder = factory.GetEncoder(encoderType);
            return encoder.Encode(value);
        }

        /// <summary>
        /// Encode an integer using a custom encoder
        /// </summary>
        /// <param name="value">Value to be encoded</param>
        /// <param name="encoder">The custom encoder to be used</param>
        /// <returns>An integer encoded to a string</returns>
        public static string Encode(ulong value, BaseEncoder encoder)
        {
            return encoder.Encode(value);
        }

        /// <summary>
        /// Decode a string using the default encoder
        /// </summary>
        /// <param name="encodedValue">The encoded string</param>
        /// <returns>A converted integer</returns>
        public static ulong Decode(string encodedValue)
        {
            return Decode(encodedValue, EncoderTypes.CrockfordLower);
        }

        /// <summary>
        /// Decode a string and specify one of the builtin encoders
        /// </summary>
        /// <param name="encodedValue">The encoded string</param>
        /// <param name="encoderType">The encoder used on this string</param>
        /// <returns>A converted integer</returns>
        public static ulong Decode(string encodedValue, EncoderTypes encoderType)
        {
            EncoderFactory factory = new EncoderFactory();
            BaseEncoder encoder = factory.GetEncoder(encoderType);
            return encoder.Decode(encodedValue);
        }

        /// <summary>
        /// Decode a string using a custom encoder
        /// </summary>
        /// <param name="encodedValue">The encoded string</param>
        /// <param name="encoder">The custom encoder to be used</param>
        /// <returns>A converted integer</returns>
        public static ulong Decode(string encodedValue, BaseEncoder encoder)
        {
            return encoder.Decode(encodedValue);
        }
    }
}
