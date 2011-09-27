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
    /// Interaction logic for SequenceView.xaml
    /// </summary>
    public partial class SequenceView : SurfaceUserControl
    {
        public SequenceView()
        {
            InitializeComponent();
            //((SequenceViewModel)this.DataContext).MySurfaceScrollViewer = this.SequenceScrollViewer;
            //reference the scrollviewer in the view model
        }

        private void SurfaceUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
