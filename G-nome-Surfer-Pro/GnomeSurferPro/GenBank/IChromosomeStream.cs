using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBank
{
    public interface IChromosomeStream
    {
        int CurrentBasePair { get; set; }
        int TotalBasePairs { get; set; }
        int Version { get; set; }

        string AccessionID { get; set; }
        string Lineage { get; set; }
        string Name { get; set; }
        string Organism { get; set; }
        string Strain { get; set; }

        IList<IGene> GeneList { get; set; }

        IGene GetGeneByNameOrLocusTag(String name); // Returns null if no gene is found. Should be case insensitive.

        //IGene NextForwardGene(int i);
        //IGene NextReverseGene(int i);
        //IGene PreviousForwardGene(int i);
        //IGene PreviousReverseGene(int i);
    }
}
