   M S B A M L   `   `   `  ����G  CDexterityApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:DexterityApp.Views.User.PatientManagement.Accounts2DexterityApp.Views.User.PatientManagement.Accounts  5   	   F    @DexterityApp.Views.User.PatientManagement.Accounts.PaymentWindow   5   	   a ]DevExpress.Xpf.Core.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Rlocal@clr-namespace:DexterityApp.Views.User.PatientManagement.Accounts     5   	   j fDevExpress.Xpf.LayoutControl.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   a	 ]DevExpress.Xpf.Grid.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af
 bDevExpress.Xpf.Grid.v23.2.Core, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v23.2.Extensions, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 	 
  5	   	   $	��450��5   !   $	��800��6-     � WindowStartupLocation$  CenterScreen=�6:    � ShowInTaskbar$ False��5   	    � 
ResizeMode$ NoResize=�5   	    � Title 5   	   �� *Title+.��5      �� .+�5   
   �� $	��Top=�6+      WindowTitle#��[  6@   ��6   �� *Title+6@   0  *DevExpress.Xpf.LayoutControl.LayoutControl  5   
   $	��Top=�6   .+�5      .  (DevExpress.Xpf.LayoutControl.LayoutGroup  4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 15Q�6   .+�5           Orientation$ Vertical=�6#   .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem     Label$  ��6&      Content. 5      �� Smith, Alexander66   5        5      $ 	Personal:��6&   . 5      �� 65.006+   5      5        5      $ Vertical=�6#   $��Right=�6:   .+�5        $  ��6&   . 5      �� 06/03/1973 (42 yrs)69   5        5      $ Family��6&   . 5       �� 	$250.006-   5!      5"      5#      5$        5%   
   $ Vertical=�6   .+�5&           View$ GroupBox=�6   	   Header$	 Payment Details��6/     SimpleLayoutGroup#��[ 6H   .+�5'        $ Vertical=�6#   $ 20Q�6:   .+�5(        $ Department:��6&   . 5)      )  #DevExpress.Xpf.Editors.ComboBoxEdit  
   Items.
 5*      -  'DevExpress.Xpf.Editors.ComboBoxEditItem  .��63   Department 16A     5+      .��63   Department 26A     5,      .��63   Department 36A   5-      5.        5/      $
 HCP:��6&   . 50        .
 51        .��63   Paul Jackson6A     52      .��63   
Imran Khan6?   53      54        55      $ Payment Type:��6&   . 56        .
 57        .��63   Cash69   58      59        5:      $ Payment To:��6&   . 5;        .
 5<        .��63   
Personal6=   5=      5>        5?      $ Payment Date:��6&   . 5@      %  DevExpress.Xpf.Editors.DateEdit  %  DevExpress.Xpf.Editors.TextEdit   MaskType$ DateOnly=�6'   6=   5A        5B      $ Amount:��6&   . 5C        $ Numeric=�6'   $��80��6:   $
��Left=�6E   6b   5D        5F      $ Print Receipt��6&   . 5G      &	   DevExpress.Xpf.Editors.CheckEdit	  6*   5H      5J      5L        5M      .+�5N        $ GroupBox=�6#   $	 Unallocated Charges��63   #��[ 6P   .+�5O        . 5P      %
 	 DevExpress.Xpf.Grid.GridControl
  $��Bottom=�6*   $
��Auto��6B   $	��200��5Q   *   ) 
 #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�5S   *      SelectionMode$	 Row=�5T   Q      ItemsSource 5R   *   �� *
Patients+ �� IsAsync$
 True�� �� Mode$ TwoWay=� �� NotifyOnSourceUpdated$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�   ShowLoadingPanel 5T   *   �� *	IsLoading+ 
  View 5U      # 	 DevExpress.Xpf.Grid.TableView  5V   "      	AutoWidth$
 true��61   & 
  DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary$
 True��6B      ShowIndicator$ False��5W   0      AllowEditing$ False��5X   0      NavigationStyle$	 Row=�6E      AllowCellMerge$
 True��6[   & 	  DevExpress.Xpf.Grid.GridViewBase   AllowPaging$
 True��5Y   0      ShowSearchPanelMode$ Always=�6C   5Z   #    
  Columns. 5\      $ 	 DevExpress.Xpf.Grid.GridColumn  $ 
 DevExpress.Xpf.Grid.ColumnBase   	FieldName$	 Pay��6-   $ 
 DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$	 Pay 6=       Width2 
 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$  20 6J     5]      $
 Date��6-   $
 Date 6>   $  25 6L     5^      $ Description��6-   $ Description 6E     5_      $ Payment��6-   $ Payment 6A   $  35 6R   5`      5a      5b      5c      5e        5f   
   .+�5g        $��Right=�6   .+�5h        . 5i      �� $��Make Payment��6     ThemeButtonExtraSmall#��[ 64   6e   5j        5k      $	��100��6"   . 5l      �� $��Close��6   #��[ 6-   6^   5m      5n      5o      5p      5r      