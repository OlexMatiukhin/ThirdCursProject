   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   (    "Airport.Views.QueryWindow.QueryOne   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  QueryOne��5   	   $	��450��6   $	��868��6'   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
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
Вийти��6S   �� 6b   �� 6n   $ ru-ru�6r   6�    56      d� 57      $ 	LeftClicka�6    63   �� *LogoutCommand+59      �� 5=      $
��Left=�6   $��67��6#   $��7,0,0,5q�6/   $
{�True��6@   $��/Images/Logo.png��6Q   $��Bottom=�6k   $��0��6�   $��22��6�   �� 5@   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��90,41,688,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Тип запиту��6�   6�   &   System.Windows.Controls.DataGrid  5B   
   -   5          Name$ dataGrid��5B      $��2��6%   	   AutoGenerateColumns$	 False��62   $)��#pack://application:,,,/Fonts/#Inter)�6N   
   HeadersVisibility$
 Column=�5C         CanUserResizeColumns$ False��6-      CanUserReorderColumns$ False��6J   $
��Bold"�5D         
IsReadOnly$
 True��6$   $��10(�66   $��Center=�5E   3   $��0,0,0,-5q�6P   $	��868��6b   ��6   �� *	Flights+   Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
FlightId+6O     5I      $ 
Номер��6%   $ 2* 6V    64   �� *FlightNumber+6V     5J      $ Статус��6%   $ 2* 6R    65   �� *Status+6R     5K      $ Категорія��6%   $ 2* 6W    68   �� *
Category+6W     5L      $ Дата відправ��6%   $ 2* 6_    6;   �� *DateDeparture+6_     5M      $ Дата прибут��6%   $ 2* 6]    6:   �� *DateArrival+6]     5N      $ 
Літак��6%   $ 2* 6W    64   �� *PlaneNumber+6W     5O      $' !Диспетчер бригада��6%   $ 2* 6i    6@   �� *DispatchBrigadeId+6i     5P      $) #Навігаційн бригада��6%   $ 2* 6k    6A   �� *NavigationBrigadeId+6k     5Q      $ Льотн бригад��6%   $ 2* 6a    6;   �� *FlightBrigadeId+6a     5R      $' !Бригада Інспектор��6%   $ 2* 6i    6@   �� *InspectionBrigadeId+6i     5S      $ Машрут��6%   $ 2* 6U    65   �� *RouteNumber+6U     5T      $ Контроль��6%   $ 2* 6Z    67   �� *CustomsControl+6Z     5U      $ Реєстрація��6%   $ 2* 6c    69   �� *PassengerRegistration+6c     5V      $ Квитки��6%   $ 2* 6W    65   �� *NumberTickets+6W     5W      $ Куплені кв-и��6%   $ 2* 6c    6;   �� *NumberBoughtTickets+6c   5b      �� 5c   
   $ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��10q�6X   .+�5e      �� -   5         ��Name$ queryTypeComboBox��5f      $	��120��5g      $��30��5h      $��5q�5i       �� SelectedValuePath$ Content��5j       �� SelectedValue 5k      �� *SelectedQueryType+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5l      �� $��Перелік��6   �� 5m      $��Кількість��6   5n      �� 5p      -   5         ��Name$ categoryTextBox��5p      $	��150��6/   $��30��6;   $��5q�6G   ��5q   
   �� *
Category+$ PropertyChanged=��� 5s      -   5        $ planeTypeTextBox��5s      $	��150��60   $��30��6<   $��5q�6H   ��5t   
   �� *	PlaneType+$ PropertyChanged=��� 5v      -   5        $ flightDirectionTextBox��5v      $	��150��66   $��30��6B   $��5q�6N   ��5w   
   �� *FlightDirection+$ PropertyChanged=��� 5x      $��Виконати��6   $��95��6(   $��32��63   $��5q�6?   ��6K   �� *	DoQuery+5y      �� 5z   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��235,45,543,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   6�   �� 5{   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��402,42,376,0q�6q   $��1��6�   �� 6�   $�Тип ��6�   �� 6�   $ uk-ua�6�   $�літака��6�   6�   �� 5|   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��565,41,213,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Напрям��6�   6�   �� 5}   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��245,42,533,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Категорія��6�   6�   5~      5      