using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Threading;
using GenBank;

namespace GnomeSurferPro.Models
{
    public delegate void ThreadedPubMedServiceCompletedHandler(IList<IPublication> results);

    /// <summary>
    /// Wraps calls to the pub med service in a thread. Call Start() to begin call to the pub med service.
    /// Clients should listen to the ThreadedPubMedServiceReturned event for results.
    /// 
    /// IMPORTANT: ThreadedPubMedService should ONLY be created in main UI thread
    /// </summary>
    public class ThreadedPubMedService
    {
        public event ThreadedPubMedServiceCompletedHandler ThreadedPubMedServiceCompleted;

        private IPubMedService _service;
        private IGene _gene;
        private Dispatcher _dispatcher;
        private IList<IPublication> _publications;

        public ThreadedPubMedService(IPubMedService service, IGene gene, Dispatcher uiDispatcher)
        {
            _service = service;
            _gene = gene;
            _dispatcher = uiDispatcher;
        }

        public ThreadedPubMedService(IPubMedService service, IGene gene)
            :
            this(service, gene, Dispatcher.CurrentDispatcher)
        {
        }

        /// <summary>
        /// Begins call to Pub Med Service in separate thread
        /// </summary>
        public void Start()
        {
            Thread worker = new Thread(new ThreadStart(DoQueryService));
            worker.IsBackground = true;
            worker.SetApartmentState(ApartmentState.STA);

            worker.Start();
        }

        private void DoQueryService()
        {
            _publications = _service.GetResults(_gene);
            _dispatcher.BeginInvoke(OnCompleted);
        }

        private void OnCompleted()
        {
            if (ThreadedPubMedServiceCompleted != null)
            {
                ThreadedPubMedServiceCompleted(_publications);
            }
        }
    }
}
