using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnomeSurferPro.ViewModels
{
    public class VisualTickMark : IVisualPart
    {

        #region Private members
        private double _displayedValue;
        private double _position;
        
        #endregion // Private members

        #region Public properties
        public double DisplayedValue
        {
            get { return _displayedValue; }
        }

        public double Position
        {
            get { return _position; }
        }
        
        #endregion // Public Properties

        public VisualTickMark(double displayedValue, double position)
        {
            this._displayedValue = displayedValue;
            this._position = position;
        }
    }
}
