﻿#pragma checksum "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4F3E5EC4AA03B7B1D864A32808117D84"
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
using rusty.Resources.Pages.Customers;


namespace rusty.Resources.Pages.Customers {
    
    
    /// <summary>
    /// AddCustomer
    /// </summary>
    public partial class AddCustomer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddLogin;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddFIO;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddAdres;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AddPerson;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddPhone;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
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
            System.Uri resourceLocater = new System.Uri("/rusty;component/resources/pages/customers/addcustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
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
            this.AddAdres = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddPerson = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.AddPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\..\Resources\Pages\Customers\AddCustomer.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

