   M S B A M L   `   `   `  ����P  LGnomeSurferPro, Version=1.0.4286.15115, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GnomeSurferPro.ViewModelsGnomeSurferPro.ViewModels  5      ;"clr-namespace:GnomeSurferPro.ViewsGnomeSurferPro.Views  5      /clr-namespace:GnomeSurferProGnomeSurferPro  5      C&clr-namespace:GnomeSurferPro.SelectorsGnomeSurferPro.Selectors  5      9!clr-namespace:GnomeSurferPro.UtilGnomeSurferPro.Util  5	      I EPrimerDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PrimerDesigner;assembly=PrimerDesignerPrimerDesigner 5
      )    #GnomeSurferPro.Views.SurfaceWindow1   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      e aMicrosoft.Surface.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  5      8
viewmodels'clr-namespace:GnomeSurferPro.ViewModels  5      .views"clr-namespace:GnomeSurferPro.Views  5      (localclr-namespace:GnomeSurferPro  5      6	selectors&clr-namespace:GnomeSurferPro.Selectors  5      ,util!clr-namespace:GnomeSurferPro.Util  5	      Aprimer4clr-namespace:PrimerDesigner;assembly=PrimerDesigner  5
        � Title$  GnomeSurferPro��5       � 	Resources 5         SviScaleToContent �� 
TargetType=  7Microsoft.Surface.Presentation.Controls.ScatterViewItem �� Property �� Value �� Path �� RelativeSource �� Mode �� 
TargetType  StationarySvi	 �� BasedOn  MoveableSvi  ChromosomeBarSVIStyle  PublicationsSVIStyle  GeneSearchBoxStyle  PublicationsArticleSVIStyle  
ShelfStyle  ExtendedDesktopSVIStyle 	 GeneInfoSVIStyle 
 SeqTransSVIStyle  TestSVIStyle  SearchShelfStyle  ChromosomeBarTemplate(   "GnomeSurferPro.Views.ChromosomeBar  GeneSearchBoxTemplate)   #GnomeSurferPro.Views.GeneSearchView  PublicationsTemplate.   (GnomeSurferPro.Views.PublicationsListBox  ExtendedDesktopTemplate*   $GnomeSurferPro.Views.ExtendedDesktop  SearchShelfTemplate
 � RowDefinitions%   GnomeSurferPro.Views.SearchMenu � DataContext � ColumnDefinitions �� Orientation �� Triggers �� Binding �� Value<  6Microsoft.Surface.Presentation.Controls.SurfaceTextBox �� UpdateSourceTrigger;  5Microsoft.Surface.Presentation.Controls.SurfaceButton  SequenceTemplate'	   !GnomeSurferPro.Views.SequenceView  TranslationTemplate*
   $GnomeSurferPro.Views.TranslationView  NotesTemplate$   GnomeSurferPro.Views.NotesView  TestSVITemplate"   GnomeSurferPro.Views.TestSVI  PublicationsSVIDataTemplate.   (GnomeSurferPro.Views.PublicationsArticleG  AGnomeSurferPro.Selectors.SurfaceWindow1ItemContainerStyleSelector  myStyleSelectorA  ;GnomeSurferPro.Selectors.SurfaceWindow1DataTemplateSelector  myDataTemplateSelector��%F  &	        &	 �    7   &	 �    7   &	 �    7  &	     &	     7  &	 [    7  &	 �    &	 �    7  &		 �	    7  &	
 �
    7  &	 �    7  &	 �    7  &	 g    &	 �    &	 �    &	 �    &	     &	 6    &	 ^    &	 �    &	 �    &	 �    &	 �    &	     �� 5   
   "  6*   .�5      ��  � �� 6)   �� $ Content.MinWidth� �� *Self+$ OneWay=��� 5       � �� 6*   �� $ Content.MinHeight� �� *Self+$ OneWay=��� 5       � �� 6)   �� $ Content.MaxWidth� �� *Self+$ OneWay=��� 5       � �� 6*   �� $ Content.MaxHeight� �� *Self+$ OneWay=��� 5       � �� 6&   �� $ Content.Width� �� *Self+$ TwoWay=��� 5       � �� 6'   �� $ Content.Height� �� *Self+$ TwoWay=��� 5       � �� 5      �� 5      "  6&   .R�5      �� 5      5      5      �� 5   
   8	   "  5       .�5!      ��  �@ CanMove .  6:   �� 5"       �@ CanScale .  6;   �� 5#       �@ 	CanRotate .  6<   �� 5$       �@ Orientation$ 0Q�6>   �� 5%       �@ IsTopmostOnActivation .  6H   5&      �� 5(   
   8	   "  5)      .�5*      ��  �@ CanMove . 6:   �� 5+       �@ CanScale . 6;   �� 5,       �@ 	CanRotate . 6<   �� 5-       �@ Orientation$ 0Q�6>   -   5        50      �� 52   
   8	   "  6W   .�53      ��  �@ Center$ 512, 300&�69   �� 54       � ��$
 1024��68   55      �� 57   
   "  6-   .�58      ��  �@ CanMove . 6(   �� 59       �@ CanScale .  6)   �� 5:       �@ 	CanRotate .  6*   �� 5;       �@ Orientation$ 0Q�6,   �� 5<       � ��$	 320��6)   �� 5=       � ��$	 240��6*   �� 5>       � ��$	 320��6&   �� 5?       � ��$	 240��6'   �� 5@       � ��
 �����6+   �� 5A       � ��$ 20q�60   �� 5B       � ��
 �����6,   -   5        5E      �� 5G   
   8	   "  6T   .�5H      ��  �@ Center$ 300, 300&�6'   5I      �� 5K   
   8	   "  6[   .�5L      ��  �@ CanScale .  6)   -   5        5O      �� 5Q   
   "  6#   .�5R      ��  �@ ShowsActivationEffects .  67   �� 5S       �@ 	CanRotate .  6*   �� 5T       �@ CanScale .  6)   �� 5U       �@ Orientation$ 0Q�6,   �� 5V       �@ DecelerationRate$
 2500Q�61   5W      �� 5Y   
   "  60   8	   .�5Z      ��  � ��$
 1024��6&   �� 5[       � ��$	 750��6'   �� 5\       �@ Center$ 	512, 1115&�6'   �� 5]       � ��
 �����6+   -   5        5a      �� 5d   
   8	   "  6P   .�5e      ��  � ��$	 340��6&   �� 5f       � ��$
 Auto��6'   �� 5g       � ��$	 500��6*   �� 5h       � ��$	 340��6)   �� 5i       � ��$	 150��6*   5j      �� 5m   
   8	   "  6P   .�5n      ��  � ��$	 300��6&   �� 5o       � ��$
 Auto��6'   �� 5p       � ��$	 500��6*   �� 5q       � ��$	 300��6)   �� 5r       � ��$	 150��6*   -   5        5u      �� 5w   
   8	   "  6L   �� 5y   
   8	   "  6O   .�5z      ��  � ��$
 1024��6&   �� 5{       � ��$	 730��6'   �� 5|       �@ Center 6'   �� *Center+$ TwoWay=�-   5        5      �� 5�   
   .R�5�        5�      �� 5�   
   .R�5�        5�      �� 5�   
   .R�5�        5�      �� 5�   
   .R�5�        5�      �� 5�   
   .R�5�      � $
��1024��6   $	��730��6    
�������
 5�      �� 5�      $��* �6$   �� 5�      $
��auto �6$   .+�5�        $��0��6#   $��Center=�5�   #   $��Bottom=�5�   #    5�   #   �� *SearchMenuViewModel+� 5�      $��1��6   $��Stretch=�6$    5�      ���� 5�      '��       " ��6    .�5�      ��  � ��$ 16(�69   5�      5�       5�      �� 5�      $
��auto �6+   �� 5�      $��* �6+   �� 5�      $
��auto �6+   .+�5�      �� $ 
Horizontal=�6!   $��0��6:   $��Center=�6J   .+�5�      �� 
�������$��40 0 0 0q�62   $��Current Chromosome:��6D   �� 5�      
���������62   �� *CurrentChromosomeName+5�      �� 5�      $ 
Horizontal=�6!   $��2��6:   $��Center=�6J   $��0 0 20 5q�6e   .+�5�      �� $��10(�6    $��Bottom=�6.   ��5�      �� 5�   "   " ��6(    5�   &   �� 5�   *    66   �� *GeneSearchStatus+ Idle6[   .a�5�   .   ��  � y�$ 	Collapsed=�6K   5�   +   �� 5�   *    66   �� *GeneSearchStatus+ 	Searching6[   .a�5�   .   ��  � y�$ Visible=�6K   �� 5�   .    � ��$ 	SEARCHING��6H   �� 5�   .    � ��
 �����6K   5�   +   �� 5�   *    66   �� *GeneSearchStatus+ GeneNotFound6[   .a�5�   .   ��  � y�$ Visible=�6K   �� 5�   .    � ��$ GENE NOT FOUND��6H   �� 5�   .    � ��
 �  ��6K   5�   +   5�   #   5�      �� 5�      
���   �$��Search by Gene��63     5�      -   5        $	��150��5�   +   $��Center=�67   $��3 0 0 0q�6Y   $��16(�6k   ��5�      �� $ GeneSearchBoxText�$ TwoWay=�$ PropertyChanged=�5�        5�      $	��100��6*   $��16(�66   $��Search��6D   ��6U   �� *GeneSearchCommand+5�      5�      5�      5�      �� 5�   
   .R�5�      	  5�      �� 5�   
   .R�5�      
  5�      �� 5�   
   .R�5�        5�      �� 5�   
   .R�5�        5�      �� 5�   
   .R�5�        5�        5�   
   6=     5�   
   67   5�      .��5�      � 
���   �.+�5�   
   9  3Microsoft.Surface.Presentation.Controls.ScatterView  -   5          Name$ mainSV��5�   V   #��[ 6   #��[ 5�      
������ ��5�      �� *AllObjectsCollection+5�      � 5�   
   
���   ���5�      �� 5�      " �6    5�      �� 5�       6&   �� *InitialSearchStatus+ Complete6N   .a�5�      ��  � y�$ 	Collapsed=�6;   5�      5�      
 5�      �� 5�      $	��500 �6    �� 5�      $
��auto �6    �� 5�      $��20 �6    �� 5�      $
��auto �6    �� 5�      $��20 �6    �� 5�      $
��auto �6    .+�5       $��1��6    6,   �� *InitialSearchMenu+�� 5     $��Center=�6   $��50(�5     
�������$��Select Genome to Begin��5     $��3��5     �� 5     $T��NSorry for the wait! It may take up to thirty seconds to render the chromosome.��6   $��18(�6n   $��5��6|   
�������$��Center=�5  #   ��5	     �� 5
     " ��6   .�5     ��  � y�$ 	Collapsed=�67    5     �� 5      6*   �� *InitialSearchStatus+ 	Searching6R   .a�5  "   ��  � y�$ Visible=�6?   5     5     5     5     �� 5  
   ��6   Z� .+�5     9  3Microsoft.Surface.Presentation.Controls.ElementMenu  -	   5          Name$ _GeneElementMenu��5        ActivationMode$ AlwaysActive=�5     $y�	Collapsed=�5     $��0q�5     $��0q�5     .@�5     =  7Microsoft.Surface.Presentation.Controls.ElementMenuItem  $��Sequence��6$      Command 66   �� *ShowSequenceCommand+  5     $��Translation��6$    69   �� *ShowTranslationCommand+  5     $��Publications��6$    6:   �� *ShowPublicationsCommand+  5      $��Notes��6$    63   �� *ShowNotesCommand+  5!     $��Primer��6$    64   �� *ShowPrimerDesignerCommand+5"     5#     � 5'  
    6   �� *PrimerDesignerViewModel+.+�5(     .  (PrimerDesigner.PrimerDesignerUserControl  y�6/   �� *DesignerVisibility+   
TargetGene 6Y   �� *Gene+5)     5+     5,     