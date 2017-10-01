using System;
using System.Threading.Tasks;
using System.Net.Http;
using NorthWind;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Lab07.Models
{

	public class Product : IProduct, INorthWindModel, IChangeStatusEventArgs
	{
		public int ProductID { get ; set ; }
		public string ProductName { get ; set ; }
		public int? SupplierID { get ; set ; }
		public int? CategoryID { get ; set ; }
		public string QuantityPerUnit { get ; set ; }
		public decimal? UnitPrice { get ; set ; }
		public short? UnitsInStock { get ; set ; }
		public short? UnitsOnOrder { get ; set ; }
		public short? ReorderLevel { get ; set ; }
		public bool Discontinued { get ; set ; }
		public StatusOptions Status { get ; set ; }

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
