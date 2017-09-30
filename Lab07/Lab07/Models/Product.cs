using System;
using System.Threading.Tasks;
using System.Net.Http;
using NorthWind;
using System.Net.Http.Headers;

namespace Lab07.Models
{

	public class Product : IProduct, INorthWindModel, IChangeStatusEventArgs
	{
		public int ProductID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string ProductName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int? SupplierID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int? CategoryID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string QuantityPerUnit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public decimal? UnitPrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public short? UnitsInStock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public short? UnitsOnOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public short? ReorderLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Discontinued { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public StatusOptions Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public Product()
		{
		}

		public event ChangeStatusEventHandler ChangeStatus;

		public async Task<IProduct> GetProductByIDAsync(int ID)
		{
			HttpClient Client = new HttpClient();
			Product product = new Product();
			//using (var Client = new System.Net.Http.HttpClient())
			//{
			Client.BaseAddress =
				new Uri("https://ticapacitacion.com/webapi/northwind/");
			Client.DefaultRequestHeaders.Accept.Clear();
			Client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));
			// Notificar aqui que la API Web será invocada
			product.Status = StatusOptions.CallingWebAPI;

			HttpResponseMessage Response =
				await Client.GetAsync($"product/{ID}");
			// Notificar aquí que se va a verificar el resultado de la llamada
			product.Status = StatusOptions.VerifyingResult;

			if (Response.IsSuccessStatusCode)
			{
				var JSONProduct =
					await Response.Content.ReadAsStringAsync();
				product = JsonConvert.DeserializeObject<Product>(JSONProduct);
				if (product != null)
				{
					// Notificar aqui que el produto fue encontrado
					product.Status = StatusOptions.ProductFound;

				}
				else
				{
					product.Status = StatusOptions.ProductNotFound;
				}
			}
			return product;
			//}
		}
	}
}
