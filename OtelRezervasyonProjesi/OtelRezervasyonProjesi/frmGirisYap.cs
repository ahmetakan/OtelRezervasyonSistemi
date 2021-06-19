using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public partial class frmGirisYap : Form
    {
        public static Kullanici Admin = new Kullanici();
        public static Kullanici Musteri = new Kullanici();
        public void KullaniciGirisi(string kullaniciadi, string sifre)
        {
            

            Admin.KullaniciAdi = "admin";
            Admin.Sifre = "123456";
            Admin.Musteri.Ad = "Ahmet";
            Admin.Musteri.Soyad = "Akan";
            Admin.Musteri.TCkimlikNumarasi = 11111111111;
            Admin.Musteri.Eposta = "akanahm@hotmail.com";
            Admin.Musteri.adres.Il = "Adana";
            Admin.Musteri.adres.Ilce = "Seyhan";
            Admin.Musteri.adres.Cadde = "Eminağa Caddesi";
            Admin.Musteri.adres.Mahalle = "Barbaros Mahallesi";
            Admin.Musteri.adres.Sokak = "17047";
            
            Musteri.KullaniciAdi = "musteri";
            Musteri.Sifre = "123456";
            Musteri.Musteri.Ad = "Ahmet";
            Musteri.Musteri.Soyad = "Akan";
            Musteri.Musteri.TCkimlikNumarasi = 11111111111;
            Musteri.Musteri.Eposta = "akanahm@hotmail.com";
            Musteri.Musteri.adres.Il = "Adana";
            Musteri.Musteri.adres.Ilce = "Seyhan";
            Musteri.Musteri.adres.Cadde = "Eminağa Caddesi";
            Musteri.Musteri.adres.Mahalle = "Barbaros Mahallesi";
            Musteri.Musteri.adres.Sokak = "17047";

            Kullanici[] Kullanicilar = new Kullanici[2];

            Kullanicilar[0] = Musteri;
            Kullanicilar[1] = Admin;

            int kontrol = 0;

            for (int i = 0; i < Kullanicilar.Length; i++)
            {
                if (kullaniciadi == Kullanicilar[i].KullaniciAdi 
                    && sifre == Kullanicilar[i].Sifre)
                {
                    if (i == 0)
                    {
                        frmMusteri musteri = new frmMusteri();

                        musteri.MdiParent = this.MdiParent;

                        musteri.Show();
                        this.Close();

                        kontrol++;
                    }
                    else
                    {
                        frmAdmin admin = new frmAdmin();

                        admin.MdiParent = this.MdiParent;

                        admin.Show();
                        this.Close();

                        kontrol++;
                    }
                }
            }

            if (kontrol == 0)
            {
                MessageBox.Show("Sistemde böyle bir kullanıcı bulunamadı."
                                + Environment.NewLine + 
                                "Lütfen kontrol edip tekrar deneyiniz.", 
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmGirisYap()
        {
            InitializeComponent();

            
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            KullaniciGirisi(txtKullaniciAdi.Text, txtSifre.Text);
        }
    }
}
