   M S B A M L   `   `   `  ����B  >Airport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Airport.Views.Dialog.AddWindowAirport.Views.Dialog.AddWindow  5   	   3    -Airport.Views.Dialog.AddWindow.AddBaggageView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Airport.Views.Dialog.AddWindow     5   	     � Title$  AddBaggageView��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� $
��Left=�6   $��
365,46,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�    � Language$ ru-ru�6�   $�Вага��6�   6�   �� 5   
   -   5         ��Name$' !FlightNumber_Копировать��5      $
��Left=�5      $��
330,67,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *	BaggeType+ �� Mode$ TwoWay=�5      �� 5   
   $
��Left=�6   $��
528,44,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�Оплата��6�   6�   �� 5   
   -   5        $( "FlightNumber_Копировать1��5      $
��Left=�5      $��
490,67,0,0q�5      $	��Top=�5      $	��120��5      ��5      �� *	Payment+$ TwoWay=�5      �� 5   
   $��Center=�6   $��0,95,0,0q�61   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $ ru-ru�6�   $�Пасажир��6�   �� 6�   �� 6�   �� 6�   �� 6  6
  �� 5   
   $
��Left=�6p   $��
186,69,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6   �� *TypeBaggeList+ �� SelectedValue 6=   �� *	BaggeType+$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��
217,46,0,0q�6/   $
��Wrap=�6C   $)��#pack://application:,,,/Fonts/#Inter)�6W   $	��Top=�6�   $
��Bold"�6�   $��14��6�   �� 6�   $�Категор��6�   �� 6�   $ uk-ua�6�   $�і��6�   �� 6�   $�я��6�   6  �� 5   
    �� DisplayMemberPath$ Value��6B    �� SelectedValuePath$	 Key��6]   $��Center=�6�   $��	0,117,0,0q�6�   $	��Top=�6�   $	��128��6�   ��6   �� *PassengersDictionary+ 6v   �� *SelectedPassengerId+$ TwoWay=�6�   �� 5   
   $��Додати��6   $
��Left=�6H   $��250,169,0,0q�6c   $	��Top=�6x   $	��246��6�    J� RenderTransformOrigin$ 0.664,6.966&�6�   $��35��6�   ��6"   �� *AddBaggageCommand+6�   5!      5$      