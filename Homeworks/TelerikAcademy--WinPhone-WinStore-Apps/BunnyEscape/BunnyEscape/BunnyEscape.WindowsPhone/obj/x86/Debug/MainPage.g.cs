﻿

#pragma checksum "F:\git\TelerikAcademy--WinPhone-WinStore-Apps\BunnyEscape\BunnyEscape\BunnyEscape.Shared\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3989C549A2E99F10C2CB5205209FDF22"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BunnyEscape
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 10 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).DoubleTapped += this.OnAnywhereDoubleTap;
                 #line default
                 #line hidden
                #line 11 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Holding += this.OnAnywhereLongPress;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


