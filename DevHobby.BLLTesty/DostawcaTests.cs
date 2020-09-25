using System;
using DevHobby.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.BLL.Testy
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
    }
}
