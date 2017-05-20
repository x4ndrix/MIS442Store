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
    public class StateRepository : IStateRepository
    {
        
        //Private member variable of type INewsRepository
        private IStateRepository staterepository;

        //Constructor
        public StateRepository()
        {
            staterepository = new StateRepository();
        }


        public USState Get(string name)
        {
            USState state = new USState();
            return state;
        }

        public List<USState> GetStates()
        {
            List < USState > stateList = new List<USState>();



            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                //Open the connection
                connection.Open();

                return stateList;
            }
        }

        public void Save(USState state)
        {
            //New connection to sql server database initialized.
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM State";
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
            if (state.name == "")
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM State";
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
