   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   '    !Airport.Views.QueryWindow.Query12   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query11��5   	   $	��450��6   $	��868��6&   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $	��171��6*   �� 5      .+�5   
   �� $��	0,1,513,2q�6    �� Orientation$ 
Horizontal=�6(   $	��181��6A   $��Right=�6M   .+�5      ��  J� RenderTransformOrigin$ 3,2.348&�6   $��15��64   $��16��6@   $��/Images/Key.png��6K   �� 5      $
��Wrap=�6   $)��#pack://application:,,,/Fonts/#Inter)�6,   $��16(�5      $
��Bold"�6   $��20��6,   $	��156��68   $��0,0,2,0q�6D   ��5      �� *Login+5      �� 5   
   $��	0,1,200,3q�6   $ 
Horizontal=�6(   $��Right=�6C   $	��310��6_   .+�5      �� $��15��6   $��16��6!   $ 3,2.348&�6,   $��/Images/Position.png��6L   �� 5       $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�68   $��16(�5!      $
��Bold"�6   $	��284��6,   $��Center=�68   $��Right=�5"      $��0,0,2,0q�6(   ��5#      �� *AccessRight+5%      �� 5'   
   $��
0,4,99.5,5q�6   $ 
Horizontal=�6)   $��Right=�6B   $��93��6^   .+�5(      �� $��/Images/Main.png��6   $ 3,2.348&�6.   $��18��6N   $��16��6Z   �� 5)      $��Головна��6   $
��Wrap=�6'   $��16(�6;   $
��Bold"�6I   $)��#pack://application:,,,/Fonts/#Inter)�6[   $ 0.955,0.627&�6�   $��19��6�   $��70��6�   $��0,0,2,0q�6�    J� InputBindings 5*      d� 5+       d� Gesture$ 	LeftClicka�6    �� Command 63   �� *OpenMainWindowCommand+5.      �� 50   
   $��0,0,0,0q�6   $ 
Horizontal=�6&   $��Right=�6?   $��80��6[   .+�51      �� $ 3,2.348&�6   $��/Images/Logout.png��64   $��13��6Q   $��15��6\   �� 52      $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�53      $��16(�54      $
��Bold"�6   $��58��6!   $��0,0,2,0q�6,   �� 6>    � Language$ ru-ru�6B   $�
Вийти��6S   �� 6b   �� 6n   $ ru-ru�6r   6�    55      d� 56      $ 	LeftClicka�6    63   �� *LogoutCommand+58      �� 59   
   $
��Left=�6   $��67��6+   $��7,0,0,5q�67   $
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ dataGrid��5=   <   	   AutoGenerateColumns$	 False��6N   $)��#pack://application:,,,/Fonts/#Inter)�6j   
   HeadersVisibility$
 Column=�5>      $��2��6.      CanUserResizeColumns$ False��6;      CanUserReorderColumns$ False��6X   $
��Bold"�5?         
IsReadOnly$
 True��6%   $��10(�67   $��-4,0,0,0q�6F   ��5=      �� *CanceledFlights+   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *CanceledFlightInfoId+6\     5B      $ 
Номер��6%   $
 0.5* 6W      FontSize$ 10Q�6d    64   �� *FlightNumber+6d     5C      $ Статус��6%   $ * 6R   $ 10Q�6\    65   �� *Status+6\     5D      $ Категорія��6%   $ * 6W   $ 10Q�6a    68   �� *
Category+6a     5E      $' !Диспетчер бригада��6%   $ * 6i   $ 10Q�6s    6@   �� *DispatchBrigadeId+6s     5F      $) #Навігаційн бригада��6%   $ * 6l    6A   �� *NavigationBrigadeId+6l     5G      $ Льотн бригад��6%   $ * 6a    6;   �� *FlightBrigadeId+6a     5H      $- 'Інспекторська бригад��6%   $ * 6o    6C   �� *InspectionBrigadeId+6o     5I      $# Незайняті місця��6%   $ * 6i    6>   �� *UnoccupiedSeatNumber+6i     5J      $ 
Місця��6%   $ * 6S    64   �� *
SeatNumber+6S     5K      $ Машрут��6%   $ * 6V    65   �� *RouteNumber+6V     5L      $ Працівник��6%   $ * 6W    68   �� *
WorkerId+6W     5M      $ Причина��6%   $ * 6Q   $ 10Q�6[    66   �� *Reason+6[   5P      �� 5Q   
   $"��Номер маршруту:��6   $��16(�6+   $
��Bold"�69   $	��150��6K   $	��Top=�6W   $ -0.593,1.442&�6o   $��90,10,628,0q�6�   $��1��6�   �� 5R   
   -   5         ��Name$ RouteNumberInput��5R      $	��200��6,   $��30��68   $��65,44,603,97q�6�   $��14(�6�   $��1��6�   ��6E   �� *RouteNumber+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5S   
   $$��Незайняті місця:��6   $��16(�6,   $
��Bold"�6:   $	��150��6L   $	��Top=�6X   $��339,13,379,0q�6p   $��1��6�   �� 5T   
   -   5        $ UnoccupiedSeatNumberInput��5T      $	��200��65   $��30��6�   $��310,43,358,98q�6�   $��14(�6�   $��1��6�   ��6A   �� *UnoccupiedSeatNumberText+$ PropertyChanged=�6�   �� 5U   
   $"��Напрямок рейсу:��6   $��16(�6,   $
��Bold"�6:   $	��150��6L   $	��Top=�6X   $��565,10,153,0q�6p   $��1��6�   �� 5V   
   -   5        $ FlightDirectionInput��5V      $	��200��60   $��30��6<   $��540,43,128,98q�6H   $��14(�6�   $��1��6�   ��6_   �� *FlightDirection+$ PropertyChanged=�6�   �� 5W   
   $��Виконати��6   $��95��6$   $��32��6/   $��751,41,22,98q�6;   $��1��6n   ��6R   �� *	DoQuery+6n   5Y      5Z      