using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OtelRezervasyonProjesi
{
    public class LinkedListIslemleri : LinkedListADT
    {
        public override Oteller OdaEklemeIslemi(Oteller otel, Oda oda)
        {
            if (otel.oda == null)
            {
                otel.oda = oda;
                otel.otel.OdaSayisi++;
            }

            else
            {
                OdaHead = otel.oda;

                while (OdaHead.NextOda != null)
                {
                    OdaHead = OdaHead.NextOda;
                }

                OdaHead.NextOda = oda;
                otel.otel.OdaSayisi++;
            }

            return frmMenu.Islemler._Root;
        }

        public override Oteller PersonelEklemeIslemi(Oteller otel, Personel personel)
        {
            if (otel.personel == null)
            {
                otel.personel = personel;
            }

            else
            {
                PersonelHead = otel.personel;

                while (PersonelHead.NextPersonel != null)
                {
                    PersonelHead = PersonelHead.NextPersonel;
                }

                PersonelHead.NextPersonel = personel;
            }

            return otel;
        }

        public void PersonelBilgisiGuncelle(string OtelAdi, long PersonelTCkimlikNo,
                                            string PersonelAdi, string PersonelSoyadi,
                                            long PersonelTelefonNo, string Eposta,
                                            string Il, string Ilce, string Cadde,
                                            string Mahalle, string Sokak,
                                            string Departman, string Pozisyon)
        {

            PersonelBilgisiGuncellemeIslemi(frmMenu.Islemler.OtelBulucu(OtelAdi),
                                            PersonelTCkimlikNo, PersonelAdi,
                                            PersonelSoyadi, PersonelTelefonNo,
                                            Eposta, Il, Ilce, Cadde, Mahalle,
                                            Sokak, Departman, Pozisyon);


        }

        protected override Oteller PersonelBilgisiGuncellemeIslemi(Oteller otel, long PersonelTCkimlikNo,
                                                                string PersonelAdi, string PersonelSoyadi,
                                                                long PersonelTelefonNo, string Eposta,
                                                                string Il, string Ilce, string Cadde,
                                                                string Mahalle, string Sokak,
                                                                string Departman, string Pozisyon)
        {
            if (otel.personel == null)
            {
                System.Windows.Forms.MessageBox.Show("Sistemde herhangi bir personel bulunmamaktadır.");
            }

            else
            {
                PersonelHead = otel.personel;

                while (PersonelHead.TCkimlikNumarasi != PersonelTCkimlikNo)
                {
                    PersonelHead = PersonelHead.NextPersonel;
                }


                PersonelHead.Ad = PersonelAdi;
                PersonelHead.Soyad = PersonelSoyadi;
                PersonelHead.TelefonNumarasi = PersonelTelefonNo;
                PersonelHead.Eposta = Eposta;
                PersonelHead.adres.Il = Il;
                PersonelHead.adres.Ilce = Ilce;
                PersonelHead.adres.Cadde = Cadde;
                PersonelHead.adres.Mahalle = Mahalle;
                PersonelHead.adres.Sokak = Sokak;
                PersonelHead.Departman = Departman;
                PersonelHead.Pozisyon = Pozisyon;
            }

            MessageBox.Show("Personel bilgisi güncelleme " + Environment.NewLine +
                            "işlemi başarıyla gerçekleştirildi.", "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            return otel;
        }

        public int RowIndex2 = -1;

        public void PersonelListele(string OtelAdi, DataGridView dgv)
        {
            dgv.Rows.Clear();

            RowIndex2 = -1;

            PersonelListelemeIslemi(frmMenu.Islemler.OtelBulucu(OtelAdi), dgv);

            dgv.Refresh();
        }

        protected override void PersonelListelemeIslemi(Oteller Otel, DataGridView dgv)
        {
            if (Otel.personel == null)
            {
                return;
            }

            PersonelHead = Otel.personel;

            while (PersonelHead != null)
            {
                dgv.Rows.Add();

                dgv.Rows[++RowIndex2].Cells[0].Value = PersonelHead.Ad;
                dgv.Rows[RowIndex2].Cells[1].Value = PersonelHead.Soyad;
                dgv.Rows[RowIndex2].Cells[2].Value = PersonelHead.TCkimlikNumarasi;
                dgv.Rows[RowIndex2].Cells[3].Value = PersonelHead.TelefonNumarasi;
                dgv.Rows[RowIndex2].Cells[4].Value = PersonelHead.Eposta;
                dgv.Rows[RowIndex2].Cells[5].Value = PersonelHead.adres.Il;
                dgv.Rows[RowIndex2].Cells[6].Value = PersonelHead.adres.Ilce;
                dgv.Rows[RowIndex2].Cells[7].Value = PersonelHead.adres.Cadde;
                dgv.Rows[RowIndex2].Cells[8].Value = PersonelHead.adres.Mahalle;
                dgv.Rows[RowIndex2].Cells[9].Value = PersonelHead.adres.Sokak;
                dgv.Rows[RowIndex2].Cells[10].Value = PersonelHead.Departman;
                dgv.Rows[RowIndex2].Cells[11].Value = PersonelHead.Pozisyon;

                PersonelHead = PersonelHead.NextPersonel;
            }
        }

        public override Oteller YorumEkle(Oteller otel, Yorum yorum)
        {
            int ToplamPuan = 0;
            int PuanlamaSize = 0;

            if (otel.yorum == null)
            {
                otel.yorum = yorum;

                if (yorum.Puan > 0)
                {
                    PuanlamaSize++;
                    ToplamPuan += yorum.Puan;
                }
            }

            else
            {
                YorumHead = otel.yorum;

                if (YorumHead.Puan > 0)
                {
                    PuanlamaSize++;
                    ToplamPuan += YorumHead.Puan;
                }

                while (YorumHead.NextYorum != null)
                {
                    YorumHead = YorumHead.NextYorum;

                    if (YorumHead.Puan > 0)
                    {
                        PuanlamaSize++;
                        ToplamPuan += YorumHead.Puan;
                    }
                }

                YorumHead.NextYorum = yorum;

                if (yorum.Puan > 0)
                {
                    PuanlamaSize++;
                    ToplamPuan += yorum.Puan;
                }
            }

            otel.otel.OtelPuani = ToplamPuan / PuanlamaSize;

            return otel;
        }

        
        public void OdaListele(string OtelAdi, DataGridView dgv)
        {
            dgv.Rows.Clear();

            RowIndex2 = -1;

            OdaListelemeIslemi(frmMenu.Islemler.OtelBulucu(OtelAdi), dgv);

            dgv.Refresh();
        }

        protected override void OdaListelemeIslemi(Oteller Otel, DataGridView dgv)
        {
            if (Otel.oda == null)
            {
                return;
            }

            OdaHead = Otel.oda;

            while (OdaHead != null)
            {
                dgv.Rows.Add();

                dgv.Rows[++RowIndex2].Cells[0].Value = OdaHead.OdaNumarasi;
                dgv.Rows[RowIndex2].Cells[1].Value = OdaHead.TelefonNumarasi;
                dgv.Rows[RowIndex2].Cells[2].Value = OdaHead.KisiSayisi;
                dgv.Rows[RowIndex2].Cells[3].Value = OdaHead.ManzaraBilgisi;
                dgv.Rows[RowIndex2].Cells[4].Value = OdaHead.RezervasyonDurumu;
                dgv.Rows[RowIndex2].Cells[5].Value = OdaHead.Fiyat;
                
                OdaHead = OdaHead.NextOda;
            }
        }

        public void PersonelSil(string OtelAdi, long TCkimlikNo)
        {
            PersonelSilmeIslemi(frmMenu.Islemler.OtelBulucu(OtelAdi), TCkimlikNo);
        }

        protected override Oteller PersonelSilmeIslemi(Oteller otel, long PersonelTCkimlikNo)
        {
            PersonelHead = otel.personel;

            if (PersonelHead.TCkimlikNumarasi == PersonelTCkimlikNo)
            {
                otel.personel = PersonelHead.NextPersonel;
            }

            else
            {
                Personel temp1 = PersonelHead;
                Personel temp2 = new Personel();

                while (temp1.NextPersonel.TCkimlikNumarasi != PersonelTCkimlikNo)
                {
                    temp1 = temp1.NextPersonel;
                }

                temp2 = temp1.NextPersonel;

                temp1.NextPersonel = temp2.NextPersonel;

                temp2 = null;

                otel.personel = PersonelHead;
            }

            MessageBox.Show("Personel silme işlemi" + Environment.NewLine + 
                            "başarıyla gerçekleştirildi.", "Bilgi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            return otel;
        }
    }
}
