   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Airport.Views.WindowsAirport.Views.Windows  5   	   %    Airport.Views.Windows.UsersView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Airport.Views.Windows     5   	     � Title$  	UsersView��5   	   $	��468��6   $	��860��6)   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $��76��6*   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��	0,1,513,2q�6    �� Orientation$ 
Horizontal=�6(   $	��181��6A   $��Right=�6M   .+�5      ��  J� RenderTransformOrigin$ 3,2.348&�6   $��15��64   $��16��6@   $��/Images/Key.png��6K   �� 5      $
��Wrap=�6   $)��#pack://application:,,,/Fonts/#Inter)�6,   $��16(�5      $
��Bold"�6   $��20��6,   $	��156��68   $��0,0,2,0q�6D   ��5      �� *Login+5      �� 5   
   $��	0,1,200,3q�6   $ 
Horizontal=�6(   $��Right=�6C   $	��310��6_   .+�5      �� $��15��6   $��16��6!   $ 3,2.348&�6,   $��/Images/Position.png��6L   �� 5      $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�68   $��16(�5      $
��Bold"�6   $	��284��6,   $��Center=�68   $��Right=�5       $��0,0,2,0q�6(   ��5!      �� *AccessRight+5#      �� 5%   
   $��
0,4,99.5,5q�6   $ 
Horizontal=�6)   $��Right=�6B   $��93��6^   .+�5&      �� $��/Images/Main.png��6   $ 3,2.348&�6.   $��18��6N   $��16��6Z   �� 5'      $��Головна��6   $
��Wrap=�6'   $��16(�6;   $
��Bold"�6I   $)��#pack://application:,,,/Fonts/#Inter)�6[   $ 0.955,0.627&�6�   $��19��6�   $��70��6�   $��0,0,2,0q�6�    J� InputBindings 5(      d� 5)       d� Gesture$ 	LeftClicka�6    �� Command 63   �� *OpenMainWindowCommand+5,      �� 5.   
   $��0,0,0,0q�6   $ 
Horizontal=�6&   $��Right=�6?   $��80��6[   .+�5/      �� $ 3,2.348&�6   $��/Images/Logout.png��64   $��13��6Q   $��15��6\   �� 50      $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�51      $��16(�52      $
��Bold"�6   $��58��6!   $��0,0,2,0q�6,   �� 6>    � Language$ ru-ru�6B   $�
Вийти��6S   �� 6b   �� 6n   $ ru-ru�6r   6�    53      d� 54      $ 	LeftClicka�6    63   �� *LogoutCommand+56      �� 57   
   $
��Left=�6   $��67��6+   $��7,0,0,5q�67   $
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5;   
   -   5          Name$ dataGrid��5;      $��2��6%   	   AutoGenerateColumns$	 False��62   $)��#pack://application:,,,/Fonts/#Inter)�6N   
   HeadersVisibility$
 Column=�5<         CanUserResizeColumns$ False��6.      CanUserReorderColumns$ False��6K   $
��Bold"�5=         
IsReadOnly$
 True��6%   $��10(�67   ��5>      �� *Users+   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логін��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Login+6N     5A      $ Пароль��6%   $ * 6R    65   �� *
Password+6R     5B      $ Права доступу��6%   $ * 6\    6<   �� *AccessRight+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5E      $ 
Зміни��6)   $ * 68      CellTemplate 5F      �� 5G      .R�5H      �� $��
Зміни��6�   ��6%   �� *#!DataContext.OpenEditWindowCommand+ �� RelativeSource ��  �� AncestorType"  ��6�   �� 5I      5K        5M      $ Видалення��6)   $ * 6<    5N      �� 5O      .R�5P      �� $��Видалити��6�   ��6%   �� *DataContext.DeleteUserCommand+ �� "  ��6�   �� 5Q      5S      5U      �� 5W   
   $)��#Додати користувача��6   $��3��6.   $	��860��6;   $��0,1,0,-1q�6s   ���	#FFFAE200$
��Bold"�6�   ��6J   �� *OpenAddWindowCommand+6�   �� 5Z   
   $��
10,25,10,0q�6   $��1��6&    �� TextWrapping$
 Wrap=�63   $	��Top=�6G   $	��418��6_   $	��924��6n   $��30��6}   ��6�   �� *
SearchLine+ �� UpdateSourceTrigger$ PropertyChanged=�5[      5\      