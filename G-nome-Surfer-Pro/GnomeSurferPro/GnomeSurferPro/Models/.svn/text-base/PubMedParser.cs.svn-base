using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.Collections;
using System.IO;

namespace GnomeSurferPro.Models
{
    public class PubMedParser
    {
        #region Instance Variables
        private String _geneKeyword;
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public PubMedParser(String geneKeyword)
        {
            this._geneKeyword = geneKeyword;
        }

        public String getHTML()
        {
            //Web client gets the HTML from PubMed's server
            WebClient client = new WebClient();
            return client.DownloadString("http://www.ncbi.nlm.nih.gov/pubmed?term=" 
                + _geneKeyword + "&dispmax=200&report=Abstract"); //articles sorted by Recently Added
        }

        public IList<IPublication> getPublicationsFromHTML()
        {
            String allHTML = getHTML();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(allHTML);

            IList<IPublication> publicationList = new List<IPublication>();

            //Check to see if <li class='warn'> exists in HTML, if true, then current keyword returned no results
            if (((htmlDoc.DocumentNode.SelectNodes("//li[@class='warn']") != null) )|| (htmlDoc.DocumentNode.SelectNodes("//li[@class='error']")) != null)
            {
               //do nothing 
            }
                //if has div class='rprt_all', then keyword returns 1 result, has different format
            else if (!(htmlDoc.DocumentNode.InnerHtml.Contains("result_count")))
            {
                //publicationResults represents one article's block in PubMed
                var publicationResults = from rslt in htmlDoc.DocumentNode.SelectNodes("//div[@class='rprt abstract']") select rslt;
                foreach (HtmlNode i in publicationResults)
                {
                    //Find article's info by looking up tags. First check to see if the tag exists (some articles
                    //do not have affiliation or abstract)
                    String journal = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='cit']"))) ? "" : i.SelectSingleNode("./div[@class='cit']").SelectSingleNode("./a").InnerText;
                    String publicationDate = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='cit']"))) ? "" : i.SelectSingleNode("./div[@class='cit']").SelectSingleNode("./text()").InnerText;
                    String title = !(i.ChildNodes.Contains(i.SelectSingleNode("./h1"))) ? "" : i.SelectSingleNode("./h1").InnerText;
                    String authors = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='auths']"))) ? "" : i.SelectSingleNode("./div[@class='auths']").InnerText;
                    String affiliation = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='aff']"))) ? "" : i.SelectSingleNode("./div[@class='aff']").SelectSingleNode("./p").InnerText;
                    String pubMedId = i.SelectSingleNode("./div[@class='aux']").SelectSingleNode("./div[@class='resc']").SelectSingleNode("./dl[@class='rprtid']").SelectSingleNode("./dd").InnerText;
                    //pubMedId doesn't need a check because there will always be a PMID
                    String publicationAbstract = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='abstr']"))) ? "" : i.SelectSingleNode("./div[@class='abstr']").InnerText;
                    //If there is a publication Abstract, separate out the "Abstract" at the beginning of all entries by adding a space
                    publicationAbstract = !(publicationAbstract == "") ? publicationAbstract.Insert(8, ": " + Environment.NewLine) : "";

                    Publication currentPublication = new Publication(title, authors, affiliation, pubMedId, publicationAbstract, journal, publicationDate);
                    publicationList.Add(currentPublication);
                }
            
            
            
            }
            else//if no warning messages appear, then results exist for current keyword
            {
                //publicationResults represents one article's block in PubMed
                var publicationResults = from rslt in htmlDoc.DocumentNode.SelectNodes("//div[@class='rslt']") select rslt;
                foreach (HtmlNode i in publicationResults)
                {
                    //Find article's info by looking up tags. First check to see if the tag exists (some articles
                    //do not have affiliation or abstract)
                    String journal = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='cit']"))) ? "" : i.SelectSingleNode("./div[@class='cit']").SelectSingleNode("./a").InnerText;
                    String publicationDate = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='cit']"))) ? "" : i.SelectSingleNode("./div[@class='cit']").SelectSingleNode("./text()").InnerText;
                    String title = !(i.ChildNodes.Contains(i.SelectSingleNode("./h1"))) ? "" : i.SelectSingleNode("./h1").InnerText;
                    String authors = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='auths']"))) ? "" : i.SelectSingleNode("./div[@class='auths']").InnerText;
                    String affiliation = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='aff']"))) ? "" : i.SelectSingleNode("./div[@class='aff']").SelectSingleNode("./p").InnerText;
                    String pubMedId = i.SelectSingleNode("./div[@class='aux']").SelectSingleNode("./div[@class='resc']").SelectSingleNode("./dl[@class='rprtid']").SelectSingleNode("./dd").InnerText;
                    //pubMedId doesn't need a check because there will always be a PMID
                    String publicationAbstract = !(i.ChildNodes.Contains(i.SelectSingleNode("./div[@class='abstr']"))) ? "" : i.SelectSingleNode("./div[@class='abstr']").InnerText;
                    //If there is a publication Abstract, separate out the "Abstract" at the beginning of all entries by adding a space
                    publicationAbstract = !(publicationAbstract == "") ? publicationAbstract.Insert(8, ": " + Environment.NewLine) : "";

                    Publication currentPublication = new Publication(title, authors, affiliation, pubMedId, publicationAbstract, journal, publicationDate);
                    publicationList.Add(currentPublication);
                }
            }
            
            return publicationList;
        }
    }
}
