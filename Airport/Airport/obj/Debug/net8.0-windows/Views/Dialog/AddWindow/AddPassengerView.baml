   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Airport.Views.Dialog.AddWindowAirport.Views.Dialog.AddWindow  5   	   5    /Airport.Views.Dialog.AddWindow.AddPassengerView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Airport.Views.Dialog.AddWindow     5   	     � Title$  AddPassengerView��5	   	   $	��450��6"   $	��800��6/   .��5
      � .+�5   
   �� -   5         ��Name$ FullName��5      $
��Left=�5      $��	30,54,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *
FullName+ �� Mode$ TwoWay=�5      �� 5   
   -   5        $	 Age��5   6   $
��Left=�5      $��
165,54,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *Age+$ TwoWay=�5      �� 5   
   -   5         ��Name$# Category_Копировать��5   j   $
��Left=�6�   $��
312,51,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *Gender+ �� SelectedValue 64   �� *SelectedGender+$ TwoWay=�6�   �� 5   
   -   5        $$ Category_Копировать3��5   3   $
��Left=�6Q   $��
454,51,0,0q�6l   $	��Top=�6�   $	��120��6�   $��21��6�   ��6   �� *PassportNumber+6�   �� 5   
   -   5        $ Category��5   8   $
��Left=�6J   $��
621,46,0,0q�6e   $	��Top=�6y   $	��120��6�   ��6   �� *InternPassportNumber+6�   �� 5   
   $
��Left=�6   $��	60,35,0,0q�6/   $
��Wrap=�6B   $)��#pack://application:,,,/Fonts/#Inter)�6V   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�    � Language$ ru-ru�6�   $�П��6�   �� 6�   $ uk-ua�6�   $
�ІБ��6�   �� 6�   �� 6  6  �� 5   
   $
��Left=�6   $��
468,27,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $	�№��6�   �� 6�   $� ��6�   �� 6�   $�п��6�   �� 6�   $�аспорту��6  �� 6  �� 6  6%  �� 5   
   $
��Left=�6   $��
424,36,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5   
   $
��Left=�6   $��
612,27,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   $	��165��6�   �� 6�   $
�№ ��6�   �� 6�   $/�)Закордонного паспорту��6�   �� 6�   �� 6
  6  �� 5    
   $
��Left=�6   $��	62,86,0,0q�6/   $
��Wrap=�6B   $)��#pack://application:,,,/Fonts/#Inter)�6V   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�
Пошта��6�   6�   �� 5!   
   $
��Left=�6   $��
196,87,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   �� 6�   �� 6�   6�   �� 5"   
   $
��Left=�6   $��
214,34,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�В��6�   �� 6�   $ uk-ua�6�   $
�ік��6�   �� 6   �� 6  $ uk-ua�6  �� 6#  �� 6/  66  �� 5&   
   $
��Left=�6   $��
171,88,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $!�Номер телефону��6�   �� 6�   �� 6�   $ ru-ru�6�   6  �� 5'   
   -   5        $ NumberChildren��5'   @   $
��Left=�5(      $��
30,106,0,0q�5)      $	��Top=�5*      $	��120��5+      ��5'      �� *BaggageStatus+$ TwoWay=�5+      �� 5,   
   -   5        $ Email��5,   =   $
��Left=�5-      $��163,106,0,0q�5.      $	��Top=�5/      $	��120��50      ��5,      �� *PhoneNumber+$ TwoWay=�50      �� 53   
   $��Додати��6   $
��Left=�6J   $��277,224,0,0q�6e   $	��Top=�6z   $	��211��6�    J� RenderTransformOrigin$ 0.664,6.966&�6�   $��30��6�   ��6"   �� *AddPassengerCommand+6�   �� 55   
   $
��Left=�6   $��
354,27,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ uk-ua�6�   $�
Стать��6�   6�   57      58      