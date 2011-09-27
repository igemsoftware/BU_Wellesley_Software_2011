using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using GnomeSurferPro.ViewModels;

namespace GnomeSurferPro.Util
{
    // Provides the attached dependency that allows us to bind to the HorizontalOffset property
    // of the scrollviewer
    // See http://marlongrech.wordpress.com/2009/09/14/how-to-set-wpf-scrollviewer-verticaloffset-and-horizontal-offset/
    // See http://www.scottlogic.co.uk/blog/colin/2010/07/exposing-and-binding-to-a-silverlight-scrollviewer%E2%80%99s-scrollbars/
    public static class ScrollViewBinding
    {
    //    #region HorizontalOffset attached property

    //    public static double GetHorizontalOffset(DependencyObject depObj)
    //    {
    //        return (double)depObj.GetValue(HorizontalOffsetProperty);
    //    }

    //    public static void SetHorizontalOffset(DependencyObject depObj, double value)
    //    {
    //        depObj.SetValue(HorizontalOffsetProperty, value);
    //    }

    //    public static readonly DependencyProperty HorizontalOffsetProperty =
    //        DependencyProperty.RegisterAttached("HorizontalOffsetProperty", typeof(double),
    //        typeof(ScrollViewBinding), new PropertyMetadata(0.0, OnHorizontalOffsetPropertyChanged));

    //    #endregion // HorizontalOffset attached property

    //    //private static readonly DependencyProperty HorizontalScrollBarProperty = 
    //    //    DependencyProperty.RegisterAttached("HorizontalScrollBar", typeof(ScrollBar),
    //    //    typeof(ScrollViewBinding), new PropertyMetadata

    }
}
