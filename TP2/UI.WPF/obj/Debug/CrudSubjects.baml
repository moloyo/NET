   M S B A M L   `   `   `  ����A  =UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UI.WPFUI.WPF  5          UI.WPF.CrudSubjects   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:UI.WPF     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  CrudSubjects��5      .��5      ]� $��20q�6   .+�5   
   ]� $��Center=�6   $	��Top=�5      ��.  .+�5      �� $
��Left=�6   $��ID��6.   �� 5      -   5         ��Name$ TxtId��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $��	Weekly Hs��6.   �� 5      -   5        $ TxtWhs��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $��Total Hours��6.   �� 5      -   5        $ TxtThs��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $��	Specialty��6.   �� 5       -   5        $��CboSpecialties��5       $	��150��5!      $��5,0,5,0q�5"       �� DisplayMemberPath$ Description��5#      $
��Left=�5$      5%      �� 5&      $
��Left=�6   $
��Plan��6.   �� 5'      -   5        $��CboPlans��5'      $	��150��5(      $��5,0,5,0q�5)      $ Description��5*      $
��Left=�5+      5,      ]� 5.   
   $	��Top=�6   .+�5/      �� $
��Left=�6   $��Description��6.   �� 50      -   5        $ TxtDescription��50      $��5q�51      $��Center=�52      $
��Left=�53       �� TextWrapping$
 Wrap=�54      55      �� 57   
   $��10q�6   $��Center=�58      $	��Top=�59       �� Orientation$ 
Horizontal=�5:      .+�5;      �� -   5        $��Create��5;   *   �� 5<      -   5        $��Search��5<   *   �� 5=      -	   5        $��Modify��5=   *   �� 5>      -
   5        $��Delete��5>   0   5?      �� 5@   
   -   5         ��Name$ AllSubjectsList��5@       �� View 5A      �� 5B      -   5        AllSubjectsGridView�� �� AllowsColumnReorder .  �� ColumnHeaderToolTip$ Subjects Information��5D      5F      5G      5H      