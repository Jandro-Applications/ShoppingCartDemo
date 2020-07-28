using ShoppingCart.Services.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Interfaces.ShoppingCart
{
    public interface IShoppingCartService
    {
        Models.ShoppingCart.ShoppingCart Get();
        Models.ShoppingCart.ShoppingCart GetSummary();
        bool AddToCart(Product product);
        void ClearCart();
    }
}
