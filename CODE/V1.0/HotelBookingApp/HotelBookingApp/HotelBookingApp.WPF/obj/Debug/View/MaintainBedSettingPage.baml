   M S B A M L   `   `   `  ����N  JHotelBookingApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HotelBookingApp.WPF.ViewHotelBookingApp.WPF.View  5      5    /HotelBookingApp.WPF.View.MaintainBedSettingPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:HotelBookingApp.WPF.View     5        N� WindowTitle$*  $DSED02 ADO SQL Maintain Setting Page��5	       N� ShowsNavigationUI .  .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � ���	#FF54C1EA$	��600��6&   .+�5      �� $$��Maintain Setting Information :��6   $
��Left=�6?   $	��236��6Z   $��	10,10,0,0q�6g   $	��Top=�6z   $	��654��6�   $��Segoe Print)�6�   $��14(�6�   .��5      � $
��Left=�6   $	��199��62   $��0,0,0,0q�6?   $	��Top=�6P   $	��636��6h   .+�5      �� $��Description :��6   $
��Left=�64   $��41��6O   $��
104,60,0,0q�6[   $	��Top=�6o   $	��112��6�   �� 5      -   5         ��Name$ txtDescription��5      $
��Left=�66   $��30��6Q   $��
216,61,0,0q�6]    �� TextWrapping$
 Wrap=�6q   $��TextBox��6�   $	��Top=�6�   $	��225��6�   {�.  6�   �� 5      $��GUID :��6   $
��Left=�6-   $��30��6H   $��	24,12,0,0q�6T   $	��Top=�6g   $��60��6   �� 5      -   5        $ txtGUID��5      $
��Left=�6/   $��30��6J   $��	89,15,0,0q�6V   $
 Wrap=�6i   $��TextBox��6}   $	��Top=�6�   $	��352��6�   {�.  $��12(�6�   �� 5      $��Room Description :��6   $
��Left=�69   $��41��6T   $��
56,108,0,0q�6`   $	��Top=�6t   $	��152��6�   �� 5      -   5        $ txtRoomDescription��5      $
��Left=�6:   $��30��6U   $��216,109,0,0q�6a   $
 Wrap=�6v   $��TextBox��6�   $	��Top=�6�   $	��225��6�   {�.  6�   �� 5      $��Count :��6   $
��Left=�6.   $��41��6I   $��140,154,0,0q�6U   $	��Top=�6j   $��66��6�   �� 5      -   5        $ txtCount��5      $
��Left=�60   $��30��6K   $��216,155,0,0q�6W   $
 Wrap=�6l   $��TextBox��6�   $	��Top=�6�   $	��225��6�   {�.  6�   �� 5      -   5         ��Name$ btnOK��5      $��OK��6,   $
��Left=�69   $��50��6T   $��
456,17,0,0q�6`   $	��Top=�6t   $	��152��6�   {�.  5   1   �� 5       -   5        $ 	btnCancel��5       $��Cancel��60   $
��Left=�6A   $��50��6\   $��
456,86,0,0q�6h   $	��Top=�6|   $	��152��6�   {�.  5!   1   5"      5#      �� 5'      -   5         ��Name$ grdList��5'      $
��Left=�6(   $	��280��6C   $	��Top=�6P   $	��674��6h   $��	0,320,0,0q�6t   $��Segoe Print)�5(   ]   $��14(�6v   ��6G   Z� ��5)      �� 5*       �� 
TargetType" ��6   .�5+      ��  �� Property � ��	 �� Value$	 Center=�6G   5,      
 �� View
 5.      �� 5/      P�50      �� 51      $��Room Description��6-    �� Width$	 200��6G    �� DisplayMemberBinding 6S   ��  �� Path$ DESCRIPTION�6�   �� 52      $��Count��6-   $	 200��6<    6H   �� $	 NUM�6t   54      56      �� 57      -   5        $ 	btnReturn��57      $#��Return Back to Setting Screen��6(   $
��Left=�6P   $��39��6k   $��402,264,0,0q�6w   $	��Top=�6�   $	��262��6�   $��Segoe Print)�58   )   $��14(�6B   5:      5;      5<      