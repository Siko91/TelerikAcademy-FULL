﻿

#pragma checksum "F:\git\TelerikAcademy--WinPhone-WinStore-Apps\BunnyEscape\Tiles-cs\Shared\Scenario1_SendTextTile.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "09D9B97DE3CD215A0753E0505BD3EA7C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tiles
{
    partial class SendTextTile : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 81 "..\..\Scenario1_SendTextTile.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.UpdateTileWithTextWithStringManipulation_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 69 "..\..\Scenario1_SendTextTile.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.UpdateTileWithText_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 70 "..\..\Scenario1_SendTextTile.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.ClearTile_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


