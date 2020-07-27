using ShoppingCart.Services.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Interfaces.Products
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(Guid id);
    }
}
