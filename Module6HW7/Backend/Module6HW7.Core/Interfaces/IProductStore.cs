using Module6HW7.Core.Entity;
namespace Module6HW7.Core.Interfaces
{
    public interface IProductStore
    {
        public Task<IList<Product>> GetProductAsync();

        public Task<Product> CreateProductAsync(Product product);

        public Task<bool> UpdateProductAsync(Product product);

        public Task<int> DeleteProductAsync(int id);
    }
}
