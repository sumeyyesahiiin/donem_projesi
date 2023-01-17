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
    public partial class frmyurtetkinlikleri : Form
    {
        public frmyurtetkinlikleri()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        public string tc;
        public string etkinlikid;
        public string ogrenciid;
        public string saat;
        bool kontrol;
        private void frmyurtetkinlikleri_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            msktc.Text = metot.gettc();
            SqlCommand komut = new SqlCommand("select ogrenciid,ogrenciad, ogrencisoyad from tbl_ogrenci where ogrencitc='" + msktc.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ogrenciid = dr[0].ToString();
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select etkinlikad,etkinlikgun,(etkinlikbasaat+' - '+etkinlikbitsaat) from tbl_etkinlikkayit", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SqlCommand komut1 = new SqlCommand("select etkinlikad from tbl_etkinlikkayit", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                cmbetkinlik.Items.Add(dr1[0].ToString());
            }
            bgl.baglanti().Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogrencipaneli frm = new frmogrencipaneli();
            frm.tc = tc;
            frm.Show();
            this.Hide();
        }
        private void cmbetkinlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select etkinlikid, etkinlikbasaat, etkinlikbitsaat from tbl_etkinlikkayit where etkinlikad='" + cmbetkinlik.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                etkinlikid = dr[0].ToString();
                txtsaat.Text = dr[1].ToString() + " - " + dr[2].ToString();
            }
            bgl.baglanti().Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //TEKRAR EYNI ETKİNLİĞE KAYIT YAPILMASINI ÖNLEMEK İÇİN
            SqlCommand komut1 = new SqlCommand("select * from tbl_secilenetkinlik where ogrenciid='" + ogrenciid + "' and etkinlikid='" + etkinlikid + "'", bgl.baglanti());
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                kontrol = false;
            }
            else
            {
                kontrol = true;
            }
            bgl.baglanti().Close();

            if (cmbetkinlik.SelectedIndex != -1)
            {
                if (kontrol == true)
                {
                    SqlCommand komut = new SqlCommand("insert into tbl_secilenetkinlik (ogrenciid,etkinlikid)values(@p1,@p2)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", ogrenciid);
                    komut.Parameters.AddWithValue("@p2", etkinlikid);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("KAYIT BAŞARILI..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("SEÇİLEN ETKİNLİK İÇİN KAYDINIZ MEVCUT.\nTEKRAR KAYIT YAPILAMAZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ETKİNLİK SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}