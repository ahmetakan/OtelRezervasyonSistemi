using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public partial class frmAdmin : Form
    {

        public void OtelEkle(string oteladi, string eposta, 
                             long telefonnumarasi, int yildizsayisi, 
                             string il, string ilce, string cadde, 
                             string mahalle, string sokak)
        {
            Oteller EklenecekOtel = new Oteller();

            EklenecekOtel.otel.OtelAdi = oteladi;
            EklenecekOtel.otel.Eposta = eposta;
            EklenecekOtel.otel.TelefonNumarasi = telefonnumarasi;
            EklenecekOtel.otel.YildizSayisi = yildizsayisi;
            EklenecekOtel.otel.adres.Il = il;
            EklenecekOtel.otel.adres.Ilce = ilce;
            EklenecekOtel.otel.adres.Cadde = cadde;
            EklenecekOtel.otel.adres.Mahalle = mahalle;
            EklenecekOtel.otel.adres.Sokak = sokak;

            frmMenu.Islemler.OtelEkle(EklenecekOtel);

            PreOrderOtelListele(dgvOtelListele);
        }

        public void PreOrderOtelListele(DataGridView dgv)
        {
            frmMenu.Islemler.PreOrderOtelListele(dgv, listtemp);
        }

        public void OtelBilgisiGuncelle()
        {
            frmMenu.Islemler.OtelBilgisiGuncelle(GuncellenecekOtelAdi, txtEpostaGuncelle.Text, 
                                                 Convert.ToInt64(txtTelefonNumarasiGuncelle.Text), 
                                                 Convert.ToInt32(txtYildizSayisiGuncelle.Text), 
                                                 txtIlGuncelle.Text, txtIlceGuncelle.Text, 
                                                 txtCaddeGuncelle.Text, txtMahalleGuncelle.Text, 
                                                 txtSokakGuncelle.Text);

            MessageBox.Show("Otel bilgisi güncelleme işlemi" + Environment.NewLine + 
                            "başarıyla gerçekleştirildi.", "Bilgi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            PreOrderOtelListele(dgvOtelListele);
            PreOrderOtelListele(dgvSilinecekOtelListesi);

            btnGuncelle.Enabled = false;
        }

        public void OtelSil()
        {
            frmMenu.Islemler.OtelSil(txtSilinecekOtelAdi.Text);

            PreOrderOtelListele(dgvSilinecekOtelListesi);
            PreOrderOtelListele(dgvOtelListele);

            txtSilinecekOtelAdi.Clear();
            txtSilinecekOtelEposta.Clear();
            txtSilinecekOtelTelefonNumarasi.Clear();
            txtSilinecekOtelYildizSayisi.Clear();

            btnOtelSil.Enabled = false;
        }

        public void OdaEkle()
        {
            Oda oda = new Oda();

            Random rnd = new Random();
            int odanumarasi = rnd.Next() % 10000;

            oda.OdaNumarasi = odanumarasi;
            oda.TelefonNumarasi = Convert.ToInt64(txtOdaTelefonNumarasi.Text);
            oda.Fiyat = Convert.ToDecimal(txtOdaFiyati.Text);
            oda.KisiSayisi = Convert.ToInt32(txtOdaKisiSayisi.Text);
            oda.ManzaraBilgisi = cmbOdaManzaraBilgisi.SelectedItem.ToString();
            oda.RezervasyonDurumu = false;

            frmMenu.listIslemleri.OdaEklemeIslemi(frmMenu.Islemler.OtelBulucu(txtOdaOtel.Text), oda);

            MessageBox.Show("Oda ekleme işlemi başarıyla gerçekleştirildi.",
                            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnOdaEkle.Enabled = false;
        }
        public void PersonelEkle()
        {
            Personel personel = new Personel();

            personel.Ad = txtEklenecekPersonelAdi.Text;
            personel.Soyad = txtEklenecekPersonelSoyadi.Text;
            personel.Eposta = txtEklenecekPersonelEpostasi.Text;
            personel.TCkimlikNumarasi = Convert.ToInt64(txtEklenecekPersonelTCkimlikNo.Text);
            personel.TelefonNumarasi = Convert.ToInt64(txtEklenecekPersonelTelefonNumarasi.Text);
            personel.Departman = cmbEklenecekPersonelDepartman.SelectedItem.ToString();
            personel.Pozisyon = cmbEklenecekPersonelPozisyon.SelectedItem.ToString();
            personel.adres.Il = txtEklenecekPersonelIli.Text;
            personel.adres.Ilce = txtEklenecekPersonelIlcesi.Text;
            personel.adres.Cadde = txtEklenecekPersonelCaddesi.Text;
            personel.adres.Mahalle = txtEklenecekPersonelMahallesi.Text;
            personel.adres.Sokak = txtEklenecekPersonelSokak.Text;
            
            frmMenu.listIslemleri.PersonelEklemeIslemi(frmMenu.Islemler.OtelBulucu(txtPersonelOtel.Text), personel);

            MessageBox.Show("Personel ekleme işlemi " +
                            "başarıyla gerçekleştirildi." + 
                            Environment.NewLine , "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnPersonelEkle.Enabled = false;
        }

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnOtelEkle_Click(object sender, EventArgs e)
        {
            OtelEkle(txtOtelAdiEkle.Text, txtEpostaEkle.Text, 
                     Convert.ToInt32(txtTelefonNumarasiEkle.Text), 
                     Convert.ToInt32(txtYildizSayisiEkle.Text), 
                     txtIlEkle.Text, txtIlceEkle.Text, txtCaddeEkle.Text, 
                     txtMahalleEkle.Text, txtSokakEkle.Text);
        }

        private void btnOtelListele_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvOtelListele);
        }

        public string GuncellenecekOtelAdi = null;
        private void dgvOtelListele_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvOtelListele.SelectedCells[0].RowIndex;

            GuncellenecekOtelAdi = dgvOtelListele.Rows[Index].Cells[0].Value == null ?
                                     string.Empty : dgvOtelListele.Rows[Index].Cells[0].Value.ToString();

            txtEpostaGuncelle.Text = dgvOtelListele.Rows[Index].Cells[1].Value == null ? 
                                     string.Empty : dgvOtelListele.Rows[Index].Cells[1].Value.ToString();

            txtTelefonNumarasiGuncelle.Text = dgvOtelListele.Rows[Index].Cells[2].Value == null 
                                              ? string.Empty : dgvOtelListele.Rows[Index].Cells[2].Value.ToString();
            txtYildizSayisiGuncelle.Text = dgvOtelListele.Rows[Index].Cells[3].Value == null 
                                           ? string.Empty : dgvOtelListele.Rows[Index].Cells[3].Value.ToString();
            txtIlGuncelle.Text = dgvOtelListele.Rows[Index].Cells[4].Value == null ? 
                                 string.Empty : dgvOtelListele.Rows[Index].Cells[4].Value.ToString();
            txtIlceGuncelle.Text = dgvOtelListele.Rows[Index].Cells[5].Value == null 
                                   ? string.Empty : dgvOtelListele.Rows[Index].Cells[5].Value.ToString();
            txtCaddeGuncelle.Text = dgvOtelListele.Rows[Index].Cells[6].Value == null 
                                    ? string.Empty : dgvOtelListele.Rows[Index].Cells[6].Value.ToString();
            txtMahalleGuncelle.Text = dgvOtelListele.Rows[Index].Cells[7].Value == null 
                                      ? string.Empty : dgvOtelListele.Rows[Index].Cells[7].Value.ToString();
            txtSokakGuncelle.Text = dgvOtelListele.Rows[Index].Cells[8].Value == null 
                                    ? string.Empty : dgvOtelListele.Rows[Index].Cells[8].Value.ToString();

            btnGuncelle.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            OtelBilgisiGuncelle();
        }

        private void btnSilinecekOtelleriListele_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvSilinecekOtelListesi);
        }

        private void dgvSilinecekOtelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvSilinecekOtelListesi.SelectedCells[0].RowIndex;

            txtSilinecekOtelAdi.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[0].Value == null ?
                                     string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[0].Value.ToString();

            txtSilinecekOtelEposta.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[1].Value == null ?
                                     string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[1].Value.ToString();

            txtSilinecekOtelTelefonNumarasi.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[2].Value == null
                                              ? string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[2].Value.ToString();
            txtSilinecekOtelYildizSayisi.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[3].Value == null
                                           ? string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[3].Value.ToString();
            txtSilinecekOtelIl.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[4].Value == null ?
                                 string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[4].Value.ToString();
            txtSilinecekOtelIlce.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[5].Value == null
                                   ? string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[5].Value.ToString();
            txtSilinecekOtelCadde.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[6].Value == null
                                    ? string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[6].Value.ToString();
            txtSilinecekOtelMahalle.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[7].Value == null
                                      ? string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[7].Value.ToString();
            txtSilinecekOtelSokak.Text = dgvSilinecekOtelListesi.Rows[Index].Cells[8].Value == null
                                    ? string.Empty : dgvSilinecekOtelListesi.Rows[Index].Cells[8].Value.ToString();

            btnOtelSil.Enabled = true;
        }

        private void btnOtelSil_Click(object sender, EventArgs e)
        {
            OtelSil();
        }

        private void btnPersonelOtelListele_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvPersonelOtelListesi);
        }

        private void dgvPersonelOtelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvPersonelOtelListesi.SelectedCells[0].RowIndex;

            txtPersonelOtel.Text = dgvPersonelOtelListesi.Rows[Index].Cells[0].Value == null ?
                                       string.Empty : dgvPersonelOtelListesi.Rows[Index].Cells[0].Value.ToString();

            txtEklenecekPersonelAdi.Enabled = true;
            txtEklenecekPersonelSoyadi.Enabled = true;
            txtEklenecekPersonelTCkimlikNo.Enabled = true;
            txtEklenecekPersonelTelefonNumarasi.Enabled = true;
            txtEklenecekPersonelEpostasi.Enabled = true;
            cmbEklenecekPersonelDepartman.Enabled = true;
            cmbEklenecekPersonelPozisyon.Enabled = true;
            txtEklenecekPersonelIli.Enabled = true;
            txtEklenecekPersonelIlcesi.Enabled = true;
            txtEklenecekPersonelCaddesi.Enabled = true;
            txtEklenecekPersonelMahallesi.Enabled = true;
            txtEklenecekPersonelSokak.Enabled = true;

            btnPersonelEkle.Enabled = true;
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            PersonelEkle();
        }

        private void dgvOdaOtelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvOdaOtelListesi.SelectedCells[0].RowIndex;

            txtOdaOtel.Text = dgvOdaOtelListesi.Rows[Index].Cells[0].Value == null ?
                                       string.Empty : dgvOdaOtelListesi.Rows[Index].Cells[0].Value.ToString();

            txtOdaTelefonNumarasi.Enabled = true;
            txtOdaFiyati.Enabled = true;
            txtOdaKisiSayisi.Enabled = true;
            cmbOdaManzaraBilgisi.Enabled = true;

            btnOdaEkle.Enabled = true;
        }

        private void btnOdaOtelListele_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvOdaOtelListesi);
        }

        private void btnOdaEkle_Click(object sender, EventArgs e)
        {
            OdaEkle();
        }

        private void dgvGuncellenecekPersonelOtelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvGuncellenecekPersonelOtelListesi.SelectedCells[0].RowIndex;

            txtGuncellenecekPersonelOteli.Text = dgvGuncellenecekPersonelOtelListesi.Rows[Index].Cells[0].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelOtelListesi.Rows[Index].Cells[0].Value.ToString();

            frmMenu.listIslemleri.PersonelListele(txtGuncellenecekPersonelOteli.Text, dgvGuncellenecekPersonelListesi);
        }

        private void btnGuncellenecekPersonelOtelListesi_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvGuncellenecekPersonelOtelListesi);
        }

        private void dgvGuncellenecekPersonelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvGuncellenecekPersonelListesi.SelectedCells[0].RowIndex;

            txtGuncellenecekPersonelAdi.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[0].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[0].Value.ToString();
            txtGuncellenecekPersonelSoyadi.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[1].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[1].Value.ToString();
            txtGuncellenecekPersonelTCkimlikNo.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[2].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[2].Value.ToString();
            txtGuncellenecekPersonelTelefonNo.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[3].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[3].Value.ToString();
            txtGuncellenecekPersonelEposta.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[4].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[4].Value.ToString();
            txtGuncellenecekPersonelIli.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[5].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[5].Value.ToString();
            txtGuncellenecekPersonelIlcesi.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[6].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[6].Value.ToString();
            txtGuncellenecekPersonelCaddesi.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[7].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[7].Value.ToString();
            txtGuncellenecekPersonelMahallesi.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[8].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[8].Value.ToString();
            txtGuncellenecekPersonelSokak.Text = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[9].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[9].Value.ToString();
            cmbGuncellenecekPersonelDepartmani.SelectedItem = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[10].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[10].Value.ToString();
            cmbGuncellenecekPersonelPozisyonu.SelectedItem = dgvGuncellenecekPersonelListesi.Rows[Index].Cells[11].Value == null ?
                                       string.Empty : dgvGuncellenecekPersonelListesi.Rows[Index].Cells[11].Value.ToString();

            txtGuncellenecekPersonelAdi.Enabled = true;
            txtGuncellenecekPersonelSoyadi.Enabled = true;
            txtGuncellenecekPersonelTelefonNo.Enabled = true;
            txtGuncellenecekPersonelEposta.Enabled = true;
            txtGuncellenecekPersonelIli.Enabled = true;
            txtGuncellenecekPersonelIlcesi.Enabled = true;
            txtGuncellenecekPersonelCaddesi.Enabled = true;
            txtGuncellenecekPersonelMahallesi.Enabled = true;
            txtGuncellenecekPersonelSokak.Enabled = true;
            cmbGuncellenecekPersonelDepartmani.Enabled = true;
            cmbGuncellenecekPersonelPozisyonu.Enabled = true;

            btnPersoneliGuncelle.Enabled = true;

        }

        private void btnPersoneliGuncelle_Click(object sender, EventArgs e)
        {
            frmMenu.listIslemleri.PersonelBilgisiGuncelle(txtGuncellenecekPersonelOteli.Text, 
                                                          Convert.ToInt64(txtGuncellenecekPersonelTCkimlikNo.Text), 
                                                          txtGuncellenecekPersonelAdi.Text, 
                                                          txtGuncellenecekPersonelSoyadi.Text, 
                                                          Convert.ToInt64(txtGuncellenecekPersonelTelefonNo.Text), 
                                                          txtGuncellenecekPersonelEposta.Text, 
                                                          txtGuncellenecekPersonelIli.Text, txtGuncellenecekPersonelIlcesi.Text, 
                                                          txtGuncellenecekPersonelCaddesi.Text, 
                                                          txtGuncellenecekPersonelMahallesi.Text, 
                                                          txtGuncellenecekPersonelSokak.Text, 
                                                          cmbGuncellenecekPersonelDepartmani.SelectedItem.ToString(), 
                                                          cmbGuncellenecekPersonelPozisyonu.SelectedItem.ToString());


            frmMenu.listIslemleri.PersonelListele(txtGuncellenecekPersonelOteli.Text, dgvGuncellenecekPersonelListesi);

            btnPersoneliGuncelle.Enabled = false;
        }

        private void btnSilinecekPersonelOtelListele_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvSilinecekPersonelOtelListesi);
        }

        private void dgvSilinecekPersonelOtelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvSilinecekPersonelOtelListesi.SelectedCells[0].RowIndex;

            txtSilinecekPersonelOteli.Text = dgvSilinecekPersonelOtelListesi.Rows[Index].Cells[0].Value == null ?
                                       string.Empty : dgvSilinecekPersonelOtelListesi.Rows[Index].Cells[0].Value.ToString();

            frmMenu.listIslemleri.PersonelListele(txtSilinecekPersonelOteli.Text, dgvSilinecekPersonelListesi);
        }

        private void dgvSilinecekPersonelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvSilinecekPersonelListesi.SelectedCells[0].RowIndex;

            txtSilinecekPersonelAdi.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[0].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[0].Value.ToString();
            txtSilinecekPersonelSoyadi.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[1].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[1].Value.ToString();
            txtSilinecekPersonelTCkimlikNo.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[2].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[2].Value.ToString();
            txtSilinecekPersonelTelefonNo.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[3].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[3].Value.ToString();
            txtSilinecekPersonelEpostasi.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[4].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[4].Value.ToString();
            txtSilinecekPersonelIli.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[5].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[5].Value.ToString();
            txtSilinecekPersonelIlcesi.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[6].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[6].Value.ToString();
            txtSilinecekPersonelCaddesi.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[7].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[7].Value.ToString();
            txtSilinecekPersonelMahallesi.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[8].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[8].Value.ToString();
            txtSilinecekPersonelSokak.Text = dgvSilinecekPersonelListesi.Rows[Index].Cells[9].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[9].Value.ToString();
            cmbSilinecekPersonelDepartmani.SelectedItem = dgvSilinecekPersonelListesi.Rows[Index].Cells[10].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[10].Value.ToString();
            cmbSilinecekPersonelPozisyonu.SelectedItem = dgvSilinecekPersonelListesi.Rows[Index].Cells[11].Value == null ?
                                       string.Empty : dgvSilinecekPersonelListesi.Rows[Index].Cells[11].Value.ToString();

            btnPersoneliSil.Enabled = true;
        }

        private void btnPersoneliSil_Click(object sender, EventArgs e)
        {
            frmMenu.listIslemleri.PersonelSil(txtSilinecekPersonelOteli.Text, 
                                              Convert.ToInt64(txtSilinecekPersonelTCkimlikNo.Text));

            frmMenu.listIslemleri.PersonelListele(txtSilinecekPersonelOteli.Text, dgvSilinecekPersonelListesi);

            btnPersoneliSil.Enabled = false;
        }

        private void btnOtelListele2_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvOtelListesi);
        }

        private void dgvOtelListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbPersonelDepartman.SelectedIndex = 0;

            int Index = dgvOtelListesi.SelectedCells[0].RowIndex;
            
            frmMenu.listIslemleri.PersonelListele(dgvOtelListesi.Rows[Index].Cells[0].Value.ToString(), dgvPersonelListesi);
        }

        private void cmbPersonelDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbPersonelDepartman.SelectedItem.ToString() == "HEPSİ")
            {
                int index = dgvOtelListesi.SelectedCells[0].RowIndex;

                frmMenu.listIslemleri.PersonelListele(dgvOtelListesi.Rows[index].Cells[0].Value.ToString(), dgvPersonelListesi);
            }

            else
            {
                int Index = dgvOtelListesi.SelectedCells[0].RowIndex;

                frmMenu.listIslemleri.PersonelListele(dgvOtelListesi.Rows[Index].Cells[0].Value.ToString(), dgvPersonelListesi);

                DataTable dt = new DataTable();
                dt.Columns.Add("Personel Adı");
                dt.Columns.Add("Personel Soyadı");
                dt.Columns.Add("TC Kimlik Numarası");
                dt.Columns.Add("Telefon Numarası");
                dt.Columns.Add("Eposta");
                dt.Columns.Add("İl");
                dt.Columns.Add("İlce");
                dt.Columns.Add("Cadde");
                dt.Columns.Add("Mahalle");
                dt.Columns.Add("Sokak");
                dt.Columns.Add("Departman");
                dt.Columns.Add("Pozisyon");

                for (int i = 0; i < dgvPersonelListesi.RowCount - 1; i++)
                {
                    if (cmbPersonelDepartman.SelectedItem == dgvPersonelListesi.Rows[i].Cells[10].Value)
                    {
                        DataRow dr = dt.NewRow();

                        for (int j = 0; j < dgvPersonelListesi.Rows[i].Cells.Count - 1; j++)
                        {
                            dr[j] = dgvPersonelListesi.Rows[i].Cells[j].Value;
                        }

                        dt.Rows.Add(dr);
                    }
                }

                dgvPersonelListesi.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int n = dgvPersonelListesi.Rows.Add();
                
                    for (int i = 0; i < dgvPersonelListesi.Columns.Count - 1; i++)
                    {
                        dgvPersonelListesi.Rows[n].Cells[i].Value = row[i].ToString();
                    }
                }
            }
        }

        private void btnOtelRezervasyonlar_Click(object sender, EventArgs e)
        {
            PreOrderOtelListele(dgvRezervasyonOtel);
        }

        private void dgvRezervasyonOtel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = -1;

            int Index = dgvRezervasyonOtel.SelectedCells[0].RowIndex;

            string OtelAdi = dgvRezervasyonOtel.Rows[Index].Cells[0].Value == null ?
                             string.Empty : dgvRezervasyonOtel.Rows[Index].Cells[0].Value.ToString();

            dgvHeapAgaci.Rows.Clear();
            dgvRezervasyonlar.Rows.Clear();

            Oteller otel = frmMenu.Islemler.OtelBulucu(OtelAdi);

            HashChainEntry HashHead;

            for (int i = 0; i < otel.rezervasyonlar.Table.Length; i++)
            {
                HashHead = otel.rezervasyonlar.Table[i];

                while (HashHead != null)
                {
                    dgvRezervasyonlar.Rows.Add();

                    dgvRezervasyonlar.Rows[++RowIndex].Cells[0].Value = HashHead.Rezervasyon.RezervasyonNo;
                    dgvRezervasyonlar.Rows[RowIndex].Cells[1].Value = HashHead.Rezervasyon.OtelAdi;
                    dgvRezervasyonlar.Rows[RowIndex].Cells[2].Value = HashHead.Rezervasyon.OdaNo;
                    dgvRezervasyonlar.Rows[RowIndex].Cells[3].Value = HashHead.Rezervasyon.KisiSayisi;
                    dgvRezervasyonlar.Rows[RowIndex].Cells[4].Value = HashHead.Rezervasyon.GunSayisi;
                    dgvRezervasyonlar.Rows[RowIndex].Cells[5].Value = HashHead.Rezervasyon.ToplamUcret;

                    HashHead = HashHead.Next;
                }
            }
        }

        private void dgvRezervasyonlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = -1;

            int Index = dgvRezervasyonlar.SelectedCells[0].RowIndex;

            string OtelAdi = dgvRezervasyonlar.Rows[Index].Cells[1].Value == null ?
                             string.Empty : dgvRezervasyonlar.Rows[Index].Cells[1].Value.ToString();
            
            int _rezervasyonNo = Convert.ToInt32(dgvRezervasyonlar.Rows[Index].Cells[0].Value);
                                
            Oteller otel = frmMenu.Islemler.OtelBulucu(OtelAdi);

            HashChainEntry HashHead;

            for (int i = 0; i < otel.rezervasyonlar.Table.Length; i++)
            {
                HashHead = otel.rezervasyonlar.Table[i];

                while (HashHead != null)
                {
                    if (HashHead.Rezervasyon.RezervasyonNo == _rezervasyonNo)
                    {
                        Musteri[] musteriler = new Musteri[HashHead.Rezervasyon.HeapDizisi.HeapArray.Length];

                        for (int j = 0; j < HashHead.Rezervasyon.HeapDizisi.HeapArray.Length; j++)
                        {
                            musteriler[j] = HashHead.Rezervasyon.HeapDizisi.HeapArray[j].Musteri;
                            
                        }

                        for (int k = 0; k < musteriler.Length - 1; k++)
                        {
                            for (int j = 0; j < musteriler.Length - k - 1; j++)
                            { 
                                if (string.Compare(musteriler[j].Ad, musteriler[j + 1].Ad) == 1)
                                {
                                    Musteri temp = musteriler[j];

                                    musteriler[j] = musteriler[j + 1];

                                    musteriler[j + 1] = temp;
                                }
                            }
                        }

                        dgvHeapAgaci.Rows.Clear();

                        for (int a = 0; a < musteriler.Length; a++)
                        {
                            dgvHeapAgaci.Rows.Add();

                            dgvHeapAgaci.Rows[++RowIndex].Cells[0].Value = musteriler[a].Ad;
                            dgvHeapAgaci.Rows[RowIndex].Cells[1].Value = musteriler[a].Soyad;
                            dgvHeapAgaci.Rows[RowIndex].Cells[2].Value = musteriler[a].TCkimlikNumarasi;
                            dgvHeapAgaci.Rows[RowIndex].Cells[3].Value = musteriler[a].TelefonNumarasi;
                            dgvHeapAgaci.Rows[RowIndex].Cells[4].Value = musteriler[a].Eposta;
                            dgvHeapAgaci.Rows[RowIndex].Cells[5].Value = musteriler[a].adres.Il;
                            dgvHeapAgaci.Rows[RowIndex].Cells[6].Value = musteriler[a].adres.Ilce;
                            dgvHeapAgaci.Rows[RowIndex].Cells[7].Value = musteriler[a].adres.Cadde;
                            dgvHeapAgaci.Rows[RowIndex].Cells[8].Value = musteriler[a].adres.Mahalle;
                            dgvHeapAgaci.Rows[RowIndex].Cells[9].Value = musteriler[a].adres.Sokak;
                        }
                    }

                    HashHead = HashHead.Next;
                }
            }
        }
    }
}
