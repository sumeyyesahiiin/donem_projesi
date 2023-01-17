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
    public partial class frmogrenciodeme : Form
    {
        public frmogrenciodeme()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        public string tc;
        public string yurtad;
        string kartno="", kartsonktarih="", cvv="",b_hatırla="0";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogrencipaneli frmopanel = new frmogrencipaneli();
            frmopanel.tc = metot.gettc();
            frmopanel.yurtad = txtyurtad.Text;
            frmopanel.Show();
            this.Hide();
        }
        void hatırla()
        {
            kartno = "";
            SqlCommand komut1 = new SqlCommand("select kartno, kartsonktarih,cvv from tbl_yurtodeme where ogrencitc='" + msktc.Text + "' and hatırla='" + 1 + "'", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                kartno = dr1[0].ToString();
                kartsonktarih = dr1[1].ToString();
                cvv = dr1[2].ToString();

            }
            bgl.baglanti().Close();
        }
        void kayıt()
        {
            SqlCommand komut2 = new SqlCommand("insert into tbl_yurtodeme (ogrencitc,yurtad,odemetarih,kartno,kartsonktarih,cvv,hatırla)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", msktc.Text);
            komut2.Parameters.AddWithValue("@p2", txtyurtad.Text);
            komut2.Parameters.AddWithValue("@p3",dateTimePicker1.Value.ToString("yyyy.MM.dd"));
            komut2.Parameters.AddWithValue("@p4", mskkartno.Text);
            komut2.Parameters.AddWithValue("@p5", mskskullantarih.Text);
            komut2.Parameters.AddWithValue("@p6", mskcvv.Text);
            komut2.Parameters.AddWithValue("@p7", b_hatırla);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ÖDEMENİZ GERÇEKLEŞTİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;

            mskkartno.Text = "";
            mskskullantarih.Text = "";
            mskcvv.Text = "";

            SqlCommand komut = new SqlCommand("update tbl_yurtodeme set hatırla=@p1 where ogrencitc='"+msktc.Text+"'and hatırla='"+1+"'",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",0);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("KAYITLI OLAN KART BİLGİLERİ SİLİNDİ...","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                b_hatırla = "0";
            }
            else if(checkBox1.Checked==true)
            {
                b_hatırla = "1";
            }
        }

        private void frmogrenciodeme_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Visible = false;
            txtyurtad.Text = yurtad;

            metot.settc(tc);

            msktc.Text = metot.gettc();

            SqlCommand komut1 = new SqlCommand("select hatırla from tbl_yurtodeme where ogrencitc='" + msktc.Text+"'", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                string secim = dr1[0].ToString();
                if(secim=="True")
                {
                    checkBox1.Checked = true;
                }
                bgl.baglanti().Close();
            }

            if (checkBox1.Checked == true)
            {
                SqlCommand komut = new SqlCommand("  select (ogrenciad+''+ogrencisoyad), kartno, kartsonktarih,cvv from tbl_ogrenci o1 join tbl_yurtodeme y1 on o1.ogrencitc = y1.ogrencitc where o1.ogrencitc =@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", msktc.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    txtadsoyad.Text = dr[0].ToString();
                    mskkartno.Text = dr[1].ToString();
                    mskskullantarih.Text = dr[2].ToString();
                    mskcvv.Text = dr[3].ToString();
                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komut = new SqlCommand(" select (ogrenciad+' '+ogrencisoyad) from tbl_ogrenci where ogrencitc= @p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", msktc.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    txtadsoyad.Text = dr[0].ToString();
                }
                bgl.baglanti().Close();
            }
        }

        private void btnode_Click(object sender, EventArgs e)
        {
            try
            {
                hatırla();

                if (checkBox1.Checked == true)
                {
                    if (mskkartno.Text == kartno && mskskullantarih.Text == kartsonktarih && mskcvv.Text == cvv)
                    {
                        kayıt();
                    }
                    else if (kartno == "")
                    {
                        if (mskkartno.Text != "" && mskskullantarih.Text != "" && mskcvv.Text != "")
                        {
                            kayıt();
                            MessageBox.Show("KART BİLGİLERİNİZ KAYDEDİLDİ..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("KART BİLGİLERİNİ BOŞ BIRAKMAYINIZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }         
                    }
                    else if (mskkartno.Text != kartno)
                    {
                        MessageBox.Show("ÖĞRENCİYE AİT KART KAYDI MEVCUT.\nFARKLI KART KULLANIMI İÇİN KART BİLGİNİZİ GÜNCELLEYİN\nVEYA BENİ HATIRLA KUTUSUNDAKİ İŞARETİ KALDIRIP KAYITLI OLMAYAN KARTINIZI KULLANABİLİRSİNİZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (mskkartno.Text!=""&&mskskullantarih.Text!=""&&mskcvv.Text!="")
                    {
                        kayıt();
                    }
                    else
                    {
                        MessageBox.Show("KART BİLGİLERİNİ BOŞ BIRAKMAYINIZ...","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }
    }
}
