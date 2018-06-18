using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class Discount
    {
        public int discountId { get; set; }
        public string title { get; set; }
        public long EAN { get; set; }
        public double price { get; set; }
        public DateTime validUntil { get; set; }
    }
}