using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using GnomeSurferPro.ViewModels;
using Microsoft.Surface.Presentation.Controls;
using GnomeSurferPro.Models;

namespace GnomeSurferPro.Selectors
{
    class ExtendedDesktopTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = (FrameworkElement)container;

            //if (item is IPublication)
            //    return element.FindResource("PublicationsSVIDataTemplate") as DataTemplate;
            //else if (item is ScatterViewItem)
            //    return ((ScatterView)((ScatterViewItem)item).Parent).ItemTemplate as DataTemplate;
            //throw
            //    new Exception("could not select template for " + item.ToString());

            if (item is PublicationsArticleViewModel)
                return element.FindResource("PublicationsSVIDataTemplate") as DataTemplate;
            else if (item is ChromosomeBarViewModel)
                return element.FindResource("ChromosomeBarTemplate") as DataTemplate;
            else if (item is PublicationsViewModel)
                return element.FindResource("PublicationsTemplate") as DataTemplate;
            else if (item is ExtendedDesktopViewModel)
                return element.FindResource("ExtendedDesktopTemplate") as DataTemplate;
            else if (item is TestSVIViewModel)
                return element.FindResource("TestSVITemplate") as DataTemplate;
            else if (item is SequenceViewModel)
                return element.FindResource("SequenceTemplate") as DataTemplate;
            else if (item is TranslationViewModel)
                return element.FindResource("TranslationTemplate") as DataTemplate;
            else if (item is NotesViewModel)
                return element.FindResource("NotesTemplate") as DataTemplate;
            throw
                new Exception("could not select template for " + item.ToString());

        }
    }
}
