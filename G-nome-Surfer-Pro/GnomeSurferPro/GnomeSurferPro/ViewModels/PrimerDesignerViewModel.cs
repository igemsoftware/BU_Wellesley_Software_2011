using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenBank;
using System.Windows;
using System.Windows.Input;
using GnomeSurferPro.Util;

namespace GnomeSurferPro.ViewModels
{
    public class PrimerDesignerViewModel : ViewModelBase
    {
        private IGene _gene;
        private Visibility _visibility;
        private SurfaceWindow1ViewModel _surfaceWindowViewModel;
        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get { return _backCommand; }
        }

        public IGene Gene
        {
            get { return _gene; }
            private set
            {
                if (value != _gene)
                {
                    _gene = value;
                    OnPropertyChanged("Gene");
                }
            }
        }

        // Should really be a boolean "IsVisible". The binding should use a IConverter to convert from
        // boolean to Visibility
        public Visibility DesignerVisibility
        {
            get { return _visibility; }
            private set
            {
                if (_visibility != value)
                {
                    _visibility = value;
                    OnPropertyChanged("DesignerVisibility");
                }
            }
        }

        public PrimerDesignerViewModel(SurfaceWindow1ViewModel surfaceWindowViewModel)
        {
            _surfaceWindowViewModel = surfaceWindowViewModel;
            _visibility = Visibility.Collapsed;
            _backCommand = new RelayCommand(Execute_BackCommand);
        }

        public void HideDesigner()
        {
            this.DesignerVisibility = Visibility.Collapsed;
            this.Gene = null;
        }

        public void ShowDesigner(IGene gene)
        {
            this.Gene = gene;
            this.DesignerVisibility = Visibility.Visible;
        }

        private void Execute_BackCommand(object arg)
        {
            this.HideDesigner();
        }
    }
}
