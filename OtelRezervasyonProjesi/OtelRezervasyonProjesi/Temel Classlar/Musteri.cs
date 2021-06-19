using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Musteri
    {
        public long TCkimlikNumarasi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long TelefonNumarasi { get; set; }
        public Adres adres { get; set; }
        public string Eposta { get; set; }
        public Musteri()
        {
            adres = new Adres();
        }
    }
}
