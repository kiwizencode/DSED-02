   M S B A M L   `   `   `  ����N  JHotelBookingApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HotelBookingApp.WPF.ViewHotelBookingApp.WPF.View  5      )    #HotelBookingApp.WPF.View.SearchPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:HotelBookingApp.WPF.View     5        N� WindowTitle$-  'DSED02 ADO SQL Room Booking Search Page��5	       N� ShowsNavigationUI .  .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � ���	#FF54C1EA$��512.052��6&   $��731.967��67   .+�5      (� $��482.5,20,38.5,269.5q�6   .��5      &   System.Windows.Controls.Calendar  -   5          Name$ SelectCalendar��5      $
��Left=�63   $��191.793��6N   $	��Top=�6_   $��190.12��6w   $��Segoe Print)�6�      SelectionMode$ SingleRange=�5      5      5      � 5      $
��Left=�6   $	��208��6.   $��	19,20,0,0q�6;   $	��Top=�6N   $	��435��6f   .+�5      �� $!��Enter the number of guests:��6   $
��Left=�6>   $��34��6Y   $��	10,10,0,0q�6e   $	��Top=�6x   $	��215��6�   $��Segoe Print)�6�   $��14(�6�   �� 5      $��	End Date:��6   $
��Left=�6,   $��34��6G   $��	10,76,0,0q�6S   $	��Top=�6f   $	��132��6~   $��Segoe Print)�6�   $��14(�6�   �� 5      $��Start Date:��6   $
��Left=�6.   $��40��6I   $	��Top=�6U   $	��131��6m   $��	11,45,0,0q�6y   $��Segoe Print)�6�   $��14(�6�   �� 5      -   5         ��Name$ 	NoOfGuest��5      $
��Left=�6.   $��30��6I   $��
249,10,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $��TextBox��6}   $	��Top=�6�   $	��185��6�   $��Segoe Print)�6�   $��14(�6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ SelectStartDate��5      $
��Left=�66   $��36��6Q   $��
249,48,0,0q�6]   $	��Top=�6q   $	��181��6�   $��Segoe Print)�6�   $��14(�6�     5      -   5        $ SelectEndDate��5      $
��Left=�64   $��34��6O   $��
249,76,0,0q�6[   $	��Top=�6o   $	��182��6�   $��Segoe Print)�6�   $��14(�6�   �� 5      $��Search��6   $
��Left=�6*   $��29��6E   $��249,126,0,0q�6Q   $	��Top=�6f   $	��185��6~   $��Segoe Print)�6�   $��14(�6�   5      �� 5      $
��Left=�6   $	��160��62   $��514,250,0,0q�6?   $	��Top=�6T   $	��180��6l    �� View 5      �� 5      .P�5      �� 5       5"      �� 5$      $��>>��6   $
��Left=�6(   $��35��6C   $��464,279,0,0q�6O   $	��Top=�6d   $��33��6|   �� 5&      $��<<��6   $
��Left=�6(   $��36��6C   $��464,338,0,0q�6O   $	��Top=�6d   $��33��6|   �� 5'      $
��Left=�6   $��58��6/   $��102,180,0,0q�6;   $	��Top=�6P   $	��164��6h   $��Segoe Print)�6t   $��14(�6�   ��5(      �� 5)      	 �� TextWrapping$
	 Wrap=�6!   $*��$No. of guests not allocated to room:��65   5+      �� 5,      -   5        $ GuestNotAllocated��5,      $
��Left=�61   $��30��6L   $��271,196,0,0q�6X   $
 Wrap=�6m   $��TextBox��6�   $	��Top=�6�   $	��183��6�   $��Segoe Print)�6�   $��14(�6�   �� 5-      $��Who makes the booking:��6   $
��Left=�65   $��41��6P   $��
19,422,0,0q�6\   $	��Top=�6p   $	��192��6�   $��Segoe Print)�6�   $��14(�6�   �� 5.      -   5        $ CustomerName��5.      $
��Left=�6,   $��30��6G   $��214,426,0,0q�6S   $
 Wrap=�6h   $��TextBox��6|   $	��Top=�6�   $	��240��6�   $��Segoe Print)�6�   $��14(�6�   �� 5/      $
��Save��6   $
��Left=�6$   $��41��6?   $��514,420,0,0q�6K   $	��Top=�6`   $	��180��6x   $��Segoe Print)�6�   $��14(�6�   �� 50      $��Cancel��6   $
��Left=�6&   $��39��6A   $��514,465,0,0q�6M   $	��Top=�6b   $	��180��6z   $��Segoe Print)�6�   $��14(�6�   �� 51      -   5        
 ��Name$
 MainList��51      $
��Left=�6*   $	��160��6E   $��
19,250,0,0q�6R   $	��Top=�6f   $	��435��6~    52      �� 53      .P�54      �� 55      57      59      5;      5=      