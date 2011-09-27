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
using System.Windows.Media.Animation;

namespace PrimerDesigner
{
    /// <summary>
    /// Interaction logic for BlastPrimerResult.xaml
    /// </summary>
    public partial class BlastPrimerResult : SurfaceUserControl
    {
        private float _score;
        private float _start;
        private float _stop;

        public float Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public float Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public float Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

        public BlastPrimerResult(float score, float start, float stop)
        {
            InitializeComponent();

            _score = score;
            _start = start;
            _stop = stop;

            scoreLabel.Content = "Score: " + _score;
            startLabel.Content = "Start: " + _start;
            //stopLabel.Content = "Stop: " + _stop;

            scatterviewMomma.Opacity = _score / 100;

        }

        private void scatterviewMomma_ContactDown(object sender, ContactEventArgs e)
        {
            ScatterViewItem svi = new ScatterViewItem();
            svi.Background = Brushes.Tomato;
            svi.Height = 300;
            svi.Width = 300;

            //DoubleAnimation animation = new DoubleAnimation();
            //animation.To = 0;
            //animation.Duration = new Duration(new TimeSpan(0, 0, 5));

            //Storyboard sb = new Storyboard();
            //sb.Children.Add(animation);

            //Storyboard.SetTarget(sb, svi);
            //Storyboard.SetTargetProperty(sb, new PropertyPath(Control.ActualHeightProperty));
            //sb.Begin();
            ScatterView temp = (ScatterView) scatterviewMomma.Parent;

        }
    }
}
