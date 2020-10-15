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
        [TestMethod()]
        public void NazwaProduktu_FormatTest()
        {

            // Arrange 
            var produkt = new Produkt();
            produkt.NazwaProduktu = " Krzesło obrotowe ";
            var oczekiwana = "Krzesło obrotowe";

            // Act
            var aktualna = produkt.NazwaProduktu;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
        }
        [TestMethod()]
        public void NazwaProduktu_ZaKrotkaTest()
        {

            // Arrange 
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krz";
            string oczekiwana = null;
            string oczekiwanaWiadomosc = "Nazwa produktu musi być dłuższa niż 4 znaki";

            // Act
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomosc;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }
        [TestMethod()]
        public void NazwaProduktu_ZaDlugaTest()
        {

            // Arrange 
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krzesło obrotowe zbyt długa nazwa";
            string oczekiwana = null;
            string oczekiwanaWiadomosc = "Nazwa produktu musi być krótsza niż 30 znaków";

            // Act
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomosc;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }
        [TestMethod()]
        public void NazwaProduktu_DobraDlugoscTest()
        {

            // Arrange 
            var produkt = new Produkt();
            produkt.NazwaProduktu = "Krzesło obrotowe";
            var oczekiwana = "Krzesło obrotowe";
            string oczekiwanaWiadomosc = null;

            // Act
            var aktualna = produkt.NazwaProduktu;
            var aktualnaWiadomosc = produkt.Wiadomosc;

            // Assert

            Assert.AreEqual(oczekiwana, aktualna);
            Assert.AreEqual(oczekiwanaWiadomosc, aktualnaWiadomosc);
        }
        [TestMethod()]
        public void Kategoria_WartoscDomyslnaTest()
        {

            // Arrange 
            var produkt = new Produkt();
            var oczekiwana = "Informatyka";


            // Act
            var aktualna = produkt.Kategoria;


            // Assert

            Assert.AreEqual(oczekiwana, aktualna);

        }
        [TestMethod()]
        public void Kategoria_NowaWartoscTest()
        {

            // Arrange 
            var produkt = new Produkt();
            produkt.Kategoria = "Geografia";
            var oczekiwana = "Geografia";


            // Act
            var aktualna = produkt.Kategoria;


            // Assert

            Assert.AreEqual(oczekiwana, aktualna);

        }
        [TestMethod()]
        public void Numer_WartoscDomyslnaTest()
        {

            // Arrange 
            var produkt = new Produkt();
            var oczekiwana = 1;


            // Act
            var aktualna = produkt.Numer;


            // Assert

            Assert.AreEqual(oczekiwana, aktualna);

        }
        [TestMethod()]
        public void Numer_NowaWartoscaTest()
        {

            // Arrange 
            var produkt = new Produkt();
            produkt.Numer = 400;
            var oczekiwana = 400;


            // Act
            var aktualna = produkt.Numer;


            // Assert

            Assert.AreEqual(oczekiwana, aktualna);

        }
        [TestMethod()]
        public void KodProduktu_WartoscDomyslnaTest()
        {

            // Arrange 
            var produkt = new Produkt();

            var oczekiwana = "Informatyka - 0001";


            // Act
            var aktualna = produkt.KodProduktu;


            // Assert

            Assert.AreEqual(oczekiwana, aktualna);

        }
        [TestMethod()]
        public void KodProduktu_NowaWartoscTest()
        {

            // Arrange 
            var produkt = new Produkt();
            produkt.Kategoria = "Historia";
            produkt.Numer = 10;

            var oczekiwana = "Historia - 0010";


            // Act
            var aktualna = produkt.KodProduktu;


            // Assert

            Assert.AreEqual(oczekiwana, aktualna);

        }

        [TestMethod()]
        public void ObliczSugerowanaCenaTest()
        {
            // Arrange 

            var produkt = new Produkt(1, "Biurko", "Opis");
            produkt.Koszt = 200m;
            var oczekiwana = 220m;



            // Act

            var aktualna = produkt.ObliczSugerowanaCena(10);


            // Assert
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}