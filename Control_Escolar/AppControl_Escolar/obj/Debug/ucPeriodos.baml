   M S B A M L   `   `   `  ����M  IAppControl_Escolar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AppControl_EscolarAppControl_Escolar  5      #    AppControl_Escolar.ucPeriodos   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:AppControl_Escolar     5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � 
���   �  � ColumnDefinitions  5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   � ���	#FF2C2C2C$��0��6&   .+�5      �� $��Center=�6   $��5q�66   .+�5      �� $��Periodos��6   $��Center=�6,   
�������$��10q�6Z   $��18(�6f   $��Center=�6t   � 5      $��10��6   �� 5       �� Orientation$ 
Horizontal=�6   $�� 5q�66   .+�5      	� -   5         	�Name$ 	rbAgregar��5   "   $��Agregar��65   
�������6G   � 5      $��10��6   	� 5      -   5        $ rbActualizar��5   "   $��
Actualizar��68   
�������6M   5      �� 5      -   5         ��Name$
 spIU��5      $y�	Collapsed=�6+   .+�5      �� -   5        $	 sId��5   E   $ 
Horizontal=�6!   $��5q�6:   $y�	Collapsed=�6R   .+�5      �� $��Id:  ��6$   $��Center=�61   
�������$��15(�6^   �� 5      -   5         ��Name$
 tbId��5   $   $��#��62   $��Center=�6<   ���	#FF3D96B8$��15(�6n   5      �� 5       $!��Fecha de inicio del periodo��6    $��Center=�6C   
�������$��5 5 5 0q�6p   �� 5!      $ 
Horizontal=�6!   $��5q�6:   .+�5"      �� -   5         ��Name$ cbFi_d��5"   #   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Dia��63    &  "MaterialDesignFloatingHintComboBox#��[  6X   $��45��6�   $��Center=�6�   
�������$	��2 0q�6�   �� 5#      -   5        $ cbFi_m��5#   #   $	 Mes��63   #��[  6X   $��45��6�   $��Center=�6�   
�������$	��2 0q�6�   �� 5$      -   5        $ cbFi_a��5$   #   $
 Año��63   #��[  6X   $��55��6�   $��Center=�6�   
�������$	��2 0q�6�   5%      �� 5&      $��Fecha de fin del periodo��6    $��Center=�6@   
�������$��5 5 5 0q�6m   �� 5'      $ 
Horizontal=�6!   $��5q�6:   .+�5(      �� -	   5        $ cbFf_d��5(   #   $	 Dia��63   #��[  6X   $��45��6�   $��Center=�6�   
�������$	��2 0q�6�   �� 5)      -
   5        $ cbFf_m��5)   #   $	 Mes��63   #��[  6X   $��45��6�   $��Center=�6�   
�������$	��2 0q�6�   �� 5*      -   5        $ cbFf_a��5*   #   $
 Año��63   #��[  6X   $��55��6�   $��Center=�6�   
�������$	��2 0q�6�   5+      �� 5,      -   5         ��Name$ btnIU��5,      $��Agregar��6,   $��Center=�6>   $	��100��6\   ���	#FF3D96B8$��Center=�6�   $��5q�6�   $��12(�6�   5/      51      �� 52      -   5        $ btnCancelar��52      $��Cancelar��6*   $��Center=�6=   $	��100��6[   ���	#FF3D96B8$��Bottom=�6   $��10q�6�   $��12(�6�   54      � 55   
   $��1��6   
������� � RowDefinitions 56      �� 57      $��50 �6    �� 58      $��* �6    �� 59      $��50 �6    .+�5;      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 
dgPeriodos��5;      $��10q�6,   
   
IsReadOnly
 .    CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     CanUserResizeColumns .     SelectionMode$ Single=�6�   $��1��6�   � 5<      $��2��6   
���   �6    5=      5@      5A      