   M S B A M L   `   `   `  ���� P  LGnomeSurferPro, Version=1.0.4260.16603, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GnomeSurferPro.ViewModelsGnomeSurferPro.ViewModels  ;"clr-namespace:GnomeSurferPro.ViewsGnomeSurferPro.Views  /clr-namespace:GnomeSurferProGnomeSurferPro  C&clr-namespace:GnomeSurferPro.SelectorsGnomeSurferPro.Selectors  9!clr-namespace:GnomeSurferPro.UtilGnomeSurferPro.Util  I EPrimerDesigner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PrimerDesigner;assembly=PrimerDesignerPrimerDesigner )    #GnomeSurferPro.Views.SurfaceWindow1   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    e aMicrosoft.Surface.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  8
viewmodels'clr-namespace:GnomeSurferPro.ViewModels  .views"clr-namespace:GnomeSurferPro.Views  (localclr-namespace:GnomeSurferPro  6	selectors&clr-namespace:GnomeSurferPro.Selectors  ,util!clr-namespace:GnomeSurferPro.Util  Aprimer4clr-namespace:PrimerDesigner;assembly=PrimerDesigner    � Title$  GnomeSurferPro�� � 	Resources    SviScaleToContent �� 
TargetType=  7Microsoft.Surface.Presentation.Controls.ScatterViewItem �� Property �� Value �� Path �� RelativeSource �� Mode �� 
TargetType  StationarySvi	 �� BasedOn  MoveableSvi  ChromosomeBarSVIStyle  PublicationsSVIStyle  GeneSearchBoxStyle  PublicationsArticleSVIStyle  
ShelfStyle  ExtendedDesktopSVIStyle 	 GeneInfoSVIStyle 
 SeqTransSVIStyle  TestSVIStyle  SearchShelfStyle  ChromosomeBarTemplate(   "GnomeSurferPro.Views.ChromosomeBar  GeneSearchBoxTemplate)   #GnomeSurferPro.Views.GeneSearchView  PublicationsTemplate.   (GnomeSurferPro.Views.PublicationsListBox  ExtendedDesktopTemplate*   $GnomeSurferPro.Views.ExtendedDesktop  SearchShelfTemplate
 � RowDefinitions%   GnomeSurferPro.Views.SearchMenu � DataContext � ColumnDefinitions �� Orientation �� Triggers �� Binding �� Value<  6Microsoft.Surface.Presentation.Controls.SurfaceTextBox �� UpdateSourceTrigger;  5Microsoft.Surface.Presentation.Controls.SurfaceButton  SequenceTemplate'	   !GnomeSurferPro.Views.SequenceView  TranslationTemplate*
   $GnomeSurferPro.Views.TranslationView  NotesTemplate$   GnomeSurferPro.Views.NotesView  TestSVITemplate"   GnomeSurferPro.Views.TestSVI  PublicationsSVIDataTemplate.   (GnomeSurferPro.Views.PublicationsArticleG  AGnomeSurferPro.Selectors.SurfaceWindow1ItemContainerStyleSelector  myStyleSelectorA  ;GnomeSurferPro.Selectors.SurfaceWindow1DataTemplateSelector  myDataTemplateSelector��%�  &	        &	 �    7   &	 �    7   &	 8    7  &	 �    &	 �    7  &	 �    7  &	     &	 �    7  &		 Y    7  &	
 �    7  &	 j    7  &	 y    7  &	 �    &	     &	     &	     &	 (    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    �� "  .���  � �� �� $ Content.MinWidth� �� *Self+$ OneWay=���  � �� �� $ Content.MinHeight� �� *Self+$ OneWay=���  � �� �� $ Content.MaxWidth� �� *Self+$ OneWay=���  � �� �� $ Content.MaxHeight� �� *Self+$ OneWay=���  � �� �� $ Content.Width� �� *Self+$ TwoWay=���  � �� �� $ Content.Height� �� *Self+$ TwoWay=���  � �� �� "  .R��� �� 8	   "  .���  �@ CanMove .  ��  �@ CanScale .  ��  �@ 	CanRotate .  ��  �@ Orientation$ 0Q���  �@ IsTopmostOnActivation .  �� 8	   "  .���  �@ CanMove . ��  �@ CanScale . ��  �@ 	CanRotate . ��  �@ Orientation$ 0Q�-   �� 8	   "  .���  �@ Center$ 512, 300&���  � ��$
 1024���� "  .���  �@ CanMove . ��  �@ CanScale .  ��  �@ 	CanRotate .  ��  �@ Orientation$ 0Q���  � ��$	 320����  � ��$	 240����  � ��$	 320����  � ��$	 240����  � ��
 �������  � ��$ 20q���  � ��
 �����-   �� 8	   "  .���  �@ Center$ 300, 300&��� 8	   "  .���  �@ CanScale .  -   �� "  .���  �@ ShowsActivationEffects .  ��  �@ 	CanRotate .  ��  �@ CanScale .  ��  �@ Orientation$ 0Q���  �@ DecelerationRate$
 2500Q��� "  8	   .���  � ��$
 1024����  � ��$	 750����  �@ Center$ 	512, 1115&���  � ��
 �����-   �� 8	   "  .���  � ��$	 340����  � ��$
 Auto����  � ��$	 500����  � ��$	 340����  � ��$	 150���� 8	   "  .���  � ��$	 300����  � ��$
 Auto����  � ��$	 500����  � ��$	 300����  � ��$	 150��-   �� 8	   "  �� 8	   "  .���  � ��$
 1024����  � ��$	 730����  �@ Center �� *Center+$ TwoWay=�-   �� .R�  �� .R�  �� .R�  �� .R�  �� .R�� $
��1024��$	��730��
�������
 �� $��* ��� $
��auto �.+�  $��0��$��Center=�$��Bottom=� �� *SearchMenuViewModel+� $��1��$��Stretch=� ���� '��       " ��.���  � ��$ 16(� �� $
��auto ��� $��* ��� $
��auto �.+��� $ 
Horizontal=�$��0��$��Center=�.+��� 
�������$��40 0 0 0q�$��Current Chromosome:���� 
����������� *CurrentChromosomeName+�� $ 
Horizontal=�$��2��$��Center=�$��0 0 20 5q�.+��� $��10(�$��Bottom=����� " �� ��  �� *GeneSearchStatus+ Idle.a���  � y�$ 	Collapsed=���  �� *GeneSearchStatus+ 	Searching.a���  � y�$ Visible=���  � ��$ 	SEARCHING����  � ��
 �������  �� *GeneSearchStatus+ GeneNotFound.a���  � y�$ Visible=���  � ��$ GENE NOT FOUND����  � ��
 �  ���� 
���   �$��Search by Gene��  -   $	��150��$��Center=�$��3 0 0 0q�$��16(����� $ GeneSearchBoxText�$ TwoWay=�$ PropertyChanged=�  $	��100��$��16(�$��Search������ *GeneSearchCommand+�� .R�	  �� .R�
  �� .R�  �� .R�  �� .R�      .��� 
���   �.+�9  3Microsoft.Surface.Presentation.Controls.ScatterView  -     Name$ mainSV��#��[ #��[ 
������ ���� *AllObjectsCollection+� 
���   ����� " � ��  �� *InitialSearchStatus+ Complete.a���  � y�$ 	Collapsed=�
 �� $	��500 ��� $
��auto ��� $��20 ��� $
��auto ��� $��20 ��� $
��auto �.+�  $��1�� �� *InitialSearchMenu+�� $��Center=�$��50(�
�������$��Select Genome to Begin��$��3���� $T��NSorry for the wait! It may take up to thirty seconds to render the chromosome.��$��18(�$��5��
�������$��Center=����� " ��.���  � y�$ 	Collapsed=� ��  �� *InitialSearchStatus+ 	Searching.a���  � y�$ Visible=��� ��Z� .+�9  3Microsoft.Surface.Presentation.Controls.ElementMenu  -	     Name$ _GeneElementMenu��   ActivationMode$ AlwaysActive=�$y�	Collapsed=�$��0q�$��0q�.@�=  7Microsoft.Surface.Presentation.Controls.ElementMenuItem  $��Sequence��   Command �� *ShowSequenceCommand+  $��Translation�� �� *ShowTranslationCommand+  $��Publications�� �� *ShowPublicationsCommand+  $��Notes�� �� *ShowNotesCommand+  $��Primer�� �� *ShowPrimerDesignerCommand+�  �� *PrimerDesignerViewModel+.+�.  (PrimerDesigner.PrimerDesignerUserControl  y��� *DesignerVisibility+   
TargetGene �� *Gene+