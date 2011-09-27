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
using GnomeSurferPro.ViewModels;

namespace GnomeSurferPro.Views
{
    /// <summary>
    /// Interaction logic for PublicationsListBox.xaml
    /// </summary>
    public partial class PublicationsListBox : SurfaceUserControl
    {

        public PublicationsListBox()
        {
            InitializeComponent();
        }

        public PublicationsViewModel CurrentViewModel
        {
            get
            {
                return (PublicationsViewModel)this.DataContext; 
            }
        }

        private void PublicationsSurfaceListBox_DragEnter(object sender, SurfaceDragDropEventArgs e)
        {
            Console.WriteLine("PublicationsSurfaceListBox_DragEnter");
            //((PublicationsViewModel)this.DataContext).Routed_PublicationsSurfaceListBox_DragEnter(sender, e);
        }

        private void PublicationsSurfaceListBox_DragLeave(object sender, SurfaceDragDropEventArgs e)
        {
            Console.WriteLine("PublicationsSurfaceListBox_DragLeave");
            //((PublicationsViewModel)this.DataContext).Routed_PublicationsSurfaceListBox_DragLeave(sender, e);
        }

        private void PublicationsSurfaceListBox_Drop(object sender, SurfaceDragDropEventArgs e)
        {
            Console.WriteLine("PublicationsSurfaceListBox_Drop");
            //((PublicationsViewModel)this.DataContext).Routed_PublicationsSurfaceListBox_Drop(sender, e);
        }

        private void PublicationsSurfaceListBox_DragCompleted(object sender, SurfaceDragCompletedEventArgs e)
        {
            Console.WriteLine("PublicationsSurfaceListBox_DragCompleted");
            //((PublicationsViewModel)this.DataContext).Routed_PublicationsSurfaceListBox_DragCompleted(sender, e);
        }

        private void PublicationsSurfaceListBox_PreviewContactDown(object sender, ContactEventArgs e)
        {
            ((PublicationsViewModel)this.DataContext).Routed_PublicationsSurfaceListBox_PreviewContactDown(sender, e);
        }

        private void PublicationsSurfaceListBox_PreviewContactChanged(object sender, ContactEventArgs e)
        {
            ((PublicationsViewModel)this.DataContext).Routed_PublicationsSurfaceListBox_PreviewContactChanged(sender, e);
        }

        private void PublicationsSurfaceListBox_PreviewContactUp(object sender, ContactEventArgs e)
        {
           
            ((PublicationsViewModel)this.DataContext).Routed_PublicationsSurfaceListBox_PreviewContactUp(sender, e);
        }

        
    }
}
