using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR_Cshar_DB.DB;
using SignalR_Cshar_DB.Hubs;

namespace SignalR_Cshar_DB.Models.SignalR
{
    public class ProductsTicker
    {
        //private readonly IEnumerable<MProducts> _product;
        private readonly List<MProducts> _product;

        private IHubContext<ProductsHub> _productHub { get; set; }
        
        private readonly Timer _timer;

        private readonly LpProductDB _lp;

        public ProductsTicker(IHubContext<ProductsHub> hubContext, LpProductDB lpProductDB)
        {
            _productHub= hubContext;

            _lp = lpProductDB;

            _timer = new Timer(SendInfo, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        public List<MProducts> GetAllProduct()
        {
            var res = _lp.Products.FromSqlRaw($"exec SP_Get_AllProduct").ToList();

            _product.AddRange(res);

            return res;
        }

        public void SendInfo(object state)
        {
            foreach (var item in _product)
            {
                SendData(item);
            }
        }

        public void SendData(MProducts products) 
        {
            _productHub.Clients.All.SendAsync("ReceiveProduct", products);
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
