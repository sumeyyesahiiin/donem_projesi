using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace donem_projesi
{
    public partial class frmogrenci : Form
    {
        public frmogrenci()
        {
            InitializeComponent();
        }
        metot_kullan metot = new metot_kullan();
        public string tc;
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmyonetici frm = new frmyonetici();
            frm.tc = metot.gettc();
            frm.Show();
            this.Hide();
        }
        private void btnodeme_Click(object sender, EventArgs e)
        {
            frmodemedurumu frmodemedurum = new frmodemedurumu();
            frmodemedurum.tc = metot.gettc();
            frmodemedurum.Show();
            this.Hide();
        }
        private void btnizinonay_Click(object sender, EventArgs e)
        {
            frmogrenciizin frmoizin = new frmogrenciizin();
            frmoizin.tc = metot.gettc();
            frmoizin.Show();
            this.Hide();
        }
        private void btnbilgi_Click(object sender, EventArgs e)
        {
            frmogrencibilgi frmobilgi = new frmogrencibilgi();
            frmobilgi.tc = metot.gettc();
            frmobilgi.Show();
            this.Hide();
        }
        private void btnkayit_Click(object sender, EventArgs e)
        {
            frmogrencikayıt frmokayit = new frmogrencikayıt();
            frmokayit.tc = metot.gettc();
            frmokayit.Show();
            this.Hide();
        }

        private void btnduyuru_Click(object sender, EventArgs e)
        {
            frmogrenciduyuru frmduyuru = new frmogrenciduyuru();
            frmduyuru.tc = metot.gettc();
            frmduyuru.Show();
            this.Hide();
        }
        private void frmogrenci_Load(object sender, EventArgs e)
        {
            metot.settc(tc);
        }
    }
}
