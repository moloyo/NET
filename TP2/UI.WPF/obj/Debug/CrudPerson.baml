   M S B A M L   `   `   `  ����A  =UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UI.WPFUI.WPF  5          UI.WPF.CrudPerson   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:UI.WPF     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  CreatePerson��5      .��5      �� $	��600��6   .+�5   
   ]� .+�5      �� $	��170��6   $
��Left=�5      $��File Number��5      �� 5      -   5         ��Name$ TxtFileNumber��5      $��Center=�5       �� TextWrapping$
 Wrap=�5      5      ]� 5   
   .+�5      �� $	��170��6   $
��Left=�5      $
��Name��5      �� 5      -   5        $ TxtName��5      $��Center=�5      $
 Wrap=�5      5      ]� 5   
   .+�5      �� $	��170��6   $
��Left=�5      $��	Last Name��5       �� 5!      -   5        $ TxtLastName��5!      $��Center=�5"      $
 Wrap=�5#      5$      ]� 5%   
   .+�5&      �� $	��170��6   $
��Left=�5'      $��Address��5(      �� 5)      -   5        $ 
TxtAddress��5)      $��Center=�6*   5*      ]� 5+   
   .+�5,      �� $	��170��6   $
��Left=�5-      $��Email��5.      �� 5/      -   5        $ TxtEmail��5/      $��Center=�50      $
 Wrap=�51      52      ]� 53   
   .+�54      �� $	��170��6   $
��Left=�55      $��Phone Number��56      �� 57      -   5        $ TxtPhoneNumber��57      $��Center=�58      $
 Wrap=�59      5:      ]� 5;   
   .+�5<      �� $	��170��6   $
��Left=�5=      $��
Birth Date��5>      (  "System.Windows.Controls.DatePicker  5?      -   5          Name$ DpBirthDate��5?      $��45��5@      $��5q�5A      $��Center=�5B      $��22(�5C      5D      �� 5E   
   -   5         ��Name$ StudentOnly��5E      $y�	Collapsed=�6*   .+�5F      ]� .+�5G      �� $	��170��6   $
��Left=�5H      $��	Specialty��5I      �� 5J      -	   5        $��CboSpecialties��5J       �� DisplayMemberPath$ Description��5K      $
��Left=�5L      5M      5N      ]� 5O      .+�5P      �� $	��170��6   $
��Left=�5Q      $
��Plan��5R      �� 5S      -
   5        $��CboPlans��5S      $ Description��5T      $
��Left=�5U      $��22(�5V      5W      5X      �� 5Y   
   $��10q�6   $��Center=�5Z      $	��Top=�5[       �� Orientation$ 
Horizontal=�5\      .+�5]      �� -   5        $��Create��5]   *   �� 5^      -   5        $��Search��5^   *   �� 5_      -   5        $��Modify��5_   *   �� 5`      -   5        $��Delete��5`   0   5a      5b      5c      