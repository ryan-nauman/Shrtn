using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn.Entity.Encoders;

namespace Shrtn.Entity
{
    public interface IBaseEncoderFactory
    {
        BaseEncoder GetEncoder(EncoderTypes encoderType);
    }
}
