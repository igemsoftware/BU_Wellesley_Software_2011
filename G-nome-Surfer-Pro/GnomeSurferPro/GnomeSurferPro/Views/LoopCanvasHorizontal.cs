using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Controls.Primitives;
using GnomeSurferPro.ViewModels;

// See http://msdn.microsoft.com/en-us/library/ee804761(v=surface.10).aspx
namespace GnomeSurferPro.Views
{
    public partial class LoopCanvasHorizontal : Canvas, ISurfaceScrollInfo
    // Notice: ContentWidth must be set in XAML //

    {
        #region Private Members

        private bool _horizontalScrollAllowed = true;       // Is the scrollview allowed to scroll
        private ScrollViewer _owner;                        // Not sure what this is
        private Size _extent = new Size(0, 0);              // The total size over which the viewport can travel
        private Point _viewportOffset = new Point();        // The position of the viewport within the extent
        private bool _viewportPositionDirty;                // Not sure what this is

        #endregion

        #region ContentOffset dependency property

        public double ContentOffset
        {
            get { return (double)GetValue(ContentOffsetProperty); }
            set { SetValue(ContentOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentOffsetProperty =
            DependencyProperty.Register("ContentOffset", typeof(double), typeof(LoopCanvasHorizontal), new UIPropertyMetadata(0.0));

        #endregion

        #region ContentOriginOffset dependency property

        public double ContentOriginOffset
        {
            get { return (double)GetValue(ContentOriginOffsetProperty); }
            set { SetValue(ContentOriginOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentOriginOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentOriginOffsetProperty =
            DependencyProperty.Register("ContentOriginOffset", typeof(double), typeof(LoopCanvasHorizontal), new UIPropertyMetadata(0.0));

        #endregion

        #region Viewport dependency property

        public Size Viewport
        {
            get { return (Size)GetValue(ViewportProperty); }
            set { SetValue(ViewportProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BindableViewportWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewportProperty =
            DependencyProperty.Register("Viewport", typeof(Size), typeof(LoopCanvasHorizontal), new UIPropertyMetadata(new Size()));

        #endregion

        #region ContentWidth dependency property

        public int ContentWidth
        {
            get { return (int)GetValue(ContentWidthProperty); }
            set { SetValue(ContentWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentWidthProperty =
            DependencyProperty.Register("ContentWidth", typeof(int), typeof(LoopCanvasHorizontal), new UIPropertyMetadata(0));

        #endregion


        // Constructor
        public LoopCanvasHorizontal()
        {
            RenderTransform = new TranslateTransform();
        }


        private double LeftmostContentPixel
        {
            get
            {
                double pixelsLeftOfOrigin = ContentOriginOffset - ContentOffset;
                return ContentWidth - pixelsLeftOfOrigin;
            }
        }

        private double ConvertCanvasLeftToOffset(double canvasLeft)
        {
            if (canvasLeft < LeftmostContentPixel) // Then the canvasleft is to the right of the content offset origin
            {
                return ContentOriginOffset + canvasLeft;
            }
            else // Then the canvasleft is to the left of the content offset origin
            {
                return ContentOffset + (canvasLeft - LeftmostContentPixel);
            }
        }

        #region IScrollInfo Properties
        // Gets or sets a value that determines if the content can be scrolled horizontally.
        public bool CanHorizontallyScroll
        {
            get
            {
                return true;
            }
            set
            {
                if (value)
                {
                    _horizontalScrollAllowed = value;
                }
            }
        }

        // Gets or sets a value that determines if the content can be scrolled vertically.
        public bool CanVerticallyScroll
        {
            get
            {
                return false;
            }
            set
            {
                // not supported
            }
        }

        // Gets a value that describes the height of the area.
        public double ExtentHeight
        {
            get { return _extent.Height; }
        }

        // Gets a value that describes the width of the area.
        public double ExtentWidth
        {
            //get { return _extent.Width; }
            get { return _extent.Width; }
        }

        /// Gets a value that describes the vertical offset of the view box.
        public double VerticalOffset
        {
            get { return _viewportOffset.Y; }
        }


        // Gets a value that describes the horizontal offset of the view box.
        public double HorizontalOffset
        {
            get { return _viewportOffset.X; }
        }

        // Gets a value that describes the height of the viewport.
        public double ViewportHeight
        {
            get { return Viewport.Height; }
        }

        // Gets a value that describes the width of the viewport.
        public double ViewportWidth
        {
            get { return Viewport.Width; }
        }

        // Gets or sets the owner.
        public ScrollViewer ScrollOwner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }
        #endregion

        #region IScrollInfo Positioning Methods
        // Scroll content up.
        public void LineUp()
        {
            // Not implemented
        }

        // Scroll content down.
        public void LineDown()
        {
            // Not implemented
        }

        public void LineLeft()
        {
            ScrollContent(-1);
        }

        public void LineRight()
        {
            ScrollContent(1);
        }

        // Scrolls the content up by ten lines.
        public void MouseWheelUp()
        {
            // Not implemented
        }

        // Scrolls the content down by ten lines. 
        public void MouseWheelDown()
        {
            // Not implemented
        }

        public void MouseWheelLeft()
        {
            // Not implemented. Cannot scroll horizontally.
        }

        public void MouseWheelRight()
        {
            // Not implemented. Cannot scroll horizontally. 
        }

        public void PageUp()
        {
            // Not implemented
        }

        public void PageDown()
        {
            // Not implemented
        }

        public void PageLeft()
        {
            ScrollContent(-Viewport.Width);
        }

        public void PageRight()
        {
            ScrollContent(Viewport.Width);
        }
        #endregion

        #region IScrollInfo Offset Methods
        public void SetVerticalOffset(double newVerticalOffset)
        {
            // Not implemented
        }

        public void SetHorizontalOffset(double newHorizontalOffset)
        {
            //if (CanHorizontallyScroll)
            //{
            //    if (double.IsNaN(_previousOffset))
            //    {
            //        _previousOffset = newHorizontalOffset;
            //    }

            //    double difference = _previousOffset - newHorizontalOffset;

            //    // Scroll the content.
            //    ScrollContent(difference);

            //    _previousOffset = newHorizontalOffset;
            //}
            ScrollContent(_viewportOffset.X - newHorizontalOffset);
        }
        #endregion

        #region IScrollInfo MakeVisible Method
        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            double itemCanvasLeft = (double)visual.GetValue(Canvas.LeftProperty);
            double itemOffset = ConvertCanvasLeftToOffset(itemCanvasLeft);

            // If the item is not fully in view on the left, 
            // adjust the offset to bring it into view.
            if (itemOffset < _viewportOffset.X)
            {
                ScrollContent(_viewportOffset.X - itemOffset);
            }

            // If the item is not fully in view on the right, 
            // adjust the offset to bring it into view.
            if (itemOffset + rectangle.Width > _viewportOffset.X + ViewportWidth)
            {
                ScrollContent((_viewportOffset.X + ViewportWidth) -
                    (itemOffset + rectangle.Width));
            }

            return rectangle;
        }
        #endregion

        #region ISurfaceScrollInfo Members
        public Vector ConvertFromViewportUnits(Point origin, Vector offset)
        {
            return offset;
        }

        public Vector ConvertToViewportUnits(Point origin, Vector offset)
        {
            return offset;
        }

        public Vector ConvertToViewportUnitsForFlick(Point origin, Vector offset)
        {
            return offset;
        }
        #endregion

        #region Overridden Layout Methods
        protected override Size MeasureOverride(Size availableSize)
        {
            // If there's no children, take all the space.
            if (InternalChildren.Count == 0)
            {
                return availableSize;
            }

            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }

            // The viewport should be as large as it can be.
            Viewport = availableSize;

            // Remeasuring could invalidate the current viewport position. Mark it as dirty.
            _viewportPositionDirty = true;

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // If there's no children, take all the space.
            if (InternalChildren.Count == 0)
            {
                return finalSize;
            }

            // Arrange the viewport relative to the extent.
            if (_viewportPositionDirty)
            {
                PositionViewportAndExtent();
            }

            Rect arrangeInMe;
            double childCanvasLeft;
            double childCanvasTop;
            double leftOffset;

            foreach (UIElement item in InternalChildren)
            {
                childCanvasLeft = (double)item.GetValue(Canvas.LeftProperty);
                childCanvasTop = (double)item.GetValue(Canvas.TopProperty);
                leftOffset = ConvertCanvasLeftToOffset(childCanvasLeft);
                arrangeInMe = new Rect(leftOffset, childCanvasTop, item.DesiredSize.Width, item.DesiredSize.Height);
                item.Arrange(arrangeInMe);
            }

            return finalSize;
        }
        #endregion

        #region Viewport and Extent Methods
        private void PositionViewportAndExtent()
        {
            // If the items all fit in the viewport at the same time, 
            // disable scrolling and center the items.
            if (ContentWidth < Viewport.Width)
            {
                _extent = new Size(ContentWidth, Viewport.Height);
                ContentOffset = 0;
                ContentOriginOffset = 0;
                SetViewportOffset(0);
                CanHorizontallyScroll = false;
            }

            // Otherwise, extend the extent past both ends of the viewport 
            // so there will be plenty of space in which to scroll the items.
            else
            {
                // Make sure the extent is plenty large. 
                _extent = new Size(Math.Max(1000000, ContentWidth * 15), Viewport.Height);
                SetViewportOffset((_extent.Width - Viewport.Width) / 2);
                ContentOffset = (_extent.Width - ContentWidth) / 2;
                ContentOriginOffset = ContentOffset;
                CanHorizontallyScroll = true;
            }

            _viewportPositionDirty = false;

            // Because the offset was changed, the current scroll info isn't valid anymore.
            if (_owner != null)
            {
                _owner.InvalidateScrollInfo();
            }
        }

        private void SetViewportOffset(double newOffset)
        {
            // Validate the input.
            if (newOffset < 0 || Viewport.Width >= _extent.Width)
            {
                newOffset = 0;
            }

            if (newOffset + Viewport.Width >= _extent.Width)
            {
                newOffset = _extent.Width - Viewport.Width;
            }

            // Value is validated, so use it.
            _viewportOffset.X = newOffset;

            // Adjust the transform to display based on the new offset.
            ((TranslateTransform)RenderTransform).X = -newOffset;

            // If the viewport is within 10% of either of the content boundaries, rebalance 
            // the content area around the viewport
            double contentBoundaryPercent = 0.1;
            double leftBoundaryOffset = ContentOffset + contentBoundaryPercent * ContentWidth;
            double rightBoundaryOffset = ContentOffset + ContentWidth - contentBoundaryPercent * ContentWidth;

            // Move items as needed.
            if (_viewportOffset.X < leftBoundaryOffset)
            {
                MoveItemsFromRightToLeft();
            }

            if (_viewportOffset.X + ViewportWidth > rightBoundaryOffset)
            {
                MoveItemsFromLeftToRight();
            }
        }

        private void ScrollContent(double adjustment)
        {
            SetViewportOffset(_viewportOffset.X - adjustment);
            _owner.InvalidateScrollInfo();
        }
        #endregion

        #region Move Item Methods
        private void MoveItemsFromRightToLeft()
        {
            // Set _contentOffset so that 2/3 of content is to the left of the viewport
            double contentAreaNotInViewport = ContentWidth - Viewport.Width;
            ContentOffset = _viewportOffset.X - contentAreaNotInViewport * (2.0 / 3.0);
            while (ContentOriginOffset - ContentOffset > ContentWidth)
            {
                ContentOriginOffset -= ContentWidth;
            }

            // Need to redraw the items.
            InvalidateVisual();
        }

        private void MoveItemsFromLeftToRight()
        {
            // Set _contentOffset so that 2/3 of content is to the right of the viewport
            double contentAreaNotInViewport = ContentWidth - Viewport.Width;
            ContentOffset = _viewportOffset.X - contentAreaNotInViewport * (1.0 / 3.0);
            while ((ContentOffset + ContentWidth) - ContentOriginOffset > ContentWidth)
            {
                ContentOriginOffset += ContentWidth;
            }

            // Need to redraw the items.
            InvalidateVisual();
        }
        #endregion

    } // end Class LoopPanelVertical
}