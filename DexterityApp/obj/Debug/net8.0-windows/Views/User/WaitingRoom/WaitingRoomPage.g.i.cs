﻿#pragma checksum "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D33CD3E5C3336178A6768B0ACDBF8FB32B0A8B8"
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
using DevExpress.Xpf.Bars;
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
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
using DevExpress.Xpf.LayoutControl;
using DexterityApp.Views.User.WaitingRoom;
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


namespace DexterityApp.Views.User.WaitingRoom {
    
    
    /// <summary>
    /// WaitingRoomPage
    /// </summary>
    public partial class WaitingRoomPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.DXTabControl PatientTabControl;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl PatientExpectedGridControl;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView PatientView;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl PatientPresentGridControl;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView PatientPresentView;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl PatientInconsultationGridControl;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView PatientInconsultationView;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl PatientHistoryGridControl;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView PatientHistoryView;
        
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
            System.Uri resourceLocater = new System.Uri("/DexterityApp;V1.0.0.0;component/views/user/waitingroom/waitingroompage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\User\WaitingRoom\WaitingRoomPage.xaml"
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
            this.PatientTabControl = ((DevExpress.Xpf.Core.DXTabControl)(target));
            return;
            case 2:
            this.PatientExpectedGridControl = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 3:
            this.PatientView = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            case 4:
            this.PatientPresentGridControl = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 5:
            this.PatientPresentView = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            case 6:
            this.PatientInconsultationGridControl = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 7:
            this.PatientInconsultationView = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            case 8:
            this.PatientHistoryGridControl = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 9:
            this.PatientHistoryView = ((DevExpress.Xpf.Grid.TableView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

