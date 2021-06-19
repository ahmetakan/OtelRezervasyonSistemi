using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Oteller : ICloneable
    {
        public Otel otel;
        public Oda oda;
        public Personel personel;
        public Yorum yorum;

        public HashChain rezervasyonlar;

        public Oteller LeftOtel;
        public Oteller RightOtel;

        public Oteller()
        {
            otel = new Otel();
            rezervasyonlar = new HashChain();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
