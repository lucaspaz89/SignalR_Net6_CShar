using Microsoft.AspNetCore.SignalR;
using SignalR_Cshar_DB.Models;
using SignalR_Cshar_DB.Service.Interface;

namespace SignalR_Cshar_DB.Hubs;

public class ProductsHub:Hub 
{

    private readonly IProductService _productService;

    public ProductsHub(IProductService productService)
    {
        _productService = productService;
    }

    public async Task SendAsync(object state)
    {
        await Clients.All.SendAsync("ReceiveProduct", state);
    }

    public async Task postSendAsync(List<MProducts> state)
    {
        await Clients.All.SendAsync("ReceiveProduct", state);
    }

    public async Task GetTask()
    {
        var res = await _productService.GetAllProductAsync();

        await Clients.All.SendAsync("ReceiveProduct", res);
    }
}
