   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Airport.Views.Dialog.ChangeWindow!Airport.Views.Dialog.ChangeWindow  5   	   9    3Airport.Views.Dialog.ChangeWindow.ChangePlaneRepair   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Airport.Views.Dialog.ChangeWindow     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  ChangePlaneRepair��5	   	   $	��450��6#   $	��800��60   .��5
      � .+�5   
   &   Xceed.Wpf.Toolkit.DateTimePicker  
����� �&   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5   
      FormatString$ dd/MM/yyyy HH:mm��5   
   
���   �   CalendarDisplayMode$
 Year=�5   
   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   ShowButtonSpinner$ False��5   
   $��
241,58,0,0q�5   
   $
��Left=�5   
   $	��Top=�5   
   $	��134��5   
   $��20��6   $	��140��6"      Value 5   
   �� *	EndDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5   "     5   
   $
��Left=�6m   $	��Top=�5   
   
����� �$ Custom=�65   $ dd/MM/yyyy/ HH:mm��6E   
���   �$
 Year=�6{   $ False��6�   $��	78,57,0,0q�6�   $	��140��6�   $��20��6�   $	��140��6�    5      �� *	StartDate+$ TwoWay=�$ PropertyChanged=�5   �   �� 5   
   -   5         ��Name$$ Category_Копировать3��5   j   $
��Left=�6�   $��
383,54,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *Status+	 �� SelectedValue	 64   �� *SelectedStatus+$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��
107,34,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   
 � Language$
 ru-ru�6�   $�Дата початку��6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
422,32,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $
 uk-ua�6�   $�Статус��6�   6�   �� 5    
   $
��Left=�6   $��
424,36,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $
 uk-ua�6�   �� 6�   �� 6�   6�   �� 5!   
   $
��Left=�6   $��
289,94,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�Резуль��6�   �� 6�   $
 uk-ua�6�   $�т��6�   �� 6�   $�а��6�   �� 6  $
 uk-ua�6  $�т��6  �� 6"  �� 6.  65  �� 5"   
   $
��Left=�6   $��
542,34,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�Кількість ��6�   �� 6�   $
 uk-ua�6�   $�польотів��6�   �� 6�   �� 6
  6  �� 5#   
   $
��Left=�6   $��
439,92,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�Бригада��6�   �� 6�   �� 6�   6�   �� 5$   
   $
��Left=�6   $��
428,91,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $
 uk-ua�6�   �� 6�   �� 6�   6�   �� 5%   
   $
��Left=�6   $��
275,37,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�Дата к��6�   �� 6�   $
 uk-ua�6�   $�і��6�   �� 6�   $�нця��6�   6  �� 5&   
   $
��Left=�6   $��
586,92,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�    J� RenderTransformOrigin$ -1.896,0.431&�6�   �� 6�   $
 uk-ua�6�   $�
Літак��6�   6	  �� 5(   
   -   5         ��Name$( "FlightNumber_Копировать2��5(      $
��Left=�5)      $��
540,57,0,0q�5*      $	��Top=�5+      $	��120��5,      ��6   �� *NumberFlights+$ TwoWay=��� 5-   
   -   5        $ NumberChildren��5-   9   $
��Left=�5.      $��122,113,0,0q�5/      $	��Top=�50      $	��120��51      ��5-      �� *Reason+$ TwoWay=�51      �� 52   
   -   5        $ Category��52   h   $
��Left=�6z   $��260,113,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *Result+	 62   �� *SelectedResult+$ TwoWay=�6�   �� 53   
   -   5        $# Category_Копировать��53   �    �� DisplayMemberPath$ Value��6w    �� SelectedValuePath$	 Key��6�   $
��Left=�6�   $��406,109,0,0q�6�   $	��Top=�6�   $	��116��6  $��27��6  ��6   �� *BrigadesDictionary+	 6>   �� *SelectedBrigadeId+$ TwoWay=�6  �� 54   
   -   5        $ Postions��54   �   $ Value��6>   $	 Key��6X   $
��Left=�6�   $��542,112,0,0q�6�   $	��Top=�6�   $	��120��6  ��6   �� *PlanesDictionary+	 6p   �� *SelectedPlaneId+$ TwoWay=�6  �� 55   
   $
��Left=�6   $��
149,93,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $
 uk-ua�6�   $�Причин��6�   �� 6�   $�а��6�   �� 6�   �� 6�   �� 6  �� 6  6  �� 57   
   $��Змінити��6   $
��Left=�6#   $��327,174,0,0q�6>   $	��Top=�6S   $	��162��6k   $��30��6w   ��6�   �� *ChangePlaneRepairCommand+5<      5=      