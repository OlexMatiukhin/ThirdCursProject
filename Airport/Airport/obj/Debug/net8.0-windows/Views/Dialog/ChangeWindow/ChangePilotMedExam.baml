   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Airport.Views.DialogAirport.Views.Dialog  5      -    'Airport.Views.Dialog.ChangePilotMedExam   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Airport.Views.Dialog     5      X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � Title$  ChangePlane��5
      .��5      � .+�5   
   �� $
��Left=�6   $��
110,62,0,0q�6.   $	��Top=�6B   $	��120��6Z   ��6f   �� *Result+ �� SelectedValue 6�   �� *SelectedResult+ �� Mode$ TwoWay=��� 5   
   $
��Left=�6   $��
278,62,0,0q�6.   $	��Top=�6B   $	��120��6Z    �� SelectedValuePath$	 Key��6�   ��6f   �� *PilotsDictionary+ 6�   �� *SelectedPilotId+$ TwoWay=��� 5   
   $
��Left=�6   $��
420,61,0,0q�6.   $	��Top=�6B   $	��120��6Z   $	 Key��6�   ��6f   �� *DoctorsDictionary+ 6�   �� *SelectedDoctorId+$ TwoWay=��� 5   
   $
��Left=�6   $��
139,43,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�    � Language$ uk-ua�6�   $�Результат��6�   �� 6�   �� 6�   $ uk-ua�6�   �� 6
  �� 6  �� 6  �� 6(  6/  �� 5   
   $
��Left=�6   $��
310,43,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�П��6�   �� 6�   $ uk-ua�6�   $�ілот��6�   �� 6  �� 6  �� 6  �� 6   6'  �� 5   
   $
��Left=�6   $��
454,43,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�Доктор��6�   �� 6�   �� 6�   6�   �� 5   
   $��Змінити��6   $��Center=�6#   $��	0,114,0,0q�6@   $	��Top=�6S   $	��140��6k    J� RenderTransformOrigin$ 0.521,1.104&�6w   ��6�   �� *ChangeMedExamCommand+�� 5   
   $	��Top=�6   $
��Wrap=�6,   $��
614,43,0,0q�6@   $��14��6T   $
��Left=�6`   $
��Bold"�6{   $)��#pack://application:,,,/Fonts/#Inter)�6�   �� 6�   $ uk-ua�6�   $�Дата��6�   6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   
����� �&   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�5         FormatString$ dd/MM/yyyy HH:mm��5      
���   �   CalendarDisplayMode$
 Year=�5      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]	   ShowButtonSpinner$	 False��5      $��
566,62,0,0q�5      $
��Left=�5      $	��Top=�5       $	��134��5"      $��20��6   $	��140��6%   
   Value
 5!      �� *DateExamination+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5"   %   5$      5%      