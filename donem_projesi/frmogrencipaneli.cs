using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace donem_projesi
{
    public partial class frmogrencipaneli : Form
    {
        public frmogrencipaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        public string tc;
        public string id;
        bool mukerrer_talep;
        bool bekleyen_izin;
        DateTime tarih;
        public int kalan;
        public string yurtad;

        //TALEP
        string[] bolum = { "ÇALIŞMA ODASI", "YATAK ODASI", "LAVABO VE BANYO", "DİĞER" };
        string[] calısmaodasıesya = { "ÇALIŞMA MASASI", "SANDALYE", "PETEK", "PENCERE", "LAMBA", "PRİZ" };
        string[] yatakodasıesya = { "RANZA", "YATAK", "KOMODİN", "PETEK", "PENCERE", "LAMBA", "PRİZ" };
        string[] lavabobanyoesya = { "LAVABO","KLOZET", "DOLAP", "DUSAKABİN", "PETEK", "LAMBA", "PRİZ","KAPI" };
        string[] digeresya = { "DOLAP", "LAMBA", "BUZDOLABI","KAPI" };
        void mukerrertalep()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_ogrencisorun where odano='" + mskodano.Text + "'and sorunluesya='" + cmbesya.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                mukerrer_talep = false;
            }
            else
            {
                mukerrer_talep = true;
            }
        }
        void bekleyenizin()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_ogrenciyurtizin where ogrenciid=@p1 and kontrol=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskid.Text);
            komut.Parameters.AddWithValue("@p2", "onay bekleniyor");
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                bekleyen_izin = false;
            }
            else
            {
                bekleyen_izin = true;
            }
        }
        void izinlistele()
        {
            SqlCommand komut4 = new SqlCommand("select baslangicizin, bitisizin, kontrol from tbl_ogrenciyurtizin where ogrenciid='" + mskid.Text + "'", bgl.baglanti());
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter(komut4);
            da4.Fill(dt4);
            dataGridView2.DataSource = dt4;
            dataGridView2.RowHeadersWidth = 4;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmyurtetkinlikleri frmyetkinlik = new frmyurtetkinlikleri();
            frmyetkinlik.tc = metot.gettc();
            frmyetkinlik.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //bugünün tarihinden daha eski tarih kayit yapılmasını enegllemek için
                if (tarih == dateTimePicker1.Value || tarih <= dateTimePicker1.Value)
                {
                    //aynı gün için alınamaz
                    if (dateTimePicker1.Value.ToShortDateString() != dateTimePicker2.Value.ToShortDateString())
                    {
                        //ilk gün izin alınan son günden küçük olamalı
                        if (dateTimePicker1.Value <= dateTimePicker2.Value)
                        {
                            bekleyenizin();
                            if (bekleyen_izin == true)
                            {
                                DateTime baslangicizin = dateTimePicker1.Value;
                                DateTime bitisizin = dateTimePicker2.Value;
                                TimeSpan hesap = bitisizin - baslangicizin;
                                int alinan = Convert.ToInt16(hesap.Days); //kaç gün izin aldığı

                                if (Convert.ToInt16(txtkalanizin.Text) <= 30)
                                {
                                    if (alinan <= Convert.ToInt16(txtkalanizin.Text)) 
                                    {
                                        SqlCommand komut2 = new SqlCommand("insert into tbl_ogrenciyurtizin (ogrenciid,baslangicizin,bitisizin,kalanizin,onayizin,kontrol) values(@p1,@p2,@p3,@p4,@p5,@p6) ", bgl.baglanti());
                                        komut2.Parameters.AddWithValue("@p1", mskid.Text);
                                        komut2.Parameters.AddWithValue("@p2", dateTimePicker1.Value.ToString("yyyy.MM.dd"));
                                        komut2.Parameters.AddWithValue("@p3", dateTimePicker2.Value.ToString("yyyy.MM.dd"));
                                        komut2.Parameters.AddWithValue("@p4", txtkalanizin.Text);
                                        komut2.Parameters.AddWithValue("@p5", 0);
                                        komut2.Parameters.AddWithValue("@p6", "onay bekleniyor");
                                        komut2.ExecuteNonQuery();
                                        bgl.baglanti().Close();
                                        MessageBox.Show("İZİN KAYDI OLUŞTURULDU.ONAY BEKLENİYOR...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        izinlistele();
                                    }
                                    else
                                    {
                                        MessageBox.Show("İSTENEN GÜN KADAR İZİN HAKKI YOK.\nALINABİLECEK İZİN GÜNÜ SAYISI "+txtkalanizin.Text, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ALABİLECEĞİNİZ MAXİMUM İZİN SAYISINA ULAŞTINIZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("ONAY BEKLEYEN İZİN TALEBİ VAR İKEN İZİN TALEBİNDE BULUNULAMAZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("BAŞLANGIÇ TARİHİ BİTİŞ TARİHİNDEN GERİDE OLAMAZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("GÜN İÇERİSİNDE İZİN ALINAMAZ.\nGÜNLERİ KONTROL EDİN.", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("GEÇMİŞ TARİHTEN İZİN ALINAMAZ.", "UYARI ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select SUBSTRING(odemetarih,6,2) from tbl_yurtodeme where ogrencitc='" + msktc.Text +"' and odemetarih like '%"+ DateTime.Now.ToString("yyyy.MM.") + "%'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString()==DateTime.Now.ToString("MM"))
                {
                    MessageBox.Show("ÖDEMENİZ YAPILMIŞITR.\nTEKRAR ÖDEME YAPAMAZ...","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    frmogrenciodeme frmoodeme = new frmogrenciodeme();
                    frmoodeme.tc = metot.gettc();
                    frmoodeme.yurtad = yurtad;
                    frmoodeme.Show();
                    this.Hide();
                }
            }
            bgl.baglanti().Close();
        }
        private void frmogrencipaneli_Load(object sender, EventArgs e)
        {
            tarih = DateTime.Today;
            cmbbolum.Items.AddRange(bolum);
            metot.settc(tc);
            MessageBox.Show(" " + metot.gettc());
            string tcgir= metot.gettc();
            msktc.Text =tcgir;

            //mskid.Text=metot.gettc();

            SqlCommand komut1 = new SqlCommand("select ogrenciid, ogrenciad,ogrencisoyad,ogrencitc, ogrenciogretim, ogrenciodano,ogrenciyatakno,ogrencikınama,ogrencitoplamizin from tbl_ogrenci where ogrencitc=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",tcgir);
            SqlDataReader dr = komut1.ExecuteReader();
            while(dr.Read())
            {
                mskid.Text= dr[0].ToString();
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                txtogretim.Text = dr[4].ToString();
                mskodano.Text= dr[5].ToString();
                txtyatakno.Text= dr[6].ToString();
                txtkınamadurum.Text = dr[7].ToString();
                txtadsoyad.Text= dr[1].ToString()+" "+dr[2].ToString();
                txtkalanizin.Text = dr[8].ToString();
            }
            bgl.baglanti().Close();

            //izin
            SqlCommand komut2 = new SqlCommand("select kalanizin from tbl_ogrenciyurtizin where ogrenciid=@p1",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", mskid.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                txtkalanizin.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();
            izinlistele();

            //kaydolduğu etkinlikler
            SqlCommand komut3 = new SqlCommand("select etkinlikad from tbl_etkinlikkayit k1 join tbl_secilenetkinlik d1 on d1.etkinlikid = k1.etkinlikid where ogrenciid ='"+mskid.Text+"'",bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut3);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersWidth = 4;
            dataGridView1.ColumnHeadersVisible = false;

        }
        private void btntalep_Click(object sender, EventArgs e)
        {
            mukerrertalep();
            if (mukerrer_talep==true)
            {
                if (cmbbolum.SelectedIndex != -1)
                {
                    if (cmbesya.SelectedIndex != -1)
                    {
                        if (richTextBox1.Text != "")
                        {
                            SqlCommand komut = new SqlCommand("insert into tbl_ogrencisorun (odano,sorunlubolum,sorunluesya,sorun,durum)values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", mskodano.Text);
                            komut.Parameters.AddWithValue("@p2", cmbbolum.Text);
                            komut.Parameters.AddWithValue("@p3", cmbesya.Text);
                            komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
                            komut.Parameters.AddWithValue("@p5", 0);
                            komut.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            MessageBox.Show("TALEBİNİZ ALINMIŞTIR..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("TALEBİNİZİ KISA ŞEKİLDE AÇIKLAYIN..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("EŞYA SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("BÖLÜM SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("SEÇİLEN EŞYA İLE İLGİLİ TALEP BULUNMAKTA...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbbolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbesya.Items.Clear();
            switch (cmbbolum.SelectedIndex)
            {
                case 0:
                    {
                        cmbesya.Items.AddRange(calısmaodasıesya);
                    }; break;
                case 1:
                    {
                        cmbesya.Items.AddRange(yatakodasıesya);
                    }; break;
                case 2:
                    {
                        cmbesya.Items.AddRange(lavabobanyoesya);
                    }; break;
                case 3:
                    {
                        cmbesya.Items.AddRange(digeresya);
                    }; break;
            }
        }
    }
}
