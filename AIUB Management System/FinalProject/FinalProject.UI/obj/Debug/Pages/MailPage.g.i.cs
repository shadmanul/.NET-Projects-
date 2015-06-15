﻿#pragma checksum "..\..\..\Pages\MailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "55C84BD5CD2431AF31859388FB9E5251"
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
    /// MailPage
    /// </summary>
    public partial class MailPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserMailTB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox MailPasswordTB;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button a1Button;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button a2Button;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button a3Button;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ToTB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SubjectTB;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BodyTB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\MailPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Send;
        
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
            System.Uri resourceLocater = new System.Uri("/FinalProject.UI;component/pages/mailpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MailPage.xaml"
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
            this.UserMailTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Pages\MailPage.xaml"
            this.UserMailTB.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UserMailTB_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MailPasswordTB = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 15 "..\..\..\Pages\MailPage.xaml"
            this.MailPasswordTB.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UserMailTB_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.a1Button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Pages\MailPage.xaml"
            this.a1Button.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.a2Button = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\MailPage.xaml"
            this.a2Button.Click += new System.Windows.RoutedEventHandler(this.a2Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.a3Button = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\MailPage.xaml"
            this.a3Button.Click += new System.Windows.RoutedEventHandler(this.a3Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ToTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.SubjectTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.BodyTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Send = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pages\MailPage.xaml"
            this.Send.Click += new System.Windows.RoutedEventHandler(this.Send_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
