using SignalR_Cshar_DB.Models;

namespace SignalR_Cshar_DB.Service.Interface
{
    public interface IDatasServices
    {
        Task<List<MProducts>> GetDatos();

        //List<MProducts> GetProduct();
    }
}
