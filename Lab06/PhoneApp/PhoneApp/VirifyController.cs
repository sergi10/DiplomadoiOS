using Foundation;
using System;
using UIKit;

namespace PhoneApp
{
	public partial class VirifyController : UIViewController
	{
		public VirifyController(IntPtr handle) : base(handle)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//VerifyButton.TouchUpInside += VerifyButton_TouchUpInside1;
			VerifyButton.TouchUpInside += async (object sender, System.EventArgs e) =>
			{
				var Client = new SALLab06.ServiceClient();
				var Result = await Client.ValidateAsync(UserEntry.Text, PassEntry.Text, this);
				var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token} ", UIAlertControllerStyle.Alert);
				Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
				PresentViewController(Alert, true, null);
			};

		}
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		void VerifyButton_TouchUpInside1(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(UserEntry.Text) || String.IsNullOrEmpty(PassEntry.Text))
			{
				var Alert = UIAlertController.Create("ERROR", "El campo User y Password deghne de estar rellenados", UIAlertControllerStyle.Alert);
				Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
				PresentViewController(Alert, true, null);
			}
			else
			{
				Validate();
			}
		}

		async void Validate()
		{
			var Client = new SALLab06.ServiceClient();
			var Result = await Client.ValidateAsync(UserEntry.Text, PassEntry.Text, this);
			var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token} ", UIAlertControllerStyle.Alert);
			Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
			PresentViewController(Alert, true, null);
		}
	}
}