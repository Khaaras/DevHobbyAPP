using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevHobby.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHobby.BLL.Tests
{
    [TestClass()]
    public class ProduktTests
    {
        [TestMethod()]
        public void PowiedzWitajTest()
        {

            // Arrange
            var produkt = new Produkt();
            produkt.ProduktId = 1;
            produkt.NazwaProduktu = "Biurko";
            produkt.Opis = "Czerwone biurko";

            var oczekiwana = "Witaj Biurko (1): Czerwone biurko";


            // Act
            var aktualna = produkt.PowiedzWitaj();

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void PowiedzWitajSparametryzowanyKonstruktorTest()
        {

            // Arrange
            var produkt = new Produkt(1, "Biurko", "Czerwone biurko");        
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko";


            // Act
            var aktualna = produkt.PowiedzWitaj();

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}