   M S B A M L   `   `   `  ����  wpf_Pong    wpf_Pong.Lobby   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Lobby��5   	   $	��600��6   $	��800��6$    � 
ResizeMode$ CanMinimize=�60   .��5      � $
��Left=�6   $	��800��6&   $	��600��62   $��
0,0,-8,-31q�6?   $	��Top=�6S   .+�5   
   �� -   5         ��Name$ lvRooms��5      $
��Left=�6$   $��10,10,0,143q�6?   $	��425��6T    J� RenderTransformOrigin$ 0.539,0.558&�6`    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5       �� View 5
      �� 5      .P�5      �� 5      5      �� 5   
   $
��Join��6   $
��Left=�6    $��	9,466,0,0q�6;   $	��Top=�6N   $��75��6f   $��26��6q   �� 5   
   -   5         ��Name$ 	btnCreate��5      $��Create Room��6$   $
��Left=�6:   $��
98,467,0,0q�6U   $	��Top=�6i   $��75��6�   $��26��6�   � 5   
   -   5         �Name$ GRoomNotification��5      $��11,141,367,0q�6*   $	��194��6@   $	��Top=�6M   .+�5      �� $��	NO ROOMS!��6   $��99,59,99,45q�6(   $��Simplified Arabic)�6=   $��40(�6\   5      �� 5   
   -   5         ��Name$ lblUsername��5      $��CountConnectedUsers��6%   $
��Left=�6C   $��182,466,0,0q�6^   $	��Top=�6s   $	��249��6�   �� 5   
   -   5        $ lblRecentMessage��5      $��RecentMessage��6*   $
��Left=�6B   $��443,459,0,0q�6]   $	��Top=�6r   $	��331��6�   � 5   
   $��446,11,14,143q�6   .+�5      �� -   5        	 ��Name$	 tbChat��5      $��
0,396,15,0q�6&   
 �� TextWrapping$

 Wrap=�6:    �� 	UndoLimit$ 5��6N    �� 	IsEnabled .  � ToolTip$ Input your text....��6x   .��6�    5        5      .��5   "   5      �� 5      -   5        $	 tbChatLobby��5      $	��377��6+   $

 Wrap=�68   $	��Top=�6L   $ 0��6d    �� 
IsReadOnly . $��0,0,15,0q�6�   .��6�    5        5      .��5    "   5!      5"      5$      5%      