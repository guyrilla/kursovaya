   M S B A M L   `   `   `  ����F  Bapplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:applicationapplication  5      1    +application.BasicAccountDetailsRegisterPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:application     5        N� Title$%  BasicAccountDetailsRegisterPage��5	      .��5      � .+�5   
   �� ._�5      �� $��Center=�6   $��Center=�66   $	��300��6Q   .+�5      �� $��Регистрация��6   $��24(�6/   
�������$��0,0,0,20q�6P   $��Center=�6b   � 5      $��0,0,0,10q�6   .+�5      � .+�5      �� ���#444$��1q�64    �� CornerRadius$ 5��6H   ���#2c2a2c._�5      �� -   5         ��Name$ EmailTextBox��5   &   $
��Auto��5   &   $��30��5   &   
������ 
�������5   &   5      �� 5      -   5         ��Name$ EmailPlaceHolder��5   $   $��Email��6>   
�������$��Center=�6]   $��5,0,0,0q�6x    J� IsHitTestVisible .  6�   5      5      � 5      $��0,0,0,10q�6   .+�5       � .+�5!      �� ���#444$��1q�64   $ 5��6H   ���#2c2a2c._�5"      �� -   5        $ LoginTextBox��5"   &   $
��Auto��5#   &   $��30��5$   &   
������ 
�������5(   &   5)      �� 5*      -   5        $ LoginPlaceHolder��5*   $   $��
Логин��6>   
�������$��Center=�6]   $��5,0,0,0q�6x    .  6�   5+      5,      � 5.      $��0,0,0,20q�6   .+�5/      � .+�50      �� ���#444$��1q�64   $ 5��6H   ���#2c2a2c._�51      G� -   5         G�Name$ PasswordTextBox��51   *   $
��Auto��52   *   $��30��53   *   
������ 
�������57   *   58      �� 59      -   5        $ PasswordPlaceHolder��59   $   $��Пароль��6A   
�������$��Center=�6a   $��5,0,0,0q�6|    .  6�   5:      5;      �� 5=      -   5         ��Name$ 
NextButton��5=      $��
Далее��5>      $
��Auto��5?      ���#FF6A00
�������$��0q�5B      $��10q�5C      $��0,0,0,10q�5D       � Cursor$
 Hand��5E      $
��Bold"�5F      5G      �� 5I      -   5        $ LoginTextBlock��5I      $1��+Уже есть аккаунт? Войти!��5J      
�������$��Center=�5L      $��0,10,0,0q�5M      $��12(�5N      $
 Hand��5O       J� InputBindings 5Q      d� 5R      	 d� Gesture$	 	LeftClicka�6'   
 �� Command
 6;   �� *LoginCommand+5T      5U      5V      5W      5X      