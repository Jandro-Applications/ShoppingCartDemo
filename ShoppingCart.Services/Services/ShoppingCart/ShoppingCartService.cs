using Microsoft.Extensions.Logging;
using ShoppingCart.Services.Interfaces.ShoppingCart;
using ShoppingCart.Services.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Services.ShoppingCart
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        public ShoppingCartService(ILogger<ShoppingCartService> logger) : base(logger)
        {
        }

        public bool AddToCart()
        {
            throw new NotImplementedException();
        }

        public Models.ShoppingCart.ShoppingCart Get()
        {
            throw new NotImplementedException();
        }
    }
}
