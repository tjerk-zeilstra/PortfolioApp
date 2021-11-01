using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DAL.DTO;
using DAL.Interface;
using System.Collections.Generic;

namespace PortfolioTest
{
    [TestClass]
    public class DalTest
    {
        private readonly string _connstring = "Server=DESKTOP-N7U3HV7;Database=portfolioDB;Trusted_Connection=True;";

        [TestMethod]
        public void Get_Person_Test()
        {
            //arrange
            Context context = new(_connstring);
            string query = "SELECT * FROM Gebruiker";

            //act
            List<IGebruikerDTO> gebruikers = context.GetGebruikers(query);

            //assert
            Assert.IsNotNull(query);
            CollectionAssert.AllItemsAreNotNull(gebruikers);
        }

        [TestMethod]
        public void Get_Bestanden_Test()
        {
            //arrange
            Context context = new(_connstring);
            string query = "SELECT * FROM Project";

            //act
            List<IProjectDTO> bestanden = context.GetProjecten(query);

            //assert
            Assert.IsNotNull(bestanden);
            CollectionAssert.AllItemsAreNotNull(bestanden);
        }
    }
}
