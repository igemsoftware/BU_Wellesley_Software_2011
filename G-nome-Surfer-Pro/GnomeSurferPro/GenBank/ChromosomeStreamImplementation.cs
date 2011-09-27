using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBank
{
    class ChromosomeStreamImplementation : IChromosomeStream
    {
        private IList<IGene> geneList = new List<IGene>();

        private int currentBasePair, version, totalBasePairs;
        private string accessionID, lineage, name, organism, strain;

        public IList<IGene> GeneList
        {
            set { geneList = value; }
            get { return geneList; }
        }

        public int CurrentBasePair
        {
            set { currentBasePair = value; }
            get { return currentBasePair; }
        }
        public int Version
        {
            set { version = value; }
            get { return version; }
        }
        public int TotalBasePairs
        {
            set { totalBasePairs = value; }
            get { return totalBasePairs; }
        }

        public string AccessionID
        {
            set { accessionID = value; }
            get { return accessionID; }
        }
        public string Lineage
        {
            set { lineage = value; }
            get { return lineage; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Organism
        {
            set { organism = value; }
            get { return organism; }
        }
        public string Strain
        {
            set { strain = value; }
            get { return strain; }
        }

        public IGene GetGeneByNameOrLocusTag(string query)
        {
            Func<IGene, Boolean> predicate =
                (gene) =>
                {
                    if (!String.IsNullOrEmpty(gene.Name) && gene.Name.ToUpperInvariant().Equals(query.ToUpperInvariant()))
                    // Check if query matches gene name
                    {
                        return true;
                    }
                    else if (!String.IsNullOrEmpty(gene.LocusTag) && gene.LocusTag.ToUpperInvariant().Equals(query.ToUpperInvariant()))
                    // Check if query matches gene locus tag
                    {
                        return true;
                    }
                    return false;
                };
                // Predicate checks if gene name matches
                // expected name

            return GeneList.FirstOrDefault(predicate);  // Returns first IGene that matches name, or default if no 
                                                        // matching gene exists
        }


        //public IGene NextForwardGene(IGene g)
        //{
        //    int index = geneList.BinarySearch(g) + 1;
        //    IGene nextGene = geneList.ElementAt(index);
        //    if (!nextGene.IsForward) { NextForwardGene(index + 1); }
        //    return nextGene;
        //}
        //public IGene NextForwardGene(int i)
        //{
        //    IGene nextGene = geneList.ElementAt(i);
        //    if (!nextGene.IsForward) { NextForwardGene(i + 1); }
        //    return nextGene;
        //}

        //public IGene NextReverseGene(IGene g)
        //{
        //    int index = geneList.BinarySearch(g) + 1;
        //    IGene nextGene = geneList.ElementAt(index);
        //    if (nextGene.IsForward) { NextReverseGene(index + 1); }
        //    return nextGene;
        //}
        //public IGene NextReverseGene(int i)
        //{
        //    IGene nextGene = geneList.ElementAt(i);
        //    if (nextGene.IsForward) { NextReverseGene(i + 1); }
        //    return nextGene;
        //}

        //public IGene PreviousForwardGene(IGene g)
        //{
        //    int index = geneList.BinarySearch(g) - 1;
        //    IGene prevGene = geneList.ElementAt(index);
        //    if (!prevGene.IsForward) { PreviousForwardGene(index - 1); }
        //    return prevGene;
        //}
        //public IGene PreviousForwardGene(int i)
        //{
        //    IGene prevGene = geneList.ElementAt(i);
        //    if (!prevGene.IsForward) { PreviousForwardGene(i - 1); }
        //    return prevGene;
        //}

        //public IGene PreviousReverseGene(IGene g)
        //{
        //    int index = geneList.BinarySearch(g) - 1;
        //    IGene prevGene = geneList.ElementAt(index);
        //    if (prevGene.IsForward) { PreviousReverseGene(index - 1); }
        //    return prevGene;
        //}
        //public IGene PreviousReverseGene(int i)
        //{
        //    IGene prevGene = geneList.ElementAt(i);
        //    if (prevGene.IsForward) { PreviousReverseGene(i - 1); }
        //    return prevGene;
        //}
    }
}
