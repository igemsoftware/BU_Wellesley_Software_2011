using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBank
{
    public class GeneImplementation : IGene
    {
        #region Private Variables
        private bool isForward = true;
        private bool isHypothetical = false;
        private int geneID, genInfoID, leftBasePair, rightBasePair;
        private string ecNumber, locusTag, name, note, product, proteinID, translation, sequence;
        #endregion

        #region Getters and Setters
        public bool IsForward
        {
            set { isForward = value; }
            get { return isForward; }
        }
        public bool IsHypothetical
        {
            set { isHypothetical = value; }
            get { return isHypothetical; }
        }

        public int GeneID
        {
            set { geneID = value; }
            get { return geneID; }
        }
        public int GenInfoID
        {
            set { genInfoID = value; }
            get { return genInfoID; }
        }
        public int LeftBasePair
        {
            set { leftBasePair = value; }
            get { return leftBasePair; }
        }
        public int RightBasePair
        {
            set { rightBasePair = value; }
            get { return rightBasePair; }
        }

        public string ECNumber
        {
            set { ecNumber = value; }
            get { return ecNumber; }
        }
        public string LocusTag
        {
            set { locusTag = value; }
            get { return locusTag; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Note
        {
            set { note = value; }
            get { return note; }
        }
        public string Product
        {
            set { product = value; }
            get { return product; }
        }
        public string ProteinID
        {
            set { proteinID = value; }
            get { return proteinID; }
        }
        public string Translation
        {
            set { translation = value; }
            get { return translation; }
        }
        public string Sequence
        {
            set { sequence = value; }
            get { return sequence; }
        }
        #endregion
    }
}
