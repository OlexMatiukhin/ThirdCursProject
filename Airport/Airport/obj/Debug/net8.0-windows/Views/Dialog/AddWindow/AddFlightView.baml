   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Airport.Views.DialogAirport.Views.Dialog  5      U QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aS:clr-namespace:System.Globalization;assembly=System.RuntimeSystem.Globalization 5   >   (    "Airport.Views.Dialog.AddFlightView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Airport.Views.Dialog     5      X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      NGlobalization:clr-namespace:System.Globalization;assembly=System.Runtime  6>     � Title$  ChangePlane��5
      .��5      � $��-2,0,2,0q�6   .+�5   
   �� -   5         ��Name$ FlightNumber��5      $
��Left=�5      $��
122,54,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *FlightNumber+ �� Mode$ TwoWay=�5      �� 5   
   $
��Left=�5      $��
263,54,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *
Category+ �� SelectedValue 5      �� *SelectedCategory+$ TwoWay=�5      �� 5   
   $
��Left=�6   $��
152,35,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�    � Language$ uk-ua�6�   $�
Номер��6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
293,36,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Категорія��6�   6�   �� 5   
   $
��Left=�6   $��
424,36,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
562,34,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Відправлення��6�   �� 6�   �� 6�   6�   �� 5   
   $��Додати��6   $
��Left=�6G   $��277,224,0,0q�6b   $	��Top=�6w   $	��211��6�    J� RenderTransformOrigin$ 0.664,6.966&�6�   $��30��6�   ��6"   �� *AddFlightCommand+6�   �� 5    
   -   5         ��Name$ Plane��5    �    �� DisplayMemberPath$ Value��6<    �� SelectedValuePath$	 Key��6�   $
��Left=�6�   $��122,107,0,0q�6�   $	��Top=�6�   $	��120��6   ��6   �� *PlanesDictionary+ 6V   �� *SelectedPlaneNumber+$ TwoWay=�6   �� 5!   
   -   5        $ DispatcherBrigade��5!   �   $ Value��6D   $	 Key��6�   $
��Left=�6�   $��540,106,0,0q�6�   $	��Top=�6  $	��120��6  ��6   �� *FlightBrigadesDictionary+ 6_   �� *SelectedFlightBrigadeId+$ TwoWay=�6  �� 5"   
   -   5        $ NavigationBrigade��5"   �   $ Value��6G   $	 Key��6a   $
��Left=�6�   $��400,106,0,0q�6�   $	��Top=�6  $	��120��6  ��6   �� *DispatchBrigadesDictionary+ 6y   �� *SelectedDispatchBrigadeId+$ TwoWay=�6  �� 5#   
   $
��Left=�6   $��
432,35,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Прибуття��6�   �� 6�   �� 6�   $ uk-ua�6�   6
  �� 5$   
   $
��Left=�6   $��
163,88,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�
Літак��6�   �� 6�   �� 6�   6�   �� 5%   
   $
��Left=�6   $��
385,85,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�Диспетч��6�   �� 6�   $�ерська бриг��6�   �� 6�   $ uk-ua�6�   $�ада��6  �� 6  �� 6  �� 6!  �� 6-  64  �� 5&   
   $
��Left=�6   $��
428,91,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5'   
   $
��Left=�6   $��
256,85,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $%�Навігаційна бриг��6�   �� 6�   $ uk-ua�6�   $�ада��6�   �� 6�   �� 6  �� 6  �� 6  6$  �� 5(   
   $ Value��6I   $	 Key��6c   $
��Left=�6�   $��259,107,0,0q�6�   $	��Top=�6�   $	��120��6  ��6   �� *NavigationBrigadesDictionary+ 6{   �� *SelectedNavigationBrigadeId+$ TwoWay=�6  �� 5)   
   $ Value��6N   $	 Key��6i   $
��Left=�6�   $��112,163,0,0q�6�   $	��Top=�6�   $	��128��6  ��6   �� *" TechInspectionBrigadesDictionary+ 6�   �� *!SelectedTechInspectionBrigadeId+$ TwoWay=�6  �� 5*   
   -   5        $ RouteId��5*   �   $ Value��6=   $	 Key��6X   $
��Left=�6�   $��263,163,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *RoutesDictionary+ 6q   �� *RouteNumber+$ TwoWay=�6�   �� 5,   
   $
��Left=�6   $��
553,87,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $!�Льотна бригада��6�   6�   �� 5-   
   $
��Left=�6   $��122,144,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   $'��!Бригада техогляду��6�   �� 5.   
   $
��Left=�6   $��295,145,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Маршрут��6�   �� 6�   �� 6�   �� 6�   �� 6  6  �� 5/   
   $
��Left=�6   $��428,144,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 53   
   -   5        $( "FlightNumber_Копировать1��53      $
��Left=�55   
   $��405,164,0,0q�56   
   $	��Top=�57   
   $	��120��58   
   ��54   
   �� *NumberTickets+$ TwoWay=�58      �� 5:   
   -   5        $' !FlightNumber_Копировать��5:      $
��Left=�5<      $��548,164,0,0q�5=      $	��Top=�5>      $	��120��5?      ��5;      �� *TicketPrice+$ TwoWay=�5?      �� 5B   
   $
��Left=�6   $��411,144,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $'�!Кількість квитків��6�   6�   �� 5C   
   $
��Left=�6   $��565,144,0,0q�6/   $
��Wrap=�6D   $)��#pack://application:,,,/Fonts/#Inter)�6X   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�Ц��6�   �� 6�   $ uk-ua�6�   $�іна квиткка��6�   6  &   Xceed.Wpf.Toolkit.DateTimePicker  5E   
   
����� �&   Xceed.Wpf.Toolkit.DateTimeUpDown	   Format$	 Custom=�5G      
   FormatString$
 dd/MM/yyyy HH:mm��5H      
���   �   CalendarDisplayMode$
 Year=�5J      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   ShowButtonSpinner$ False��5K      $��
561,56,0,0q�5L      $
��Left=�5M      $	��Top=�5N      $	��134��5P      $��20��6   $	��140��6      Value 5O      �� *DateDeparture+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5P        5Q   
   $
��Left=�6   $	��Top=�5R      
����� �$	 Custom=�6-   $
 dd/MM/yyyy/ HH:mm��6=   
���   �$
 Year=�6s   $ False��6�   $��398,55,256,359q�6�   $	��140��6  $��20��6   $	��140��6,   6�   �� *DateArrivial+$ TwoWay=�$ PropertyChanged=�6,  5T      5U      