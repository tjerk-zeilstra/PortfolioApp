using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Logic.Models;
using DAOInterface.DTOs;
using DAOInterface.Interface;
using PortfolioTest.FakeDAL;

namespace PortfolioTest.Logic
{
    [TestClass]
    public class ProjectTest
    {
        IProjectDAO projectDAO;
        Project project;

        public ProjectTest()
        {
            projectDAO = new FakeProjectDAO();
        }

        [TestMethod]
        public void TestUpdateProject()
        {
            //arange
            string nieuwprojectnaam = "new project naam";

            ProjectDTO projectDTO = new() { ProjectID = 1, GebruikerID = 1, ProjectNaam = "naam", ProjectBeschrijving = "naam", ProjectDatum = new() };

            project = new Project(projectDAO, projectDTO);

            //act
            project.Update(1, nieuwprojectnaam, "naam", project.ProjectDatum);

            //assert
            Assert.AreEqual(nieuwprojectnaam, project.ProjectNaam);
        }
    }
}
