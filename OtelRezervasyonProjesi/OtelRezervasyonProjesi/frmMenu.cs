using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public partial class frmMenu : Form
    {
        public static OtelIslemleri Islemler = new OtelIslemleri();
        
        public static LinkedListIslemleri listIslemleri = new LinkedListIslemleri();
        public void GirisFormuAc()
        {
            frmGirisYap GirisYap = new frmGirisYap();

            GirisYap.MdiParent = this;

            GirisYap.Show();
        }

        public void BaslangicDegerleriOku()
        {
            Oteller Root = new Oteller();
            Root.otel.OtelAdi = "A";
            Root.otel.adres.Il = "Adana";

            Oteller tempotel = new Oteller();
            tempotel.otel.OtelAdi = "C";
            tempotel.otel.adres.Il = "Çanakkale";

            Oteller tempotel2 = new Oteller();
            tempotel2.otel.OtelAdi = "B";
            tempotel2.otel.adres.Il = "Malatya";

            Oteller tempotel3 = new Oteller();
            tempotel3.otel.OtelAdi = "E";
            tempotel3.otel.adres.Il = "Edirne";

            Oteller tempotel4 = new Oteller();
            tempotel4.otel.OtelAdi = "F";
            tempotel4.otel.adres.Il = "Mardin";
            
            Oteller tempotel5 = new Oteller();
            tempotel5.otel.OtelAdi = "H";
            tempotel5.otel.adres.Il = "Eskişehir";

            Oda oda = new Oda();
            oda.TelefonNumarasi = 5345343434;
            oda.ManzaraBilgisi = "Deniz Manzaralı";
            oda.KisiSayisi = 4;
            oda.RezervasyonDurumu = false;
            oda.Fiyat = 3000;

            Oda oda2 = new Oda();
            oda2.TelefonNumarasi = 5531234545;
            oda2.ManzaraBilgisi = "Güneş Manzaralı";
            oda2.KisiSayisi = 2;
            oda2.RezervasyonDurumu = false;
            oda2.Fiyat = 1500;

            Personel personel = new Personel();
            personel.Ad = "AHMET";
            personel.Departman = "Muhasebe";
            personel.TCkimlikNumarasi = 111111;

            Personel personel2 = new Personel();
            personel2.Ad = "HAKAN";
            personel2.Departman = "Muhasebe";
            personel2.TCkimlikNumarasi = 123456;

            Personel personel3 = new Personel();
            personel3.Ad = "BERKE";
            personel3.Departman = "Güvenlik";
            personel3.TCkimlikNumarasi = 222222;

            Personel personel4 = new Personel();
            personel4.Ad = "ABUZER";
            personel4.Departman = "Temizlik";
            personel4.TCkimlikNumarasi = 333333;

            Yorum yorum1 = new Yorum();
            yorum1.yorum = "DENEME";
            yorum1.Puan = 10;

            Yorum yorum2 = new Yorum();
            yorum2.yorum = "DENEME2";
            yorum2.Puan = 15;

            Yorum yorum3 = new Yorum();
            yorum3.yorum = "DENEME3";
            yorum3.Puan = 7;

            Islemler.OtelEkle(Root);
            Islemler.OtelEkle(tempotel);
            Islemler.OtelEkle(tempotel2);
            Islemler.OtelEkle(tempotel3);
            Islemler.OtelEkle(tempotel4);
            Islemler.OtelEkle(tempotel5);

            listIslemleri.OdaEklemeIslemi(Root, oda);
            listIslemleri.OdaEklemeIslemi(Root, oda2);

            listIslemleri.PersonelEklemeIslemi(Root, personel);
            listIslemleri.PersonelEklemeIslemi(Root, personel2);
            listIslemleri.PersonelEklemeIslemi(Root, personel3);
            listIslemleri.PersonelEklemeIslemi(Root, personel4);

            listIslemleri.YorumEkle(Root, yorum1);
            listIslemleri.YorumEkle(Root, yorum2);
            listIslemleri.YorumEkle(Root, yorum3);
        }

        public frmMenu()
        {
            InitializeComponent();

            BaslangicDegerleriOku();
            
        }

        private void GirisYap_Click(object sender, EventArgs e)
        {
            GirisFormuAc();
        }
    }
}
