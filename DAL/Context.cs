using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL
{
    public class Context
    {
        private string _constring;

        public Context(IConfigurationBuilder configurationBuilder)
        {
            _constring = Helper.ConString(configurationBuilder);
        }

        public Context(string constring)
        {
            _constring = constring;
        }
        public IList<IGebruikerDTO> GetPersons(string query)
        {
            IList<IGebruikerDTO> retunlist = new List<IGebruikerDTO>();
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retunlist.Add(new GebruikerDTO
                        {
                            GebruikerID = Convert.ToInt32(reader["ID"]),
                            Beschrijving = reader["Beschrijving"].ToString(),
                            Email = reader["Email"].ToString(),
                            Naam = reader["Naam"].ToString(),
                            ProfielFoto = reader["ProfielFoto"].ToString()
                        });
                    }
                }
            }
            return retunlist;
        }
        
    }
}
