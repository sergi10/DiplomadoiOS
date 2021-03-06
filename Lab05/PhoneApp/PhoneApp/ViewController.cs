﻿using System;

using UIKit;

namespace PhoneApp
{
	public partial class ViewController : UIViewController
	{


		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			var TranslatedNumber = string.Empty;

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
		}

		partial void VerifyButton_TouchUpInside(UIButton sender)
		{
			Validate();
		}

		async void Validate()
		{
			var Client = new SALLab05.ServiceClient();
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
	}
}
