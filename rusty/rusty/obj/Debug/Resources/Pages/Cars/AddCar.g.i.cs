﻿#pragma checksum "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "609A1C4A3CE5E1000203CBC5F3EF1D45"
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
using rusty.Resources.Pages.Cars;


namespace rusty.Resources.Pages.Cars {
    
    
    /// <summary>
    /// AddCar
    /// </summary>
    public partial class AddCar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddMark;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddModel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddYear;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddEngine;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddBody;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddColor;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddRegNummber;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
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
            System.Uri resourceLocater = new System.Uri("/rusty;component/resources/pages/cars/addcar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
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
            this.AddMark = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AddModel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AddYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddEngine = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddBody = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddColor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.AddRegNummber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\..\Resources\Pages\Cars\AddCar.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

