namespace SignalR_Cshar_DB.Models
{
    public class MMproductos
    {
        public List<MProducts> MProducts { get; }

        public IEnumerable<MProducts> gets()
        {
            return MProducts;
        }
    }
}
