   M S B A M L   `   `   `  ����G  CAutoClicker1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AutoClicker1AutoClicker1  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.24.16411, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7pQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45GalaSoft.MvvmLight.Command 5      ?$clr-namespace:AutoClicker1.ViewModelAutoClicker1.ViewModel  5	      !    AutoClicker1.View.ColorView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -local2clr-namespace:AutoClicker1     5      ^ePclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      acmdQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45     5      :	ViewModel$clr-namespace:AutoClicker1.ViewModel     5	        � 	Resources  5       �� 
TargetType �� Property �� Value��%�   'Q�       �� 5   
   " Q�6   .�5      ��  � �� 6+   �� *
Background+5      �� 5       � �� 6+   �� *
Foreground+5      5      5      .��5      � .+�5   
   �� $��Center=�6   $��0,50,0,0q�61   $F��@This page will minimize upon your start/stop bind being pressed.��6C   6�   � 5   
   $	��250��6   $��50��6   $��0,0,0,50q�6'   .+�5      �� $��Center=�6   $	��100��62   $��20��6>   $��Select Color��6J   $��0,0,0,0q�6a   ��6r   �� *SelectClick+6�   5      � 5   
   $	��250��6   $��50��6   $��Center=�6'   $��0,50,0,0q�6D   .+�5       �� $��20��6B   $��20��6N    �� 	MaxLength$ 1��6Y   $
��Left=�6g   $��	100,0,0,0q�6�   ��6   ��  �� Path$ BindText� �� Mode$ TwoWay=�{�6�   �� *	IsEnabled+6�   �� 5!      $��Start/Stop Bind��6   $
��Left=�6/   $��Center=�6J   $��0,0,0,0q�6e   6x   �� 5"      $
��Left=�6   $	��100��60   $��20��6<   $��	150,0,0,0q�6e   ��6H   �� *
EditText+��6x   �� *
EditBind+6�   5#      � 5$   
   $	��200��6   $	��250��6   $��Right=�6(   $��	0,20,50,0q�6D   .+�5%      R� -   5         R�Name$ lb��5%      ��6#   �� *
ListBind+��5&      �� 5'       �� DataType    AutoClicker1.ListBoxBinder"  6P   	 �� ItemsSource	 6/   �� *
ListBind+.R�5(      �� ��6"   �� *	Content+��6;   �� *
Background+��6]   �� *
Foreground+.��6   5)      5*      5,      5-      5.      5/      