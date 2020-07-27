using Microsoft.Extensions.Logging;
using ShoppingCart.Services.Interfaces.ShoppingCart;
using ShoppingCart.Services.Models.Product;
using ShoppingCart.Services.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Services.Services.ShoppingCart
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        private Models.ShoppingCart.ShoppingCart _shoppingCart = null;

        public ShoppingCartService(ILogger<ShoppingCartService> logger) : base(logger)
        {
        }

        public bool AddToCart(Product product)
        {
            if (_shoppingCart != null)
            {
                ShoppingCartItem cartItem = _shoppingCart.Items.FirstOrDefault(x => x.ProductCode == product.Code);

                if (cartItem != null)
                {
                    cartItem.Quantity += 1;
                }
                else
                {
                    _shoppingCart.Items.Add(SetShoppingCartItem(product));
                }
            }
            else
            {
                SetNewShoppingCart(product);
            }

            return CalculatePrices();
        }

        public Models.ShoppingCart.ShoppingCart Get()
        {
            _logger.LogTrace($"Shopping cart details: {Newtonsoft.Json.JsonConvert.SerializeObject(_shoppingCart)}");

            return _shoppingCart;
        }

        private void SetNewShoppingCart(Product product)
        {
            _shoppingCart = new Models.ShoppingCart.ShoppingCart
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Id = Guid.NewGuid(),
                Items = new List<ShoppingCartItem>
                    {
                        SetShoppingCartItem(product)
                    },
                DiscountPrice = 0.0m,
                OriginalPrice = 0.0m,
                PriceSum = 0.0m
            };
        }

        private ShoppingCartItem SetShoppingCartItem(Product product)
        {
            return new ShoppingCartItem
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Id = Guid.NewGuid(),
                ProductCode = product.Code,
                ProductTitle = product.Title,
                Quantity = 1,
                Price = product.Price,
                BasePrice = product.Price
            };
        }

        private bool CalculatePrices()
        {
            try
            {

            }
            catch (Exception)
            {
                _logger.LogError("Error on calculating prices");
                return false;
            }

            return true;
        }
    }
}
