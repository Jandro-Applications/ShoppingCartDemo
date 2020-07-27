using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
