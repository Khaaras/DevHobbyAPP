using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevHobby.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHobby.Common.Tests
{
    [TestClass()]
    public class LogowanieServiceTests
    {
        [TestMethod()]
        public void LogowanieTest()
        {

            // Arrange
            
            var oczekiwana = "Akcja: Test Akcja";

            // Act

            var aktualna = LogowanieService.Logowanie("Test Akcja");

            // Assert


            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}