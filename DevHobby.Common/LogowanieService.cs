using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHobby.Common
{
    /// <summary>
    /// Klasa zapewnie logowanie
    /// </summary>
    /// 

    public class LogowanieService
    {

        /// <summary>
        /// Loguje jakąś akcję
        /// </summary>
        /// <param name="akcja">Akcja do zalogowania</param>
        /// <returns></returns>
        public string Logowanie(string akcja)
        {
            var tekstDoZalogowania = "Akcja: " + akcja;
            Console.WriteLine(tekstDoZalogowania);

            return tekstDoZalogowania;
        }
    }
}
