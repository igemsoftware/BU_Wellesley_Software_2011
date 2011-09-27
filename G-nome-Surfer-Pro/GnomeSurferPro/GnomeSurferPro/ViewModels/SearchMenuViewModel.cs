using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GnomeSurferPro.Util;
using System.Media;

namespace GnomeSurferPro.ViewModels
{
    public enum ChromosomeSearchStatusEnum
    {
        Idle, // User has not selected a chromosome yet
        Searching, // User has selected a chromosome. Search is now being performed in backend
        Complete,
    }

    public class SearchMenuViewModel : ViewModelBase
    {
        private ICommand _selectChromosomeCommand;
        private Action<String> _onChromosomeSelected;
        private ChromosomeSearchStatusEnum _chromosomeSearchStatus;

        public SearchMenuViewModel(Action<String> onChromosomeSelected)
        {
            _onChromosomeSelected = onChromosomeSelected;
            _selectChromosomeCommand = new RelayCommand(Execute_SelectChromosomeCommand);
            _chromosomeSearchStatus = ChromosomeSearchStatusEnum.Idle;
        }

        public ChromosomeSearchStatusEnum ChromosomeSearchStatus
        {
            get { return _chromosomeSearchStatus; }
            set
            {
                if (_chromosomeSearchStatus != value)
                {
                    _chromosomeSearchStatus = value;
                    OnPropertyChanged("ChromosomeSearchStatus");
                }
            }
        }

        public ICommand SelectChromosomeCommand
        {
            get { return _selectChromosomeCommand; }
        }

        // Expecting a chromosome id as argument
        private void Execute_SelectChromosomeCommand(object arg)
        {
            ChromosomeSearchStatus = ChromosomeSearchStatusEnum.Searching;
            _onChromosomeSelected((String)arg);
        }
    }
}
