using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ApiDataUpdater
{
    class Program
    {
        static string baseUri = "https://supermaco.starwave.nl/api/";
        static int count;
        static void Main(string[] args)
        {
            //updateProduct();
            //updateCategory();
            //updateSubCategory();
            //updateSubSubCategory();
            updatePromotions();
            updateDelivery();

            Console.ReadLine();
        }

        static void updateProduct()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "products");
            string xmlContent = doc.InnerXml;

            XmlElement xmlRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xmlRoot.SelectNodes("/Products/Product");

            count = 0;
            foreach (XmlNode XmlNode in xmlNodes)
            {
                count++;
                Console.WriteLine("Toevoegen aan database EAN = " + XmlNode["EAN"].InnerText + " product nummer " + count);

                var con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sven\Documents\GitHub\McLittle2\McLittle\App_Data\aspnet-McLittle-20180516011236.mdf;Initial Catalog=aspnet-McLittle-20180516011236;Integrated Security=True");

                con.Open();
                //Table veranderen naar products hieronder!!
                var sql = "INSERT INTO Products(EAN, title, brand, shortDesc, fullDesc, imageLink, weight, price, category, subCategory, subsubCategory) Values(@EAN, @title, @brand, @shortDesc, @fullDesc, @imageLink, @weight, @price, @category, @subCategory, @subsubCategory)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EAN", XmlNode["EAN"].InnerText);
                    cmd.Parameters.AddWithValue("@title", XmlNode["Title"].InnerText);
                    cmd.Parameters.AddWithValue("@brand", XmlNode["Brand"].InnerText);
                    cmd.Parameters.AddWithValue("@shortDesc", XmlNode["Shortdescription"].InnerText);
                    cmd.Parameters.AddWithValue("@fullDesc", XmlNode["Fulldescription"].InnerText);
                    cmd.Parameters.AddWithValue("@imageLink", XmlNode["Image"].InnerText);
                    cmd.Parameters.AddWithValue("@weight", XmlNode["Weight"].InnerText);
                    cmd.Parameters.AddWithValue("@price", XmlNode["Price"].InnerText);
                    cmd.Parameters.AddWithValue("@category", XmlNode["Category"].InnerText);
                    cmd.Parameters.AddWithValue("@subCategory", XmlNode["Subcategory"].InnerText);
                    cmd.Parameters.AddWithValue("@subsubCategory", XmlNode["Subsubcategory"].InnerText);

                    cmd.ExecuteNonQuery();
                }
                //using (var connection = new SqlConnection(@"");
            }
            Console.WriteLine("producten toegevoegd " + count);

        }

        static void updateCategory()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "categories");
            string xmlContent = doc.InnerXml;

            XmlElement xmlRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xmlRoot.SelectNodes("/Categories/Category");
            count = 0;
            foreach (XmlNode XmlNode in xmlNodes)
            {
                count++;
                Console.WriteLine("Toevoegen aan database naam = " + XmlNode["Name"].InnerText + " category nummer " + count);
                var con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sven\Documents\GitHub\McLittle2\McLittle\App_Data\aspnet-McLittle-20180516011236.mdf;Initial Catalog=aspnet-McLittle-20180516011236;Integrated Security=True");

                con.Open();
                //Table veranderen naar products hieronder!!
                var sql = "INSERT INTO Categories(Title) Values(@Name)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", XmlNode["Name"].InnerText);

                    cmd.ExecuteNonQuery();
                }
                //using (var connection = new SqlConnection(@"");
            }
            Console.WriteLine("Categorieen toegevoegd " + count);
        }

        static void updateSubCategory()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "categories");
            string xmlContent = doc.InnerXml;

            XmlElement xmlRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xmlRoot.SelectNodes("/Categories/Category/Subcategory");
            count = 0;
            foreach (XmlNode XmlNode in xmlNodes)
            {
                count++;
                Console.WriteLine("Toevoegen aan database naam = " + XmlNode["Name"].InnerText + " category nummer " + count);
                var con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sven\Documents\GitHub\McLittle2\McLittle\App_Data\aspnet-McLittle-20180516011236.mdf;Initial Catalog=aspnet-McLittle-20180516011236;Integrated Security=True");

                con.Open();
                //Table veranderen naar products hieronder!!
                var sql = "INSERT INTO SubCategories(Title) Values(@Name)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", XmlNode["Name"].InnerText);

                    cmd.ExecuteNonQuery();
                }
                //using (var connection = new SqlConnection(@"");
            }
            Console.WriteLine("Categorieen toegevoegd " + count);
        }

        static void updateSubSubCategory()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "categories");
            string xmlContent = doc.InnerXml;

            XmlElement xmlRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xmlRoot.SelectNodes("/Categories/Category/Subcategory/Subsubcategory");
            count = 0;
            foreach (XmlNode XmlNode in xmlNodes)
            {
                count++;
                Console.WriteLine("Toevoegen aan database naam = " + XmlNode["Name"].InnerText + " category nummer " + count);
                var con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sven\Documents\GitHub\McLittle2\McLittle\App_Data\aspnet-McLittle-20180516011236.mdf;Initial Catalog=aspnet-McLittle-20180516011236;Integrated Security=True");

                con.Open();
                //Table veranderen naar products hieronder!!
                var sql = "INSERT INTO SubSubCategories(Title) Values(@Name)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", XmlNode["Name"].InnerText);

                    cmd.ExecuteNonQuery();
                }
                //using (var connection = new SqlConnection(@"");
            }
            Console.WriteLine("Categorieen toegevoegd " + count);
        }
        static void updatePromotions()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "promotions");
            string xmlContent = doc.InnerXml;

            XmlElement xmlRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xmlRoot.SelectNodes("/Promotions/Promotion");
            count = 0;
            foreach (XmlNode XmlNode in xmlNodes)
            {
                count++;
                Console.WriteLine("Toevoegen aan database promotie = " + XmlNode["Title"].InnerText + " promotie nummer " + count);

                var con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sven\Documents\GitHub\McLittle2\McLittle\App_Data\aspnet-McLittle-20180516011236.mdf;Initial Catalog=aspnet-McLittle-20180516011236;Integrated Security=True");

                con.Open();
                var sql = "INSERT INTO Discount(title, EAN, price, validUntil) Values(@Name, @EAN, @price, @validUntil)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", XmlNode["Title"].InnerText);

                    XmlNodeList addrNodes = XmlNode.SelectNodes("/Discount");
                    foreach (XmlNode addrn in addrNodes)
                    {


                        cmd.Parameters.AddWithValue("@EAN", XmlNode["EAN"].InnerText);
                        cmd.Parameters.AddWithValue("@price", XmlNode["DiscountPrice"].InnerText);
                        cmd.Parameters.AddWithValue("@validUntil", XmlNode["ValidUntil"].InnerText);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("promoties toegevoegd " + count);
        }

        static void updateDelivery()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "deliveryslots");
            string xmlContent = doc.InnerXml;

            XmlElement xmlRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xmlRoot.SelectNodes("/Deliveryslots/Deliveryslot");
            count = 0;
            foreach (XmlNode XmlNode in xmlNodes)
            {
                count++;
                Console.WriteLine("Toevoegen aan database deliveryslots = " + XmlNode["Date"].InnerText + " delivery nummer " + count);

                //using (var connection = new SqlConnection(@"");
            }
            Console.WriteLine("Delivery slot toegevoegd " + count);
        }
    }
}
