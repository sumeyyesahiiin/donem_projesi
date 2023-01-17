
namespace donem_projesi
{
    partial class frmogrenciodeme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmogrenciodeme));
            this.label1 = new System.Windows.Forms.Label();
            this.txtadsoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnode = new System.Windows.Forms.Button();
            this.txtyurtad = new System.Windows.Forms.TextBox();
            this.mskkartno = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mskcvv = new System.Windows.Forms.MaskedTextBox();
            this.mskskullantarih = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.msktc = new System.Windows.Forms.MaskedTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "AD SOYAD: ";
            // 
            // txtadsoyad
            // 
            this.txtadsoyad.Enabled = false;
            this.txtadsoyad.Location = new System.Drawing.Point(148, 66);
            this.txtadsoyad.Name = "txtadsoyad";
            this.txtadsoyad.Size = new System.Drawing.Size(144, 20);
            this.txtadsoyad.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "TC KİMLİK:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "YURT ADI:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "KART NUMARASI:";
            // 
            // btnode
            // 
            this.btnode.Location = new System.Drawing.Point(193, 301);
            this.btnode.Name = "btnode";
            this.btnode.Size = new System.Drawing.Size(75, 23);
            this.btnode.TabIndex = 84;
            this.btnode.Text = "ÖDE";
            this.btnode.UseVisualStyleBackColor = true;
            this.btnode.Click += new System.EventHandler(this.btnode_Click);
            // 
            // txtyurtad
            // 
            this.txtyurtad.Enabled = false;
            this.txtyurtad.Location = new System.Drawing.Point(148, 132);
            this.txtyurtad.Name = "txtyurtad";
            this.txtyurtad.Size = new System.Drawing.Size(144, 20);
            this.txtyurtad.TabIndex = 86;
            // 
            // mskkartno
            // 
            this.mskkartno.Location = new System.Drawing.Point(148, 166);
            this.mskkartno.Mask = "0000000000000000";
            this.mskkartno.Name = "mskkartno";
            this.mskkartno.Size = new System.Drawing.Size(144, 20);
            this.mskkartno.TabIndex = 87;
            this.mskkartno.ValidatingType = typeof(int);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 92;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 93;
            this.label7.Text = "CVV:";
            // 
            // mskcvv
            // 
            this.mskcvv.Location = new System.Drawing.Point(148, 232);
            this.mskcvv.Mask = "000";
            this.mskcvv.Name = "mskcvv";
            this.mskcvv.Size = new System.Drawing.Size(144, 20);
            this.mskcvv.TabIndex = 94;
            this.mskcvv.ValidatingType = typeof(int);
            // 
            // mskskullantarih
            // 
            this.mskskullantarih.Location = new System.Drawing.Point(148, 199);
            this.mskskullantarih.Mask = "00/00";
            this.mskskullantarih.Name = "mskskullantarih";
            this.mskskullantarih.Size = new System.Drawing.Size(144, 20);
            this.mskskullantarih.TabIndex = 95;
            this.mskskullantarih.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "SON KULLANMA TARİHİ:";
            // 
            // msktc
            // 
            this.msktc.Enabled = false;
            this.msktc.Location = new System.Drawing.Point(148, 100);
            this.msktc.Mask = "00000000000";
            this.msktc.Name = "msktc";
            this.msktc.Size = new System.Drawing.Size(144, 20);
            this.msktc.TabIndex = 97;
            this.msktc.ValidatingType = typeof(int);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.Location = new System.Drawing.Point(141, 268);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(127, 14);
            this.checkBox1.TabIndex = 98;
            this.checkBox1.Text = "KART BİLGİLERİMİ HATIRLA";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 20);
            this.button1.TabIndex = 99;
            this.button1.Text = "KART BİLGİSİ GÜNCELLE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(179, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker1.TabIndex = 100;
            // 
            // frmogrenciodeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(335, 371);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.msktc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mskskullantarih);
            this.Controls.Add(this.mskcvv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mskkartno);
            this.Controls.Add(this.txtyurtad);
            this.Controls.Add(this.btnode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtadsoyad);
            this.Name = "frmogrenciodeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÖĞRENCİ YURT ÖDEME";
            this.Load += new System.EventHandler(this.frmogrenciodeme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtadsoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnode;
        private System.Windows.Forms.TextBox txtyurtad;
        private System.Windows.Forms.MaskedTextBox mskkartno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mskcvv;
        private System.Windows.Forms.MaskedTextBox mskskullantarih;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox msktc;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}