using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shrtn.Utility
{
    public static class Math
    {
        public static ulong Pow(ulong x, ulong y)
        {
            if (y == 0) return 1;
            ulong count = x;
            for (ulong i = 0; i < y - 1; i++)
            {
                count = x * count;
            }
            return count;
        }
    }
}
