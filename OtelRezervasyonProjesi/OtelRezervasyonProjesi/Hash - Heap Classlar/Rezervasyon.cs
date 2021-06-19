using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Rezervasyon
    {
        public int RezervasyonNo { get; set; }
        public string OtelAdi { get; set; }
        public int OdaNo { get; set; }
        public int KisiSayisi { get; set; }
        public int GunSayisi { get; set; }
        public decimal ToplamUcret { get; set; }

        public Heap HeapDizisi;
        public Rezervasyon(int KisiSayisi)
        {
            Random rnd = new Random();
            RezervasyonNo = rnd.Next();
            HeapDizisi = new Heap(KisiSayisi);
        }
    }
}
