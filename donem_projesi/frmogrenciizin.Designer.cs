
namespace donem_projesi
{
    partial class frmogrenciizin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmogrenciizin));
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtadsoyad = new System.Windows.Forms.TextBox();
            this.mskgun = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnizin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btntumizin = new System.Windows.Forms.Button();
            this.btnonayla = new System.Windows.Forms.Button();
            this.btnonaylanan = new System.Windows.Forms.Button();
            this.btnguncelle = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "BİTİŞ TARİHİ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 78;
            this.label5.Text = "KALAN GÜN:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 79;
            this.label6.Text = "BAŞLANGIÇ TARİHİ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "AD SOYAD: ";
            // 
            // txtadsoyad
            // 
            this.txtadsoyad.Location = new System.Drawing.Point(129, 37);
            this.txtadsoyad.Name = "txtadsoyad";
            this.txtadsoyad.Size = new System.Drawing.Size(120, 20);
            this.txtadsoyad.TabIndex = 77;
            // 
            // mskgun
            // 
            this.mskgun.Enabled = false;
            this.mskgun.Location = new System.Drawing.Point(128, 71);
            this.mskgun.Mask = "00000000000";
            this.mskgun.Name = "mskgun";
            this.mskgun.Size = new System.Drawing.Size(120, 20);
            this.mskgun.TabIndex = 87;
            this.mskgun.ValidatingType = typeof(int);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(265, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(573, 414);
            this.dataGridView1.TabIndex = 89;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(179, 184);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 17);
            this.checkBox1.TabIndex = 94;
            this.checkBox1.Text = "ONAYLA";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnizin
            // 
            this.btnizin.Location = new System.Drawing.Point(174, 207);
            this.btnizin.Name = "btnizin";
            this.btnizin.Size = new System.Drawing.Size(75, 23);
            this.btnizin.TabIndex = 99;
            this.btnizin.Text = "İZİN VER";
            this.btnizin.UseVisualStyleBackColor = true;
            this.btnizin.Click += new System.EventHandler(this.btnizin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 176;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btntumizin
            // 
            this.btntumizin.Location = new System.Drawing.Point(6, 19);
            this.btntumizin.Name = "btntumizin";
            this.btntumizin.Size = new System.Drawing.Size(213, 30);
            this.btntumizin.TabIndex = 177;
            this.btntumizin.Text = "TÜM İZİNLER";
            this.btntumizin.UseVisualStyleBackColor = true;
            this.btntumizin.Click += new System.EventHandler(this.btntumizin_Click);
            // 
            // btnonayla
            // 
            this.btnonayla.Location = new System.Drawing.Point(5, 66);
            this.btnonayla.Name = "btnonayla";
            this.btnonayla.Size = new System.Drawing.Size(213, 30);
            this.btnonayla.TabIndex = 178;
            this.btnonayla.Text = "ONAYLANACAK İZİNLER";
            this.btnonayla.UseVisualStyleBackColor = true;
            this.btnonayla.Click += new System.EventHandler(this.btnonayla_Click);
            // 
            // btnonaylanan
            // 
            this.btnonaylanan.Location = new System.Drawing.Point(5, 113);
            this.btnonaylanan.Name = "btnonaylanan";
            this.btnonaylanan.Size = new System.Drawing.Size(213, 30);
            this.btnonaylanan.TabIndex = 179;
            this.btnonaylanan.Text = "ONAYLANAN İZİNLER";
            this.btnonaylanan.UseVisualStyleBackColor = true;
            this.btnonaylanan.Click += new System.EventHandler(this.btnonaylanan_Click);
            // 
            // btnguncelle
            // 
            this.btnguncelle.Location = new System.Drawing.Point(22, 216);
            this.btnguncelle.Name = "btnguncelle";
            this.btnguncelle.Size = new System.Drawing.Size(105, 23);
            this.btnguncelle.TabIndex = 180;
            this.btnguncelle.Text = "İZİN GÜNCELLE";
            this.btnguncelle.UseVisualStyleBackColor = true;
            this.btnguncelle.Click += new System.EventHandler(this.btnguncelle_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(128, 106);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker1.TabIndex = 181;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(128, 151);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker2.TabIndex = 182;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(710, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 183;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 184;
            this.label3.Text = "İSİM ARA:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btntumizin);
            this.groupBox1.Controls.Add(this.btnonayla);
            this.groupBox1.Controls.Add(this.btnonaylanan);
            this.groupBox1.Location = new System.Drawing.Point(22, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 150);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LİSTELE";
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(22, 245);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(105, 23);
            this.btnsil.TabIndex = 186;
            this.btnsil.Text = "İZİN SİL";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // frmogrenciizin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(850, 463);
            this.Controls.Add(this.btnsil);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnguncelle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnizin);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mskgun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtadsoyad);
            this.Name = "frmogrenciizin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÖĞRENCİ İZİN ONAYI";
            this.Load += new System.EventHandler(this.frmogrenciizin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtadsoyad;
        private System.Windows.Forms.MaskedTextBox mskgun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnizin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btntumizin;
        private System.Windows.Forms.Button btnonayla;
        private System.Windows.Forms.Button btnonaylanan;
        private System.Windows.Forms.Button btnguncelle;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnsil;
    }
}