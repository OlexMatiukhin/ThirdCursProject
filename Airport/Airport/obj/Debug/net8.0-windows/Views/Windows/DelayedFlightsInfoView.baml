   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirportAirport  5   	   $    Airport.DelayedFlightsInfoView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Airport     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��860��6)   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $	��149��6*   �� 5      .+�5   
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5;   
   -   5          Name$ dataGrid��5;   :   	   AutoGenerateColumns$	 False��6L   $)��#pack://application:,,,/Fonts/#Inter)�6h   
   HeadersVisibility$
 Column=�5<      $��2��6.      CanUserResizeColumns$ False��6;      CanUserReorderColumns$ False��6X   $
��Bold"�5=         
IsReadOnly$
 True��6%   $��10(�67   ��5;      �� *DelayedFlights+   Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *DelayedFlightInfoId+6Z     5@      $ 
Номер��6%   $ * 6V    64   �� *FlightNumber+6V     5A      $ Категорія��6%   $ * 6U    68   �� *
Category+6U     5B      $) #Диспетчерська бриг��6%   $ * 6g    6A   �� *DispatchBrigadeId+6g     5C      $% Навігаційна бриг��6%   $ * 6h    6?   �� *NavigationBrigadeId+6h     5D      $ Льотна бриг��6%   $ * 6_    6:   �� *FlightBrigadeId+6_     5E      $ Дата початку��6%   $ * 6_    6;   �� *StartDelayDate+6_     5F      $ Закінчення��6%   $ * 6[    69   �� *EndDelayDate+6[     5G      $) #Інспекторська бриг��6%   $ * 6j    6A   �� *InspectionBrigadeId+6j     5H      $ Рейс��6%   $ * 6Q    63   �� *
FlightId+6Q     5I      $ Маршрут��6%   $ * 6X    66   �� *RouteNumber+6X     5J      $ Працівник��6%   $ * 6V    68   �� *
WorkerId+6V     5K      $ Причина��6%   $ * 6R    66   �� *Reason+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5L      $ Видалення��6)   $ 2* 6<      CellTemplate 5M      �� 5N      .R�5O      �� $��Видалити��6%   $
��Auto��69   5P      5R        5S      $+ %Закінчення затримки��6)   $ 2* 6F    5T      �� 5U      .R�5V      �� $��Закінчити��6%   $
��Auto��5X   7   ��5V   9   �� * DataContext.FinishDelayCommand+ �� RelativeSource ��  �� AncestorType DataGrid��5X      �� 67   5Y      5[      5]      �� 5^   
   $��
10,25,20,0q�6   $��1��6&    �� TextWrapping$
 Wrap=�63   $	��Top=�6H   $	��418��6`   $	��924��6o   $��30��6~   ��6�   �� *
SearchLine+ �� UpdateSourceTrigger$ PropertyChanged=�5a      5c      