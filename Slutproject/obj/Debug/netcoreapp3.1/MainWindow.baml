   M S B A M L   `   `   `  ����F  BSlutproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SlutprojectSlutproject  5   	       Slutproject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Slutproject     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��690��6)   
����� � � DataContext 5	   	   ��  �� RelativeSource �� *Self+.��5      � ���#252323 � ColumnDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��300 �6   �� 5      $��30 �6   �� 5      $	��150 �6   �� 5      $	��150 �6   �� 5      $��30 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��30 �6   .+�5   
   �� -   5        
����ح�$��50��5   <   $	��150��6H   $��6��6T   $��4��6a   .��6q   EXIT6w   �� 5    
   -   5        
����ح�$��50��5    (   $	��150��64   $��6��6@   $��3��6M   .��6r   RESET SCORE6   �� 5!   
   -   5        
����ح�$��50��5!   ?   $	��300��6K   $��5��6W   $��3��6d   $��2��6t   .��6�   
NEW GAME6�   �� 5"   
   -   5        $��
PlayerXBox��5"      
����ح�$��50��6=   $	��150��6I   $��1��6U   $��3��6b    �� TextAlignment$ Center=�6r   	PLAYER X:6�   �� 5#   
   -   5        $��
PlayerOBox��5#      
����ح�$��50��6=   $	��150��6I   $��2��6U   $��3��6b   $ Center=�6r   	PLAYER O:6�   �� 5$   
   
����ح�$��50��6+   $	��150��67   $��2��6C   $��4��6P   $ Center=�6`   ��6w   �� *ScoreO+6�   �� 5%   
   
����ح�$��50��6+   $	��150��67   $��1��6C   $��4��6P   $ Center=�6`   ��6w   �� *ScoreX+�� 5&   
   
����ح�$��50��6+   $	��150��67   $��3��6C   $��3��6P   $ Center=�6`   CURRENT PLAYER:6�   �� 5'   
   
����ح�$��50��6+   $	��150��67   $��3��6C   $��4��6P   $ Center=�6�    6`   ��  �� ElementName$ 	gameboard����6�   ��  �� Path$ CurrentPlayer�6�      Slutproject.Gameboard  5(   
   -   5          Name$ 	gameboard��5(      
�������$��1��6G   $��6��6T   $��1��6e   5)      5*      