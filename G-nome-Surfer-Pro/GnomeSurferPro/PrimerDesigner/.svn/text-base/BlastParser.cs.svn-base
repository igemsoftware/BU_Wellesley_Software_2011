/// <Summary>
/// FILE:                   BlastParser.cs
/// AUTHORS:                Megan Strait
/// DESCRIPTION:            Parses the xml files produced from running blastall.exe of a query sequence against a 
///                         genome; results start at line 27 of the file and are spaced evenly at 11 lines per result
/// MODIFICATION HISTORY:    
///                         22 Mar 2010 Getters and setters completed.
///                         30 May 2010 Issues with refreshing the query and sbjct variables fixed (also fixes 
///                                     CompareByLength method).
///                         16 Jun 2010 Updated file to parse xml instead of txt files in response to change in output
///                                     of the blastall executable to xml.
/// </Summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Resources;
using System.Windows;

namespace PrimerDesigner
{
    class BlastParser
    {
        private int alignment, chromosomeCount, hitFrame, hitNum, hitStart, hitStop, queryFrame, queryStart, queryStop;
        private Double bitScore, eValue, identity, score;
        private String chr, directory, filename, midlines, hitSeq, querySeq;

        private List<ResultSVI>[] _blastResults = new List<ResultSVI>[5]; 

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public BlastParser(String[] genomes)
        {
            String[] tbGenomes = genomes;
            // fill array with List of ResultSVIs
            for (int i = 0; i < genomes.Length; i++)
            {
                _blastResults[i] = ReadFile (tbGenomes[i]);
            }
        }

        public List<ResultSVI>[] blastResults
        {
            get
            {
                return _blastResults;
            }
        }


        // traverses xml file for results. Add each result to List. Return List.
        public List<ResultSVI> ReadFile(String filename)
        {
            //C:\Users\orit44\Desktop\PrimerDesigner\PrimerDesigner\Resources
            List<ResultSVI> blastResults = new List<ResultSVI>(); 
            try
            {
                //Uri uri = new Uri("C:\\Users\\orit44\\Desktop\\PrimerDesigner\\PrimerDesigner\\Resources\\blast_results_" + filename+".xml", UriKind.Relative);
                
                //Uri uri = new Uri("\\Resources\\blast_results_" + filename + ".xml", UriKind.Relative);

                //Console.WriteLine(uri);
               // StreamResourceInfo info = System.Windows.Application.GetContentStream(uri);
                //StreamResourceInfo info = Application.GetResourceStream(uri);
                
                //XmlTextReader reader = new XmlTextReader(info.Stream);
                //Uri uri = new Uri("\\PrimerDesigner\\Resources\\blast_results_" + filename + ".xml", UriKind.Relative);
                //Console.WriteLine(uri);
                //Console.WriteLine(uri == null);
                //StreamResourceInfo info = new StreamResourceInfo();


                //StreamResourceInfo info = Application.GetResourceStream(uri);

                //XmlTextReader reader = new XmlTextReader(info.Stream);





                //###################################BalichRight
                //XmlTextReader reader = new XmlTextReader("C:\\Users\\orit44\\Desktop\\GnomeSurferPro\\PrimerDesigner\\Resources\\blast_results_"
                    //+ filename + ".xml");

                //#########################################labSurface
                XmlTextReader reader = new XmlTextReader(" C:\\Users\\public Surface\\Desktop\\PrimerDesigner\\PrimerDesigner\\PrimerDesigner\\Resources\\blast_results_"
                    + filename + ".xml");








                // Skips all unimportant info and goes straight to tags with name "Hsp" (start of first result)
                for (int i = 0; reader.ReadToFollowing("Hsp"); i++)
                {
                    //Console.WriteLine(i);
                    // for every result
                    reader.ReadToFollowing("Hsp_num");
                    reader.Read();                              // go to values inside the <Hsp_num> tag
                    hitNum = Int32.Parse(reader.Value);         // stores current hit number

                    reader.ReadToFollowing("Hsp_bit-score");
                    reader.Read();                              // go to the next node, which contains the bit-score
                    bitScore = Double.Parse(reader.Value);

                    reader.ReadToFollowing("Hsp_score");
                    reader.Read();                              // go to score
                    score = Double.Parse(reader.Value);

                    reader.ReadToFollowing("Hsp_evalue");
                    reader.Read();                              // go to e-value
                    eValue = Double.Parse(reader.Value);

                    reader.ReadToFollowing("Hsp_query-from");
                    reader.Read();                              // get the query start and stop
                    queryStart = Int32.Parse(reader.Value);
                    reader.ReadToFollowing("Hsp_query-to");
                    reader.Read();                              
                    queryStop = Int32.Parse(reader.Value);

                    reader.ReadToFollowing("Hsp_hit-from");
                    reader.Read();                              // get the hit's start and stop
                    hitStart = Int32.Parse(reader.Value);
                    reader.ReadToFollowing("Hsp_hit-to");
                    reader.Read();
                    hitStop = Int32.Parse(reader.Value);

                    reader.ReadToFollowing("Hsp_query-frame");
                    reader.Read();                              // get the query and hit frames
                    queryFrame = Int16.Parse(reader.Value);
                    reader.ReadToFollowing("Hsp_hit-frame");
                    reader.Read();
                    hitFrame = Int16.Parse(reader.Value);

                    reader.ReadToFollowing("Hsp_identity");
                    reader.Read();                              // get the hit identity and alignment values
                    identity = Double.Parse(reader.Value);
                    reader.ReadToFollowing("Hsp_align-len");
                    reader.Read();                              
                    alignment = Int32.Parse(reader.Value);

                    reader.ReadToFollowing("Hsp_qseq");
                    reader.Read();                              // get the query and hit sequences, and midlines
                    querySeq = reader.Value;
                    reader.ReadToFollowing("Hsp_hseq");
                    reader.Read();
                    hitSeq = reader.Value;
                    reader.ReadToFollowing("Hsp_midline");
                    reader.Read();
                    midlines = reader.Value;

                    ResultSVI result = new ResultSVI(chr, hitNum, bitScore, score, eValue, queryStart, queryStop,
                        hitStart, hitStop, queryFrame, hitFrame, identity, alignment, querySeq, hitSeq, midlines);
                    if(result.GetBitScore()>25)
                        blastResults.Add(result);
                }
            }
            catch (Exception x)
            {
                //Console.WriteLine("Error! Current gene does not exist in website database.");
                Console.WriteLine(x);
            }
            return blastResults; 
        }
    }
}
