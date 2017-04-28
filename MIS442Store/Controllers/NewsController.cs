using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MIS442Store.DataLayer.DataModels


{
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
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";

            //Call get news
          
           /*
            //New list
            List<News> news = new List<News>();

            //Article 1
            News article1 = new News();
            article1.id = 1;
            article1.title = "C++ for everyone";
            article1.body = "I love c++, it's a great language.";
            article1.author = "Travis Mason";
            article1.datePosted = new DateTime(2017,04,27);
            news.Add(article1);

            //Article 2
            News article2 = new News();
            article2.id = 2;
            article2.title = "C# for everyone";
            article2.body = "I love c#, it's a great language.";
            article2.author = "Travis Mason";
            article2.datePosted = new DateTime(2017, 04, 27);
            news.Add(article2);

            //Article 3
            News article3 = new News();
            article3.id = 3;
            article3.title = "LISP for everyone";
            article3.body = "I love LISP, it's a great language.";
            article3.author = "Travis Mason";
            article3.datePosted = new DateTime(2017, 04, 27);
            news.Add(article3);

    */

            return View(GetNews());
        }
        
    }
}