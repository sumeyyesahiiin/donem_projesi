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
    public partial class frmogrencikayıt : Form
    {
        public frmogrencikayıt()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        string kınama="0";
        string[] onlisans = { "Basım ve Yayın Teknolojileri", "Bilgisayar Destekli Tasarım ve Animasyon", "Görsel İletişim", "İç Mekan Tasarımı", "Bankacılık ve Sigortacılık", "Grafik Tasarım", "Radyo ve Televizyon", "Lojistik", "Reklamcılık", "Pazarlama", "Biyokimya" };
        string[] lisans = { "Sınıf Öğretmenliği", "Almanca Öğretmenliğ", "İngiliz Dili ve Edebiyatı", "İktisat", "Maliye", "Psikoloji", "Sağlık Yönetimi", "Hukuk", "Yazılım Mühendisliği", "Yönetim Bilişim Sistemler", "Yapay Zeka Mühendisliği", "Diş Hekimliği", "Eczacılık" };
        string ogrenimduzeyi;
        bool mukerrer1, mukerrer2,mukerrer3;
        public string tc;
        int say;
        void mukerrertc()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_ogrenci where ogrencitc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                mukerrer1 = false;
            }
            else
            {
                mukerrer1 = true;
            }
            bgl.baglanti().Close();
        }
        void mukerrertel()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_ogrenci where ogrencitel=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktel.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                mukerrer2 = false;
            }
            else
            {
                mukerrer2 = true;
            }
            bgl.baglanti().Close();
        }
        void mukerreroda()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_ogrenci where ogrenciodano=@p1 and ogrenciyatakno=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbodano.Text);
            komut.Parameters.AddWithValue("@p2", cmbyatakno.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                mukerrer3 = false;
            }
            else
            {
                mukerrer3 = true;
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            msktc.Text = "";
            cmbkan.SelectedIndex = -1;
            mskdtraihi.Text = "";
            msktel.Text = "";
            rdbtnonlisans.Checked = false;
            rdbtnlisans.Checked = false;
            cmbbolum.SelectedIndex = -1;
            cmbbolum.Text ="";
            rdbtn1ogretim.Checked = false;
            rdbtn2ogretim.Checked = false;
            numkatsayisi.Value = 0;
            cmbodano.SelectedIndex = -1;
            cmbodano.Text = "";
            cmbyatakno.SelectedIndex = -1;
            cmbyatakno.Text = "";
            rdbtnvar.Checked = false;
            rdbtnyok.Checked = false;
            txtsifre.Text = "";
        }
        void listele()
        {
            SqlCommand komut1 = new SqlCommand("select ogrenciodano,ogrenciyatakno from tbl_ogrenci order by ogrenciodano", bgl.baglanti());
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            bgl.baglanti().Close();
        }
        private void frmogrencikayıt_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            string[] kan = { "O RH+", "O RH-", "A RH+", "A RH-", "B RH+", "B RH-", "AB RH+", "AB RH-" };
            cmbkan.Items.AddRange(kan);

            lblogretim.Visible = false;
            cmbbolum.Enabled = false;

            numkatsayisi.Minimum = 0;
            numkatsayisi.Maximum =9;

            listele();
        }
        private void rdbtnonlisans_CheckedChanged(object sender, EventArgs e)
        {
            cmbbolum.Items.Clear();
            cmbbolum.Enabled = true;
            ogrenimduzeyi = "önlisans";
            cmbbolum.Items.AddRange(onlisans);
        }
        private void rdbtnlisans_CheckedChanged(object sender, EventArgs e)
        {
            cmbbolum.Items.Clear();
            cmbbolum.Enabled = true;
            ogrenimduzeyi = "lisans";
            cmbbolum.Items.AddRange(lisans);
        }
        private void rdbtn1ogretim_CheckedChanged(object sender, EventArgs e)
        {
            lblogretim.Text = rdbtn1ogretim.Text;
        }

        private void rdbtn2ogretim_CheckedChanged(object sender, EventArgs e)
        {
            lblogretim.Text = rdbtn2ogretim.Text;
        }
        private void numkatsayisi_ValueChanged(object sender, EventArgs e)
        {
            cmbodano.Items.Clear();
            SqlCommand komut = new SqlCommand("select odano from tbl_odalar where katsayisi=@p1 order by odano", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", numkatsayisi.Value);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbodano.Items.Add(dr[0].ToString());
            }
            bgl.baglanti().Close();

        }
        private void cmboda_Click(object sender, EventArgs e)
        {
            if(numkatsayisi.Value==0)
            {
                MessageBox.Show("KAT SAYISI SEÇİN...",  "UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else 
            {
                cmbodano.Items.Clear();
                SqlCommand komut = new SqlCommand("select odano from tbl_odalar where katsayisi=@p1 order by odano", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", numkatsayisi.Value);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    cmbodano.Items.Add(dr[0].ToString());
                }
                bgl.baglanti().Close();
            }
        }
        private void cmbyatakno_Click(object sender, EventArgs e)
        {
            if (cmbodano.SelectedIndex==-1)
            {
                MessageBox.Show("ODA NUMARASI SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            string tc = msktc.Text;
            string kontrol = "0";

            mukerrertc();
            mukerrertel();
            mukerreroda();

            if (txtad.Text != "" && txtsoyad.Text != "" && cmbkan.SelectedIndex != -1 && cmbbolum.SelectedIndex != -1 && lblogretim.Text != "" && numkatsayisi.Value != 0 && cmbodano.SelectedIndex != -1 && cmbyatakno.SelectedIndex != -1 && kınama != "0")
            {
                if (mskdtraihi.Text.Length == 10 && msktel.Text.Length == 15)
                {
                    if (tc.Length == 11)
                    {
                        kontrol = "1";

                        if (tc.Substring(0, 1) != "0")
                        {
                            kontrol = "2";
                            if (metot.mod10_10(tc) == tc.Substring(9, 1))
                            {
                                kontrol = "3";

                                if (metot.mod10_11(tc) == tc.Substring(10, 1))
                                {
                                    kontrol = "4";
                                }
                                else if (kontrol == "3")
                                {
                                    MessageBox.Show("HATALI TC KİMLİK NUMARASI. TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if (kontrol == "2")
                            {
                                MessageBox.Show("HATALI TC KİMLİK NUMARASI. TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (kontrol == "1")
                        {
                            MessageBox.Show("TC KİMLİK NUMARASININ ILK KARAKTERİ 0 OLAMAZ. TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (kontrol == "0")
                    {
                        MessageBox.Show("TC KİMLİK NUMARASI EKSİK TEKRAR DENEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (kontrol == "4")
                    {
                        if (mukerrer1 == true)
                        {
                            if (mukerrer2 == true)
                            {
                                if (mukerrer3 == true)
                                {
                                    label14.Enabled = true;
                                    txtsifre.Text = metot.sifreolustur(6);

                                    SqlCommand komut = new SqlCommand("insert into tbl_ogrenci(ogrenciad,ogrencisoyad,ogrencitc,ogrencikan,ogrencisifre,ogrencidtarihi,ogrencitel,ogrenciogrenimduzeyi,ogrencibolum,ogrenciogretim,ogrenciodano,ogrenciyatakno,ogrencikınama,ogrencitoplamizin)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)", bgl.baglanti());
                                    komut.Parameters.AddWithValue("@p1", txtad.Text);
                                    komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
                                    komut.Parameters.AddWithValue("@p3", msktc.Text);
                                    komut.Parameters.AddWithValue("@p4", cmbkan.Text);
                                    komut.Parameters.AddWithValue("@p5", txtsifre.Text);
                                    komut.Parameters.AddWithValue("@p6", mskdtraihi.Text);
                                    komut.Parameters.AddWithValue("@p7", msktel.Text);
                                    komut.Parameters.AddWithValue("@p8", ogrenimduzeyi);
                                    komut.Parameters.AddWithValue("@p9", cmbbolum.Text);
                                    komut.Parameters.AddWithValue("@p10", lblogretim.Text);
                                    komut.Parameters.AddWithValue("@p11", cmbodano.Text);
                                    komut.Parameters.AddWithValue("@p12", cmbyatakno.Text);
                                    komut.Parameters.AddWithValue("@p13", kınama);
                                    komut.Parameters.AddWithValue("@p14", numerictplizingun.Value);
                                    komut.ExecuteNonQuery();
                                    bgl.baglanti().Close();
                                    MessageBox.Show("ÖĞRENCİ KAYDEDİLDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    temizle();
                                    msktel.Text = "05";
                                    listele();
                                }
                                else
                                {
                                    MessageBox.Show("ODADAKİ SEÇİLEN YATAK DOLU..\nBASKA YATAK NUMARASI İÇİN KONTROL EDİN..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("EKLENMEK İSTENEN TELEFON NUMARASI ZATEN KAYITLI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("EKLENMEK İSTENEN TC ZATEN KAYITLI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("EKSİK BİLGİLERİ DOLDURNUZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("BOŞ ALAN BIRAKMAYINIZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogrenci frm = new frmogrenci();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
        private void cmboda_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlCommand komut = new SqlCommand("select ogrenciodano,ogrenciyatakno from tbl_ogrenci where ogrenciodano=@p1", bgl.baglanti());
            //komut.Parameters.AddWithValue("@p1", cmbodano.Text);
            //DataTable dt = new DataTable();
            //SqlDataAdapter da1 = new SqlDataAdapter(komut);
            //da1.Fill(dt);
            //dataGridView2.DataSource = dt;
            //bgl.baglanti().Close();

            cmbyatakno.Items.Clear();
            SqlCommand komut1 = new SqlCommand("select kisisayisi from tbl_odalar where odano='" + cmbodano.Text + "'", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                say = Convert.ToInt16(dr1[0]);
            }
            bgl.baglanti().Close();

            for (int i = 1; i <= say; i++)
            {
                SqlCommand komut2 = new SqlCommand("select * from tbl_ogrenci where ogrenciodano='" + cmbodano.Text + "' and ogrenciyatakno='" + i + "'", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                if (dr2.HasRows == false)
                {
                    cmbyatakno.Items.Add(i);
                }
            }
            bgl.baglanti().Close();

            //odanumarasının başındaki rakama göre oda numarası göstermek için
            SqlCommand komut3 = new SqlCommand("select ogrenciodano,ogrenciyatakno from tbl_ogrenci where ogrenciodano like'"+ cmbodano.Text.Substring(0, 1) + "%'order by ogrenciodano", bgl.baglanti());
            MessageBox.Show(cmbodano.Text.Substring(0, 1));
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut3);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bgl.baglanti().Close();
        }
        private void rdbtnvar_CheckedChanged(object sender, EventArgs e)
        {
            kınama = "var";
        }

        private void rdbtnyok_CheckedChanged(object sender, EventArgs e)
        {
            kınama = "yok"
;        }
    }
}
