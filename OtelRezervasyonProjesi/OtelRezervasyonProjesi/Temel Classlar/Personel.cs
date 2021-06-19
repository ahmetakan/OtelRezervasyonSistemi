using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Personel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long TCkimlikNumarasi { get; set; }
        public long TelefonNumarasi { get; set; }
        public Adres adres { get; set; }
        public string Eposta { get; set; }
        public string Departman { get; set; }
        public string Pozisyon { get; set; }

        public Personel()
        {
            adres = new Adres();
        }

        public Personel NextPersonel;
    }
}
