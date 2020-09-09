﻿using DevHobby.Common;
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
        public int DostawcaId { get; set; }
        public string NazwaFirmy { get; set; }
        public string Email { get; set; }


        /// <summary>
        /// Wysyła wiadomośc email, aby powitac nowego dostawcę
        /// </summary>
        /// <param name="wiadomosc"></param>
        /// <returns></returns>
        public string wyslijEmailWitamy(string wiadomosc)
        {
            var emailService = new EmailService();
            var temat = "Witaj" + this.NazwaFirmy;
            var potwierdzenie = emailService.WyslijWiadomosc(temat, wiadomosc, this.Email);

            return potwierdzenie;


        }
    }
}