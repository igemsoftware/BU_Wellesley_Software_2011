   M S B A M L   `   `   `  ����P  LGnomeSurferPro, Version=1.0.4286.15115, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GnomeSurferPro.ViewModelsGnomeSurferPro.ViewModels  5      ;"clr-namespace:GnomeSurferPro.ViewsGnomeSurferPro.Views  5      /clr-namespace:GnomeSurferProGnomeSurferPro  5      C&clr-namespace:GnomeSurferPro.SelectorsGnomeSurferPro.Selectors  5      *    $GnomeSurferPro.Views.ExtendedDesktop   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      e aMicrosoft.Surface.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  5      8
viewmodels'clr-namespace:GnomeSurferPro.ViewModels  5      .views"clr-namespace:GnomeSurferPro.Views  5      (localclr-namespace:GnomeSurferPro  5      6	selectors&clr-namespace:GnomeSurferPro.Selectors  5        � 	Resources  5         SviScaleToContent �� 
TargetType=  7Microsoft.Surface.Presentation.Controls.ScatterViewItem �� Property �� Value �� Path �� RelativeSource �� Mode �� 
TargetType  MoveableSvi �� BasedOn  PublicationsSVIStyle  PublicationsArticleSVIStyle  SeqTransSVIStyle  GeneInfoSVIStyle  TestSVIStyle  PublicationsSVIDataTemplate.   (GnomeSurferPro.Views.PublicationsArticle  SequenceTemplate'   !GnomeSurferPro.Views.SequenceView 	 TranslationTemplate*   $GnomeSurferPro.Views.TranslationView 
 TestSVITemplate"   GnomeSurferPro.Views.TestSVI  NotesTemplate$   GnomeSurferPro.Views.NotesView;  5GnomeSurferPro.Selectors.ExtendedDesktopStyleSelector  myStyleSelector>  8GnomeSurferPro.Selectors.ExtendedDesktopTemplateSelector  myDataTemplateSelector��%�	  &	        &	 �    7   &	 �    &	 �    7  &	 =    7  &	 .    7  &	     7  &	 7    &	 _    &		 �    &	
 �    &	 �    &	 �    &	 	    �� 5   
   "  6*   .�5      ��  � �� 6)   �� $ Content.MinWidth� �� *Self+$ OneWay=��� 5       � �� 6*   �� $ Content.MinHeight� �� *Self+$ OneWay=��� 5       � �� 6)   �� $ Content.MaxWidth� �� *Self+$ OneWay=��� 5       � �� 6*   �� $ Content.MaxHeight� �� *Self+$ OneWay=��� 5       � �� 6&   �� $ Content.Width� �� *Self+$ TwoWay=��� 5       � �� 6'   �� $ Content.Height� �� *Self+$ TwoWay=��� 5       � �� 5      �� 5      "  6&   .R�5      �� 5      5      5      �� 5   
   8   "  5      .�5      ��  �@ CanMove . 6:   �� 5       �@ CanScale . 6;   �� 5        �@ 	CanRotate . 6<   �� 5!       � ��$ 20q�60   �� 5"       �@ Center$ 400,200&�6'   -   5        5$      �� 5&   
   "  6-   .�5'      ��  �@ CanMove . 6(   �� 5(       �@ CanScale .  6)   �� 5)       �@ 	CanRotate .  6*   �� 5*       �@ Orientation$ 0Q�6,   �� 5+       � ��$	 320��6)   �� 5,       � ��$	 240��6*   �� 5-       � ��$	 320��6&   �� 5.       � ��$	 240��6'   �� 5/       � ��
 �   �6+   �� 50       � ��$ 20q�60   �� 51       � ��
 �����6,   -   5        53      �� 55   
   8   "  6[   .�56      ��  � ��$	 480��6&   �� 57       � ��$	 320��6'   �� 58       �@ CanScale .  6)   -   5        5;      �� 5>   
   8   "  6P   .�5?      ��  � ��$	 300��6&   �� 5@       � ��$
 Auto��6'   �� 5A       � ��$	 500��6*   �� 5B       � ��$	 300��6)   �� 5C       � ��$	 150��6*   -   5        5F      �� 5H   
   8   "  6P   .�5I      ��  � ��$	 300��6&   �� 5J       � ��$
 Auto��6'   �� 5K       � ��$	 500��6*   �� 5L       � ��$	 300��6)   �� 5M       � ��$	 150��6*   5N      �� 5P   
   8   "  6L   5Q      �� 5S   
   .R�5T        5U      �� 5W   
   .R�5X        5Y      �� 5[   
   .R�5\        5]      �� 5_   
   .R�5`        5a      �� 5c   
   .R�5d        5e        5h   
   61     5i   
   64   5j      .��5l      9	  3Microsoft.Surface.Presentation.Controls.ScatterView	  -   5        $��workspaceBarSV��5l      $
��1024��6*   $	��730��67   .@�5m   
     -   5        $��workspaceBlockerSVI��5m      $
��1024��67   $	��730��6D   	   Center$	 512,395&�6Q   
   CanMove
 .     	CanRotate .     CanScale .     ShowsActivationEffects .  .��5p      	  -   5        $��workspaceActualSV��5p      $
��1024��65   $	��730��6B   
�������#��[ 5s      #��[ 5t      ��5r      �� *WorkspaceCollection+5v      5w      5x      5y      