using Microsoft.AspNetCore.SignalR;
using SignalR_Cshar_DB.Models;

namespace SignalR_Cshar_DB.Hubs;

public class ProductsHub:Hub 
{
    public async Task SendAsync(object state)
    {
        await Clients.All.SendAsync("ReceiveProduct", state);
    }

    public async Task postSendAsync(List<MProducts> state)
    {
        await Clients.All.SendAsync("ReceiveProduct", state);
    }
}
