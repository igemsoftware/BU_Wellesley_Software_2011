using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenBank;
using System.Windows;
using System.Windows.Media;
using Microsoft.Surface.Presentation.Controls;
using System.Windows.Controls;

namespace GnomeSurferPro.ViewModels
{
    class TranslationViewModel : ViewModelBase
    {
        private SurfaceWindow1ViewModel _mainVM;
        private SolidColorBrush _background;
        private ScatterViewItem _myDadSVI; //The scatterviewitem that has me as a DataContext
        //private double _verticalScrollOffset;
        //private ScatterViewItem _myUncleSVI; //The scatterviewitem that is aligned. Hook our scroll viewers
        //private SurfaceScrollViewer _mySurfaceScrollViewer;

        public TranslationViewModel(SurfaceWindow1ViewModel mainVM, IGene model)
        {
            _mainVM = mainVM;
            _model = model;
            _background = new SolidColorBrush(Colors.Black);
            //_myUncleSVI = null; //Nothing is aligned to me yet
        }

        private IGene _model;

        public int FirstBasePair
        {
            get { return _model.IsForward ? _model.LeftBasePair : _model.RightBasePair; }
        }

        public int LastBasePair
        {
            get { return _model.IsForward ? _model.RightBasePair : _model.LeftBasePair; }
        }

        public IGene Model
        {
            get { return _model; }
        }

        public String LocusTag
        {
            get { return _model.LocusTag; }
        }

        public String Name
        {
            get { return _model.Name; }
        }

        public String Translation
        {
            get { return spaceSequence(_model.Translation); }
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
            for (int i = 0; i < originalSequence.Length - 1; i++)
            {
                //for every 7th three-letter sequence, don't add padding
                if (i > 6 && i % 7 == 0)
                {
                    String tempSeq = Environment.NewLine + Environment.NewLine + originalSequence.Substring(i, 1).PadRight(4);
                    placeHolder.Add(tempSeq);

                }
                else
                    placeHolder.Add((originalSequence.Substring(i, 1)).PadRight(4));
            }

            String finalSequence = Environment.NewLine + String.Join("", placeHolder.ToArray());
            return finalSequence;

        }

        //public void Routed_SurfaceScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        //{
        //    VerticalScrollOffset = ((SurfaceScrollViewer)sender).VerticalOffset;
        //    if (MyUncleSVI != null)
        //    {
        //        ((SequenceViewModel)MyUncleSVI.DataContext).MySurfaceScrollViewer.ScrollToVerticalOffset(VerticalScrollOffset);
        //    }
        //}
    }
}
