using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Otel
    {
        public string OtelAdi { get; set; }
        public string Eposta { get; set; }

        public int OdaSayisi = 0;
        public long TelefonNumarasi { get; set; }
        public Adres adres { get; set; }
        public int YildizSayisi { get; set; }
        public float OtelPuani { get; set; }

        public Otel()
        {
            adres = new Adres();
        }
    }
}