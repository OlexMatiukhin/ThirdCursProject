   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirportAirport  5   	   "    Airport.CompletedFlightsView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Airport     5   	     � Title$  completedFlightsView��5   	   $	��450��6&   $	��868��63   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ dataGrid��5=   <   	   AutoGenerateColumns$	 False��6N   $)��#pack://application:,,,/Fonts/#Inter)�6j   
   HeadersVisibility$
 Column=�5>      $��2��6.      CanUserResizeColumns$ False��6;      CanUserReorderColumns$ False��6X   $
��Bold"�5?         
IsReadOnly$
 True��6%   $��10(�67   $��-4,0,0,0q�6F   ��5=      �� *CompletedFlights+   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *CompletedFlightId+6W     5B      $ 
Номер��6%   $ 2* 6U    64   �� *FlightNumber+6U     5C      $ Статус��6%   $ 2* 6Q    65   �� *Status+6Q     5D      $ Категорія��6%   $ 2* 6V    68   �� *
Category+6V     5E      $ Дата відправ��6%   $ 2* 6b    6;   �� *DispatchBrigadeId+6b     5F      $ Дата прибут��6%   $ 2* 6c    6:   �� *NavigationBrigdeId+6c     5G      $ 
Літак��6%   $ 2* 6X    64   �� *DateDeparture+6X     5H      $' !Диспетчер бригада��6%   $ 2* 6c    6@   �� *DateArrivial+6c     5I      $) #Навігаційн бригада��6%   $ 2* 6f    6A   �� *FlightBrigadeId+6f     5J      $ Льотн бригад��6%   $ 2* 6d    6;   �� *InspectionBrigadeId+6d     5K      $' !Бригада Інспектор��6%   $ 2* 6`    6@   �� *RouteNumber+6`   4  .System.Windows.Controls.DataGridTemplateColumn  5M      $ Редагування��6-   $ 2* 6B      CellTemplate 5N      �� 5O      .R�5P      �� $��Видалити��6%   $
��Auto��6�   ��69   �� *!DataContext.DeleteWindowCommand+ �� RelativeSource ��  �� AncestorType DataGrid6�   5Q      5S      5U      �� 5W   
   $��
10,25,10,0q�6   $��1��6&    �� TextWrapping$
 Wrap=�63   $	��Top=�6H   $	��418��6`   $	��924��6o   $��30��6~   ��6�   �� *
SearchLine+ �� UpdateSourceTrigger$ PropertyChanged=�5Z      5\      