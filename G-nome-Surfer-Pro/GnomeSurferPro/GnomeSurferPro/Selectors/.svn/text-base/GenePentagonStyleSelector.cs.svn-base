using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using GnomeSurferPro.ViewModels;

namespace GnomeSurferPro.Selectors
{
    class GenePentagonStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (item == null || element == null)
            {
                return null;
            }
            
            if (item is VisualGene && (item as VisualGene).Direction == VisualGene.GeneDirection.Forward)
            {
                return element.FindResource("ForwardGeneItemContainerStyle") as Style;
            }
            else if (item is VisualGene && (item as VisualGene).Direction == VisualGene.GeneDirection.Reverse)
            {
                return element.FindResource("ReverseGeneItemContainerStyle") as Style;
            }
            else if (item is VisualTickMark)
            {
                return element.FindResource("TickMarkItemContainerStyle") as Style;
            }
            else
            {
                return null;
            }
        }
    }
}
