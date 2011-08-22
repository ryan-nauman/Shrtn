using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Entity.Encoders;

namespace Shrtn.Entity
{
    internal class EncoderFactory : IBaseEncoderFactory
    {
        public BaseEncoder GetEncoder(EncoderTypes encoderType)
        {
            BaseEncoder encoder = null;

            switch (encoderType)
            {
                case EncoderTypes.CrockfordLower:
                    encoder = new CrockfordLowerEncoder();
                    break;
                case EncoderTypes.CrockfordMixed:
                    encoder = new CrockfordMixedEncoder();
                    break;
                case EncoderTypes.ZBase32:
                    encoder = new ZBase32Encoder();
                    break;
                case EncoderTypes.Hexadecimal:
                    encoder = new HexadecimalEncoder();
                    break;
                default:
                    throw new ArgumentException("Encoder type not registered");
            }

            return encoder;
        }
    }
}
