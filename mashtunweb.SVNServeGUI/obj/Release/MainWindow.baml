   M S B A M L   `   `   `  ����   SVN Gui Lite+    %mashtunweb.SVNServeGUILite.MainWindow   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    -     � Title$  SVN Gui Lite��$	��354��$	��644�� � Icon$ Images/SVNServeGUI.ico�� � 	Resources    Data��%   &	        S� .��� ���	#FFC2D8FA.+�o� -   $��MainMenu��$��20��$	��Top=����	#FFC2D8FA-  'System.Windows.Input.KeyboardNavigation   	IsTabStop .  .@�m� $��_File�� .  .@�m� -   $��CloseMenuItem��$��_Close�� � ToolTip _� .��Close Everything.m� -   $��
_toolsMenu��$��_Tools��.@�m� -   $��_options��$��_Options�� _� .��Open Options dialog.m� -   $��	_helpMenu��$��_Help��.@�m� -   $��_about��$��	_About...�� _� .��Open About dialog.�� $��2,20,2,2q� .  .@��� -   $��_serverDaemonTab��$��Server Daemon�� .  .���� -	   $��canvas1��$	��300��$	��100��.+��� -
   $��
playButton�� �� Left$ 0��
 �� Top$ 0��$	��100��$	��100��$��Center=�.���� -   $��playButtonImage��$��Images\svn-start.png���� -   $��
stopButton��$	 200��$ 0��$	��100��$	��100��$��Center=�.���� -   $��stopButtonImage��$��Images\svn-stop.png���� -   $��_newRepoTab��$��New Repo�� .  .���  � DataContext# [  .+��� -   $��_fsComboBox��$��23��$��
132,39,0,0q�$	��Top=� �� SelectedIndex$ 0��$
��Left=�$	��120��.@��� .��fsfs�� .��BDB�� -   $��_fsTypeLabel��$��23��$
��Left=�$��6,39,0,0q�$	��Top=�$	��120��$��File System Type:���� -   $��label1��$��28��$��	0,6,188,0q�$	��Top=�$��14(�$
��Bold"�$��Right=�$	��220��$!��Create a New SVN Repository���� -   $��label2��$��23��$
��Left=�$��6,68,0,0q�$	��Top=�$	��120��$��Repository Path:���� $��0,0,0,26q�$��2��$��Bottom=��� -   $��_statusLabel��$�� ��$��Bottom=�$��23.277��$��	0,0,157,0q�� -   $��_progressBar��$��Right=�$��0,0,6,3q�$��Bottom=�$	��145��$��17���� -   $��label3��$��	6,122,0,0q�$
��Left=�$��43��$��22��$	��Top=�.��Users�� -   $��_userListBox��$��6,149.723,0,0q�$
��Left=�$	��120��$��79��$	��Top=����� 	 �� Path$	 Users����� .R�� .+��� ���� *Key+�� -   $��label4��$
��Left=�$��132,121,0,118.723q�$��71��.��
User Name:�� -   $��label5��$
��Left=�$��
132,0,0,89q�$��71��$��23��$��Bottom=�.��	Password:�� -   $��_removeUserButton��$
��Left=�$��199,206,0,0q�$��75��$��22.723��$	��Top=� .  .��Remove User�� -   $��_createRepoButton��
   TabIndex$
 4��$��23��$��Right=�$��	0,0,15,34q�$��Bottom=�$��75��.��Create Repo�� -   $��_addUserButton��$
 3��$��199,180,0,0q�$
��Left=�$��75��$��22.723��$	��Top=�.��
Add UserG� -   $��_passwordBox��$
 2��$��199,150.723,15,0q� G� PasswordChar$ *��$��23��$	��Top=��� -   $��_userNameBox��$
 1��$��199,122,15,0q�$��23��$	��Top=��� -   $��_pathTextBox��$
 0��$��23��$��132,68,15,0q�$	��Top=�.��	c:\svn\