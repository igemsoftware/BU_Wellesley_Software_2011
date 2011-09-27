using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using GenBank;
using System.Threading;


namespace PrimerDesigner
{
    class BLASTworker
    {
       
            private Dispatcher _dispatcher;
            private String _primer;
            private Action<List<ResultSVI>[]> _callback;
            public List<ResultSVI>[] _result;
            private String[] _genome;

            public BLASTworker(Dispatcher dispatcher, String primer,String[] genome, Action<List<ResultSVI>[]> callback)
            {
                _dispatcher = dispatcher;
                _primer = primer;
                _callback = callback;
                _genome=genome;
                _result = new List<ResultSVI>[6];
            }

            public void Start()
            {
                Thread thread = new Thread(MakeBlastResults);
                thread.IsBackground = true;
                thread.ApartmentState = ApartmentState.STA;
                thread.Start();
            }

            private void MakeBlastResults() // Runs in background thread
            {
                RealPrimerBlastRun rpbr = new RealPrimerBlastRun(_primer, _genome);
                rpbr.Run();
                BlastParser bp = new BlastParser(_genome);
                _result = bp.blastResults;
                Console.WriteLine("MAKE BLAST RESULTS:" +_result[0].Count);
                Action a = new Action(OnSearchCompleted);
                _dispatcher.BeginInvoke(a);
                //Console.WriteLine(_result.ToString());

            }

            private void OnSearchCompleted()
            {
                _callback(_result);
            }
        }
    }
