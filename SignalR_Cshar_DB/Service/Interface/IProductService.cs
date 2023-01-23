using SignalR_Cshar_DB.Models;

namespace SignalR_Cshar_DB.Service.Interface
{
    public interface IProductService
    {
        Task<List<MProducts>> GetAllProductAsync();

        Task<bool> PostProductAsync(MProducts product);

        Task<bool> UpdateProductAsync(MProducts product);
    }
}
