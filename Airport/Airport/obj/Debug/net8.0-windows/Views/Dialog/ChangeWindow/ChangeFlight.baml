   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Airport.Views.Dialog.ChangeWindow!Airport.Views.Dialog.ChangeWindow  5   	   4    .Airport.Views.Dialog.ChangeWindow.ChangeFlight   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Airport.Views.Dialog.ChangeWindow     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  ChangeFlight��5	   	   $	��450��6   $	��800��6+   .��5
      � .+�5   
   �� -   5         ��Name$ FlightNumber��5      $
��Left=�5      $��
122,54,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *FlightNumber+ �� Mode$ TwoWay=�5      �� 5   
   $
��Left=�5      $��
263,54,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *
Category+ �� SelectedValue 5      �� *SelectedCategory+$ TwoWay=�5      �� 5   
   $
��Left=�6   $��
152,35,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�    � Language$ uk-ua�6�   $�
Номер��6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
293,36,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Категорія��6�   6�   �� 5   
   $
��Left=�6   $��
424,36,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
549,34,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Відправлення��6�   �� 6�   �� 6�   6�   �� 5   
   -   5         ��Name$ Plane��5   �    �� DisplayMemberPath$ Value��6<    �� SelectedValuePath$	 Key��6�   $
��Left=�6�   $��122,107,0,0q�6�   $	��Top=�6�   $	��120��6   ��6   �� *PlanesDictionary+ 6V   �� *SelectedPlaneNumber+$ TwoWay=�6   �� 5   
   -   5        $ DispatcherBrigade��5   �   $ Value��6D   $	 Key��6�   $
��Left=�6�   $��540,106,0,0q�6�   $	��Top=�6  $	��120��6  ��6   �� *FlightBrigadesDictionary+ 6_   �� *SelectedFlightBrigadeId+$ TwoWay=�6  �� 5   
   -   5        $ NavigationBrigade��5   �   $ Value��6G   $	 Key��6a   $
��Left=�6�   $��400,106,0,0q�6�   $	��Top=�6  $	��120��6  ��6   �� *DispatchBrigadesDictionary+ 6y   �� *SelectedDispatchBrigadeId+$ TwoWay=�6  �� 5    
   $
��Left=�6   $��
432,35,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Прибуття��6�   �� 6�   �� 6�   $ uk-ua�6�   6
  �� 5!   
   $
��Left=�6   $��
163,88,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�
Літак��6�   �� 6�   �� 6�   6�   �� 5"   
   $
��Left=�6   $��
385,85,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�Диспетч��6�   �� 6�   $�ерська бриг��6�   �� 6�   $ uk-ua�6�   $�ада��6  �� 6  �� 6  �� 6!  �� 6-  64  �� 5#   
   $
��Left=�6   $��
428,91,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5$   
   $
��Left=�6   $��
256,85,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $%�Навігаційна бриг��6�   �� 6�   $ uk-ua�6�   $�ада��6�   �� 6�   �� 6  �� 6  �� 6  6$  �� 5%   
   $ Value��6I   $	 Key��6c   $
��Left=�6�   $��259,107,0,0q�6�   $	��Top=�6�   $	��120��6  ��6   �� *NavigationBrigadesDictionary+ 6{   �� *SelectedNavigationBrigadeId+$ TwoWay=�6  �� 5&   
   $ Value��6N   $	 Key��6i   $
��Left=�6�   $��112,163,0,0q�6�   $	��Top=�6�   $	��128��6  ��6   �� *" TechInspectionBrigadesDictionary+ 6�   �� *!SelectedTechInspectionBrigadeId+$ TwoWay=�6  �� 5'   
   -   5        $ RouteId��5'   �   $ Value��6=   $	 Key��6X   $
��Left=�6�   $��263,163,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *RoutesDictionary+ 6q   �� *RouteNumber+$ TwoWay=�6�   �� 5)   
   $
��Left=�6   $��
553,87,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $!�Льотна бригада��6�   6�   �� 5*   
   $
��Left=�6   $��122,144,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   $'��!Бригада техогляду��6�   �� 5+   
   $
��Left=�6   $��295,145,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Маршрут��6�   �� 6�   �� 6�   �� 6�   �� 6  6  �� 5,   
   $
��Left=�6   $��428,144,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5.   
   -   5        $( "FlightNumber_Копировать1��5.      $
��Left=�50      $��405,164,0,0q�51      $	��Top=�52      $	��120��53      ��5/      �� *NumberTicket+$ TwoWay=�53      �� 55   
   $
��Left=�6   $��411,144,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $'�!Кількість квитків��6�   6�   �� 56   
   -   5        $��Змінити��56      $
��Left=�6L   $��275,234,0,0q�6g   $	��Top=�6|   $��45��6�   $	��184��6�   ��6#   �� *ChangeFlightCommand+6�   &   Xceed.Wpf.Toolkit.DateTimePicker  58   
   
����� �&   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5:      	   FormatString$	 dd/MM/yyyy HH:mm��5;      
���   �
   CalendarDisplayMode$

 Year=�5=      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   ShowButtonSpinner$ False��5>      $��
561,56,0,0q�5?      $
��Left=�5@      $	��Top=�5A      $	��134��5C      $��20��6   $	��140��6%      Value 5B      �� *DateDeparture+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5C   %     5D   
   $
��Left=�6   $	��Top=�5E      
����� �$ Custom=�68   $	 dd/MM/yyyy/ HH:mm��6H   
���   �$

 Year=�6~   $ False��6�   $��
398,55,0,0q�6�   $	��140��6  $��20��6'  $	��140��63   6�   �� *DateArrivial+$ TwoWay=�$ PropertyChanged=�63  5G      5I      