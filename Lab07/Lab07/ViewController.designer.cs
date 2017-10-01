// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Lab07
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CategoryEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NameEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PriceEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SearchButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField StockEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ValidateButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CategoryEntry != null) {
                CategoryEntry.Dispose ();
                CategoryEntry = null;
            }

            if (NameEntry != null) {
                NameEntry.Dispose ();
                NameEntry = null;
            }

            if (PriceEntry != null) {
                PriceEntry.Dispose ();
                PriceEntry = null;
            }

            if (SearchButton != null) {
                SearchButton.Dispose ();
                SearchButton = null;
            }

            if (StockEntry != null) {
                StockEntry.Dispose ();
                StockEntry = null;
            }

            if (ValidateButton != null) {
                ValidateButton.Dispose ();
                ValidateButton = null;
            }
        }
    }
}