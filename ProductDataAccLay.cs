using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRID_PRACTICE
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
    public class ProductDataAccLay
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> listProducts = new List<Product>();

            string CS = ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Product", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(rdr["Id"]);
                    product.ProductName = rdr["Name"].ToString();
                    product.Description = rdr["Description"].ToString();

                    listProducts.Add(product);
                }
            }

            return listProducts;
        }
    }
}