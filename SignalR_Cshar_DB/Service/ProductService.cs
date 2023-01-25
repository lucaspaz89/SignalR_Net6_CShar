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

		public ProductService(LpProductDB lpProductDB)
		{
			_lp= lpProductDB;
        }

        public async Task<List<MProducts>> GetAllProductAsync()
        {
			try
			{	
				await Task.Delay(1000);

				var _res = await _lp.Products.FromSqlRaw($"exec SP_Get_AllProduct").ToListAsync();

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

	}
}
