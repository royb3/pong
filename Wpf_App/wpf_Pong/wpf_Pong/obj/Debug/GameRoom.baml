   M S B A M L   `   `   `  ����  wpf_Pong    wpf_Pong.GameRoom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  GameRoom��5   	   $	��300��6   $	��300��6'   .��5      � .+�5   
   �� $��Create Room��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V   $	��251��6n   $	��272��6{   .��5      � $
��Left=�6   $	��229��6.   $	��Top=�6;   $	��260��6S   .+�5      �� $��Name:��6   $
��Left=�6(   $��5,12,0,0q�6C   $	��Top=�6U    J� RenderTransformOrigin$ 0.605,-0.346&�6m   �� 5	      -   5         ��Name$ TB_GameRoomName��5	      $
��Left=�63   $��23��6N   $��	20,42,0,0q�6Z    �� TextWrapping$
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��222��6�    �� 	IsEnabled . 6�   �� 5
      $��Players:��6   $
��Left=�6+   $��5,73,0,0q�6F   $	��Top=�6X   $ 
0.52,0.846&�6p   	� 5      -   5         	�Name$ RB_Players_2��5      $��2��64   $
��Left=�6@   $��
20,108,0,0q�6[   $	��Top=�6o    	� 	GroupName$ Players��6�    d� 	IsChecked$
 TrueY�6�   	� 5      -   5        $ RB_Players_3��5      $��3��64   $
��Left=�6@   $��
55,108,0,0q�6[   $	��Top=�6o   $ Players��6�   	� 5      -   5        $ RB_Players_4��5      $��4��64   $
��Left=�6@   $��
89,108,0,0q�6[   $	��Top=�6o   $ Players��6�   �� 5      -   5         ��Name$ BTN_CreateRoom��5      $��Create��61   $
��Left=�6B   $��170,193,0,0q�6]   $	��Top=�6r   $��75��6�   	 �� 	IsDefault	 . 6�   �� 5      -   5        $ 
BTN_Cancel��5      $��Cancel��6-   $
��Left=�6>   $��
75,193,0,0q�6Y   $	��Top=�6m   $��75��6�   
 �� IsCancel
 . 6�   5      5      5      5      