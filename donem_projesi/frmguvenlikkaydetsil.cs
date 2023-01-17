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
    public partial class frmguvenlikkaydetsil : Form
    {
        public frmguvenlikkaydetsil()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        string[] ogrenimdurumu = { "İlköğretim", "Ortaöğretim", "Lise", "Lisans", "Yüksek Lisans" };
        string cinsiyet = "c";
        string medenih = "h";
        bool mukerrer1;
        bool mukerrer2;
        public string tc;
        void temizle()
        {
            txtadsoyad.Clear();
            msktc.Clear();
            mskdtarihi.Clear();
            msktel.Text = "";
            cmbodurumu.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            txtsifre.Text = "ŞİFRE";
            txtsifre.Enabled = false;
            msktel.Text = "05";
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_guvenlik", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void mukerrertc()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_guvenlik where guvenliktc=@p1", bgl.baglanti());
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
            SqlCommand komut = new SqlCommand("select * from tbl_guvenlik where guvenliktel=@p1", bgl.baglanti());
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
        private void btnekle_Click(object sender, EventArgs e)
        {
            string tc = msktc.Text;
            string kontrol = "0";

            if (txtadsoyad.Text != "" && cmbodurumu.SelectedIndex != -1 && cinsiyet != "c" && medenih != "h")
            {
                if (mskdtarihi.Text.Length == 10 && msktel.Text.Length == 15)
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
                        mukerrertc();
                        mukerrertel();
                        if (mukerrer1 == true)
                        {
                            if (mukerrer2 == true)
                            {
                                txtsifre.Enabled = true;
                                txtsifre.Text = metot.sifreolustur(6);

                                SqlCommand komut = new SqlCommand("insert into tbl_guvenlik (guvenlikadsoyad,guvenliksifre, guvenliktc, guvenlikdtarihi, guvenliktel, guvenlikodurumu, guvenlikcinsiyet, guvenlikmedenih) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", txtadsoyad.Text);
                                komut.Parameters.AddWithValue("@p2", txtsifre.Text);
                                komut.Parameters.AddWithValue("@p3", msktc.Text);
                                komut.Parameters.AddWithValue("@p4", mskdtarihi.Text);
                                komut.Parameters.AddWithValue("@p5", msktel.Text);
                                komut.Parameters.AddWithValue("@p6", cmbodurumu.SelectedItem);
                                komut.Parameters.AddWithValue("@p7", cinsiyet);
                                komut.Parameters.AddWithValue("@p8", medenih);
                                komut.ExecuteNonQuery();
                                bgl.baglanti();
                                MessageBox.Show("GÜVENLİK KAYDEDİLDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                listele();
                                temizle();
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
                    MessageBox.Show("EKSİK BİLGİLERİ DOLDURUNUZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("BOŞ ALAN BIRAKMAYINIZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmguvenlikkayıt_Load_1(object sender, EventArgs e)
        {
            metot.settc(tc);
            cmbodurumu.Items.AddRange(ogrenimdurumu);
            txtsifre.Enabled = false;

            listele();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cinsiyet = "Kadın";
            }
        }       
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                cinsiyet = "Erkek";
            }
        }    
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked==true)
            {
                medenih = "Evli";
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                medenih = "Bekar";
            }
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            if(txtsifre.Text != "ŞİFRE")
            {
                SqlCommand komut2 = new SqlCommand("delete from tbl_guvenlik where guvenliktc=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", msktc.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("GÜVENLİK SİLİNDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            else
            {
                MessageBox.Show("SİLİNECEK PERSONELİ TABLODAN SEÇİNİZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtadsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            msktc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            mskdtarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            msktel.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbodurumu.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            medenih= dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            switch (medenih)
            {
                //SQLE KAYDEDERKEN CHAR(5) OLDUĞU İÇİN BİR BOŞLUK BIRAKIYOR KENDİ "Evli " OLARAK KAYDEDİYOR
                case "Evli ":
                    {
                        radioButton3.Checked = true;
                    }
                    break;
                case "Bekar":
                    {
                        radioButton4.Checked = true;
                    }break;
            }
            if (cinsiyet == "Kadın")
            {
                radioButton1.Checked = true;
            }
            else if (cinsiyet == "Erkek")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtsifre.Text != "ŞİFRE")
            {
                txtsifre.Text = metot.sifreolustur(6);
                SqlCommand komut = new SqlCommand("update tbl_guvenlik set guvenlikadsoyad=@p1, guvenliksifre=@p2, guvenlikdtarihi=@p3, guvenliktel=@p4, guvenlikodurumu=@p5, guvenlikcinsiyet=@p6, guvenlikmedenih=@p7 where guvenliktc=@p8", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1",txtadsoyad.Text);
                komut.Parameters.AddWithValue("@p2",txtsifre.Text);
                komut.Parameters.AddWithValue("@p3",mskdtarihi.Text);
                komut.Parameters.AddWithValue("@p4",msktel.Text);
                komut.Parameters.AddWithValue("@p5",cmbodurumu.Text);
                komut.Parameters.AddWithValue("@p6",cinsiyet);
                komut.Parameters.AddWithValue("@p7",medenih);
                komut.Parameters.AddWithValue("@p8", msktc.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                temizle();
                listele();
                MessageBox.Show("GÜVENLİK GÜNCELLENDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("GÜNCELLENECEK PERSONELİ TABLODAN SEÇİNİZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmguvenlikplanı frm = new frmguvenlikplanı();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
    }
}
