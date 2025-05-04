namespace ProductRepositoryDummyTest;

using System.Collections.Generic;
using CRUD.Models;
using Xunit;
using CRUD.Repo;

public class ProductRepositoryDummyTests
{
    private readonly ProductRepository _repository = new();

    [Fact]
    public void GetAll_InitiallyEmpty()
    {
        var products = _repository.GetAll();
        Assert.Empty(products);
    }

    [Fact]
    public void Add_Product_ShouldIncreaseCount()
    {
        var product = new Product { Name = "Test Product", Price = 10.5M };
        _repository.Add(product);

        var products = _repository.GetAll();
        Assert.Single(products);
    }

    [Fact]
    public void GetById_ReturnsCorrectProduct()
    {
        var product = new Product { Name = "Test Product", Price = 20M };
        _repository.Add(product);

        var result = _repository.GetById(product.Id);
        Assert.NotNull(result);
        Assert.Equal("Test Product", result.Name);
        Assert.Equal(20M, result.Price);
    }

    [Fact]
    public void Update_Product_ShouldModifyValues()
    {
        var product = new Product { Name = "Old Name", Price = 15M };
        _repository.Add(product);

        product.Name = "Updated Name";
        product.Price = 25M;
        _repository.Update(product);

        var updatedProduct = _repository.GetById(product.Id);
        Assert.NotNull(updatedProduct);
        Assert.Equal("Updated Name", updatedProduct.Name);
        Assert.Equal(25M, updatedProduct.Price);
    }

    [Fact]
    public void Delete_Product_RemovesItFromList()
    {
        var product = new Product { Name = "To Be Deleted", Price = 5M };
        _repository.Add(product);

        _repository.Delete(product.Id);
        var result = _repository.GetById(product.Id);

        Assert.Null(result);
        Assert.Empty(_repository.GetAll());
    }

    [Fact]
    public void TestIsRepositoryEmpty()
    {
        var repo = new ProductRepository();
        Assert.True(repo.IsRepositoryEmpty());
    }

    [Fact]
    public void TestGetNumber()
    {
        var repo = new ProductRepository();
        Assert.Equal(42, repo.GetNumber());
    }
}
