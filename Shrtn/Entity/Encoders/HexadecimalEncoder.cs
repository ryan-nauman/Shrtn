using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shrtn.Entity.Encoders
{
    public class HexadecimalEncoder : BaseEncoder
    {

        private static readonly char[] _characters = {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 
            'D', 'E', 'F'
        };

        public override char[] Characters
        {
            get { return _characters; }
        }

        public override ulong Decode(string input)
        {
            throw new NotImplementedException();
        }
    }
}
