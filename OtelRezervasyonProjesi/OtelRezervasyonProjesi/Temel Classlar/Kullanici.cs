using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Kullanici
    {
        Musteri musteri;
        
        public Musteri Musteri
        {
            get
            {
                return musteri; 
            }
            set
            {
                musteri = value; 
            }
        }

        public Kullanici()
        {
            musteri = new Musteri();
        }

        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
