﻿#pragma checksum "..\..\..\Views\ExtendedDesktop.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DD99785171D132EF0BE7847091DB7B38"
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
using GnomeSurferPro.ViewModels;
using GnomeSurferPro.Views;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Controls.ContactVisualizations;
using Microsoft.Surface.Presentation.Controls.Primitives;
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
    /// ExtendedDesktop
    /// </summary>
    public partial class ExtendedDesktop : Microsoft.Surface.Presentation.Controls.SurfaceUserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 108 "..\..\..\Views\ExtendedDesktop.xaml"
        internal Microsoft.Surface.Presentation.Controls.ScatterView workspaceBarSV;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Views\ExtendedDesktop.xaml"
        internal Microsoft.Surface.Presentation.Controls.ScatterViewItem workspaceBlockerSVI;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Views\ExtendedDesktop.xaml"
        internal Microsoft.Surface.Presentation.Controls.ScatterView workspaceActualSV;
        
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
            System.Uri resourceLocater = new System.Uri("/GnomeSurferPro;component/views/extendeddesktop.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ExtendedDesktop.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            this.workspaceBarSV = ((Microsoft.Surface.Presentation.Controls.ScatterView)(target));
            return;
            case 6:
            this.workspaceBlockerSVI = ((Microsoft.Surface.Presentation.Controls.ScatterViewItem)(target));
            return;
            case 7:
            this.workspaceActualSV = ((Microsoft.Surface.Presentation.Controls.ScatterView)(target));
            
            #line 117 "..\..\..\Views\ExtendedDesktop.xaml"
            this.workspaceActualSV.AddHandler(Microsoft.Surface.Presentation.SurfaceDragDrop.PreviewDragCanceledEvent, new System.EventHandler<Microsoft.Surface.Presentation.SurfaceDragDropEventArgs>(this.PublicationsArticle_DragCanceled));
            
            #line default
            #line hidden
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
            
            #line 35 "..\..\..\Views\ExtendedDesktop.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.SendToMain_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Controls.ScatterViewItem.ScatterManipulationCompletedEvent;
            
            #line 50 "..\..\..\Views\ExtendedDesktop.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.Controls.ScatterManipulationCompletedEventHandler(this.SendToMain_ScatterManipulationCompleted);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 3:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Contacts.PreviewContactDownEvent;
            
            #line 57 "..\..\..\Views\ExtendedDesktop.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.ContactEventHandler(this.PublicationsArticle_PreviewContactDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.FrameworkElement.LoadedEvent;
            
            #line 58 "..\..\..\Views\ExtendedDesktop.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.PublicationsArticle_SVIInitialized);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 4:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = Microsoft.Surface.Presentation.Contacts.PreviewContactUpEvent;
            
            #line 68 "..\..\..\Views\ExtendedDesktop.xaml"
            eventSetter.Handler = new Microsoft.Surface.Presentation.ContactEventHandler(this.SeqTransSVI_PreviewContactUp);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.FrameworkElement.LoadedEvent;
            
            #line 69 "..\..\..\Views\ExtendedDesktop.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.SeqTransSVI_Initialized);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
