using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using GenBank;

namespace GnomeSurferPro.ViewModels
{
    public class VisualGene : IVisualPart
    {
        #region Private members
        private const int _height = 50;

        private String _name;
        private String _locusTag;
        private double _leftPosition;
        private double _length;
        private GeneDirection _direction;
        private PointCollection _pentagonPoints;
        private IGene _model;

        #endregion // Private members

        #region Public properties
        public String Name 
        {
            get { return _name; }
        }

        public double LeftPosition
        {
            get { return _leftPosition; }
        }

        public double Length
        {
            get { return _length; }
        }

        public GeneDirection Direction
        {
            get { return _direction; }
        }

        public Point ZerothPentagonPoint
        {
            get { return _pentagonPoints.ElementAt(0); }
        }

        public Point OnethPentagonPoint
        {
            get { return _pentagonPoints.ElementAt(1); }
        }

        public Point TwothPentagonPoint
        {
            get { return _pentagonPoints.ElementAt(2); }
        }

        public Point ThreethPentagonPoint
        {
            get { return _pentagonPoints.ElementAt(3); }
        }

        public Point FourthPentagonPoint
        {
            get { return _pentagonPoints.ElementAt(4); }
        }

        public double Height
        {
            get { return _height; }
        }

        public String LocusTag
        {
            get { return _locusTag; }
        }

        public IGene Model
        {
            get { return _model; }
        }

        #endregion // Public properties

        public VisualGene(IGene model, double pixelsPerBasePair)
        {
            _model = model;
            _name = model.Name;
            _leftPosition = model.LeftBasePair * pixelsPerBasePair;
            _length = (model.RightBasePair - model.LeftBasePair) * pixelsPerBasePair;
            _direction = model.IsForward ? GeneDirection.Forward : GeneDirection.Reverse;
            _locusTag = model.LocusTag;

            // Define the points in the pentagon container
            _pentagonPoints = new PointCollection(5);
            double rectangleLength = _length > _height / 2 ? _length - _height / 2 : 0;
            if (_direction == GeneDirection.Forward)
            {
                
                _pentagonPoints.Add(new Point(0, 0));
                _pentagonPoints.Add(new Point(rectangleLength, 0));
                _pentagonPoints.Add(new Point(_length, _height / 2));
                _pentagonPoints.Add(new Point(rectangleLength, _height));
                _pentagonPoints.Add(new Point(0, _height));
            }
            else
            {
                _pentagonPoints.Add(new Point(0, _height / 2));
                _pentagonPoints.Add(new Point(_height / 2, _height));
                _pentagonPoints.Add(new Point(_height / 2 + rectangleLength, _height));
                _pentagonPoints.Add(new Point(_height / 2 + rectangleLength, 0));
                _pentagonPoints.Add(new Point(_height / 2, 0));
            }
        }

        public override string ToString()
        {
            return String.Format("{0}: ({1}, {2})", _name, _leftPosition, _length);
        }

        public enum GeneDirection
        {
            Forward,
            Reverse
        }
    }
}
