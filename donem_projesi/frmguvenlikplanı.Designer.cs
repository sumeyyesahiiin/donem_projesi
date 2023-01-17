
namespace donem_projesi
{
    partial class frmguvenlikplanı
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmguvenlikplanı));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnhaftaliklistele = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnekle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbbaslangic = new System.Windows.Forms.ComboBox();
            this.cmbbitis = new System.Windows.Forms.ComboBox();
            this.btnguvenlikkayıt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnkisilistele = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbadsoyad = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "AD SOYAD: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(250, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(442, 299);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "BAŞLANGIÇ SAAT:";
            // 
            // btnhaftaliklistele
            // 
            this.btnhaftaliklistele.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnhaftaliklistele.Location = new System.Drawing.Point(12, 74);
            this.btnhaftaliklistele.Name = "btnhaftaliklistele";
            this.btnhaftaliklistele.Size = new System.Drawing.Size(92, 29);
            this.btnhaftaliklistele.TabIndex = 69;
            this.btnhaftaliklistele.Text = "LİSTELE";
            this.btnhaftaliklistele.UseVisualStyleBackColor = true;
            this.btnhaftaliklistele.Click += new System.EventHandler(this.btnhaftaliklistele_Click);
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(119, 26);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(92, 29);
            this.btnsil.TabIndex = 67;
            this.btnsil.Text = "SİL";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnekle
            // 
            this.btnekle.Location = new System.Drawing.Point(12, 26);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(92, 29);
            this.btnekle.TabIndex = 66;
            this.btnekle.Text = "EKLE";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "TARİH:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "BİTİŞ SAAT:";
            // 
            // cmbbaslangic
            // 
            this.cmbbaslangic.FormattingEnabled = true;
            this.cmbbaslangic.Location = new System.Drawing.Point(112, 116);
            this.cmbbaslangic.Name = "cmbbaslangic";
            this.cmbbaslangic.Size = new System.Drawing.Size(121, 21);
            this.cmbbaslangic.TabIndex = 74;
            this.cmbbaslangic.SelectedIndexChanged += new System.EventHandler(this.cmbbaslangics_SelectedIndexChanged);
            // 
            // cmbbitis
            // 
            this.cmbbitis.FormattingEnabled = true;
            this.cmbbitis.Location = new System.Drawing.Point(112, 150);
            this.cmbbitis.Name = "cmbbitis";
            this.cmbbitis.Size = new System.Drawing.Size(121, 21);
            this.cmbbitis.TabIndex = 75;
            this.cmbbitis.SelectedIndexChanged += new System.EventHandler(this.cmbbitis_SelectedIndexChanged);
            // 
            // btnguvenlikkayıt
            // 
            this.btnguvenlikkayıt.Location = new System.Drawing.Point(26, 295);
            this.btnguvenlikkayıt.Name = "btnguvenlikkayıt";
            this.btnguvenlikkayıt.Size = new System.Drawing.Size(199, 42);
            this.btnguvenlikkayıt.TabIndex = 76;
            this.btnguvenlikkayıt.Text = "GÜVENLİK PERSONELİ KAYDET-SİL-GÜNCELLE";
            this.btnguvenlikkayıt.UseVisualStyleBackColor = true;
            this.btnguvenlikkayıt.Click += new System.EventHandler(this.btnguvenlikkayıt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnkisilistele);
            this.groupBox1.Controls.Add(this.btnhaftaliklistele);
            this.groupBox1.Controls.Add(this.btnekle);
            this.groupBox1.Controls.Add(this.btnsil);
            this.groupBox1.Location = new System.Drawing.Point(14, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 114);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KAYDET-SİL";
            // 
            // btnkisilistele
            // 
            this.btnkisilistele.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnkisilistele.Location = new System.Drawing.Point(119, 74);
            this.btnkisilistele.Name = "btnkisilistele";
            this.btnkisilistele.Size = new System.Drawing.Size(92, 34);
            this.btnkisilistele.TabIndex = 70;
            this.btnkisilistele.Text = "KİŞİYE GÖRE LİSTELE";
            this.btnkisilistele.UseVisualStyleBackColor = true;
            this.btnkisilistele.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmbadsoyad
            // 
            this.cmbadsoyad.FormattingEnabled = true;
            this.cmbadsoyad.Location = new System.Drawing.Point(113, 41);
            this.cmbadsoyad.Name = "cmbadsoyad";
            this.cmbadsoyad.Size = new System.Drawing.Size(121, 21);
            this.cmbadsoyad.TabIndex = 79;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 80;
            this.dateTimePicker1.Value = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(568, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker2.TabIndex = 82;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "TARİH:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(46, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(542, 22);
            this.richTextBox1.TabIndex = 83;
            this.richTextBox1.Text = "DATAGRİD ÜSTÜNDEKİNDEN TARİH SEÇİLDİĞİNDE O HAFTANIN TARİHİNİ GETİRMEK İÇİN LİSTE" +
    "LEME ";
            // 
            // frmguvenlikplanı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(699, 346);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbadsoyad);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnguvenlikkayıt);
            this.Controls.Add(this.cmbbitis);
            this.Controls.Add(this.cmbbaslangic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "frmguvenlikplanı";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HAFTALIK GÜVENLİK ÇALIŞMA PLANI";
            this.Load += new System.EventHandler(this.frmguvenlikplanı_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnhaftaliklistele;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbbaslangic;
        private System.Windows.Forms.ComboBox cmbbitis;
        private System.Windows.Forms.Button btnguvenlikkayıt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbadsoyad;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnkisilistele;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}