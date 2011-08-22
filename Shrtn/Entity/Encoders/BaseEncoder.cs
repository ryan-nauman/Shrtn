using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Utility;

namespace Shrtn.Entity.Encoders
{
    /// <summary>
    /// Represents an alphabet that can be used to encode and decode strings with
    /// </summary>
    public abstract class BaseEncoder
    {
        /// <summary>
        /// Get the characters of this alphabet
        /// </summary>
        /// <returns>The characters this alphabet composes of</returns>
        public abstract char[] Characters { get; }

        /// <summary>
        /// Encode a string using this alphabet
        /// </summary>
        /// <param name="input">The int to encode</param>
        /// <returns>A string encoded using this alphabet</returns>
        public virtual string Encode(UInt64 value)
        {
            return this.IntToStringFast(value);
        }

        /// <summary>
        /// Decode a string using this alphabet
        /// </summary>
        /// <param name="input">The string to decode</param>
        /// <returns>An integer decoded using this alphabet</returns>
        public abstract UInt64 Decode(string input);

    }
}
