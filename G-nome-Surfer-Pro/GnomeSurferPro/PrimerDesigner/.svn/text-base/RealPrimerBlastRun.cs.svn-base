/// <Summary>
/// FILE:                   RealPrimerBlastRun.cs
/// AUTHORS:                Kelsey Tempel and Casey Grote
/// DESCRIPTION:            Gets sequences and runs primer blast. 
///                         REMEMBER: May need to adjust file paths before running.
/// 
/// MODIFICATION HISTORY:   

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PrimerDesigner
{
    class RealPrimerBlastRun
    {
        ProcessStartInfo properties;
        Process process;

        private String _primerSeq;
        private String _dataDir;

        private String[] makeArgsArray;
        private String[] blastArgsArray;

        private String[] _tbGenomes; 


        public RealPrimerBlastRun (String primerSequence, String[] genomes)
        {
            //start process 
            this.properties = new ProcessStartInfo("cmd.exe");  // run Command executable
            this.properties.CreateNoWindow = true;              // suppress opening of a UI
            this.properties.UseShellExecute = false;
            this.properties.RedirectStandardError = true;       // redirect the input, output, and errors through the Surface UI
            this.properties.RedirectStandardInput = true;
            this.properties.RedirectStandardOutput = true;

            this.process = new Process();

            this._primerSeq = primerSequence;
            

            //Adjust appropriately #############################################################################

            //balichRight
            //this._dataDir = @"C:\Users\orit44\Desktop\GnomeSurferPro\PrimerDesigner\";
           
            //lab surface
            this._dataDir = @"C:\Users\public Surface\Desktop\GnomeSurferPro\GnomeSurferPro\PrimerDesigner\";



            String description = "Added on: " + DateTime.Now; 
            
            //tb genomes files (5)
            //String tb1 = "CDC1551";
            //String tb2 = "F11";
            //String tb3 = "H37Ra";
            //String tb4 = "H37Rv";
            //String tb5 = "K7N1435";
            //_tbGenomes[0] = tb1;
            //_tbGenomes[1] = tb2;
            //_tbGenomes[2] = tb3;
            //_tbGenomes[3] = tb4;
            //_tbGenomes[4] = tb5;
            _tbGenomes = genomes; 

            WriteSequenceText(_primerSeq); // write inputted primer sequence to text doc
            makeArgsArray = MakeBlastDB(_tbGenomes); // get args to create db files for tb genome
            blastArgsArray = BlastArgs(_tbGenomes); // get args to call blast                
        }


        //getter and setter for tbGenomes
        public String[] tbGenomes
        {
            get
            {
                return _tbGenomes;
            }
            
        }


        /// <summary>
        /// Writes the inputted sequence to a text file. We will write to the GnomesFolder
        /// in the bin folder of the executable. Used for Primer Sequence
        /// </summary>
        /// <param name="sequence">String of the DNA sequence being written to file</param>
        public void WriteSequenceText(String sequence)
        {
            using (StreamWriter sw = new StreamWriter(_dataDir + @"Resources\primer_source.txt"))
            {
                sw.WriteLine(">gnl|primer_source.txt|Description");
                sw.Write(sequence); 
            }
        }

        // longshot attempt to save as fasta
        public void WriteSequenceFasta(String sequence, String filename, String description)
        {
            using (StreamWriter sw = new StreamWriter(_dataDir + "GnomesFolder\filename.fasta"))
            {
                sw.WriteLine(">gnl|" + filename + "|" + description);
                sw.Write(sequence);
            }
        }


        /// <summary>
        /// Specifies argements for the makeblastbd command. 
        /// </summary>
        /// <param name="genomes">String array of genomes being made into databases</param>
        /// <returns> String array of appropriate command line args</returns>
        public String[] MakeBlastDB(String[] genomes)
        {
            String[] makeArgs = new String[5]; 
            for (int i = 0; i < genomes.Length; i++)
            {
                String args = "makeblastdb -in " + _dataDir + "Resources\\" + genomes[i] + ".fasta" +
                           " -parse_seqids -dbtype nucl ";
                makeArgs[i] = args;
                Console.WriteLine(args); 
            }
            return makeArgs; 
        }

        /// <summary>
        /// Specifies arguments for BLAST results for all five TB genomes. Format ex: blast_results_CDC1551.xml
        /// </summary>
        /// <param name="genomes">String array of genomes being made into databases</param>
        /// <returns> String array of appropriate command line args</returns>
        public String[] BlastArgs(String[] genomes)
        {
            String[] blastArgs = new String[5];
            for (int i = 0; i < genomes.Length; i++)
            {
                String args = "blastall -p blastn -d " + _dataDir + @"Resources\" + genomes[i] + ".fasta"
                      + " -i " + _dataDir + @"Resources\primer_source.txt"
                      + " -o " + _dataDir + @"Resources\blast_results_" + genomes[i] +".xml"
                      + " -m 7 -b 10"; 
                blastArgs[i] = args;
                Console.WriteLine(args); 
            }
            return blastArgs; 
        }

        /// <summary>
        /// Starts a new Command process.
        /// </summary>
        public void Run()
        {

            for (int i = 0; i < makeArgsArray.Length; i++)
            {
                process = Process.Start(properties);

                process.StandardInput.WriteLine("cd ..\\");
                process.StandardInput.WriteLine("cd ..\\");
                process.StandardInput.WriteLine("cd ..\\");//up three directories
                process.StandardInput.WriteLine(@"cd PrimerDesigner\Executable\blast-2.2.25+\bin"); // move to directory

                process.StandardInput.WriteLine(makeArgsArray[i]);
                process.StandardInput.WriteLine(blastArgsArray[i]);

               // process.StandardInput.WriteLine(@"EXIT");
                process.WaitForExit(1000); // so that BLAST has time to run...may be better soln
                process.Close();
            }

            //Console.WriteLine("closed"); 
        }



    }

}
