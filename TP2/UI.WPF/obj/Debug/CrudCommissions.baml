   M S B A M L   `   `   `  ����A  =UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UI.WPFUI.WPF  5          UI.WPF.CrudCommissions   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:UI.WPF     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  CrudCommission��5      .��5      ]� $��20q�6   .+�5   
   ]� $��Center=�6   $	��Top=�5      ��.  .+�5      �� $
��Left=�6   $��ID��6.   �� 5      -   5         ��Name$ TxtId��5      $��55��5      $��5q�5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $
��Year��6.   �� 5      -   5        $ TxtYear��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $��	Specialty��6.   �� 5      -   5        $��CboSpecialties��5      $	��150��5      $��5,0,5,0q�5       �� DisplayMemberPath$ Description��5      $
��Left=�5       5!      �� 5"      $
��Left=�6   $
��Plan��6.   �� 5#      -   5        $��CboPlans��5#      $	��150��5$      $��5,0,5,0q�5%      $ Description��5&      $
��Left=�5'      5(      ]� 5*   
   $	��Top=�6   .+�5+      �� $
��Left=�6   $��Description��6.   �� 5,      -   5        $ TxtDescription��5,      $��5q�5-      $��Center=�5.      $
��Left=�5/       �� TextWrapping$
 Wrap=�50      51      �� 53   
   $��10q�6   $��Center=�54      $	��Top=�55       �� Orientation$ 
Horizontal=�56      .+�57      �� -   5        $��Create��57   *   �� 58      -   5        $��Search��58   *   �� 59      -   5        $��Modify��59   *   �� 5:      -	   5        $��Delete��5:   0   5;      �� 5<   
   -
   5         ��Name$ AllCommissionsList��5<       �� View 5=      �� 5>      -   5        AllCommissionsGridView�� �� AllowsColumnReorder .  �� ColumnHeaderToolTip$ Commissions Information��5@      5B      5C      5D      