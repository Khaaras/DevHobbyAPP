using DevHobby.Common;
using System;
using static DevHobby.Common.LogowanieService; // pozwala nam aby wywołować członków klasy LogowanieService bez określania nazwy klasy
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHobby.BLL
{
    /// <summary>
    /// Klasa produktu, zarządza produktami
    /// </summary>
    /// 

    public class Produkt
    {
        public const double CaliNaMetr = 38.87;

        public readonly decimal MinimalnaCena;

        #region Konstruktory
        public Produkt()
        {
            Console.WriteLine("Produkt został utworzony");
            //this.DostawcaProduktu = new Dostawca();
            this.MinimalnaCena = 10.50m;
            this.Kategoria = "Informatyka";
        }

        public Produkt(int produktId, string nazwaProduktu, string opis) : this()
        {
            this.ProduktId = produktId;
            this.NazwaProduktu = nazwaProduktu;
            this.Opis = opis;
            if (NazwaProduktu.StartsWith("Krzesło"))
            {
                this.MinimalnaCena = 120.99m;
            }

            Console.WriteLine("Produkt ma nazwę: " + nazwaProduktu);

            
        }
        #endregion

        private int produktId;

        #region Pola i właściwości

        public int ProduktId
        { 
            get { return produktId; }
            set { produktId = value; }
        }

        private string nazwaProduktu;

        public string NazwaProduktu
        {
            get 
            {
                var sformatowanaNazwaProduktu = nazwaProduktu?.Trim();
                return sformatowanaNazwaProduktu; 
            }
            set 
            {
                if (value.Length < 4)
                {
                    Wiadomosc = "Nazwa produktu musi być dłuższa niż 4 znaki";
                }
                
                else if (value.Length > 30)
                {
                    Wiadomosc = "Nazwa produktu musi być krótsza niż 30 znaków";
                }
                else
                {
                    nazwaProduktu = value;
                }
            }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private Dostawca dostawcaProduktu;

        public Dostawca DostawcaProduktu
        {
            get 
            {
                if (dostawcaProduktu == null)
                {
                    dostawcaProduktu = new Dostawca();
                }
                return dostawcaProduktu;
            }
            set { dostawcaProduktu = value; }
        }

        private DateTime? datadostepnosci;
        public string Wiadomosc { get; private set; }

        public DateTime? DataDostepnosci
        {
            get { return datadostepnosci; }
            set { datadostepnosci = value; }
        }

        internal string Kategoria { get; set; }

        public int Numer { get; set; } = 1;


        public string KodProduktu => this.Kategoria + " - " + this.Numer;

        public decimal Koszt { get; set; }

        #endregion

        #region Metody
        public string PowiedzWitaj()
        {
            //var dostawca = new Dostawca();
            //dostawca.wyslijEmailWitamy("Wiadomość z produktu");

            var emailServices = new EmailService();
            var potwierdzenie = emailServices.WyslijWiadomosc("Nowy produkt",this.nazwaProduktu,"Marketing@devhobby.pl");

            var wynik = Logowanie("Powiedziano witaj");            

            return "Witaj " + NazwaProduktu + " (" + ProduktId + "): " + Opis + " dostępny od: " + DataDostepnosci?.ToShortDateString(); 

        }

        public override string ToString() => this.nazwaProduktu + " (" + this.produktId + ")";
        

        /// <summary>
        /// Oblicza sugerowaną cenę detaliczną produktu
        /// </summary>
        /// <param name="procent">Procent używany do wyliczenia sugerowanej ceny detalicznej</param>
        /// <returns></returns>
        public decimal ObliczSugerowanaCena(decimal procent) => this.Koszt + (this.Koszt * procent / 100);



        #endregion

    }
}
