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
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using GnomeSurferPro.ViewModels;
using Microsoft.Surface.Core;


namespace GnomeSurferPro.Views
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        private const int _eraseMargin = 50;
        private const double _searchShelfMaxY = 300;


        private double CenterX
        {
            get { return Width / 2; }
        }

        private SurfaceWindow1ViewModel _myViewModel;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for Application activation events
            AddActivationHandlers();

            //Define DataContext
            _myViewModel = new SurfaceWindow1ViewModel();
            this.DataContext = _myViewModel;

            _myViewModel.GenePentagonContactDown +=new GenePentagonContactDownHandler(MoveAndShowGeneInfoMenu);
            _myViewModel.GeneBarMovedEvent += new Action(HideGeneInfoMenu);
        }


        #region Default Methods
        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for Application activation events
            RemoveActivationHandlers();
        }

        /// <summary>
        /// Adds handlers for Application activation events.
        /// </summary>
        private void AddActivationHandlers()
        {
            // Subscribe to surface application activation events
            ApplicationLauncher.ApplicationActivated += OnApplicationActivated;
            ApplicationLauncher.ApplicationPreviewed += OnApplicationPreviewed;
            ApplicationLauncher.ApplicationDeactivated += OnApplicationDeactivated;
        }

        /// <summary>
        /// Removes handlers for Application activation events.
        /// </summary>
        private void RemoveActivationHandlers()
        {
            // Unsubscribe from surface application activation events
            ApplicationLauncher.ApplicationActivated -= OnApplicationActivated;
            ApplicationLauncher.ApplicationPreviewed -= OnApplicationPreviewed;
            ApplicationLauncher.ApplicationDeactivated -= OnApplicationDeactivated;
        }

        /// <summary>
        /// This is called when application has been activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationActivated(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when application is in preview mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationPreviewed(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        ///  This is called when application has been deactivated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationDeactivated(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }
        #endregion

        #region Routed Events for Workspace

        private void workspaceContainerSVI_ScatterManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {
            _myViewModel.ExtendedDesktopViewModel.Routed_workspaceContainerSVI_ScatterManipulationDelta(sender, e);
        }

        private void workspaceContainerSVI_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            _myViewModel.ExtendedDesktopViewModel.Routed_workspaceContainerSVI_ScatterManipulationCompleted(sender, e);
        }

        private void SendToWorkspace_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            _myViewModel.ExtendedDesktopViewModel.Routed_SendToWorkspace_ScatterManipulationCompleted(sender, e);
        }
        #endregion

        private void searchShelfContainerSVI_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            const int snapMargin = 60; // The distance from the shelf's retracted center that will cause the shelf
                                       // to snap into place
            ScatterViewItem item = (ScatterViewItem)sender;
            double y = item.Center.Y;
            SearchShelfViewModel vm = (SearchShelfViewModel)item.DataContext;
            if (y < vm.RetractedCenter.Y + snapMargin)
            {
                vm.RetractShelf();
            }
        }

        private void searchShelfContainerSVI_ScatterManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {

            ScatterViewItem item = (ScatterViewItem)sender;
            SearchShelfViewModel vm = (SearchShelfViewModel)item.DataContext;
            double y = item.Center.Y;
            y = Math.Max(y, vm.RetractedCenter.Y);
            y = Math.Min(y, _searchShelfMaxY);
            item.Center = new Point(CenterX, y);

            HideGeneInfoMenu();
        }

        #region Routed Events for Publications

     
        private void PublicationsArticle_PreviewContactDown(object sender, Microsoft.Surface.Presentation.ContactEventArgs e)
        {
            _myViewModel.Routed_PublicationsArticle_PreviewContactDown(sender, e);
        }

        private void PublicationsArticle_DragCanceled(object sender, SurfaceDragDropEventArgs e)
        {
            _myViewModel.Routed_PublicationsArticle_DragCanceled(sender, e);
        }

        private void PublicationsArticle_SVIInitialized(object sender, EventArgs e)
        {
            _myViewModel.Routed_PublicationsArticle_SVIInitialized(sender, e);
        }
        #endregion

        private void Erase_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            double xPosition = e.ManipulationOrigin.X;
            if (xPosition < _eraseMargin || xPosition > (Width - _eraseMargin)) // check if svi is outside erase margin
            {
                FrameworkElement element = (FrameworkElement) sender;
                _myViewModel.EraseItem(element.DataContext);
            }
        }

        private void MoveAndShowGeneInfoMenu(Rect boundingRect, VisualGene.GeneDirection direction)
        {
            _GeneElementMenu.SetValue(Canvas.LeftProperty, boundingRect.Left - 20); // I don't know why 20 works, but
            _GeneElementMenu.SetValue(Canvas.TopProperty, boundingRect.Top - 20);   // based on experimentation it positions the
                                                                                    // menu correctly

            // Set orientation so gene menu fits within chromosomebar
            if (direction == VisualGene.GeneDirection.Forward)
            {
                _GeneElementMenu.Orientation = -180;
            }
            else
            {
                _GeneElementMenu.Orientation = 0;
            }

            _GeneElementMenu.Visibility = Visibility.Visible;
        }

        private void HideGeneInfoMenu()
        {
            _GeneElementMenu.Visibility = Visibility.Collapsed;
        }

        #region Alignment of Translations and Sequences
        private void SeqTransSVI_PreviewContactUp(object sender, Microsoft.Surface.Presentation.ContactEventArgs e)
        {
            if (((ScatterViewItem)sender).DataContext as SequenceViewModel != null)
            {
                //Goes through mainSV looking for TranslationViewModels
                for (int i = 0; i < mainSV.Items.Count; i++)
                {
                    //If the translation object is found in the mainSV
                    if ((mainSV.Items[i]) as TranslationViewModel != null)
                    {
                        //Check centers to see if they should be aligned
                        if ((Math.Abs(((TranslationViewModel)mainSV.Items[i]).MyDadSVI.Center.X - ((ScatterViewItem)sender).Center.X) < 50)
                            && (Math.Abs(((TranslationViewModel)mainSV.Items[i]).MyDadSVI.Center.Y - ((ScatterViewItem)sender).Center.Y) < 50))
                        {
                            //ALIGN!
                            ((ScatterViewItem)sender).Center = ((TranslationViewModel)mainSV.Items[i]).MyDadSVI.Center;
                            ((ScatterViewItem)sender).Orientation = ((TranslationViewModel)mainSV.Items[i]).MyDadSVI.Orientation;
                            ((ScatterViewItem)sender).Width = ((TranslationViewModel)mainSV.Items[i]).MyDadSVI.Width;
                            ((ScatterViewItem)sender).Height = ((TranslationViewModel)mainSV.Items[i]).MyDadSVI.Height;
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
                //Goes through mainSV looking for TranslationViewModels
                for (int i = 0; i < mainSV.Items.Count; i++)
                {
                    //If the sequence object is found in the mainSV
                    if ((mainSV.Items[i]) as SequenceViewModel != null)
                    {
                        //Check centers to see if they should be aligned
                        if ((Math.Abs(((SequenceViewModel)mainSV.Items[i]).MyDadSVI.Center.X - ((ScatterViewItem)sender).Center.X) < 50)
                            && (Math.Abs(((SequenceViewModel)mainSV.Items[i]).MyDadSVI.Center.Y - ((ScatterViewItem)sender).Center.Y) < 50))
                        {
                            //Hook them so the scrollviewers will move together
                            //((TranslationViewModel)((ScatterViewItem)sender).DataContext).MyUncleSVI = ((SequenceViewModel)mainSV.Items[i]).MyDadSVI;
                            //ALIGN!
                            ((ScatterViewItem)sender).Center = ((SequenceViewModel)mainSV.Items[i]).MyDadSVI.Center;
                            ((ScatterViewItem)sender).Orientation = ((SequenceViewModel)mainSV.Items[i]).MyDadSVI.Orientation;
                            ((ScatterViewItem)sender).Width = ((SequenceViewModel)mainSV.Items[i]).MyDadSVI.Width;
                            ((ScatterViewItem)sender).Height = ((SequenceViewModel)mainSV.Items[i]).MyDadSVI.Height;
                            //Transparent-ify the top
                            ((TranslationViewModel)((ScatterViewItem)sender).DataContext).Background = new SolidColorBrush(Colors.Transparent);
                        }
                        else
                        {
                            ((TranslationViewModel)((ScatterViewItem)sender).DataContext).Background = new SolidColorBrush(Colors.Black);
                            //((TranslationViewModel)((ScatterViewItem)sender).DataContext).MyUncleSVI = null;
                        }
                    }

                }
            }
            
        }

        public void SeqTransSVI_Initialized(object sender, EventArgs e)
        {
            if (((ScatterViewItem)sender).DataContext as TranslationViewModel != null)
            {
               ((TranslationViewModel) ((ScatterViewItem)sender).DataContext).MyDadSVI = (ScatterViewItem)sender;
            }
            else if (((ScatterViewItem)sender).DataContext as SequenceViewModel != null)
            {
                ((SequenceViewModel)((ScatterViewItem)sender).DataContext).MyDadSVI = (ScatterViewItem)sender;
            }
        }
        #endregion

        /// <summary>
        /// This method closes the surface keyboard when "Enter" key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeneSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            //When the Return key is pressed
            if (e.Key == Key.Return)
            {
                _myViewModel.PersistentSearchMenu.Execute_GeneSearch(null);
            }
        }
       
    }
}