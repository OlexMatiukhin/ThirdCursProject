   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AirportAirport  5   	       Airport.TestWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Airport     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��860��6)   ���	#FF1EB7EE.��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $
��Left=�6   $��67��6+   $��7,0,0,5q�67   $
{�True��6H   $��Logo.png��6Y   $��Bottom=�6k   $��0��6�   $��22��6�   �� 5   
   $��	0,1,513,2q�6    �� Orientation$ 
Horizontal=�6(   $	��181��6A   $��Right=�6M   .+�5      ��  J� RenderTransformOrigin$ 3,2.348&�6   $��15��64   $��16��6@   $��/Key.png��6K   �� 5      $
��Wrap=�6   $)��#pack://application:,,,/Fonts/#Inter)�6,   $��16(�5      $
��Bold"�6   $��20��61   $	��156��6=   $��0,0,2,0q�6I   �� 6[   $�VovaShumchuchek��6_   �� 6x   �� 6�   �� 6�   �� 6�   6�   5      �� 5   
   -   5        $��	0,1,200,3q�5      $ 
Horizontal=�6(   $��Right=�6c   $	��310��6   .+�5      �� $��15��6   $��16��6!   $ 3,2.348&�6,   $��Position.png��6L   �� 5      $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�5      $��16(�5       $
��Bold"�6   $	��284��61   $B��<Начальник бригади рятувальників��6=   $��Center=�6d   $��0,0,2,0q�6   $��Right=�6�   5#      �� 5$   
   $��	775,1,0,2q�6   $ 
Horizontal=�6(   $
��Left=�6A   $��81��6\   .+�5%      �� $ 3,2.348&�6   $��
Logout.png��64   $��13��6I   �� 5&      $
��Wrap=�6   $��20��6,   $)��#pack://application:,,,/Fonts/#Inter)�5'   	   $��16(�5(   	   $
��Bold"�6   $��58��6)   $��0,0,2,0q�64   �� 6F    � Language$ ru-ru�6J   $�
Вийти��6[   �� 6j   �� 6v   $ ru-ru�6z   6�   5)      �� 5*   
   $��
677,4,92,5q�6   $ 
Horizontal=�6)   $��Right=�6B   5,      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ dataGrid��5-         AutoGenerateColumns$ False��6%   $)��#pack://application:,,,/Fonts/#Inter)�6A      HeadersVisibility$ Column=�5.         CanUserResizeColumns$ False��6(   	   CanUserReorderColumns$	 False��6E   $
��Bold"�5/      
   
IsReadOnly$

 True��6   $��9(�61   $��3,149,2,-130q�6k   $��1��6�      Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Name+6J     52      $ 
Номер��6%   $ 2* 6L    64   �� *Age+6L     53      $ Статус��6%   $ 2* 6O    65   �� *Name+6O     54      $ Категорія��6%   $ 2* 6Q    68   �� *Age+6Q     55      $ Дата відправ��6%   $ 2* 6U    6;   �� *Name+6U     56      $ Дата прибут��6%   $ 2* 6T    6:   �� *Age+6T     57      $ 
Літак��6%   $ 2* 6O    64   �� *Name+6O     58      $' !Диспетчер бригада��6%   $ 2* 6Z    6@   �� *Age+6Z     59      $) #Навігаційн бригада��6%   $ 2* 6[    6A   �� *Name+6[     5:      $ Льотн бригад��6%   $ 2* 6T    6;   �� *Age+6T     5;      $' !Бригада Інспектор��6%   $ 2* 6Y    6@   �� *Name+6Y     5<      $ Машрут��6%   $ 2* 6M    65   �� *Age+6M   4  .System.Windows.Controls.DataGridTemplateColumn  5=      $ Actions��6)   $ 2* 6:      CellTemplate 5>      �� 5?      .R�5@      �� -   5        $��Видалити��5@   %   $
��Auto��6M   5A      5C        5D      $ Видалення��6)   $ 2* 6<    5E      �� 5F      .R�5G      �� -   5        $��
Зміни��5G   %   $
��Auto��6J   5H      5J      5L      �� 5M   
   $��
0,4,99.5,5q�6   $ 
Horizontal=�6)   $��Right=�6B   $��93��6^   .+�5N      �� $��	/Main.png��6   $ 3,2.348&�6'   $��18��6G   $��16��6S   �� 5O      $��Головна��6   $
��Wrap=�6'   $��16(�6;   $
��Bold"�6I   $)��#pack://application:,,,/Fonts/#Inter)�6[   $ 0.955,0.627&�6�   $��19��6�   $��70��6�   $��0,0,2,0q�6�   5R      5U      5W      