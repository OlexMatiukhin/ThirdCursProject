   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirportAirport  5   	       Airport.PlanesView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Airport     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��860��6)   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $��76��6*   �� 5      �� 5      $
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
{�True��6H   $��/Images/Logo.png��6Y   $��Bottom=�6s   $��0��6�   $��22��6�   &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ dataGrid��5?      $��2��6%   	   AutoGenerateColumns$	 False��62   $)��#pack://application:,,,/Fonts/#Inter)�6N   
   HeadersVisibility$
 Column=�5@         CanUserResizeColumns$ False��6*      CanUserReorderColumns$ False��6G   $
��Bold"�5A         
IsReadOnly$
 True��6!   $��10(�63   ��5B   
   �� *Planes+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	PlaneId+6N     5E      $ 
Номре��6%   $ * 6U    64   �� *PlaneNumber+6U     5F      $ Тип��6%   $ * 6L    62   �� *Type+6L     5G      $! Технічний стан��6%   $ 2* 6a    6=   �� *TechCondition+6a     5H      $  Заправленість��6%   $ 2* 6c    6<   �� *PlaneFuelStatus+6c     5I      $' !Готовність салону��6%   $ 2* 6h    6@   �� *InteriorReadiness+6h     5J      $* $Польотів до ремонту��6%   $ 2* 6r    6B   �� *NumberFlightsBeforeRepair+6r     5K      $! Дата техогляду��6%   $ 2* 6g    6=   �� *TechInspectionDate+6g     5L      $ Приписка��6%   $ 2* 6W    67   �� *
Assigned+6W     5M      $' !Кілкість ремонтів��6%   $ 2* 6d    6@   �� *NumberRepairs+6d     5N      $+ %Початок використаня��6%   $ 2* 6i    6B   �� *ExploitationDate+6i   4  .System.Windows.Controls.DataGridTemplateColumn  5O      $ Заправка��6)   $ * 6;      CellTemplate 5P      �� 5Q      .R�5R      �� $��Заправка��6%   $
��Auto��6�   ��68   �� *%#DataContext.ChangeFuelStatusCommand+ �� RelativeSource ��  �� AncestorType DataGrid��6�   �� 6�   5S      5U        5W      $ 
Зміна��6)   $ * 68    5X      �� 5Y      .R�5Z      �� $��
Салон��6%   $
��Auto��6�   ��66   �� *$"DataContext.ChangeInteriorReadines+ ��  DataGrid��6�   �� 6�   5[      5]        5_      $ 
Зміна��6)   $ * 68    5`      �� 5a      .R�5b      �� $��Техперевірка��6%   $
��Auto��6�   ��6<   �� *'%DataContext.ChangeTechConditionStatus+ ��  DataGrid��6�   �� 6�   5c      5e        5h      $ 
Зміна��6)   $ * 68    5i      �� 5j      .R�5k      �� $��Редагувати��6%   $
��Auto��6�   ��6:   �� *#!DataContext.OpenEditWindowCommand+ ��  DataGrid��6�   �� 6�   5l      5n        5p      $ 
зміна��6)   $ * 68    5q      �� 5r      .R�5s      �� $��Видалити��6%   $
��Auto��5t   _   ��5s   8   �� *!DataContext.DeleteWindowCommand+ ��  DataGrid��5t   B   �� 6_   5u      5w      5y      �� 5{   
   $��Додавання��6   $��3��6%   $	��860��62   ���	#FFFAE200$
��Bold"�6�   $��0,1,0,-1q�6�   ��6A   �� *OpenAddWindowCommand+6�   �� 5|   
   $��
10,25,10,0q�6   $��1��6&    �� TextWrapping$
 Wrap=�63   $	��Top=�6H   $	��418��6`   $	��924��6o   $��30��6~   ��6�   �� *
SearchLine+ �� UpdateSourceTrigger$ PropertyChanged=�5}      5      