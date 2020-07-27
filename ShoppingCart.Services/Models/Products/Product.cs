using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Models.Product
{
    public class Product : BaseModel
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
