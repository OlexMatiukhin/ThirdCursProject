   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   &     Airport.Views.QueryWindow.Query4   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query4��5   	   $	��450��6   $	��868��6&   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $	��216��6*   �� 5      .+�5   
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ dataGrid��5=      	   AutoGenerateColumns$	 False��6%   $)��#pack://application:,,,/Fonts/#Inter)�6A   
   HeadersVisibility$
 Column=�5>      $��2��6.      CanUserResizeColumns$ False��6;      CanUserReorderColumns$ False��6X   $
��Bold"�5?         
IsReadOnly$
 True��6%   $��10(�67   $��-4,0,0,0q�6F   ��6X   �� *PassengersCompletedFlight+   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *PassengerId+6Q     5C      $ Льотн бригад��6%   $ 2* 6X    6;   �� *
FullName+6X     5D      $ 
Номер��6%   $ 2* 6L    64   �� *Age+6L     5E      $ Статус��6%   $ 2* 6P    65   �� *Gender+6P     5F      $ Категорія��6%   $ 2* 6[    68   �� *PassportNumber+6[     5G      $ Дата відправ��6%   $ 2* 6d    6;   �� *InternPassportNumber+6d     5H      $ Дата прибут��6%   $ 2* 6\    6:   �� *BaggageStatus+6\     5I      $ 
Літак��6%   $ 2* 6T    64   �� *PhoneNumber+6T     5J      $' !Диспетчер бригада��6%   $ 2* 6Z    6@   �� *Email+6Z     5K      $) #Навігаційн бригада��6%   $ 2* 6g    6A   �� *CompletedFlightId+6g   5M      �� 5S   
   -   5         ��Name$ queryTypeComboBox��5S      $	��120��6.   $��30��6:   $��300,62,448,124q�6F   $��1��5T   Y    �� SelectedValue 6   �� *SelectedQueryType+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5U      �� $��Перелік��6   �� 5V      $��Кількість��6   5W      �� 5Y   
   $
��Wrap=�6   $)��#pack://application:,,,/Fonts/#Inter)�6(   $��16(�5Z      $
��Bold"�6&   $��20��68   $	��156��6D   $��0,0,2,0q�6P   ��5[      �� *Login+(  "System.Windows.Controls.DatePicker  5]   
   -   5          Name$ startDateTextBox��5]      $	��150��6/   $��30��6;   $��470,62,248,124q�6G   $��1��5^   V      Text 6   �� *	StartDate+$ PropertyChanged=�6V     5a   
   -   5        $ endDateTextBox��5a      $	��150��6-   $��30��69   $��625,62,93,124q�6E   $��1��5b   T    6   �� *	EndDate+$ PropertyChanged=�6T   �� 5e   
   -   5        $ flightCategoryComboBox��5e      $��30��63   $��282,122,448,64q�6?   $��1��5f   d    �� SelectedItem 6   �� *FlightCategory+$ PropertyChanged=�.@�5g      �� $��міжнародний��6   �� 5h      $��внутрішній��6   5j      �� 5l   
   -   5        $ baggageStatusComboBox��5l      $	��150��62   $��30��6>   $��438,124,280,62q�6J   $��1��5m   c    6   �� *BaggageStatus+$ PropertyChanged=�.@�5n      �� $"��зареєстрований��6   �� 5o      $'��!не зареєстрований��6   5p      �� 5r   
   -   5        $ genderComboBox��5r      $	��100��6+   $��30��67   $��622,124,146,62q�6C   $��1��5s   \    6   �� *Gender+$ PropertyChanged=�.@�5t      �� $��чоловік��6   �� 5u      $��
жінка��6   5v      �� 5w   
   -   5         ��Name$ minAgeTextBox��5w      $��80��6)   $��30��64   $��748,122,40,64q�6@   $��1��5x   W   ��6   �� *
MinAgeText+$ PropertyChanged=�6W   �� 5z   
   $��Виконати��6   $��95��6$   $��32��6/   $��300,168,473,16q�6;   $��1��6p   ��6T   �� *	DoQuery+6p   5|      5}      