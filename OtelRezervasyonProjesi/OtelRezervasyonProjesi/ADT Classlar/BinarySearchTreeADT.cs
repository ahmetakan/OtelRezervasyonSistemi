using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public abstract class BinarySearchTreeADT
    {
        public Oteller OtelHead;
        protected abstract Oteller OtelEklemeIslemi(Oteller Root, Oteller otel);
        protected abstract Oteller OtelBilgisiGuncellemeIslemi(Oteller Root, string OtelAdi, 
                                                               string Eposta, long TelefonNumarasi, 
                                                               int YildizSayisi, string Il, 
                                                               string Ilce, string Cadde, 
                                                               string Mahalle, string Sokak);
        protected abstract Oteller OtelSilmeIslemi(Oteller Root, string OtelAdi);
        protected abstract int AgacDerinligiBulmaIslemi(Oteller Root);
        protected abstract int DugumSeviyeHesaplamaIslemi(Oteller Otel, string OtelAdi, int Seviye);
        protected abstract int ElemanSayisiHesaplamaIslemi(Oteller Root);
        protected abstract void PreOrderOtelListelemeIslemi(Oteller Root, Oteller tempotel,
                                                            DataGridView dgv, ListView AgacSeviyeleri);
        protected abstract void InOrderOtelListelemeIslemi(Oteller Root, Oteller tempotel, 
                                                           DataGridView dgv, ListView AgacSeviyeleri);
        protected abstract void PostOrderOtelListelemeIslemi(Oteller Root, Oteller tempotel, 
                                                             DataGridView dgv, ListView AgacSeviyeleri);
        protected abstract Oteller IsmeGoreOtelAramaIslemleri(Oteller Root, string OtelAdi);
        protected abstract Oteller SehreGoreOtelAramaIslemleri(Oteller Root, string SehirAdi);
        protected abstract string EnSoldakiIsim(Oteller Root);
    }
}
