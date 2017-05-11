using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.DataModels;
using System.Data;
using System.Data.SqlClient;

namespace MIS442Store.DataLayer.Repositories
{
    public class NewsRepository : INewsRepository
    {
        //Private member variable of type INewsRepository
        private INewsRepository newsrepository;

        //Constructor
        public NewsRepository()
        {
            newsrepository = new NewsRepository();
        }
        

        public News Get(int id)
        {
            News news = new News();
            return news;
        }

        public List<News> GetList()
        {
            List < News >  newsList = new List<News>();

            
           
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                //Open the connection
                connection.Open();

                return newsList;
            }
        }
        
        public void Save(News news)
        {
            //New connection to sql server database initialized.
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM News";
                    command.CommandType = System.Data.CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            //Add news to the list
                            command.ExecuteNonQuery();

                        }
                    }
                }
            }


            //Perform insert if true that there are no items in the list of news items
            if (news.id == 0)
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM News";
                        command.CommandType = System.Data.CommandType.Text;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                            }
                        }
                    }
                }
            }
               
            
            //Perform update since we have news items
            else
            {
                //Read from table 
            }
        }
    }
}