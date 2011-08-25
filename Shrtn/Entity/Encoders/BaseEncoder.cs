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
        #region Properties

        /// <summary>
        /// Get the characters of this alphabet and the correpsonding index
        /// </summary>
        public virtual Dictionary<char, int> CharactersToValues { get; protected set; }

        /// <summary>
        /// Get the characters of this alphabet
        /// </summary>
        /// <returns>The characters this alphabet composes of</returns>
        public char[] Characters
        {
            get
            {
                return this.CharactersToValues.Keys.ToArray<char>();
            }
        }

        #endregion

        #region Constructors

        public BaseEncoder(IEnumerable<char> characters)
        {
            this.CharactersToValues = characters.Select((c, i) => new { Value = c, Index = i }).ToDictionary(x => x.Value, x => x.Index);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set the alphabet characters late. In the case that a child class needs to
        /// preform some pre-processing to generate an alphabet set allow them to pass 
        /// the IEnumerable character set here and instead pass some dummy values to 
        /// the constructor.
        /// </summary>
        /// <param name="characters">The alphabet</param>
        public virtual void SetCharacters(IEnumerable<char> characters)
        {
            this.CharactersToValues = characters.Select((c, i) => new { Value = c, Index = i }).ToDictionary(x => x.Value, x => x.Index);
        }

        /// <summary>
        /// Encode a string using this alphabet
        /// </summary>
        /// <param name="input">The int to encode</param>
        /// <returns>A string encoded using this alphabet</returns>
        public string Encode(ulong value)
        {
            return this.IntToStringFast(value);
        }

        /// <summary>
        /// Decode a string using this alphabet
        /// </summary>
        /// <param name="encodedValue">The string to decode</param>
        /// <returns>An integer decoded using this alphabet</returns>
        public ulong Decode(string encodedValue)
        {
            return this.StringToIntFast(encodedValue);
        }

        #endregion
    }
}
