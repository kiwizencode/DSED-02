   M S B A M L   `   `   `  ����N  JHotelBookingApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HotelBookingApp.WPF.ViewHotelBookingApp.WPF.View  5      .    (HotelBookingApp.WPF.View.MaintainBedPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:HotelBookingApp.WPF.View     5        N� WindowTitle$&   DSED02 ADO SQL Maintain Bed Page��5	       N� ShowsNavigationUI .  .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � ���	#FF54C1EA$	��519��6&   .+�5      �� -   5         ��Name$ grdList��5      $
��Left=�6(   $	��219��6C   $	��Top=�6P   $	��674��6h   $��	0,300,0,0q�6t   $��Segoe Print)�5   ]   $��14(�6v   ��6G   Z� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Center=�6G   5       �� View 5      �� 5      P�5      �� 5      $
��GUID��6-    �� Width$	 375��6;   	 �� DisplayMemberBinding	 6G   �� 
 �� Path$

 GUID�6t   �� 5      $��Description��6-   $	 100��6B   	 6N   �� $
 DESCRIPTION�6�   �� 5      $��Max. Capacity��6-   $	 150��6D   	 6P   �� $
 MAX_CAPACITY�6�   5      5      �� 5      $ ��Maintain Bed Information :��6   $
��Left=�6;   $	��192��6V   $��	10,10,0,0q�6c   $	��Top=�6v   $	��654��6�   $��Segoe Print)�6�   $��14(�6�   .��5      � $
��Left=�6   $	��253��62   $��0,0,0,0q�6?   $	��Top=�6P   $	��636��6h   .+�5       �� $��Description :��6   $
��Left=�64   $��41��6O   $��
104,60,0,0q�6[   $	��Top=�6o   $	��128��6�   �� 5!      $��Max. Capacity :��6   $
��Left=�66   $��34��6Q   $��
86,102,0,0q�6]   $	��Top=�6q   $	��128��6�   �� 5"      $��GUID :��6   $
��Left=�6-   $��30��6H   $��	24,12,0,0q�6T   $	��Top=�6g   $��60��6   �� 5$      -   5         ��Name$ txtDescription��5$      $
��Left=�66   $��30��6Q   $��
216,61,0,0q�6]    �� TextWrapping$
 Wrap=�6q   $��TextBox��6�   $	��Top=�6�   $	��225��6�   {�.  6�   �� 5%      -   5        $ txtMax_Capacity��5%      $
��Left=�67   $��30��6R   $��216,106,0,0q�6^   $
 Wrap=�6s   $��TextBox��6�   $	��Top=�6�   $	��225��6�   {�.  6�   �� 5&      -   5        $ txtGUID��5&      $
��Left=�6/   $��30��6J   $��	89,15,0,0q�6V   $
 Wrap=�6i   $��TextBox��6}   $	��Top=�6�   $	��352��6�   {�.  $��12(�6�   �� 5'      -   5         ��Name$ btnOK��5'      $��OK��6,   $
��Left=�69   $��50��6T   $��
456,17,0,0q�6`   $	��Top=�6t   $	��152��6�   {�.  5(   1   �� 5)      -   5        $ 	btnCancel��5)      $��Cancel��60   $
��Left=�6A   $��50��6\   $��
456,86,0,0q�6h   $	��Top=�6|   $	��152��6�   {�.  5*   1   5+      5,      �� 5-      -   5        $ btnAdd��5-      $��Add Bed��6%   $
��Left=�67   $��39��6R   $��
13,253,0,0q�6^   $	��Top=�6r   $	��152��6�   $��Segoe Print)�5.   2   $��14(�6K   �� 5/      -   5        $ btnEdit��5/      $��Edit Bed��6&   $
��Left=�69   $��40��6T   $��172,252,0,0q�6`   $	��Top=�6u   $	��152��6�   $��Segoe Print)�50   3   $��14(�6L   {�.  6Z   �� 51      -	   5        $ 	btnRemove��51      $��
Remove Bed��6(   $
��Left=�6=   $��40��6X   $��332,252,0,0q�6d   $	��Top=�6y   $	��152��6�   $��Segoe Print)�52   5   $��14(�6N   {�.  6\   �� 53      -
   5        $ btnExit��53      $��Exit Screen��6&   $
��Left=�6<   $��39��6W   $��510,208,0,0q�6c   $	��Top=�6x   $	��152��6�   $��Segoe Print)�54   3   $��14(�6L   55      56      57      