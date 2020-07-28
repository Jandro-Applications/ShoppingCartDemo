using Microsoft.Extensions.Logging;
using ShoppingCart.Services.Interfaces.Products;
using ShoppingCart.Services.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Services.Services.Products
{
    public class ProductsService : BaseService, IProductsService
    {
        private List<Product> _products = null;

        public ProductsService(ILogger<ProductsService> logger) : base(logger)
        {
            _products = new List<Product>
            {
                new Product{Id = Guid.NewGuid(), Code = 888, Category = "milk", DateCreated = DateTime.Now, DateModified = DateTime.Now, Title = "Milk", Description = "Whole milk with 3.8% fat", Price = 1.15m },
                new Product{Id = Guid.NewGuid(), Code = 123, Category = "butter", DateCreated = DateTime.Now, DateModified = DateTime.Now, Title = "Butter", Description = "Butter first class, 250 grams", Price = 0.80m },
                new Product{Id = Guid.NewGuid(), Code = 456, Category = "bread", DateCreated = DateTime.Now, DateModified = DateTime.Now, Title = "Bread", Description = "Corn bread with seeds", Price = 1.00m }
            };
        }

        public List<Product> GetAll()
        {
            try
            {
                return _products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetById(Guid id)
        {
            try
            {
                return _products.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
