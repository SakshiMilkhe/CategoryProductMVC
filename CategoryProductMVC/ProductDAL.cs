using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CategoryProductMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace CategoryProductMVC
{
    public class ProductDAL
    {
        SqlConnection conn;

        public ProductDAL()
        {
            conn = new SqlConnection("data source = localhost\\SQLEXPRESS; initial catalog = productinfo; integrated security = true");
        }

        public List<Product> GetProducts()
        {
            SqlCommand cmd = new SqlCommand("select * from products", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Product> list = new List<Product>();
            while (dr.Read())
            {
                Product p = new Product();
                p.ProductId = Convert.ToInt32(dr[0]);
                p.ProductName = dr[1].ToString();
                p.CategoryId = Convert.ToInt32(dr[2]);
                p.CategoryName = dr[3].ToString();
                list.Add(p);
            }
            conn.Close();
            return list;
        }

        public Product GetProductById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from products where ProductId = " + id, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Product p = new Product();
            while (dr.Read())
            {
                p.ProductId = Convert.ToInt32(dr[0]);
                p.ProductName = dr[1].ToString();
                p.CategoryId = Convert.ToInt32(dr[2]);
                p.CategoryName = dr[3].ToString();
            }
            conn.Close();
            return p;
        }

        public int CreateProduct(Product p)
        {
            SqlCommand cmd = new SqlCommand("insert into products(ProductName, CategoryId, CategoryName) values('" + p.ProductName + "', " + p.CategoryId + ", '" + p.CategoryName + "')", conn);
            conn.Open();
            int data = cmd.ExecuteNonQuery();
            if (data > 0)
            {
                conn.Close();
                return data;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        public int EditProduct(Product p)
        {
            SqlCommand cmd = new SqlCommand("update products set ProductName = '" + p.ProductName +"' where ProductId = " + p.ProductId, conn);
            conn.Open();
            int data = cmd.ExecuteNonQuery();
            if (data > 0)
            {
                conn.Close();
                return data;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        public int DeleteProduct(Product p)
        {
            SqlCommand cmd = new SqlCommand("delete from products where ProductId = " + p.ProductId, conn);
            conn.Open();
            int data = cmd.ExecuteNonQuery();
            if (data > 0)
            {
                conn.Close();
                return data;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }
    }
}