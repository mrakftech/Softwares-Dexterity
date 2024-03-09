﻿#pragma checksum "..\..\..\..\..\Views\Admin\PermissionsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5255EF619A781AEF4616C00E40F452E12FD02C6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Data;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.LayoutControl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DexterityApp.Views.Admin {
    
    
    /// <summary>
    /// PermissionsPage
    /// </summary>
    public partial class PermissionsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit UserRoleTxt;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit Modulues;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadPermissions;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.LayoutControl.LayoutControl CheckboxControl;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.CheckEdit CreateCbx;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.CheckEdit ReadCbx;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.CheckEdit UpdateCbx;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.CheckEdit DeleteCbx;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.CheckEdit PrintCbx;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DexterityApp;V1.0.0.0;component/views/admin/permissionspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserRoleTxt = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            
            #line 29 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
            this.UserRoleTxt.SelectedIndexChanged += new System.Windows.RoutedEventHandler(this.UserRoleTxt_OnSelectedIndexChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Modulues = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            
            #line 43 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
            this.Modulues.SelectedIndexChanged += new System.Windows.RoutedEventHandler(this.Modulues_OnSelectedIndexChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LoadPermissions = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
            this.LoadPermissions.Click += new System.Windows.RoutedEventHandler(this.LoadPermissions_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CheckboxControl = ((DevExpress.Xpf.LayoutControl.LayoutControl)(target));
            return;
            case 5:
            this.CreateCbx = ((DevExpress.Xpf.Editors.CheckEdit)(target));
            return;
            case 6:
            this.ReadCbx = ((DevExpress.Xpf.Editors.CheckEdit)(target));
            return;
            case 7:
            this.UpdateCbx = ((DevExpress.Xpf.Editors.CheckEdit)(target));
            return;
            case 8:
            this.DeleteCbx = ((DevExpress.Xpf.Editors.CheckEdit)(target));
            return;
            case 9:
            this.PrintCbx = ((DevExpress.Xpf.Editors.CheckEdit)(target));
            return;
            case 10:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\..\Views\Admin\PermissionsPage.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
