   M S B A M L   `   `   `  ����K  GMusicSearchFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MusicSearchFinal.MVVM.ViewsMusicSearchFinal.MVVM.Views  5      .    (MusicSearchFinal.MVVM.Views.RegisterView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MusicSearchFinal.MVVM.Views     5      ���#00897b.��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Center=�5      $��48(�5      $��Rejestracja��5      $
��Bold"�6    $��Italic$�62   $��
0 120 0 0 q�5      ���#2828286(   � 5   
   $��1��6   $��0 20 0 0q�6   $	��400��5       � IsSharedSizeScope .   5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    .+�5$      � $��0��6    � ColumnDefinitions 5%      �� 5&      $
��auto �6'    z� SharedSizeGroup$ Label��64   �� 5'      $��* �6'   .+�5*      �� $��0��6   $��Imię��6,   
�������68   �� 5+      $��1��6   $��10,0,0,0q�6*   ��5,      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5-      � 50      $��1��6   $��0,10,0,0q�6     51      �� 52      $
��auto �6'   $ Label��64   �� 53      $��* �6'   .+�56      �� $��0��6   $��Nazwisko��6,   
�������6<   �� 57      $��1��6   $��10,0,0,0q�6*   ��58      �� *	Surname+$ PropertyChanged=�5:      5H      �� 5K   
   $��2��6   $��0 20 0 0q�6"    �� Orientation$ 
Horizontal=�64   $��Center=�6M   .+�5L      �� $��2��6   $��0 0 5 0q�6"   $��Center=�5M      $��Login��5O      ���#282828
���������5N      �� *NavigateToLoginView+5O   2   �� 5T      $��2��6   $��5 0 0 0q�6"   $��Center=�5U      $��Register��5W      ���#282828
���������5V      �� *Add+5W   5   5X      5\      5]      