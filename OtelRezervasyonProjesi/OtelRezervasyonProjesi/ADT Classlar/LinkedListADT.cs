using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public abstract class LinkedListADT
    {
        public Oda OdaHead;
        public Personel PersonelHead;

        public Yorum YorumHead;

        public abstract Oteller OdaEklemeIslemi(Oteller otel, Oda oda);
        protected abstract void OdaListelemeIslemi(Oteller otel, DataGridView dgv);
        public abstract Oteller PersonelEklemeIslemi(Oteller otel, Personel personel);
        protected abstract Oteller PersonelBilgisiGuncellemeIslemi(Oteller otel, long PersonelTCkimlikNo, 
                                                                string PersonelAdi, string PersonelSoyadi,
                                                                long PersonelTelefonNo, string Eposta,
                                                                string Il, string Ilce, string Cadde,
                                                                string Mahalle, string Sokak,
                                                                string Departman, string Pozisyon);
        protected abstract void PersonelListelemeIslemi(Oteller otel, DataGridView dgv);
        protected abstract Oteller PersonelSilmeIslemi(Oteller otel, long PersonelTCkimlikNo);
        public abstract Oteller YorumEkle(Oteller otel, Yorum yorum);
    }
}
