   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirportAirport  5   	       Airport.FlightsView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Airport     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$#  completedFlightPassengersView��5	   	   $	��450��6/   $	��868��6<   ���	#FF1EB7EE.��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $��76��6*   �� 5      �� 5      $
��Auto �6   .+�5   
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ dataGrid��5>      $��2��6%   	   AutoGenerateColumns$	 False��62   $)��#pack://application:,,,/Fonts/#Inter)�6N   
   HeadersVisibility$
 Column=�5?         CanUserResizeColumns$ False��6-      CanUserReorderColumns$ False��6J   $
��Bold"�5@         
IsReadOnly$
 True��6$   $��10(�66   $��Center=�5A   g   $��0,0,0,18q�6�   $��2��6�   ��6   �� *	Flights+ �� SelectedItem 62   �� *SelectedFlight+ �� Mode$ TwoWay=�   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
FlightId+6O     5E      $ 
Номер��6%   $ 2* 6V    64   �� *FlightNumber+6V     5F      $ Статус��6%   $ 2* 6R    65   �� *Status+6R     5G      $ Категорія��6%   $ 2* 6W    68   �� *
Category+6W     5H      $ Дата відправ��6%   $ 2* 6_    6;   �� *DateDeparture+6_     5I      $ Дата прибут��6%   $ 2* 6]    6:   �� *DateArrival+6]     5J      $ 
Літак��6%   $ 2* 6W    64   �� *PlaneNumber+6W     5K      $' !Диспетчер бригада��6%   $ 2* 6i    6@   �� *DispatchBrigadeId+6i     5L      $) #Навігаційн бригада��6%   $ 2* 6k    6A   �� *NavigationBrigadeId+6k     5M      $ Льотн бригад��6%   $ 2* 6a    6;   �� *FlightBrigadeId+6a     5N      $' !Бригада Інспектор��6%   $ 2* 6i    6@   �� *InspectionBrigadeId+6i     5O      $ Машрут��6%   $ 2* 6U    65   �� *RouteNumber+6U     5P      $ Контроль��6%   $ 2* 6Z    67   �� *CustomsControl+6Z     5Q      $ Реєстрація��6%   $ 2* 6c    69   �� *PassengerRegistration+6c     5R      $ Квитки��6%   $ 2* 6W    65   �� *NumberTickets+6W     5S      $ Куплені кв-и��6%   $ 2* 6c    6;   �� *NumberBoughtTickets+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5V      $ Редагування��6)   $ 2* 6>      CellTemplate 5W      �� 5X      .R�5Y      �� $��Змінити��6%   $
��Auto��68   ��6F   �� *#!DataContext.OpenEditWindowCommand+ �� RelativeSource ��  �� AncestorType DataGrid��5[      �� 5\      5^        5a      $# Активація рейсу��6)   $ 2* 6B    5b      �� 5c      .R�5d      �� $#��Активувати рейс��6%   $
��Auto��5f   .   ��5d   ?   �� *#!DataContext.ActivateFlightCommand+ ��  DataGrid��5f      �� 6.   5g      5i        5l      $% Завершення рейсу��6)   $ 2* 6C    5m      �� 5n      .R�5o      �� $!��Завершити рейс��6%   $
��Auto��5q   +   ��5o   >   �� *!DataContext.FinishFlightCommand+ ��  DataGrid��5q      �� 6+   5r      5t        5w      $ Затримання��6)   $ 2* 6=    5x      �� 5y      .R�5z      �� $��Затримати��6%   $
��Auto��5{   e   ��5z   9   �� * DataContext.DelayFlightCommand+ ��  DataGrid��5{   H   �� 6e   5|      5~        5�      $ Скасування��6)   $ 2* 6=    5�      �� 5�      .R�5�      �� $��Скасувати��6%   $
��Auto��5�   ,   ��5�   9   �� *!DataContext.CancelFlightCommand+ ��  DataGrid��5�      �� 6,   5�      5�        5�      $! Митний контрол��6)   $ 2* 6B    5�      �� 5�      .R�5�      �� $��Завершити��6%   $
��Auto��5�   +   ��5�   9   �� *&$DataContext.EndCustomsControlCommand+ ��  DataGrid��5�      �� 6+   5�      5�        5�      $- 'Реєстрація пасажирів��6)   $ 2* 6G    5�      �� 5�      .R�5�      �� $��Завершити��6%   $
��Auto��5�   +   ��5�   :   �� *.,DataContext.EndRegistrationPassengersCommand+ ��  DataGrid��5�      �� 6+   5�      5�      5�      �� 5�   
   $��Додавання��6   $��3��6%   $	��860��62   $��0,1,0,-1q�6j   ���	#FFFAE200$
��Bold"�6�   ��6A   �� *OpenAddWindowCommand+6�   �� 5�   
   $��
10,25,10,0q�6   $��1��6&   $��Stretch=�63    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6f   $��30��6~   ��6�   �� *
SearchLine+ �� UpdateSourceTrigger$ PropertyChanged=�5�      5�      