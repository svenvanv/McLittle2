using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class SubSubCategory
    {
        [Display(Name = "SubCategorie")]
        public SubCategory SubCategory { get; set; }
        [Display(Name = "SubCategorie naam")]
        public int SubCategoryId { get; set; }

        [Key]
        [Display(Name = "SubsubCategorie")]
        public int SubSubCategoryId { get; set; }
        [Display(Name = "Categorie naam")]
        public string Title { get; set; }
        [Display(Name = "Afbeelding url")]
        public string ImageUrl { get; set; }
    }
}