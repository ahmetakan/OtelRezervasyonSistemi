using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public class OtelIslemleri : BinarySearchTreeADT
    {
        Oteller Root;

        public Oteller _Root
        {
            get { return Root; }
            private set { }
        }

        public OtelIslemleri()
        {
            Root = null;
        }

        public void OtelEkle(Oteller Otel)
        {
            Root = OtelEklemeIslemi(Root, Otel);
        }

        protected override Oteller OtelEklemeIslemi(Oteller Root, Oteller Otel)
        {
            if (Root == null)
            {
                Root = Otel;
            }

            else if (string.Compare(Otel.otel.OtelAdi, Root.otel.OtelAdi) == 1)
            {
                Root.RightOtel = OtelEklemeIslemi(Root.RightOtel, Otel);
            }

            else if (string.Compare(Otel.otel.OtelAdi, Root.otel.OtelAdi) == -1)
            {
                Root.LeftOtel = OtelEklemeIslemi(Root.LeftOtel, Otel);
            }

            else
            {
                MessageBox.Show("Sistemde bu isimle kayıtlı otel" + Environment.NewLine +
                                "halihazırda bulunmaktadır." + Environment.NewLine +
                                "Lütfen başka bir isim deneyiniz.", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            return Root;
        }

        public void OtelBilgisiGuncelle(string OtelAdi, string Eposta, 
                                        long TelefonNumarasi, 
                                        int YildizSayisi, string Il, 
                                        string Ilce, string Cadde, 
                                        string Mahalle, string Sokak)
        {
            Root = OtelBilgisiGuncellemeIslemi(Root, OtelAdi, Eposta, TelefonNumarasi,
                                               YildizSayisi, Il, Ilce, Cadde, Mahalle, Sokak);
        }

        protected override Oteller OtelBilgisiGuncellemeIslemi(Oteller Root, string OtelAdi, 
                                                               string Eposta, long TelefonNumarasi, 
                                                               int YildizSayisi, string Il, 
                                                               string Ilce, string Cadde, 
                                                               string Mahalle, string Sokak)
        {
            if (string.Compare(OtelAdi, Root.otel.OtelAdi) == 0)
            {
                Root.otel.Eposta = Eposta;
                Root.otel.TelefonNumarasi = TelefonNumarasi;
                Root.otel.YildizSayisi = YildizSayisi;
                Root.otel.adres.Il = Il;
                Root.otel.adres.Ilce = Ilce;
                Root.otel.adres.Cadde = Cadde;
                Root.otel.adres.Mahalle = Mahalle;
                Root.otel.adres.Sokak = Sokak;
            }

            else if (string.Compare(OtelAdi, Root.otel.OtelAdi) == 1)
            {
                Root.RightOtel = OtelBilgisiGuncellemeIslemi(Root.RightOtel, OtelAdi, Eposta, 
                                                             TelefonNumarasi, YildizSayisi, 
                                                             Il, Ilce, Cadde, Mahalle, Sokak);
            }

            else
            {
                Root.LeftOtel = OtelBilgisiGuncellemeIslemi(Root.LeftOtel, OtelAdi, Eposta, 
                                                            TelefonNumarasi, YildizSayisi, 
                                                            Il, Ilce, Cadde, Mahalle, Sokak);
            }

            return Root;
        }

        public Oteller OtelBulucu(string OtelAdi)
        {
            Oteller tempotel = Root;
            tempotel = (OtelBulmaIslemi(tempotel, OtelAdi));
            return tempotel;
        }

        public Oteller OtelBulmaIslemi(Oteller tempotel, string OtelAdi)
        {
            if (string.Compare(tempotel.otel.OtelAdi, OtelAdi) == 1)
            {
                tempotel= OtelBulmaIslemi(tempotel.LeftOtel, OtelAdi);

                return tempotel;
            }

            else if (string.Compare(tempotel.otel.OtelAdi, OtelAdi) == -1)
            {
                tempotel= OtelBulmaIslemi(tempotel.RightOtel, OtelAdi);

                return tempotel;
            }

            return tempotel;
        }

        public void OtelSil(string OtelAdi)
        {
            Root = OtelSilmeIslemi(Root, OtelAdi);

            MessageBox.Show("Otel silme işlemi başarıya gerçekleştirildi.",
                            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override Oteller OtelSilmeIslemi(Oteller Root, string OtelAdi)
        {
            if (Root == null)
            {
                return Root;
            }

            if (string.Compare(Root.otel.OtelAdi, OtelAdi) == 1)
            {
                Root.LeftOtel = OtelSilmeIslemi(Root.LeftOtel, OtelAdi);
            }
            else if (string.Compare(Root.otel.OtelAdi, OtelAdi) == -1)
            {
                Root.RightOtel = OtelSilmeIslemi(Root.RightOtel, OtelAdi);
            }
            else
            {
                if (Root.LeftOtel == null)
                {
                    return Root.RightOtel;
                }

                else if (Root.RightOtel == null)
                {
                    return Root.LeftOtel;
                }

                Root.otel.OtelAdi = EnSoldakiIsim(Root.RightOtel);

                Root.RightOtel = OtelSilmeIslemi(Root.RightOtel, Root.otel.OtelAdi);
            }

            return Root;
        }

        protected override string EnSoldakiIsim(Oteller Root)
        {
            string EnSoldakiIsim = Root.otel.OtelAdi;

            while (Root.LeftOtel != null)
            {
                EnSoldakiIsim = Root.LeftOtel.otel.OtelAdi;
                Root = Root.LeftOtel;
            }

            return EnSoldakiIsim;
        }

        public int RowIndex = -1;

        public void PreOrderOtelListele(DataGridView dgv, ListView AgacSeviyeleri)
        {
            dgv.Rows.Clear();
            AgacSeviyeleri.Clear();

            RowIndex = -1;

            Oteller tempotel2 = (Oteller)Root.Clone();

            PreOrderOtelListelemeIslemi(Root, tempotel2, dgv, AgacSeviyeleri);

            dgv.Refresh();
        }

        protected override void PreOrderOtelListelemeIslemi(Oteller Root, Oteller tempotel, DataGridView dgv, ListView AgacSeviyeleri)
        {
            if (Root == null)
            {
                return;
            }

            dgv.Rows.Add();

            dgv.Rows[++RowIndex].Cells[0].Value = Root.otel.OtelAdi;
            dgv.Rows[RowIndex].Cells[1].Value = Root.otel.Eposta;
            dgv.Rows[RowIndex].Cells[2].Value = Root.otel.TelefonNumarasi;
            dgv.Rows[RowIndex].Cells[3].Value = Root.otel.YildizSayisi;
            dgv.Rows[RowIndex].Cells[4].Value = Root.otel.adres.Il;
            dgv.Rows[RowIndex].Cells[5].Value = Root.otel.adres.Ilce;
            dgv.Rows[RowIndex].Cells[6].Value = Root.otel.adres.Cadde;
            dgv.Rows[RowIndex].Cells[7].Value = Root.otel.adres.Mahalle;
            dgv.Rows[RowIndex].Cells[8].Value = Root.otel.adres.Sokak;

            DugumSeviyeBul(dgv.Rows[RowIndex].Cells[0].Value.ToString(), tempotel, AgacSeviyeleri);
            
            PreOrderOtelListelemeIslemi(Root.LeftOtel, tempotel, dgv, AgacSeviyeleri);

            PreOrderOtelListelemeIslemi(Root.RightOtel, tempotel, dgv, AgacSeviyeleri);
        }

        public void InOrderOtelListele(DataGridView dgv, ListView AgacSeviyeleri)
        {
            dgv.Rows.Clear();
            AgacSeviyeleri.Clear();

            RowIndex = -1;

            Oteller tempotel2 = (Oteller)Root.Clone();

            InOrderOtelListelemeIslemi(Root, tempotel2, dgv, AgacSeviyeleri);

            dgv.Refresh();
        }

        protected override void InOrderOtelListelemeIslemi(Oteller Root, Oteller tempotel, DataGridView dgv, ListView AgacSeviyeleri)
        {
            if (Root == null)
            {
                return;
            }

            InOrderOtelListelemeIslemi(Root.LeftOtel, tempotel, dgv, AgacSeviyeleri);

            dgv.Rows.Add();

            dgv.Rows[++RowIndex].Cells[0].Value = Root.otel.OtelAdi;
            dgv.Rows[RowIndex].Cells[1].Value = Root.otel.Eposta;
            dgv.Rows[RowIndex].Cells[2].Value = Root.otel.TelefonNumarasi;
            dgv.Rows[RowIndex].Cells[3].Value = Root.otel.YildizSayisi;
            dgv.Rows[RowIndex].Cells[4].Value = Root.otel.adres.Il;
            dgv.Rows[RowIndex].Cells[5].Value = Root.otel.adres.Ilce;
            dgv.Rows[RowIndex].Cells[6].Value = Root.otel.adres.Cadde;
            dgv.Rows[RowIndex].Cells[7].Value = Root.otel.adres.Mahalle;
            dgv.Rows[RowIndex].Cells[8].Value = Root.otel.adres.Sokak;

            DugumSeviyeBul(dgv.Rows[RowIndex].Cells[0].Value.ToString(), tempotel, AgacSeviyeleri);

            InOrderOtelListelemeIslemi(Root.RightOtel, tempotel, dgv, AgacSeviyeleri);
        }

        public void PostOrderOtelListele(DataGridView dgv, ListView AgacSeviyeleri)
        {
            dgv.Rows.Clear();
            AgacSeviyeleri.Clear();

            RowIndex = -1;

            Oteller tempotel2 = (Oteller)Root.Clone();

            PostOrderOtelListelemeIslemi(Root, tempotel2, dgv, AgacSeviyeleri);

            dgv.Refresh();
        }

        protected override void PostOrderOtelListelemeIslemi(Oteller Root, Oteller tempotel, DataGridView dgv, ListView AgacSeviyeleri)
        {
            if (Root == null)
            {
                return;
            }

            PostOrderOtelListelemeIslemi(Root.LeftOtel, tempotel, dgv, AgacSeviyeleri);

            PostOrderOtelListelemeIslemi(Root.RightOtel, tempotel, dgv, AgacSeviyeleri);

            dgv.Rows.Add();

            dgv.Rows[++RowIndex].Cells[0].Value = Root.otel.OtelAdi;
            dgv.Rows[RowIndex].Cells[1].Value = Root.otel.Eposta;
            dgv.Rows[RowIndex].Cells[2].Value = Root.otel.TelefonNumarasi;
            dgv.Rows[RowIndex].Cells[3].Value = Root.otel.YildizSayisi;
            dgv.Rows[RowIndex].Cells[4].Value = Root.otel.adres.Il;
            dgv.Rows[RowIndex].Cells[5].Value = Root.otel.adres.Ilce;
            dgv.Rows[RowIndex].Cells[6].Value = Root.otel.adres.Cadde;
            dgv.Rows[RowIndex].Cells[7].Value = Root.otel.adres.Mahalle;
            dgv.Rows[RowIndex].Cells[8].Value = Root.otel.adres.Sokak;

            DugumSeviyeBul(dgv.Rows[RowIndex].Cells[0].Value.ToString(), tempotel, AgacSeviyeleri);
        }

        public void AgacDerinligiBul(TextBox txt)
        {
            txt.Text = AgacDerinligiBulmaIslemi(Root).ToString();
        }

        protected override int AgacDerinligiBulmaIslemi(Oteller Root)
        {
            if (Root == null)
            {
                return 0;
            }

            else
            {
                int SolDerinlik = AgacDerinligiBulmaIslemi(Root.LeftOtel);
                int SagDerinlik = AgacDerinligiBulmaIslemi(Root.RightOtel);

                if (SolDerinlik > SagDerinlik)
                {
                    return (SolDerinlik + 1);
                }

                else
                {
                    return (SagDerinlik + 1);
                }
            }
        }

        public void ElemanSayisiHesapla(TextBox txt)
        {
            txt.Text = ElemanSayisiHesaplamaIslemi(Root).ToString();
        }

        protected override int ElemanSayisiHesaplamaIslemi(Oteller Root)
        {
            int ElemanSayisi = 0;

            if (Root != null)
            {
                ElemanSayisi = 1;
                ElemanSayisi += ElemanSayisiHesaplamaIslemi(Root.LeftOtel);
                ElemanSayisi += ElemanSayisiHesaplamaIslemi(Root.RightOtel);
            }

            return ElemanSayisi;
        }

        public void DugumSeviyeBul(string OtelAdi, Oteller tempotel, ListView AgacSeviyeleri)
        {
            string OtelVeSeviyesi = "Otel: " + OtelAdi + " | " + "Seviye: --> " 
                                    + DugumSeviyeHesaplamaIslemi(tempotel, OtelAdi, 1);
            
            AgacSeviyeleri.Items.Add(OtelVeSeviyesi);
        }
        protected override int DugumSeviyeHesaplamaIslemi(Oteller Otel, string OtelAdi, int Seviye)
        {
            if (Otel == null)
            {
                return 0;
            }

            if (Otel.otel.OtelAdi == OtelAdi)
            {
                return Seviye;
            }

            int AltSeviye = DugumSeviyeHesaplamaIslemi(Otel.LeftOtel, OtelAdi, Seviye + 1);
            
            if (AltSeviye != 0)
            {
                return AltSeviye;
            }

            AltSeviye = DugumSeviyeHesaplamaIslemi(Otel.RightOtel, OtelAdi, Seviye + 1);
            return AltSeviye;
        }

        public void OtelAra(TextBox txtOtelAdi, DataGridView dgv)
        {

            Oteller ArananOtel = (Oteller)Root.Clone();

            if (txtOtelAdi.Text == "")
            {
                MessageBox.Show("Bu alan boş bırakılamaz." + Environment.NewLine +
                                "Lütfen kutucuğu doldurunuz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dgv.Rows.Clear();
                dgv.Refresh();
            }

            else
            {

                if (IsmeGoreOtelAramaIslemleri(ArananOtel, txtOtelAdi.Text) == null)
                {
                    MessageBox.Show("Bu isimli bir otel bulunamadı.",
                                    "Uyarı", MessageBoxButtons.OK, 
                                    MessageBoxIcon.Warning);
                    
                    dgv.Rows.Clear();
                    dgv.Refresh();
                }
                else
                {
                    ArananOtel = (Oteller)Root.Clone();

                    ArananOtel = (Oteller)IsmeGoreOtelAramaIslemleri(ArananOtel, txtOtelAdi.Text).Clone();

                    dgv.Rows.Clear();

                    RowIndex = -1;

                    dgv.Rows.Add();

                    dgv.Rows[++RowIndex].Cells[0].Value = ArananOtel.otel.OtelAdi;
                    dgv.Rows[RowIndex].Cells[1].Value = ArananOtel.otel.Eposta;
                    dgv.Rows[RowIndex].Cells[2].Value = ArananOtel.otel.TelefonNumarasi;
                    dgv.Rows[RowIndex].Cells[3].Value = ArananOtel.otel.YildizSayisi;
                    dgv.Rows[RowIndex].Cells[4].Value = ArananOtel.otel.OtelPuani;
                    dgv.Rows[RowIndex].Cells[5].Value = ArananOtel.otel.adres.Il;
                    dgv.Rows[RowIndex].Cells[6].Value = ArananOtel.otel.adres.Ilce;
                    dgv.Rows[RowIndex].Cells[7].Value = ArananOtel.otel.adres.Cadde;
                    dgv.Rows[RowIndex].Cells[8].Value = ArananOtel.otel.adres.Mahalle;
                    dgv.Rows[RowIndex].Cells[9].Value = ArananOtel.otel.adres.Sokak;

                    dgv.Refresh();
                }
            }
        }

        protected override Oteller IsmeGoreOtelAramaIslemleri(Oteller Root, string OtelAdi)
        {
            if (Root == null || Root.otel.OtelAdi == OtelAdi)
            {
                return Root;
            }

            if (string.Compare(Root.otel.OtelAdi, OtelAdi) == -1)
            { 
                return IsmeGoreOtelAramaIslemleri(Root.RightOtel, OtelAdi);
            }

            else
            {
                return IsmeGoreOtelAramaIslemleri(Root.LeftOtel, OtelAdi);
            }
        }

        public void SehireGoreOtelAra(TextBox txtSehirAdi, DataGridView dgv)
        {
            Oteller ArananOtel = (Oteller)Root.Clone();

            if (txtSehirAdi.Text == "")
            {
                MessageBox.Show("Bu alan boş bırakılamaz." + Environment.NewLine +
                                "Lütfen kutucuğu doldurunuz.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dgv.Rows.Clear();
                dgv.Refresh();
            }

            else
            {
                string OtelAdi = null;

                OtelAdi = OtelleriGez(ArananOtel, txtSehirAdi.Text, OtelAdi);

                if (SehreGoreOtelAramaIslemleri(ArananOtel, OtelAdi) == null)
                {
                    MessageBox.Show("Bu isimli bir otel bulunamadı.",
                                    "Uyarı", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    dgv.Rows.Clear();
                    dgv.Refresh();
                }
                else
                {
                    ArananOtel = (Oteller)Root.Clone();

                    ArananOtel = (Oteller)SehreGoreOtelAramaIslemleri(ArananOtel, OtelAdi).Clone();

                    dgv.Rows.Clear();

                    RowIndex = -1;

                    dgv.Rows.Add();

                    dgv.Rows[++RowIndex].Cells[0].Value = ArananOtel.otel.OtelAdi;
                    dgv.Rows[RowIndex].Cells[1].Value = ArananOtel.otel.Eposta;
                    dgv.Rows[RowIndex].Cells[2].Value = ArananOtel.otel.TelefonNumarasi;
                    dgv.Rows[RowIndex].Cells[3].Value = ArananOtel.otel.YildizSayisi;
                    dgv.Rows[RowIndex].Cells[4].Value = ArananOtel.otel.OtelPuani;
                    dgv.Rows[RowIndex].Cells[5].Value = ArananOtel.otel.adres.Il;
                    dgv.Rows[RowIndex].Cells[6].Value = ArananOtel.otel.adres.Ilce;
                    dgv.Rows[RowIndex].Cells[7].Value = ArananOtel.otel.adres.Cadde;
                    dgv.Rows[RowIndex].Cells[8].Value = ArananOtel.otel.adres.Mahalle;
                    dgv.Rows[RowIndex].Cells[9].Value = ArananOtel.otel.adres.Sokak;

                    dgv.Refresh();
                }
            }
        }

        protected override Oteller SehreGoreOtelAramaIslemleri(Oteller Root, string OtelAdi)
        {
            if (Root == null || Root.otel.OtelAdi == OtelAdi)
            {
                return Root;
            }

            if (string.Compare(Root.otel.OtelAdi, OtelAdi) == -1)
            {
                return SehreGoreOtelAramaIslemleri(Root.RightOtel, OtelAdi);
            }

            else
            {
                return SehreGoreOtelAramaIslemleri(Root.LeftOtel, OtelAdi);
            }
        }

        public string OtelleriGez(Oteller Root, string SehirAdi, string OtelAdi)
        {
            if (Root != null)
            {
                if (string.Compare(Root.otel.adres.Il, SehirAdi) == 0)
                {
                    OtelAdi = Root.otel.OtelAdi;
                    return OtelAdi;
                }

                OtelAdi = OtelleriGez(Root.LeftOtel, SehirAdi, OtelAdi);

                if (string.Compare(Root.otel.adres.Il, SehirAdi) == 0)
                {
                    OtelAdi = Root.otel.OtelAdi;
                    return OtelAdi;
                }

                OtelAdi = OtelleriGez(Root.RightOtel, SehirAdi, OtelAdi);

                if (string.Compare(Root.otel.adres.Il, SehirAdi) == 0)
                {
                    OtelAdi = Root.otel.OtelAdi;
                    return OtelAdi;
                }
            }

            return OtelAdi;
        }
    }
}
