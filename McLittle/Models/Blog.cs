using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class Blog
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDiscription { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }

    }
}