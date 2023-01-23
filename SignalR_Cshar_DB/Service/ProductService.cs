using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using SignalR_Cshar_DB.DB;
using SignalR_Cshar_DB.Hubs;
using SignalR_Cshar_DB.Models;
using SignalR_Cshar_DB.Service.Interface;

namespace SignalR_Cshar_DB.Service
{
    public class ProductService:IProductService
    {
		private readonly LpProductDB _lp;
        private readonly IHubContext<ProductsHub> _productHub;

		//private HubConnection _hubConnection;

		//private string _server = "https://localhost:7296/productHub";

        //private readonly List<MProducts> _products = new List<MProducts>();

        public ProductService(LpProductDB lpProductDB, IHubContext<ProductsHub> productHub)
		{
			_lp= lpProductDB;
			_productHub = productHub;

            //_hubConnection = new HubConnectionBuilder().WithUrl(_server).Build();

			//Connect();
			//GetMostar();
        }

        public async Task<List<MProducts>> GetAllProductAsync()
        {
			try
			{	
				var _res = await _lp.Products.FromSqlRaw($"exec SP_Get_AllProduct").ToListAsync();

				//_products.AddRange(_res);

                //GetMostar();

                //await GetMostar(_res);

                //await _productHub.Clients.All.SendAsync("ReceiveProduct", _res);

                return _res;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
        }

		public async Task<bool> PostProductAsync(MProducts product)
		{
			try
			{
				await _lp.Database.ExecuteSqlAsync($"exec SP_Post_Product {product.NameProduct}, {product.PriceProduct}");

                //await _productHub.Clients.All.SendAsync("ReceiveProduct", product);

                return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<bool> UpdateProductAsync(MProducts product)
		{
			try
			{
				await _lp.Database.ExecuteSqlAsync($"exec SP_Update_ByIdProduct {product.PriceProduct}, {product.IdProducto}");

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}


		//private async void Connect()
		//{
		//	//connect to server
		//	//_hubConnection = new HubConnectionBuilder().WithUrl(_server).Build();

		//	await _hubConnection.StartAsync();

  //          _hubConnection.On("GetNatification", (string name) => {
		//		var res = name;

		//	});

  //          await _hubConnection.InvokeAsync("pusNotification", "Naranaja");

  //      }

		//public async Task GetMostar(List<MProducts> product)
		//{
		//	//List<MProducts> product = await GetAllProductAsync();
			
  //          await _hubConnection.StartAsync();
            
		//	//await _hubConnection.InvokeAsync("pusNotification", product);

  //          await _hubConnection.InvokeAsync("postSendAsync", product);
  //      }

  //      public async void GetMostar()
  //      {
  //          await _hubConnection.StartAsync();

  //          await _hubConnection.InvokeAsync("postSendAsync", _products);
  //      }
    }
}
