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
            try
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

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Models.ShoppingCart.ShoppingCart Get()
        {
            _logger.LogTrace($"Shopping cart details: {Newtonsoft.Json.JsonConvert.SerializeObject(_shoppingCart)}");

            return _shoppingCart;
        }

        public Models.ShoppingCart.ShoppingCart GetSummary()
        {
            Models.ShoppingCart.ShoppingCart summary = _shoppingCart;

            try
            {
                if (summary != null && summary.Items != null && summary.Items.Count() > 0)
                {
                    var butterCount = summary.Items.FirstOrDefault(x => x.ProductCategory == "butter")?.Quantity;
                    int breadDiscountsCount = 0;

                    if (butterCount.HasValue)
                    {
                        breadDiscountsCount = butterCount.Value / 2;
                    }

                    foreach (var item in summary.Items)
                    {
                        item.Price = CalculateItemPrice(item, breadDiscountsCount, out string discount);

                        if (!string.IsNullOrEmpty(discount))
                        {
                            _shoppingCart.Discounts.Add(discount);
                        }
                    }

                    _shoppingCart.Price = _shoppingCart.Items.Sum(x => x.Price);
                }
            }
            catch (Exception)
            {
                _logger.LogError("Error on calculating prices");
            }

            _logger.LogInformation($"Shopping cart summary details: {Newtonsoft.Json.JsonConvert.SerializeObject(_shoppingCart)}");

            return summary;
        }

        public void ClearCart()
        {
            _shoppingCart = null;
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
                Price = 0.0m,
                Discounts = new List<string>()
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
                BasePrice = product.Price,
                ProductCategory = product.Category
            };
        }

        private decimal CalculateItemPrice(ShoppingCartItem item, int breadDiscountsCount, out string discount)
        {
            decimal price;
            discount = "";

            if (item.ProductCategory == "milk")
            {
                price = (item.Quantity - item.Quantity / 4) * item.BasePrice;
                discount = $"{item.Quantity / 4} milk with discount";
            }
            else if ((breadDiscountsCount > 0) && item.ProductCategory == "bread")
            {

                if (item.Quantity < breadDiscountsCount || item.Quantity == breadDiscountsCount)
                {
                    price = (item.Quantity) * item.BasePrice / 2;
                }
                else
                {
                    var original = (item.Quantity - breadDiscountsCount) * item.BasePrice;
                    var withDiscount = breadDiscountsCount * item.BasePrice / 2;

                    price = original + withDiscount;

                    discount = $"{breadDiscountsCount} bread with discount";
                }
            }
            else
            {
                price = item.BasePrice * item.Quantity;
            }

            return price;
        }
    }
}
