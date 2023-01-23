using Microsoft.AspNetCore.SignalR;
using SignalR_Cshar_DB.Service.Interface;

namespace SignalR_Cshar_DB.Hubs
{
    public class ProductHostedService //: IHostedService, IDisposable
    {
        //private readonly IHubContext<ProductsHub> _productHub;

        //private Timer _timer;

        //private readonly IDatasServices _dataServices;
        ////private readonly IProductService _productService;

        //public ProductHostedService(IHubContext<ProductsHub> productHub, IDatasServices datasServices)
        //{
        //    _productHub = productHub;
        //    _dataServices = datasServices;
        //}

        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _timer = new Timer(SendInfo, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        //    return Task.CompletedTask;
        //}

        //public void SendInfo(object state)
        //{
        //    //var _products = new MMproductos();
        //    var res = _dataServices.GetDatos(); //_products.MProducts;

        //    _productHub.Clients.All.SendAsync("ReceiveProduct", res);
        //}

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    //cambia a tiempo cero y te devuelve almenos un segundo.
        //    _timer?.Change(Timeout.Infinite, 0);

        //    //retornamos el dato.
        //    return Task.CompletedTask;
        //}

        //public void Dispose()
        //{
        //    _timer?.Dispose();
        //}


        //private IEnumerable<MProducts> GetData()
        //{
        //    var _listProduct = new List<MProducts>();

        //    using (var _connect = new SqlConnection(_connection.SqlString))
        //    {
        //        _connect.Open();

        //        SqlCommand cmd = new SqlCommand("SP_Get_AllProduct", _connect);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        using (var _reader = cmd.ExecuteReader())
        //        {
        //            while(_reader.Read())
        //            {
        //                _listProduct.Add(new MProducts()
        //                {
        //                    IdProducto = _reader.GetInt32("IdProduct"),
        //                    NameProduct = _reader.GetString("NameProduct"),
        //                    PriceProduct = _reader.GetDecimal("PriceProduct"),
        //                    FchMovt = _reader.GetString("FchMovt")
        //                });
        //            }
        //        }
        //    }
        //    //_products = _listProduct;
        //    return _listProduct;
        //}
    }
}
