using Module6HW7.Core.Entity;
using Module6HW7.Core.Interfaces;
using Module6HW7.Core.Services;
using Module6HW7.Infrastructure;
using Module6HW7.Core;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Module6HW7.Core.Tests;

public class UnitTest1
{
    [Fact]
    public void Add_ValidProduct_AddedInDatabase()
    {
        var product = new Product(1, "d", 10.0M);
        var store = Mock.Of<IProductStore>(p => p.CreateProductAsync(It.IsAny<Product>()).Result == product);
        var service = new ProductService(store);

        var product1 = service.ProductAddAsync(product).Result;

        Assert.Equal(product, product1);
    }

    [Fact]
    public void Get_ValidProduct_GetFromDatabase()
    {
        var products = new List<Product>();
         
        var store = Mock.Of<IProductStore>(p => p.GetProductAsync().Result == products);
        var service = new ProductService(store);

        var listProducts = service.GetAllAsync().Result;

        Assert.Equal(0, listProducts.Count);
    }

    [Fact]
    public void Delete_ValidProduct_DeleteFromDatabase()
    {
        var product = new Product(1, "d", 10.0M);
        var store = Mock.Of<IProductStore>(p => p.DeleteProductAsync(It.IsAny<int>()).Result == 1 &&
         p.CreateProductAsync(It.IsAny<Product>()).Result == product);

        var service = new ProductService(store);

        var create = service.ProductAddAsync(product).Result;
        var delete = service.ProductDeleteAsync(create.Id).Result;

        Assert.Equal(1, delete);
    }

    [Fact]
    public void Update_NullProduct_NotUpdateDatabase()
    {
        var product = new Product(1, "d", 10.0M);

        var store = Mock.Of<IProductStore>(p => p.UpdateProductAsync(It.IsAny<Product>()).Result == false);

        var service = new ProductService(store);

        var update = service.ProductUpdateAsync(null).Result;

        Assert.False(update);
    }

    [Fact]
    public void Update_ValidProduct_UpdateDatabase()
    {
        var product = new Product(1, "d", 10.0M);

        var store = Mock.Of<IProductStore>(p => p.UpdateProductAsync(It.IsAny<Product>()).Result == true &&
         p.CreateProductAsync(It.IsAny<Product>()).Result == product);

        var service = new ProductService(store);

        var create = service.ProductAddAsync(product).Result;
        var update = service.ProductUpdateAsync(create).Result;

        Assert.True(update);
    }
}