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
//en yeni 5 duyuruyu tarihleri ile göster
namespace donem_projesi
{
    public partial class frmyonetici : Form
    {
        public frmyonetici()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        DateTime zaman = DateTime.Now;
        metot_kullan metot = new metot_kullan();
        public string tc;
        
        string[] duyurusecim = { "Yönetici", "Güvenlik" };
        string[] gunler = { "Pazartesi","Salı","Çarşamba","Perşembe","Cuma","Cumartesi","Pazar"};

        void eskiduyuru()
        {
            if(comboBox1.SelectedIndex==0)
            {
                listView1.Items.Clear();
                SqlCommand komut = new SqlCommand("select yoneticitarih, yoneticiduyuru from tbl_yoneticiduyuru", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem duyuru = new ListViewItem(dr["yoneticitarih"].ToString());
                    duyuru.SubItems.Add(dr["yoneticiduyuru"].ToString());
                    listView1.Items.Add(duyuru);
                }
                bgl.baglanti().Close();
            }
            else if(comboBox1.SelectedIndex==1)
            {
                listView1.Items.Clear();
                SqlCommand komut = new SqlCommand("select guvenliktarih, guvenlikduyuru from tbl_guvenlikduyuru", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem duyuru = new ListViewItem(dr["guvenliktarih"].ToString());
                    duyuru.SubItems.Add(dr["guvenlikduyuru"].ToString());
                    listView1.Items.Add(duyuru);
                }
                bgl.baglanti().Close();
            }
        }
        void etkinlikler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select etkinlikad,etkinlikgun,etkinlikbasaat,etkinlikbitsaat from tbl_etkinlikkayit ", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        void temizle()
        {
            txtetkinlikad.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i,false);
            }
            mskbaslangic.Text = "";
            mskbitis.Text ="";
        } 
        private void frmyonetici_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            txtad.Enabled = false;
            txtsoyad.Enabled = false;
            msktc.Enabled = false;
            msktel.Enabled = false;
            txtunvan.Enabled = false;
            btnyonetici.Enabled = false;

            label7.Text =zaman.ToShortDateString();

            comboBox1.Items.AddRange(duyurusecim);

            //checklist gün ekleme
            checkedListBox1.Items.AddRange(gunler);

            if (txtunvan.Text=="Müdür"|| txtunvan.Text == "Müdür Yardımcısı")
            {
                btnyonetici.Enabled = true;
            }

            SqlCommand komut1 = new SqlCommand("select yoneticitarih, yoneticiduyuru from tbl_yoneticiduyuru", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                ListViewItem duyuru = new ListViewItem(dr1["yoneticitarih"].ToString());
                duyuru.SubItems.Add(dr1["yoneticiduyuru"].ToString());
                listView1.Items.Add(duyuru);
            }
            bgl.baglanti().Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select yoneticiunvan,yoneticitel,yoneticimail,( yoneticiad+' '+yoneticisoyad) from tbl_yonetici", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SqlCommand komut2 = new SqlCommand("select yoneticiad, yoneticisoyad, yoneticitc,yoneticitel, yoneticiunvan from tbl_yonetici where yoneticitc=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",metot.gettc());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                txtad.Text = dr2[0].ToString();
                txtsoyad.Text = dr2[1].ToString();
                msktc.Text = dr2[2].ToString();
                msktel.Text = dr2[3].ToString();
                txtunvan.Text = dr2[4].ToString();
            }
            bgl.baglanti().Close();
            dataGridView1.RowHeadersWidth = 4;
            dataGridView2.RowHeadersWidth = 4;
            etkinlikler();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmyoneticikayıt frmybilgi = new frmyoneticikayıt();
            frmybilgi.tc = metot.gettc();
            frmybilgi.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmogrenci frmo = new frmogrenci();
            frmo.tc = metot.gettc();
            frmo.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmguvenlikplanı frmgplani = new frmguvenlikplanı();
            frmgplani.tc = metot.gettc();
            frmgplani.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            frmodano_yatakno_kayıt frm = new frmodano_yatakno_kayıt();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
        private void btnduyuru_Click(object sender, EventArgs e)
        {
            //timer kullanarak duyurunun kalma süresini ayarlayabilirsen ayarla 
            if(richTextBox1.Text!="")
            {
                if(checkBox1.Checked==true)
                {
                    SqlCommand komut = new SqlCommand("insert into tbl_yoneticiduyuru (yoneticiduyuru, yoneticitarih, yoneticisaat)values (@p1, @p2, @p3)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1",richTextBox1.Text);
                    komut.Parameters.AddWithValue("@p2",zaman.ToShortDateString());
                    komut.Parameters.AddWithValue("@p3",zaman.ToShortTimeString());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    
                    if (checkBox2.Checked==false)
                    {
                        MessageBox.Show("MESAJ GÖNDERİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        richTextBox1.Clear();
                        eskiduyuru();
                    }
                }
                if (checkBox2.Checked == true)//iksinede aynı mesaj gönderilmek istenebilir eğer if yaparsanda else in içine giriyor kontrol et onu
                {
                    SqlCommand komut = new SqlCommand("insert into tbl_guvenlikduyuru (guvenlikduyuru, guvenliktarih, guvenliksaat)values(@p1,@p2,@p3)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@p2", zaman.ToShortDateString());
                    komut.Parameters.AddWithValue("@p3", zaman.ToShortTimeString());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("MESAJ GÖNDERİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    richTextBox1.Clear();
                    eskiduyuru();
                }
                else if(checkBox1.Checked==false&&checkBox2.Checked==false)
                {
                    MessageBox.Show("DUYURU KİŞİ SEÇİLMEDİĞİ İÇİN GÖNDERİLEMEDİ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("BOŞ DUYURU PAYLAŞILAMAZ..","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            eskiduyuru();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if(txtetkinlikad.Text!="")
            {
                if(checkedListBox1.SelectedIndex!=-1&&checkedListBox1.CheckedItems.Count==1)
                {
                    if(mskbaslangic.Text.Length==5&& mskbitis.Text.Length == 5)
                    {

                        SqlCommand komut = new SqlCommand("insert into tbl_etkinlikkayit (etkinlikad, etkinlikgun,etkinlikbasaat,etkinlikbitsaat)values(@p1,@p2,@p3,@p4)", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", txtetkinlikad.Text);
                        komut.Parameters.AddWithValue("@p2",checkedListBox1.CheckedItems[0]);
                        komut.Parameters.AddWithValue("@p3", mskbaslangic.Text);
                        komut.Parameters.AddWithValue("@p4", mskbitis.Text);
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("ETKİNLİK KAYDEDİLDİ...","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        etkinlikler();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("SAAT BİLGİLERİNİ GİRİN..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("BİR ETKİNLİK GÜNÜ SEÇİN..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ETKİNLİK ADINI GİRİNİZ..","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtetkinlikad.Text != "" && checkedListBox1.CheckedItems.Count == 1 && mskbaslangic.Text.Length == 5 && mskbitis.Text.Length == 5)
            {
                SqlCommand komut = new SqlCommand("delete from tbl_etkinlikkayit where etkinlikad='" + txtetkinlikad.Text + "'", bgl.baglanti());
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("ETKİNLİK SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                temizle();
                etkinlikler();
            }
            else
            {
                MessageBox.Show("EKSİK VEYA HATALI BİLGİ.\nSİLMEK İSTENEN ETKİNLİĞİ TABLODAN SEÇİNİZ...","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtetkinlikad.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            mskbaslangic.Text= dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            mskbitis.Text= dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();

            string gun= dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();

            //kayıtlı olan gunu isaretleme
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (gun == checkedListBox1.Items[i].ToString())
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }
        private void btnetkinlikekle_Click(object sender, EventArgs e)
        {
            frmyurtetkinlikleri frm = new frmyurtetkinlikleri();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
    }
}
