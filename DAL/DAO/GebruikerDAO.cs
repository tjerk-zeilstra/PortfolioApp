using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.DTOs;
using DAOInterface.Interface;

namespace DAL.DAO
{
    public class GebruikerDAO : IGebruikerDAO
    {
        private readonly SqlConnection _connection;
        public GebruikerDAO(string constring)
        {
            _connection = new SqlConnection(constring);
        }
        public void AddGebruiker(GebruikerDTO gebruiker)
        {
            using (_connection)
            {
                SqlCommand command = new("INSERT [dbo].[Gebruiker] ([Naam], [Email], [Beschrijving], [ProfielFoto]) VALUES (@Naam, @Email, @Beschrijving, @ProfielFoto)", _connection);
                command.Parameters.AddWithValue("@Naam", gebruiker.Naam);
                command.Parameters.AddWithValue("@Email", gebruiker.Naam);
                command.Parameters.AddWithValue("@Beschrijving", gebruiker.Naam);
                command.Parameters.AddWithValue("@ProfielFoto", gebruiker.Naam);
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteGebruiker(GebruikerDTO gebruiker)
        {
            using (_connection)
            {
                SqlCommand command = new("DELETE FROM [dbo].[Gebruiker] WHERE [ID] == @id", _connection);
                command.Parameters.AddWithValue("@id", gebruiker.GebruikerID);
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditGebruiker(GebruikerDTO gebruiker)
        {
            using (_connection)
            {
                SqlCommand command = new("INSERT INTO Gebruiker ()", _connection);
                command.Parameters.AddWithValue("@bar", 1);
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IList<GebruikerDTO> GetAllGebruikers()
        {
            List<GebruikerDTO> gebruikers = new();
            using (SqlCommand command = new("SELECT * FROM Gebruiker", _connection))
            {
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gebruikers.Add(new GebruikerDTO
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
            return gebruikers;
        }
    }
}
