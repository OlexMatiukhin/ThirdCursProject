   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Airport.Views.Dialog.AddWindowAirport.Views.Dialog.AddWindow  5   	   4    .Airport.Views.Dialog.AddWindow.AddPositionView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Airport.Views.Dialog.AddWindow     5   	     � Title$  AddPostitionView��5   	   $	��450��6"   $	��800��6/   .��5	      � .+�5
   
   �� -   5         ��Name$ FlightNumber��5
      $
��Left=�5      $��
122,54,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *PositionName+ �� Mode$ TwoWay=�5      �� 5   
   -   5        $' !FlightNumber_Копировать��5      $
��Left=�5   
   $��
272,55,0,0q�5   
   $	��Top=�5   
   $	��120��5   
   ��5   
   �� *Salary+$ TwoWay=�5   
   �� 5   
   $
��Left=�6   $��
152,35,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�    � Language$ uk-ua�6�   $�
Номер��6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
303,37,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�Зарплата��6�   6�   �� 5   
   -   5         ��Name$ NavigationBrigade��5   �    �� DisplayMemberPath$ Value��6D    �� SelectedValuePath$	 Key��6^   $
��Left=�6�   $��
421,53,0,0q�6�   $	��Top=�6�   $	��120��6  ��6   �� *StructureUnitDictionary+ �� SelectedValue 6v   �� *StructureUnitId+$ TwoWay=�6  �� 5   	   $
��Left=�6   $��
419,32,0,0q�6.   $
��Wrap=�6B   $)��#pack://application:,,,/Fonts/#Inter)�6V   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $)�#Структурна одиниця��6�   �� 6�   �� 6�   $ ru-ru�6�   �� 6  �� 6  6%  �� 5   
   $
��Left=�6   $��
456,42,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 5      $ uk-ua�6   �� 6'   �� 63   6:   �� 5   
   $��Button��67   $��130,124,259,260q�6H   ��6   �� *AddBrigadeCommand+6H   5"      5#      