using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Models.ShoppingCart
{
    public class ShoppingCartItem : BaseModel
    {
        public int Quantity { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public int ProductCode { get; set; }
        public string ProductTitle { get; set; }
    }
}
