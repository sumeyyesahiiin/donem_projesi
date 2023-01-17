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
    public partial class frmyoneticikayıt : Form
    {
        public frmyoneticikayıt()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();

        string[] yurtpersonel = { "Yurt Görevlisi", "Yurt Sorumlusu", "Müdür Yardımcısı", "Müdür", "Yurt İdari Sorumlusu" };
        string cinsiyet = "c";
        string medenih = "h";
        bool mukerrer1;
        bool mukerrer2;
        public string tc;
        void mukerrertc()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_yonetici where yoneticitc=@p1", bgl.baglanti());
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
            SqlCommand komut = new SqlCommand("select * from tbl_yonetici where yoneticitel=@p1", bgl.baglanti());
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
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_yonetici",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void temizle()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            msktc.Text = "";
            mskdtarihi.Text = "";
            msktel.Text = "";
            msktel.Text = "05";
            cmbunvan.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            txtmail1.Text = "";
            txtsifre.Text = "ŞİFRE";
            txtsifre.Enabled = false;
        }
        private void frmyoneticikayıt_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            cmbunvan.Items.AddRange(yurtpersonel);
            txtsifre.Enabled = false;

            listele();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            string tc = msktc.Text;
            string kontrol = "0";

            if (txtad.Text != "" && txtsoyad.Text != "" && cmbunvan.SelectedIndex != -1 && cinsiyet != "c" && medenih != "h" && txtmail1.Text != "")
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
                                SqlCommand komut = new SqlCommand("insert into tbl_yonetici (yoneticiad,yoneticisoyad,yoneticitc,yoneticidtarihi, yoneticitel, yoneticiunvan, yoneticicinsiyet,yoneticimedenih,yoneticimail,yoneticisifre)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", txtad.Text);
                                komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
                                komut.Parameters.AddWithValue("@p3", msktc.Text);
                                komut.Parameters.AddWithValue("@p4", mskdtarihi.Text);
                                komut.Parameters.AddWithValue("@p5", msktel.Text);
                                komut.Parameters.AddWithValue("@p6", cmbunvan.Text);
                                komut.Parameters.AddWithValue("@p7", cinsiyet);
                                komut.Parameters.AddWithValue("@p8", medenih);
                                komut.Parameters.AddWithValue("@p9", txtmail1.Text + txtmail2.Text);
                                komut.Parameters.AddWithValue("@p10", txtsifre.Text);
                                komut.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                MessageBox.Show("GÜVENLİK KAYDEDİLDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                listele();
                                temizle();
                            }
                            else
                            {
                                MessageBox.Show("EKLENMEK İSTENEN TELEFION NUMARASI ZATEN KAYITLI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("EKLENMEK İSTENEN TC ZATEN KAYITLI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked==true)
            {
                cinsiyet = "Kadın";
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //kaydedeerken char 5 olduğu için bir boşluk ekleyerek kaydediyor
            if (radioButton4.Checked == true)
            {
                cinsiyet = "Erkek";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                medenih = "Evli";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                medenih = "Bekar";
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtsifre.Text != "ŞİFRE")
            {
                txtsifre.Text = metot.sifreolustur(6);
                SqlCommand komut = new SqlCommand("update tbl_yonetici set yoneticiad=@p1,  yoneticisoyad=@p2, yoneticidtarihi=@p3, yoneticitel=@p4, yoneticiunvan=@p5,  yoneticicinsiyet=@p6,  yoneticimedenih=@p7,  yoneticisifre=@p8 where yoneticitc=@p9", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtad.Text);
                komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
                komut.Parameters.AddWithValue("@p3", mskdtarihi.Text);
                komut.Parameters.AddWithValue("@p4", msktel.Text);
                komut.Parameters.AddWithValue("@p5", cmbunvan.Text);
                komut.Parameters.AddWithValue("@p6", cinsiyet);
                komut.Parameters.AddWithValue("@p7", medenih);
                komut.Parameters.AddWithValue("@p8", txtsifre.Text);
                komut.Parameters.AddWithValue("@p9", msktc.Text);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtsoyad.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            msktc.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            mskdtarihi.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            msktel.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbunvan.Text= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cinsiyet= dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            medenih= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtmail1.Text= dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtsifre.Text= dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

            if(cinsiyet == "Kadın")
            {
                radioButton3.Checked = true;
            }
            else if(cinsiyet == "Erkek")
            {
                radioButton4.Checked = true;
            }

            if (medenih == "Evli ")
            {
                radioButton1.Checked = true;
            }
            else if(medenih == "Bekar")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {

            if (txtsifre.Text != "ŞİFRE")
            {
                SqlCommand komut2 = new SqlCommand("delete from tbl_yonetici where yoneticitc=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", msktc.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("GÜVENLİK SİLİNDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            else
            {
                MessageBox.Show("SİLİNECEK YÖNETİCİYİ TABLODAN SEÇİNİZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmyonetici frm = new frmyonetici();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
    }
}
