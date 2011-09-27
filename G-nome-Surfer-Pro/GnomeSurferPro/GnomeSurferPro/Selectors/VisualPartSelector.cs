using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using GnomeSurferPro.ViewModels;

// See http://msdn.microsoft.com/en-us/library/ms742521.aspx#Styling_StyleSelection
namespace GnomeSurferPro.Selectors
{
    public class VisualPartSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                if (item is VisualGene)
                {
                    return element.FindResource("GenePartDataTemplate") as DataTemplate;
                }
                else if (item is VisualTickMark)
                {
                    return element.FindResource("TickMarkDataTemplate") as DataTemplate;
                }
            }
            return null;
        }
    }
}
