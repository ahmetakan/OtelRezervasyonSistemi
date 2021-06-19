using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Yorum
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public Adres adres { get; set; }
        public string yorum { get; set; }
        public int Puan { get; set; }

        public Yorum()
        {
            adres = new Adres();
        }

        public Yorum NextYorum;
    }
}
