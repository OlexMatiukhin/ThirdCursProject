   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   &     Airport.Views.QueryWindow.Query6   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query6��5   	   $	��450��6   $	��868��6%   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ dataGrid��5>      $��2��6%   	   AutoGenerateColumns$	 False��62   $)��#pack://application:,,,/Fonts/#Inter)�6N   
   HeadersVisibility$
 Column=�5?         CanUserResizeColumns$ False��6-      CanUserReorderColumns$ False��6J   $
��Bold"�5@         
IsReadOnly$
 True��6$   $��10(�66   ��5A      �� *	Workers+   Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
WorkerId+6N     5D      $ ПІБ��6%   $
 0.5* 6O    62   �� *
FullName+6O     5E      $ Вік��6%   $ * 6J    62   �� *Age+6J     5F      $ Статус��6%   $ * 6P    65   �� *Status+6P     5G      $ 
Стать��6%   $ * 6O    64   �� *Gender+6O     5H      $ Діти��6%   $ * 6V    63   �� *NumberChildren+6V     5I      $ Дата старт��6%   $ * 6V    69   �� *
HireDate+6V     5J      $ 
Зміна��6%   $ * 6N    64   �� *Shift+6N     5K      $ Еmail��6%   $ * 6N    64   �� *Email+6N     5L      $ 
Номер��6%   $ * 6T    64   �� *PhoneNumber+6T     5M      $ Посада��6%   $ * 6V    65   �� *PositionName+6V     5N      $ Бригада��6%   $ * 6T    66   �� *	BrigadeId+6T   5X      �� 5Z   
   -   5         ��Name$ queryTypeComboBox��5[      $	��120��5\      $��30��5]      $��10,30,738,114q�5^       �� SelectedValuePath$ Content��5_      $��1��5`   S    �� SelectedValue 6   �� *SelectedQueryType+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5a      �� $��Перелік��6   �� 5b      $��Кількість��6   5c      �� 5e   
   -   5         ��Name$ minAgeTextBox��5e      $	��100��6)   $��25��65   $��164,74,604,73q�5f   Z   $��1��6q   ��6   �� *
MinAgeText+$ PropertyChanged=�6q   �� 5k   
   -   5        $ maxAgeTextBox��5k      $	��100��6)   $��25��65   $��285,73,483,73q�5l   \   $��1��6s   ��6   �� *
MaxAgeText+$ PropertyChanged=�6s   �� 5m   
   -   5        $ minSalaryTextBox��5m      $	��120��6,   $��25��68   $��410,73,338,73q�5n   ^   $��1��6u   ��6   �� *MinSalaryText+$ PropertyChanged=�6u   �� 5r   
   -   5        $ maxSalaryTextBox��5r      $	��120��6,   $��25��68   $��548,73,200,73q�5s   ^   $��1��6u   ��6   �� *MaxSalaryText+$ PropertyChanged=�6u   �� 5t   
   $��Виконати��6   $��95��6$   $��32��6/   $��705,70,68,69q�6;   $��1��6n   ��6R   �� *	DoQuery+6n   �� 5u   
   -   5        $( "minAgeTextBox_Копировать��5u      $	��100��64   $��25��6@   $��164,32,604,117q�5v   J   $��1��6b   ��6   �� *Gender+$ PropertyChanged=�6b   �� 5w   
   -   5        $) #minAgeTextBox_Копировать1��5w      $	��100��65   $��25��6A   $��285,32,483,117q�5x   L   $��1��6d   ��6   �� *
Position+$ PropertyChanged=�6d   5z      5{      