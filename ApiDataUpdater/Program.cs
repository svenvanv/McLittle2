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
            updateProduct();
        }

        static void updateProduct()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(baseUri + "products");
            string xmlContent = doc.InnerXml;

            XmlElement xmlRoot = doc.DocumentElement;
            XmlNodeList xmlNodes = xmlRoot.SelectNodes("/Products/Product");

            foreach (XmlNode XmlNode in xmlNodes)
            {
                count++;
                Console.WriteLine("Toevoegen aan database EAN = " + XmlNode["EAN"].InnerText + " product nummer " + count);

                var con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-McLittle-20180516011236;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                
                    con.Open();
                var sql = "INSERT INTO Products(EAN, title, brand, shortDesc, fullDesc, imageLink, weight, price, category, subCategory, subsubCategory) Values(@EAN, @title, @brand, @shortDesc, @fullDesc, @imageLink, @weight, @price, @category, @subCategory, @subsubCategory)";
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EAN", xmd)
                }
                
            }
            Console.WriteLine("producten toegevoegd " + count);
            Console.ReadLine();
        }
    }
}
