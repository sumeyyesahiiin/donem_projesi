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
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmyoneticigirisi frmygiris = new frmyoneticigirisi();
            frmygiris.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmguvenlikgirisi frmggiris = new frmguvenlikgirisi();
            frmggiris.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmogrencigirisi frmogiris = new frmogrencigirisi();
            frmogiris.yurtad = label4.Text;
            frmogiris.Show();
        }
    }
}
