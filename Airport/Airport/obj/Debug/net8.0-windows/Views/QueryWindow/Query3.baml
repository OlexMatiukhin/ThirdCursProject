   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   &     Airport.Views.QueryWindow.Query3   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query��5   	   $	��450��6   $	��868��6(   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5<   
   -   5          Name$ dataGrid��5<      $��2��6%   	   AutoGenerateColumns$	 False��62   $)��#pack://application:,,,/Fonts/#Inter)�6N   
   HeadersVisibility$
 Column=�5=         CanUserResizeColumns$ False��6)      CanUserReorderColumns$ False��6F   $
��Bold"�5>         
IsReadOnly$
 True��6    $��10(�62   $��Center=�5?   c   $��0,0,0,-5q�6�   $	��868��6�   ��6   �� *	Flights+ �� SelectedItem 6.   �� *SelectedFlight+ �� Mode$ TwoWay=�   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	PlaneId+6M     5C      $ Тип��6%   $ * 6K    62   �� *Type+6K     5D      $! Технічний стан��6%   $ 2* 6`    6=   �� *TechCondition+6`     5E      $  Заправленість��6%   $ 2* 6a    6<   �� *PlaneFuelStatus+6a     5F      $, &Готовність інтер'єру��6%   $ 2* 6j    6C   �� *InteriorReadiness+6j     5G      $* $Польотів до ремонту��6%   $ 2* 6q    6B   �� *NumberFlightsBeforeRepair+6q     5H      $! Дата техогляду��6%   $ 2* 6f    6=   �� *TechInspectionDate+6f     5I      $ Приписка��6%   $ 2* 6V    67   �� *
Assigned+6V     5J      $' !Кілкість ремонтів��6%   $ 2* 6d    6@   �� *NumberRepairs+6d     5K      $+ %Початок використаня��6%   $ 2* 6i    6B   �� *ExploitationDate+6i   5Q      �� 5R   
   $ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��10q�6X   .+�5T      �� -   5         ��Name$ queryTypeComboBox��5U      $	��120��5V      $��30��5W      $��5q�5X       �� SelectedValuePath$ Content��5Y       �� SelectedValue 5Z      �� *SelectedQueryType+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5[      �� $��Перелік��6   �� 5\      $��Кількість��6   5]      �� 5_      -   5         ��Name$ startDateTextBox��5_      $	��150��60   $��30��6<   $��5q�6H   ��5`      �� *	StartDate+$ PropertyChanged=��� 5a      -   5        $ endDateTextBox��5a      $	��150��6.   $��30��6:   $��5q�6F   ��5b      �� *	EndDate+$ PropertyChanged=��� 5e      -   5        $ assignedTextBox��5e      $	��150��6/   $��30��6;   $��5q�6G   ��5f      �� *
Assigned+$ PropertyChanged=�6M   �� 5g      -   5        $ statusTextBox��5g      $	��150��6-   $��30��69   $��5q�6E   ��5h      �� *Status+$ PropertyChanged=��� 5j      $��Виконати��6   $��95��6(   $��32��63   $��5q�6?   ��6K   �� *	DoQuery+5k      �� 5l   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��160,40,618,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Дата почат��6�   6�   �� 5m   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��325,44,453,0q�6q   $��1��6�   �� 6�   $�Дата��6�   �� 6�   $ uk-ua�6�   $� кінця��6�   6�   �� 5n   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��325,44,453,0q�6q   $��1��6�   �� 6�   $�Дата��6�   �� 6�   $ uk-ua�6�   $� кінця��6�   6�   �� 5o   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��468,44,310,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Приписка��6�   6�   �� 5p   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��632,44,146,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Статус��6�   6�   5q      5r      