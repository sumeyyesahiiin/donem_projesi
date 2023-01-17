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
    public partial class frmyoneticigirisi : Form
    {
        public frmyoneticigirisi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        private void button1_Click(object sender, EventArgs e)
        {
            metot.set(msktc.Text, txtsifre.Text);
            string tc = metot.gettc();
            string sifre = metot.getsifre();
            string rdegeri = metot.tckontrol(tc);
          
            try
            {
                metot.message();

                if (rdegeri == "4")
                {
                    SqlCommand komut = new SqlCommand("select * from tbl_yonetici where yoneticitc=@p1 and yoneticisifre=@p2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", tc);
                    komut.Parameters.AddWithValue("@p2", sifre);
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        frmyonetici frm = new frmyonetici();
                        frm.tc = msktc.Text;
                        frm.Show();
                        this.Hide();
                        bgl.baglanti().Close();
                    }
                    else
                    {
                        MessageBox.Show("SİFRE EKSİK VEYA HATALI...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
        private void frmyoneticigirisi_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
