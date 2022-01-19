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
    public class ProjectDAO : IProjectDAO
    {
        private readonly string _connection;
        public ProjectDAO()
        {
            _connection = "Server=DESKTOP-N7U3HV7;Database=portfolio;Trusted_Connection=True;";
        }

        #region Project
        public void CreateProject(ProjectDTO project)
        {
            string query = "INSERT INTO dbo.Project([ProjectEigenaar],[Beschrijving],[Naam],[Datum]) VALUES(@eigenaar, @beschrijving, @naam, @datum)" + "SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@eigenaar", project.GebruikerID);
                    command.Parameters.AddWithValue("@beschrijving", project.ProjectBeschrijving);
                    command.Parameters.AddWithValue("@naam", project.ProjectNaam);
                    command.Parameters.AddWithValue("@datum", project.ProjectDatum);

                    var id = (int)command.ExecuteScalar();
                    project.ProjectID = id;
                }
            }
        }

        public void DeleteProject(int id)
        {
            string query = "DELETE FROM [dbo].[Project] WHERE [ID] = @id";

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

        public void EditProject(ProjectDTO Project)
        {
            string query = "UPDATE [dbo].[Project] SET [ProjectEigenaar] = @eigenaar ,[Beschrijving] = @beschrijving ,[Naam] = @name ,[Datum] = @datum WHERE [ID] = @id";

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@eigenaar", Project.GebruikerID);
                    command.Parameters.AddWithValue("@beschrijving", Project.ProjectBeschrijving);
                    command.Parameters.AddWithValue("@name", Project.ProjectNaam);
                    command.Parameters.AddWithValue("@datum", Project.ProjectDatum);
                    command.Parameters.AddWithValue("@id", Project.ProjectID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ProjectDTO> GetAllProjecten()
        {
            string query = "SELECT * FROM dbo.Project";

            List<ProjectDTO> projectDTOs = new();

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            projectDTOs.Add(new()
                            {
                                ProjectID = (int)dataReader["ID"],
                                GebruikerID = (int)dataReader["ProjectEigenaar"],
                                ProjectBeschrijving = (string)dataReader["Beschrijving"],
                                ProjectNaam = (string)dataReader["Naam"],
                                ProjectDatum = (DateTime)dataReader["Datum"]
                            });
                        }
                    }
                }
            }
            return projectDTOs;
        }

        public ProjectDTO GetProject(int projectID)
        {
            string query = "SELECT * FROM [dbo].[Project] WHERE [ID] = @id";

            ProjectDTO projectDTO = new();

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", projectID);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            projectDTO = new()
                            {
                                ProjectID = (int)dataReader["ID"],
                                GebruikerID = (int)dataReader["ProjectEigenaar"],
                                ProjectBeschrijving = (string)dataReader["Beschrijving"],
                                ProjectNaam = (string)dataReader["Naam"],
                                ProjectDatum = (DateTime)dataReader["Datum"]
                            };
                        }
                    }
                }
            }

            return projectDTO;
        }

        public List<ProjectDTO> GetProjectsFromUser(int userID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Gebruiker

        public List<GebruikerDTO> GetProjectGebruikers(int projectID)
        {
            throw new NotImplementedException();
        }

        public void AddGebruiker(int gebruiker)
        {
            throw new NotImplementedException();
        }

        public void RemoveGebruiker(int gebruikerID, int projectID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Bestanden
        public void RemoveBestanden(int bestandsID, int projectID)
        {
            throw new NotImplementedException();
        }

        public void AddBestand(BestandDTO bestand, int projectID)
        {
            string query = "INSERT INTO dbo.Bestand([Locatie]) VALUES(@locatie)" + "SELECT CAST(scope_identity() AS int)";
            string junctionQuery = "INSERT INTO [dbo].[Project_Bestand] ([BestandID],[ProjectID]) VALUES(@bestandID, @projectID)";

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    //make table
                    command.Parameters.AddWithValue("@locatie", bestand.BestandsLocatie);
                    var id = (int)command.ExecuteScalar();
                    bestand.ID = id;
                    //add to juncitonTable
                    command.CommandText = junctionQuery;
                    command.Parameters.AddWithValue("@bestandID", id);
                    command.Parameters.AddWithValue("@projectID", projectID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<BestandDTO> GetBestanden(int projectID)
        {
            string query = "SELECT Bestand.ID, Bestand.Locatie, Project.Naam FROM (Bestand INNER JOIN Project_Bestand on Bestand.ID = Project_Bestand.BestandID INNER JOIN Project on Project.ID = Project_Bestand.ProjectID) WHERE Project.ID = @id";
            List<BestandDTO> bestandDTOs = new();

            using (SqlConnection connection = new(_connection))
            {
                using (SqlCommand command = new(query, connection))
                {
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@id", projectID);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            bestandDTOs.Add(new BestandDTO()
                            {
                                ID = (int)dataReader["ID"],
                                BestandsLocatie = (string)dataReader["Locatie"]
                            });
                        }
                    }
                }
            }
            return bestandDTOs;
        }
        #endregion

        #region Expertise
        public List<ExpertiseDTO> GetExpertises(int projectID)
        {
            throw new NotImplementedException();
        }

        public void RemoveExpertise(int expertiseID, int projectID)
        {
            throw new NotImplementedException();
        }

        public void AddExpertise(int expertiseID)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
