using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class SubCategory
    {
        [Display(Name = "Categorie")]
        public Category Category { get; set; }
        [Display(Name = "Categorie naam")]
        public int CategoryId { get; set; }

        [Key]
        [Display(Name = "Subcatgeorie naam")]
        public int SubCategoryId { get; set; }
        [Display(Name = "Categorie naam")]
        public string Title { get; set; }
        [Display(Name = "Afbeelding link")]
        public string ImageUrl { get; set; }
    }
}