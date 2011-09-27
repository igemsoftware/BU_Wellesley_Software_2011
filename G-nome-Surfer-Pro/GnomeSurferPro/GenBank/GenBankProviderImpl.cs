using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBank
{
    public class GenBankProviderImpl : IGenBankProvider
    {

        IChromosomeStream IGenBankProvider.GetChromosome(string chromosomeId)
        {
            GenBankParser parser = new GenBankParser(chromosomeId);
            return parser.Chromosome;
        }
    }
}
