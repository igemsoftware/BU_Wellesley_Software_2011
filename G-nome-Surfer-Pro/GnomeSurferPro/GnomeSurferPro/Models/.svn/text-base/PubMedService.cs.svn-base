using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using GenBank;

namespace GnomeSurferPro.Models
{
    public class PubMedService : IPubMedService
    {
        public PubMedService()
        {
        }

        public IList<IPublication> GetResults(IGene gene)
        {
            //if (!String.IsNullOrEmpty(geneName))
            //{
            //    PubMedParser parser = new PubMedParser(geneName);
            //    return parser.getPublicationsFromHTML();
            //}

            //if the gene has a name, use name as keyword, else use Locus Tag (Locus Tag with no results
            //will be handled within getPublicationsFromHTML() from PubMedParser.cs
            if (!String.IsNullOrEmpty(gene.Name))
            {
                PubMedParser parser = new PubMedParser(gene.Name);
                return parser.getPublicationsFromHTML();
            }
            else if (!String.IsNullOrEmpty(gene.LocusTag))
            {
                PubMedParser parser = new PubMedParser(gene.LocusTag);
                return parser.getPublicationsFromHTML();
            }
            else
            {
                return new List<IPublication>();
            }
        }
    }
}
