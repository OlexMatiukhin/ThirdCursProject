   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Airport.Views.QueryWindowAirport.Views.QueryWindow  5   	   &     Airport.Views.QueryWindow.Query5   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Airport.Views.QueryWindow     5   	     � Title$  Query5��5   	   $	��450��6   $	��868��6%   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ dataGrid��5>   :   	   AutoGenerateColumns$	 False��6L   $)��#pack://application:,,,/Fonts/#Inter)�6h   
   HeadersVisibility$
 Column=�5?      $��2��6'      CanUserResizeColumns$ False��64      CanUserReorderColumns$ False��6Q   $
��Bold"�5@         
IsReadOnly$
 True��6   $��10(�60   $��-4,0,0,0q�6?   ��5>      �� *PilotMedExams+   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ExamId+6M     5C      $ Результат��6%   $ 2* 6T    68   �� *Result+6T     5D      $ Дата��6%   $ 2* 6Y    63   �� *DateExamination+6Y     5E      $ 
Пілот��6%   $ 2* 6R    64   �� *	PilotId+6R     5F      $ Доктор��6%   $ 2* 6T    65   �� *
DoctorId+6T   5K      �� 5P   
   -   5         ��Name$ queryTypeComboBox��5Q      $	��120��5R      $��30��5S      $��144,61,604,125q�5T       �� SelectedValuePath$ Content��5U      $��1��5V   S    �� SelectedValue 6   �� *SelectedQueryType+ �� UpdateSourceTrigger$ PropertyChanged=�.@�5W      �� $��Перелік��6   �� 5X      $��Кількість��6   5Y      (  "System.Windows.Controls.DatePicker  5\   
   $	��150��6   $��30��6!   $��325,65,393,121q�6-   $��1��6�      SelectedDate 6E   �� *	StartDate+$ PropertyChanged=�6�     5]   
   $	��150��6   $��30��6!   $��505,63,213,123q�6-   $��1��6�    6E   �� *	EndDate+$ PropertyChanged=�6�   �� 5`   
   $��Виконати��6   $��95��6$   $��32��6/   $��676,61,97,123q�6;   $��1��6o   ��6S   �� *	DoQuery+6o   �� 5a   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��174,35,604,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Тип��6�   6�   �� 5b   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��344,39,434,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Дата почат��6�   6�   �� 5c   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��344,39,434,0q�6q   $��1��6�   �� 6�   $ uk-ua�6�   $�Дата почат��6�   6�   �� 5d   
   $��16(�6   $
��Bold"�6"   $	��Top=�64   $ -0.593,1.442&�6L   $��535,39,243,0q�6q   $��1��6�   �� 6�   $�	Дата ��6�   �� 6�   $ uk-ua�6�   $�кінц��6�   6�   5f      5g      