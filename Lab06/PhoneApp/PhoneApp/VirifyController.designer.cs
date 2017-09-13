// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PhoneApp
{
    [Register ("VirifyController")]
    partial class VirifyController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PassEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UserEntry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton VerifyButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PassEntry != null) {
                PassEntry.Dispose ();
                PassEntry = null;
            }

            if (UserEntry != null) {
                UserEntry.Dispose ();
                UserEntry = null;
            }

            if (VerifyButton != null) {
                VerifyButton.Dispose ();
                VerifyButton = null;
            }
        }
    }
}