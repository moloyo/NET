﻿#pragma checksum "..\..\ReportAttendingList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C212B7B26D0173131D1C81844303258D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using UI.WPF;


namespace UI.WPF {
    
    
    /// <summary>
    /// ReportAttendingList
    /// </summary>
    public partial class ReportAttendingList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\ReportAttendingList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CboSpecialties;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ReportAttendingList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CboPlans;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ReportAttendingList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CboSubjects;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ReportAttendingList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CboCourses;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ReportAttendingList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid reportGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/UI.WPF;component/reportattendinglist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReportAttendingList.xaml"
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
            this.CboSpecialties = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\ReportAttendingList.xaml"
            this.CboSpecialties.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboSpecialties_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CboPlans = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\ReportAttendingList.xaml"
            this.CboPlans.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboPlans_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CboSubjects = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\ReportAttendingList.xaml"
            this.CboSubjects.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboSubjects_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CboCourses = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 38 "..\..\ReportAttendingList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Show_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.reportGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

