using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int EAN { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}