using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class Category
    {
        [Display(Name = "Hoofd categorie")]
        public int CategoryId { get; set; }
        [Display(Name = "Categorie naam")]
        public string Title { get; set; }
        [Display(Name = "EAfbeelding link")]
        public string ImageUrl { get; set; }
    }
}