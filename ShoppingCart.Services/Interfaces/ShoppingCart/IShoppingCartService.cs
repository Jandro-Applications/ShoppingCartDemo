using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Interfaces.ShoppingCart
{
    public interface IShoppingCartService
    {
        Models.ShoppingCart.ShoppingCart Get();
        bool AddToCart();
    }
}
