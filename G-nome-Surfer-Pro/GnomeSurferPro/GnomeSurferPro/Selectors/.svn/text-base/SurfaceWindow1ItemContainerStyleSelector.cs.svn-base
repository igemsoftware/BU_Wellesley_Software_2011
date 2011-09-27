using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using GnomeSurferPro.ViewModels;

namespace GnomeSurferPro.Selectors
{
    class SurfaceWindow1ItemContainerStyleSelector :StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            FrameworkElement element = (FrameworkElement)container;
            if (item is ChromosomeBarViewModel)
                return element.FindResource("ChromosomeBarSVIStyle") as Style;
            else if (item is PublicationsViewModel)
                return element.FindResource("PublicationsSVIStyle") as Style;
            else if (item is ExtendedDesktopViewModel)
                return element.FindResource("ExtendedDesktopSVIStyle") as Style;
            else if (item is PublicationsArticleViewModel)
                return element.FindResource("PublicationsArticleSVIStyle") as Style;
            else if (item is TestSVIViewModel)
                return element.FindResource("TestSVIStyle") as Style;
            else if (item is SequenceViewModel)
                return element.FindResource("SeqTransSVIStyle") as Style;
            else if (item is TranslationViewModel)
                return element.FindResource("SeqTransSVIStyle") as Style;
            else if (item is NotesViewModel)
                return element.FindResource("GeneInfoSVIStyle") as Style;
            else if (item is SearchShelfViewModel)
                return element.FindResource("SearchShelfStyle") as Style;
            throw
                new Exception("could not select style for "+ item.ToString());
        }
    }
}
