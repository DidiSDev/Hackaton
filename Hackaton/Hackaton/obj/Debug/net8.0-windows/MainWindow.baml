   M S B A M L   `   `   `  ����C  ?Hackaton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HakatonFinalHakatonFinal  5   	       HakatonFinal.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HakatonFinal     5   	     � Title$  Initial window��5   	   $	��666��6    $
��1413��6-    � WindowState$ 	Maximized=�6:    � Icon$ fotos/imagen.jpg��5	   	   ��5      �� 5   
    �� ImageSource$ fotos/fotoMain.jpg��6    j� Stretch$ UniformToFill=�66   .��5      � .+�5   
   �� -   5         ��Name$ Welcome��5      $��WELCOME!��6"   $
��Left=�65   $	��141��6P   $��682,161,0,0q�6]   $	��Top=�6r   $	��248��6�   ���#d9b0f5$��Comic Sans MS)�6�   $��40(�6�   z�5      �� 5      -   5        WelcomeRotate��5   "    � Triggers 5      :� 5       :� RoutedEvent$ Button.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� 
TargetName$ WelcomeRotate��6.   	 �� TargetProperty$	 Angle�6T   
 W� From
 -3606v   	 W� To 06�    g� Duration$ 0:0:1D�6�   W� 5      $8	 2(UIElement.RenderTransform).(TranslateTransform.Y)�6.   
 -1006}    06�   $ 0:0:1D�6�   5      5      5      5       �� 5#   
   -   5        $ Start��5#      $��Start��6    $
��Left=�60   $	��100��6K   $��706,327,0,0q�6X   $	��Top=�6m   $	��200��6�   $��Comic Sans MS)�6�   ���#8138f9$��40(�6�   z�5$      �� 5%      -   5        
StartScale�� �� ScaleX$	 0.1Q�5%   5    �� ScaleY$	 0.1Q�6B    5'      :� 5(      $ Button.Loaded��6   .[�5)      �� .��5*      �� .��5+      W� $ 
StartScale��6.   $	 ScaleX�6Q    16t   $ 0:0:1D�6{   W� 5,      $ 
StartScale��6.   $	 ScaleY�6Q    16t   $ 0:0:1D�6{   5-      5.      5/      51      �� 54   
   -   5        $ Dfacil��54      $
��EASY��6!   $	��102��60   $	��148��6=   ���#f5a0a0$
��Left=�6^   $	��Top=�6y   $��Comic Sans MS)�6�   $��510,327,0,0q�6�   ${�False��6�   $��20(�6�   z�55      V� 56      .~�57      �� -   5        
EasyRotate��57   &   T� 58      -   5        EasyTranslate��58   )   59       5;      :� 5<      $ Button.Loaded��6   .[�5=      �� .��5>      �� .��5?      W� $ 
EasyRotate��6.   $	 Angle�6Q   
 -3606s    06   $ 0:0:1D�6�   W� 5@      $ EasyTranslate��6.   $	 X�6T   
 -3006r    06~   $ 0:0:1D�6�   5A      5B      5C      5E      �� 5H   
   -   5        $ Ddificil��5H      $
��HARD��6#   $	��101��62   $	��140��6?   $
��Left=�6K   $	��Top=�6f   ���#f32d2d$��Comic Sans MS)�6�   $��957,326,0,0q�6�   ${�False��6�   $��20(�6�   z�5I      V� 5J      .~�5K      �� -	   5        
HardRotate��5K   &   T� 5L      -
   5        HardTranslate��5L   )   5M       5O      :� 5P      $ Button.Loaded��6   .[�5Q      �� .��5R      �� .��5S      W� $ 
HardRotate��6.   $	 Angle�6Q   
 -3606s    06   $ 0:0:1D�6�   W� 5T      $ HardTranslate��6.   $	 X�6T   
 3006r    06}   $ 0:0:1D�6�   5U      5V      5W      5Y      �� 5\   
   -   5        $ Dmedia��5\      $��MODERATE��6!   $	��102��64   $	��148��6A   ���#f35656$
��Left=�6b   $	��Top=�6}   $��Comic Sans MS)�6�   $��732,479,0,0q�6�   ${�False��6�   $��20(�6�   z�5]      V� 5^      .~�5_      �� -   5        MediumScale��$	 0.1Q�5_   :   $	 0.1Q�6G   T� 5`      -   5        MediumTranslate��5`   )   5a       5c      :� 5d      $ Button.Loaded��6   .[�5e      �� .��5f      �� .��5g      W� $ MediumScale��6.   $	 ScaleX�6R    16u   $ 0:0:1D�6|   W� 5h      $ MediumScale��6.   $	 ScaleY�6R    16u   $ 0:0:1D�6|   W� 5i      $ MediumTranslate��6.   $	 Y�6V   
 3006t    06   $ 0:0:1D�6�   5j      5k      5l      5n      �� 5q   
   -   5        $ Cerrar��5q      $
��Exit��6!   $
��Left=�60   $	��100��6K   $��706,592,0,0q�6X   $	��Top=�6m   $	��200��6�   $��Comic Sans MS)�6�   ���#8138f9$��40(�6�   z�5r      �� 5s      -   5        
CloseScale��$	 0.1Q�5s   5   $	 0.1Q�6B    5u      :� 5v      $ Button.Loaded��6   .[�5w      �� .��5x      �� .��5y      W� $ 
CloseScale��6.   $	 ScaleX�6Q    16t   $ 0:0:1D�6{   W� 5z      $ 
CloseScale��6.   $	 ScaleY�6Q    16t   $ 0:0:1D�6{   5{      5|      5}      5      �� 5�   
   $
��Left=�6   $��22��6/   $��538,405,0,0q�6;   $
��Wrap=�6P   $��+10 points each ��6d   $	��Top=�6|   $��92��6�   �� 5�   
   $
��Left=�6   $��22��6/   $��982,403,0,0q�6;   $
��Wrap=�6P   $��+30 points each��6d   $	��Top=�6{   $��90��6�   �� 5�   
   $
��Left=�6   $��22��6/   $��761,559,0,0q�6;   $
��Wrap=�6P   $��+20 points each��6d   $	��Top=�6{   $��90��6�   �� 5�   
   -   5         ��Name$ ImageBorder��5�      
������� �� CornerRadius$ 15��6=   
����  �$��2q�6f    �� Padding$ 10q�6z   $	��300��5�      $	��200��6   $��Right=�6*   $	��Top=�6F   $��10,70,20,20q�6^   z�5�      T� 5�      ._�5�      �� $��fotos/imagen.jpg��6   $
��Fill=�6.    J� RenderTransformOrigin$ 0.5,0.5&�6=   $��-2,-2,-2,-2q�6]   5�      5�      5�      