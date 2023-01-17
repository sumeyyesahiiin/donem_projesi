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
    public partial class frmgüvenliknöbet : Form
    {
        public frmgüvenliknöbet()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        string odano;
        string esya;
        public string tc;
        void temizle()
        {
            txtesya.Text = "";
            txtbolum.Text = "";
            richTextBox2.Text = "";
        }
        void listele()
        {
            SqlCommand komut2 = new SqlCommand("select odano,sorunluesya from tbl_ogrencisorun where durum=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", 0);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut2);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bgl.baglanti().Close();
        }
        void guvenlikler()
        {
            SqlCommand komut = new SqlCommand("select guvenlikadsoyad,guvenliktel from tbl_guvenlik",bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmgüvenliknöbet_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlCommand komut1 = new SqlCommand("select guvenliktarih, guvenlikduyuru from tbl_guvenlikduyuru", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                ListViewItem duyuru = new ListViewItem(dr1["guvenliktarih"].ToString());
                duyuru.SubItems.Add(dr1["guvenlikduyuru"].ToString());
                listView1.Items.Add(duyuru);
            }

            bgl.baglanti().Close();
            metot.settc(tc);
            label9.Text = metot.gettc();

            SqlCommand komut2 = new SqlCommand("select guvenlikadsoyad,guvenliktel from tbl_guvenlik where guvenliktc=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", label9.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
               label2.Text = dr2[0].ToString();
               label10.Text = dr2[1].ToString();
            }

            listele();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbolum.Clear();
            txtesya.Clear();
            richTextBox2.Clear();

            odano = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            esya = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();


            SqlCommand komut = new SqlCommand("select sorunlubolum,sorunluesya, sorun from tbl_ogrencisorun where odano=@p1 and sorunluesya=@p2 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", odano);
            komut.Parameters.AddWithValue("@p2", esya);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtbolum.Text = dr[0].ToString();
                txtesya.Text = dr[1].ToString();
                richTextBox2.Text = dr[2].ToString();
            }
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int durum;
            if(checkBox1.Checked==true)
            {
                durum = 1;
            }
            else
            {
                durum = 0;
            }
            if (txtbolum.Text!="")
            {
                if (durum==1)
                {
                    //durumu güncellemek yerine kayıt silinedebilir bilgiler lazımolmayacak sor
                    SqlCommand komut = new SqlCommand("update tbl_ogrencisorun set durum='" + durum + "' where odano=@p1 and sorunluesya=@p2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", odano);
                    komut.Parameters.AddWithValue("@p2", txtesya.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("GÜNCELLENDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle(); 
                }
                else
                {
                    MessageBox.Show("SORUN ÇÖZÜLMESİ İÇİN BEKLETİLİYOR...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("TABLODAN ODA SEÇİN...","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
