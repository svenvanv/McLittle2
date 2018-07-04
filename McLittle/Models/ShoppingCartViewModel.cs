using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class ShoppingCartViewModel
    {
     
        public List<Cart> CartItems { get; set; }
        public float CartTotal { get; set; }
    }
}