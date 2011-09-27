/// <Summary>
/// FILE:                   PrimerDesignerUserControl.xaml.cs
/// AUTHORS:                Casey Grote and Kelsey Tempel
/// DESCRIPTION:            This class handles Primer Designer functions. Including updating the display, running tests 
///                         (including Primer BLAST) and saving the Primer. 
/// MODIFICATION HISTORY:   
/// </Summary>

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
using GenBank;
using System.Windows.Threading;

namespace PrimerDesigner
{
    /// <summary>
    /// Interaction logic for PrimerDesignerUserControl.xaml
    /// </summary>
    public partial class PrimerDesignerUserControl : SurfaceUserControl
    {

        private const Byte BLAST_TAG_VALUE = 0x02;
        private Storyboard storyBoard1; //notecards
        private Storyboard saveStoryboard; //bio-bricked animation

        private String _leftPrimer;
        private String _rightPrimer;

        private String _leftSequence;
        private String _rightSequence;
        private double _leftGibbsFree;
        private double _rightGibbsFree;
        private int _leftTemp;
        private int _rightTemp;
        private int _leftLength;
        private int _rightLength;

        private String[] _genome;
        private int[] _genomeNumBasePairs;
        private int plasmidPlacementTracker;//keeping track of plasmid being placed for positioning on blast results grid
        private IGene _gene;

        private List<ResultSVI>[] results;

        private List<String> rightRestrictionCutSequences;
        private List<String> leftRestrictionCutSequences;

        //gene direction
        private Point[] reverseGenePolygonPoints={new Point(200,400),new Point(300,300), new Point(825,300),new Point(825, 500), 
                                                     new Point(300,500), new Point(200,400)};

        private Point[] forwardGenePolygonPoints ={new Point(825,400),new Point(725,300), new Point(200, 300),new Point(200, 500), 
                                                     new Point(725,500), new Point(825,400)};                                           
         
        // triange pointing in 5' direction
        private Point[] leftReversePrimerPolygonPoints = {new Point(15,350),new Point(40,325),new Point(40,375),new Point(15,350)};
        private Point[] leftForwardPrimerPolygonPoints ={new Point(460,325),new Point(485,350),new Point(460,375),new Point(460,325)};

        private Point[] rightReversePrimerPolygonPoints = {new Point(1009, 625), new Point(984, 600),new Point(984, 650), new Point(1009, 625) };
        private Point[] rightForwardPrimerPolygonPoints = {new Point(564, 600), new Point(539, 625),new Point(564, 650), new Point(564, 600) };


        public PrimerDesignerUserControl()
        { 
            InitializeComponent();

            _leftPrimer = leftGetPrimer(5, leftSequence.Text);
            _rightPrimer = rightGetPrimer(5, rightSequence.Text);

            //for tb genome
            //String tb1 = "CDC1551";
            //String tb2 = "F11";
            //String tb3 = "H37Ra";
            String tb4 = "H37Rv";
            //String tb5 = "K7N1435";
            //String[] t = { tb1, tb2, tb3, tb4,tb5 };
            String[] t = { tb4 };
            _genome = t;

            // sets length to 10bp to begin
            _rightLength = 10;
            _leftLength = 10;
            rightLength.Content = 10;
            leftLength.Content = 10;

            // gives bogus data for construction
            String sequence = "ATGGACGCGGCTACGACAAGAGTTGGCCTCACCGACTTGA";
            _leftSequence = (sequence).Substring(0, 40);
            leftSequence.Text = _leftSequence;
            _rightSequence = "ATGGACGCGGCTACGACAAGAGTTGGCCTCACCGACTTGA";
            rightSequence.Text = _rightSequence;

            _leftPrimer = leftGetPrimer(_leftLength, _leftSequence);
            _rightPrimer = rightGetPrimer(_rightLength, _rightSequence);
            
            // updates content before real data
            rightBlastResult.Content = "";
            leftBlastResult.Content = "";
            leftHairpinResult.Content = "";
            rightHairpinResult.Content = "";

            rightGibbsFree.Content = calcDeltaG(_rightPrimer);
            leftGibbsFree.Content = calcDeltaG(_leftPrimer);
            leftTemp.Content = leftCalculateTemp(_leftSequence, _leftLength);
            temp.Content = rightCalculateTemp(_rightSequence, _rightLength);

            //int[] genomeLengths = { 4403837, 4424435, 4419977, 4411532, 4398250 }; // hardcoded lengths of tb genomes
            //_genomeNumBasePairs = genomeLengths;
            int[] genomeLengths = { 4411532 };
            _genomeNumBasePairs = genomeLengths;
            
            plasmidPlacementTracker = 0;

            // sample sequences


            //RESTRICTION CUT SITE VISUALIZATION CODE, FUNCTION DISABLED FOR MONDAY?

            rightRestrictionCutSequences= new List<String>();
            rightRestrictionCutSequences.Add("G|AATTC");//ecoRI
            rightRestrictionCutSequences.Add("T|CTAGA");//XbaI
            rightRestrictionCutSequences.Add("A|CTAGT");//SpeI
            rightRestrictionCutSequences.Add("CTGCA|G");//PstI

            leftRestrictionCutSequences = new List<String>();
            leftRestrictionCutSequences.Add("CTTAA|G");//ecoRI
            leftRestrictionCutSequences.Add("AGATC|T");//XbaI
            leftRestrictionCutSequences.Add("TGATC|A");//SpeI
            leftRestrictionCutSequences.Add("G|ACGTC");//PstI


            List<int> rightCutSites = generateCutSites(_rightSequence, rightRestrictionCutSequences);
            List<int> leftcutSites = generateCutSites(_leftSequence, leftRestrictionCutSequences);

            leftSequenceRestrictionLayer.Children.Clear();
            rightSequenceRestrictionLayer.Children.Clear();
            restrictionWarningGrid(rightCutSites, rightSequenceRestrictionLayer);
            restrictionWarningGrid(leftcutSites, leftSequenceRestrictionLayer);
        }


        
        /// <summary>
        /// Returns a list of cut sites within the given sequence, given a list of cut sequences 
        /// with '|' replacing cutsites within cut sequence
        /// </summary>
        /// <param name="sequence">String of the DNA sequence being checked for Restriction sites</param>
        /// <param name="List<String>">String List holding the Restriction cut sequences</param>
        /// <returns> integer List with the x coordinate of the cut site</returns>
        private List<int> generateCutSites(String sequence, List<String> restrictionCutSequences)
        {
            List<int> cutSites = new List<int>();
            String seq=sequence.ToString();

            for (int i = 0; i < restrictionCutSequences.Count; i++)
            {
                int cutSite=restrictionCutSequences[i].IndexOf('|');//cut site within restriction site
                String query = restrictionCutSequences[i].Remove(cutSite, 1);//sequence to search for

                //for replacing findseq with empty sequence of same length to preserve sequence length and indexes;


                while (seq.Contains(query))
                {
                    int index = seq.IndexOf(query);
                    cutSites.Add(index+cutSite);
                    seq = replaceFirst(seq, query);

                }

            }

            return cutSites;
        }

        /// <summary>
        /// Replaces first occurance of the query with pipes, for preserving the length of sequences while removing cutsites
        /// </summary>
        /// <param name="sequence">String of the DNA sequence being checked</param>
        /// <param name="query">String of DNA representing a single cut site</param>
        /// <returns> String with the replacement pipes</returns>
        private String replaceFirst(String sequence, String query)
        {
            int index = sequence.IndexOf(query);
            char[] replaceStringBlanks = { '|', '|', '|', '|', '|', '|', '|', '|', '|' };
            String replaceString = new String(replaceStringBlanks, 0, query.Length);
            String seq = sequence.ToString();

            String preQuery = seq.Substring(0, index);
            String postQuery = seq.Substring(index + query.Length);

            return preQuery + replaceString + postQuery;         
        }


        /// <summary>
        /// Draws existing Restriction Enzyme Cut Sites on Primer Sequence. 
        /// </summary>
        /// <param name="cutSites">the integer List containing the x coor of the cut site</param>
        /// <param name="warningLayer">the Grid used to hold these cut sites</param>
        private void restrictionWarningGrid(List<int> cutSites, Grid warningLayer)
        {
            for (int i = 0; i < cutSites.Count; i++)
            {
                if (cutSites[i] < 40)
                {
                    Line line = new Line();
                    line.X1 = 10 * cutSites[i];
                    line.X2 = 10 * cutSites[i];
                    line.Y1 = 0;
                    line.Y2 = 50;
                    line.Stroke = Brushes.Black;
                    line.StrokeThickness = 2;
                    warningLayer.Children.Add(line);
                }
            }

        }




        /* Don't be scared by the following section, this is just so I can bind to the TargetGene property
         * Dependency Property Tutorial: http://www.wpftutorial.net/DependencyProperties.html */

        public IGene TargetGene
        {
            get { return (IGene)GetValue(TargetGeneProperty); }
            set { SetValue(TargetGeneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetGene.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetGeneProperty =
            DependencyProperty.Register("TargetGene", typeof(IGene), typeof(PrimerDesignerUserControl), new FrameworkPropertyMetadata(null, 
                new PropertyChangedCallback(OnGeneChanged)));

        /* </scariness> */



        /// <summary>
        /// Is called when the value of TargetGene changes. Notice that OnGeneChanged is a static method so you won't
        /// have access to the 'this' keyword. Instead, cast the 'd' parameter to PrimerDesignerUserControl and
        /// call methods on it.
        /// </summary>
        /// <param name="d">The PrimerDesignerUserControl bound to the TargetGene property</param>
        /// <param name="e">Contains a reference to the new gene 'e.NewValue'</param>
        private static void OnGeneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Here's the skeleton for what this method should do
            PrimerDesignerUserControl primerDesignerUC = (PrimerDesignerUserControl)d;
            IGene newGene = (IGene)e.NewValue;
            primerDesignerUC.ChangeGene(newGene);
        }



        /// <summary>
        /// Given a selected iGEM object, this method creates the Primer Designer main page with the relevant information, 
        /// including the primer sequences, name, base pairs, and relevant directions. Handles the logic for creating a new
        /// gene. 
        /// 
        /// Params: an IGene object selected by the user
        /// </summary>
        /// <param name="gene">the IGene object selected from G-Nome Surfer Pro</param>
        private void ChangeGene(IGene gene)
        {
            if (gene != null)
            {
                _gene = gene;

                // updates lenght and displays accordingly
                _rightLength = 5;
                _leftLength = 5;
                rightLength.Content = 5;
                leftLength.Content = 5;

                // updates sequence and primer sequences



                String sequence = (gene.Sequence).ToUpper();
             


                _leftSequence = (sequence).Substring(0, 40);
                leftSequence.Text = _leftSequence;
                _rightSequence = (sequence).Substring(sequence.Length - 40, 40);
                rightSequence.Text = _rightSequence;

                _leftPrimer = leftGetPrimer(_leftLength, _leftSequence);
                _rightPrimer = rightGetPrimer(_rightLength, _rightSequence);

                //updates the name of the gene and total base pairs
                if (gene.Name != null)
                    geneNameLabel.Content = gene.Name;
                else
                    geneNameLabel.Content = "";

                geneBPLabel.Content = (Math.Abs(gene.RightBasePair - gene.LeftBasePair)) + " bp";

                // updates the display to show all tests with a blank box (incomplete)
                rightBlastResult.Content = "x";
                leftBlastResult.Content = "x";
                leftHairpinResult.Content = "x";
                rightHairpinResult.Content = "x";
                leftSelfDimerResult.Content = "x";
                rightSelfDimerResult.Content = "x";
                leftHeteroDimerResult.Content = "x";
                rightHeteroDimerResult.Content = "x";


                //update visibility of test tips

                // calculates and displays Gibb's Free and temperature
                rightGibbsFree.Content = calcDeltaG(_rightPrimer);
                leftGibbsFree.Content = calcDeltaG(_leftPrimer);

                _leftTemp = leftCalculateTemp(_leftSequence, _leftLength);
                _rightTemp = rightCalculateTemp(_leftSequence, _rightLength);

                leftTemp.Content = _leftTemp;
                temp.Content = _rightTemp;

                rightTempResult.Content = updateTempResults(_leftTemp, _rightTemp);
                leftTempResult.Content = updateTempResults(_leftTemp, _rightTemp);

                // displays the highlighters at appropriate spot
                rightHighlight.Center = new Point(925, 625);
                rightHighlight.Width = 100;

                leftHighlight.Center = new Point(100, 350);
                leftHighlight.Width = 100;

                //  updates length so minimum of 10 bp to start
                _rightLength = 10;
                _leftLength = 10;
                rightLength.Content = 10;
                leftLength.Content = 10;

                // Restriction Enzyme Cut Sites
                List<int> rightCutSites = generateCutSites(_rightSequence, rightRestrictionCutSequences);
                List<int> leftcutSites = generateCutSites(_leftSequence, leftRestrictionCutSequences);


                restrictionWarningGrid(rightCutSites, rightSequenceRestrictionLayer);
                restrictionWarningGrid(leftcutSites, leftSequenceRestrictionLayer);

                // draws gene and primer triangles on display depending on the orientation of the given gene
                genePolygon.Points = new PointCollection();
                leftPrimerPolygon.Points = new PointCollection();
                rightPrimerPolygon.Points = new PointCollection();

                if (gene.IsForward)
                {
                    foreach (Point p in forwardGenePolygonPoints)
                        genePolygon.Points.Add(p);
                    foreach (Point p in leftForwardPrimerPolygonPoints)
                        leftPrimerPolygon.Points.Add(p);
                    foreach (Point p in rightForwardPrimerPolygonPoints)
                        rightPrimerPolygon.Points.Add(p);
                }
                else
                {
                    foreach (Point p in reverseGenePolygonPoints)
                        genePolygon.Points.Add(p);
                    foreach (Point p in leftReversePrimerPolygonPoints)
                        leftPrimerPolygon.Points.Add(p);
                    foreach (Point p in rightReversePrimerPolygonPoints)
                        rightPrimerPolygon.Points.Add(p);
                }

            }
        }

        /// <summary>
        /// 
        /// Takes in the List of Results for a genome, the total number of base pairs, as well as the
        /// genomes name and creates the circular visualization. This method also returns the total
        /// number of results. 
        /// 
        /// </summary>
        /// <param name="totalBP">integer represting the total number of base pairs</param>
        /// <param name="results">List of ResultSVI objects that will appear on genome</param>
        /// <param name="name">String name of the relevant genome</param>
        /// <returns> integer representing the total number of results for that genome</returns>
        private int makeChromosome(int totalBP, List<ResultSVI> results, String name)
        {

            // create circular representation of genome
            ScatterViewItem SVI = new ScatterViewItem();

            ProBlastResultUC chromosome = new ProBlastResultUC(totalBP, results, name);
            SVI.Content = chromosome;
            SVI.Clip = new EllipseGeometry(new Point(100, 100), 100, 100);
            SVI.CanScale = false;
            SVI.CanRotate = false;
            SVI.Height = 200;
            SVI.Width = 200;

            SVI.ScatterManipulationDelta += new ScatterManipulationDeltaEventHandler(chromosomeManipulationDelta);
            blastScatterView.Items.Add(SVI);
            SVI.Background = Brushes.Transparent;



            SVI.Center = new Point(512, 400);
            // space genomes on screen
            //if (plasmidPlacementTracker == 0)
            //    SVI.Center = new Point(256, 200);
            //if (plasmidPlacementTracker == 1)
            //    SVI.Center = new Point(256, 600);
            //if (plasmidPlacementTracker == 2)
            //    SVI.Center = new Point(768, 200);
            //if (plasmidPlacementTracker == 3)
            //    SVI.Center = new Point(512, 400);
            //if (plasmidPlacementTracker == 4)
            //{
            //    SVI.Center = new Point(768, 600);
            //    plasmidPlacementTracker = 0;//reset
            //}
            //else
            //    plasmidPlacementTracker++;

            int numResults = 0;
            
                //adds results for each genome onto circle
                foreach (ResultSVI result in chromosome.results)
                {
                    ScatterViewItem resultSVI = new ScatterViewItem();
                    resultSVI.Content = result;
                    resultSVI.Orientation = 0;
                    resultSVI.Background = Brushes.YellowGreen;
                    resultSVI.Opacity = (result.GetScore()) / 100;
                    blastScatterView.Items.Add(resultSVI);
                    resultSVI.Center = new Point(SVI.Center.X + result.displaceX, SVI.Center.Y + result.displaceY);

                    resultSVI.CanMove = false; resultSVI.CanRotate = false; resultSVI.CanScale = false;

                    resultSVI.PreviewContactDown += new ContactEventHandler(resultSVI_PreviewContactDown);


                    if (name.Equals("H37Rv"))//################!!!!!!FOR DEMO, ONLY COUNTING RESULTS ON RELEVANT GENOME
                        numResults++;
                }
            

                return numResults;
            
        }

        /// <summary>
        /// Calculates the deltaG value of a given String of DNA.
        /// 
        /// </summary>
        /// <param name="s">String representing the DNA sequence whose delta G value is being calculated</param>
        /// <returns> double representing the delta G value</returns>
        public static Double calcDeltaG(String s)
        {
            Double toReturn = 0.0;
            if (s != null)
            {
                s = s.ToUpper();
                if (s.StartsWith("C") || s.StartsWith("G"))
                {
                    toReturn = toReturn + 0.98;
                }
                else
                {
                    toReturn = toReturn + 1.03;
                }
                if (s.EndsWith("C") || s.EndsWith("G"))
                {
                    toReturn = toReturn + 0.98;
                }
                else
                {
                    toReturn = toReturn + 1.03;
                }
                for (int i = 0; i < s.Length - 1; i++)
                {
                    String token = s.Substring(i, 2);
                    if (token.Equals("AA") || token.Equals("TT"))
                    {
                        toReturn = toReturn - 1.00;
                    }
                    else if (token.Equals("AT"))
                    {
                        toReturn = toReturn - 0.88;
                    }
                    else if (token.Equals("TA"))
                    {
                        toReturn = toReturn - -0.58;
                    }
                    else if (token.Equals("CA") || token.Equals("AC"))
                    {
                        toReturn = toReturn - 1.45;
                    }
                    else if (token.Equals("GT") || token.Equals("TG"))
                    {
                        toReturn = toReturn - 1.44;
                    }
                    else if (token.Equals("CT") || token.Equals("TC"))
                    {
                        toReturn = toReturn - 1.28;
                    }
                    else if (token.Equals("GA") || token.Equals("AG"))
                    {
                        toReturn = toReturn - 1.30;
                    }
                    else if (token.Equals("CG"))
                    {
                        toReturn = toReturn - 2.17;
                    }
                    else if (token.Equals("GC"))
                    {
                        toReturn = toReturn - 2.24;
                    }
                    else if (token.Equals("GG") || token.Equals("CC"))
                    {
                        toReturn = toReturn - 1.84;
                    }
                }

                //rounding
                toReturn = toReturn * 10;
                int toReturnInt = (int)toReturn;
                toReturn = (double)toReturnInt / (double)10;

                return toReturn;
            }

            return 0.00;
        }


        /// <summary>
        /// Given a full sequence and length, this method returns the highlighted right primer sequence. 
        /// 
        /// </summary>
        /// <param name="len">integer represting the length of the Primer sequence</param>
        /// <param name="fullSeq">String representing the full sequence displayed on the Primer Designer</param>
        /// <returns> String represeting the RIGHT highlighted Primer Sequence</returns>
        private String rightGetPrimer(int len, String fullSeq)
        {
            if (len > 40)
                len = 40;
            String primer = "";
            for (int i = fullSeq.Length - 1; i >= fullSeq.Length - len; i--)
            {
                char c = fullSeq[i];
                primer += c;
            }
            return primer;
        }
        /// <summary>
        /// Given a full sequence and length, this method returns the highlighted LEFT primer sequence. 
        /// 
        /// </summary>
        /// <param name="len">integer represting the length of the Primer sequence</param>
        /// <param name="fullSeq">String representing the full sequence displayed on the Primer Designer</param>
        /// <returns> String represeting the LEFT highlighted Primer Sequence</returns>
        private String leftGetPrimer(int len, String fullSeq)
        {
            if (len > 40)
                len = 40;
            String primer = "";
            for (int i = 0; i < len; i++)
            {
                char c = fullSeq[i];
                primer += c;
            }
            return primer;
        }



        /// <summary>
        /// Given the temperature of two primers, this method returns a String representing whether the temperatures 
        /// of each Primer are within 1 degree of eachother. If true, the webdings character for a check mark is returned,
        /// if false the character for a blank box will be returned. 
        /// 
        /// </summary>
        /// <param name="primer1temp">integer representing the temperature of primer 1</param>
        /// <param name="primer2temp">integer representing the temperature of primer 2</param>
        /// <returns> String representing the result of the Temp check</returns>
        private string updateTempResults(int primer1temp, int primer2temp)
        {
            string result = "x"; //box
            if (Math.Abs(primer1temp - primer2temp) <= 1)
            {
                result = "a"; // check mark
            }
            return result;
        }

        /// <summary>
        /// Given the full sequence and length of the primer, this method returns the temperature of the
        /// LEFT primer. 
        /// 
        /// </summary>
        /// <param name="seq">String representing the full sequence displayed on the Primer Designer</param>
        /// <param name="length">integer representing the length of the left primer</param>
        /// <returns> integer representing the temperate of the left Primer</returns>
        private int leftCalculateTemp(string seq, int length)
        {
            if (length > 40)
                length = 40;
            int result = 0;
            for (int i = 0; i < length; i++)
            {
                char c = seq[i];
                if (c == 'A' || c == 'T')
                    result += 2;
                else
                    result += 3;

            }
            return result;
        }

        /// <summary>
        /// Given the full sequence and length of the primer, this method returns the temperature of the
        /// RIGHT primer. 
        /// 
        /// </summary>
        /// <param name="seq">String representing the full sequence displayed on the Primer Designer</param>
        /// <param name="length">integer representing the length of the right primer</param>
        /// <returns> integer representing the temperate of the right Primer</returns>
        private int rightCalculateTemp(string seq, int length)
        {
            if (length > 40)
                length = 40;
            int result = 0;
            for (int i = seq.Length - 1; i >= seq.Length - length; i--)
            {
                char c = seq[i];
                if (c == 'A' || c == 'T')
                    result += 2;
                else
                    result += 3;

            }
            return result;
        }

        #region object manipulation logic


        /// <summary> 
        /// Creates detailed view notecard that pops up when a ResultSVI has been touched. 
        /// 
        /// Make as touched so we don't have useless memory waste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// clumsy animation conversion for anchoring expanded results
        void resultSVI_PreviewContactDown(object sender, ContactEventArgs e)
        {
            ScatterViewItem senderSVI = (ScatterViewItem)sender;
            ResultSVI resultSVI = (ResultSVI)senderSVI.Content;
            if (!resultSVI._balloon) //if a balloon doesn't already exist
            {
                resultSVI._balloon = true;

                //outlines selected svi
                resultSVI.BorderBrush = Brushes.SeaShell;
                resultSVI.BorderThickness = new Thickness(3);

                //creates the info box

                //ScatterViewItem svi = new ScatterViewItem();
                //svi.Background = Brushes.OliveDrab;
               // svi.Opacity = .75;
               // svi.Orientation = 0;

                Grid infoGrid = new Grid();
                infoGrid.VerticalAlignment = VerticalAlignment.Top;
                infoGrid.HorizontalAlignment = HorizontalAlignment.Left;

                //create rows and single column
                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                RowDefinition row3 = new RowDefinition();
                RowDefinition row4 = new RowDefinition();
                RowDefinition row5 = new RowDefinition();
                ColumnDefinition col1 = new ColumnDefinition();

                //edit heights of information to be displayed
                row1.Height = new GridLength(35);
                row2.Height = new GridLength(15);
                row3.Height = new GridLength(15);
                row4.Height = new GridLength(15);
                row5.Height = new GridLength(15);



                // add rows and column to the infoGrid contained in the SVI
                infoGrid.RowDefinitions.Add(row1);
                infoGrid.RowDefinitions.Add(row2);
                infoGrid.RowDefinitions.Add(row3);
                infoGrid.RowDefinitions.Add(row4);
                infoGrid.RowDefinitions.Add(row5);
                infoGrid.ColumnDefinitions.Add(col1);

                //get sender, ResultSVI
                ScatterViewItem resultSVIWrapper = (ScatterViewItem)sender;
                ResultSVI result = (ResultSVI)resultSVIWrapper.Content;

                //text for notecard
                TextBlock headerText = new TextBlock();
                headerText.Text = " Detailed BLAST Result";
                headerText.TextWrapping = TextWrapping.Wrap;
                headerText.FontSize = 12;
                headerText.TextAlignment = TextAlignment.Center;
                headerText.FontWeight = FontWeights.Bold;
                Grid.SetColumnSpan(headerText, 1);
                Grid.SetRow(headerText, 0);
                infoGrid.Children.Add(headerText);

                TextBlock startText = new TextBlock();
                startText.Text = " Start: " + result.GetHitStart();
                startText.FontSize = 12;
                startText.TextAlignment = TextAlignment.Left;
                Grid.SetColumnSpan(startText, 1);
                Grid.SetRow(startText, 1);
                infoGrid.Children.Add(startText);

                TextBlock lengthText = new TextBlock();
                double length = result.GetHitStop() - result.GetHitStart();
                lengthText.Text = " Length: " + length;
                lengthText.FontSize = 12;
                lengthText.TextAlignment = TextAlignment.Left;
                Grid.SetColumnSpan(lengthText, 1);
                Grid.SetRow(lengthText, 2);
                infoGrid.Children.Add(lengthText);

                TextBlock eValText = new TextBlock();
                eValText.Text = " E-Val " + result.GetEvalue();
                eValText.FontSize = 12;
                eValText.TextAlignment = TextAlignment.Left;
                Grid.SetColumnSpan(eValText, 1);
                Grid.SetRow(eValText, 3);
                infoGrid.Children.Add(eValText);

                TextBlock scoreText = new TextBlock();
                scoreText.Text = " Score " + result.GetScore();
                scoreText.FontSize = 12;
                scoreText.TextAlignment = TextAlignment.Left;
                Grid.SetColumnSpan(scoreText, 1);
                Grid.SetRow(scoreText, 4);
                infoGrid.Children.Add(scoreText);

                double start = resultSVI.GetHitStart();
                double score = resultSVI.GetScore();

                //svi.Content = infoGrid;
               // svi.Center = senderSVI.Center;

                //ScatterViewItem child = (ScatterViewItem)sender;
                //ScatterView temp = (ScatterView)child.Parent;
               // temp.Items.Add(svi);


                infoGrid.Height = 5;
                infoGrid.Width = 100;


                resultSVI.infoCanvas.Children.Add(infoGrid);
                infoGrid.Margin = new Thickness(0, -25, 0, 0);
                resultSVI.infoCanvas.Children.Remove(resultSVI.eValLabel);
                resultSVI.infoCanvas.Children.Remove(resultSVI.scoreLabel);

                senderSVI.Opacity = 1;


                // Animation for making notecard appear
                //EasingFunction Code 
                Duration duration = new Duration(TimeSpan.FromSeconds(1.0));

                //Make width animation and height animation
                DoubleAnimation widthAnimation = new DoubleAnimation();
                widthAnimation.Duration = duration;
                DoubleAnimation heightAnimation = new DoubleAnimation();
                heightAnimation.Duration = duration;


                DoubleAnimation infoGridHeightAnimation = new DoubleAnimation();
                infoGridHeightAnimation.Duration = duration;



                ThicknessAnimation infoGridMarginAnimation = new ThicknessAnimation();
                infoGridMarginAnimation.Duration = duration;
                
           

                // give starting and stopping x and y values for animation
                widthAnimation.To = 100;
                widthAnimation.From = 100;
                heightAnimation.To = 100;
                heightAnimation.From = 50;


                infoGridHeightAnimation.To = 100;
                infoGridHeightAnimation.From = 50;

                infoGridMarginAnimation.To = new Thickness(0,-25,0,0);
                infoGridMarginAnimation.From = new Thickness(0,0,0,0);



                // Tell storyboards which animation is happening to which item
                Storyboard.SetTargetName(widthAnimation, senderSVI.Name);
                Storyboard.SetTarget(widthAnimation, senderSVI);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(ScatterViewItem.WidthProperty));

                Storyboard.SetTargetName(heightAnimation, senderSVI.Name);
                Storyboard.SetTarget(heightAnimation, senderSVI);
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(ScatterViewItem.HeightProperty));


                Storyboard.SetTargetName(infoGridHeightAnimation, infoGrid.Name);
                Storyboard.SetTarget(infoGridHeightAnimation, infoGrid);
                Storyboard.SetTargetProperty(infoGridHeightAnimation, new PropertyPath(ScatterViewItem.HeightProperty));


                Storyboard.SetTargetName(infoGridMarginAnimation, infoGrid.Name);
                Storyboard.SetTarget(infoGridMarginAnimation, infoGrid);
                Storyboard.SetTargetProperty(infoGridMarginAnimation, new PropertyPath(Grid.MarginProperty));



                // add and begin animations
                storyBoard1 = new Storyboard();
                storyBoard1.Children.Add(heightAnimation);
                storyBoard1.Children.Add(widthAnimation);
                storyBoard1.Children.Add(infoGridHeightAnimation);

                storyBoard1.Children.Add(infoGridMarginAnimation);

                
               
                storyBoard1.Begin();

            }//closes if
        }

        //backup baloon animation

        //void resultSVI_PreviewContactDown(object sender, ContactEventArgs e)
        //{
        //    ScatterViewItem senderSVI = (ScatterViewItem)sender;
        //    ResultSVI resultSVI = (ResultSVI)senderSVI.Content;
        //    if (!resultSVI._balloon) //if a balloon doesn't already exist
        //    {
        //        resultSVI._balloon = true;

        //        //outlines selected svi
        //        resultSVI.BorderBrush = Brushes.SeaShell;
        //        resultSVI.BorderThickness = new Thickness(3);

        //        //creates the info box
        //        ScatterViewItem svi = new ScatterViewItem();
        //        svi.Background = Brushes.OliveDrab;
        //        svi.Opacity = .75;
        //        svi.Orientation = 0;

        //        Grid infoGrid = new Grid();
        //        infoGrid.VerticalAlignment = VerticalAlignment.Top;
        //        infoGrid.HorizontalAlignment = HorizontalAlignment.Left;

        //        //create rows and single column
        //        RowDefinition row1 = new RowDefinition();
        //        RowDefinition row2 = new RowDefinition();
        //        RowDefinition row3 = new RowDefinition();
        //        RowDefinition row4 = new RowDefinition();
        //        RowDefinition row5 = new RowDefinition();
        //        ColumnDefinition col1 = new ColumnDefinition();

        //        //edit heights of information to be displayed
        //        row1.Height = new GridLength(35);
        //        row2.Height = new GridLength(15);
        //        row3.Height = new GridLength(15);
        //        row4.Height = new GridLength(15);
        //        row5.Height = new GridLength(15);

        //        // add rows and column to the infoGrid contained in the SVI
        //        infoGrid.RowDefinitions.Add(row1);
        //        infoGrid.RowDefinitions.Add(row2);
        //        infoGrid.RowDefinitions.Add(row3);
        //        infoGrid.RowDefinitions.Add(row4);
        //        infoGrid.RowDefinitions.Add(row5);
        //        infoGrid.ColumnDefinitions.Add(col1);

        //        //get sender, ResultSVI
        //        ScatterViewItem resultSVIWrapper = (ScatterViewItem)sender;
        //        ResultSVI result = (ResultSVI)resultSVIWrapper.Content;

        //        //text for notecard
        //        TextBlock headerText = new TextBlock();
        //        headerText.Text = " Detailed BLAST Result";
        //        headerText.TextWrapping = TextWrapping.Wrap;
        //        headerText.FontSize = 12;
        //        headerText.TextAlignment = TextAlignment.Center;
        //        headerText.FontWeight = FontWeights.Bold;
        //        Grid.SetColumnSpan(headerText, 1);
        //        Grid.SetRow(headerText, 0);
        //        infoGrid.Children.Add(headerText);

        //        TextBlock startText = new TextBlock();
        //        startText.Text = " Start: " + result.GetHitStart();
        //        startText.FontSize = 12;
        //        startText.TextAlignment = TextAlignment.Left;
        //        Grid.SetColumnSpan(startText, 1);
        //        Grid.SetRow(startText, 1);
        //        infoGrid.Children.Add(startText);

        //        TextBlock lengthText = new TextBlock();
        //        double length = result.GetHitStop() - result.GetHitStart();
        //        lengthText.Text = " Length: " + length;
        //        lengthText.FontSize = 12;
        //        lengthText.TextAlignment = TextAlignment.Left;
        //        Grid.SetColumnSpan(lengthText, 1);
        //        Grid.SetRow(lengthText, 2);
        //        infoGrid.Children.Add(lengthText);

        //        TextBlock eValText = new TextBlock();
        //        eValText.Text = " E-Val " + result.GetEvalue();
        //        eValText.FontSize = 12;
        //        eValText.TextAlignment = TextAlignment.Left;
        //        Grid.SetColumnSpan(eValText, 1);
        //        Grid.SetRow(eValText, 3);
        //        infoGrid.Children.Add(eValText);

        //        TextBlock scoreText = new TextBlock();
        //        scoreText.Text = " Score " + result.GetScore();
        //        scoreText.FontSize = 12;
        //        scoreText.TextAlignment = TextAlignment.Left;
        //        Grid.SetColumnSpan(scoreText, 1);
        //        Grid.SetRow(scoreText, 4);
        //        infoGrid.Children.Add(scoreText);

        //        double start = resultSVI.GetHitStart();
        //        double score = resultSVI.GetScore();

        //        svi.Content = infoGrid;
        //        svi.Center = senderSVI.Center;

        //        ScatterViewItem child = (ScatterViewItem)sender;
        //        ScatterView temp = (ScatterView)child.Parent;
        //        temp.Items.Add(svi);



        //        // Animation for making notecard appear
        //        //EasingFunction Code 
        //        Duration duration = new Duration(TimeSpan.FromSeconds(1.0));

        //        //Make width animation and height animation
        //        DoubleAnimation widthAnimation = new DoubleAnimation();
        //        widthAnimation.Duration = duration;
        //        DoubleAnimation heightAnimation = new DoubleAnimation();
        //        heightAnimation.Duration = duration;

        //        // give starting and stopping x and y values for animation
        //        widthAnimation.To = 100;
        //        widthAnimation.From = 100;
        //        heightAnimation.To = 100;
        //        heightAnimation.From = 50;

        //        // Tell storyboards which animation is happening to which item
        //        Storyboard.SetTargetName(widthAnimation, svi.Name);
        //        Storyboard.SetTarget(widthAnimation, svi);
        //        Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(ScatterViewItem.WidthProperty));

        //        Storyboard.SetTargetName(heightAnimation, svi.Name);
        //        Storyboard.SetTarget(heightAnimation, svi);
        //        Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(ScatterViewItem.HeightProperty));

        //        // add and begin animations
        //        storyBoard1 = new Storyboard();
        //        storyBoard1.Children.Add(heightAnimation);
        //        storyBoard1.Children.Add(widthAnimation);
        //        storyBoard1.Begin();
        //    }//closes if
        //}backup animation


        /// <summary>
        /// Adjusts the look of the LEFT highlighted field as the users moves it back and forth. Also updates the
        /// tests so that the empty box appears except for temperature, which it calculates. Also gives live 
        /// display of Gibbs Free Energy, length, and temperature. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftHighlight_ScatterManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {
            //tracks changes occuring with the highlighter
            double deltaX = e.HorizontalChange;
            double deltaY = e.VerticalChange;
            ScatterViewItem highlighter = (ScatterViewItem)sender;
            double newWidth = highlighter.Width + deltaX;
            if (newWidth <= 400 && newWidth > 100)
            {
                highlighter.Center = new Point(highlighter.Center.X - deltaX / 2, highlighter.Center.Y - deltaY);
                highlighter.Width = newWidth;
            }
            else
            {
                highlighter.Center = new Point(highlighter.Center.X - deltaX, highlighter.Center.Y - deltaY);
            }

            // reset labels to empty box
            leftBlastResult.Content = "x";
            leftHairpinResult.Content = "x";
            leftSelfDimerResult.Content = "x";
            leftHeteroDimerResult.Content = "x";

            // keep primer above 10bp
            if (newWidth / 10 < 10)
                newWidth = 100;
            leftLength.Content = (int)(newWidth / 10);

            //calculate left temp, display results
            _leftTemp = leftCalculateTemp(leftSequence.Text, (int)(newWidth / 10));
            leftTemp.Content = _leftTemp;

            // set _leftPrimer instance variable
            _leftPrimer = leftGetPrimer((int)newWidth / 10, leftSequence.Text);

            //calculate Gibbs Free energy, display results
            _leftGibbsFree = calcDeltaG(_leftPrimer);
            leftGibbsFree.Content = _leftGibbsFree;
        }

        /// <summary>
        /// Adjusts the look of the RIGHT highlighted field as the users moves it back and forth. Also updates the
        /// tests so that the empty box appears except for temperature, which it calculates. Also gives live 
        /// display of Gibbs Free Energy, length, and temperature. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightHighlight_ScatterManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {
            double deltaX = e.HorizontalChange;
            double deltaY = e.VerticalChange;
            ScatterViewItem highlighter = (ScatterViewItem)sender;

            double newWidth = highlighter.Width - deltaX;
            if (newWidth <= 400 && newWidth > 100)
            {
                highlighter.Center = new Point(highlighter.Center.X - deltaX / 2, highlighter.Center.Y - deltaY);
                highlighter.Width -= deltaX;
            }
            else
            {
                highlighter.Center = new Point(highlighter.Center.X - deltaX, highlighter.Center.Y - deltaY);
            }

            //resets label to empty box
            rightBlastResult.Content = "x";
            rightHairpinResult.Content = "x";
            rightSelfDimerResult.Content = "x";
            rightHeteroDimerResult.Content = "x";

            //calculates temperature and updates display
            _rightTemp = rightCalculateTemp(rightSequence.Text, (int)(newWidth / 10));
            temp.Content = _rightTemp;

            //updates _rightPrimer 
            _rightPrimer = rightGetPrimer((int)newWidth / 10, rightSequence.Text);

            // keeps highlighter above 10bp
            if (newWidth / 10 < 10)
                newWidth = 100;
            rightLength.Content = (int)(newWidth / 10); //length

            //calculates Gibbs Free and updates display
            _rightGibbsFree = calcDeltaG(_rightPrimer);
            rightGibbsFree.Content = _rightGibbsFree;
        }

        /// <summary>
        /// Once the user finishes moving the RIGHT highlighter, the temperature of both primers is checked and the display
        /// for both Primers is updated. Variables updated appropriately. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightHighlight_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            ScatterViewItem highlighter = (ScatterViewItem)sender;
            int width = (int)highlighter.Width;
            width -= width % 10;
            highlighter.Width = width;
            highlighter.Center = new Point((1024 - 50) - width / 2, highlighter.Center.Y);
            _rightTemp = rightCalculateTemp(rightSequence.Text, (int)(width / 10));
            temp.Content = _rightTemp;
            rightLength.Content = (int)(width / 10); //length
            rightTempResult.Content = updateTempResults(_rightTemp, _leftTemp);
            leftTempResult.Content = rightTempResult.Content;
        }


        /// <summary>
        /// Once the user finishes moving the LEFT highlighter, the temperature of both primers is checked and the display
        /// for both Primers is updated. Variables updated appropriately. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftHighlight_ScatterManipulationCompleted(object sender, ScatterManipulationCompletedEventArgs e)
        {
            ScatterViewItem highlighter = (ScatterViewItem)sender;
            int width = (int)highlighter.Width;
            width -= width % 10;
            highlighter.Width = width;
            highlighter.Center = new Point(50 + width / 2, highlighter.Center.Y);
            leftLength.Content = (int)(width / 10);
            leftTemp.Content = leftCalculateTemp(leftSequence.Text, (int)(width / 10));
            leftTempResult.Content = updateTempResults(Convert.ToInt16(temp.Content), Convert.ToInt16(leftTemp.Content));
            rightTempResult.Content = leftTempResult.Content;
            //Console.WriteLine(leftGetPrimer(width/10, leftSequence.Text)); 
        }


        /// <summary>
        /// When the user clicks the RIGHT BLAST button, Primer BLAST is run and the appropriate results
        /// are displayed in a new view. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightSurfaceButton_Click(object sender, RoutedEventArgs e)
        {
            //shows BLAST grid

            //runs Primer BLAST through command line and file I/O
            
            BLASTworker worker = new BLASTworker(Dispatcher.CurrentDispatcher, _rightPrimer, _genome, (results) =>
            {

                this.results = results;
                displayRightBlastResults(this.results);
            }
            );

            worker.Start();

            runningRightBlastLabel.Visibility = Visibility.Visible;
            rightHighlight.CanMove = false;
        }

        /// <summary>
        /// When the user clicks the LEFT BLAST button, Primer BLAST is run and the appropriate results
        /// are displayed in a new view. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftSurfaceButton_Click(object sender, RoutedEventArgs e)
        {
            //shows BLAST grid

            //parses results from .xml file and places results in an array of Lists holding ResultSVI objects
            //each index in the array corresponds to a specific tb genome

            //BlastParser bp = new BlastParser(_genome);
            //List<ResultSVI>[] results = bp.blastResults;

            
            BLASTworker worker = new BLASTworker(Dispatcher.CurrentDispatcher, _leftPrimer, _genome, (results) =>
                {

                    this.results = results;
                    displayLeftBlastResults(this.results);
                }
            );

            worker.Start();

            runningLeftBlastLabel.Visibility = Visibility.Visible;
            leftHighlight.CanMove = false;
            

            }


        private void displayRightBlastResults(List<ResultSVI>[] results)
        {


            blastGrid.Visibility = Visibility.Visible;
            blastScatterView.Visibility = Visibility.Visible;


            int totalResults = 0;

            for (int i = 0; i < results.Length; i++)
            {

                if (results[i] != null)
                {
                    totalResults += results[i].Count;
                    RealPrimerBlastUC RPBUC = new RealPrimerBlastUC(results[i], _genomeNumBasePairs[i]);
                    blastGrid.Children.Add(RPBUC);
                    RPBUC.HorizontalAlignment = HorizontalAlignment.Center;

                }


                if (totalResults < 7)
                {
                    rightBlastResult.Content = "a";
                }
                else
                {
                    rightBlastResult.Content = "x";
                }
            }


            runningRightBlastLabel.Visibility = Visibility.Hidden;
            rightHighlight.CanMove = true;
        }

        private void displayLeftBlastResults(List<ResultSVI>[] results)
        {
            blastGrid.Visibility = Visibility.Visible;
            blastScatterView.Visibility = Visibility.Visible;

            int totalResults = 0;

            for (int i = 0; i < results.Length; i++)
            {

                if (results[i] != null)
                {
                    totalResults += results[i].Count;
                    RealPrimerBlastUC RPBUC = new RealPrimerBlastUC(results[i], _genomeNumBasePairs[i]);
                    blastGrid.Children.Add(RPBUC);
                    RPBUC.HorizontalAlignment = HorizontalAlignment.Center;

                }


                if (totalResults < 7)
                {
                    leftBlastResult.Content = "a";
                }
                else
                {
                    leftBlastResult.Content = "x";
                }
            }
            runningLeftBlastLabel.Visibility = Visibility.Hidden;
            leftHighlight.CanMove = true;

        }



        /// <summary>
        /// When the user clicks the back button, the BLAST layer gets erased and becomes hidden. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideSurfaceButton_Click(object sender, RoutedEventArgs e)
        {
            blastGrid.Visibility = Visibility.Hidden;
            blastScatterView.Visibility = Visibility.Hidden;

            //blastScatterView.Items.Clear();
            blastGrid.Children.Clear();


            //SurfaceButton newHide = new SurfaceButton();
            //newHide.Click += new RoutedEventHandler(HideSurfaceButton_Click);
            //newHide.Width = 100;
            //newHide.Content = "BACK";

            //ScatterViewItem newHideSVI = new ScatterViewItem();
            //newHideSVI.Center = new Point(964, 45);
            //newHideSVI.Background = Brushes.Transparent;
            //newHideSVI.CanMove = false;
            //newHideSVI.CanScale = false;
            //newHideSVI.CanRotate = false;
            //newHideSVI.Orientation = 0;
            //newHideSVI.Content = newHide;

            //blastScatterView.Items.Add(newHideSVI);

        }

        /// <summary>
        /// Makes the Results move with their genome. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chromosomeManipulationDelta(object sender, ScatterManipulationDeltaEventArgs e)
        {
            ScatterViewItem senderSVI = (ScatterViewItem)sender;
            ProBlastResultUC chromosome = (ProBlastResultUC)senderSVI.Content;
            
            
            foreach(ResultSVI result in chromosome.results){
                if (result != null)
                {
                    ScatterViewItem resultSVI = (ScatterViewItem)blastScatterView.ContainerFromElement(result);
                    resultSVI.Center = new Point(senderSVI.Center.X + result.displaceX, senderSVI.Center.Y + result.displaceY);
                }
                }
    }

        /// <summary>
        /// When the LEFT hairpin button is pressed, the hairpin test is called and the display
        /// is updated accordingly. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HairpinLeftButton_Click(object sender, RoutedEventArgs e)
        {
            alignmentTests at = new alignmentTests(_leftPrimer);
            double worstCase=at.hairpinRun();
            if (worstCase < _leftGibbsFree)
            {
                leftHairpinResult.Content = "x";
            }
            else
            {
                leftHairpinResult.Content = "a";
            }

        }

        /// <summary>
        /// When the RIGHT hairpin button is pressed, the hairpin test is called and the display
        /// is updated accordingly. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HairpinRightButton_Click(object sender, RoutedEventArgs e)
        {
            alignmentTests at = new alignmentTests(_leftPrimer);
            double worstCase=at.hairpinRun();
            if (worstCase < _leftGibbsFree)
            {
                rightHairpinResult.Content = "x";
            }
            else
                rightHairpinResult.Content = "a";
        }

        /// <summary>
        /// When the RIGHT Self-Dimer button is pressed, the test is called and the display
        /// is updated accordingly. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelfDimerRightButton_Click(object sender, RoutedEventArgs e)
        {
            alignmentTests at = new alignmentTests(_rightPrimer);
            double worstCase = at.selfDimerRun();
            if (worstCase < _rightGibbsFree)
            {
                rightSelfDimerResult.Content = "x";
            }
            else
                rightSelfDimerResult.Content = "a";

        }

        /// <summary>
        /// When the RIGHT Heterodimer button is pressed, the test is called and the display
        /// is updated accordingly. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeteroDimerRightButton_Click(object sender, RoutedEventArgs e)
        {
            alignmentTests at = new alignmentTests(_rightPrimer);
            double worstCase = at.heteroDimerRun(_leftPrimer);

            if (worstCase < _rightGibbsFree)
            {
                rightHeteroDimerResult.Content = "x";
            }
            else
                rightHeteroDimerResult.Content = "a";

        }

        /// <summary>
        /// When the LEFT Self-Dimer button is pressed, the test is called and the display
        /// is updated accordingly. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelfDimerLeftButton_Click(object sender, RoutedEventArgs e)
        {
            alignmentTests at = new alignmentTests(_leftPrimer);
            double worstCase = at.selfDimerRun();
            //Console.WriteLine(worstCase);
            if (worstCase < _rightGibbsFree)
            {
                leftSelfDimerResult.Content = "x";
            }
            else
            {
                leftSelfDimerResult.Content = "a";
            }

        }

        /// <summary>
        /// When the LEFT Heterodimer button is pressed, the test is called and the display
        /// is updated accordingly. 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeteroDimerLeftButton_Click(object sender, RoutedEventArgs e)
        {

            alignmentTests at = new alignmentTests(_leftPrimer);
            double worstCase = at.heteroDimerRun(_rightPrimer);
            //Console.WriteLine(worstCase);
            if (worstCase < _rightGibbsFree)
            {
                leftHeteroDimerResult.Content = "x";
            }
            else
            {
                leftHeteroDimerResult.Content = "a";

            }
        }

        /// <summary>
        /// When the SAVE button on the BLAST display is pressed, a phrase is displayed on 
        /// the surface to inform the user that their Primer has been saved. 
        /// 
        /// Functionality coming later...
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(3.0));
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.Duration = duration; 

            opacityAnimation.From = 1.0;
            opacityAnimation.To = 0.0;

            Storyboard.SetTargetName(opacityAnimation, saveLabelSVI.Name);
            Storyboard.SetTarget(opacityAnimation, saveLabelSVI);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(ScatterViewItem.OpacityProperty));

            saveStoryboard = new Storyboard();

            saveStoryboard.Children.Add(opacityAnimation);
            saveStoryboard.Begin();

        }

        #endregion





       


    }
    }

