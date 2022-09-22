using Module6HW7.Core.Entity;
namespace Module6HW7.Core.Interfaces
{
    public interface IProductService
    {
        public  Task<Product> ProductAddAsync(Product product);

        public Task<int> ProductDeleteAsync(int id);

        public Task<bool> ProductUpdateAsync(Product product);

        public Task<IList<Product>> GetAllAsync();
    }
}
