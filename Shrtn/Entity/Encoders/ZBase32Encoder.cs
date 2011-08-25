using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Utility;

namespace Shrtn.Entity.Encoders
{
    public class ZBase32Encoder : BaseEncoder
    {
        private static readonly char[] _characters = {
            'b', 'd', '8', 'k', 'm', 'p', 'x', 't', '1', 'w', 'i', 'z', 'a', 
            '5', 'h', '7', '6', '9', '_', 'y', 'n', 'r', 'f', 'g', 'e', 'j', 
            'c', 'q', 'o', 'u', 's', '3', '4', '-'
        };

        public ZBase32Encoder()
            : base(_characters) { }
    }
}
