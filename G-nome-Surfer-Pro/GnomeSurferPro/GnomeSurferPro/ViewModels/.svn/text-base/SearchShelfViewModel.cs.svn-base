using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GenBank;
using GnomeSurferPro.Util;
using System.Windows.Input;
using System.Windows.Threading;
using GnomeSurferPro.ThreadWorkers;

namespace GnomeSurferPro.ViewModels
{

    public enum GeneSearchStatusEnum
    {
        Idle, // The backend is not performing a search for a gene
        Searching, // The backend is currently searching for a gene (probably in a separate thread)
        GeneNotFound, // The most recent search came up empty
    }

    public class SearchShelfViewModel : ViewModelBase
    {
        private readonly Point _retractedCenter = new Point(512, -327);

        private Action<IGene> _onGeneSelected;
        private SearchMenuViewModel _searchMenuVM;
        private Point _center;
        private SurfaceWindow1ViewModel _surfaceWindowViewModel;
        private String _geneSearchBoxText;
        private GeneSearchStatusEnum _geneSearchStatus;
        private RelayCommand _geneSearchCommand;

        public SearchMenuViewModel SearchMenuViewModel
        {
            get { return _searchMenuVM; }
        }

        public ICommand GeneSearchCommand
        {
            get { return _geneSearchCommand; }
        }

        public GeneSearchStatusEnum GeneSearchStatus
        {
            get { return _geneSearchStatus; }
            set
            {
                if (value != _geneSearchStatus)
                {
                    _geneSearchStatus = value;
                    OnPropertyChanged("GeneSearchStatus");
                }
            }
        }

        public String CurrentChromosomeName
        {
            get { return _surfaceWindowViewModel.CurrentChromosomeName; }
        }

        public String GeneSearchBoxText
        {
            get { return _geneSearchBoxText; }
            set
            {
                if (_geneSearchBoxText != value)
                {
                    _geneSearchBoxText = value;
                    OnPropertyChanged("GeneSearchBoxText");
                    _geneSearchCommand.InvokeCanExecuteChanged();
                }
            }
        }

        public Point Center
        {
            get { return _center; }
            set
            {
                if (_center != value)
                {
                    _center = value;
                    OnPropertyChanged("Center");
                }
            }
        }

        public Point RetractedCenter
        {
            get { return _retractedCenter; }
        }

        public SearchShelfViewModel(Action<String> onChromosomeSelected, Action<IGene> onGeneSelected,
            SurfaceWindow1ViewModel surfaceWindowViewModel)
        {
            _searchMenuVM = new SearchMenuViewModel(onChromosomeSelected);
            _onGeneSelected = onGeneSelected;
            _surfaceWindowViewModel = surfaceWindowViewModel;
            _surfaceWindowViewModel.NewChromosomeSelected += OnNewChromosomeSelected;
            _geneSearchCommand = new RelayCommand(Execute_GeneSearch, CanExecute_GeneSearch);
            GeneSearchStatus = GeneSearchStatusEnum.Idle;
            RetractShelf();
        }

        public void RetractShelf()
        {
            Center = _retractedCenter;
        }
    
        private void OnNewChromosomeSelected(IChromosomeStream arg)
        {
            OnPropertyChanged("CurrentChromosomeName");
        }

        public void Execute_GeneSearch(object arg) // ignore parameter
        {
            GeneSearchWorker worker = new GeneSearchWorker(Dispatcher.CurrentDispatcher, 
                                                            _surfaceWindowViewModel.ChromosomeStream,
                                                            GeneSearchBoxText,
                                                            GeneSearchCallback);
            worker.Start();
            GeneSearchBoxText = null;
            Microsoft.Surface.Core.SurfaceKeyboard.IsVisible = false;

            this.GeneSearchStatus = GeneSearchStatusEnum.Searching;
        }

        private bool CanExecute_GeneSearch(object arg) // ignore parameter
        {
            return !String.IsNullOrEmpty(GeneSearchBoxText);
        }

        private void GeneSearchCallback(IGene result)
        {
            if (result == null)
            {
                GeneSearchStatus = GeneSearchStatusEnum.GeneNotFound;
                return;
            }

            GeneSearchStatus = GeneSearchStatusEnum.Idle;
            _onGeneSelected(result);
        }
    }
}
