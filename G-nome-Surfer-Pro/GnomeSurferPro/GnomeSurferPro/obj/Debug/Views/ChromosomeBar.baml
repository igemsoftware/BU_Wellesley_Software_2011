   M S B A M L   `   `   `  ����P  LGnomeSurferPro, Version=1.0.4286.15115, Culture=neutral, PublicKeyToken=null/clr-namespace:GnomeSurferProGnomeSurferPro  5      C&clr-namespace:GnomeSurferPro.SelectorsGnomeSurferPro.Selectors  5      ;"clr-namespace:GnomeSurferPro.ViewsGnomeSurferPro.Views  5      9!clr-namespace:GnomeSurferPro.UtilGnomeSurferPro.Util  5      (    "GnomeSurferPro.Views.ChromosomeBar   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      e aMicrosoft.Surface.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  5      $lclr-namespace:GnomeSurferPro  5      6	selectors&clr-namespace:GnomeSurferPro.Selectors  5      .views"clr-namespace:GnomeSurferPro.Views  5      ,util!clr-namespace:GnomeSurferPro.Util  5        � 	Resources  5
       �� 
TargetType   	GridStyle �� Property �� Value  TickMarkDataTemplate �� Orientation	 �� X1	 �� Y1	 �� X2	 �� Y2	 �� Path  GenePartDataTemplate<  6Microsoft.Surface.Presentation.Controls.LibraryBarItem
 �� Triggers �� Binding �� Value J� Clip E� IsClosed E� 
StartPoint �� Point  GenePentagonItemcontainer �� 
TargetType@  :Microsoft.Surface.Presentation.Controls.SurfaceListBoxItem ��Name ! ForwardGeneItemContainerStyle �� BasedOn ! ReverseGeneItemContainerStyle  TickMarkItemContainerStyle  	myEllipse @� RadiusX @� RadiusY @� Center1   +GnomeSurferPro.Selectors.VisualPartSelector  myVisualPartSelector8  2GnomeSurferPro.Selectors.GenePentagonStyleSelector 	 myGenePentagonStyleSelector��%�	  &	        &	 I     &	 ?    &	 �    &	 6    7  &	 }    7  &	 �    &	 �    &	 #	    &		 6	    �� 5   
   " �6   .�5      ��  � ��$	 200��6'   5      �� 5   
   .R�5      �� $ Vertical=�6   .+�5      �� $ 0��6   $ 0��6   $ 0��6%   $ 15��6,   
�������$��1��6C   $��Center=�6W   �� 5      
���������6   �� $	 DisplayedValue�6@   5      5      �� 5   
   .R�5      � .+�5        -   5        ��5   #   �� $	 Length���5      �� $	 Height���5       �� 5!      "  6    
 5"      �� 5#   "    6.   �� $	 	Direction� Forward6Q   .a�5$   &   ��  � ��
 ����6C   �� 5%   &    �@J�Opacity$
 0.75Q�6@   5&   #   �� 5'   "    6.   �� $	 	Direction� Reverse6Q   .a�5(   &   ��  � ��
 �/���6C   �� 5)   &    �@J�Opacity$
 0.75Q�6@   5*   #   5,       5.      B� 5/      ��51   "   E�  .  6-   �� $	 ZerothPentagonPoint���53   *   ��  66   �� $	 OnethPentagonPoint��� 54   *    66   �� $	 TwothPentagonPoint��� 55   *    66   �� $	 ThreethPentagonPoint��� 56   *    66   �� $	 FourthPentagonPoint�58   #   5:      .��5<      �� $ 
Horizontal=�6!   $��15 0 0 0q�6:     5=      ���� 5>      '��       " ��6$   .�5?   "   ��  � ��$ 12(�6=   �� 5@   "    � ��$ Center=�6F   5A      5B      .+�5C      �� $
��Bold"�6    ��62   �� $
	 Name��� 5D      ��6    �� $	 LocusTag�5E      5F      5c      5e      �� 5j   
   .�5k      ��  � ��$ 0q�60   �� 5l       � ��$ 0��61   �� 5m       � ��$ 0��62   �� 5n       �@��Left 6,   �� *LeftPosition+�� 5o       � �� 5p      �� 5q      "  6&   .R�5r      � $��0q�6$   
������ .+�5s      �� $ ContentHost��6/   5t      5u      5w      5x      �� 5{   
   8   .�5|      ��  �@��Top$ 20��6+   5~      �� 5�   
   8   .�5�      ��  �@��Top$	 130��6+   5�      �� 5�   
   .�5�      ��  �@��Left 6,   �� *
Position+�� 5�       �@��Top$ 90��6+   �� 5�       � �� 5�      �� 5�      "  6&   .R�5�      � $��0q�6$   
������ .+�5�      �� $ ContentHost��6/   5�      5�      5�      5�      @� 5�   
   $	 150Q�6,   $	 150Q�6:   $ 150,150&�6H     5�   
   6'     5�   
   6.   5�      .��5�      �  � RowDefinitions 5�   
   �� 5�      $��3* �6   �� 5�      $��2* �6   �� 5�      $��3* �6   .+�5�   
   � #��[  6   $��0��62   $��	0,200,0,0q�6?   .+�5�      <  6Microsoft.Surface.Presentation.Controls.SurfaceListBox  -   5        $��GeneListBox��5�      #��[ 5�      #��[	 5�      ��5�      �� *Parts+��5�      �� 5�      .R�5�      A  ;Microsoft.Surface.Presentation.Controls.SurfaceScrollViewer  -   5        $��Disabled=�5�      $��Hidden=�5�      ��. 
�������-   'GnomeSurferPro.Util.ScrollViewerBinding   HorizontalOffset 5�      �� *LeftmostVisiblePixel+ �� Mode$ TwoWay=�.��5�      /   )GnomeSurferPro.Views.LoopCanvasHorizontal   K� IsItemsHost .    ContentWidth 5�   !   �� *ContentWidth+   Viewport 5�   !   �� *ViewportSize+$ OneWayToSource=�   ContentOffset 5�   !   �� *ContentOffset+$ OneWayToSource=�   ContentOriginOffset 5�   !   �� *ContentOriginPosition+$ OneWayToSource=�5�      5�      5�      5�      � 5�   
   $��1��6   .+�5�      �� $	 512��6   $	 175��6   $	 512��6%   $	 215��6.   $��4��67   
�������6K   �� 5�      $	 512��6   $	 175��6   $ 0��6%   $ 0��6,   $��2��63   
�������6G   �� 5�      $	 512��6   $	 175��6   $
 1024��6%   $ 0��6/   $��2��66   
�������6J   5�      9	  3Microsoft.Surface.Presentation.Controls.ScatterView	  5�   	   $	��300��6   $	��300��6#   $��2��60   .@�5�      =
  7Microsoft.Surface.Presentation.Controls.ScatterViewItem
   
  CanMove .    
  CanScale  .  ! 
  	CanRotate! . " 
  Center$" 150,150&�6R   $	��300��5�       $	��300��6-   
������ # 
  ShowsActivationEffects# .  # [ 5�       $ 
  Orientation$ 5�       �� $	 WheelOrientation�$ TwoWay=�.��5�      �� ��6   �� $	 WheelImageSource�5�      5�      5�      5�      