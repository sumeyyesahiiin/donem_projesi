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
    public partial class frmogrencigirisi : Form
    {
        public frmogrencigirisi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        public string btnsecim = "basla";
        public string ogrizin;
        public string onay;
        public string karar;
        public int konum = 0;
        public string yurtad;
        private void button1_Click(object sender, EventArgs e)
        {
            metot.set(msktc.Text, txtsifre.Text);
            string tc = metot.gettc();
            string sifre = metot.getsifre();

            string rdeger = metot.tckontrol(tc);

            try
            {
                metot.message();

                if (rdeger == "4")
                {
                    SqlCommand komut = new SqlCommand("select * from tbl_ogrenci where ogrencitc=@p1 and ogrencisifre=@p2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", tc);
                    komut.Parameters.AddWithValue("@p2", sifre);
                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                        frmogrencipaneli frm = new frmogrencipaneli();
                        frm.tc = metot.gettc();
                        frm.id = dr[0].ToString();
                        frm.yurtad = yurtad;
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("SİFRE EKSİK VEYA HATALI...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    bgl.baglanti().Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmgiris frmgiris = new frmgiris();
            frmgiris.Show();
            this.Hide();
        }
        private void frmogrencigirisi_Load_1(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortTimeString();
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            frmgiris frmgiris = new frmgiris();
            frmgiris.Show();
            this.Hide();
        }
    }
}

