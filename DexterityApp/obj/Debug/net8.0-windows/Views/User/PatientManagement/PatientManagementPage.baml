   M S B A M L   `   `   `  ����G  CDexterityApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:DexterityApp.Views.UserDexterityApp.Views.User  5      E    ?DexterityApp.Views.User.PatientManagement.PatientManagementPage   5      a ]DevExpress.Xpf.Core.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:DexterityApp.Views.User     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      a ]DevExpress.Xpf.Grid.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v23.2.Core, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al
 hDevExpress.Xpf.Grid.v23.2.Extensions, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
 5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5
      j fDevExpress.Xpf.LayoutControl.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5        N� Title$  PatientManagement��5      $
��Auto��6!   $
��Auto��6/   .��5      � .+�5   
   ]� .+�5      �� $��Patient Management��6      WindowTitle#��[  5      $	��Top=�5      &   DevExpress.Xpf.Core.DXTabControl  5      -   5          Name$ PatientTabControl��5   9   $
��Auto��6   $
��Auto��6,     CustomTabControl#��[ 5   N   .@�5      #  DevExpress.Xpf.Core.DXTabItem  �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ Search Patient��6   .��5      ]� $
��True��6    .+�5      � $	��Top=�6    � ColumnDefinitions 5      �� 5   "   $
��Auto �63   �� 5   "   $��* �63    � RowDefinitions 5      �� 5   "   $
��Auto �60   .+�5      0  *DevExpress.Xpf.LayoutControl.LayoutControl  .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�61   .+�5    "     4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�63   .+�5!   &   �� $��Load Patients��6-     ThemeButtonSmall#��[ 5"   -   ��5!   E   �� *GetPatientsCommand+5"   -   �� 5#   &   -   5        $��Add new patient��5#   -   #��[ 6G   5$   -   �� 5&   &   -   5         ��Name$ OpenPatientBtn��5(   I   ${�False��5&   -   $��Open Patient��6?   #��[ 5'   -   5(   I   �� 5*   &   -   5        $ PatientSummaryBtn��5,   L   ${�False��5*   -   $��Patient Summary��6?   #��[ 5+   -   5,   L   5-   #   5/      51      � 52      .+�53      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ PatientGridControl��53   .   $��Bottom=�6J   $
��Auto��6b   $
��Auto��54   .   ) 	 #DevExpress.Xpf.Grid.DataControlBase	   AutoGenerateColumns$
	 None=�56   .   
   SelectionMode$	
 Row=�57   U      ItemsSource 55   .   �� *
Patients+ �� IsAsync$
 True�� �� Mode$ TwoWay=� �� NotifyOnSourceUpdated$
 True�� �� UpdateSourceTrigger$ PropertyChanged=�   ShowLoadingPanel 57   .   �� *	IsLoading+   View 58   "   #	  DevExpress.Xpf.Grid.TableView	  59   &   -   5         	 Name$ PatientView��59   4    	  	AutoWidth$
 true��6I   &
 	  DevExpress.Xpf.Grid.DataViewBase 
  ShowTotalSummary$
 True��6Z    	  ShowIndicator$ False��5:   4    
  AllowEditing$ False��5<   4    
  NavigationStyle$	 Row=�6I    	  AllowCellMerge$
 True��6_   &   DevExpress.Xpf.Grid.GridViewBase   AllowPaging$
 True��5=   4    
  ShowSearchPanelMode$ Always=�6G     
  RowCellMenuCustomizations 5>   *   '  !DevExpress.Xpf.Bars.BarButtonItem  5?   .   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Delete 6@     5@   .   $
 Edit 6@   5B   '      Columns. 5D   "   $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ CreatedDate��61   $ 	 DevExpress.Xpf.Grid.BaseColumn   Header$ Created Date 6I       Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$
  Auto 6_     5E   "   $ FullName��61   $ 	Full Name 6F   $
  Auto 6Y     5F   "   $ Gender��61   $ Gender 6D   $
  Auto 6T     5G   "   $ DateOfBirth��61   $ Date Of Birth 6I   $  30 6`     5H   "   $ EmailAddress��61   $ Email 6J   $
  Auto 6Y     5I   "   $ AddressLine1��61   $ Address 6J   $
  Auto 6[     5J   "   $  ��61   $  50 6>   !   CellTemplate! 5K   &   �� 5L   *   .R�5M   .   '  !DevExpress.Xpf.Editors.ButtonEdit  $��Center=�6=   "   AllowDefaultButton	" False5N   =   $��Right=�6X   $	��100��5O   =   #   ShowText$# False��6I   
������ $��0,0,0,0q�5P   =   $   Buttons$ 5R   6   '  !DevExpress.Xpf.Editors.ButtonInfo  -   5        %   Content% 5S   :   �� 5T   >   $!��/Resources/actions/edit.png��6D   $��20��6i   5V   7     5W   6   -   5        % 5X   :   �� 5Y   >   $#��/Resources/actions/delete.png��6D   $��20��6k   5[   7   5]   /   5^   +   5`   #   5a      5c      5d      5g      5h      5j      5k      5l      