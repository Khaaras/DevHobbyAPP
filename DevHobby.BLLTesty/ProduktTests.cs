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
            produkt.DostawcaProduktu.NazwaFirmy = "DevHobby";

            var oczekiwana = "Witaj Biurko (1): Czerwone biurko dostępny od: ";


            // Act
            var aktualna = produkt.PowiedzWitaj();

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void PowiedzWitaj_SparametryzowanyKonstruktorTest()
        {

            // Arrange
            var produkt = new Produkt(1, "Biurko", "Czerwone biurko");        
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko dostępny od: ";


            // Act
            var aktualna = produkt.PowiedzWitaj();

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void PowiedzWitaj_InicjalizatorObiektu()
        {

            // Arrange
            var produkt = new Produkt
            {
                ProduktId = 1,
                NazwaProduktu = "Biurko",
                Opis = "Czerwone biurko"
            };

            var oczekiwana = "Witaj Biurko (1): Czerwone biurko dostępny od: ";


            // Act
            var aktualna = produkt.PowiedzWitaj();

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void Produkt_NullTest()
        {

            // Arrange 
            Produkt produkt = null;

            string oczekiwana = null;


            // Act
            var aktualna = produkt?.DostawcaProduktu?.NazwaFirmy;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void Konwersja_CaliNaMetr()
        {

            // Arrange 
            var oczekiwana = 194.35;


            // Act
            var aktualna = 5 * Produkt.CaliNaMetr;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void MinimalnaCena_DomyslnaTest()
        {

            // Arrange 
            var produkt = new Produkt();
            var oczekiwana = 10.50m;


            // Act
            var aktualna = produkt.MinimalnaCena;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void MinimalnaCena_KrzesloTest()
        {

            // Arrange 
            var produkt = new Produkt(1, "Krzesło obrotowe", "Krzesło biurowe");
            var oczekiwana = 120.99m;


            // Act
            var aktualna = produkt.MinimalnaCena;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}