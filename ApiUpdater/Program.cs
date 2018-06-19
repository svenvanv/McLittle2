﻿using System;
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
            Entities e = new Entities();

            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "categories");

            XmlNode node = doc.SelectSingleNode("Categories");
            foreach (XmlNode category in node.ChildNodes)
            {
                Category c = new Category();
                c.Title = category.SelectSingleNode("Name").InnerXml;
                foreach (XmlNode subcategory in category.ChildNodes)
                {
                    if(subcategory.Name != "Name")
                    {
                        
                        SubCategory s = new SubCategory();
                        s.Title = subcategory.SelectSingleNode("Name").InnerXml;

                        foreach (XmlNode subsubcategory in subcategory.ChildNodes)
                        {
                            if (subsubcategory.Name != "Name")
                            {
                                SubSubCategory ssc = new SubSubCategory();
                                ssc.Title = subsubcategory.SelectSingleNode("Name").InnerXml;

                                if (ssc == null)
                                {
                                    ssc = new SubSubCategory();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}