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
    public partial class frmogrenciduyuru : Form
    {
        public frmogrenciduyuru()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        DateTime tarih = DateTime.Now;
        metot_kullan metot = new metot_kullan();
        string[] secenek = { "TÜM ÖĞRENCİLER", "ÖĞRENCİ SEÇ" };
        string ogrenciid;
        public string tc;
        void eskiduyuru(string id)
        {
            bool kayit;

            SqlCommand komut1 = new SqlCommand("select * from tbl_ogrenciduyuru where ogrenciduyuruid=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", id);
            SqlDataReader dr1 = komut1.ExecuteReader();
            if (dr1.Read())
            {
                kayit = true;
            }
            else
            {
                kayit = false;
            }
            bgl.baglanti().Close();

            if (kayit == true)
            {
                SqlCommand komut2 = new SqlCommand("select ogrencitarih, ogrenciduyuru from tbl_ogrenciduyuru where ogrenciduyuruid=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", ogrenciid);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    ListViewItem duyuru = new ListViewItem(dr2["ogrencitarih"].ToString());
                    duyuru.SubItems.Add(dr2["ogrenciduyuru"].ToString());

                    listView1.Items.Add(duyuru);
                }
                bgl.baglanti().Close();
            }
            else
            {
                ListViewItem duyuru = new ListViewItem(" ");
                duyuru.SubItems.Add("öğrencinin duyurusu bulunmamaktadır..");

                listView1.Items.Add(duyuru);
            }
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ogrenciid,ogrenciad,ogrencisoyad from tbl_ogrenci", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmogrenciduyuru_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            label3.Text= tarih.ToShortDateString();
            label1.Enabled = false;
            txtadsoyad.Enabled = false;

            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogrenci frm = new frmogrenci();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select ogrenciid, ogrenciad, ogrencisoyad from tbl_ogrenci where ogrenciad like '"+txtara.Text+"%'", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource=dt;
            bgl.baglanti().Close();
        }

        private void btngonder_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (txtadsoyad.Text != "")
                {
                    SqlCommand komut = new SqlCommand("insert into tbl_ogrenciduyuru (ogrenciduyuruid, ogrenciduyuru, ogrencitarih)values(@p1,@p2,@p3)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1",ogrenciid);
                    komut.Parameters.AddWithValue("@p2", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@p3", label3.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("DUYURU GÖNDERİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    richTextBox1.Clear();
                    listView1.Items.Clear();
                    eskiduyuru(ogrenciid);
                }
                else
                {
                    MessageBox.Show("TABLODAN KİŞİYİ SEÇİNİZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("BOŞ DUYURU PAYLAŞILAMAZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listView1.Items.Clear();
            richTextBox1.Clear();
            txtadsoyad.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()+" "+dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); ;
            ogrenciid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            eskiduyuru(ogrenciid);
        }
    }
}
