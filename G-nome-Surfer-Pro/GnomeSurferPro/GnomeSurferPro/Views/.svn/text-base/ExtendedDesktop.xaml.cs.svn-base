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
    /// Interaction logic for ExtendedDesktop.xaml
    /// </summary>
    public partial class ExtendedDesktop : SurfaceUserControl
    {

        public ExtendedDesktop()
        {
            InitializeComponent();
        }

        private void SendToMain_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            ((ExtendedDesktopViewModel)this.DataContext).Routed_SendToMain_ScatterManipulationCompleted(sender, e);
            workspaceBlockerSVI.Focus();
        }

        private void PublicationsArticle_SVIInitialized(object sender, EventArgs e)
        {
            ((ExtendedDesktopViewModel)this.DataContext).Routed_PublicationsArticle_SVIInitialized(sender, e);
        }

        private void PublicationsArticle_PreviewContactDown(object sender, ContactEventArgs e)
        {
            //This method is used to handle moving PublicationsArticleSVI back into the SurfaceListBox
            ((ExtendedDesktopViewModel)this.DataContext)._mainVM.Routed_PublicationsArticle_PreviewContactDown(sender, e);//reroutes event handler to SurfaceWindow1ViewModel, which will then reroute it to PublicationsViewModel
        }

        private void PublicationsArticle_DragCanceled(object sender, SurfaceDragDropEventArgs e)
        {
            ((ExtendedDesktopViewModel)this.DataContext).Routed_PublicationsArticle_DragCanceled(sender, e);
        }
        #region Alignment of Translations and Sequences
        private void SeqTransSVI_PreviewContactUp(object sender, ContactEventArgs e)
        {
            if (((ScatterViewItem)sender).DataContext as SequenceViewModel != null)
            {
                //Goes through workspaceActualSV looking for TranslationViewModels
                for (int i = 0; i < workspaceActualSV.Items.Count; i++)
                {
                    //If the translation object is found in the workspaceActualSV
                    if ((workspaceActualSV.Items[i]) as TranslationViewModel != null)
                    {
                        //Check centers to see if they should be aligned
                        if ((Math.Abs(((TranslationViewModel)workspaceActualSV.Items[i]).MyDadSVI.Center.X - ((ScatterViewItem)sender).Center.X) < 50)
                            && (Math.Abs(((TranslationViewModel)workspaceActualSV.Items[i]).MyDadSVI.Center.Y - ((ScatterViewItem)sender).Center.Y) < 50))
                        {
                            //ALIGN!
                            ((ScatterViewItem)sender).Center = ((TranslationViewModel)workspaceActualSV.Items[i]).MyDadSVI.Center;
                            ((ScatterViewItem)sender).Orientation = ((TranslationViewModel)workspaceActualSV.Items[i]).MyDadSVI.Orientation;
                            ((ScatterViewItem)sender).Width = ((TranslationViewModel)workspaceActualSV.Items[i]).MyDadSVI.Width;
                            ((ScatterViewItem)sender).Height = ((TranslationViewModel)workspaceActualSV.Items[i]).MyDadSVI.Height;
                            //Transparent-ify the top
                            ((SequenceViewModel)((ScatterViewItem)sender).DataContext).Background = new SolidColorBrush(Colors.Transparent);
                        }
                        else
                        {
                            ((SequenceViewModel)((ScatterViewItem)sender).DataContext).Background = new SolidColorBrush(Colors.Black);
                        }
                    }

                }

            }
            else if (((ScatterViewItem)sender).DataContext as TranslationViewModel != null)
            {
                //Goes through workspaceActualSV looking for TranslationViewModels
                for (int i = 0; i < workspaceActualSV.Items.Count; i++)
                {
                    //If the translation object is found in the workspaceActualSV
                    if ((workspaceActualSV.Items[i]) as SequenceViewModel != null)
                    {
                        //Check centers to see if they should be aligned
                        if ((Math.Abs(((SequenceViewModel)workspaceActualSV.Items[i]).MyDadSVI.Center.X - ((ScatterViewItem)sender).Center.X) < 50)
                            && (Math.Abs(((SequenceViewModel)workspaceActualSV.Items[i]).MyDadSVI.Center.Y - ((ScatterViewItem)sender).Center.Y) < 50))
                        {
                            //ALIGN!
                            ((ScatterViewItem)sender).Center = ((SequenceViewModel)workspaceActualSV.Items[i]).MyDadSVI.Center;
                            ((ScatterViewItem)sender).Orientation = ((SequenceViewModel)workspaceActualSV.Items[i]).MyDadSVI.Orientation;
                            ((ScatterViewItem)sender).Width = ((SequenceViewModel)workspaceActualSV.Items[i]).MyDadSVI.Width;
                            ((ScatterViewItem)sender).Height = ((SequenceViewModel)workspaceActualSV.Items[i]).MyDadSVI.Height;
                            //Transparent-ify the top
                            ((TranslationViewModel)((ScatterViewItem)sender).DataContext).Background = new SolidColorBrush(Colors.Transparent);
                        }
                        else
                        {
                            ((TranslationViewModel)((ScatterViewItem)sender).DataContext).Background = new SolidColorBrush(Colors.Black);
                        }
                    }

                }
            }

        }

        public void SeqTransSVI_Initialized(object sender, EventArgs e)
        {
            if (((ScatterViewItem)sender).DataContext as TranslationViewModel != null)
            {
                ((TranslationViewModel)((ScatterViewItem)sender).DataContext).MyDadSVI = (ScatterViewItem)sender;
            }
            else if (((ScatterViewItem)sender).DataContext as SequenceViewModel != null)
            {
                ((SequenceViewModel)((ScatterViewItem)sender).DataContext).MyDadSVI = (ScatterViewItem)sender;
            }
        }
        #endregion
    }
}
