using System;

using UIKit;
using Lab07.Models;

namespace Lab07
{
	public partial class ViewController : UIViewController
	{
		Product product = new Product();
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SearchButton.TouchUpInside += (object sender, System.EventArgs e) =>
            {

                product = (Product)product.GetProductByIDAsync(4).Result;

            





                //var Translator = new PhoneTranslator();
                //TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                //if (string.IsNullOrWhiteSpace(TranslatedNumber))
                //{
                //	// No hay número a llamar
                //	CallButton.SetTitle("Llamar", UIControlState.Normal);
                //	CallButton.Enabled = false;
                //}
                //else
                //{
                //	// Hay un posible número telefónico a llamar
                //	CallButton.SetTitle($"Llamar al { TranslatedNumber}", UIControlState.Normal);
                //	CallButton.Enabled = true;
                //	PhoneNumbers.Add(TranslatedNumber);
                //}
            };
            if(product != null)
            {
                NameEntry.Text = product.ProductName;
                PriceEntry.Text = product.UnitPrice.ToString();
                StockEntry.Text = product.UnitsInStock.ToString();
                CategoryEntry.Text = product.CategoryID.ToString();
                
            }
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
