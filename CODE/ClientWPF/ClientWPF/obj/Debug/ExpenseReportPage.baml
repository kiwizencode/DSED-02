   M S B A M L   `   `   `  ����D  @ClientWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ClientWPF	ClientWPF  5      !    ClientWPF.ExpenseReportPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:ClientWPF     5        N� Title$  ExpenseIt - View Expense��5	      .��5      � $��
10,0,10,10q�6    � 	Resources 5   
      typeItemTemplate �� XPath  amountItemTemplate��%�   &	        &	 I     �� 5      .R�5      �� ��6   �� $ @ExpenseType��5      �� 5      .R�5      �� ��6   �� $ @ExpenseAmount��5      5      ��5   
   �� 5       �� ImageSource$ watermark.png��6    � ColumnDefinitions 5   
   �� 5      $	��230 �6   �� 5       � RowDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      .+�5&   
   �� $��1��6     headerTextStyle#��[ 6    $��Expense Report For:��5'      � 5*   
   $��10q�6   $��1��6   $��1��6+    5,      �� 5-      �� 5.       50      �� 51      $
��Auto �6    �� 52      $
��Auto �6    �� 53      .+�57      �� $��0��6   $��2��6)   $��0��6=    �� Orientation$ 
Horizontal=�6J   .+�58      ��   
labelStyle#��[ 6   $
��Name��6<   �� 59      #��[ 6   ��6<   �� $ @Name��5:      �� 5=      $��0��6   $��2��6)   $��1��6=   $ 
Horizontal=�6J   .+�5>      �� #��[ 6   $��Department:��6<   �� 5?      #��[ 6   ��6<   �� $ @Department��5@      � 5B      $��0��6   $��2��6#   $��2��67   $	��Top=�5C      $
��Left=�6+   .+�5E      &   System.Windows.Controls.DataGrid    columnHeaderStyle   ColumnHeaderStyle# [ 6      AutoGenerateColumns .  	   RowHeaderWidth$	 0Q�5F   7   ��5G      �� $ Expense��
   Columns
 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$ ExpenseType��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� $ @ExpenseType��  5J      $ Amount��6-    6=   �� $ @ExpenseAmount��5L      5M      5N      5P      5Q      