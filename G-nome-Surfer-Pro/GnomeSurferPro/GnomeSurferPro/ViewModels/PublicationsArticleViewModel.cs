using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GenBank;
using GnomeSurferPro.Models;

namespace GnomeSurferPro.ViewModels
{
    class PublicationsArticleViewModel : ViewModelBase
    {
        private Publication _publicationArticle;
        private PublicationsViewModel _currentPubBoxVM;
        private Point _SVIcenter;
        private double _SVIorientation;
        

        public PublicationsArticleViewModel(Publication publicationArticle, PublicationsViewModel publicationsViewModel)
        {
            _publicationArticle = publicationArticle;
            _currentPubBoxVM = publicationsViewModel;
        }

        public String CurrentGeneTagandName
        {
            get
            {
                return _currentPubBoxVM.CurrentGeneTagandName;
            }
        }

        public Point SVICenter
        {
            get
            {
                return _SVIcenter;
            }
            set
            {
                _SVIcenter = value;
            }
        }

        public double SVIOrientation
        {
            get
            {
                return _SVIorientation;
            }
            set
            {
                _SVIorientation = value;
            }
        }

        public String Title
        {
            get
            {
                return _publicationArticle.Title;
            }
        }

        public String Authors
        {
            get
            {
                return _publicationArticle.Authors;
            }
        }

        public String PublicationAbstract
        {
            get
            {
                return _publicationArticle.PublicationAbstract;
            }
        }

    }
}
