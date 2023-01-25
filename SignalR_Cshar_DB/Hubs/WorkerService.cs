using Microsoft.AspNetCore.SignalR;
using SignalR_Cshar_DB.Service.Interface;

namespace SignalR_Cshar_DB.Hubs
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;
        private IProductService _product;


        public WorkerService(ILogger<WorkerService> logger, IProductService productService)
        {
            _logger = logger;
            _product = productService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(5000);
                var res = _product.GetAllProductAsync();
                if (res != null)
                {
                    _logger.LogInformation("Informaciones", res);
                }
            }
        }
    }
}
