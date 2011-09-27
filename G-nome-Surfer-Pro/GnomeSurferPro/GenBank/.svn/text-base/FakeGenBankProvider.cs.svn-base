using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBank
{
	public class FakeGenBankProvider : IGenBankProvider
	{
        public IChromosomeStream GetChromosome(string chromosomeId)
        {
            IList<IGene> genes = new List<IGene>();
            string prefix = chromosomeId.Substring(chromosomeId.Length > 3 ? chromosomeId.Length - 3 : 0);
            int totalGenes = 100;
            int namedGeneInterval = 10;
            int geneLength = 800;
            int geneMargin = 200;
            string sequence = "gattacagattacagattacagattacagattacagattacagattacagattacagattacagattacagattacagattacagattacagattacagattacagattaca";
            string translation = "LSASTDUGQWEJHRHWGESBDFKJGHSUIDTDHFGJWHEGRTWEHJDGVFJHSDGBFNMWEBRIYTQTWUWERUOUSDPFSYOZSDJKFHOIUER";
            for (int i = 0; i < totalGenes; i++)
            {
                String name = (i % namedGeneInterval == 0) ? ("kR" + i.ToString()) : null;

                IGene gene = new GeneImplementation();
                gene.LocusTag = prefix + i.ToString();
                gene.LeftBasePair = (geneLength + geneMargin) * i + geneMargin;
                gene.RightBasePair = gene.LeftBasePair + geneLength;
                gene.Sequence = sequence;
                gene.Name = name;
                gene.Translation = translation;
                genes.Add(gene);

                IGene reverseGene = new GeneImplementation();
                reverseGene.LocusTag = prefix + i.ToString();
                reverseGene.LeftBasePair = (geneLength + geneMargin) * i + geneMargin;
                reverseGene.RightBasePair = gene.LeftBasePair + geneLength;
                reverseGene.IsForward = false;
                reverseGene.Sequence = sequence;
                reverseGene.Name = name;
                reverseGene.Translation = translation;
                genes.Add(reverseGene);
            }

            IChromosomeStream stream = new ChromosomeStreamImplementation();
            stream.GeneList = genes;
            stream.TotalBasePairs = totalGenes * (geneLength + geneMargin) + geneMargin;
            return stream;
        }
    }
}
