using Module6HW7.Core.Interfaces;
using Module6HW7.Core.Entity;
namespace Module6HW7.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductStore _productStore;

        public ProductService(IProductStore productStore)
        {
            _productStore = productStore;
        }

        public async Task<Product> ProductAddAsync(Product product)
        {
            return await _productStore.CreateProductAsync(product);      
        }

        public async Task<int> ProductDeleteAsync(int id)
        {
            return await _productStore.DeleteProductAsync(id);
        }

        public async Task<bool> ProductUpdateAsync(Product product)
        {
            if (product != null)
            {
                await _productStore.UpdateProductAsync(product);
                return true;
            }
            return false;
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _productStore.GetProductAsync();
        }
    }
}
