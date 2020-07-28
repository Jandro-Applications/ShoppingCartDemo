using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Models.ShoppingCart
{
    public class ShoppingCart : BaseModel
    {
        public List<ShoppingCartItem> Items { get; set; }
        public decimal Price { get; set; }
        public List<string> Discounts { get; set; }
    }
}
