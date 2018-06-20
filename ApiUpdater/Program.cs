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
            Category();
            // Product();               
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

            XmlNode node = doc.SelectSingleNode("products");

        }



        //static void Product()
        //{
        //    Entities e = new Entities();

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(baseUri + "products");

        //    XmlNode node = doc.SelectSingleNode("products");

        //    //foreach (XmlNode category in node.ChildNodes)
        //    //{

        //    //}


        //    foreach (XmlNode products in node.ChildNodes)
        //    {
        //        foreach (XmlNode product in products.ChildNodes)
        //        {

        //        Product p = new Product();
        //            p.EAN = Convert.ToInt64(product.SelectSingleNode("EAN").InnerXml);
        //            p.title = product.SelectSingleNode("Title").InnerXml;
        //            p.brand = product.SelectSingleNode("Brand").InnerXml;
        //            p.shortDesc = product.SelectSingleNode("Shortdescription").InnerXml;
        //            p.fullDesc = product.SelectSingleNode("Fulldescription").InnerXml;
        //            p.imageLink = product.SelectSingleNode("Imageink").InnerXml;
        //            p.weight = product.SelectSingleNode("Weight").InnerXml;
        //            p.price = Convert.ToSingle(product.SelectSingleNode("Price").InnerXml);
        //            p.category = product.SelectSingleNode("Category").InnerXml;
        //            p.subCategory = product.SelectSingleNode("Subcategory").InnerXml;
        //            p.subsubCategory = product.SelectSingleNode("Subsubcategory").InnerXml;

        //            long EAN = Convert.ToUInt32(product.SelectSingleNode("EAN").InnerXml);
        //            Product ssc = e.Products.FirstOrDefault(jap => jap.EAN == EAN);
        //            if (ssc == null)
        //            {
        //                e.Products.Add(ssc);
        //                e.SaveChanges();
        //            }
        //        }
        //    }
        //}
    }
    }


