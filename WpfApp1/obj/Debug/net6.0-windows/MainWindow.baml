   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfAppSQLTermekekWpfAppSQLTermekek  5   	   "    WpfAppSQLTermekek.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfAppSQLTermekek     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      .+�5   
   �� .+�5      �� $��
Kategória��6   �� 5      -   5         ��Name$ 
cbCategory��5      �� 5      $��Gyártó��6   �� 5      -   5        $ cbManifacturers��5      �� 5      $��Keresés a terméknévben��6   �� 5      -   5         ��Name$ txtProducts��5      
������5      �� 5      -   5         ��Name$ 	btnSzukit��5      $��0 20 0 0q�5      $��Szűrés a feltételekre��5      65   �� 5      -   5        $ 	btnMentes��5      $��0 20 0 0q�5      $��Mentés CSV fájlba��5      61   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgProducts��5      $��1��5      
�������$��5q�5!      5#      5$      