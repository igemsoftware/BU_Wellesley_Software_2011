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
    /// Interaction logic for TranslationView.xaml
    /// </summary>
    public partial class TranslationView : SurfaceUserControl
    {
        public TranslationView()
        {
            InitializeComponent();
            //((TranslationViewModel)this.DataContext).MySurfaceScrollViewer = this.TranslationScrollViewer;
            //reference the scrollviewer in the view model
        }

        //private void SurfaceScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        //{
        //    ((TranslationViewModel)this.DataContext).Routed_SurfaceScrollViewer_ScrollChanged(sender, e);
        //}
    }
}
