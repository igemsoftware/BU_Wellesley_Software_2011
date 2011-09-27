/// <Summary>
/// FILE:                   BlastResult.cs
/// AUTHORS:                Casey Grote and Kelsey Tempel
/// DESCRIPTION:            Heavily copied if not exactly like existing class in GeneBrowse. 
///                         Currently not used. 
/// MODIFICATION HISTORY:   
/// </Summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
//using SurfaceApplication1;
using System.Threading;
using System.Windows.Input;

namespace PrimerDesigner
{
    public class BlastResult
    {

        Double bitScore, eValue, identity, score;
        int alignment, hitNum, hitFrame, hitStart, hitStop, queryFrame, queryStart, queryStop;
        String chromosome, midlines, hitSeq, querySeq;

        int or;
        static Random generator = new Random();

        public BlastResult(String chromosome, int hitNum, Double bitScore, Double score, Double eValue,
            int queryStart, int queryStop, int hitStart, int hitStop, int queryFrame, int hitFrame, 
            Double identity, int alignment, String querySeq, String hitSeq, String midlines)

        {
            this.chromosome = chromosome;
            this.hitNum = hitNum;
            this.bitScore = bitScore;
            this.score = score;
            this.eValue = eValue;
            this.queryStart = queryStart;
            this.queryStop = queryStop;
            this.hitStart = hitStart;
            this.hitStop = hitStop;
            this.queryFrame = queryFrame;
            this.hitFrame = hitFrame;
            this.identity = identity;
            this.alignment = alignment;
            this.querySeq = querySeq;
            this.hitSeq = hitSeq;
            this.midlines = midlines;
        }

        public String GetChromosome() { return chromosome; }
        //The score of chance, whether this reulst was by chance or related to evolution
        public Double GetEvalue() { return eValue; }
        //The percent alignment
        public Double GetIdentity() { return (identity / alignment * 100); }
        public int GetLength() { return alignment; }
        public int GetNum() { return hitNum; }
        public Double GetBitScore() { return bitScore; }
        //Combination of evalue, length, and percent alignment
        public Double GetScore() { return score; }
        public String GetMidlines() { return midlines; }

        public int GetHitFrame() { return hitFrame; }
        public String GetHitSeq() { return hitSeq; }
        public int GetHitStart() { return hitStart; }
        public int GetHitStop() { return hitStop; }

        public int GetQueryFrame() { return queryFrame; }
        public String GetQuerySeq() { return querySeq; }
        public int GetQueryStart() { return queryStart; }
        public int GetQueryStop() { return queryStop; }

        /// <summary>
        /// Setter for orientation
        /// Sets the scale (change in width) of the BlastResult for the ScatterViewItem created in the BlastInstance method of SurfaceWindow1.xaml.cs.
        /// </summary>
        /// <param name="s"></param>
        public void setOrient(int o) { or = o; }
        public int getOrient() { return or; }

        /// <summary>
        /// ToString method
        /// Formats the BlastResult instance as a String.
        /// </summary>
        /// <returns></returns>
        public String toString()
        {
            String matchPercent = Convert.ToString(identity / alignment * 100);
            String[] array = matchPercent.Split('.');
            return ("Chromosome " + chromosome + "\nLength: " + alignment + " base pairs\nAlignment: " + array[0] + " percent");
        }
    }
}
