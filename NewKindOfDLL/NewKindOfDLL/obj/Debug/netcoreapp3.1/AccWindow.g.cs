﻿#pragma checksum "..\..\..\AccWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3AD679A99B93D75300188AC4CBB52549C45E2CF0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using NewKindOfDLL;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace NewKindOfDLL {
    
    
    /// <summary>
    /// AccWindow
    /// </summary>
    public partial class AccWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\AccWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Minimize;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\AccWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Close;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AccWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridPrincipal;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AccWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TransitioningContentSlide;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AccWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridCursor;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AccWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewMenu;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\AccWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignOutButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NewKindOfDLL;component/accwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AccWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\AccWindow.xaml"
            ((NewKindOfDLL.AccWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Minimize = ((System.Windows.Controls.Image)(target));
            
            #line 12 "..\..\..\AccWindow.xaml"
            this.Minimize.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Minimize_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Close = ((System.Windows.Controls.Image)(target));
            
            #line 14 "..\..\..\AccWindow.xaml"
            this.Close.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Close_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GridPrincipal = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.TransitioningContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 6:
            this.GridCursor = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.ListViewMenu = ((System.Windows.Controls.ListView)(target));
            
            #line 31 "..\..\..\AccWindow.xaml"
            this.ListViewMenu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewMenu_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SignOutButton = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\AccWindow.xaml"
            this.SignOutButton.Click += new System.Windows.RoutedEventHandler(this.SignOutButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

