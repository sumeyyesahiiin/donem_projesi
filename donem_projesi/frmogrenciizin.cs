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
    public partial class frmogrenciizin : Form
    {
        public frmogrenciizin()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        int izin;
        int kalanizin;
        int idizin;
        DateTime baslangic;
        DateTime bitis;
        TimeSpan hesap;
        TimeSpan guncelhesap;
        int guncelgun;
        string kontrol;
        public string tc;

        void tumunulistele()
        {
            DataTable dt = new DataTable();
            //ogrenciid, ogrenciad,ogrencisoyad, kalanizin, baslangicizin,bitisizin,onayizin
            SqlDataAdapter da = new SqlDataAdapter("Select y1.ogrenciid,ogrenciad ,ogrencisoyad,kalanizin,baslangicizin,bitisizin,kontrol from tbl_ogrenci o1 join tbl_ogrenciyurtizin y1 on o1.ogrenciid = y1.ogrenciid ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        void onaylananizin()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select y1.ogrenciid,ogrenciad ,ogrencisoyad,kalanizin,baslangicizin,bitisizin,kontrol from tbl_ogrenci o1 join tbl_ogrenciyurtizin y1 on o1.ogrenciid = y1.ogrenciid where onayizin='" + 1 + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        void onaybekle()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select y1.ogrenciid,ogrenciad ,ogrencisoyad,kalanizin,baslangicizin,bitisizin,kontrol from tbl_ogrenci o1 join tbl_ogrenciyurtizin y1 on o1.ogrenciid = y1.ogrenciid where onayizin='" + 0 + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void izinkayit()
        {
            DateTime baslangicizin = dateTimePicker1.Value;
            DateTime bitisizin = dateTimePicker2.Value;
            hesap = bitisizin - baslangicizin;
            int alinan = Convert.ToInt16(hesap.Days); //kaç gün izin aldığı
            kalanizin = izin - alinan;
            MessageBox.Show(kalanizin.ToString());
            if (alinan < izin)
            {
                SqlCommand komut = new SqlCommand("update tbl_ogrenciyurtizin set onayizin=@p1,kalanizin=@p2,kontrol=@p3 where ogrenciid=@p4", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", 1);
                komut.Parameters.AddWithValue("@p2", kalanizin);
                komut.Parameters.AddWithValue("@p3", "onaylandı");
                komut.Parameters.AddWithValue("@p4", idizin);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("İZİN ONAYLANDI..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand komut1 = new SqlCommand("update tbl_ogrenci set ogrencitoplamizin='" + kalanizin + "'where ogrenciid='" + idizin + "'", bgl.baglanti());
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                tumunulistele();
            }
            else
            {
                MessageBox.Show("İSTENEN GÜN KADAR İZİN HAKKI YOK...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmogrenciizin_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            tumunulistele();

            MessageBox.Show(dateTimePicker1.Value.ToString());
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtadsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value + " " + dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            mskgun.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value);

            izin = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            idizin = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            kontrol = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            baslangic = dateTimePicker1.Value;
            bitis = dateTimePicker2.Value;
        }

        private void btnizin_Click(object sender, EventArgs e)
        {
            if (txtadsoyad.Text != "" && mskgun.Text != "")
            {
                if (izin <= 0)
                {
                    MessageBox.Show("İZİN KULLANMA HAKKI BİTMİŞTİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkBox1.Enabled = false;
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        izinkayit();

                    }
                    else
                    {
                        MessageBox.Show("ONAY KUTUSUNU İŞARETLEYİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("BİLGİLER EKSİK. İŞLEM YAPILMAK İSTENEN KİŞİYİ TABLODAN SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogrenci frm = new frmogrenci();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }

        private void btntumizin_Click(object sender, EventArgs e)
        {
            tumunulistele();
        }
        private void btnonaylanan_Click(object sender, EventArgs e)
        {
            onaylananizin();
        }

        private void btnonayla_Click(object sender, EventArgs e)
        {
            onaybekle();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select y1.ogrenciid,ogrenciad ,ogrencisoyad,kalanizin,baslangicizin,bitisizin,kontrol from tbl_ogrenci o1 join tbl_ogrenciyurtizin y1 on o1.ogrenciid = y1.ogrenciid where ogrenciad like'" + textBox1.Text + "%'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            if (mskgun.Text != "")
            {
                if (dateTimePicker1.Value >= DateTime.Now)
                {
                    MessageBox.Show(dateTimePicker1.Value.ToString() + DateTime.Now.ToString());
                    SqlCommand komut = new SqlCommand("delete from tbl_yurtogrenciizin where ogrenciid='" + idizin + "'", bgl.baglanti());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("İZİN SİLİNDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("SEÇİLEN KİŞİ İÇİN GÜNCELLEME YAPABİLİRSİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("BİLGİLER EKSİK. İŞLEM YAPILMAK İSTENEN KİŞİYİ TABLODAN SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (mskgun.Text != "")
            {
                if (dateTimePicker1.Value != dateTimePicker2.Value)
                {
                    if (kontrol == "onaylandı")
                    {
                        hesap = bitis - baslangic;//eski alınan izin günü        
                        guncelhesap = dateTimePicker2.Value - dateTimePicker1.Value;//yeni izin gunu

                        if (baslangic <= dateTimePicker1.Value)//izin baslangıcından önceki günler için öğrenci izin almalı. baslangıç tarihi ileri alınabilir ama kayıttakinden geriye gidemez
                        {

                            if (hesap.Days > guncelhesap.Days)//ekle
                            {
                                guncelgun = Convert.ToInt32(hesap.Days - guncelhesap.Days);
                                kalanizin = Convert.ToInt16(mskgun.Text) + guncelgun;
                                SqlCommand komut = new SqlCommand("update tbl_ogrenciyurtizin set kalanizin=@p1,baslangicizin=@p2, bitisizin=@p3 where ogrenciid=@p4", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", kalanizin);
                                komut.Parameters.AddWithValue("@p2", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                                komut.Parameters.AddWithValue("@p3", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                                komut.Parameters.AddWithValue("@p4", idizin);
                                komut.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                MessageBox.Show("daha az izin günü");
                                SqlCommand komut1 = new SqlCommand("update tbl_ogrenci set ogrencitoplamizin='" + kalanizin + "'where ogrenciid='" + idizin + "'", bgl.baglanti());
                                komut1.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                MessageBox.Show("İZİN GÜNCELLENDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tumunulistele();
                                mskgun.Text = kalanizin.ToString();
                            }
                            else if (guncelhesap.Days > hesap.Days)//çıkar
                            {
                                guncelgun = Convert.ToInt32(guncelhesap.Days - hesap.Days);
                                kalanizin = Convert.ToInt16(mskgun.Text) - guncelgun;
                                SqlCommand komut = new SqlCommand("update tbl_ogrenciyurtizin set kalanizin=@p1,baslangicizin=@p2, bitisizin=@p3 where ogrenciid=@p4", bgl.baglanti());
                                komut.Parameters.AddWithValue("@p1", kalanizin);
                                komut.Parameters.AddWithValue("@p2", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                                komut.Parameters.AddWithValue("@p3", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                                komut.Parameters.AddWithValue("@p4", idizin);
                                komut.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                MessageBox.Show("daha fazla izin günü");

                                SqlCommand komut1 = new SqlCommand("update tbl_ogrenci set ogrencitoplamizin='" + kalanizin + "'where ogrenciid='" + idizin + "'", bgl.baglanti());
                                komut1.ExecuteNonQuery();
                                bgl.baglanti().Close();
                                MessageBox.Show("İZİN GÜNCELLENDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tumunulistele();
                                mskgun.Text = kalanizin.ToString();
                            }
                            else
                            {
                                MessageBox.Show("TARİH DEĞİŞİKLİĞİ YAPILMADI..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("izin BAŞLANGIÇ TARİHİNDEN ÖNCEKİ GÜNLER İÇİN ÖĞRENCİNİN İZİN KAYDI GEREKMEKTEDİR...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("GÜNCELLEME İÇİN ÖNCE İZİN ONAYLANMALI...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("BASLANGÇ VE BİTİŞ TARİHLERİ AYNI OLAMAZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("BİLGİLER EKSİK. İŞLEM YAPILMAK İSTENEN KİŞİYİ TABLODAN SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
