using DevHobby.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevHobby.BLL
{
    /// <summary>
    /// Klasa zarządza dostawcami od których kupujemy produkty
    /// </summary>
    /// 

    public class Dostawca
    {
        #region Pola i właściwości
        public int DostawcaId { get; set; }
        public string NazwaFirmy { get; set; }
        public string Email { get; set; }
        #endregion

        #region Metody

        /// <summary>
        /// Wysyła wiadomośc email, aby powitac nowego dostawcę
        /// </summary>
        /// <param name="wiadomosc"></param>
        /// <returns></returns>
        public string wyslijEmailWitamy(string wiadomosc)
        {
            var emailService = new EmailService();
            var temat = ("Witaj " + this.NazwaFirmy).Trim();
            var potwierdzenie = emailService.WyslijWiadomosc(temat, wiadomosc, this.Email);

            return potwierdzenie;


        }

        /// <summary>
        /// Wysyła zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość do zamówienia</param>
        /// <returns></returns>
        /// 
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc)
        {
            if (produkt == null) throw new ArgumentNullException(nameof(produkt));
            if (ilosc <= 0) throw new ArgumentOutOfRangeException(nameof(ilosc));

            var sukces = false;

            var tekstZamowienia =   "Zamówienie z DevHobby.pl" + Environment.NewLine +
                                    "Produkt : " + produkt.KodProduktu + Environment.NewLine +
                                    "Ilość : " + ilosc;

            var emailService = new EmailService();

            var potwierdzenie = emailService.WyslijWiadomosc("Nowe zamówienie", tekstZamowienia, this.Email);

            if (potwierdzenie.StartsWith("Wiadomość wysłana: ")) 
            {
                sukces = true;
            }

            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);

            return wynikOperacji;
        }

        /// <summary>
        /// Wysyła zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość do zamówienia</param>
        /// <param name="data">Data dostawy zamówienia</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DateTimeOffset? data)
        {
            if (produkt == null) throw new ArgumentNullException(nameof(produkt));
            if (ilosc <= 0) throw new ArgumentOutOfRangeException(nameof(ilosc));
            if (data <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(data));
            

            var sukces = false;

            var tekstZamowienia = "Zamówienie z DevHobby.pl" + Environment.NewLine +
                                    "Produkt : " + produkt.KodProduktu + Environment.NewLine +
                                    "Ilość : " + ilosc;

            if (data.HasValue)
            {
                tekstZamowienia += Environment.NewLine + "Data dostawy: " + data.Value.ToString("d");
            }

            var emailService = new EmailService();

            var potwierdzenie = emailService.WyslijWiadomosc("Nowe zamówienie", tekstZamowienia, this.Email);

            if (potwierdzenie.StartsWith("Wiadomość wysłana: "))
            {
                sukces = true;
            }

            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);

            return wynikOperacji;
        }

        /// <summary>
        /// Wysyła zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość do zamówienia</param>
        /// <param name="data">Data dostawy zamówienia</param>
        /// <param name="instrukcje">Instrukcje dostawy</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DateTimeOffset? data, string instrukcje)
        {
            if (produkt == null) throw new ArgumentNullException(nameof(produkt));
            if (ilosc <= 0) throw new ArgumentOutOfRangeException(nameof(ilosc));
            if (data <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(data));
            


            var sukces = false;

            var tekstZamowienia = "Zamówienie z DevHobby.pl" + Environment.NewLine +
                                    "Produkt : " + produkt.KodProduktu + Environment.NewLine +
                                    "Ilość : " + ilosc;

            if (data.HasValue)
            {
                tekstZamowienia += Environment.NewLine + "Data dostawy: " + data.Value.ToString("d");
            }
            if (!String.IsNullOrWhiteSpace(instrukcje))
            {
                tekstZamowienia += Environment.NewLine + "Instrukcje: " + instrukcje;
            }

            var emailService = new EmailService();

            var potwierdzenie = emailService.WyslijWiadomosc("Nowe zamówienie", tekstZamowienia, this.Email);

            if (potwierdzenie.StartsWith("Wiadomość wysłana: "))
            {
                sukces = true;
            }

            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);

            return wynikOperacji;
        }

        #endregion
    }
}
