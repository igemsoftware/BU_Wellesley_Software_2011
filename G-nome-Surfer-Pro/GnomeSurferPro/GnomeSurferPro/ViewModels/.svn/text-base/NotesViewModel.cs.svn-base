using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenBank;

namespace GnomeSurferPro.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        private IGene _model;

        public NotesViewModel(IGene model)
        {
            _model = model;
        }

        public String CurrentGeneTagandName
        {
            get
            {
                return _model.LocusTag + "    " + _model.Name;
            }
        }

        public int FirstBasePair
        {
            get { return _model.LeftBasePair; }
        }

        public int LastBasePair
        {
            get { return _model.RightBasePair; }
        }

        public String Name
        {
            get { return _model.Name; }
        }

        public String LocusTag
        {
            get { return _model.LocusTag; }
        }

        public String NoteText
        {
            get { return _model.Note; }
        }
    }
}
