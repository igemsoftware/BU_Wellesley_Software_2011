using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GenBank;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using Microsoft.Surface.Presentation.Controls;


namespace GnomeSurferPro.ViewModels
{
    class SequenceViewModel : ViewModelBase
    {
        private SurfaceWindow1ViewModel _mainVM;
        private SolidColorBrush _background;
        private ScatterViewItem _myDadSVI; //The scatterviewitem that has me as a DataContext
        //private double _verticalScrollOffset;
        //private ScatterViewItem _myUncleSVI; //The scatterviewitem that is aligned. Hook our scroll viewers
        //private SurfaceScrollViewer _mySurfaceScrollViewer;


        public SequenceViewModel(SurfaceWindow1ViewModel mainVM, IGene model)
        {
            _mainVM = mainVM;
            _model = model;
            _background = new SolidColorBrush(Colors.Black);
        }


        private IGene _model;

        
       public IGene Model
        {
            get { return _model; }
        }

        public int FirstBasePair
        {
            get { return _model.IsForward ? _model.LeftBasePair : _model.RightBasePair; }
        }

        public int LastBasePair
        {
            get { return _model.IsForward ? _model.RightBasePair : _model.LeftBasePair; }
        }

        public String LocusTag
        {
            get { return _model.LocusTag; }
        }

        public String Name
        {
            get { return _model.Name; }
        }

        public String Sequence
        {
            get { return spaceSequence(_model.Sequence); }
        }

        public SolidColorBrush Background
        {
            get { return _background; }
            set
            {
                if (_background != value)
                {
                    _background = value;
                    OnPropertyChanged("Background");
                }
            }
        }

        public ScatterViewItem MyDadSVI
        {
            get { return _myDadSVI; }
            set
            {
                if (_myDadSVI != value)
                {
                    _myDadSVI = value;
                    OnPropertyChanged("MyDadSVI");
                }
            }
        }

        //public double VerticalScrollOffset
        //{
        //    get { return _verticalScrollOffset; }
        //    set
        //    {
        //        if (_verticalScrollOffset != value)
        //        {
        //            _verticalScrollOffset = value;
        //            OnPropertyChanged("VerticalScrollOffset");
        //        }
        //    }
        //}

        //public ScatterViewItem MyUncleSVI
        //{
        //    get { return _myUncleSVI; }
        //    set
        //    {
        //        if (_myUncleSVI != value)
        //        {
        //            _myUncleSVI = value;
        //            OnPropertyChanged("MyUncleSVI");
        //        }
        //    }
        //}

        //public SurfaceScrollViewer MySurfaceScrollViewer
        //{
        //    get { return _mySurfaceScrollViewer; }
        //    set
        //    {
        //        if (_mySurfaceScrollViewer != value)
        //        {
        //            _mySurfaceScrollViewer = value;
        //            OnPropertyChanged("MySurfaceScrollViewer");
        //        }
        //    }
        //}

        public String spaceSequence(String originalSequence)
        {
            List<String> placeHolder = new List<string>();
            for (int i = 0; i < originalSequence.Length - 1; i = i+3)
            {
                //for every 7th three-letter sequence, don't add padding
                if (i >20 && i%21 == 0)
                {
                    String tempSeq = Environment.NewLine + Environment.NewLine + originalSequence.Substring(i, 3).PadRight(4);
                    placeHolder.Add(tempSeq);

                }
                else
                    placeHolder.Add((originalSequence.Substring(i,3)).PadRight(4));
            }

            String finalSequence = String.Join("", placeHolder.ToArray());
            return finalSequence;
            
        }
    }
}
