﻿using System;
using DevHobby.BLL;
using DevHobby.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.BLL.Tests
{
    [TestClass]
    public class DostawcaTests
    {
        [TestMethod]
        public void WyslijEmailWitamy_PrawidlowaNazwaFirmy_Sukces()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "DevHobby";
            var wartoscOczekiwana = "Wiadomość wysłana: Witaj DevHobby";

            // Act (działaj)
            var wartoscAktualna = dostawca.wyslijEmailWitamy("wiadomość testowa");


            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }

        [TestMethod]
        public void WyslijEmailWitamy_PustaNazwaFirmy_Sukces()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "";
            var wartoscOczekiwana = "Wiadomość wysłana: Witaj";

            // Act (działaj)
            var wartoscAktualna = dostawca.wyslijEmailWitamy("wiadomość testowa");


            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }

        [TestMethod]
        public void WyslijEmailWitamy_NullNazwaFirmy_Sukces()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = null;
            var wartoscOczekiwana = "Wiadomość wysłana: Witaj";

            // Act (działaj)
            var wartoscAktualna = dostawca.wyslijEmailWitamy("wiadomość testowa");


            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }

        [TestMethod()]
        public void ZlozZamowienieTest()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt : Informatyka - 0001\r\nIlość : 15\r\nInstrukcje: Standardowa dostawa");


            // Act (działaj)

            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15);

            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZlozZamowienie_ExceptionNullProduktTest()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();



            // Act (działaj)

            var wartoscAktualna = dostawca.ZlozZamowienie(null, 15);

            // Assert (potwierdzenie testu, lub nie)
            // Oczekiwany wyjątek

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZlozZamowienie_ExceptionZlaIlosc()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");



            // Act (działaj)

            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, -15);

            // Assert (potwierdzenie testu, lub nie)
            // Oczekiwany wyjątek
        }

        [TestMethod()]
        public void ZlozZamowienie_TrzyParametryTest()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt : Informatyka - 0001\r\nIlość : 15\r\nData dostawy: 2020-10-22\r\nInstrukcje: Standardowa dostawa");


            // Act (działaj)

            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, new DateTimeOffset(2020, 10, 22, 0, 0, 0, new TimeSpan(8, 0, 0)));

            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);

        }

        [TestMethod()]
        public void ZlozZamowienie_CzteryParametryTest()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt : Informatyka - 0001" +
                "\r\nIlość : 15\r\nData dostawy: 2020-10-22\r\nInstrukcje: testowe instrukcje");


            // Act (działaj)

            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, new DateTimeOffset(2020, 10, 22, 0, 0, 0, new TimeSpan(8, 0, 0)), "testowe instrukcje");

            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);

        }

        [TestMethod()]
        public void ZlozZamowienie_DolaczAdresTest()
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Tekst zamówienia Dołączamy adres");



            // Act (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, Dostawca.DolaczAdres.Tak, Dostawca.WyslijKopie.Nie);



            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        public void ZlozZamowienie_BrakDatyTest()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "Opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamówienie z DevHobby.pl\r\nProdukt : Informatyka - 0001" +
                "\r\nIlość : 15\r\nInstrukcje: testowe instrukcje");


            // Act (działaj)

            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, instrukcje: "testowe instrukcje");

            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);

        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange (zaranżuj test)

            var dostawca = new Dostawca();
            dostawca.DostawcaId = 2;
            dostawca.NazwaFirmy = "DevHobby";
            var wartoscOczekiwana = "Dostawca: DevHobby";


            // Act (działaj)

            var wartoscAktualna = dostawca.ToString();

            // Assert (potwierdzenie testu, lub nie)

            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);

        }

        [TestMethod()]
        public void ZwrocTekstTest()
        {
            // Arrange (zaranżuj test)           

            var dostawca = new Dostawca();
            var oczekiwana = @"wstawiam \r\n nowa linia";

            // Act (działaj)

            var aktualna = dostawca.ZwrocTekst();
            Console.WriteLine(aktualna);


            // Assert (potwierdzenie testu, lub nie)
            Assert.AreEqual(oczekiwana, aktualna);

        }
    }
}
