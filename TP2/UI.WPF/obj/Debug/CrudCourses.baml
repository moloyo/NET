   M S B A M L   `   `   `  ����A  =UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UI.WPFUI.WPF  5          UI.WPF.CrudCourses   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:UI.WPF     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  
CrudCourse��5      .��5      ]� $��20q�6   .+�5   
   ]� $��Center=�6   $	��Top=�5      ��.  .+�5      �� $
��Left=�6   $��ID��6.   �� 5      -   5         ��Name$ TxtId��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $
��Year��6.   �� 5      -   5        $ TxtYear��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $��Quota��6.   �� 5      -   5        $ TxtQuota��5      $��55��5      $��Center=�5      $
��Left=�5      �� 5      $
��Left=�6   $��	Specialty��6.   �� 5       -   5        $��CboSpecialties��5       $	��150��5!       �� DisplayMemberPath$ Description��5"      $
��Left=�5#      5$      �� 5%      $
��Left=�6   $
��Plan��6.   �� 5&      -   5        $��CboPlans��5&      $	��150��5'      $ Description��5(      $
��Left=�5)      5*      5+      ]� 5,   
   $��0,10,0,0q�6   $��Center=�5-      $	��Top=�5.      ��.  .+�50      �� $
��Left=�6   $��Subject��6.   �� 51      -   5        $��CboSubjects��51      $	��150��52      $ Description��53      $
��Left=�54      55      �� 56      $
��Left=�6   $��	Commision��6.   �� 57      -   5        $��CboCommissions��57      $	��150��58      $ Description��59      $
��Left=�5:      5;      �� 5=   
   $��10q�6   $��Center=�5>      $	��Top=�5?       �� Orientation$ 
Horizontal=�5@      .+�5A      �� -   5        $��Create��5A   *   �� 5B      -	   5        $��Search��5B   *   �� 5C      -
   5        $��Modify��5C   *   �� 5D      -   5        $��Delete��5D   0   5E      �� 5F   
   -   5         ��Name$ AllCoursesList��5F       �� View 5G      �� 5H      -   5        AllCoursesGridView�� �� AllowsColumnReorder .  �� ColumnHeaderToolTip$ Courses Information��5J      5L      5M      5N      