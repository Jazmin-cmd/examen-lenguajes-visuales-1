   M S B A M L   `   `   `  ����  ExamenLenguajesVisuales15    /ExamenLenguajesVisuales1.Views.VendedoresWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Administrar Vendedores��5   	   $	��450��6(   $	��600��65   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� $��Buscar:��6   $��Center=�6&   �� 5      -   5         ��Name$ 	txtBuscar��5      $	��200��6)   $	��5,0q�65   6B   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgVendedores��5      $��1��6)      AutoGenerateColumns .     SelectionMode$ Single=�6R      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
VendedorId+6P     5      $	 Nombre��6%   $
 * 6P    65   �� *Nombre+6P     5      $	 	Teléfono��6%   $
 * 6T    67   �� *
Telefono+6T     5      $	 Email��6%   $
 * 6N    64   �� *Email+6N   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��Right=�6;   $��0,10,0,0q�6W   .+�5      �� -   5        $��Agregar��5      $��75��6'   $��5q�62   6=   �� 5      -   5        $��Editar��5      $��75��6&   $��5q�61   6<   �� 5      -   5        $��Eliminar��5      $��75��6(   $��5q�63   6>   5      5      5       