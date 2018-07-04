using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace McLittle.Models
{
    public class Product
    {
        public int productId { get; set; }
        public long EAN { get; set; }
        [DisplayName("Titel")]
        public string title { get; set; }
        [DisplayName("Merk")]
        public string brand { get; set; }
        [DisplayName("Korte omschrijving")]
        public string shortDesc { get; set; }
        [DisplayName("Volledige omschrijving")]
        public string fullDesc { get; set; }
        [DisplayName("Afbeelding link")]
        public string imageLink { get; set; }
        [DisplayName("Gewicht")]
        public string weight { get; set; }
        [DisplayName("Prijs")]
        public float price { get; set; }
        [DisplayName("Categorie")]
        public string category { get; set; }
        [DisplayName("Subcategorie")]
        public string subCategory { get; set; }
        [DisplayName("Subsubcategorie")]
        public string subsubCategory { get; set; }
    }
}
