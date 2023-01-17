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
    public partial class frmodano_yatakno_kayıt : Form
    {
        public frmodano_yatakno_kayıt()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        metot_kullan metot = new metot_kullan();
        string odano;
        int sayac;
        decimal btnyatakkntrl;
        int komodin = 0, masa = 0, sandalye = 0, dolap = 0, yatak = 0;
        bool lamba = false, pencere = false, kapi = false, petek = false, priz = false, banyo = false, lavabo = false, ayakkabilik=false, askilik =false, buzdolabi =false;
        string yatakcesit="";
        public string tc;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            yatakcesit = "ranza";
        }
        void mukerrerodakayıt()
        {
            for (decimal i = nummin.Value; i <= nummax.Value; i++)
            {
                SqlCommand komut = new SqlCommand("select * from tbl_odalar where odano=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", i);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    listBox2.Items.Add(Convert.ToString(i));
                    ++sayac;
                }
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            yatakcesit = "baza";
        }
        void check()
        {
            if (checkkomodin.Checked == true)
            {
                komodin = Convert.ToInt16(numkisisayisi.Value);
            }
            if (checkayakkabi.Checked == true)
            {
                ayakkabilik = true;
            }
            if (checkaskilik.Checked == true)
            {
                askilik = true;
            }
            if (checkbuzdolabi.Checked == true)
            {
                buzdolabi = true;
            }
            if (checkmasa.Checked == true)
            {
                masa = Convert.ToInt16(numkisisayisi.Value);
            }
            if (checksandalye.Checked == true)
            {
                sandalye = Convert.ToInt16(numkisisayisi.Value);
            }
            if (checkdolap.Checked == true)
            {
                dolap = Convert.ToInt16(numkisisayisi.Value);
            }
            if(checklamba.Checked==true)
            {
                lamba = true;
            }
            if(checkpencere.Checked==true)
            {
                pencere = true;
            }
            if(checkapi.Checked==true)
            {
                kapi = true;
            }
            if(checkpetek.Checked==true)
            {
                petek = true;
            }
            if(checkpriz.Checked==true)
            {
                priz = true;
            }
            if(checkbanyo.Checked==true)
            {
                banyo = true;
            }
            if(checklavabo.Checked==true)
            {
                lavabo = true;
            }
            if(checkyatak.Checked==true)
            {
                if(radioButton1.Checked==true)
                {
                    yatak = Convert.ToInt16(numkisisayisi.Value) / 2;
                }
                if(radioButton2.Checked==true)
                {
                    yatak = Convert.ToInt16(numkisisayisi.Value);
                }
            }
        }
        private void checkyatak_CheckedChanged(object sender, EventArgs e)
        {
            if (checkyatak.Checked==true)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            if (checkyatak.Checked==false)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_odalar order by odano", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "kat";
            dataGridView1.Columns[1].HeaderText = "oda";
            dataGridView1.Columns[2].HeaderText = "kişi";
        }
        private void frmodano_yatakno_kayıt_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
            txttplkat.Text = "9";

            txtodano.Enabled = false;
            numkatsayisi.Minimum = 1;
            numkatsayisi.Maximum = Convert.ToInt16(txttplkat.Text); ;

            listele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            listBox1.Items.Clear();

            if (numodasayisi.Value != 0)
            {
                groupBox4.Enabled = true;

                if (numodasayisi.Value == 1)
                {
                    for (int i = 0; i < numodasayisi.Value; i++)
                    {
                        if (i < 10)
                        {
                            odano = Convert.ToString(numkatsayisi.Value) + 0 + i;
                        }
                        if (i >= 10)
                        {
                            odano = Convert.ToString(numkatsayisi.Value) + i;
                        }
                        listBox1.Items.Add(odano);
                    }
                }
                if (numodasayisi.Value > 1)
                {
                    for (int i = 0; i <= numodasayisi.Value; i++)
                    {
                        if (i < 10)
                        {
                            odano = Convert.ToString(numkatsayisi.Value) + 0 + i;
                        }
                        if (i >= 10)
                        {
                            odano = Convert.ToString(numkatsayisi.Value) + i;
                        }
                        listBox1.Items.Add(odano);
                    }
                }
                groupBox1.Enabled = true;

                if (listBox1.Items.Count == 1)
                {
                    nummin.Minimum = Convert.ToDecimal(listBox1.Items[0].ToString());
                    nummin.Maximum = Convert.ToDecimal(listBox1.Items[Convert.ToInt16(numodasayisi.Value) - 1].ToString());
                    nummax.Minimum = Convert.ToDecimal(listBox1.Items[0].ToString());
                    nummax.Maximum = Convert.ToDecimal(listBox1.Items[Convert.ToInt16(numodasayisi.Value) - 1].ToString());

                    nummax.Value = Convert.ToDecimal(listBox1.Items[0].ToString()); ;
                }
                else if (listBox1.Items.Count > 1)
                {
                    nummin.Minimum = Convert.ToDecimal(listBox1.Items[0].ToString());
                    nummin.Maximum = Convert.ToDecimal(listBox1.Items[Convert.ToInt16(numodasayisi.Value)].ToString());
                    nummax.Minimum = Convert.ToDecimal(listBox1.Items[0].ToString());
                    nummax.Maximum = Convert.ToDecimal(listBox1.Items[Convert.ToInt16(numodasayisi.Value)].ToString());

                    nummax.Value = Convert.ToDecimal(listBox1.Items[Convert.ToInt16(numodasayisi.Value)].ToString());
                }
            }
            else
            {
                MessageBox.Show("ODA SAYİSİNİ GİRİNİZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }
        private void txtara_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_odalar where odano like '" + txtodaara.Text + "%' order by odano", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtodano.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            btnyatakkntrl = numericUpDown1.Value;
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtodano.Text != "")
            {
                SqlCommand komut = new SqlCommand("delete from tbl_odalar where odano=@p1 and kisisayisi=@p2 ", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtodano.Text);
                komut.Parameters.AddWithValue("@p2", numericUpDown1.Value);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("ODA SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            else
            {
                MessageBox.Show("SİLMEK İSTEDİĞİNİZ ODAYI TABLODAN SEÇİN..", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_odalar where kisisayisi like '" + numkisiara.Value + "%' order by odano", bgl.baglanti());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmyonetici frm = new frmyonetici();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            sayac = 0;
            listBox2.Items.Clear();

            if (numodasayisi.Value != 0&& listBox1.Items.Count!=0)
            {
                if (numkisisayisi.Value != 0)
                {
                    mukerrerodakayıt();
                    if (sayac == 0)
                    {
                        if (checkkomodin.Checked == true || checkayakkabi.Checked == true || checkaskilik.Checked == true || checkbuzdolabi.Checked == true || checkmasa.Checked == true || checksandalye.Checked == true || checkdolap.Checked == true || checkyatak.Checked == true || checklamba.Checked == true || checkpencere.Checked == true || checkapi.Checked == true || checkpetek.Checked == true || checkpriz.Checked == true || checkbanyo.Checked == true || checklavabo.Checked == true || checkhepsi.Checked == true)
                        {
                            if (radioButton1.Checked == true || radioButton2.Checked == true)
                            {
                                if (numkisisayisi.Value % 2 == 1 && radioButton1.Checked == true)
                                {
                                    MessageBox.Show("KİŞİ SAYISI TEK İKEN RANZA SEÇİLEMEZ...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    check();
                                    for (decimal i = nummin.Value; i <= nummax.Value; i++)
                                    {
                                        SqlCommand komut = new SqlCommand("insert into tbl_odalar (katsayisi,odano,kisisayisi,komodin,ayakkabilik,askilik,buzdolabi,masa,sandalye,dolap,yatak,lamba,pencere,kapı,petek,priz,banyo,lavabo,yatakcesit) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19)", bgl.baglanti());
                                        komut.Parameters.AddWithValue("@p1", numkatsayisi.Value);
                                        komut.Parameters.AddWithValue("@p2", i);
                                        komut.Parameters.AddWithValue("@p3", numkisisayisi.Value);
                                        komut.Parameters.AddWithValue("@p4", komodin);
                                        komut.Parameters.AddWithValue("@p5", ayakkabilik);
                                        komut.Parameters.AddWithValue("@p6", askilik);
                                        komut.Parameters.AddWithValue("@p7", buzdolabi);
                                        komut.Parameters.AddWithValue("@p8", masa);
                                        komut.Parameters.AddWithValue("@p9", sandalye);
                                        komut.Parameters.AddWithValue("@p10", dolap);
                                        komut.Parameters.AddWithValue("@p11", yatak);
                                        komut.Parameters.AddWithValue("@p12", lamba);
                                        komut.Parameters.AddWithValue("@p13", pencere);
                                        komut.Parameters.AddWithValue("@p14", kapi);
                                        komut.Parameters.AddWithValue("@p15", petek);
                                        komut.Parameters.AddWithValue("@p16", priz);
                                        komut.Parameters.AddWithValue("@p17", banyo);
                                        komut.Parameters.AddWithValue("@p18", lavabo);
                                        komut.Parameters.AddWithValue("@p19", yatakcesit);//sqlde bool tanımladım ranza=false baza=true
                                        komut.ExecuteNonQuery();
                                        bgl.baglanti().Close();
                                    }
                                    MessageBox.Show(listBox1.Items.Count + " ODANIN KAYDI BAŞARILI...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    listele();
                                }
                            }
                            else
                            {
                                MessageBox.Show("YATAK ÇEŞİDİNİ SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("EKLENECEK ESYALARI SEÇİN...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        groupBox5.Enabled = true;
                        MessageBox.Show(sayac + " ODANIN KAYDI BULUNMAKTA. KAYDI BULANAN ODALARA TEKRAR KAYIT İŞLEMİ YAPILAMAZ..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("KİŞİ SAYISI 0 OLAMAZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("KATTAKİ ODA SAYISI 0 OLAMAZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void checkhepsi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkhepsi.Checked == true)
            {
                checkkomodin.Checked = true;
                checkayakkabi.Checked = true;
                checkaskilik.Checked = true;
                checkbuzdolabi.Checked = true;
                checkmasa.Checked = true;
                checksandalye.Checked = true;
                checkdolap.Checked = true;
                checkyatak.Checked = true;
                checklamba.Checked = true;
                checkpencere.Checked = true;
                checkapi.Checked = true;
                checkpetek.Checked = true;
                checkpriz.Checked = true;
                checkbanyo.Checked = true;
                checklavabo.Checked = true;
                checkhepsi.Checked = true;
            }
            else if (checkhepsi.Checked == false)
            {
                checkkomodin.Checked = false;
                checkayakkabi.Checked = false;
                checkaskilik.Checked = false;
                checkbuzdolabi.Checked = false;
                checkmasa.Checked = false;
                checksandalye.Checked = false;
                checkdolap.Checked = false;
                checkyatak.Checked = false;
                checklamba.Checked = false;
                checkpencere.Checked = false;
                checkapi.Checked = false;
                checkpetek.Checked = false;
                checkpriz.Checked = false;
                checkbanyo.Checked = false;
                checklavabo.Checked = false;
                checkhepsi.Checked = false;
            }
        }
    }
}
