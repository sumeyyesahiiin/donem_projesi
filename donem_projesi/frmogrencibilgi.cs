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
    public partial class frmogrencibilgi : Form
    {
        public frmogrencibilgi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();

        string[] onlisans = { "Basım ve Yayın Teknolojileri", "Bilgisayar Destekli Tasarım ve Animasyon", "Görsel İletişim", "İç Mekan Tasarımı", "Bankacılık ve Sigortacılık", "Grafik Tasarım", "Radyo ve Televizyon", "Lojistik", "Reklamcılık", "Pazarlama", "Biyokimya" };
        string[] lisans = { "Sınıf Öğretmenliği", "Almanca Öğretmenliğ", "İngiliz Dili ve Edebiyatı", "İktisat", "Maliye", "Psikoloji", "Sağlık Yönetimi", "Hukuk", "Yazılım Mühendisliği", "Yönetim Bilişim Sistemler", "Yapay Zeka Mühendisliği", "Diş Hekimliği", "Eczacılık" };
        string[] kan = { "O RH+", "O RH-", "A RH+", "A RH-", "B RH+", "B RH-", "AB RH+", "AB RH-" };
        
        string ogretim,kınama,ogrenimduzeyi;
        public string tc;
        int say;
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            msktc.Text = "";
            cmbkan.Text = "";
            mskdtarihi.Text = "";
            msktel.Text = "";
            rdb1ogrtm.Checked = false;
            rdb2ogrtm.Checked = false;
            cmbbolum.Text = "";
            rdb1ogrtm.Checked = false;
            rdb2ogrtm.Checked = false;
            cmbodano.Text = "";
            cmbyatakno.Text = "";
            kınama = "";
            rdbvar.Checked = false;
            rdbyok.Checked = false;
        }
        void listele()
        {
            SqlCommand komut = new SqlCommand("select ogrenciid, ogrenciad, ogrencisoyad, ogrencitc, ogrencikan, ogrencidtarihi, ogrencitel, ogrenciogrenimduzeyi, ogrencibolum, ogrenciogretim, ogrenciodano, ogrenciyatakno,ogrencikınama, ogrencitoplamizin from tbl_ogrenci", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        void yatakbilgisi()
        {
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
        }
        private void frmogrencibilgi_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            txtid.Enabled = false;
            cmbbolum.Enabled = false;
            listele();

            cmbkan.Items.AddRange(kan);

            SqlCommand komut = new SqlCommand("select odano from tbl_odalar order by odano",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbodano.Items.Add(dr[0].ToString());
            }
            bgl.baglanti().Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogrenci frm = new frmogrenci();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
       {
            SqlCommand komut = new SqlCommand("select ogrenciid, ogrenciad, ogrencisoyad, ogrencitc, ogrencikan, ogrencidtarihi, ogrencitel,ogrenciogrenimduzeyi, ogrencibolum, ogrenciogretim, ogrenciodano, ogrenciyatakno,ogrencikınama,ogrencitoplamizin from tbl_ogrenci where ogrenciad like'" + txtara.Text+"%'",bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnodeme_Click(object sender, EventArgs e)
        {
            frmodemedurumu frmdurum = new frmodemedurumu();
            frmdurum.Show();
            this.Hide();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtid.Text!="")
            {
                SqlCommand komut = new SqlCommand("delete from tbl_ogrenci where ogrenciid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("ÖĞRENCİ SİLİNDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                listele();
            }
            else
            {
                MessageBox.Show("SİLMEK İSTEDİĞİNİZ ÖĞRENCİYİ TABLODAN SEÇİNİZ...","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if(txtid.Text!="")
            {
                if (txtad.Text != "" && txtsoyad.Text != "" && cmbkan.Text!="" && cmbkan.Text!= "" && rdbtnonlisans.Checked == true || rdbtnlisans.Checked == true && cmbbolum.Text != "" && rdb1ogrtm.Checked == true || rdb2ogrtm.Checked == true && txtkalanizin.Text != "")
                {
                    string tc = metot.tckontrol(msktc.Text);
                    if (mskdtarihi.Text.Length == 10 && msktel.Text.Length == 15)
                    {
                        if (tc == "4")
                        {
                            SqlCommand komut = new SqlCommand("update tbl_ogrenci set ogrenciad=@p1, ogrencisoyad=@p2, ogrencitc=@p3, ogrencikan=@p4, ogrencidtarihi=@p5, ogrencitel=@p6, ogrenciogrenimduzeyi=@p7, ogrencibolum=@p8, ogrenciogretim=@p9, ogrenciodano=@p10, ogrenciyatakno=@p11, ogrencikınama=@p12, ogrencitoplamizin=@p13 where ogrenciid=@p14", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", txtad.Text);
                            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
                            komut.Parameters.AddWithValue("@p3", msktc.Text);
                            komut.Parameters.AddWithValue("@p4", cmbkan.Text);
                            komut.Parameters.AddWithValue("@p5", mskdtarihi.Text);
                            komut.Parameters.AddWithValue("@p6", msktel.Text);
                            komut.Parameters.AddWithValue("@p7", ogrenimduzeyi);
                            komut.Parameters.AddWithValue("@p8", cmbbolum.Text);
                            komut.Parameters.AddWithValue("@p9", ogretim);
                            komut.Parameters.AddWithValue("@p10", cmbodano.Text);
                            komut.Parameters.AddWithValue("@p11", cmbyatakno.Text);
                            komut.Parameters.AddWithValue("@p12", kınama);
                            komut.Parameters.AddWithValue("@p13", txtkalanizin.Text);
                            komut.Parameters.AddWithValue("@p14", txtid.Text);
                            komut.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            MessageBox.Show("ÖĞRENCİ KAYDI GÜNCELLENDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listele();
                            yatakbilgisi();
                        }
                        else
                        {
                            MessageBox.Show("TC KİMLİK NUMARASI HATALI.\nGÜNCELLENEMEDİ...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("EKSİK DOĞUM TARİHİ VEYA TELEFON NUMARASI...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("BOŞ ALAN BIRAKMAYINIZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("GÜNCELLEMEK İSTEDİĞİNİZ ÖĞRENCİYİ TABLODAN SEÇİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void rdbtnonlisans_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnonlisans.Checked==true)
            {
                ogrenimduzeyi = "önlisans";
                cmbbolum.Enabled = true;
                cmbbolum.Items.Clear();
                cmbbolum.Items.AddRange(onlisans);
            }
        }
        private void rdb1ogrtm_CheckedChanged(object sender, EventArgs e)
        {
            if(rdb1ogrtm.Checked==true)
            {
                ogretim = "1. ÖĞRETİM";
            }
        }
        private void rdb2ogrtm_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2ogrtm.Checked == true)
            {
                ogretim = "2. ÖĞRETİM";
            }
        }
        private void cmbodano_SelectedIndexChanged(object sender, EventArgs e)
        {
            yatakbilgisi();
        }
        private void rdbtnlisans_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnlisans.Checked == true)
            {
                ogrenimduzeyi = "lisans";
                cmbbolum.Enabled = true;
                cmbbolum.Items.Clear();
                cmbbolum.Items.AddRange(lisans);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            temizle();
            msktc.Text = "05";
            try
            {             
                txtid.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                msktc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cmbkan.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                mskdtarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                msktel.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                ogrenimduzeyi = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmbbolum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                ogretim= dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                cmbodano.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                cmbyatakno.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                kınama= dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtkalanizin.Text= dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();

                switch (ogrenimduzeyi)
                {
                    case "önlisans":
                        { rdbtnonlisans.Checked = true;}
                        break;
                    case "lisans":
                        { rdbtnlisans.Checked = true;}
                        break;
                }
                switch (ogretim)
                {
                    case "1. ÖĞRETİM":
                        { rdb1ogrtm.Checked = true; }break;
                    case "2. ÖĞRETİM":
                        { rdb2ogrtm.Checked = true; }break;
                }
                switch (kınama)
                {
                    case "var":
                        { rdbvar.Checked = true; }
                        break;
                    case "yok":
                        { rdbyok.Checked = true; }
                        break;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
    }
}
