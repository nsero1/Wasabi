<<<<<<< HEAD
﻿#pragma checksum "D:\OOAD2\Wasabi\Prodavnica\Prodavnica\DodajArtikal.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B04A7D7E0095C35A38437831D278AF88"
=======
﻿#pragma checksum "C:\Users\Rasim Kaleta\Wasabi\Prodavnica\Prodavnica\DodajArtikal.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3B876B3EDE5C6604CABB99726D3218A1"
>>>>>>> 7ae9d8685e7c7b6d728fbd826ae23ca577cfda6d
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prodavnica
{
    partial class DodajArtikal : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.nazivArtikla = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 2:
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.brojArtikala = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.dodajArtikal = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 14 "..\..\..\DodajArtikal.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.dodajArtikal).Click += this.dodajArtikal_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.cijenaArtikla = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.captureImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 7:
                {
                    this.captureBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\DodajArtikal.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.captureBtn).Click += this.captureBtn_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

