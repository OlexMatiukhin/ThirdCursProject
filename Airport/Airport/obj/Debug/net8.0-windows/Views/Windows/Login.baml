   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Airport.ViewsAirport.Views  5   	       Airport.Views.LoginView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Airport.Views     5   	     � Title$  Registration��5   	   $	��450��6   $	��800��6+   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF1EB7EE��6    � Offset$ 0Q�6-   � 5      $ 	#FFECE8E8��6   $ 1Q�6-   5      .��5      � $��0,4,0,-4q�6   .+�5   
   �� $��Center=�6   $	��184��6-   $
{�True��6;   $��/Images/Logo.png��6L   $	��Top=�6f   $��0��6~   $��70��6�   $��0,14,0,0q�6�   �� 5   
   $��Center=�6   $��	0,148,0,0q�62    �� TextWrapping$
 Wrap=�6E   $	��Top=�6�   $	��296��6�   $��30��6�   $��Stretch=�6�   $��Stretch=�6�   $��22(�6  ��6Y   �� *Login+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5      $��Center=�6   $��	0,242,0,0q�6*   $
 Wrap=�6=   $	��Top=�6�   $	��296��6�   $��30��6�   $��Stretch=�6�   $��Stretch=�6�   $��22(�6  ��6Q   �� *
Password+$ TwoWay=�$ PropertyChanged=�6  �� 5   
   $��Center=�6   $��	0,119,0,0q�61   $
��Wrap=�6D   $��
Логін��6X   $	��Top=�6e   $��20(�6}   $
��Bold"�6�   �� 5   
   $��Center=�6   $��0,0,0,0q�61   $
��Wrap=�6B   $��Пароль��6V   $��Center=�6d   $��20(�6   $
��Bold"�6�   �� 5   
   $��Увійти��6   $��Center=�6"   $��	0,320,0,0q�6`   $	��Top=�6s   $��30��6�   $	��295��6�   ���	#FFFAF100$
��Bold"�6�   $��16(�6�   ��6?   �� *LoginCommand+6�   �� 5   
   $��	0,371,0,0q�6   $��Center=�6'   $
��Wrap=�6D   $	��Top=�5      $��14(�6$   $
��Bold"�62   $��19��6D    �� TextAlignment$ Center=�5      �� 5      	 � Language$	 uk-ua�6   $�Забули пароль��6#   
 J� InputBindings
 5      d� 5       d� Gesture$ 	LeftClicka�6    �� Command 63   �� *ForgotPasswordCommand+5      5!      5"      