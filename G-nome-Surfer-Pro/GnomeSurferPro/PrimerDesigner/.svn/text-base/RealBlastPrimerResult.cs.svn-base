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
    class RealBlastPrimerResult:ScatterViewItem
    {
        //data
        private double _score;
        private double _start;
        private double _stop;
        private bool _triangle;
        private bool _balloon;
        private int _seqNumber;
        private String _hitSequence;
        private String _querySequence;
        private String _midline;
        private int totalBP;
        private Storyboard storyBoard1;
        Random _random = new Random();

    

        //UI
        private Label scoreLabel;
        private Label startLabel;
        private Label stopLabel;
        private String sequence;

        /// <summary>
        /// The length (in pixels) from the base of the triangle on the end of a gene
        /// to the tip of the triangle
        /// </summary>
        public const int TriangleLength = 30;

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public double Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public double Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

        public ScatterViewItem SVI
        {
            get { return this; }
            //set { _stop = value; }
        }

        public RealBlastPrimerResult(ResultSVI result, int maxResult,int totalBP)
        {
            _score = result.GetScore() ; //+/- score
            _start = result.GetHitStart();
            _stop = result.GetHitStop();
            _hitSequence = result.GetHitSeq();
            _querySequence = result.GetQuerySeq();
            _midline = result.GetMidlines();

            _triangle = false;
            _balloon = false;
            storyBoard1 = new Storyboard();
            this.totalBP = totalBP;

            this.Width = 100; // makes standard width 
            this.Height = 50;
            this.Background = Brushes.OliveDrab;
            this.Orientation = 0;
            this.Opacity = 1;
            this.CanMove = false;
            this.CanRotate = false;
            this.CanScale = false;
            this.IsTopmostOnActivation = false;
          
            //this.Center = new Point(_start, 50+200*(_score/Math.Abs(_score)));
            //Console.WriteLine("y value: 380 + 200*" +(_score / Math.Abs(_score)));
            
            switch((int)maxResult)
            {
                case 1: 
                    this.Center = new Point(1024 * _start / totalBP, 700);
                break;
                case 2:
                    this.Center = new Point(1024 * _start / totalBP, 650);
                break;
                case 3:
                    this.Center = new Point(1024 * _start / totalBP, 550);
                break;
                case 4:
                    this.Center = new Point(1024 * _start / totalBP, 450);
                break;
                case 5:
                    this.Center = new Point(1024 * _start / totalBP, 350);
                break;
                case 6:
                    this.Center = new Point(1024 * _start / totalBP, 250);
                break;

                Console.WriteLine("that number: " + this.Center.Y);
            }


            this.ScatterManipulationDelta += new ScatterManipulationDeltaEventHandler(blastResultSVI_ScatterManipulationDelta);
            this.ScatterManipulationCompleted += new ScatterManipulationCompletedEventHandler(BlastPR_ScatterManipulationCompleted);

            scoreLabel = new Label();
            startLabel = new Label();
            stopLabel = new Label();

            scoreLabel.VerticalAlignment = VerticalAlignment.Top;
            startLabel.VerticalAlignment = VerticalAlignment.Center;
            stopLabel.VerticalAlignment = VerticalAlignment.Bottom;

            scoreLabel.Content = "Score: " + Math.Abs(_score); // value passed: 380+(200*up)
            startLabel.Content = "Start: " + _start;
            //stopLabel.Content = "Length: 6"; 

            Grid labelsGrid = new Grid();
            labelsGrid.Children.Add(scoreLabel);
            labelsGrid.Children.Add(startLabel);
            //labelsGrid.Children.Add(stopLabel);
            this.Content = labelsGrid;
        }

        /// <summary>
        /// Authors: Consuelo Valdes and Kelsey Tempel
        /// 
        /// When user has finished moving the orignal BlastResult over, show an expanded information view and animate :)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BlastPR_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            Console.WriteLine(sender.GetType());
            RealBlastPrimerResult senderSVI = (RealBlastPrimerResult)sender;

            if (!_balloon)
            {
                _balloon = true;

                //outlines selected svi
                this.BorderBrush = Brushes.SeaShell;
                this.BorderThickness = new Thickness(4);

                //creates the info box
                ScatterViewItem svi = new ScatterViewItem();
                svi.Background = Brushes.OliveDrab;
                svi.Opacity = .75;
                svi.Orientation = 0;

                /////////////////////////////////////////////////////////////////////////////////////////
              
                SurfaceTextBox surfaceTextBox = new SurfaceTextBox();
                surfaceTextBox.FontFamily = new FontFamily("Courier New");
                surfaceTextBox.AppendText(senderSVI.toString());
                surfaceTextBox.TextWrapping = TextWrapping.Wrap;
                surfaceTextBox.IsReadOnly = true;
                surfaceTextBox.Width = 250;//Sets the size of the text box so that it wraps

                Grid textGrid = new Grid();
                textGrid.Background = Brushes.White;
                textGrid.Margin = new Thickness(3);
               

                textGrid.Children.Add(surfaceTextBox);


                //set row content for mainWrapperGrid and add all objects appropriately
                

                svi.Content = textGrid;
                ///////////////////////////////////////////////////////////////////////////
                //Grid infoGrid = new Grid();
                //infoGrid.VerticalAlignment = VerticalAlignment.Top;
                //infoGrid.HorizontalAlignment = HorizontalAlignment.Left;
                ////infoGrid.ShowGridLines = true;

                //RowDefinition row1 = new RowDefinition();
                //RowDefinition row2 = new RowDefinition();
                //RowDefinition row3 = new RowDefinition();
                //RowDefinition row4 = new RowDefinition();
                //ColumnDefinition col1 = new ColumnDefinition();

                //row1.Height = new GridLength(35);
                //row2.Height = new GridLength(20);
                //row3.Height = new GridLength(20);
                //row4.Height = new GridLength(20);

                //infoGrid.RowDefinitions.Add(row1);
                //infoGrid.RowDefinitions.Add(row2);
                //infoGrid.RowDefinitions.Add(row3);
                //infoGrid.RowDefinitions.Add(row4);
                //infoGrid.ColumnDefinitions.Add(col1);
                
                //TextBlock headerText = new TextBlock();
                ////headerText.Text = "This is the detailed view for a BLAST result";
                //headerText.Text = "Restriction Enzyme Cut Sites";
                //headerText.TextWrapping = TextWrapping.Wrap; 
                //headerText.FontSize = 12;
                //headerText.TextAlignment = TextAlignment.Center;
                //headerText.FontWeight = FontWeights.Bold; 
                //Grid.SetColumnSpan(headerText, 1);
                //Grid.SetRow(headerText, 0);

                //TextBlock scoreText = new TextBlock();
                ////scoreText.Text = "Score: " + _score;
                //if (Math.Abs(_score) == 92)
                //{
                //    scoreText.Text = "SpeI:";
                //}
                //else if (Math.Abs(_score) == 93)
                //{
                //    scoreText.Text = "XbaI:"; 
                //}
                //else
                //{
                //    scoreText.Text = "EcoRI:";
                //}
                //scoreText.FontSize = 12;
                //Grid.SetColumnSpan(scoreText, 1);
                //Grid.SetRow(scoreText, 1);

                //TextBlock startText = new TextBlock();
                ////startText.Text = "Start: " + _start;
                //if (Math.Abs(_score) == 92)
                //{
                //    startText.Text = " 5'  A | CTAGT  3'";
                //}
                //else if (Math.Abs(_score) == 93)
                //{
                //    startText.Text = " 5'  T | CTAGA  3'";
                //}
                //else
                //{
                //    startText.Text = " 5'  G | AATTC  3'";
                //}
                //startText.FontSize = 12;
                
                //Grid.SetColumnSpan(startText, 1);
                //Grid.SetRow(startText, 2);

                //TextBlock stopText = new TextBlock();
                ////stopText.Text = "Stop: " + _stop;
                //if (Math.Abs(_score) == 92)
                //{
                //    stopText.Text = " 3'  TBATC | A  5'";
                //}
                //else if (Math.Abs(_score) == 93)
                //{
                //    stopText.Text = " 3'  AGATC | T  5'";
                //}
                //else
                //{
                //    stopText.Text = " 3'  CTTAA | G  5'";
                //}
                //stopText.FontSize = 12;
                //Grid.SetColumnSpan(stopText, 1);
                //Grid.SetRow(stopText, 3);

                ScatterViewItem child = (ScatterViewItem)sender;

                svi.Center = child.Center;
                svi.ScatterManipulationDelta += new ScatterManipulationDeltaEventHandler(svi_ScatterManipulationDelta);

               
                ScatterView temp = (ScatterView)child.Parent;
                svi.CanScale = true;
                temp.Items.Add(svi);
                
                //EasingFunction Code 
                Duration duration = new Duration(TimeSpan.FromSeconds(1.0));

                // DoubleAnimation scale x/y
                DoubleAnimation widthAnimation = new DoubleAnimation();
                widthAnimation.Duration = duration;
                DoubleAnimation heightAnimation = new DoubleAnimation();
                heightAnimation.Duration = duration;

                widthAnimation.To = 250;
                widthAnimation.From = 50;
                heightAnimation.To = 150;
                heightAnimation.From = 50;

                Storyboard.SetTargetName(widthAnimation, svi.Name);
                Storyboard.SetTarget(widthAnimation, svi);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(ScatterViewItem.WidthProperty));

                Storyboard.SetTargetName(heightAnimation, svi.Name);
                Storyboard.SetTarget(heightAnimation, svi);
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(ScatterViewItem.HeightProperty));

                storyBoard1.Children.Add(heightAnimation);
                storyBoard1.Children.Add(widthAnimation);
                storyBoard1.Begin();
            } // closes  if (!_balloon)

        }

        void svi_ScatterManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {
            //throw new NotImplementedException(); 
           // Console.WriteLine("I moved");
        }

        /// <summary>
        /// AUTHORS: Kelsey Tempel, Consuelo Valdes
        /// 
        /// Adds bar showing results match on thing being blasted against.
        /// Adds a connecting bar betweent the match and the result. 
        /// 
        /// Make as touched so we don't have useless memory waste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void blastResultSVI_ScatterManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {
            RealBlastPrimerResult child = (RealBlastPrimerResult)sender;            
 
        }

        public String toString()
        {
            String result = "";
            result+="\nScore: " +_score;

            result += "\n\nTotal Base Pair: " + totalBP;

            result+="\n\nStart: " +_start;
            
            result+="\tStop: " +_stop;
                     
            result+="\n\nH: " +_hitSequence;

            result += "\n   " + _midline;

            result+="\nQ: " +_querySequence;
            
            

            return result;

        }
    }
}
