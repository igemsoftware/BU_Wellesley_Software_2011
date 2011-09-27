using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using LinqToVisualTree;
using GnomeSurferPro.ViewModels;

namespace GnomeSurferPro.Util
{
    // See http://www.scottlogic.co.uk/blog/colin/2010/07/exposing-and-binding-to-a-silverlight-scrollviewer%E2%80%99s-scrollbars/
    public static class ScrollViewerBinding
    {
        //#region ViewportWidth attached property

        ///// <summary>
        ///// Gets the ViewportWidth value
        ///// </summary>
        //public static double GetViewportWidth(DependencyObject depObj)
        //{
        //    return (double)depObj.GetValue(ViewportWidthProperty);
        //}

        ///// <summary>
        ///// Sets the ViewportWidth value
        ///// </summary>
        //public static void SetViewportWidth(DependencyObject depObj, double value)
        //{
        //    depObj.SetValue(ViewportWidthProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for ViewportWidth.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ViewportWidthProperty =
        //    DependencyProperty.Register("ViewportWidth", typeof(double), typeof(ScrollViewerBinding), new UIPropertyMetadata(1.0));


        //#endregion

        #region Horizontal attached property

        /// <summary>
        /// Gets the horizontal offset value
        /// </summary>
        public static double GetHorizontalOffset(DependencyObject depObj)
        {
            return (double)depObj.GetValue(HorizontalOffsetProperty);
        }

        /// <summary>
        /// Sets the horizontal offset value
        /// </summary>
        public static void SetHorizontalOffset(DependencyObject depObj, double value)
        {
            depObj.SetValue(HorizontalOffsetProperty, value);
        }

        /// <summary>
        /// Horizontal attached property
        /// </summary>
        public static readonly DependencyProperty HorizontalOffsetProperty =
            DependencyProperty.RegisterAttached("HorizontalOffset", typeof(double),
            typeof(ScrollViewerBinding), new PropertyMetadata(-1.0, OnHorizontalOffsetPropertyChanged)); // setting default value to
                                                                                                        // -1.0 so callback is called  
                                                                                                        // immediately

        #endregion

        /// <summary>
        /// An attached property which holds a reference to the horizontal scrollbar which
        /// is extracted from the visual tree of a ScrollViewer
        /// </summary>
        private static readonly DependencyProperty HorizontalScrollBarProperty =
            DependencyProperty.RegisterAttached("HorizontalScrollBar", typeof(ScrollBar),
            typeof(ScrollViewerBinding), new PropertyMetadata(null));

        /// <summary>
        /// Invoked when the Horizontal attached property changes
        /// </summary>
        private static void OnHorizontalOffsetPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            ScrollViewer sv = d as ScrollViewer;
            if (sv != null)
            {
                // check whether we have a reference to the horizontal scrollbar
                if (sv.GetValue(HorizontalScrollBarProperty) == null)
                {
                    // if not, handle LayoutUpdated, which will be invoked after the
                    // template is applied and extract the scrollbar
                    sv.LayoutUpdated += (s, ev) =>
                    {
                        if (sv.GetValue(HorizontalScrollBarProperty) == null)
                        {
                            GetScrollBarsForScrollViewer(sv);
                        }
                    };
                }
                else
                {
                    // update the scrollviewer offset
                    sv.ScrollToHorizontalOffset((double)e.NewValue);
                }
            }
        }

        /// <summary>
        /// Attempts to extract the scrollbars that are within the scrollviewers
        /// visual tree. When extracted, event handlers are added to their ValueChanged events.
        /// </summary>
        private static void GetScrollBarsForScrollViewer(ScrollViewer scrollViewer)
        {
            ScrollBar scroll = GetScrollBar(scrollViewer, Orientation.Horizontal);
            if (scroll != null)
            {
                // save a reference to this scrollbar on the attached property
                scrollViewer.SetValue(HorizontalScrollBarProperty, scroll);

                // scroll the scrollviewer
                scrollViewer.ScrollToHorizontalOffset(
                  ScrollViewerBinding.GetHorizontalOffset(scrollViewer));


                // handle the changed event to update the exposed VerticalOffset
                scroll.ValueChanged += (s, e) =>
                {
                    SetHorizontalOffset(scrollViewer, e.NewValue);
                };
            }
        }

        /// <summary>
        /// Searches the descendants of the given element, looking for a scrollbar
        /// with the given orientation.
        /// </summary>
        private static ScrollBar GetScrollBar(FrameworkElement fe, Orientation orientation)
        {
            return fe.Descendants()
                      .OfType<ScrollBar>()
                      .Where(s => s.Orientation == orientation)
                      .SingleOrDefault();

        }
    }
}
