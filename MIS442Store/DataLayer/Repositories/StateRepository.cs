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
        
        


        

        public List<USState> GetStates()
        {
            List < USState > stateList = new List<USState>();



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
                            USState state = new USState();
                            state.code = reader["Code"].ToString();
                            state.name = reader["Name"].ToString();
                            stateList.Add(state);
                        }
                    }
                   
                }
               
            }
            return stateList;
        }

       
    }
}
