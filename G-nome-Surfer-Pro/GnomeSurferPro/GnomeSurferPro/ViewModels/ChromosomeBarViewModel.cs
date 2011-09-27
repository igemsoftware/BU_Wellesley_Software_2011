using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using GenBank;
using System.Windows.Input;
using GnomeSurferPro.Util;

namespace GnomeSurferPro.ViewModels
{
    public delegate void GeneSelectedHandler(IGene selectedGene);

    public class ChromosomeBarViewModel : ViewModelBase
    {
        public event GeneSelectedHandler NewGeneSelected;

        #region Private members

        private const double PixelsPerBasePair = 0.3;
        private const int TickMarkBasePairInterval = 1000;

        private SurfaceWindow1ViewModel _surfaceWindowVM;
        private IGenBankProvider _provider;

        private ObservableCollection<IVisualPart> _visualParts;
        private double _contentWidth;
        private double _leftmostVisiblePixel;
        private Size _viewportSize;
        private double _contentOriginPosition;
        private double _contentOffset;
        private IGene _selectedGene;
        private String _wheelImageSource;

        private ICommand _showSequenceCommand;
        private ICommand _showTranslationCommand;
        private ICommand _showPublicationsCommand;
        private ICommand _showPrimerDesignerCommand;

        #endregion // Private members

        #region Public Properties

        public IGene SelectedGene
        {
            get { return _selectedGene; }
            set
            {
                if (_selectedGene != value)
                {
                    _selectedGene = value;
                    OnPropertyChanged("SelectedGene");
                    if (NewGeneSelected != null)
                    {
                        NewGeneSelected(value);
                    }
                }
            }
        }

        public int TotalBasePairs
        {
            get { return (int)(_contentWidth / PixelsPerBasePair); }
        }

        public ObservableCollection<IVisualPart> Parts
        {
            get { return _visualParts; }
            set
            {
                if (_visualParts != value)
                {
                    _visualParts = value;
                    OnPropertyChanged("Parts");
                }
            }
        }

        public double ContentWidth
        {
            get { return _contentWidth; }
            set
            {
                if (_contentWidth != value)
                {
                    _contentWidth = value;
                    OnPropertyChanged("ContentWidth");
                }
            }
        }

        public double LeftmostVisiblePixel
        {
            get { return _leftmostVisiblePixel; }
            set
            {
                if (value != _leftmostVisiblePixel)
                {
                    _leftmostVisiblePixel = value;
                    OnPropertyChanged("LeftmostVisiblePixel");
                    OnPropertyChanged("CentralBasePair");
                    OnPropertyChanged("WheelOrientation");
                }
            }
        }

        public double ContentOffset
        {
            get { return _contentOffset; } 
            set 
            {
                if (value != _contentOffset)
                {
                    _contentOffset = value;
                    OnPropertyChanged("ContentOffset");
                }
            }
        }

        public Size ViewportSize
        {
            get { return _viewportSize; }
            set
            {
                if (value != _viewportSize)
                {
                    _viewportSize = value;
                    OnPropertyChanged("ViewportSize");
                }
            }
        }

        public double ContentOriginPosition
        {
            get { return _contentOriginPosition; }
            set
            {
                if (value != _contentOriginPosition)
                {
                    _contentOriginPosition = value;
                    OnPropertyChanged("ContentOriginPosition");
                }
            }
        }

        public int CentralBasePair
        {
            get
            {
                double centralViewablePixel = LeftmostVisiblePixel + ViewportSize.Width / 2;
                return ConvertOffsetToBasePair(centralViewablePixel);
            }
            set
            {
                if (value == CentralBasePair) { return; }
                LeftmostVisiblePixel = ConvertBasePairToOffset(value) - ViewportSize.Width / 2;
                // Setting leftmostvisiblepixel will notify that centralbasepair has changed
            }
        }

        public double WheelOrientation
        {
            get
            {
                return -360 * ((double) CentralBasePair / TotalBasePairs);
            }
            set
            {
                if (value != WheelOrientation)
                {
                    double degrees = value % 360;
                    int basePair = TotalBasePairs - (int) ((degrees / 360) * TotalBasePairs);
                    LeftmostVisiblePixel = ConvertBasePairToOffset(basePair);
                    // Setting leftmostvisiblepixel will notify that wheelorientation has changed
                }
            }
        }

        public string ChromosomeId
        {
            get { return _surfaceWindowVM.ChromosomeStream.AccessionID; }
        }

        //Wheel's image
        public String WheelImageSource
        {
            get
            {
                if (String.IsNullOrEmpty(ChromosomeId))
                {
                    return null;
                }
                ChromosomeWheelImageGenerator wheelGenerator = new ChromosomeWheelImageGenerator(ChromosomeId);
                return wheelGenerator.getWheelImageSource();
            }
        }

        #endregion Public properties

        public ChromosomeBarViewModel(IGenBankProvider provider, SurfaceWindow1ViewModel surfaceWindowVM)
        {
            this._provider = provider;
            this._surfaceWindowVM = surfaceWindowVM;
            surfaceWindowVM.NewChromosomeSelected += new Action<IChromosomeStream>(OnNewChromosomeStream);
        }

        #region Helper methods 

        private double ConvertBasePairToOffset(int basePair)
        {
            double offsetFromContentOrigin = basePair * PixelsPerBasePair;
            double contentPixelsLeftOfOrigin = ContentOriginPosition - ContentOffset;
            double contentPixelsRightOfOrigin = ContentWidth - contentPixelsLeftOfOrigin;
            if (offsetFromContentOrigin < contentPixelsRightOfOrigin)
            {
                return ContentOriginPosition + offsetFromContentOrigin;
            }
            else
            {
                return ContentOriginPosition - (ContentWidth - offsetFromContentOrigin);
            }
        }


        private int ConvertOffsetToBasePair(double offset)
        {
            if (offset >= ContentOriginPosition) // Then base pair is to the right of the content origin
            {
                return (int)((offset - ContentOriginPosition) / PixelsPerBasePair);
            }
            else // Then base pair is to the left of the content origin
            {
                return (int)((ContentWidth - (ContentOriginPosition - offset)) / PixelsPerBasePair);
            }
        }

        private void OnNewChromosomeStream(IChromosomeStream stream)
        {
            OnPropertyChanged("ChromosomeId");
            OnPropertyChanged("WheelImageSource");

            ObservableCollection<IVisualPart> parts = ConvertIGenesToIVisualParts(stream.GeneList);
            ContentWidth = stream.TotalBasePairs * PixelsPerBasePair;

            AddTickmarksToCollection(parts, ContentWidth, TickMarkBasePairInterval);
            Parts = parts;
        }

        private static ObservableCollection<IVisualPart> ConvertIGenesToIVisualParts(ICollection<IGene> geneList)
        {
            ObservableCollection<IVisualPart> parts = new ObservableCollection<IVisualPart>();
            foreach (IGene gene in geneList)
            {
                //string name = gene.Name != null ? gene.Name : gene.LocusTag;
               
                parts.Add(new VisualGene(gene, PixelsPerBasePair));
            }
            return parts;
        }

        private static void AddTickmarksToCollection(Collection<IVisualPart> partsCollection,
            double contentWidth,
            double basePairInterval)
        {
            double basePair = 0;
            while (basePair * PixelsPerBasePair + basePairInterval * PixelsPerBasePair < contentWidth)
            {
                VisualTickMark tickMark = new VisualTickMark(basePair, basePair * PixelsPerBasePair);
                partsCollection.Add(tickMark);
                basePair += basePairInterval;
            }
        }

        #endregion Helper methods

        public void GenePentagonContacted(Rect position, VisualGene.GeneDirection direction)
        {
            _surfaceWindowVM.OnGenePentagonContacted(position, direction);
        }

        internal void ScrollBarChanged()
        {
            _surfaceWindowVM.HideGeneInfoMenu();
        }
    }
}
