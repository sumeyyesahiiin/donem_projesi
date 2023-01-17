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
    public partial class frmodemedurumu : Form
    {
        public frmodemedurumu()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        string dtp;
        public string tc;
        void odenen()
        {
            SqlCommand komut = new SqlCommand("select odemetarih,y1.ogrencitc, ogrenciad,ogrencisoyad,ogrencitel, ogrenciodano, ogrenciyatakno from tbl_yurtodeme y1 join tbl_ogrenci o1 on y1.ogrencitc = o1.ogrencitc where substring(odemetarih, 4, 7)='" +dtp+ "'", bgl.baglanti());

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogrenci frm = new frmogrenci();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtp = dateTimePicker1.Value.ToString("MM") + "." + dateTimePicker1.Value.ToString("yyyy");

            odenen();
        }
        private void frmodemedurumu_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            dataGridView1.RowHeadersWidth = 4;
            dtp = dateTimePicker1.Value.ToString("MM") + "." + dateTimePicker1.Value.ToString("yyyy");
            odenen();

            SqlCommand komut = new SqlCommand("select ogrencitc from tbl_ogrenci except select ogrencitc from tbl_yurtodeme", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                SqlCommand komut1 = new SqlCommand("select ogrencitc, ogrenciad,ogrencisoyad,ogrencitel, ogrenciodano, ogrenciyatakno from tbl_ogrenci where ogrencitc='"+comboBox1.Items[i]+"'",bgl.baglanti());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut1);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }
    }
}
