using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.DAO;
using DAOInterface.DTOs;
using DAOInterface.Interface;
using System.Collections.Generic;


namespace PortfolioTest.DAL
{
    [TestClass]
    public class GebruikerDAOTest
    {
        private GebruikerDAO _gebruikerDAO;
        private readonly string _connstring;
        public GebruikerDAOTest()
        {
            _connstring = "Server=DESKTOP-N7U3HV7;Database=portfolioDB_Test;Trusted_Connection=True;";
            _gebruikerDAO = new GebruikerDAO();
        }

        [TestMethod]
        public void Get_All_Gebruikers_Test()
        {
            //arrange

            //act
            List<GebruikerDTO> gebruikers = (List<GebruikerDTO>)_gebruikerDAO.GetAllGebruikers();

            //assert
            Assert.IsNotNull(gebruikers);
            CollectionAssert.AllItemsAreNotNull(gebruikers);
        }

        [TestMethod]
        public void Get_Gebruiker_Test()
        {
            //arrange
            int gebruikerID = 1;

            //act
            GebruikerDTO gebruiker = _gebruikerDAO.GetGebruiker(gebruikerID);

            //assert
            Assert.AreEqual(gebruiker.GebruikerID, gebruikerID);
        }

        [TestMethod]
        public void Add_Gebruiker_Test()
        {
            //arrange
            GebruikerDTO gebruiker = new() {
                Beschrijving = "Test beschrijving",
                Naam = "Test naam",
                Email = "Test mail",
                ProfielFoto = null
            };

            //act
            gebruiker = _gebruikerDAO.AddGebruiker(gebruiker);

            //assert
            Assert.IsNotNull(gebruiker.GebruikerID);
        }

    }
}
