   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   '    !Airport.Views.QueryWindow.Query13   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query12��5   	   $	��450��6   $	��868��6&   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
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
   -   5          Name$ dataGrid��5=   :   	   AutoGenerateColumns$	 False��6L   $)��#pack://application:,,,/Fonts/#Inter)�6h   
   HeadersVisibility$
 Column=�5>      $��2��6.      CanUserResizeColumns$ False��6;      CanUserReorderColumns$ False��6X   $
��Bold"�5?         
IsReadOnly$
 True��6%   $��10(�67   ��5=      �� *DelayedFlights+   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *DelayedFlightInfoId+6Z     5B      $ 
Номер��6%   $ * 6V    64   �� *FlightNumber+6V     5C      $ Категорія��6%   $ * 6U    68   �� *
Category+6U     5D      $) #Диспетчерська бриг��6%   $ * 6g    6A   �� *DispatchBrigadeId+6g     5E      $% Навігаційна бриг��6%   $ * 6h    6?   �� *NavigationBrigadeId+6h     5F      $ Льотна бриг��6%   $ * 6_    6:   �� *FlightBrigadeId+6_     5G      $ Дата початку��6%   $ * 6_    6;   �� *StartDelayDate+6_     5H      $ Закінчення��6%   $ * 6[    69   �� *EndDelayDate+6[     5I      $) #Інспекторська бриг��6%   $ * 6j    6A   �� *InspectionBrigadeId+6j     5J      $ Рейс��6%   $ * 6Q    63   �� *
FlightId+6Q     5K      $ Маршрут��6%   $ * 6X    66   �� *RouteNumber+6X     5L      $ Працівник��6%   $ * 6V    68   �� *
WorkerId+6V     5M      $ Причина��6%   $ * 6R    66   �� *Reason+6R   5P      �� 5Q   
   $&�� Причина затримки:��6   $��16(�6-   $
��Bold"�6;   $	��150��6M   $	��Top=�6Y   $��90,10,628,0q�6q   $��1��6�   �� 5R   
   -   5         ��Name$ ReasonInput��5R      $	��200��6'   $��30��63   $��65,44,603,97q�6|   $��14(�6�   $��1��6�   ��6?   �� *Reason+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5T   
   $"��Номер маршруту:��6   $��16(�6+   $
��Bold"�69   $	��150��6K   $	��Top=�6W   $��295,10,423,0q�6o   $��1��6�   �� 5U   
   -   5        $ RouteNumberInput��5U      $	��200��6,   $��30��68   $��280,44,388,97q�6�   $��14(�6�   $��1��6�   ��6D   �� *RouteNumber+$ PropertyChanged=�6�   �� 5V   
   $��Виконати��6   $��95��6$   $��32��6/   $��751,41,22,98q�6;   $��1��6n   ��6R   �� *	DoQuery+6n   5X      5Y      