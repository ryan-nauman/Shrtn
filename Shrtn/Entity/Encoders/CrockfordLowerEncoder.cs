using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Utility;

namespace Shrtn.Entity.Encoders
{
    public class CrockfordLowerEncoder : BaseEncoder
    {
        private static readonly char[] _characters = {
            '0', '2', 'c', 'h', 'j', 'p', 'r', 's', 'w', 'y', '_', '1', '4', 
            '5', 'a', 'g', 'k', 'n', '-', '3', '6', '7', '8', '9', 'b', 'e', 
            'f', 'q', 't', 'x', 'z', 'd', 'm', 'v'
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
