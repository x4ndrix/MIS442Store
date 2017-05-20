using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            //Create instance of product
            Product product = null;
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Product_Get";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product();
                            product.ProductID = int.Parse(reader["ProductID"].ToString());
                            product.ProductCode = reader["ProductCode"].ToString();
                            product.ProductName = reader["ProductName"].ToString();
                            product.ProductReleaseDate = DateTime.Parse(reader["ProductReleaseDate"].ToString());
                            product.ProductVersion = double.Parse(reader["ProductVersion"].ToString());
                        }

                    }
                }
            }
            return product;

            //Repo method below

        }

        public List<Product> GetList()
        {
            List<Product> prodList = new List<Product>();

            //New connection to sql server database initialized.
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Product_GetList";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                   
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.ProductID = int.Parse(reader["ProductID"].ToString());
                            product.ProductCode = reader["ProductCode"].ToString();
                            product.ProductName =  reader["ProductName"].ToString();
                            product.ProductReleaseDate = DateTime.Parse(reader["ProductReleaseDate"].ToString());
                            product.ProductVersion = double.Parse(reader["ProductVersion"].ToString());

                            prodList.Add(product);
                        }

                    }

                        

                }
            }

            

            //Get list of products
            return prodList;
        }

        public void Save(Product product)
        {
            //New connection to sql server database initialized.
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Product_InsertUpdate";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (product.ProductID != 0)
                    {
                        command.Parameters.AddWithValue("@ID", product.ProductID);
                    }
                    command.Parameters.AddWithValue("@Code", product.ProductCode);
                    command.Parameters.AddWithValue("@Name", product.ProductName);
                    command.Parameters.AddWithValue("@Version", product.ProductVersion);
                    command.Parameters.AddWithValue("@ReleaseDate", product.ProductReleaseDate);
                    connection.Open();


                    //Add news to the list
                    command.ExecuteNonQuery();


                }
            }

           

        }
    }
}