using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Oda
    {
        public int OdaNumarasi { get; set; }
        public long TelefonNumarasi { get; set; }
        public int KisiSayisi { get; set; }
        public string ManzaraBilgisi { get; set; }
        public bool RezervasyonDurumu { get; set; }
        public decimal Fiyat { get; set; }

        public Oda()
        {
            Random random = new Random();
            OdaNumarasi = random.Next() % 10000;
        }
        public Oda NextOda;
    }
}
