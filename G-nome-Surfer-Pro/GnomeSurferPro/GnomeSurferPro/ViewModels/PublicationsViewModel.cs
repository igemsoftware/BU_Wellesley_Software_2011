using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Microsoft.Surface.Presentation;
using Microsoft.Surface;
using Microsoft.Surface.Presentation.Controls;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Xml;
using GenBank;
using GnomeSurferPro.Models;
using GnomeSurferPro.Views;
using GnomeSurferPro.Util;

namespace GnomeSurferPro.ViewModels
{
    //This class handles all the properties associated with publications (both SVIs and ListBoxItems)
    public class PublicationsViewModel : ViewModelBase
    {
        #region Private members

        private const int DragThreshold = 15;
        private ObservableCollection<IPublication> _LBIpublicationCollection;
        private List<InputDevice> _ignoreDeviceList = new List<InputDevice>();
        private SurfaceWindow1ViewModel _mainVM;
        private IGene _gene;
        private bool _doneFetchingResults;
        private ObservableCollection<IPublication> _publications;

        private String _totalResultNum;

        #endregion Private members

        //Instance variables for SVI to LBI, not going to use for GnomeSurferPro
        //private SurfaceListBoxItem _draggedLBIElement;
        //public event PropertyChangedEventHandler PropertyChanged;
        //private ScatterViewItem _draggedSVIElement;

        public PublicationsViewModel(SurfaceWindow1ViewModel mainVM, IGene gene)
        {
            _mainVM = mainVM;
            _gene = gene;
            DoneFetchingResults = false;
            LBIPublicationCollection = null;

            IPubMedService service = new PubMedService();
            ThreadedPubMedService threadedService = new ThreadedPubMedService(service, gene);
            threadedService.ThreadedPubMedServiceCompleted += new ThreadedPubMedServiceCompletedHandler(DisplayPublications);
            threadedService.Start();
        }

        public IGene CurrentGene
        {

            get
            {
                return _gene;
            }
        }

        public String TotalResultNum
        {
            get
            {
                return "" + LBIPublicationCollection.Count + " Results Found";
            }
            set
            {
                if (value != _totalResultNum)
                {
                    _totalResultNum = value;
                    OnPropertyChanged("TotalResultNum");
                }
            }
        }

        public String CurrentGeneTagandName
        {
            get
            {
                return this.CurrentGene.LocusTag + "    "
                    + this.CurrentGene.Name;
            }
        }

        public ObservableCollection<IPublication> LBIPublicationCollection
        {
            get { return _publications; }
            set
            {
                if (value != _publications)
                {
                    _publications = value;
                    OnPropertyChanged("LBIPublicationCollection");

                    TotalResultNum = "" + LBIPublicationCollection.Count + " Results Found";
                }
            }
        }

        public bool DoneFetchingResults
        {
            get { return _doneFetchingResults; }
            set
            {
                if (_doneFetchingResults != value)
                {
                    _doneFetchingResults = value;
                    OnPropertyChanged("DoneFetchingResults");
                }
            }
        }


        #region SCATTERVIEW TO LIST BOX. Not going to use for GnomeSurferPro
        //public void Routed_ScatterView_PreviewContactDown(object sender, ContactEventArgs e)
        //{
        //    FrameworkElement findSource = e.OriginalSource as FrameworkElement;
        //    _draggedSVIElement = null;

        //    //Find the SVI object that is being touched
        //    while (_draggedSVIElement == null && findSource != null)
        //    {
        //        if ((_draggedSVIElement = findSource as ScatterViewItem) == null)
        //        {
        //            findSource = VisualTreeHelper.GetParent(findSource) as FrameworkElement;
        //        }
        //    }

        //    if (_draggedSVIElement == null)
        //    {
        //        return;
        //    }

        //    Publication publication = _draggedSVIElement.Content as Publication;

        //    // If the data has not been specified, return.
        //    if (publication == null)
        //    {
        //        return;
        //    }

        //    // Set the dragged element. This is needed in case the drag operation is canceled.
        //    publication.DraggedElement = _draggedSVIElement;


        //    // Create the cursor visual.
        //    ContentControl cursorVisual = new ContentControl()
        //    {
        //        Content = _draggedSVIElement.DataContext,
        //        Style = (Style)_draggedSVIElement.FindResource("CursorStyle")
        //    };

        //    cursorVisual.Unloaded += new RoutedEventHandler(cursorVisual_Unloaded);

        //    // Create a list of input devices. Add the contacts that
        //    // are currently captured within the dragged element and
        //    // the current contact (if it isn't already in the list).
        //    List<InputDevice> devices = new List<InputDevice>();
        //    devices.Add(e.Contact);
        //    foreach (Contact contact in _draggedSVIElement.ContactsCapturedWithin)
        //    {
        //        if (contact != e.Contact)
        //        {
        //            devices.Add(contact);
        //        }
        //    }

        //    // Get the drag source object
        //    ItemsControl dragSource = ItemsControl.ItemsControlFromItemContainer(_draggedSVIElement);

        //    bool startDragOkay =
        //        SurfaceDragDrop.BeginDragDrop(
        //          dragSource,                 // The ScatterView object that the cursor is dragged out from.
        //          _draggedSVIElement,             // The ScatterViewItem object that is dragged from the drag source.
        //          cursorVisual,               // The visual element of the cursor.
        //          _draggedSVIElement.DataContext, // The data attached with the cursor.
        //          devices,                    // The input devices that start dragging the cursor.
        //          DragDropEffects.Move);      // The allowed drag-and-drop effects of the operation.

        //    if (startDragOkay)
        //    {
        //        // Set e.Handled to true, otherwise the ScatterViewItem will capture the contact 
        //        // and cause the BeginDragDrop to fail.
        //        e.Handled = true;
        //        // Hide the ScatterViewItem.
        //        _draggedSVIElement.Visibility = Visibility.Hidden;
        //    }

           
        //}

        //void cursorVisual_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    //if ((((ScatterViewItem)_draggedSVIElement).Center.Y > 650) && !(_mainVM.ExtendedDesktopViewModel.WorkspaceCollection.Contains(this)))
        //    //{
        //    //    Console.WriteLine("SEND ME TO THE EXTENDED DESKTOP!!!");
        //    //    int indexOfThing = -1;
        //    //    _mainVM.ExtendedDesktopViewModel.WorkspaceCollection.Add(((ContentControl)sender).Content);
        //    //    if (_mainVM.AllObjectsCollection.Contains(((ContentControl)sender).Content))
        //    //    {
        //    //        indexOfThing = _mainVM.AllObjectsCollection.IndexOf(((ContentControl)sender).Content);
        //    //    }
        //    //    _mainVM.AllObjectsCollection.RemoveAt(indexOfThing);
        //    //}
        //}

        //public void Routed_PublicationsSurfaceListBox_DragEnter(object sender, SurfaceDragDropEventArgs e)
        //{
        //    e.Cursor.Visual.Tag = "DragEnter";
        //}

        //public void Routed_PublicationsSurfaceListBox_DragLeave(object sender, SurfaceDragDropEventArgs e)
        //{
        //    e.Cursor.Visual.Tag = null;
        //}

        //public void Routed_PublicationsSurfaceListBox_Drop(object sender, SurfaceDragDropEventArgs e)
        //{
        //    try
        //    {
        //        if (LBIPublicationCollection.Contains(e.Cursor.Data as Publication))
        //        {
        //            _mainVM.SVIPublicationCollection.Remove(e.Cursor.Data as Publication);
        //        }

        //        if (!(LBIPublicationCollection.Contains(e.Cursor.Data as Publication)) && (e.Cursor.Data as Publication != null))
        //        {
        //            LBIPublicationCollection.Add(e.Cursor.Data as Publication);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("OOPSIES!");
        //    }
            
        //}
        #endregion

        #region LISTBOX TO SCATTERVIEW
        public void Routed_PublicationsSurfaceListBox_DragCompleted(object sender, SurfaceDragCompletedEventArgs e)
        {
            foreach (Publication item in ((SurfaceListBox)sender).Items)
            {
                if (item != null)
                {
                    SurfaceListBoxItem currentItem = ((SurfaceListBox)sender).ItemContainerGenerator.ContainerFromItem(item) as SurfaceListBoxItem;
                    currentItem.Opacity = 1.0;
                }
            }
        }

        public void Routed_PublicationsSurfaceListBox_PreviewContactDown(object sender, ContactEventArgs e)
        {
            _ignoreDeviceList.Remove(e.Device);
            InputDeviceHelper.ClearDeviceState(e.Device);

            InputDeviceHelper.InitializeDeviceState(e.Device);
        }

        public void Routed_PublicationsSurfaceListBox_PreviewContactChanged(object sender, ContactEventArgs e)
        {
            if (InputDeviceHelper.GetDragSource(e.Device) != null)
            {
                StartDragDrop((SurfaceListBox)sender, e);
            }
        }

        private Publication StartDragDrop(SurfaceListBox sourceListBox, InputEventArgs e)
        {
            if (_ignoreDeviceList.Contains(e.Device))
            {
                return null;
            }

            InputDeviceHelper.InitializeDeviceState(e.Device);

            Vector draggedDelta = InputDeviceHelper.DraggedDelta(e.Device, (UIElement)sourceListBox);

            if (Math.Abs(draggedDelta.Y) > DragThreshold)
            {
                _ignoreDeviceList.Add(e.Device);
                return null;
            }

            if (Math.Abs(draggedDelta.X) < DragThreshold)
            {
                return null;
            }

            _ignoreDeviceList.Add(e.Device);

            DependencyObject downSource = InputDeviceHelper.GetDragSource(e.Device);
            Debug.Assert(downSource != null);

            if (!(downSource is System.Windows.Controls.TextBlock))
            {
                return null;
            }
            SurfaceListBoxItem draggedListBoxItem = GetVisualAncestor<SurfaceListBoxItem>(downSource);
            Debug.Assert(draggedListBoxItem != null);
            

            Publication data = draggedListBoxItem.Content as Publication;

            TempPublicationSVI cursorVisual = new TempPublicationSVI();
            cursorVisual.Style = (Style)sourceListBox.FindResource("CursorStyle");
            cursorVisual.ScatterManipulationCompleted += new ScatterManipulationCompletedEventHandler(cursorVisual_ScatterManipulationCompleted);
            cursorVisual.Content = data;

            IEnumerable<InputDevice> devices = null;

            ContactEventArgs contactEventArgs = e as ContactEventArgs;
            if (contactEventArgs != null)
            {
                devices = MergeContacts(draggedListBoxItem.ContactsCapturedWithin, contactEventArgs.Contact);
            }
            else
            {
                devices = new List<InputDevice>(new InputDevice[] { e.Device });
            }

            
            if (!SurfaceDragDrop.BeginDragDrop(sourceListBox, draggedListBoxItem, cursorVisual, sourceListBox.DataContext, devices, DragDropEffects.Copy))
            {
                return data;
            }
            
            InputDeviceHelper.ClearDeviceState(e.Device);
            _ignoreDeviceList.Remove(e.Device);

            draggedListBoxItem.Opacity = 0.5;
            e.Handled = true;

            return data;
        }

        void cursorVisual_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {

            if (((TempPublicationSVI)sender).Opacity == 0.9)
            {
                bool isInWorkspace = false;
                if (_mainVM.ExtendedDesktopViewModel.WorkspaceCollection.Contains(this))
                    isInWorkspace = true;

                if (isInWorkspace)
                {
                    double difference = _mainVM.ExtendedDesktopViewModel.WorkspaceCenter.Y - 340;
                    
                    PublicationsArticleViewModel currentArticleVM = new PublicationsArticleViewModel((Publication)((TempPublicationSVI)sender).Content, this);
                    currentArticleVM.SVICenter = ((TempPublicationSVI)sender).Center;
                    currentArticleVM.SVIOrientation = ((TempPublicationSVI)sender).Orientation;
                    _mainVM.ExtendedDesktopViewModel.WorkspaceCollection.Add(currentArticleVM);
                    LBIPublicationCollection.Remove(((Publication)((TempPublicationSVI)sender).Content));
                }
                else
                {
                    PublicationsArticleViewModel currentArticleVM = new PublicationsArticleViewModel((Publication)((TempPublicationSVI)sender).Content, this);
                    currentArticleVM.SVICenter = ((TempPublicationSVI)sender).Center;
                    currentArticleVM.SVIOrientation = ((TempPublicationSVI)sender).Orientation;
                    _mainVM.AllObjectsCollection.Add(currentArticleVM);
                    LBIPublicationCollection.Remove(((Publication)((TempPublicationSVI)sender).Content));
                }
            }
        }

        private static T GetVisualAncestor<T>(DependencyObject descendant) where T : class
        {
            T ancestor = null;
            DependencyObject scan = descendant;
            ancestor = null;

            while (scan != null && ((ancestor = scan as T) == null))
            {
                scan = VisualTreeHelper.GetParent(scan);
            }

            return ancestor;
        }

        private static IEnumerable<InputDevice> MergeContacts(IEnumerable<Contact> existContacts, Contact extraContact)
        {
            var result = new List<InputDevice> { extraContact };

            foreach (Contact contact in existContacts)
            {
                result.Add(contact);
            }

            return result;
        }

        public void Routed_PublicationsSurfaceListBox_PreviewContactUp(object sender, ContactEventArgs e)
        {
            _ignoreDeviceList.Remove(e.Device);
            InputDeviceHelper.ClearDeviceState(e.Device);
        }

        #endregion

        private void DisplayPublications(IList<IPublication> publications)
        {
            LBIPublicationCollection = new ObservableCollection<IPublication>(publications);
            DoneFetchingResults = true;
        }
    }
}
