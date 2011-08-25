using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Utility;

namespace Shrtn.Entity.Encoders
{
    /// <summary>
    /// Encode using unicode symbols
    /// </summary>
    /// <see cref="http://www.ssec.wisc.edu/~tomw/java/unicode.html"/>
    public class UnicodeSymbolsEncoder : BaseEncoder
    {
        #region Symbol ranges

        private readonly List<IntegerRange> _interestingRanges = new List<IntegerRange>() {
            new IntegerRange(8352, 8399), // Currency symbols
            new IntegerRange(8448, 8527), // Letterlike symbols
            new IntegerRange(8528, 8591), // Number forms
            new IntegerRange(8592, 8703), // Arrows
            new IntegerRange(8704, 8959), // Mathematical operators
            new IntegerRange(8960, 9215), // Miscellaneous technical 
            new IntegerRange(9312, 9331), // Encloes numeric
            new IntegerRange(9398, 9450), // Enclosed alpha
            new IntegerRange(9600, 9631), // Block elements
            new IntegerRange(9632, 9727), // Geometric shapes
            new IntegerRange(9728, 9983), // Miscellaneous symbols!
            new IntegerRange(9984, 10175), // Dingbats!
            new IntegerRange(12032, 12255), // Kangxi radicals 
            new IntegerRange(12352, 12447), // Hiragana 
            new IntegerRange(12448,  12543), // Katakana
            new IntegerRange(12544, 12591), // Bopomofo!
            new IntegerRange(12688, 12703), // Kanbun
        };

        private readonly List<IntegerRange> _symbolsOnly = new List<IntegerRange>() {
            //new IntegerRange(8592, 8703), // Arrows
            new IntegerRange(8592, 8682), // Arrows

            //new IntegerRange(9632, 9727), // Geometric shapes
            new IntegerRange(9632, 9711), // Geometric shapes

            //new IntegerRange(9728, 9983), // Miscellaneous symbols!
            new IntegerRange(9728, 9747), // Miscellaneous symbols!
            new IntegerRange(9754, 9839), // Miscellaneous symbols!

            //new IntegerRange(9985, 10175), // Dingbats!
            new IntegerRange(9985, 9988), // Dingbats!
            new IntegerRange(9990, 9993), // Dingbats!
            new IntegerRange(9996, 10023), // Dingbats!
            new IntegerRange(10025, 10059), // Dingbats!
            new IntegerRange(10061, 10061), // Dingbats!
            new IntegerRange(10063, 10066), // Dingbats!
            new IntegerRange(10070, 10070), // Dingbats!
            new IntegerRange(10072, 10078), // Dingbats!
            new IntegerRange(10102, 10132), // Dingbats!
            new IntegerRange(10136, 10159), // Dingbats!
            new IntegerRange(10161, 10174) // Dingbats!


        };

        #endregion

        public UnicodeSymbolsEncoder()
            : base(new [] {'b', 'o', 'g', 'u', 's'})
        {
            this.GenerateCharacters();
        }

        private void GenerateCharacters()
        {
            List<char> tempChars = new List<char>();

            foreach (IntegerRange range in _symbolsOnly)
            {
                for (int i = range.Start; i <= range.End; i++)
                {
                    tempChars.Add((char)i);
                }
            }

            base.SetCharacters(tempChars);
        }
    }
}
