﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45B59FE9E2278FD45299373469D4FE175933F4DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RenderingWithShapes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace RenderingWithShapes {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar MainToolBar;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CircleOption;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RectOption;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton LineOption;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton FlipToggle;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas DrawingArea;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RenderingWithShapes;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainToolBar = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 2:
            this.CircleOption = ((System.Windows.Controls.RadioButton)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.CircleOption.Click += new System.Windows.RoutedEventHandler(this.CircleOption_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RectOption = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.RectOption.Click += new System.Windows.RoutedEventHandler(this.RectOption_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LineOption = ((System.Windows.Controls.RadioButton)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.LineOption.Click += new System.Windows.RoutedEventHandler(this.LineOption_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FlipToggle = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 28 "..\..\MainWindow.xaml"
            this.FlipToggle.Click += new System.Windows.RoutedEventHandler(this.FlipToggle_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DrawingArea = ((System.Windows.Controls.Canvas)(target));
            
            #line 30 "..\..\MainWindow.xaml"
            this.DrawingArea.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DrawingArea_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 30 "..\..\MainWindow.xaml"
            this.DrawingArea.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DrawingArea_MouseRightButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
