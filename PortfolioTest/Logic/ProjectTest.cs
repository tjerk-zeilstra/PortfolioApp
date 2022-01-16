using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Logic.Models;
using DAOInterface.DTOs;
using DAOInterface.Interface;
using PortfolioTest.FakeDAL;
using System;

namespace PortfolioTest.Logic
{
    [TestClass]
    public class ProjectTest
    {
        FakeProjectDAO projectDAO;
        FakeGebruikerDAO gebruikerDAO;

        public ProjectTest()
        {
            projectDAO = new FakeProjectDAO();
            gebruikerDAO = new FakeGebruikerDAO();
        }

        [TestMethod]
        public void TestUpdateProject()
        {
            //arange
            string nieuwprojectnaam = "project naam";
            string nieuwbeschrijving = "project test";
            DateTime nieuwdatum = new(2020, 12, 6);

            ProjectDTO projectDTO = new() { ProjectID = 1, GebruikerID = 1, ProjectNaam = "naam", ProjectBeschrijving = "test", ProjectDatum = new() };

            Project project = new Project(projectDAO, gebruikerDAO, projectDTO);

            //act
            project.Update(1, nieuwprojectnaam, nieuwbeschrijving, nieuwdatum);

            //assert
            Assert.AreEqual(nieuwprojectnaam, project.ProjectNaam);
            Assert.AreEqual(nieuwbeschrijving, project.ProjectBeschrijving);
            Assert.AreEqual(nieuwdatum, project.ProjectDatum);

            Assert.AreEqual(project.ProjectID, projectDAO.ID);
            Assert.AreEqual(nieuwprojectnaam, projectDAO.Naam);
            Assert.AreEqual(nieuwbeschrijving, projectDAO.Beschrijving);
            Assert.AreEqual(nieuwdatum, projectDAO.Datum);
        }
    }
}
