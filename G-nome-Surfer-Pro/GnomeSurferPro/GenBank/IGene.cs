using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBank
{
    public interface IGene
    {
        bool IsForward { get; set; }
        bool IsHypothetical { get; set; }

        int LeftBasePair { get; set; }
        int RightBasePair { get; set; }

        string LocusTag { get; set; }
        string Name { get; set; }
        string Note { get; set; }
        string Product { get; set; }
        string ProteinID { get; set; }
        string Sequence { get; set; }
        string Translation { get; set; }
    }
}
