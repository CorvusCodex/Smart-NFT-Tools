﻿#pragma checksum "..\..\..\Holders.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42DC87C137E86027973CEE439FD7C4CEEFE81051"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SmartNFTTools;
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


namespace SmartNFTTools {
    
    
    /// <summary>
    /// Holders
    /// </summary>
    public partial class Holders : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LogBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_holdCol;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_HolderToken;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_AirDropCollection;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_numAirDropToken;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_APIKey;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_ManAirDropAddress;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chk_SpecificToken;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_CheckHolders;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_AmountToAirdrop;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\Holders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ManAirdrop;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SmartNFTTools;V0.6.8;component/holders.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Holders.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 23 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.new_click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 24 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.changer_click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 25 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.airdrop_click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 26 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.holders_click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 27 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.history_click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 28 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.itemhistory_click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 31 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.about_click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 32 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.github_click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 33 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.twitter_click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 34 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.nfts_click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 35 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.docs_click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 53 "..\..\..\Holders.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 13:
            this.LogBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txt_holdCol = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txt_HolderToken = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\Holders.xaml"
            this.txt_HolderToken.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 16:
            this.txt_AirDropCollection = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.txt_numAirDropToken = ((System.Windows.Controls.TextBox)(target));
            
            #line 113 "..\..\..\Holders.xaml"
            this.txt_numAirDropToken.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 18:
            this.txt_APIKey = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            this.txt_ManAirDropAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 20:
            this.chk_SpecificToken = ((System.Windows.Controls.CheckBox)(target));
            
            #line 167 "..\..\..\Holders.xaml"
            this.chk_SpecificToken.Checked += new System.Windows.RoutedEventHandler(this.chk_SpecificToken_Checked);
            
            #line default
            #line hidden
            
            #line 167 "..\..\..\Holders.xaml"
            this.chk_SpecificToken.Click += new System.Windows.RoutedEventHandler(this.chk_SpecificToken_Checked);
            
            #line default
            #line hidden
            return;
            case 21:
            this.btn_CheckHolders = ((System.Windows.Controls.Button)(target));
            
            #line 168 "..\..\..\Holders.xaml"
            this.btn_CheckHolders.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.txt_AmountToAirdrop = ((System.Windows.Controls.TextBox)(target));
            
            #line 170 "..\..\..\Holders.xaml"
            this.txt_AmountToAirdrop.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 23:
            this.btn_ManAirdrop = ((System.Windows.Controls.Button)(target));
            
            #line 172 "..\..\..\Holders.xaml"
            this.btn_ManAirdrop.Click += new System.Windows.RoutedEventHandler(this.btn_ManAirdrop_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

