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
    public class RegistrationRepository : IRegistrationRepository
    {
        
            //Private member variable of type INewsRepository
            private IRegistrationRepository registrationrepository;

            //Constructor
            public RegistrationRepository()
            {
                registrationrepository = new RegistrationRepository();
            }


        public Registration GetRegistration(int id)
        {
            Registration registration = new Registration();
            return registration;
        }

        public List<Registration> GetRegistrations()
        {
            List<Registration> registrationList = new List<Registration>();



            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                //Open the connection
                connection.Open();

                return registrationList;
            }
        }

        
        public List<Registration> GetUserRegistrations(string username)
            {
                List<Registration> registrationList = new List<Registration>();



                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
                {
                    //Open the connection
                    connection.Open();

                    return registrationList;
                }
            }

        public void SaveRegistration(Registration registration)
        {
            //New connection to sql server database initialized.
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
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
        }
    }
}
