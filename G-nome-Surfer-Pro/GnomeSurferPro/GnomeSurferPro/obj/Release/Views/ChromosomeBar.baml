   M S B A M L   `   `   `  ���� P  LGnomeSurferPro, Version=1.0.4260.16603, Culture=neutral, PublicKeyToken=null/clr-namespace:GnomeSurferProGnomeSurferPro  C&clr-namespace:GnomeSurferPro.SelectorsGnomeSurferPro.Selectors  ;"clr-namespace:GnomeSurferPro.ViewsGnomeSurferPro.Views  9!clr-namespace:GnomeSurferPro.UtilGnomeSurferPro.Util  (    "GnomeSurferPro.Views.ChromosomeBar   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    e aMicrosoft.Surface.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  $lclr-namespace:GnomeSurferPro  6	selectors&clr-namespace:GnomeSurferPro.Selectors  .views"clr-namespace:GnomeSurferPro.Views  ,util!clr-namespace:GnomeSurferPro.Util    � 	Resources   �� 
TargetType   	GridStyle �� Property �� Value  TickMarkDataTemplate �� Orientation	 �� X1	 �� Y1	 �� X2	 �� Y2	 �� Path  GenePartDataTemplate<  6Microsoft.Surface.Presentation.Controls.LibraryBarItem
 �� Triggers �� Binding �� Value J� Clip E� IsClosed E� 
StartPoint �� Point  GenePentagonItemcontainer �� 
TargetType@  :Microsoft.Surface.Presentation.Controls.SurfaceListBoxItem ��Name ! ForwardGeneItemContainerStyle �� BasedOn ! ReverseGeneItemContainerStyle  TickMarkItemContainerStyle  	myEllipse @� RadiusX @� RadiusY @� Center1   +GnomeSurferPro.Selectors.VisualPartSelector  myVisualPartSelector8  2GnomeSurferPro.Selectors.GenePentagonStyleSelector 	 myGenePentagonStyleSelector��%�  &	        &	 $     &	 �     &	 t    &	 7    7  &	 ^    7  &	 �    &	      &	 G    &		 L    �� " �.���  � ��$	 200���� .R��� $ Vertical=�.+��� $ 0��$ 0��$ 0��$ 15��
�������$��1��$��Center=��� 
����������� $	 DisplayedValue��� .R�� .+�  -   ���� $	 Length����� $	 Height����� "  
 ��  �� $	 	Direction� Forward.a���  � ��
 ������  �@J�Opacity$
 0.75Q���  �� $	 	Direction� Reverse.a���  � ��
 �/�����  �@J�Opacity$
 0.75Q� B� ��E�  .  �� $	 ZerothPentagonPoint�����  �� $	 OnethPentagonPoint���  �� $	 TwothPentagonPoint���  �� $	 ThreethPentagonPoint���  �� $	 FourthPentagonPoint�.���� $ 
Horizontal=�$��15 0 0 0q�  ���� '��       " ��.���  � ��$ 12(���  � ��$ Center=�.+��� $
��Bold"����� $
	 Name��� ���� $	 LocusTag��� .���  � ��$ 0q���  � ��$ 0����  � ��$ 0����  �@��Left �� *LeftPosition+��  � �� �� "  .R�� $��0q�
������ .+��� $ ContentHost���� 8   .���  �@��Top$ 20���� 8   .���  �@��Top$	 130���� .���  �@��Left �� *
Position+��  �@��Top$ 90����  � �� �� "  .R�� $��0q�
������ .+��� $ ContentHost��@� $	 150Q�$	 150Q�$ 150,150&�    .���  � RowDefinitions �� $��3* ��� $��2* ��� $��3* �.+�� #��[  $��0��$��	0,200,0,0q�.+�<  6Microsoft.Surface.Presentation.Controls.SurfaceListBox  -   $��GeneListBox��#��[ #��[	 ���� *Parts+���� .R�A  ;Microsoft.Surface.Presentation.Controls.SurfaceScrollViewer  -   $��Disabled=�$��Hidden=���. 
�������-   'GnomeSurferPro.Util.ScrollViewerBinding   HorizontalOffset �� *LeftmostVisiblePixel+ �� Mode$ TwoWay=�.��/   )GnomeSurferPro.Views.LoopCanvasHorizontal   K� IsItemsHost .    ContentWidth �� *ContentWidth+   Viewport �� *ViewportSize+$ OneWayToSource=�   ContentOffset �� *ContentOffset+$ OneWayToSource=�   ContentOriginOffset �� *ContentOriginPosition+$ OneWayToSource=�� $��1��.+��� $	 512��$	 175��$	 512��$	 215��$��4��
��������� $	 512��$	 175��$ 0��$ 0��$��2��
��������� $	 512��$	 175��$
 1024��$ 0��$��2��
�������9	  3Microsoft.Surface.Presentation.Controls.ScatterView	  $	��300��$	��300��$��2��.@�=
  7Microsoft.Surface.Presentation.Controls.ScatterViewItem
   
  CanMove .    
  CanScale  .  ! 
  	CanRotate! . " 
  Center$" 150,150&�$	��300��$	��300��
������ # 
  ShowsActivationEffects# .  # [ $ 
  Orientation$ �� $	 WheelOrientation�$ TwoWay=�.���� ���� $	 WheelImageSource�