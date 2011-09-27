using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using GenBank;
using System.Threading;

namespace GnomeSurferPro.ThreadWorkers
{
    public class ChromosomeSearchWorker
    {
        private Dispatcher _dispatcher;
        private IGenBankProvider _provider;
        private String _query;
        private Action<IChromosomeStream> _callback;
        private IChromosomeStream _result;

        public ChromosomeSearchWorker(Dispatcher dispatcher, IGenBankProvider provider, String query,
            Action<IChromosomeStream> callback)
        {
            _dispatcher = dispatcher;
            _provider = provider;
            _query = query;
            _callback = callback;
        }

        public void Start()
        {
            Thread thread = new Thread(DoChromosomeSearch);
            thread.IsBackground = true;
            thread.ApartmentState = ApartmentState.STA;
            thread.Start();
        }

        private void DoChromosomeSearch() // run in background
        {
            _result = _provider.GetChromosome(_query);
            _dispatcher.BeginInvoke(OnSearchCompleted);
        }

        private void OnSearchCompleted()
        {
            _callback(_result);
        }
    }
}
