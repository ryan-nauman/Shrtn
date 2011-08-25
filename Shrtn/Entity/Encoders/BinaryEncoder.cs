using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shrtn.Entity.Encoders
{
    public class BinaryEncoder : BaseEncoder
    {
        private static readonly char[] _characters = {
            '0', '1'
        };

        public BinaryEncoder()
            : base(_characters) { }
    }
}
