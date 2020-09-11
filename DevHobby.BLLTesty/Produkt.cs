using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHobby.BLLTesty
{
    /// <summary>
    /// Klasa produktu, zarządza produktami
    /// </summary>
    /// 

    public class Produkt
    {
        private int produktId;

        public int ProduktId
        {
            get { return produktId; }
            set { produktId = value; }
        }

        private string nazwaProduktu;

        public string NazwaProduktu
        {
            get { return nazwaProduktu; }
            set { nazwaProduktu = value; }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public string PowiedzWitaj()
        {

            return "Witaj " + NazwaProduktu + " (" + ProduktId + "): " + Opis;
        }



    }
}
