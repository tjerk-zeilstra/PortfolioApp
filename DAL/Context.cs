using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interface;

namespace DAL
{
    public class Context
    {
        private readonly string _constring;

        public Context(IConfigurationBuilder configurationBuilder)
        {
            _constring = Helper.ConString(configurationBuilder);
        }

        public Context(string constring)
        {
            _constring = constring;
        }

        public List<IGebruikerDTO> GetGebruikers(string query)
        {
            //TODO dependency injection
            IList<IGebruikerDTO> retunlist = new List<IGebruikerDTO>();
            using (SqlConnection connection = new(_constring))
            {
                SqlCommand command = new(query, connection);
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
            return (List<IGebruikerDTO>)retunlist;
        }

        public List<IProjectDTO> GetProjecten(string query)
        {
            //TODO dependency injection
            IList<IProjectDTO> retunlist = new List<IProjectDTO>();
            using (SqlConnection connection = new(_constring))
            {
                SqlCommand command = new(query, connection);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retunlist.Add(new ProjectDTO
                        {
                            ProjectID = Convert.ToInt32(reader["ID"]),
                            GebruikerID = Convert.ToInt32(reader["ProjectEigenaar"]),
                            ProjectNaam = reader[""].ToString(),
                            ProjectBeschrijving = reader[""].ToString(),
                            ProjectDatum = Convert.ToDateTime(reader[""]),
                        });
                    }
                }
            }
            return (List<IProjectDTO>)retunlist;
        }
        
    }
}
