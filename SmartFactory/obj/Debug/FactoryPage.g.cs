﻿#pragma checksum "..\..\FactoryPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E11B8D0E194294B9066836AA5A62FFE6AB688FCAD3CDA8E771A51526892A615B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SmartFactory;
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


namespace SmartFactory {
    
    
    /// <summary>
    /// FactoryPage
    /// </summary>
    public partial class FactoryPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\FactoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Main;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\FactoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MenuGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\FactoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTB;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\FactoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCEX;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\FactoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddImg;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FactoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveCex;
        
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
            System.Uri resourceLocater = new System.Uri("/SmartFactory;component/factorypage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FactoryPage.xaml"
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
            this.Main = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            
            #line 22 "..\..\FactoryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MenuGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            
            #line 24 "..\..\FactoryPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddCEX = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\FactoryPage.xaml"
            this.AddCEX.Click += new System.Windows.RoutedEventHandler(this.AddCEX_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddImg = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\FactoryPage.xaml"
            this.AddImg.Click += new System.Windows.RoutedEventHandler(this.AddImg_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SaveCex = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\FactoryPage.xaml"
            this.SaveCex.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
