   M S B A M L   `   `   `  ����D  @Flakesnow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Flakesnow	Flakesnow  5          Flakesnow.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:Flakesnow     5        �� 	Resources  5         ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle��%�  &	        '�� C    �� 5
   
   " n�6%   .�5      ��  � �� 5      �� 5      " n�6&   .R�5      � $
 Grid��6   .+�5      �� $��Stretch=�6(   $��Stretch=�6F   $
��Auto��6b   $
��Auto��6o   
������ 6}   �� 5      $ 
Rectangle1��6%   $ 5��69   $��Stretch=�6J   $��Stretch=�6h   $
��Auto��6�   $
��Auto��6�   #��z��6�   5       5      P� 5      	 �@�Tag$
 
Horizontal��65   . �5   "   �� $ 
Rectangle1��6)    � ��$
 Auto��6R   �� 5   "   $ 
Rectangle1��6)    � ��$ 7��6S   5      5      5      5      �� 5   
   " ��6+   .�5      ��  �@��IsFlicksEnabled .  67   �� 5       � �� �#8C8C8C6+   �� 5        � ��
 ���� 6+   �� 5!       � ��$ 8��6&   �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%      � $ GridRoot��6   $��8��61   #��z��6;    5&      �� 5'   "   $��0.00001* �60   .+�5)      ]� $ 
PART_Track��6$   $��0��68   ��. |�.   5*   "   n� 5+   &   $ Thumb��6,   #��z��6;   #���   6e    5-   "   �� 5.   &   $ PageUp��63   $��ScrollBar.PageDownCommand��6C   $ 0Q�6g   |�.  6s    50   "   �� 51   &   $ PageDown��63   $��ScrollBar.PageUpCommand��6E   $ 0Q�6g   |�.  6s   53      54       55      P� 56      $ Thumb��6&   	 �@J�IsMouseOver
 . . �57   "   �� # �  6)   $ Thumb��6U    � ��6h   58      P� 59      $ Thumb��6&   	 �@n�
IsDragging
 . . �5:   "   �� # �  6)   $ Thumb��6M    � ��6`   5;      P� 5<      	 � {�
 .  . �5=   "   �� $ Thumb��6)    � y�$ 	Collapsed=�6R   5>      P� 5?      	 �@��Orientation$
 
Horizontal=�6=   . �5@   "   �� $ GridRoot��6)    �@�LayoutTransform 5A   &   �� 5B   *   $	 -90Q�6:   5D   #   �� 5E   "   $ 
PART_Track��6)    �@�LayoutTransform 5F   &   �� 5G   *   $	 -90Q�6:   5I   #   �� 5J   "    � ��$
 Auto��6:   �� 5K   "    � ��$ 8��6;   �� 5L   "   $ Thumb��6)    �@�Tag$ 
Horizontal��6K   �� 5M   "   $ PageDown��6)    � ��$ ScrollBar.PageLeftCommand��6R   �� 5N   "   $ PageUp��6)    � ��$  ScrollBar.PageRightCommand��6P   5O      5Q      5S      5T      5U      5V      