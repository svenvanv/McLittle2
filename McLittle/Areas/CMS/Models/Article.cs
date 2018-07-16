using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLittle.Areas.CMS.Models
{
    public class Article
    {
        [Key]
        [Display(Name = "NieuwsId")]
        public int ArticleId { get; set; }
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Display(Name = "Inhoud")]
        public string Content { get; set; }
        [Display(Name = "Afbeelding")]
        public string ImagePath { get; set; }
    }
}