   M S B A M L   `   `   `  ����K  GMusicSearchFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MusicSearchFinal.MVVM.ViewsMusicSearchFinal.MVVM.Views  5      S.clr-namespace:MusicSearchFinal.MVVM.Components MusicSearchFinal.MVVM.Components  6F   S.clr-namespace:MusicSearchFinal.MVVM.ViewModels MusicSearchFinal.MVVM.ViewModels  6�   +    %MusicSearchFinal.MVVM.Views.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MusicSearchFinal.MVVM.Views     5      E
components.clr-namespace:MusicSearchFinal.MVVM.Components     6F   E
viewmodels.clr-namespace:MusicSearchFinal.MVVM.ViewModels     6�   ���#00897b.��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Center=�5      $��48(�5      $��MusicSearcherDB��5      $
��Bold"�6%   $��Italic$�67   $��
0 120 0 0 q�5      � 5    
   $��1��6   $��0 20 0 0q�6   $	��400��5!       � IsSharedSizeScope .   5#      �� 5$      $
��auto �6    �� 5%      $
��auto �6    �� 5&      $
��auto �6    .+�5*      � $��0��6    � ColumnDefinitions 5+      �� 5,      $
��auto �6'    z� SharedSizeGroup$ Label��64   �� 5-      $��* �6'   .+�50      �� $��0��6   $��Imię��6,   
�������68   �� 51      $��1��6   $��10,0,0,0q�6*   ��52      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�53      � 56      $��1��6   $��0,10,0,0q�6     57      �� 58      $
��auto �6'   $ Label��64   �� 59      $��* �6'   .+�5<      �� $��0��6   $��Nazwisko��6,   
�������6<   �� 5=      $��1��6   $��10,0,0,0q�6*   ��5>      �� *	Surname+$ PropertyChanged=�5@      5N      �� 5Q   
   $��2��6   $��0 20 0 0q�6"    �� Orientation$ 
Horizontal=�64   $��Center=�6M   .+�5R      �� $��2��6   $��0 0 5 0q�6"   $��Center=�5S      $��Login��5U      ���#282828
���������5T      �� *LoginCommand+5U   2   �� 5Z      $��2��6   $��5 0 0 0q�6"   $��Center=�5[      $��Register��5]      ���#282828
���������5\      �� *NavigateToRegisterView+5]   5   5^      5b      5c      