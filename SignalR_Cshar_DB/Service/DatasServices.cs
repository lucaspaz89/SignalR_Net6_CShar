using Microsoft.EntityFrameworkCore;
using SignalR_Cshar_DB.DB;
using SignalR_Cshar_DB.Models;
using SignalR_Cshar_DB.Service.Interface;

namespace SignalR_Cshar_DB.Service
{
    public class DatasServices:IDatasServices
    {
        //private LpProductDB _lp;
        //public DatasServices(LpProductDB lpProductDB)
        //{
        //    _lp= lpProductDB;
        //}

        public Task<List<MProducts>> GetDatos()
        {
            var _res = new List<MProducts>()
            {
                new MProducts()
                {
                    IdProducto = 1,
                    NameProduct = "Manzana",
                    PriceProduct = 350,
                    FchMovt = "22/01/2023"
                }
            };
            return Task.FromResult(_res);
        }

        //public List<MProducts> GetProduct()
        //{
        //    var _listProduct = new List<MProducts>();

        //    var _res = _lp.Products.FromSqlRaw($"exec SP_Get_AllProduct").ToList();

        //    //_listProduct.AddRange(_res);

        //    return _res;
        //}
    }
}
