   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Airport.Views.Dialog.AddWindowAirport.Views.Dialog.AddWindow  5   	   2    ,Airport.Views.Dialog.AddWindow.AddTicketView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Airport.Views.Dialog.AddWindow     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  AddTicketView��5	   	   $	��450��6   $	��800��6,   .��5
      � .+�5   
   �� $
��Left=�6   $��
152,35,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�C��6�   �� 6�    � Language$ ru-ru�6�   $�
татус��6�   �� 6�   �� 6�   6  �� 5   
   -   5         ��Name$ Plane��5   j   $
��Left=�6y   $��
120,69,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *Status+ �� SelectedValue 63   �� *SelectedStatus+ �� Mode$ TwoWay=�6�   �� 5   
   $
��Left=�66   $��
323,69,0,0q�6R   $	��Top=�6f    J� RenderTransformOrigin$ 1,0.731&�6    d� 	IsChecked 6   �� *Availability+6   �� 5   
   -   5         ��Name$( "FlightNumber_Копировать1��5      $
��Left=�5      $��112,124,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *Price+$ TwoWay=�5      �� 5   
    �� DisplayMemberPath$ Value��6>   	 �� SelectedValuePath$		 Key��6X   $
��Left=�6�   $��259,121,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *FlightsDictionary+ 6p   �� *SelectedFlightId+$ TwoWay=�6�   �� 5   
   -   5        $ NavigationBrigade��5   �   $ Value��6<   $		 Key��6V   $
��Left=�6�   $��400,120,0,0q�6�   $	��Top=�6�   $	��120��6  ��6   �� *SeatsDictionary+ 6o   �� *SelectedSeatId+$ TwoWay=�6  �� 5   
   $
��Left=�6   $��
432,35,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�Дата зм��6�   �� 6�   $ uk-ua�6�   $
�ін��6�   �� 6  �� 6  6  �� 5   
   $
��Left=�6   $��
442,98,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�М��6�   �� 6�   $ uk-ua�6�   $�ісце��6�   6  �� 5   
   $
��Left=�6   $��
428,91,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
294,99,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Р��6�   �� 6�   $�ейс��6�   6�   �� 5$   
   $
��Left=�6   $��160,103,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Ціна��6�   �� 6�   �� 6�   $ uk-ua�6�   6  �� 5%   
   $
��Left=�6   $��
294,45,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Доступність��6�   �� 6�   �� 6�   6�   �� 5&   
   $��Додати��6   $
��Left=�6"   $��323,174,0,0q�6=   $	��Top=�6R   $��30��6j   $	��113��6v   ��6�   �� *AddTicketCommand+&   Xceed.Wpf.Toolkit.DateTimePicker  5(   
   
����� �&   Xceed.Wpf.Toolkit.DateTimeUpDown
   Format$
 Custom=�5*         FormatString$ dd/MM/yyyy HH:mm��5+      
���   �   CalendarDisplayMode$
 Year=�5-      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   ShowButtonSpinner$ False��5.      $��
400,66,0,0q�5/      $
��Left=�50      $	��Top=�51      $	��140��53      $��20��6   $	��140��6%      Value 52      �� *DateChanges+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�53   %   55      56      