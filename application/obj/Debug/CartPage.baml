   M S B A M L   `   `   `  ����F  Bapplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:applicationapplication  5          application.CartPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:application     5      -   5          N� Title$  CartPage��5	       � 	Resources 5         RemoveButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value  OrderButtonStyle��%  &	        &	 �    �� 5   
   " ��6*   .�5      ��  � �� �#FF6A006+   �� 5       � ��
 �����6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 16(�6)   �� 5       � ��$ 5q�6'   �� 5       � �� �#FF6A006,   �� 5       � ��$ 2q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   5      5      5!       5"      P� 5#       �@J�IsMouseOver	 . . �5$      ��  � �� �#FF450063   5%      P� 5&       � ��	 . . �5'      ��  � �� �#CC3E0063   5(      5*      �� 5+   
   " ��6)   .�5,      ��  � �� �#FF45006+   �� 5-       � ��
 �����6+   �� 5.       � ��$ 15,10q�6(   �� 5/       � ��$ 18(�6)   �� 50       � ��$ 10q�6'   �� 51       � ��
 �   �6,   �� 52       � ��$ 2q�60   �� 53       �@�Cursor$
 Hand��6'   �� 54       � �� 55      �� 56      " ��6&   .R�57      �� #��z��6!   #��z��58   !   #��z��59   !   $ 20��5:   !   ._�5;      �� $��Center=�6/   $��Center=�5<   /   5=      5>      5@       5A      P� 5B       �@J�IsMouseOver	 . . �5C      ��  � �� �#75210263   5D      P� 5E       � ��	 . . �5F      ��  � �� �#75210263   5G      5I      5J      .��5L      �� $
��0,10q�6   $
��Auto=�6!   .��5M   
   � $��Center=�6   
 � RowDefinitions
 5N      �� 5O      $��* �6    �� 5P      $��* �6    .+�5R      �� $��0,0,0,20q�6   $��0��6+   .+�5S      �� -   5         ��Name$ BasketElementsList��5S   #   ��5T      �� 5U      .R�5V   "   � 5W      ��5Y      �� 5Z      .R�5[   "   �� $��5q�6)    �� Padding$ 10q�64   ���#FF6A00$��2q�5\   ?   $ 5��5]   )   ._�5^   &   � 
 5_   *   �� 5`   .   $
��Auto �6<   �� 5a   .   $
��Auto �6<   �� 5b   .   $
��Auto �6<   �� 5c   .   $
��Auto �6<   .+�5e   *   �� $	��300��5f   0   $	��300��6<   $��UniformToFill=�5g   0   $��0��5h   0   ��5e   0   �� *	ImagePath+5h   0   �� 5i   *   
�������$��0,5,0,0q�5k   4   $��Center=�5l   4   $��1��5m   4   ��5i   4   �� *ElementName+5m   4   �� 5n   *   
�������$��0,5,0,0q�5p   4   $��Center=�5q   4   $��2��5r   4   ��5n   4   �� *ElementPrice+ �� StringFormat$ Цена: {0} руб.��5r   4   �� 5s   *   -   5        $&�� Убрать из корзины��5s   1   $��3��5t   1   $	��200��5u   1   $��50��5v   1   #��[  5w   1   ��5y   1   �� 5z   '   5{   #   5|      5~      5      �� 5�      -   5        $��Сделать заказ��5�      $	��400��5�      $��60��5�      #��[ 5�      $��Center=�5�      $��Bottom=�5�      $��0,20,0,0q�5�      $��1��5�      5�      5�      5�      5�      