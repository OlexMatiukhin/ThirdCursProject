   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   &     Airport.Views.QueryWindow.Query7   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query6��5   	   $	��450��6   $	��868��6&   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $	��171��6*   �� 5      .+�5   
   �� $��	0,1,513,2q�6    �� Orientation$ 
Horizontal=�6(   $	��181��6A   $��Right=�6M   .+�5      ��  J� RenderTransformOrigin$ 3,2.348&�6   $��15��64   $��16��6@   $��/Images/Key.png��6K   �� 5      $
��Wrap=�6   $)��#pack://application:,,,/Fonts/#Inter)�6,   $��16(�5      $
��Bold"�6   $��20��6,   $	��156��68   $��0,0,2,0q�6D   ��5      �� *Login+5      �� 5   
   $��	0,1,200,3q�6   $ 
Horizontal=�6(   $��Right=�6C   $	��310��6_   .+�5       �� $��15��6   $��16��6!   $ 3,2.348&�6,   $��/Images/Position.png��6L   �� 5!      $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�68   $��16(�5"      $
��Bold"�6   $	��284��6,   $��Center=�68   $��Right=�5#      $��0,0,2,0q�6(   ��5$      �� *AccessRight+5&      �� 5(   
   $��
0,4,99.5,5q�6   $ 
Horizontal=�6)   $��Right=�6B   $��93��6^   .+�5)      �� $��/Images/Main.png��6   $ 3,2.348&�6.   $��18��6N   $��16��6Z   �� 5*      $��Головна��6   $
��Wrap=�6'   $��16(�6;   $
��Bold"�6I   $)��#pack://application:,,,/Fonts/#Inter)�6[   $ 0.955,0.627&�6�   $��19��6�   $��70��6�   $��0,0,2,0q�6�    J� InputBindings 5+      d� 5,       d� Gesture$ 	LeftClicka�6    �� Command 63   �� *OpenMainWindowCommand+5/      �� 51   
   $��0,0,0,0q�6   $ 
Horizontal=�6&   $��Right=�6?   $��80��6[   .+�52      �� $ 3,2.348&�6   $��/Images/Logout.png��64   $��13��6Q   $��15��6\   �� 53      $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�54      $��16(�55      $
��Bold"�6   $��58��6!   $��0,0,2,0q�6,   �� 6>    � Language$ ru-ru�6B   $�
Вийти��6S   �� 6b   �� 6n   $ ru-ru�6r   6�    56      d� 57      $ 	LeftClicka�6    63   �� *LogoutCommand+59      �� 5:   
   $
��Left=�6   $��67��6+   $��7,0,0,5q�67   $
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ dataGrid��5?      $��2��6%   	   AutoGenerateColumns$	 False��62   $)��#pack://application:,,,/Fonts/#Inter)�6N   
   HeadersVisibility$
 Column=�5@         CanUserResizeColumns$ False��6-      CanUserReorderColumns$ False��6J   $
��Bold"�5A         
IsReadOnly$
 True��6$   $��10(�66   $��Center=�5B   2   $��0,0,0,-5q�6O   $	��868��6a   ��6   �� *	Flights+   Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
FlightId+6O     5F      $ 
Номер��6%   $ 2* 6V    64   �� *FlightNumber+6V     5G      $ Статус��6%   $ 2* 6R    65   �� *Status+6R     5H      $ Категорія��6%   $ 2* 6W    68   �� *
Category+6W     5I      $ Дата відправ��6%   $ 2* 6_    6;   �� *DateDeparture+6_     5J      $ Дата прибут��6%   $ 2* 6]    6:   �� *DateArrival+6]     5K      $ 
Літак��6%   $ 2* 6W    64   �� *PlaneNumber+6W     5L      $' !Диспетчер бригада��6%   $ 2* 6i    6@   �� *DispatchBrigadeId+6i     5M      $) #Навігаційн бригада��6%   $ 2* 6k    6A   �� *NavigationBrigadeId+6k     5N      $ Льотн бригад��6%   $ 2* 6a    6;   �� *FlightBrigadeId+6a     5O      $' !Бригада Інспектор��6%   $ 2* 6i    6@   �� *InspectionBrigadeId+6i     5P      $ Машрут��6%   $ 2* 6Q    65   �� *	RouteId+6Q     5Q      $ Контроль��6%   $ 2* 6Z    67   �� *CustomsControl+6Z     5R      $ Реєстрація��6%   $ 2* 6c    69   �� *PassengerRegistration+6c     5S      $ Квитки��6%   $ 2* 6W    65   �� *NumberTickets+6W     5T      $ Куплені кв-и��6%   $ 2* 6c    6;   �� *NumberBoughtTickets+6c   5\      �� 5]   
   $ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��10q�6X   .+�5_      �� -   5         ��Name$ routeNumberTextBox��5_      $	��150��62   $��30��6>   $��5q�6J   ��5`      �� *RouteNumber+ �� UpdateSourceTrigger$ PropertyChanged=��� 5c      -   5        $ minDurationTextBox��5c      $	��150��62   $��30��6>   $��5q�6J   ��5d      �� *MinDurationHoursText+$ PropertyChanged=��� 5h      -   5        $ maxDurationTextBox��5h      $	��150��62   $��30��6>   $��5q�6J   ��5i      �� *MaxDurationHoursText+$ PropertyChanged=��� 5k      $��Виконати��6   $��95��6(   $��32��63   $��5q�6?   ��6K   �� *	DoQuery+5l      �� 5m   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��174,45,604,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�
Номер��6�   6�   �� 5n   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��302,45,434,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Мін тривалсть��6�   6�   �� 5o   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��473,45,263,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $!�Мак тривалість��6�   6�   5p      5q      