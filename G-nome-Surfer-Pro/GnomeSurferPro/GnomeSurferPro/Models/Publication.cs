using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnomeSurferPro.Models
{
    public class Publication : IPublication
    {
        #region Instance Variables
        private String _title;
        private String _authors;
        private String _affiliation;
        private String _pubMedId;
        private String _publicationAbstract;
        private String _journal;
        private String _publicationDate;
        #endregion


        public Publication(String title, String authors, String affiliation, String pubMedId,
                            String publicationAbstract, String journal, String publicationDate)
        {
            _title = title;
            _authors = authors;
            _affiliation = affiliation;
            _pubMedId = pubMedId;
            _publicationAbstract = publicationAbstract;
            _journal = journal;
            _publicationDate = publicationDate;
        }
        

        public override string ToString()
        {
            return _journal + Environment.NewLine + _publicationDate + Environment.NewLine + _title +
                Environment.NewLine + _authors + Environment.NewLine + _affiliation + Environment.NewLine +
                _publicationAbstract + Environment.NewLine + _pubMedId;
        }

        //Property used to hold a reference to the SVI object that is being dragged
        public object DraggedElement
        {
            get;
            set;
        }

        public String Title 
        {
            get
            {
                return _title;
            }
        }

        public String Authors
        {
            get
            {
                return _authors;
            }
        }

        public String Affiliation
        {
            get
            {
                return _affiliation;
            }
        }

        public String PubMedId
        {
            get
            {
                return _pubMedId;
            }
        }

        public String PublicationAbstract
        {
            get
            {
                return _publicationAbstract;
            }
        }

        public String Journal
        {
            get
            {
                return _journal;
            }
        }

        public String PublicationDate
        {
            get
            {
                return _publicationDate;
            }
        }
    }
}
