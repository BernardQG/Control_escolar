   M S B A M L   `   `   `  ����M  IAppControl_Escolar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AppControl_EscolarAppControl_Escolar  5      $    AppControl_Escolar.ucEmpleados   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ,local clr-namespace:AppControl_Escolar  5      .��5
      � 
�������  � ColumnDefinitions  5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   � ���	#FF2C2C2C.+�5      �� $��5q�6   .+�5      �� $��	Empleados��6   $��Center=�6-   
�������$��10q�6[   $��18(�6g   $��Center=�6u   � 5      $��20��6   �� 5      $��Filtrar��6   
�������$��15(�6C   $	��Top=�6Q   $��Center=�6i   �� 5      -   5         ��Name$ cbPuesto��5       &  "MaterialDesignFloatingHintComboBox#��[  6-   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Puesto��6i   
�������6�   �� 5      -   5         ��Name$ 
btnFiltrar��5      $��Filtrar��6-   $��Center=�6?   $	��100��6]   ���	#FF3D96B8$��Center=�6�   $
��6 15q�6�   $��13(�6�   5      �� 5      -   5        $ btnCancelar��5      $��Cancelar��6*   $��Center=�6=   $	��100��6[   ���	#FF3D96B8$
��0 10q�6�   $��12(�6�   $��Bottom=�6�   5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      $��50 �6    �� 5       $��* �6    �� 5!      $��50 �6    .+�5#      � .+�5$      ��  �� Orientation$ 
Horizontal=�6   .+�5%      �� -   5         ��Name$
 tbID��5%      $ ID��6,    % !MaterialDesignFloatingHintTextBox#��[ 6P   $��70��6�   $��Center=�6�   $��	20 0 10 0q�6�   �� 5&      -   5        $ tbBuscar��5&      $ Nombre��60   #��[ 6X   $	��130��6�   $��Center=�6�   $��	20 0 10 0q�6�   5)      5+      &   System.Windows.Controls.DataGrid  5,      -   5          Name$ dgEmpleados��5,      $��10q�6,      
IsReadOnly . 	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     CanUserResizeRows .     CanUserResizeColumns .  $��1��6�      SelectionMode$ Single=�6�   � 5-      $��2��6   ���	#FF111111.+�5.      �� $ 
Horizontal=�6   .+�5/      �� $	��ID:��6    
�������$��15(�6A   $��Center=�6O   $��	25 0  0 0q�6j   �� 50      -   5         ��Name$ txtId��50       $��#��6/   $��90��68   
�������$��15(�6Y   $��Center=�6g   $��
15 0 30 0 q�6�   �� 52      -   5        $ btnInformacion��52      $��Informacion��65   $��Center=�6K   $	��100��6i   ���	#FF3D96B8$��Center=�6�   $	��6 0q�6�   $��12(�6�   �� 53      -	   5        $ btnActualizar��53      $��
Actualizar��64   $��Center=�6I   $��90��6g   ���	#FF3D96B8$��Center=�6�   $	��6 0q�6�   $��12(�6�   �� 54      -
   5        $ btnEliminar��54      $��Eliminar��62   $��Center=�6E   $��80��6c   ���	#FF3D96B8$��Center=�6�   $	��6 0q�6�   $��13(�6�   55      � 56      $��35��6   $��35��6#   $��Center=�6/   $��Right=�6J   $
��10 0q�6f   .+�57      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�6/   ���	#FF3D96B8$��35��6R   $��35��6]   �� 58      -   5         ��Name$ btnNuevo��58   1   ���	#0000000059      5:      5<      5=      5>      