using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using GenBank;
using System.Threading;

namespace GnomeSurferPro.ThreadWorkers
{
    public class GeneSearchWorker
    {
        private Dispatcher _dispatcher;
        private IChromosomeStream _stream;
        private String _query;
        private Action<IGene> _callback;
        private IGene _result;

        public GeneSearchWorker(Dispatcher dispatcher, IChromosomeStream stream, String query,
                                Action<IGene> callback)
        {
            _dispatcher = dispatcher;
            _stream = stream;
            _query = query;
            _callback = callback;
        }

        public void Start()
        {
            Thread thread = new Thread(DoGeneSearch);
            thread.IsBackground = true;
            thread.ApartmentState = ApartmentState.STA;
            thread.Start();
        }

        private void DoGeneSearch() // Runs in background thread
        {
            _result = _stream.GetGeneByNameOrLocusTag(_query);
            _dispatcher.BeginInvoke(OnSearchCompleted);
        }

        private void OnSearchCompleted()
        {
            _callback(_result);
        }
    }
}
