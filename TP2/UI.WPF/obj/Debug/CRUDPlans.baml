   M S B A M L   `   `   `  ����A  =UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UI.WPFUI.WPF  5          UI.WPF.CrudPlans   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:UI.WPF     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  	CRUDPlans��5      .��5      ]� $��20q�6   .+�5   
   ]� $	��Top=�6   .+�5      �� $
��Left=�6   $��ID��6.   �� 5      -   5         ��Name$ TxtId��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $��Description��6.   �� 5      -   5        $ TxtDescription��5      $
��Left=�5       �� TextWrapping$
 Wrap=�5      5      ]� 5   
   $	��Top=�6   .+�5      �� $
��Left=�6   $��	Specialty��6.   �� 5      -   5        $��CboSpecialties��5       �� DisplayMemberPath$ Description��5      $
��left=�5      5      �� 5    
   $��10q�6   $��Center=�5!      $	��Top=�5"       �� Orientation$ 
Horizontal=�5#      .+�5$      �� -   5        $��Create��5$   *   �� 5%      -   5        $��Search��5%   *   �� 5&      -   5        $��Modify��5&   *   �� 5'      -   5        $��Delete��5'   0   5(      �� 5)   
   -   5         ��Name$ AllPlansList��5)       �� View 5*      �� 5+      -	   5        AllPlansGridView�� �� AllowsColumnReorder .  �� ColumnHeaderToolTip$ Plans Information��5-      5/      50      51      