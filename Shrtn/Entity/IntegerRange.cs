using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shrtn.Entity
{
    /// <summary>
    /// A simple start and end integer range. Do not want to use Enumerable
    /// Range and Linq because you must provide start and length, not end
    /// </summary>
    public class IntegerRange
    {
        public int Start { get; set; }
        public int End { get; set; }

        public IntegerRange (int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
