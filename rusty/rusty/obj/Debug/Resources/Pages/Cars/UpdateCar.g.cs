﻿#pragma checksum "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3EBA23FE75E34C7E442036A9FE1EC64F"
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
    /// UpdateCar
    /// </summary>
    public partial class UpdateCar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdateMark;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdateModel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdateYear;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdateEngine;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdateBody;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdateColor;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpdateRegNummber;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update;
        
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
            System.Uri resourceLocater = new System.Uri("/rusty;component/resources/pages/cars/updatecar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
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
            this.UpdateMark = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.UpdateModel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.UpdateYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.UpdateEngine = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.UpdateBody = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.UpdateColor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.UpdateRegNummber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Update = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\..\Resources\Pages\Cars\UpdateCar.xaml"
            this.Update.Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

