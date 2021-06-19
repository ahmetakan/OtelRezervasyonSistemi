using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public partial class frmMusteri : Form
    {
        public frmMusteri()
        {
            InitializeComponent();
        }

        public int KisiSayisiAl(TextBox txt)
        {
            int KisiSayisi = Convert.ToInt32(txt.Text);

            return KisiSayisi;
        }


        private void btnPreOrderListele_Click(object sender, EventArgs e)
        {
            frmMenu.Islemler.PreOrderOtelListele(dgvOtelListele, listOtelSeviyeleri);

            frmMenu.Islemler.AgacDerinligiBul(txtAgacDerinligi);

            frmMenu.Islemler.ElemanSayisiHesapla(txtElemanSayisi);
        }

        private void btnInOrderListele_Click(object sender, EventArgs e)
        {
            frmMenu.Islemler.InOrderOtelListele(dgvOtelListele, listOtelSeviyeleri);

            frmMenu.Islemler.AgacDerinligiBul(txtAgacDerinligi);
            
            frmMenu.Islemler.ElemanSayisiHesapla(txtElemanSayisi);
        }

        private void btnPostOrderListele_Click(object sender, EventArgs e)
        {
            frmMenu.Islemler.PostOrderOtelListele(dgvOtelListele, listOtelSeviyeleri);

            frmMenu.Islemler.AgacDerinligiBul(txtAgacDerinligi);

            frmMenu.Islemler.ElemanSayisiHesapla(txtElemanSayisi);
        }

        private void btnIsmeGoreListele_Click(object sender, EventArgs e)
        {
            frmMenu.Islemler.OtelAra(txtOzelOtelAdi, dgvOzelListelemeler);
        }

        private void btnSehreGoreOtelListele_Click(object sender, EventArgs e)
        {
            frmMenu.Islemler.SehireGoreOtelAra(txtOtelSehir, dgvOzelListelemeler);
        }

        private void btnOtelleriListele_Click(object sender, EventArgs e)
        {
            frmMenu.Islemler.PreOrderOtelListele(dgvRezervasyonOtelleri, listOtelSeviyeleri);
        }

        public int KisiSayisi;
        public Musteri[] musteriler;

        private void btnAyarla_Click(object sender, EventArgs e)
        {
            KisiSayisi = KisiSayisiAl(txtMusteriKisiSayisi);

            txtMusteriAd.Enabled = true;
            txtMusteriSoyad.Enabled = true;
            txtMusteriTCkimlikNo.Enabled = true;
            txtMusteriTelefonNo.Enabled = true;
            txtMusteriEposta.Enabled = true;
            txtMusteriIl.Enabled = true;
            txtMusteriIlce.Enabled = true;
            txtMusteriCadde.Enabled = true;
            txtMusteriMahalle.Enabled = true;
            txtMusteriSokak.Enabled = true;

            txtMusteriKisiSayisi.Enabled = false;
            txtKalinacakGunSayisi.Enabled = false;

            btnKisiyiEkle.Enabled = true;
            btnAyarla.Enabled = false;

            musteriler = new Musteri[KisiSayisi];
        }

        public int counter = 0;
        public void KisiEkle()
        {
            if (counter < KisiSayisi)
            {
                Musteri musteri = new Musteri();

                musteri.Ad = txtMusteriAd.Text;
                musteri.Soyad = txtMusteriSoyad.Text;
                musteri.TCkimlikNumarasi = Convert.ToInt64(txtMusteriTCkimlikNo.Text);
                musteri.TelefonNumarasi = Convert.ToInt64(txtMusteriTelefonNo.Text);
                musteri.Eposta = txtMusteriEposta.Text;
                musteri.adres.Il = txtMusteriIl.Text;
                musteri.adres.Ilce = txtMusteriIlce.Text;
                musteri.adres.Cadde = txtMusteriCadde.Text;
                musteri.adres.Mahalle = txtMusteriMahalle.Text;
                musteri.adres.Sokak = txtMusteriSokak.Text;

                musteriler[counter] = musteri;

                txtMusteriAd.Clear();
                txtMusteriSoyad.Clear();
                txtMusteriTCkimlikNo.Clear();
                txtMusteriTelefonNo.Clear();
                txtMusteriEposta.Clear();
                txtMusteriIl.Clear();
                txtMusteriIlce.Clear();
                txtMusteriCadde.Clear();
                txtMusteriMahalle.Clear();
                txtMusteriSokak.Clear();

                counter++;

                if (counter == KisiSayisi)
                {
                    txtMusteriAd.Enabled = false;
                    txtMusteriSoyad.Enabled = false;
                    txtMusteriTCkimlikNo.Enabled = false;
                    txtMusteriTelefonNo.Enabled = false;
                    txtMusteriEposta.Enabled = false;
                    txtMusteriIl.Enabled = false;
                    txtMusteriIlce.Enabled = false;
                    txtMusteriCadde.Enabled = false;
                    txtMusteriMahalle.Enabled = false;
                    txtMusteriSokak.Enabled = false;

                    btnKisiyiEkle.Enabled = false;

                    KisiSayisi = 0;
                    counter = 0;
                }
            }
        }

        private void btnKisiyiEkle_Click(object sender, EventArgs e)
        {
            KisiEkle();
        }

        private void dgvRezervasyonOtelleri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvRezervasyonOtelleri.SelectedCells[0].RowIndex;

            txtSecilenOtel.Text = dgvRezervasyonOtelleri.Rows[Index].Cells[0].Value == null ?
                                     string.Empty : dgvRezervasyonOtelleri.Rows[Index].Cells[0].Value.ToString();

            string OtelAdi = dgvRezervasyonOtelleri.Rows[Index].Cells[0].Value.ToString();

            frmMenu.listIslemleri.OdaListele(OtelAdi, dgvRezervasyonOda);
        }

        public int GunlukUcret;
        private void dgvRezervasyonOda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvRezervasyonOda.SelectedCells[0].RowIndex;

            txtSecilenOdaNumarasi.Text = dgvRezervasyonOda.Rows[Index].Cells[0].Value == null ?
                                     string.Empty : dgvRezervasyonOda.Rows[Index].Cells[0].Value.ToString();

            GunlukUcret = Convert.ToInt32(dgvRezervasyonOda.Rows[Index].Cells[5].Value);

            txtMusteriKisiSayisi.Enabled = true;
            txtKalinacakGunSayisi.Enabled = true;
            btnAyarla.Enabled = true;
        }

        private void btnRezervasyonuGerceklestir_Click(object sender, EventArgs e)
        {
            Oteller otel = frmMenu.Islemler.OtelBulucu(txtSecilenOtel.Text);
            HashChainEntry rezervasyon = new HashChainEntry(musteriler.Length);
            
            for (int i = 0; i < musteriler.Length; i++)
            {
                rezervasyon.Rezervasyon.HeapDizisi.Insert(musteriler[i]);
            }

            int ToplamUcret = GunlukUcret * Convert.ToInt32(txtKalinacakGunSayisi.Text);

            rezervasyon.Rezervasyon.ToplamUcret = ToplamUcret;
            rezervasyon.Rezervasyon.GunSayisi = Convert.ToInt32(txtKalinacakGunSayisi.Text);
            rezervasyon.Rezervasyon.KisiSayisi = musteriler.Length;
            rezervasyon.Rezervasyon.OdaNo = Convert.ToInt32(txtSecilenOdaNumarasi.Text);
            rezervasyon.Rezervasyon.OtelAdi = txtSecilenOtel.Text;
            
            otel.rezervasyonlar.RezervasyonEkle(rezervasyon);

            MessageBox.Show("Rezervasyon işleminiz " + Environment.NewLine +
                            "başarıyla gerçekleştirildi.", "Bilgi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnYorumOtelleriListele_Click(object sender, EventArgs e)
        {
            frmMenu.Islemler.PreOrderOtelListele(dgvOtelYorum, listOtelSeviyeleri);
        }

        private void dgvOtelYorum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvOtelYorum.SelectedCells[0].RowIndex;

            txtSecilenOtel2.Text = dgvOtelYorum.Rows[Index].Cells[0].Value == null ?
                                     string.Empty : dgvOtelYorum.Rows[Index].Cells[0].Value.ToString();

            rdb1puan.Enabled = true;
            rdb2puan.Enabled = true;
            rdb3puan.Enabled = true;
            rdb4puan.Enabled = true;
            rdb5puan.Enabled = true;

            rdb3puan.Checked = true;

            foreach (string item in YorumYapilanOteller)
            {
                if (item == txtSecilenOtel2.Text)
                {
                    rdb1puan.Enabled = false;
                    rdb2puan.Enabled = false;
                    rdb3puan.Enabled = false;
                    rdb4puan.Enabled = false;
                    rdb5puan.Enabled = false;

                    rdb3puan.Checked = false;
                }
            }

            rtbYorumYap.Enabled = true;
        }

        private void rtbYorumYap_TextChanged(object sender, EventArgs e)
        {
            

            btnYorumuIlet.Enabled = true;
        }

        public List<string> YorumYapilanOteller = new List<string>();
        
        private void btnYorumuIlet_Click(object sender, EventArgs e)
        {
            int Puan = 0;

            if (rdb1puan.Checked)
            {
                Puan = 1;
            }
            else if (rdb2puan.Checked)
            {
                Puan = 2;
            }
            else if (rdb3puan.Checked)
            {
                Puan = 3;
            }
            else if (rdb4puan.Checked)
            {
                Puan = 4;
            }
            else if (rdb5puan.Checked)
            {
                Puan = 5;
            }

            Oteller otel = frmMenu.Islemler.OtelBulucu(txtSecilenOtel2.Text);

            Yorum yorum = new Yorum
            {
                Ad = frmGirisYap.Musteri.Musteri.Ad,
                Soyad = frmGirisYap.Musteri.Musteri.Soyad,
                Eposta = frmGirisYap.Musteri.Musteri.Eposta,
                Puan = Puan,
                yorum = rtbYorumYap.Text
            };
            
            frmMenu.listIslemleri.YorumEkle(otel, yorum);

            YorumYapilanOteller.Add(txtSecilenOtel2.Text);

            rtbYorumYap.Clear();
            rtbYorumYap.Enabled = false;

            foreach (string item in YorumYapilanOteller)
            {
                if (item == txtSecilenOtel2.Text)
                {
                    rdb1puan.Enabled = false;
                    rdb2puan.Enabled = false;
                    rdb3puan.Enabled = false;
                    rdb4puan.Enabled = false;
                    rdb5puan.Enabled = false;

                    if (rdb1puan.Checked)
                    {
                        rdb1puan.Checked = false;
                    }
                    else if (rdb2puan.Checked)
                    {
                        rdb2puan.Checked = false;
                    }
                    else if (rdb3puan.Checked)
                    {
                        rdb3puan.Checked = false;
                    }
                    else if (rdb4puan.Checked)
                    {
                        rdb4puan.Checked = false;
                    }
                    else if (rdb5puan.Checked)
                    {
                        rdb5puan.Checked = false;
                    }
                }
            }

            MessageBox.Show("Yorumunuz başarıyla iletildi.", "Bilgi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
