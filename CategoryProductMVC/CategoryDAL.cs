using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CategoryProductMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace CategoryProductMVC
{
    public class CategoryDAL
    {
        SqlConnection conn;

        public CategoryDAL()
        {
            conn = new SqlConnection("data source = localhost\\SQLEXPRESS; initial catalog = productinfo; integrated security = true");
        }

        public List<Category> GetCategories()
        {
            SqlCommand cmd = new SqlCommand("select * from category", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Category> list = new List<Category>();
            while (dr.Read())
            {
                Category c = new Category();
                c.CategoryId = Convert.ToInt32(dr[0]);
                c.CategoryName = dr[1].ToString();
                list.Add(c);
            }
            conn.Close();
            return list;
        }

        public Category GetCategoryById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from category where CategoryId = " + id, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Category c = new Category();
            while (dr.Read())
            {
                c.CategoryId = Convert.ToInt32(dr[0]);
                c.CategoryName = dr[1].ToString();
            }
            conn.Close();
            return c;
        }

        public int CreateCategory(Category c)
        {
            SqlCommand cmd = new SqlCommand("insert into category(CategoryName) values('" + c.CategoryName + "')", conn);
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

        public int EditCategory(Category c)
        {
            SqlCommand cmd = new SqlCommand("update category set CategoryName = '" + c.CategoryName + "' where CategoryId = " + c.CategoryId, conn);
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

        public int DeleteCategory(Category c)
        {
            SqlCommand cmd = new SqlCommand("delete from category where CategoryId = " + c.CategoryId, conn);
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