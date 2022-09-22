using Microsoft.EntityFrameworkCore;
using Module6HW7.Core;
using Module6HW7.Core.Entity;
using Module6HW7.Core.Interfaces;

namespace Module6HW7.Infrastructure;
public class ProductStore : IProductStore
{
    private readonly EntityContext _entityContext;

    public ProductStore(EntityContext entityContext)
    {
        _entityContext = entityContext;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _entityContext.Add(product);
        await _entityContext.SaveChangesAsync();
        return product;
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        var product = _entityContext.Product.FirstOrDefault(x => x.Id == id);

        if(product != null)
        {
            _entityContext.Remove(product);
        }

        await _entityContext.SaveChangesAsync();
        return id;
    }

    public async Task<IList<Product>> GetProductAsync()
    {
        return await _entityContext.Product.ToListAsync();
    }


    public async Task<bool> UpdateProductAsync(Product product)
    {
        if (product != null)
        {
            _entityContext.Update(product);
            return true;
        }    
        
        await _entityContext.SaveChangesAsync();
        return false;
    }
}
