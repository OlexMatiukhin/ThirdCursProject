   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   &     Airport.Views.QueryWindow.Query2   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query2��5   	   $	��450��6   $	��800��6%   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $	��136��6*   �� 5      �� 5      $
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
 Column=�5?         CanUserResizeColumns$ False��6'      CanUserReorderColumns$ False��6D   $
��Bold"�5@         
IsReadOnly$
 True��6   $��10(�60   ��5A      �� *Seats+   Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *SeatId+6M     5D      $ 
Номер��6%   $ 2* 6P    64   �� *Number+6P     5E      $ Статус��6%   $ 2* 6R    65   �� *Status+6R     5F      $ Рейс��6%   $ 2* 6R    63   �� *
FlightId+6R   5H      �� 5I   
   -   5         ��Name$ queryTypeComboBox��5J      $	��120��5K      $��30��5L      $��10,24,670,82q�5M       �� SelectedValuePath$ Content��5N      $��1��5O   U    �� SelectedValue 6   �� *SelectedQueryType+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5P      �� $��Перелік��6   �� 5Q      $��Кількість��6   5R      �� 5S   
   $��140,25,510,81q�6   $��1��6C   ��6)   �� *
FlightId+6C   �� 5T   
   $	��150��6   $��30��6   $��350,25,300,81q�6G   $��1��6^   ��6*   �� *RouteNumber+6^   (  "System.Windows.Controls.DatePicker  5U   
   $	��150��6   $��30��6!   $��550,25,100,81q�6T   $��1��6k      SelectedDate 6-   �� *DepartureDate+6k   �� 5V   
   $	��150��6   $��30��6   $��140,83,510,23q�6E   $��1��6\   ��6*   �� *	PriceText+6\   �� 5W   
   $	��150��6   $��30��6   $��310,81,340,25q�6M   $��1��6d   ��6*   �� *DepartureHourText+6d   �� 5X   
   $	��150��6   $��30��6   $��500,81,150,25q�6O   $��1��6f   ��6*   �� *DepartureMinuteText+6f   �� 5Y   
   $��Виконати��6   $��95��6$   $��32��6/   $��665,81,40,23q�6;   $��1��6n   ��6R   �� *	DoQuery+6n   5\      5]      