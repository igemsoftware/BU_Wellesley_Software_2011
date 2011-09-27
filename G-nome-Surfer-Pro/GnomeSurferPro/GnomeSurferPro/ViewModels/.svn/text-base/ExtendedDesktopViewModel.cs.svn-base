using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using GnomeSurferPro.Models;



namespace GnomeSurferPro.ViewModels
{
    public class ExtendedDesktopViewModel : ViewModelBase
    {
        private Point _workspaceCenter;
        private CompositeCollection _workspaceCollection;

        public SurfaceWindow1ViewModel _mainVM;

        public ExtendedDesktopViewModel(SurfaceWindow1ViewModel mainVM)
        {
            _mainVM = mainVM;
        }

        public CompositeCollection WorkspaceCollection
        {
            get
            {
                if (_workspaceCollection == null)
                {
                    _workspaceCollection = new CompositeCollection();
                }

                return _workspaceCollection;
            }
            set
            {
                if (_workspaceCollection != value)
                {
                    _workspaceCollection = value;
                }
            }
        }

        public Point WorkspaceCenter
        {
            get
            {
                return _workspaceCenter;
            }
        }

        public void Routed_SendToMain_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            if (((ScatterViewItem)sender).Center.Y < 150)
            {
                Console.WriteLine("SEND ME TO THE MAIN!!!");
                _mainVM.AllObjectsCollection.Add(((ScatterViewItem)sender).DataContext);
                
                _workspaceCollection.Remove(((ScatterViewItem)sender).DataContext);
            }
        }

        public void Routed_SendToWorkspace_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            if ((((ScatterViewItem)sender).Center.Y > 650)&&!(WorkspaceCollection.Contains(sender)))
            {
                Console.WriteLine("SEND ME TO THE EXTENDED DESKTOP!!!");
                WorkspaceCollection.Add(((ScatterViewItem)sender).DataContext);
                _mainVM.AllObjectsCollection.Remove(((ScatterViewItem)sender).DataContext);
            }
        }

        public void Routed_workspaceContainerSVI_ScatterManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {
            ScatterViewItem current = (ScatterViewItem)sender;
            if (e.ManipulationOrigin.Y > 20)
            {
                current.Center = new Point(512, current.Center.Y);
            }
            _workspaceCenter = current.Center;
        }

        public void Routed_workspaceContainerSVI_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            ScatterViewItem current = (ScatterViewItem)sender;
            if (current.Center.Y < 400)
                current.Center = new Point(512, 380);
            if (current.Center.Y > 1000)
                current.Center = new Point(512, 1115);
        }

        public void Routed_PublicationsArticle_SVIInitialized(object sender, EventArgs e)
        {
            if (sender is ScatterViewItem && (sender as ScatterViewItem).DataContext != null)
            {
                //get the PublicationsArticleViewModel related to current SVI
                int articleIndex = WorkspaceCollection.IndexOf((PublicationsArticleViewModel)(((ScatterViewItem)sender).DataContext));
                
                //set cetner and orientation of newly constructed SVI to have "drop in place" effect
                ((ScatterViewItem)sender).Center = ((PublicationsArticleViewModel)WorkspaceCollection[articleIndex]).SVICenter;
                ((ScatterViewItem)sender).Orientation = ((PublicationsArticleViewModel)WorkspaceCollection[articleIndex]).SVIOrientation;
            }
        }


        public void Routed_PublicationsArticle_DragCanceled(object sender, SurfaceDragDropEventArgs e)
        {
            if (!(e.Cursor.Data is PublicationsViewModel))
            {
                Publication publication = e.Cursor.Data as Publication;

                if (WorkspaceCollection.Contains(publication))//filter this method to only apply to pubArticles currently in extended desktop
                {
                    ScatterViewItem item = publication.DraggedElement as ScatterViewItem;
                    if (item != null)
                    {
                        item.Visibility = Visibility.Visible;
                        item.Orientation = e.Cursor.GetOrientation((ScatterView)sender);
                        item.Center = e.Cursor.GetPosition((ScatterView)sender);
                    }
                }
            }
        }
    }
}
