﻿#pragma checksum "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "141C32456D89BB79896C53C463D594A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using rusty.Resources.Pages.Masters;


namespace rusty.Resources.Pages.Masters {
    
    
    /// <summary>
    /// AddMaster
    /// </summary>
    public partial class AddMaster : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddLogin;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddFIO;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddSpec;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddExp;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddPhone;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AddWorkplace;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddSalary;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
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
            System.Uri resourceLocater = new System.Uri("/rusty;component/resources/pages/masters/addmaster.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
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
            this.AddLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AddFIO = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AddSpec = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddExp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddWorkplace = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.AddSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\..\Resources\Pages\Masters\AddMaster.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

