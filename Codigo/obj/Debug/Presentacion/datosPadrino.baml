   M S B A M L   `   `   `  ����A  =LabIPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LabIPO.PresentacionLabIPO.Presentacion  5   	   &     LabIPO.Presentacion.datosPadrino   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LabIPO.Presentacion     5   	     � Title$  datosPadrino��5   	   $	��500��6   $	��500��6+    � SizeToContent$ Manual=�67    � WindowStartupLocation$ CenterScreen=�6N    � 
ResizeMode$ NoResize=�6s   ��5	      �� 5
   
    �� ImageSource$. (/imagenes/datos-personales_padrino_c.JPG��6   .��5      (� .��5   
   � .+�5      �� -   5         ��Name$ nombrePadrino��5      $
��Left=�6-   $��26��6H   $��
180,41,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��141��6�   {�.  6�   �� 5      -   5        $ apellidosPadrino��5      $
��Left=�60   $��26��6K   $��
180,72,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��141��6�   {�.  6�   �� 5      -   5        $ emailPadrino��5      $
��Left=�6,   $��26��6G   $��180,103,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��141��6�   {�.  6�   �� 5      -   5        $ 
dniPadrino��5      $
��Left=�6*   $��26��6E   $��180,134,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��141��6�   {�.  6�   �� 5      -   5        $ domicilioPadrino��5      $
��Left=�60   $��26��6K   $��180,165,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��141��6�   {�.  6�   �� 5      -   5        $ telefonoPadrino��5      $
��Left=�6/   $��26��6J   $��180,196,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $	��141��6�   {�.  6�   �� 5      -   5        $ aportacionPadrino��5      $
��Left=�61   $��26��6L   $��180,227,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��141��6�   {�.  6�   �� 5      -   5        $ pagoPadrino��5      $
��Left=�6+   $��26��6F   $��180,258,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��141��6�   {�.  6�   �� 5      -	   5        $ cuentaPadrino��5      $
��Left=�6-   $��26��6H   $��180,289,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��141��6�   {�.  6�   �� 5      $��Nombre��6   $
��Left=�6%   $��
-24,41,0,0q�6@   $	��Top=�6T   $	��125��6l   $��Right=�6x   �� 5      $��	Apellidos��6   $
��Left=�6(   $��
-24,72,0,0q�6C   $	��Top=�6W   $	��125��6o   $��Right=�6{   �� 5      $��Email��6   $
��Left=�6$   $��-24,103,0,0q�6?   $	��Top=�6T   $	��125��6l   $��Right=�6x   �� 5      $	��DNI��6   $
��Left=�6"   $��-24,134,0,0q�6=   $	��Top=�6R   $	��125��6j   $��Right=�6v   �� 5      $��	Domicilio��6   $
��Left=�6(   $��-24,165,0,0q�6C   $	��Top=�6X   $	��125��6p   $��Right=�6|   �� 5      $��	Teléfono��6   $
��Left=�6'   $��-24,196,0,0q�6B   $	��Top=�6W   $	��125��6o   $��Right=�6{   �� 5      $��Aportación mensual��6   $
��Left=�61   $��-24,227,0,0q�6L   $	��Top=�6a   $	��125��6y   $��Right=�6�   �� 5      $��
Forma pago��6   $
��Left=�6)   $��-24,258,0,0q�6D   $	��Top=�6Y   $	��125��6q   $��Right=�6}   �� 5      $��Número cuenta��6   $
��Left=�6,   $��-24,289,0,0q�6G   $	��Top=�6\   $	��125��6t   $��Right=�6�   �� 5       $$��Fecha comienzo
apadrinamiento��6   $
��Left=�6E   $��-24,320,0,0q�6`   $	��Top=�6u   $	��125��6�   $��Right=�6�   �� 5!      $��MÁS INFORMACIÓN PADRINO��6   $��Center=�66   $��0,10,0,0q�6S   $	��Top=�6e   $
��Bold"�6}    J� RenderTransformOrigin$ 0.347,0.473&�6�   �� 5"      -
   5         ��Name$ 
imgPadrino��5"      $��Stretch=�6(   $	��108��6F   $��	0,351,0,0q�6S   $��Bottom=�6f   $	��140��6�   ��6�   �� *foto+(  "System.Windows.Controls.DatePicker  5#      -   5        	  Name$	 fechaPadrino��5#      $
��Left=�6/   $��180,320,0,0q�6J   $	��Top=�6_   $��26��6w   $	��141��6�   {�.  6�   5%      5&      5(      