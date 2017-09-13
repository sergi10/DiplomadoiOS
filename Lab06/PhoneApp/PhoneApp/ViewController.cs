using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneApp
{
    public partial class ViewController : UIViewController
    {
        string TranslatedNumber = string.Empty;
        List<string> PhoneNumbers = new List<string>();

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            //var TranslatedNumber = string.Empty;

            TranslateButton.TouchUpInside += (object sender, System.EventArgs e) =>
             {
                 var Translator = new PhoneTranslator();
                 TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                 if (string.IsNullOrWhiteSpace(TranslatedNumber))
                 {
                     // No hay número a llamar
                     CallButton.SetTitle("Llamar", UIControlState.Normal);
                     CallButton.Enabled = false;
                 }
                 else
                 {
                     // Hay un posible número telefónico a llamar
                     CallButton.SetTitle($"Llamar al { TranslatedNumber}", UIControlState.Normal);
                     CallButton.Enabled = true;
                     PhoneNumbers.Add(TranslatedNumber);
                 }
             };

            CallButton.TouchUpInside += (object sender, System.EventArgs e) =>
            {
                var URL = new Foundation.NSUrl($"tel:{TranslatedNumber}");
                // Intentar marcar el número telefónico


                if (!UIApplication.SharedApplication.OpenUrl(URL))
                {
                    var Alert = UIAlertController.Create("No soportado", "El esquema 'tel:' no es soportado en este dispositivo", UIAlertControllerStyle.Alert);
                    Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(Alert, true, null);
                }
            };
            CallHistoryButton.TouchUpInside += (object sender, System.EventArgs e) =>
            {
                if (this.Storyboard.InstantiateViewController("ClassHistoryController") is ClassHistoryController Controller)
                {
                    Controller.PhoneNumbers = PhoneNumbers;
                    this.NavigationController.PushViewController(Controller, true);
                }
            };
            VerifyButton.TouchUpInside += (object sender, System.EventArgs e) =>
            {
                if (this.Storyboard.InstantiateViewController("VirifyController") is VirifyController Controller)
                {
                    this.NavigationController.PushViewController(Controller, true);
                }
            };
        }

        //partial void VerifyButton_TouchUpInside(UIButton sender)
        //{
        //    Validate();
        //}

        async void Validate()
        {
            var Client = new SALLab06.ServiceClient();
            var Result = await Client.ValidateAsync("email", "password", this);
            var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token} ", UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(Alert, true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);
        //    if (segue.DestinationViewController is ClassHistoryController controller)
        //    {
        //        controller.PhoneNumbers = PhoneNumbers;
        //    }
        //}
    }
}
