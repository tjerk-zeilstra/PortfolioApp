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
        public GebruikerDAO()
        {
            _connection = new SqlConnection("Server=DESKTOP-N7U3HV7;Database=portfolioDB_Test;Trusted_Connection=True;");
        }

        public GebruikerDTO AddGebruiker(GebruikerDTO gebruiker)
        {
            string query = "INSERT [dbo].[Gebruiker] ([Naam], [Email], [Beschrijving], [ProfielFoto]) VALUES (@Naam, @Email, @Beschrijving, @ProfielFoto); " + "SELECT CAST(scope_identity() AS int)";

            using (_connection)
            {
                using (SqlCommand command = new(query, _connection))
                {
                    command.Parameters.AddWithValue("@Naam", gebruiker.Naam);
                    command.Parameters.AddWithValue("@Email", gebruiker.Email);
                    command.Parameters.AddWithValue("@Beschrijving", gebruiker.Beschrijving);
                    if (gebruiker.ProfielFoto != null)
                    {
                        command.Parameters.AddWithValue("@ProfielFoto", gebruiker.ProfielFoto);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ProfielFoto", "Img/default_img.png");
                    }

                    _connection.Open();
                    var modified = command.ExecuteScalar();
                    gebruiker.GebruikerID = (int)modified;
                }
            }

            return gebruiker;
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

        public GebruikerDTO EditGebruiker(GebruikerDTO gebruiker)
        {
            using (_connection)
            {
                SqlCommand command = new("INSERT INTO Gebruiker ()", _connection);
                command.Parameters.AddWithValue("@bar", 1);
                _connection.Open();
                command.ExecuteNonQuery();
            }

            return gebruiker;
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

        public GebruikerDTO GetGebruiker(int id)
        {
            GebruikerDTO gebruiker = new();
            using (SqlCommand command = new("SELECT * FROM Gebruiker WHERE [ID] = @id", _connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gebruiker.GebruikerID = Convert.ToInt32(reader["ID"]);
                        gebruiker.Beschrijving = reader["Beschrijving"].ToString();
                        gebruiker.Email = reader["Email"].ToString();
                        gebruiker.Naam = reader["Naam"].ToString();
                        gebruiker.ProfielFoto = reader["ProfielFoto"].ToString();
                    }
                }
            }
            return gebruiker;
        }
    }
}
