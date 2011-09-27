/// <Summary>
/// FILE:                   alignmentTests.cs
/// AUTHORS:                Casey Grote and Kelsey Tempel
/// DESCRIPTION:            Code for tests, including: deltaG, Self-Dimer, HeteroDimer and allignment. 
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
    class alignmentTests
    {

        private String _primerSequence;
        private String _otherSequence;
                
        ProcessStartInfo properties;
        Process process;

        //private String _dataDir;

        private List<String> alignedSequences;
       

        private StreamReader sr;


        public alignmentTests(String primerSequence)
        {
            _primerSequence = primerSequence;

              this.properties = new ProcessStartInfo("cmd.exe");  // run Command executable
            this.properties.CreateNoWindow = true;              // suppress opening of a UI
            this.properties.UseShellExecute = false;
            this.properties.RedirectStandardError = true;       // redirect the input, output, and errors through the Surface UI
            this.properties.RedirectStandardInput = true;
            this.properties.RedirectStandardOutput = true;
           

            this.process = new Process();
            
            alignedSequences= new List<String>();

        }


 
        /// <summary>
        /// Generates hairpin possibilites based on the primer sequence. 
        /// When processing with annealer.jar, first and last combos must be ommited because annealer.jar 
        /// requires 2 string arguments and does not take " ";
        /// </summary>
        /// <returns> String array of hairpin possibilites</returns>
        public String[] generateHairpinPossibilities()
        {
            String[] possibilities = new string[_primerSequence.Length];

            for (int i = 0; i < _primerSequence.Length; i++)
            {
                possibilities[i] = _primerSequence.Insert(i, " ");
            }

            return possibilities;
        }


        /// <summary>
        /// Generates the hairpin arguments to run through the command line. 
        /// Must eliminate first and last possibilities
        /// </summary>
        /// <param name="possibilities">String array of possible hairpins</param>
        /// <returns> String array of appropriate command line args</returns>
        public String[] generateHairpinArgs(String[] possibilities){
            String[] args = new String[possibilities.Length - 1];

            for(int i=1; i<args.Length+1;i++)
            {
                args[i - 1] = "java -jar Annealer.jar " + possibilities[i];
            }

            return args;
        }

        /// <summary>
        /// Runs the hairpin test via the command line. 
        /// </summary>
        /// <returns> double representing the worst case delta G value</returns>
        public double hairpinRun()
        {
            String[] hairpinPossibilities = generateHairpinPossibilities();
            String[] hairpinArgs = generateHairpinArgs(hairpinPossibilities);

            run(hairpinArgs);

            return worstCaseDeltaG();
        }

        /// <summary>
        /// Runs the Self-Dimer test via the command line. 
        /// </summary>
        /// <returns> double representing the worse case delta G</returns>
        public double selfDimerRun()
        {
            String[] selfDimerArgs = { "java -jar Annealer.jar " + _primerSequence +" "+_primerSequence};
            run(selfDimerArgs);
            return worstCaseDeltaG();
        }

        /// <summary>
        /// Runs the heterodimer test. 
        /// </summary>
        /// <param name="string">String of the other primer being checked against the current primer</param>
        /// <returns> double of the worst case delta G</returns>
        public double heteroDimerRun(String otherPrimer)
        {
            String[] heteroDimerArgs = { "java -jar Annealer.jar " + _primerSequence + " " + otherPrimer };
            run(heteroDimerArgs);
            return worstCaseDeltaG();
        }

        /// <summary>
        /// Runs given arguments (this code provides the backbone for multiple tests)
        /// Puts limit on number of results. Allignment must be more than half. 
        /// </summary>
        /// <param name="input">String array of possible hairpins</param>
        private void run(String[]input)
        {

            for (int i = 0; i < input.Length; i++)
            {
                process = Process.Start(properties);

                this.sr = process.StandardOutput;

  

                //balichRight
                process.StandardInput.WriteLine("cd ..\\");
                process.StandardInput.WriteLine("cd ..\\");
                process.StandardInput.WriteLine("cd ..\\");//up three directories

                process.StandardInput.WriteLine(@"cd PrimerDesigner\Resources\Annealer\dist"); // move to directory

                //process.StandardInput.WriteLine("cd");
                //Console.WriteLine(sr.ReadLine());

                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());
                //Console.WriteLine(sr.ReadLine());

                //labSurface
                //process.StandardInput.WriteLine(@"cd C:\Users\public Surface\Desktop\PrimerDesigner\PrimerDesigner\PrimerDesigner\Resources\Annealer\dist");

                //Console.WriteLine("navigated to .jar");


                process.StandardInput.WriteLine(input[i]);

                // Console.WriteLine(hairpinArgs[i]);


                //getting down to results in terminal
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();


                //first line of results is sequence;
                String sequence = sr.ReadLine();
                //Console.WriteLine(sequence);

                //second is "|"  or " " which indicates alignment or not. 
                String alignments = sr.ReadLine();
                //Console.WriteLine(alignments);

                sr.ReadLine();

                String processedSequence = "";


                for (int j = 0; j < alignments.Length; j++)
                {
                    if (alignments[j] != ' ')//only aligned basepairs are counted when calculating deltag
                        processedSequence += sequence[j];
                }

                if (processedSequence.Length > sequence.Length / 2)
                {
                    //takes only sequences where alignment occurs and alignment 
                    //is more than half the length of the original sequence
                    alignedSequences.Add(processedSequence);
                    //Console.WriteLine("PROCESSED: "+processedSequence);
                }

                process.Close();
            }
            //Console.WriteLine("closed"); 
        }


        /// <summary>
        /// Returns most negative result alignment tests.
        /// </summary>
        /// <returns> double represeing the worst case delta G based on the alligned sequences</returns>
        public double worstCaseDeltaG()
        {
            double worstCase = 0;
            for (int i = 0; i < alignedSequences.Count; i++)
            {
                double currentCaseDeltaG = calcDeltaG(alignedSequences[i]);
                if (currentCaseDeltaG < worstCase)
                    worstCase = currentCaseDeltaG;
            }
            return worstCase;
        }

        /// <summary>
        /// Calculates gibbs free energy for a processed string
        /// </summary>
        /// <param name="s">String whose delta G is being calculated</param>
        /// <returns> double representing delta G for inputed sequence</returns>
        public static Double calcDeltaG(String s)
        {
            Double toReturn = 0.0;
            if (s != null)
            {
                s = s.ToUpper();
                if (s.StartsWith("C") || s.StartsWith("G"))
                {
                    toReturn = toReturn + 0.98;
                }
                else
                {
                    toReturn = toReturn + 1.03;
                }
                if (s.EndsWith("C") || s.EndsWith("G"))
                {
                    toReturn = toReturn + 0.98;
                }
                else
                {
                    toReturn = toReturn + 1.03;
                }
                for (int i = 0; i < s.Length - 1; i++)
                {
                    String token = s.Substring(i, 2);
                    if (token.Equals("AA") || token.Equals("TT"))
                    {
                        toReturn = toReturn - 1.00;
                    }
                    else if (token.Equals("AT"))
                    {
                        toReturn = toReturn - 0.88;
                    }
                    else if (token.Equals("TA"))
                    {
                        toReturn = toReturn - -0.58;
                    }
                    else if (token.Equals("CA") || token.Equals("AC"))
                    {
                        toReturn = toReturn - 1.45;
                    }
                    else if (token.Equals("GT") || token.Equals("TG"))
                    {
                        toReturn = toReturn - 1.44;
                    }
                    else if (token.Equals("CT") || token.Equals("TC"))
                    {
                        toReturn = toReturn - 1.28;
                    }
                    else if (token.Equals("GA") || token.Equals("AG"))
                    {
                        toReturn = toReturn - 1.30;
                    }
                    else if (token.Equals("CG"))
                    {
                        toReturn = toReturn - 2.17;
                    }
                    else if (token.Equals("GC"))
                    {
                        toReturn = toReturn - 2.24;
                    }
                    else if (token.Equals("GG") || token.Equals("CC"))
                    {
                        toReturn = toReturn - 1.84;
                    }
                }

                //rounding
                toReturn = toReturn * 10;
                int toReturnInt = (int)toReturn;
                toReturn = (double)toReturnInt / (double)10;

                return toReturn;
            }

            return 0.00;
        }


    }
    }

