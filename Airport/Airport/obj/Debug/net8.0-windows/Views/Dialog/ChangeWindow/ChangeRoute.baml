   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Airport.Views.DialogAirport.Views.Dialog  5      &     Airport.Views.Dialog.ChangeRoute   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Airport.Views.Dialog     5        � Title$  ChangePlane��5	      .��5      � .+�5   
   �� $��Змінити��6   $
��Left=�6K   $��340,109,0,0q�6f   $	��Top=�6{   $	��140��6�   ��6$   �� *ChangeRouteCommand+6�   �� 5   
   $
��Left=�6   $��	95,43,0,0q�6/   $
��Wrap=�6B   $)��#pack://application:,,,/Fonts/#Inter)�6V   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�    � Language$ ru-ru�6�   $�
Номер��6�   6�   �� 5   
   -   5         ��Name$( "FlightNumber_Копировать3��5      $
��Left=�5      $��	60,64,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *Number+ �� Mode$ TwoWay=�5      �� 5   
   $
��Left=�6   $��
211,43,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.06Q�6&   T� 5      5      �� 5   *   $�Пункт в��6.   �� 6?   $ uk-ua�6C   $�і��6T   �� 6_   $�дправлення��6c   6x   �� 5   
   -   5        $' !FlightNumber_Копировать��5      $
��Left=�5      $��
210,64,0,0q�5       $	��Top=�5!      $	��120��5"      ��5      �� *DeparturePoint+$ TwoWay=�5"      �� 5#   
   $
��Left=�6   $��
362,43,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $!�Пункт прибуття��6�   6�   �� 5$   
   -   5        $( "FlightNumber_Копировать1��5$      $
��Left=�5&      $��
348,64,0,0q�5'      $	��Top=�5(      $	��120��5)      ��5%      �� *ArrivalPoint+$ TwoWay=�5)      �� 5*   
   $
��Left=�6   $��
484,43,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $)�#Проміжний аеропорт��6�   6�   �� 5+   
   -   5        $( "FlightNumber_Копировать2��5+      $
��Left=�5-      $��
490,64,0,0q�5.      $	��Top=�5/      $	��120��50      ��5,      �� *TransitAirport+$ TwoWay=�50      �� 51   
   $
��Left=�6   $��
675,43,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�Напрям��6�   6�   �� 52   
   -   5        $( "FlightNumber_Копировать4��52      $
��Left=�54      $��
640,64,0,0q�55      $	��Top=�56      $	��120��57      ��53      �� *FlightDirection+$ TwoWay=�57      59      5:      