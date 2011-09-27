using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using GenBank;

namespace GnomeSurferPro.Models
{
    public interface IPubMedService
    {
        IList<IPublication> GetResults(IGene currentGene);
    }
}
