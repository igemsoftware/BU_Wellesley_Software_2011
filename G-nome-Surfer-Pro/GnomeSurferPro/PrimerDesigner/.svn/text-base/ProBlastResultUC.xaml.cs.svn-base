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
    /// Interaction logic for ProBlastResultUC.xaml
    /// </summary>
    public partial class ProBlastResultUC : SurfaceUserControl
    {

        public List<ResultSVI> results; 

        public ProBlastResultUC()
        {
            InitializeComponent();

        }

        public ProBlastResultUC(int totalBasePairs, List<ResultSVI> results, String name)
        {
            InitializeComponent();
            this.results = results;

            Point center = new Point(resultGrid.Width / 2, resultGrid.Height / 2);

            double overallOpacity = 0.0; 

            if(results.Count==0){
            }

            else{

            for (int i = 0; i < results.Count; i++)
            {
                double radians = (double)(Math.PI / 180.0) * (360.0 / (double)totalBasePairs) * (double) results[i].GetHitStart();

                //Console.WriteLine(radians);

                double x = 100 * Math.Sin(radians);
                double y = 100 * Math.Cos(radians);
                //Console.WriteLine("(" + x + "," + y + ")");

                results[i].displaceX = x*1.75;
                results[i].displaceY = y*1.75;

                //Line Version
                Polygon p = new Polygon();
                p.Points.Add(new Point(x + 100, y + 100));
                p.Points.Add(center);
                p.Stroke = Brushes.YellowGreen;
                p.Opacity = results[i].GetBitScore() / 100;
                overallOpacity += p.Opacity; 
                p.StrokeThickness = 5;

                resultGrid.Children.Add(p);

            }

            }

            Ellipse backgroundEllipse = new Ellipse();
            backgroundEllipse.Width = 210;
            backgroundEllipse.Height = 210;
            backgroundEllipse.HorizontalAlignment = HorizontalAlignment.Center;
            backgroundEllipse.VerticalAlignment = VerticalAlignment.Center;
            backgroundEllipse.Fill = Brushes.DodgerBlue;
            backgroundEllipse.Opacity = overallOpacity / results.Count;
            

            resultGrid.Children.Add(backgroundEllipse);

            Ellipse centerEllipse = new Ellipse();
            centerEllipse.Width = 80;
            centerEllipse.Height = 80;
            //centerEllipse.Margin = new Thickness(30.0, 30.0, 0.0, 0.0);
            centerEllipse.HorizontalAlignment = HorizontalAlignment.Center;
            centerEllipse.VerticalAlignment = VerticalAlignment.Center; 
            centerEllipse.Fill = Brushes.White;

            resultGrid.Children.Add(centerEllipse);

            Label nameLabel = new Label();
            nameLabel.Content = name;
            nameLabel.HorizontalAlignment = HorizontalAlignment.Center;
            nameLabel.VerticalAlignment = VerticalAlignment.Center;



            resultGrid.Children.Add(nameLabel); 
            }

        }



    }

