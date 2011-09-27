using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnomeSurferPro.ViewModels;
using GenBank;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using System.Windows;
using GnomeSurferPro.Models;
using System.Windows.Input;
using GnomeSurferPro.Util;
using GnomeSurferPro.ThreadWorkers;
using System.Windows.Threading;

namespace GnomeSurferPro.ViewModels
{
    public delegate void GenePentagonContactDownHandler(Rect center, VisualGene.GeneDirection direction);

    public class SurfaceWindow1ViewModel:ViewModelBase
    {
        public event GenePentagonContactDownHandler GenePentagonContactDown;
        public event Action GeneBarMovedEvent;
        public event Action<IChromosomeStream> NewChromosomeSelected;

        #region Private members

        private IChromosomeStream _chromosomeStream;
        private ChromosomeBarViewModel _chromosomeBarViewModel;
        private PublicationsViewModel _publicationsViewModel;
        private ExtendedDesktopViewModel _extendedDesktopViewModel;
        //private ObservableCollection<IPublication> _SVIpublicationCollection;
        private TestSVIViewModel _testSVIViewModel;
        private SearchMenuViewModel _initialSearchMenu;
        private SearchShelfViewModel _persistentSearchMenu;
        private PrimerDesignerViewModel _primerDesignerViewModel;
        private IGenBankProvider _genBankProvider = new GenBankProviderImpl(); //new FakeGenBankProvider(); 

        private CompositeCollection _allObjectsCollection;
        private ChromosomeSearchStatusEnum _initialSearchStatus = ChromosomeSearchStatusEnum.Idle;

        #endregion Private members

        #region Public Properties

        public ChromosomeSearchStatusEnum InitialSearchStatus
        {
            get { return _initialSearchStatus; }
            set
            {
                if (_initialSearchStatus != value)
                {
                    _initialSearchStatus = value;
                    OnPropertyChanged("InitialSearchStatus");
                }
            }
        }

        public CompositeCollection AllObjectsCollection
        {
            get
            {
                return _allObjectsCollection;
            }
        }

        public PrimerDesignerViewModel PrimerDesignerViewModel
        {
            get { return _primerDesignerViewModel; }
        }

        public ChromosomeBarViewModel ChromosomeBarViewModel
        {
            get
            {
                return _chromosomeBarViewModel;
            }
            set
            {
                if (value != _chromosomeBarViewModel)
                {
                    _chromosomeBarViewModel = value;
                    OnPropertyChanged("ChromosomeBarViewModel");
                }
            }
        }

        public PublicationsViewModel PublicationsViewModel
        {
            get
            {
                return _publicationsViewModel;
            }
            set
            {
                if (value != _publicationsViewModel)
                {
                    _publicationsViewModel = value;
                    OnPropertyChanged("PublicationsViewModel");
                }
            }
        }

        public ExtendedDesktopViewModel ExtendedDesktopViewModel
        {
            get
            {
                return _extendedDesktopViewModel;
            }
            set
            {
                if (value != _extendedDesktopViewModel)
                {
                    _extendedDesktopViewModel = value;
                    OnPropertyChanged("ExtendedDesktopViewModel");
                }
            }
        }

        public IChromosomeStream ChromosomeStream
        {
            get { return _chromosomeStream; }
            private set
            {
                if (value != _chromosomeStream)
                {
                    _chromosomeStream = value;
                    OnPropertyChanged("CurrentChromosomeName");

                    if (NewChromosomeSelected != null)
                    {
                        NewChromosomeSelected(_chromosomeStream);
                    }
                }
            }
        }

        public String CurrentChromosomeName
        {
            get { return _chromosomeStream == null ? null : _chromosomeStream.Organism; }
        }

        public IGene SelectedGene
        {
            get { return _chromosomeBarViewModel.SelectedGene; }
        }

        public ObservableCollection<IPublication> TesterSVIPublicationCollection
        {
            get
            {
                return new ObservableCollection<IPublication>();
            }
        }

        public TestSVIViewModel TestSVIViewModel
        {
            get
            {
                return _testSVIViewModel;
            }
            set
            {
                if (value != _testSVIViewModel)
                {
                    _testSVIViewModel = value;
                    OnPropertyChanged("TestSVIViewModel");
                }
            }
        }

        public SearchMenuViewModel InitialSearchMenu
        {
            get
            {
                if (_initialSearchMenu == null)
                    _initialSearchMenu = new SearchMenuViewModel(OnChromosomeSelected);

                return _initialSearchMenu;
            }
        }

        public SearchShelfViewModel PersistentSearchMenu
        {
            get
            {
                if (_persistentSearchMenu == null)
                    _persistentSearchMenu = new SearchShelfViewModel(OnChromosomeSelected, PanToGene, this);

                return _persistentSearchMenu;
            }
        }

        public ICommand ShowSequenceCommand 
        {
            get { return new RelayCommand(Execute_ShowSequence); }
        }

        public ICommand ShowTranslationCommand
        {
            get { return new RelayCommand(Execute_ShowTranslation); }
        }

        public ICommand ShowPublicationsCommand
        {
            get { return new RelayCommand(Execute_ShowPublication); }
        }

        public ICommand ShowNotesCommand
        {
            get { return new RelayCommand(Execute_ShowNotes); }
        }

        public ICommand ShowPrimerDesignerCommand
        {
            get { return new RelayCommand(Execute_ShowPrimerDesigner); }
        }

        #endregion Public properties



        public SurfaceWindow1ViewModel()
        {
            _allObjectsCollection = new CompositeCollection();

            _chromosomeBarViewModel = new ChromosomeBarViewModel(_genBankProvider, this);
            _chromosomeBarViewModel.NewGeneSelected += new GeneSelectedHandler((gene) => OnPropertyChanged("SelectedGene"));

            _testSVIViewModel = new TestSVIViewModel();
            _extendedDesktopViewModel = new ExtendedDesktopViewModel(this);
            _primerDesignerViewModel = new PrimerDesignerViewModel(this);

            _allObjectsCollection.Add(_chromosomeBarViewModel);
            //_allObjectsCollection.Add(_testSVIViewModel);
            _allObjectsCollection.Add(_extendedDesktopViewModel);
            _allObjectsCollection.Add(PersistentSearchMenu);
        }

        private void RenderSequenceView(IGene gene)
        {
            SequenceViewModel sequenceViewModel = new SequenceViewModel(this, gene);
            int size = _allObjectsCollection.Add(sequenceViewModel);
        }

        private void RenderTranslationView(IGene gene)
        {
            TranslationViewModel translationViewModel = new TranslationViewModel(this, gene);
            _allObjectsCollection.Add(translationViewModel);
        }

        private void RenderNotesView(IGene gene)
        {
            NotesViewModel notesViewModel = new NotesViewModel(gene);
            _allObjectsCollection.Add(notesViewModel);
        }

        private void RenderPublicationsView(IGene gene)
        {
            PublicationsViewModel publicationsViewModel = new PublicationsViewModel(this, gene);
            _allObjectsCollection.Add(publicationsViewModel);
        }

        public void EraseItem(object viewModel)
        {
            if (_allObjectsCollection.Contains(viewModel))
            {
                _allObjectsCollection.Remove(viewModel);
            }
        }

        #region Routed Events for Drag and Drop from SVI to LBI, not using in GnomeSurferPro

        public void Routed_PublicationsArticle_PreviewContactDown(object sender, ContactEventArgs e)
        {
           // _publicationsViewModel.Routed_ScatterView_PreviewContactDown(sender, e);
        }

        public void Routed_PublicationsArticle_DragCanceled(object sender, SurfaceDragDropEventArgs e)
        {
            //if (!(e.Cursor.Data is PublicationsViewModel))
            //{                
            //    Publication publication = e.Cursor.Data as Publication;

            //    if (SVIPublicationCollection.Contains(publication))//filter this method to only apply to pubArticles currently in mainSV
            //    {
            //        ScatterViewItem item = publication.DraggedElement as ScatterViewItem;
            //        if (item != null)
            //        {
                        
            //            item.Orientation = e.Cursor.GetOrientation((ScatterView)sender);
            //            item.Center = e.Cursor.GetPosition((ScatterView)sender);
            //            item.Visibility = Visibility.Visible;
            //        }
            //    }
            //}
        }

        #endregion


        public void Routed_PublicationsArticle_SVIInitialized(object sender, EventArgs e)
        {
            if (sender is ScatterViewItem && (sender as ScatterViewItem).DataContext != null)
            {
                //get the PublicationsArticleViewModel related to current SVI
                int articleIndex = AllObjectsCollection.IndexOf((PublicationsArticleViewModel)(((ScatterViewItem)sender).DataContext));

                //set cetner and orientation of newly constructed SVI to have "drop in place" effect
                ((ScatterViewItem)sender).Center = ((PublicationsArticleViewModel)AllObjectsCollection[articleIndex]).SVICenter;
                ((ScatterViewItem)sender).Orientation = ((PublicationsArticleViewModel)AllObjectsCollection[articleIndex]).SVIOrientation;
            }
        }

        private void PanToGene(IGene gene)
        {
            _chromosomeBarViewModel.CentralBasePair = gene.LeftBasePair;
        }

        private void OnChromosomeSelected(String chromosomeId)
        {
            InitialSearchStatus = ChromosomeSearchStatusEnum.Searching;
            ChromosomeSearchWorker worker = new ChromosomeSearchWorker(Dispatcher.CurrentDispatcher, _genBankProvider,
                chromosomeId, (stream) => 
                { 
                    this.ChromosomeStream = stream;
                    _persistentSearchMenu.RetractShelf();
                    InitialSearchStatus = ChromosomeSearchStatusEnum.Complete;
                }
            );
            worker.Start();
        }

        public void OnGenePentagonContacted(Rect position, VisualGene.GeneDirection direction)
        {
            if (GenePentagonContactDown != null)
            {
                GenePentagonContactDown(position, direction);
            }
        }

        // Action for ShowSequence command
        // Argument should be a visual gene
        private void Execute_ShowSequence(object arg)
        {
            IGene gene = this.SelectedGene;
            RenderSequenceView(gene);
        }

        private void Execute_ShowTranslation(object arg)
        {
            IGene gene = this.SelectedGene;
            RenderTranslationView(gene);
        }

        private void Execute_ShowPublication(object arg)
        {
            IGene gene = this.SelectedGene;
            RenderPublicationsView(gene);
        }

        private void Execute_ShowNotes(object arg)
        {
            IGene gene = this.SelectedGene;
            RenderNotesView(gene);
        }

        private void Execute_ShowPrimerDesigner(object arg)
        {
            IGene gene = this.SelectedGene;
            _primerDesignerViewModel.ShowDesigner(gene);
        }

        public void HideGeneInfoMenu()
        {
            if (GeneBarMovedEvent != null)
            {
                GeneBarMovedEvent();
            }
        }
    }
}
