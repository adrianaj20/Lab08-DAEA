   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $��	txtFilter��5
      $
��Left=�6#   $	��Top=�6>   $	��200��6V   $��	20,20,0,0q�6b   $�� ��6u   �� 5   
   -   5        $��Filtrar��5      $
��Left=�6#   $	��Top=�6>   $	��100��6V   $��
230,20,0,0q�6b   6v   �� 5   
   -   5        $��lvCustomers��5      $
��Left=�6&   $	��Top=�6A   $	��750��6Y   $	��350��6e   $��	20,60,0,0q�6r    �� View 5      �� 5      .P�5      �� $��Customer ID��6%    �� Width$	 100��6:    �� DisplayMemberBinding 6F   �� *
CustomerId+�� 5      $
��Name��6%   $	 200��63    6?   �� *Name+�� 5      $��Address��6%   $	 200��66    6B   �� *	Address+�� 5      $��Phone��6%   $	 100��64    6@   �� *Phone+�� 5      $��Active��6%   $	 100��65    6A   �� *Active+5      5      5      5      