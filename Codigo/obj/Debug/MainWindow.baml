   M S B A M L   `   `   `  ����A  =LabIPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LabIPOLabIPO  5   	       LabIPO.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:LabIPO     5   	     � Title$  Inicio de sesión��5   	   $	��450��6"   $	��500��6/   $��Stretch=�6;   $��Stretch=�6`    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�   ��.  � SizeToContent$ Height=�6�    � UseLayoutRounding .  ��6   Z� .��5	      � $
��Left=�6   $	��426��6&   $��-3,-2,-3,-3q�63   $	��Top=�6H   $	��500��6`   ��5
   
   �� 5       �� ImageSource$  imagenes/hombre_login2.jpg��6    � RowDefinitions 5   
   �� 5      $	��28* �6   �� 5      $	��52* �6   �� 5      $	��44* �6   �� 5      $	��52* �6   �� 5      $	��37* �6    � ColumnDefinitions 5   
   �� 5      $	��38* �6   �� 5      $	��51* �6   �� 5      $	��36* �6   .+�5   
   �� -   5         ��Name$ btnConectar��5      	 � ToolTip$,	 &Acceder a la aplicación/Go to the app��6&   $��CONECTAR��6V   $��	3,8,18,27q�6i   $��20(�6�   $
��Bold"�6�   4  .System.Windows.Automation.AutomationProperties
   Name$
 btnConectar��6�   $��2��6�   $��4��6�   �� 5   
   -   5        $ 
btnEspanol��5      $*	 $Cambiar a Español/Change to Spanish��6%   $�� ��6S   $��
21,8,78,27q�6^    �� IsCancel .  $
 
btnEspanol��6�   $��4��6�   ��5      �� 5      $ imagenes/Español.png��6   5      �� 5   
   -   5        $ 	btnIngles��5      $)	 #Cambiar a Inglés/Change to English��6$   $�� ��6Q   $��	90,8,7,27q�6\    . $
 	btnIngles��6   $��Stretch=�6�   $��Stretch=�6�   $��4��6  ��5       �� 5!      $ imagenes/Inglés.png��6   5#      �� 5$   
   $��10,1.979,18,2q�6   $��imagenes/usuario.png��6'   $
 
imgEntrada��6E   $��1��6l   $��1��6|   $��1��6�    J� OpacityMask 5%      �� 5&      $ imagenes/usuario.png��6   5(      �� 5)   
   -   5        $ btnSalir��5)      $	 
Salir/Exit��6#   $
��Left=�68   $��76,6,0,0q�6S   $	��Top=�6e   $��Stretch=�6}   $��Stretch=�6�   $
 btnSalir��6�   $��50��6  $��50��6&   J� RenderTransformOrigin$ 0.16,0.7&�65  $��2��6V  $��1��6f  ��6�   Z� ��5*      �� 5+      $ imagenes/login.png��6   5-      �� 5.   
   -   5         ��Name$ 
lblUsuario��5.      $��Usuario��6$   $��51,102,56,50q�66   ��. $��22(�6q   $
��Bold"�6   
���   �$
 
lblUsuario��6�   $��92��6�   $��40��6�   $��Center=�6�   $��Center=�6  $��1��6.  $��1��6>  $��2��6K  ��6\  Z� �� 5/   
   -   5         ��Name$ 
txtUsuario��5/      $��10,40,18,10q�6'    �� TextWrapping$
 Wrap=�6<   $��22(�6P   $
 
txtUsuario��6^   $	��176��6�   $��38��6�   $��1��6�   $��2��6�   �� 50   
   -   5        $ lblContrasena��50      $��Contraseña��6'   $��31,10,41,54q�6<   ��. $��22(�6v   $
��Bold"�6�   
���   �$
 lblContrasena��6�   $	��128��6�   $��40��6�   $��Center=�6�   $��Center=�6  $��1��67  $��3��6G  ��6T  Z� G� 51   
   -   5         G�Name$ txtContrasena��51      $��10,56,18,10q�6-   $ 1.354,-1.375&�6B   $��22(�6g   $
 txtContrasena��6u   $	��176��6�   $��38��6�   $��1��6�   $��3��6�   52      53      