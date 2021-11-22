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
        private readonly string _connectionstring;
        public ProjectDAO(string connnectionstring)
        {
            _connectionstring = connnectionstring;
        }

        public int CreateProject(ProjectDTO Project)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(ProjectDTO Project)
        {
            string query = "DELETE FROM [dbo].[Project] WHERE [ID] = @id";

            using SqlConnection connection = new(_connectionstring);
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", Project.ProjectID);
            command.ExecuteNonQuery();
        }

        public void EditProject(ProjectDTO Project)
        {
            string query = "UPDATE [dbo].[Project] SET [ProjectEigenaar] = @eigenaar ,[Beschrijving] = @beschrijving ,[Naam] = @name ,[Datum] = @datum WHERE [ID] = @id";

            using SqlConnection connection = new(_connectionstring);
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@eigenaar", Project.GebruikerID);
            command.Parameters.AddWithValue("@beschrijving", Project.ProjectBeschrijving);
            command.Parameters.AddWithValue("@name", Project.ProjectNaam);
            command.Parameters.AddWithValue("@datum", Project.ProjectDatum);
            command.Parameters.AddWithValue("@id", Project.ProjectID);

            command.ExecuteNonQuery();
        }

        public List<ProjectDTO> GetAllProjecten()
        {
            string query = "SELECT * FROM [dbo].[Project]";

            List<ProjectDTO> projectDTOs = new();

            using SqlConnection connection = new(_connectionstring);
            using SqlCommand command = new(query, connection);
            using SqlDataReader dataReader = command.ExecuteReader();
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

            return projectDTOs;
        }

        public ProjectDTO GetProject(int projectID)
        {
            string query = "SELECT * FROM [dbo].[Project] WHERE [ID] = @id";

            ProjectDTO projectDTO = new();

            using SqlConnection connection = new(_connectionstring);
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", projectID);
            using SqlDataReader dataReader = command.ExecuteReader();
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

            return projectDTO;
        }

        public List<ProjectDTO> GetProjectsFromUser(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
