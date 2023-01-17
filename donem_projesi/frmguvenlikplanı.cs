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
    public partial class frmguvenlikplanı : Form
    {
        public frmguvenlikplanı()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        string[] bassaat = {"08.00","16.00","24.00" };
        string[] bitsaat = { "16.00", "24.00", "08.00" };
        bool kontrol;
        public string tc;

        void mukerrer()
        {
            SqlCommand komut = new SqlCommand("select * from tbl_nobet where tarih='"+dateTimePicker1.Value.ToString("yyyy.MM.dd")+"' and bassaat='"+cmbbaslangic.Text+"'",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                kontrol = false;
            }
            else
            {
                kontrol = true;
            }
        }
        void temizle()
        {
            cmbadsoyad.SelectedIndex = -1;
            cmbbaslangic.SelectedIndex = -1;
            cmbbitis.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now.Date;
        }
        void listele()
        {
            SqlCommand komut1 = new SqlCommand("select * from tbl_nobet order by tarih", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnguvenlikkayıt_Click(object sender, EventArgs e)
        {
            frmguvenlikkaydetsil frmgkayit = new frmguvenlikkaydetsil();
            frmgkayit.tc = metot.gettc();
            frmgkayit.Show();
            this.Hide();
        }
        private void frmguvenlikplanı_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            cmbbaslangic.Items.AddRange(bassaat);
            cmbbitis.Items.AddRange(bitsaat);

            SqlCommand komut = new SqlCommand("select (guvenlikadsoyad) from tbl_guvenlik",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbadsoyad.Items.Add(dr[0].ToString());
            }

            listele();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmyonetici frm = new frmyonetici();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
        private void cmbbaslangics_SelectedIndexChanged(object sender, EventArgs e)
        {
            //baslangıc saati secildiğinde bitiş saati otomatik diğer comboboxta geliyor
            for (int i = 0; i < cmbbaslangic.Items.Count; i++)
            {
                if (cmbbaslangic.SelectedIndex==i)
                {
                    cmbbitis.Text = cmbbitis.Items[i].ToString();
                }
            }
        }
        private void cmbbitis_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cmbbitis.Items.Count; i++)
            {
                if (cmbbitis.SelectedIndex == i)
                {
                    cmbbaslangic.Text = cmbbaslangic.Items[i].ToString();
                }
            }
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            if (cmbadsoyad.Text != "" && cmbbaslangic.Text != "" && cmbbitis.Text != "")
            {
                mukerrer();
                if (kontrol == true)
                {
                    SqlCommand komut = new SqlCommand("insert into tbl_nobet (guvenlikadsoyad,tarih,bassaat,bitsaat)values(@p1,@p2,@p3,@p4)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", cmbadsoyad.Text);
                    komut.Parameters.AddWithValue("@p2", dateTimePicker1.Value.ToString("yyyy.MM.dd"));
                    komut.Parameters.AddWithValue("@p3", cmbbaslangic.Text);
                    komut.Parameters.AddWithValue("@p4", cmbbitis.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("KAYIT BAŞARILI...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                    listele();
                }
                else
                {
                    MessageBox.Show("SEÇİLEN NÖBET SAATİ DOLU..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("EKSİK BİLGİ BIRAKMAYIN..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_nobet where tarih='"+dateTimePicker2.Value.ToString("yyyy-MM-dd")+"'", bgl.baglanti());

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (cmbbaslangic.Text != ""&&cmbadsoyad.Text!="")
            {
                SqlCommand komut = new SqlCommand("delete from tbl_nobet where tarih='" + dateTimePicker1.Value.ToString("yyyy.MM.dd") + "' and bassaat='" + cmbbaslangic.Text + "' and guvenlikadsoyad='"+cmbadsoyad.Text+"'", bgl.baglanti());
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("NÖBET BİLGİLERİ SİLİNDİ...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
            }
            else
            {
                MessageBox.Show("EKSİK BİLGİ BIRAKMAYIN..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbadsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            cmbbaslangic.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbbitis.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void btnhaftaliklistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbadsoyad.Text != "")
            {
                SqlCommand komut1 = new SqlCommand("select * from tbl_nobet where guvenlikadsoyad=@p1 order by tarih", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", cmbadsoyad.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut1);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("GÜVENLİK ADINI SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select * from tbl_nobet order by tarih", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", cmbadsoyad.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
