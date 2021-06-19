using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonProjesi
{
    public class HeapDugumu
    {
        public Musteri Musteri;

        public HeapDugumu(Musteri musteri)
        {
            Musteri = new Musteri();

            this.Musteri.Ad = musteri.Ad;
            this.Musteri.Soyad = musteri.Soyad;
            this.Musteri.TCkimlikNumarasi = musteri.TCkimlikNumarasi;
            this.Musteri.TelefonNumarasi = musteri.TelefonNumarasi;
            this.Musteri.Eposta = musteri.Eposta;
            this.Musteri.adres.Il = musteri.adres.Il;
            this.Musteri.adres.Ilce = musteri.adres.Ilce;
            this.Musteri.adres.Cadde = musteri.adres.Cadde;
            this.Musteri.adres.Mahalle = musteri.adres.Mahalle;
            this.Musteri.adres.Sokak = musteri.adres.Sokak;
        }
    }
}
