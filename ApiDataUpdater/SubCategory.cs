using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class SubCategory
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Title { get; set; }
    }
}