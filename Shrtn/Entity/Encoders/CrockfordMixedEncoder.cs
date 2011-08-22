using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Utility;

namespace Shrtn.Entity.Encoders
{
    public class CrockfordMixedEncoder : BaseEncoder
    {
        private static readonly char[] _characters = {
            '5', 'm', 'y', 'B', 'C', 'd', 'n', 'q', 'r', 'v', 'z', 'A', 'D', 
            'K', 'M', '0', '8', 'c', 'E', 'S', 'V', 'W', 'a', 'g', 'k', 'P', 
            '7', 'h', 'w', 'F', '-', '3', '4', '6', 'b', 't', 'x', 'J', 'Y', 
            '_', '1', 'e', 'f', 'p', 's', 'T', 'Z', '2', '9', 'j', 'G', 'H', 
            'N', 'Q', 'R', 'X'
        };

        public override char[] Characters
        {
            get { return _characters; }
        }

        //public override string Encode(ulong input)
        //{
        //    throw new NotImplementedException();
        //}

        public override ulong Decode(string input)
        {
            throw new NotImplementedException();
        }
    }
}
