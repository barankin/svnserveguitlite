   M S B A M L   `   `   `  ����  SVN Gui Lite+    %mashtunweb.SVNServeGUILite.MainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          � Title$  SVN Gui Lite��5      $	��354��6   $	��644��6'    � Icon$ Images/SVNServeGUI.ico��5   	    � 	Resources 5         Data��%   &	        S� 5   
   6   5      .��5	      � ���	#FFC2D8FA.+�5
   
   o� -   5        $��MainMenu��5
      $��20��6   $	��Top=�6+   ���	#FFC2D8FA-  'System.Windows.Input.KeyboardNavigation   	IsTabStop .  .@�5      m� $��_File��6    .  .@�5      m� -   5        $��CloseMenuItem��5      $��_Close��60    � ToolTip 5      _� 5      .��6"   Close Everything.5      5      5      m� 5      -   5        $��
_toolsMenu��5      $��_Tools��6)   .@�5      m� -   5        $��_options��5      $��_Options��6,    5      _� 5      .��6"   Open Options dialog.5      5      5      m� 5      -   5        $��	_helpMenu��5      $��_Help��6(   .@�5      m� -   5        $��_about��5      $��	_About...��6)    5      _� 5       .��6"   Open About dialog.5"      5$      5%      5&      �� 5'   
   $��2,20,2,2q�6    .  .@�5(      �� -   5        $��_serverDaemonTab��5(      $��Server Daemon��6.    .  .��5)      �� -	   5        $��canvas1��5)      $	��300��6(   $	��100��64   .+�5*      �� -
   5        $��
playButton��5*   I    �� Left$ 0��6   
 �� Top$ 0��6-   $	��100��6<   $	��100��6[   $��Center=�6g   .��5+      �� -   5        $��playButtonImage��5+       $��Images\svn-start.png��67   6W   5,      �� 5-      -   5        $��
stopButton��5-   K   $	 200��6   $ 0��6/   $	��100��6>   $	��100��6]   $��Center=�6i   .��5.      �� -   5        $��stopButtonImage��5.       $��Images\svn-stop.png��67   6V   5/      50      51      �� 52      -   5        $��_newRepoTab��52      $��New Repo��6)    .  .��53      �  � DataContext# [  6   .+�54      �� -   5        $��_fsComboBox��55      $��23��54      $��
132,39,0,0q�6+   $	��Top=�55   2    �� SelectedIndex$ 0��56      $
��Left=�61   $	��120��57      .@�58      �� .��6'   fsfs6-   �� 59      .��6'   BDB6,   5:      �� 5;      -   5        $��_fsTypeLabel��5=   .   $��23��5;      $
��Left=�5<      $��6,39,0,0q�5=      $	��Top=�5>      $	��120��5?      $��File System Type:��6(   �� 5@      -   5        $��label1��5A      $��28��5@      $��	0,6,188,0q�6(   $	��Top=�5A   *   $��14(�5B      $
��Bold"�6*   $��Right=�5C      $	��220��5D      $!��Create a New SVN Repository��6(   �� 5E      -   5        $��label2��5F   .   $��23��5E      $
��Left=�6(   $��6,68,0,0q�5F      $	��Top=�5G      $	��120��64   $��Repository Path:��5H      �� 5I      $��0,0,0,26q�6    $��2��62   $��Bottom=�6=   �� 5J      -   5        $��_statusLabel��5J      $�� ��60   $��Bottom=�5K      $��23.277��67   $��	0,0,157,0q�5L      � 5M      -   5        $��_progressBar��5N   3   $��Right=�5M   "   $��0,0,6,3q�5N   "   $��Bottom=�5O   "   $	��145��5P   "   $��17��6.   �� 5Q      -   5        $��label3��5Q   /   $��	6,122,0,0q�6   $
��Left=�6=   $��43��5R      $��22��6'   $	��Top=�63   .��6K   Users6R   �� 5S      -   5        $��_userListBox��5S   5   $��6,149.723,0,0q�6   $
��Left=�5T      $	��120��69   $��79��6E   $	��Top=�5V      ��5U      �� 	 �� Path$	 Users���5X      �� 5Y      .R�5Z   "   � .+�5[   &   �� ��60   �� *Key+5\   #   5]      5_      �� 5`      -   5        $��label4��5a   7   $
��Left=�5`      $��132,121,0,118.723q�5a      $��71��5b      .��6'   
User Name:63   �� 5c      -   5        $��label5��5d   0   $
��Left=�5c      $��
132,0,0,89q�5d      $��71��6>   $��23��6I   $��Bottom=�5e      .��67   	Password:6B   �� 5f      -   5        $��_removeUserButton��5g      $
��Left=�5f      $��199,206,0,0q�68   $��75��5g   6   $��22.723��6A   $	��Top=�5h       .  .��6z   Remove User6�   �� 5i      -   5        $��_createRepoButton��5i   x   
   TabIndex$
 4��6   $��23��6=   $��Right=�6I   $��	0,0,15,34q�6e   $��Bottom=�6�   $��75��6�   .��6�   Create Repo6�   �� 5j      -   5        $��_addUserButton��5j   R   $
 3��6   $��199,180,0,0q�6=   $
��Left=�6h   $��75��6�   $��22.723��6�   $	��Top=�6�   .��6�   
Add User6�   G� 5k      -   5        $��_passwordBox��5k   m   $
 2��6"   $��199,150.723,15,0q�6B    G� PasswordChar$ *��6\   $��23��6�   $	��Top=�6�   �� 5l      -   5        $��_userNameBox��5l   T   $
 1��6   $��199,122,15,0q�6>   $��23��6h   $	��Top=�6t   �� 5m      -   5        $��_pathTextBox��5m   _   $
 0��6   $��23��6>   $��132,68,15,0q�6J   $	��Top=�6s   .��6�   	c:\svn\6�   5n      5o      5p      5q      5r      