﻿#pragma checksum "..\..\..\Pages\GradePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ADC2AEBFF5CC6CD7AA40EA882C4D0074"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
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


namespace FinalProject.UI.Pages {
    
    
    /// <summary>
    /// GradePage
    /// </summary>
    public partial class GradePage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Pages\GradePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox CourseList;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\GradePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox semesterCB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\GradePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem sp1314;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\GradePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem fl1314;
        
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
            System.Uri resourceLocater = new System.Uri("/FinalProject.UI;component/pages/gradepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\GradePage.xaml"
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
            this.CourseList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.semesterCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\Pages\GradePage.xaml"
            this.semesterCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.semesterCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sp1314 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 4:
            this.fl1314 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

