using System.Collections.Generic;
using System.Linq;
using CRUD.Models;

namespace CRUD.Repo
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public List<Product> GetAll()
        {
             Console.WriteLine("GetAll method executed.");
             return _products;
        }

        public Product GetById(int id)
        {
            Console.WriteLine($"GetById method executed for ID: {id}");
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
             Console.WriteLine($"Add method executed for product: {product.Name}");
             product.Id = _nextId++;
            _products.Add(product);
        }

        public void Update(Product updatedProduct)
        {
            Console.WriteLine($"Update method executed for product: {updatedProduct.Name}");
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
            }
        }

        public void Delete(int id)
        {
            Console.WriteLine($"Delete method executed for ID: {id}");
            _products.RemoveAll(p => p.Id == id);
        }
        public bool IsRepositoryEmpty()
        {
            Console.WriteLine("IsRepositoryEmpty method executed.");
            return !_products.Any();
        }

        public int GetNumber()
        {
            Console.WriteLine("GetNumber method executed.");
            return 42;
        }
    }
}
