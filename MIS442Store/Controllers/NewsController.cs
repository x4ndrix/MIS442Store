using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MIS442Store.DataLayer.DataModels { 



    public class NewsController : Controller
    {
         //Function that returns a list of news objects
        private List<News> GetNews()
        {
            //New list
            List<News> news = new List<News>();

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
                            News newsItem = new News();

                            newsItem.id = int.Parse(reader["ID"].ToString());
                            newsItem.title = reader["Title"].ToString();
                            newsItem.author = reader["Author"].ToString();
                            newsItem.datePosted = DateTime.Parse(reader["DatePosted"].ToString());

                            //Add news to the list
                            news.Add(newsItem);
                        }
                    }
                }
            }
            return news;
        }

        // GET: News
        public ActionResult Index()
        { 
            return View(GetNews());
        }
    }
}