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

        public void AddExpertise(int expertiseID)
        {
            throw new NotImplementedException();
        }

        public void AddGebruiker(int gebruiker)
        {
            throw new NotImplementedException();
        }

        public void CreateProject(ProjectDTO project)
        {
            string query = "INSERT INTO dbo.Project([ProjectEigenaar],[Beschrijving],[Naam],[Datum]) VALUES(@eigenaar, @beschrijving, @naam, @datum)" + "SELECT CAST(scope_identity() AS int)";

            using(SqlConnection connection = new(_connection))
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
                using (SqlCommand command = new(query, connection)) {
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

        public List<ExpertiseDTO> GetExpertises(int projectID)
        {
            throw new NotImplementedException();
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

        public List<GebruikerDTO> GetProjectGebruikers(int projectID)
        {
            throw new NotImplementedException();
        }

        public List<ProjectDTO> GetProjectsFromUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void RemoveExpertise(int expertiseID, int projectID)
        {
            throw new NotImplementedException();
        }

        public void RemoveGebruiker(int gebruikerID, int projectID)
        {
            throw new NotImplementedException();
        }
    }
}
