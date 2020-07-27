using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Models.ShoppingCart
{
    public class ShoppingCart : BaseModel
    {
        public List<ShoppingCartItem> Items { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal PriceSum { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
