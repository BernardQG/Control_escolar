   M S B A M L   `   `   `  ����M  IAppControl_Escolar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AppControl_EscolarAppControl_Escolar  5   	   #    AppControl_Escolar.WPrincipal   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:AppControl_Escolar     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
WPrincipal��5	   	   $	��550��6   $	��900��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K    � WindowStyle$
 None=�6p    � AllowsTransparency . ���	#00000000 � Icon$ ico.png��6�   .��5
      � .+�5   
   ��  �� RadiusY$ 4��6    �� RadiusX$ 4��6    
�������6,   �� 5   
   -   5         ��Name$ 
rPrincipal��5   ,   $ 4��6   $ 4��6    $��1q�6@   ��5      �� 5      	 j� Stretch$	 UniformToFill=�6   
 �� ImageSource$
 Fon1.jpg��65   5      � 5   
    � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��* �6    �� 5      $��30 �6    .+�5      �� $	��Top=�6   $��Center=�60   $��5q�6M   $��Control Escolar��6X   
�������$��25(�6�   $
��Bold"�6�   � 5      $	��Top=�6   $��Right=�6+   $��5q�6G   .+�5      �� $ 13��6   $ 13��6)   ���	#FF47474766   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ 	btnCuenta��5      $��25��60   $��25��6;   $��Center=�6G    0  ,MaterialDesignFloatingActionMiniAccentButton#��[  6b   $��2 2 3 2q�6�   ���	#FF3D96B8{�.  ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ HomeAccount=�62   $��15��6E   $��15��6Q   $��Center=�6\   $��Center=�6w   5      �� 5       -   5        $ btnMin��5       $��25��6-   $��25��68   $��Center=�6D   #��[  6_   $	��4 0q�6�   ���	#FF3D96B8��6�   Z� .��5!        $ WindowMinimize=�62   $��15��6H   $��15��6T   $��Center=�6_   $��Center=�6z   5"      �� 5#      -   5        $ btnMax��5#      $��25��6-   $��25��68   $��Center=�6D   #��[  6_   $	��4 0q�6�   ���	#FF3D96B8��6�   Z� .��5$        $ WindowMaximize=�62   $��15��6H   $��15��6T   $��Center=�6_   $��Center=�6z   5%      �� 5'      -   5        $ 	btnCerrar��5'      $��25��60   $��25��6;   $��Center=�6G   #��[  6b   $��3 2 2 2q�6�   ���	#FF3D96B8��6�   Z� .��5(        $ Power=�62   $��15��6?   $��15��6K   $��Center=�6V   $��Center=�6q   5)      5*      5+      � 5-      -   5         �Name$ 
gPrincipal��5-      $��1��6'   $��
10 10 10 0q�64   � 5.      $��2��6   .+�5/      �� $��Usuario: Admin1��6   
�������$
��Left=�6G   $
��15 0q�6b   $��Center=�6p   $y�	Collapsed=�6�   �� 50      $��Hecho por B. Q. G.��6   
�������$��Right=�6J   $
��15 0q�6f   $��Center=�6t   $y�	Collapsed=�6�   51      53      57      58      