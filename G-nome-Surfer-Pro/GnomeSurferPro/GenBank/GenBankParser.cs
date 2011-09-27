using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenBank
{
    public class GenBankParser
    {
        //NOTE: StreamReader is faster than File.ReadAllLines for files with 20+ lines.
        private StreamReader reader;                
        private string line;

        private string[] lines, words, features;                      //arrays for storing parsed file and lines

        private char[] quotesDelimiter = { '"' };
        private char[] delimiters = { '=', '\r', '"' };
        private char[] geneDelimiters = { ' ', '.', '"', ':', '(', ')' };

        private int index, state;

        private IChromosomeStream _chromosome = new ChromosomeStreamImplementation();

        public IChromosomeStream Chromosome
        {
            get { return _chromosome; }
        }

        public GenBankParser(string _file)
        {
            this.state = 0;

            OpenFile(_file);
            ParseFile();
            CloseFile();
        }

        /// <summary>
        /// Opens the specified file, reads everything in as a stream, then splits the stream into
        /// an array of lines.
        /// </summary>
        /// <param name="_file"></param>
        public void OpenFile(string _file)
        {
            string directory = @"Resources\Genomes\" + _file + "_Chromosome.txt";
            reader = new StreamReader(@directory);
            string stream = reader.ReadToEnd();
            lines = stream.Split('\n');

            directory = @"Resources\Genomes\" + _file + "_Features.txt";
            reader = new StreamReader(@directory);
            stream = reader.ReadToEnd();
            features = stream.Split('\n');
        }

        public void ParseFile()
        {
            string tag;

            #region Chromosome Properties
            index = 0;
            while (state == 0)
            {
                line = lines[index];
                words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                tag = words[0];

                switch (tag)
                {
                    case "LENGTH":
                        words = words[1].Split(' ');
                        _chromosome.TotalBasePairs = Int32.Parse(words[0]);
                        break;
                    case "ACCESSION":
                        _chromosome.AccessionID = words[1];
                        break;
                    case "VERSION":
                        words = words[1].Split(':');
                        _chromosome.Version = Int32.Parse(words[1]);
                        break;
                    case "ORGANISM":
                        _chromosome.Organism = words[1];
                        break;
                    case "LINEAGE":
                        _chromosome.Lineage = words[1];
                        state = 1;
                        break;
                    default:
                        break;
                }
                index++;
            }
            #endregion

            #region Features
            index = 0;
            while (index < features.Length)
            {
                line = features[index];
                words = line.Split('=');
                tag = words[0];

                switch (tag)
                {
                    case "CDS":
                        addGene();
                        break;
                    case "tRNA":
                        addGene();
                        index--;
                        break;
                    case "PROMOTER":
                        addGene();
                        break;
                    case "TRANSLATION":
                        index++;
                        break;
                    case "ISCOMPLEMENT":
                        index--;
                        break;
                    default:
                        index++;
                        break;
                }
            }
            #endregion
        }

        private void addGene()
        {
            IGene gene = new GeneImplementation();
            state = 2;

            #region Start, Stop, and Direction
            words = words[1].Split(' ');
            gene.LeftBasePair = Int32.Parse(words[0]);
            gene.RightBasePair = Int32.Parse(words[1]);

            index++;
            line = features[index];
            words = line.Split('=');
            gene.IsForward = !Boolean.Parse(words[1].ToLower());
            #endregion

            index++;
            while (state == 2 && index < features.Length)
            {
                line = features[index];
                words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                switch (words[0])
                {
                    case "DNA":
                        gene.Sequence = words[1];
                        break;
                    case "GENE":
                        gene.Name = words[1];
                        break;
                    case "LOCUS_TAG":
                        gene.LocusTag = words[1];
                        break;
                    case "NOTE":
                        gene.Note = words[1];
                        break;
                    case "PRODUCT":
                        gene.Product = words[1];
                        if (gene.Product == "hypothetical protein")
                        {
                            gene.IsHypothetical = true;
                        }
                        break;
                    case "PROTEIN_ID":
                        gene.ProteinID = words[1];
                        break;
                    case "TRANSLATION":
                        gene.Translation = words[1];
                        state = 1;
                        break;
                    default:
                        state = 1;
                        break;
                }
                index++;
            }

            _chromosome.GeneList.Add(gene);
        }

        public void CloseFile()
        {
            Console.WriteLine("num genes: " + _chromosome.GeneList.Count);
            reader.Close();
        }
    }
}
