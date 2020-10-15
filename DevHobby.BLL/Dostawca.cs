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
        public enum DolaczAdres { Tak, Nie };
        public enum WyslijKopie { Tak, Nie };

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
        /// <param name="data">Data dostawy zamówienia</param>
        /// <param name="instrukcje">Instrukcje dostawy</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DateTimeOffset? data = null, string instrukcje = "Standardowa dostawa")
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

        /// <summary>
        /// Wysyła zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia</param>
        /// <param name="ilosc">Ilość produktu do zamówienia</param>
        /// <param name="dolaczAdres">true jeśli zawiera adres wysyłki</param>
        /// <param name="wyslijKopie">true jeśli będziemy wysyłać kopię wiadomości e-mail</param>
        /// <returns>flaga sukcesu i tekst zamówienia</returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc, DolaczAdres dolaczAdres, WyslijKopie wyslijKopie)
        {
            var tekstZamowienia = "Tekst zamówienia";

            if (dolaczAdres == DolaczAdres.Tak)
            {
                tekstZamowienia += " Dołączamy adres";
            }

            if (wyslijKopie == WyslijKopie.Tak)
            {
                tekstZamowienia += " Wyślij kopie";
            }

            var wynikOperacji = new WynikOperacji(true, tekstZamowienia);
            return wynikOperacji;
        }

        public override string ToString()
        {
            string dostawcaInfo =  "Dostawca: " + this.NazwaFirmy;


            string wynik = dostawcaInfo?.ToLower();
            wynik = dostawcaInfo?.ToUpper();
            wynik = dostawcaInfo?.Replace("Dostawca", "Odbiorca");

            var dlugosc = dostawcaInfo?.Length;
            var index = dostawcaInfo?.IndexOf(":");

            var start = dostawcaInfo?.StartsWith("Dosta");

            var end = dostawcaInfo?.EndsWith("ca");

            var trim = dostawcaInfo?.Trim();



            return dostawcaInfo;
        }

        public string ZwrocTekst()
        {
            var tekst = @"wstawiam \r\n nowa linia";
            return tekst;
        }

        public string ZwrocTekstDwieLinie()
        {
            var tekst = "Pierwsza linia" + Environment.NewLine + "Druga linia";

            var teks2 = "Pierwsza linia\r\nDruga linia";

            var tekst3 = @"Pierwsza linia
                           Druga linia";

            return tekst;

        }

        #endregion
    }
}
