   M S B A M L   `   `   `  ����  Hackaton    Hackaton.Window3   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$
  HARD��5   	   $	��450��6   $	��800��6#    � WindowState$ 	Maximized=�6/    � Icon$ fotos/imagen.jpg��5   	    � 	Resources 5         SlideInStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%�   &	        �� 5   
   .��5	      W� $ ImageBorder��5
      $8 2(UIElement.RenderTransform).(TranslateTransform.X)�5       2005       05      $ 0:0:1D�5      5      5      ��5      �� 5   
   	 �� ImageSource$	 fotos/dificultad3.png��6   
 j� Stretch$
 UniformToFill=�69   .��5      � .+�5   
   �� 
������� J� Opacity$	 0.9Q�6$    �� CornerRadius$ 10��62    �� Padding$ 20q�6D   $��Center=�6Q   $��Center=�6n   ._�5      �� -   5         ��Name$ AnswerStackPanel��5      .+�5      �� -   5        $��QuestionCont��5      $��20(�60    �� TextAlignment$ Center=�6>   
���**��$��0,0,0,20q�6h   �� 5      -   5        $��QuestionText��5      $��24(�60   $ Center=�6>   
���   �$��0,0,0,20q�6h   �� 5      -   5        $��AnswerButton1��5      $
��0,10q�6C   
�������6Q   �� 5      -   5        $��AnswerButton2��5      $
��0,10q�6C   
�������6Q   �� 5      -   5        $��AnswerButton3��5      $
��0,10q�6C   
�������6Q   �� 5      -   5        $��AnswerButton4��5      $
��0,10q�6C   
�������6Q   �� 5      -   5        $��
ResultText��5      $��18(�6.   $ Center=�6<   
���   �$y�	Collapsed=�6f   $��
10,20,10,0q�6}   �� 5       -	   5        $��textoContador��5       $��18(�61   $ Center=�6?   
���   �$y�	Collapsed=�6i   $��
10,20,10,0q�6�   �� 5!      
�������$��20��60   $	��300��6<   $ 5��6H   $��	0,20,0,20q�6Y   ._�5"      �� -
   5         ��Name$ ScoreBar��5"       
��� � �$��20��6?   $��0��6K   5#      5$      5%      �� 5'   
   
����·�$ 15��6+   
����  �$��2q�6T   $ 10q�6h   $��Right=�5(      $��Bottom=�6-   $��20q�6H   ._�5)      �� -   5        $��SiguientePreg��5)      $��Next Question��6*   $	��200��5*      $��50��5+      $��16(�5,      $
��Bold"�5-      
�������
����·�
����  �$��0q�51      52      53      �� 55   
   -   5         ��Name$ ImageBorder��55      
�������$ 15��6=   
����  �$��2q�6f   $ 10q�6z   $	��300��56      $	��200��6   $
��Left=�6*   $	��Top=�6E   $��	10,70,0,0q�6]   z�57      T� 58      ._�5:      �� $��fotos/imagen.jpg��6   $
��Fill=�6.    J� RenderTransformOrigin$ 0.5,0.5&�6=   $��-2,-2,-2,-2q�6]   5;      5<       � Triggers 5>      :� 5?   
    :� RoutedEvent$ Window.Loaded��6   .[�5@      �� #��[  6   5A      5C      