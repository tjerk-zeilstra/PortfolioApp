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
        private readonly string _connection;
        public GebruikerDAO()
        {
            _connection = "Server=DESKTOP-N7U3HV7;Database=portfolio;Trusted_Connection=True;";
        }

        public GebruikerDTO AddGebruiker(GebruikerDTO gebruiker)
        {
            string query = "INSERT [dbo].[Gebruiker] ([Naam], [Email], [Beschrijving], [ProfielFoto]) VALUES (@Naam, @Email, @Beschrijving, @ProfielFoto); " + "SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@Naam", gebruiker.Naam);
                    command.Parameters.AddWithValue("@Email", gebruiker.Email);
                    command.Parameters.AddWithValue("@Beschrijving", gebruiker.Beschrijving);
                    if (gebruiker.ProfielFoto != null)
                    {
                        command.Parameters.AddWithValue("@ProfielFoto", gebruiker.ProfielFoto);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ProfielFoto", DBNull.Value);
                    }

                    var id = (int)command.ExecuteScalar();
                    gebruiker.GebruikerID = id;
                }
            }

            return gebruiker;
        }

        public void DeleteGebruiker(int id)
        {
            string query = "DELETE FROM [dbo].[Gebruiker] WHERE [ID] = @id";

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditGebruiker(GebruikerDTO gebruiker)
        {
            string query = "UPDATE [dbo].[Gebruiker] SET [Naam] = @naam ,[Beschrijving] = @beschrijving ,[Email] = @email ,[ProfielFoto] = @profielFoto WHERE [ID] = @id";

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", gebruiker.GebruikerID);
                    command.Parameters.AddWithValue("@naam", gebruiker.Naam);
                    command.Parameters.AddWithValue("@email", gebruiker.Email);
                    command.Parameters.AddWithValue("@beschrijving", gebruiker.Beschrijving);
                    if (gebruiker.ProfielFoto != null)
                    {
                        command.Parameters.AddWithValue("@ProfielFoto", gebruiker.ProfielFoto);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ProfielFoto", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<GebruikerDTO> GetAllGebruikers()
        {
            string query = "SELECT * FROM Gebruiker";

            throw new NotImplementedException();
        }

        public GebruikerDTO GetGebruiker(int id)
        {
            string query = "SELECT * FROM Gebruiker WHERE [ID] = @id";
            GebruikerDTO gebruiker = new();

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            gebruiker = new()
                            {
                                GebruikerID = (int)dataReader["ID"],
                                Beschrijving = (string)dataReader["Beschrijving"],
                                Naam = (string)dataReader["Naam"],
                                Email = (string)dataReader["Email"],
                                ProfielFoto = dataReader["ProfielFoto"] as string,
                            };
                        }
                    }
                }
            }

            return gebruiker;
        }
    }
}
