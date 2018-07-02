using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ApiUpdater
{
    class Program
    {
        static string baseUri = "https://supermaco.starwave.nl/api/";
        static void Main(string[] args)
        {
            Category();
            Product();
            //Promotions();
        }
        static void Category()
        {
            Entities e = new Entities();

            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "categories");

            XmlNode node = doc.SelectSingleNode("Categories");
            foreach (XmlNode category in node.ChildNodes)
            {
                string cName = category.SelectSingleNode("Name").InnerXml;
                Category c = e.Categories.FirstOrDefault(sven => sven.Title == cName);
                if (category.Name != "Name")
                {
                    c = new Category();
                    c.Title = category.SelectSingleNode("Name").InnerXml;
                    e.Categories.Add(c);
                    e.SaveChanges();
                }
                foreach (XmlNode subcategory in category.ChildNodes)
                {
                    if (subcategory.Name != "Name")
                    {
                        string scName = subcategory.SelectSingleNode("Name").InnerXml;
                        SubCategory sc = e.SubCategories.FirstOrDefault(sven => sven.Title == scName && sven.Category.Title == c.Title);
                        if (sc == null)
                        {
                            sc = new SubCategory();

                            sc.Title = subcategory.SelectSingleNode("Name").InnerXml;
                            sc.Category = c;
                            sc.CategoryId = sc.Category.CategoryId;
                            e.SubCategories.Add(sc);
                            e.SaveChanges();
                        }

                        foreach (XmlNode subsubcategory in subcategory.ChildNodes)
                        {
                            if (subsubcategory.Name != "Name")
                            {
                                string sscName = subsubcategory.SelectSingleNode("Name").InnerXml;
                                SubSubCategory ssc = e.SubSubCategories.FirstOrDefault(sven => sven.Title == sscName && sven.SubCategory.Title == sc.Title);
                                if (ssc == null)
                                {
                                    ssc = new SubSubCategory();
                                    ssc.Title = sscName;
                                    ssc.SubCategory = sc;
                                    ssc.SubCategoryId = ssc.SubCategory.SubCategoryId;
                                    e.SubSubCategories.Add(ssc);
                                    e.SaveChanges();
                                }


                            }
                        }
                    }
                }
            }
        }


        static void Product()
        {
            Entities e = new Entities();

            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "products");

            XmlNode node = doc.SelectSingleNode("Products");
            foreach (XmlNode prod in node.ChildNodes)
            {
                
                if (prod.Name != "Title")
                {
                    string cName = prod.SelectSingleNode("Title").InnerXml;
                    Product p = e.Products.FirstOrDefault(sven => sven.title == cName);
                    if (p == null)
                    {
                        p = new Product();
                        p.EAN = Convert.ToInt64(prod.SelectSingleNode("EAN").InnerXml);
                        p.title = prod.SelectSingleNode("Title").InnerXml;
                        p.brand = prod.SelectSingleNode("Brand").InnerXml;
                        p.shortDesc = prod.SelectSingleNode("Shortdescription").InnerXml;
                        p.fullDesc = prod.SelectSingleNode("Fulldescription").InnerXml;
                        p.imageLink = prod.SelectSingleNode("Image").InnerXml;
                        p.weight = prod.SelectSingleNode("Weight").InnerXml;
                        p.price = Convert.ToSingle(prod.SelectSingleNode("Price").InnerXml);
                        p.category = prod.SelectSingleNode("Category").InnerXml;
                        p.subCategory = prod.SelectSingleNode("Subcategory").InnerXml;
                        p.subsubCategory = prod.SelectSingleNode("Subsubcategory").InnerXml;
                        e.Products.Add(p);
                        e.SaveChanges();
                    }
                }
            }
        }
        static void Promotions()
        {
            Entities e = new Entities();

            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "promotions");

            XmlNode node = doc.SelectSingleNode("Promotions");
            foreach (XmlNode prod in node.ChildNodes)
            {

                if (prod.Name != "Title")
                {
                    string cName = prod.SelectSingleNode("Title").InnerXml;
                    Discount p = e.Discounts.FirstOrDefault(sven => sven.title == cName);
                    if (p == null)
                    {
                        p = new Discount();
                        p.EAN = Convert.ToInt64(prod.SelectSingleNode("EAN").InnerXml);
                        p.title = prod.SelectSingleNode("Title").InnerXml;
                        p.price = Convert.ToSingle(prod.SelectSingleNode("DiscountPrice").InnerXml);
                        p.validUntil = Convert.ToDateTime(prod.SelectSingleNode("ValidUntil").InnerXml);
                        e.Discounts.Add(p);
                        e.SaveChanges();
                    }
                }
            }
        }
        //static void Delivery()
        //{
        //    Entities e = new Entities();

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(baseUri + "deliveryslots");

        //    XmlNode node = doc.SelectSingleNode("Deliveryslots");
        //    foreach (XmlNode prod in node.ChildNodes)
        //    {

        //        if (prod.Name != "Title")
        //        {
        //            string cName = prod.SelectSingleNode("Date").InnerXml;
        //            Delivery p = e.de.FirstOrDefault(sven => sven. == cName);
        //            if (p == null)
        //            {
        //                p = new Discount();
        //                p.EAN = Convert.ToInt64(prod.SelectSingleNode("EAN").InnerXml);
        //                p.title = prod.SelectSingleNode("Title").InnerXml;
        //                p.price = Convert.ToSingle(prod.SelectSingleNode("DiscountPrice").InnerXml);
        //                p.validUntil = Convert.ToDateTime(prod.SelectSingleNode("ValidUntil").InnerXml);
        //                e.Discounts.Add(p);
        //                e.SaveChanges();
        //            }
        //        }
        //    }
        //}
    }
    }


