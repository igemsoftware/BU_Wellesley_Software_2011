﻿#pragma checksum "..\..\..\Views\SurfaceWindow1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6A62DF094A2A24511F64D604DB811373"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4214
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GnomeSurferPro;
using GnomeSurferPro.Selectors;
using GnomeSurferPro.Util;
using GnomeSurferPro.ViewModels;
using GnomeSurferPro.Views;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Controls.ContactVisualizations;
using Microsoft.Surface.Presentation.Controls.Primitives;
using PrimerDesigner;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GnomeSurferPro.Views {
    
    
    /// <summary>
    /// SurfaceWindow1
    /// </summary>
    public partial class SurfaceWindow1 : Microsoft.Surface.Presentation.Controls.SurfaceWindow, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 231 "..\..\..\Views\SurfaceWindow1.xaml"
        internal Microsoft.Surface.Presentation.Controls.ScatterView mainSV;
        
        #line default
        #line hidden
        
        
        #line 282 "..\..\..\Views\SurfaceWindow1.xaml"
        internal Microsoft.Surface.Presentation.Controls.ElementMenu _GeneElementMenu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GnomeSurferPro;component/views/surfacewindow1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\SurfaceWindow1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            this.mainSV = ((Microsoft.Surface.Presentation.Controls.ScatterView)(target));
            
            #line 233 "..\..\..\Views\SurfaceWindow1.xaml"
            this.mainSV.AddHandler(Microsoft.Surface.Presentation.SurfaceDragDrop.PreviewDragCanceledEvent, new System.EventHandler<Microsoft.Surface.Presentation.SurfaceDragDropEventArgs>(this.PublicationsArticle_DragCanceled));
            
            #line default
            #line hidden
            return;
            case 9:
            this._GeneElementMenu = ((Microsoft.Surface.Presentation.Controls.ElementMenu)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 1:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 46 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.SendToWorkspace_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 47 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.Erase_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 67 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.SendToWorkspace_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 68 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.Erase_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 3:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Contacts.PreviewContactDownEvent;
            
            #line 77 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.ContactEventHandler(this.PublicationsArticle_PreviewContactDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.FrameworkElement.LoadedEvent;
            
            #line 78 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.PublicationsArticle_SVIInitialized);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 4:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationDeltaEvent;
            
            #line 94 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationDeltaEventHandler(this.workspaceContainerSVI_ScatterManipulationDelta);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 95 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.workspaceContainerSVI_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 96 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.workspaceContainerSVI_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 5:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Contacts.PreviewContactUpEvent;
            
            #line 115 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.ContactEventHandler(this.SeqTransSVI_PreviewContactUp);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.FrameworkElement.LoadedEvent;
            
            #line 116 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.SeqTransSVI_Initialized);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 6:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationDeltaEvent;
            
            #line 125 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationDeltaEventHandler(this.searchShelfContainerSVI_ScatterManipulationDelta);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 126 "..\..\..\Views\SurfaceWindow1.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.searchShelfContainerSVI_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 7:
            
            #line 196 "..\..\..\Views\SurfaceWindow1.xaml"
            ((Microsoft.Surface.Presentation.Controls.SurfaceTextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.GeneSearchBox_KeyDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}