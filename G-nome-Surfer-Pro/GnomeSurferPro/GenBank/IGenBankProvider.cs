using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenBank
{
    public interface IGenBankProvider
    {
        IChromosomeStream GetChromosome(string chromosomeId);
    }
}
