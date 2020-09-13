using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHobby.Common
{
    public class EmailService
    {
        /// <summary>
        /// Wysyła wiadomość email
        /// </summary>
        /// <param name="temat">Temat wiadomości</param>
        /// <param name="wiadomosc">Tekst</param>
        /// <param name="odbiorca">Adres email odbiorcy wiadomości</param>
        /// <returns></returns>
        public string WyslijWiadomosc(string temat,string wiadomosc, string odbiorca)
        {
            // Kod aby wysłać wiadomość email

            var potwierdzenie = "Wiadomość wysłana: " + temat;           
            var logowanieService = LogowanieService.Logowanie(potwierdzenie);

            return potwierdzenie;
        }
    }
}
