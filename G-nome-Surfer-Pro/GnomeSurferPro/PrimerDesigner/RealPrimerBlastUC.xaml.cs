using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;

namespace PrimerDesigner
{
    /// <summary>
    /// Interaction logic for RealPrimerBlastUC.xaml
    /// </summary>
    public partial class RealPrimerBlastUC : SurfaceUserControl
    {
        private int _maxResult = 7;
        private Random scoreGen;
        private Random startGen;
        private Random stopGen;
        private int totalBasePairs;

        public RealPrimerBlastUC(List<ResultSVI> resultList, int totalBasePairs)
        {
            InitializeComponent();

            scoreGen = new Random(88);
            startGen = new Random(315);
            stopGen = new Random(12);
            this.totalBasePairs = totalBasePairs;
            //int i = _maxResult;


            //while (i > 0)
            Console.WriteLine(resultList.Count);
            for (int i = 0; i < resultList.Count; i++) 
            {
                Console.WriteLine(i);
                //BlastPrimerResult bpr = new BlastPrimerResult(scoreGen.Next(0,100), startGen.Next(0, 999), stopGen.Next(1024));
                


                //faking
                //float scoreGenFloat = scoreGen.Next(80, 100);
                //float startGenFloat = startGen.Next(0, 1016); 

                //adding back end
                ResultSVI result = resultList[i];
                double scoreGenFloat = result.GetScore();
                double startGenFloat = result.GetHitStart(); 
                _maxResult--;
                if (i<7)
                {
                    RealBlastPrimerResult bpr = new RealBlastPrimerResult(result, _maxResult, totalBasePairs);
                    bpr.ScatterManipulationStarted += new ScatterManipulationStartedEventHandler(bpr_ScatterManipulationStarted);
                    Momma.Items.Add(bpr);

                    ScatterViewItem matchMark = new ScatterViewItem();
                    matchMark.Width = 5;
                    matchMark.MinWidth = 5;
                    matchMark.Height = 100;
                    matchMark.Center = new Point(bpr.Center.X, 50);
                    matchMark.Background = Brushes.Yellow;
                    matchMark.IsTopmostOnActivation = false;
                    matchMark.ShowsActivationEffects = false;
                    matchMark.CanMove = false;
                    matchMark.CanRotate = false;
                    matchMark.CanScale = false;

                    Momma.Items.Add(matchMark);
                }
                //i--;
            }
        }

        void bpr_ScatterManipulationStarted(object sender, ScatterManipulationStartedEventArgs e)
        {
            RealBlastPrimerResult child = (RealBlastPrimerResult)sender;

            double newX = child.Center.X;
            double newY = child.Center.Y;
            PointCollection pc = new PointCollection();

            //to redraw triangle you got start, left, right, start
            
            Point start = new Point(newX, 100);
            Point left = new Point(newX - 50, newY + 25);
            Point right = new Point(newX + 50, newY + 25);

            pc.Add(start);
            pc.Add(left);
            pc.Add(right);
            pc.Add(start);
       
           
            poly1.Points = pc;
            poly1.Visibility = Visibility.Visible;
        }

    }
}
