using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using LinqToVisualTree;
using GnomeSurferPro.ViewModels;

namespace GnomeSurferPro.Views
{
    /// <summary>
    /// Interaction logic for ChromosomeBar.xaml
    /// </summary>
    public partial class ChromosomeBar : SurfaceUserControl
    {
        private ChromosomeBarViewModel ViewModel
        {
            get { return (ChromosomeBarViewModel)this.DataContext; }
        }

        public ChromosomeBar()
        {
            InitializeComponent();
        }

        private void GenePentagon_PreviewContactDown(object sender, ContactEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            VisualGene visualGene = (VisualGene) element.DataContext;
            ViewModel.SelectedGene = visualGene.Model;

            //// Bring gene pentagon to the front of the chromosome bar
            //// so the elementmenu will appear in front of other gene pentagons
            //SurfaceListBoxItem container = this.GetListBoxItem(element);
            //container.SetValue(Panel.ZIndexProperty, _maxZIndex);
            //_maxZIndex++;

            Rect contactPosition = e.Contact.BoundingRect;
            ViewModel.GenePentagonContacted(contactPosition, visualGene.Direction);
        }

        private SurfaceListBoxItem GetListBoxItem(DependencyObject item)
        {
            SurfaceListBoxItem container = item as SurfaceListBoxItem;
            while (container == null)
            {
                item = VisualTreeHelper.GetParent(item);
                container = item as SurfaceListBoxItem;
            }

            return container;
        }

        private void SurfaceScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ViewModel.ScrollBarChanged();
        }
    }
}
