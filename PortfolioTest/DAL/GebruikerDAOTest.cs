using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.DAO;
using DAOInterface.DTOs;
using DAOInterface.Interface;
using DAL.Interface;
using System.Collections.Generic;


namespace PortfolioTest.DAL
{
    [TestClass]
    public class GebruikerDAOTest
    {
        private readonly string _connstring = "Server=DESKTOP-N7U3HV7;Database=portfolioDB;Trusted_Connection=True;";

        [TestMethod]
        public void Get_All_Gebruikers_Test()
        {
            //arrange
            GebruikerDAO gebruikerDAO = new GebruikerDAO(_connstring);

            //act
            List<GebruikerDTO> gebruikers = (List<GebruikerDTO>)gebruikerDAO.GetAllGebruikers();

            //assert
            Assert.IsNotNull(gebruikers);
            CollectionAssert.AllItemsAreNotNull(gebruikers);
        }
    }
}
