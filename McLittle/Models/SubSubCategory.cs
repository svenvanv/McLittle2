using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class SubSubCategory
    {
        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        [Key]
        public int SubSubCategoryId { get; set; }
        public string Title { get; set; }
    }
}