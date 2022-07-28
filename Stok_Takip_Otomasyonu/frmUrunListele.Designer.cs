
namespace Stok_Takip_Otomasyonu
{
    partial class frmUrunListele
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SatisFiyatitxt = new System.Windows.Forms.TextBox();
            this.AlisFiyatitxt = new System.Windows.Forms.TextBox();
            this.Miktartxt = new System.Windows.Forms.TextBox();
            this.Urunaditxt = new System.Windows.Forms.TextBox();
            this.Markatxt = new System.Windows.Forms.TextBox();
            this.Kategoritxt = new System.Windows.Forms.TextBox();
            this.Barkodnotxt = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtBarkodNoAra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboKategori = new System.Windows.Forms.ComboBox();
            this.comboMarka = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKatMarkaGuncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(353, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(594, 313);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(49, 446);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(0, 17);
            this.lblMiktar.TabIndex = 41;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(156, 418);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(131, 45);
            this.btnGuncelle.TabIndex = 40;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "Satış Fiyatı :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 38;
            this.label9.Text = "Alış Fiyatı :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(88, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Miktarı :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(74, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Ürün Adı :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(90, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Marka :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 34;
            this.label13.Text = "Kategori :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(62, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 17);
            this.label14.TabIndex = 33;
            this.label14.Text = "Barkod No :";
            // 
            // SatisFiyatitxt
            // 
            this.SatisFiyatitxt.Location = new System.Drawing.Point(176, 369);
            this.SatisFiyatitxt.Name = "SatisFiyatitxt";
            this.SatisFiyatitxt.Size = new System.Drawing.Size(100, 22);
            this.SatisFiyatitxt.TabIndex = 32;
            // 
            // AlisFiyatitxt
            // 
            this.AlisFiyatitxt.Location = new System.Drawing.Point(176, 329);
            this.AlisFiyatitxt.Name = "AlisFiyatitxt";
            this.AlisFiyatitxt.Size = new System.Drawing.Size(100, 22);
            this.AlisFiyatitxt.TabIndex = 31;
            // 
            // Miktartxt
            // 
            this.Miktartxt.Location = new System.Drawing.Point(176, 289);
            this.Miktartxt.Name = "Miktartxt";
            this.Miktartxt.Size = new System.Drawing.Size(100, 22);
            this.Miktartxt.TabIndex = 30;
            // 
            // Urunaditxt
            // 
            this.Urunaditxt.Location = new System.Drawing.Point(176, 249);
            this.Urunaditxt.Name = "Urunaditxt";
            this.Urunaditxt.Size = new System.Drawing.Size(100, 22);
            this.Urunaditxt.TabIndex = 29;
            // 
            // Markatxt
            // 
            this.Markatxt.Location = new System.Drawing.Point(176, 209);
            this.Markatxt.Name = "Markatxt";
            this.Markatxt.ReadOnly = true;
            this.Markatxt.Size = new System.Drawing.Size(100, 22);
            this.Markatxt.TabIndex = 28;
            // 
            // Kategoritxt
            // 
            this.Kategoritxt.Location = new System.Drawing.Point(176, 169);
            this.Kategoritxt.Name = "Kategoritxt";
            this.Kategoritxt.ReadOnly = true;
            this.Kategoritxt.Size = new System.Drawing.Size(100, 22);
            this.Kategoritxt.TabIndex = 27;
            // 
            // Barkodnotxt
            // 
            this.Barkodnotxt.Location = new System.Drawing.Point(176, 129);
            this.Barkodnotxt.Name = "Barkodnotxt";
            this.Barkodnotxt.Size = new System.Drawing.Size(100, 22);
            this.Barkodnotxt.TabIndex = 26;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(855, 79);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(92, 37);
            this.btnSil.TabIndex = 42;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtBarkodNoAra
            // 
            this.txtBarkodNoAra.Location = new System.Drawing.Point(544, 79);
            this.txtBarkodNoAra.Name = "txtBarkodNoAra";
            this.txtBarkodNoAra.Size = new System.Drawing.Size(100, 22);
            this.txtBarkodNoAra.TabIndex = 43;
            this.txtBarkodNoAra.TextChanged += new System.EventHandler(this.txtBarkodNoAra_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "BarkoNo ya Göre Ara : ";
            // 
            // comboKategori
            // 
            this.comboKategori.FormattingEnabled = true;
            this.comboKategori.Location = new System.Drawing.Point(435, 476);
            this.comboKategori.Name = "comboKategori";
            this.comboKategori.Size = new System.Drawing.Size(121, 24);
            this.comboKategori.TabIndex = 45;
            this.comboKategori.SelectedIndexChanged += new System.EventHandler(this.comboKategori_SelectedIndexChanged);
            // 
            // comboMarka
            // 
            this.comboMarka.FormattingEnabled = true;
            this.comboMarka.Location = new System.Drawing.Point(710, 472);
            this.comboMarka.Name = "comboMarka";
            this.comboMarka.Size = new System.Drawing.Size(121, 24);
            this.comboMarka.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "Marka :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Kategori :";
            // 
            // btnKatMarkaGuncelle
            // 
            this.btnKatMarkaGuncelle.Location = new System.Drawing.Point(544, 529);
            this.btnKatMarkaGuncelle.Name = "btnKatMarkaGuncelle";
            this.btnKatMarkaGuncelle.Size = new System.Drawing.Size(131, 58);
            this.btnKatMarkaGuncelle.TabIndex = 49;
            this.btnKatMarkaGuncelle.Text = "Kategori Marka Güncelle";
            this.btnKatMarkaGuncelle.UseVisualStyleBackColor = true;
            this.btnKatMarkaGuncelle.Click += new System.EventHandler(this.btnKatMarkaGuncelle_Click);
            // 
            // frmUrunListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1073, 599);
            this.Controls.Add(this.btnKatMarkaGuncelle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboMarka);
            this.Controls.Add(this.comboKategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarkodNoAra);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.SatisFiyatitxt);
            this.Controls.Add(this.AlisFiyatitxt);
            this.Controls.Add(this.Miktartxt);
            this.Controls.Add(this.Urunaditxt);
            this.Controls.Add(this.Markatxt);
            this.Controls.Add(this.Kategoritxt);
            this.Controls.Add(this.Barkodnotxt);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmUrunListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Listeleme Sayfası";
            this.Load += new System.EventHandler(this.frmUrunListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SatisFiyatitxt;
        private System.Windows.Forms.TextBox AlisFiyatitxt;
        private System.Windows.Forms.TextBox Miktartxt;
        private System.Windows.Forms.TextBox Urunaditxt;
        private System.Windows.Forms.TextBox Markatxt;
        private System.Windows.Forms.TextBox Kategoritxt;
        private System.Windows.Forms.TextBox Barkodnotxt;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtBarkodNoAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboKategori;
        private System.Windows.Forms.ComboBox comboMarka;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKatMarkaGuncelle;
    }
}