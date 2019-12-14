namespace CSProjekatLogin
{
    partial class FormKupac
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
            this.lblUlazno = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblKorIme = new System.Windows.Forms.Label();
            this.lblDatRodj = new System.Windows.Forms.Label();
            this.lblImePrezime = new System.Windows.Forms.Label();
            this.lblIdbrKupca = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTrenutneRezervacije = new System.Windows.Forms.ListBox();
            this.btnRezervisiNovi = new System.Windows.Forms.Button();
            this.btnOdjaviSe = new System.Windows.Forms.Button();
            this.btnUkiniRezrevaciju = new System.Windows.Forms.Button();
            this.btnIzmenaSvojihPod = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUlazno
            // 
            this.lblUlazno.AutoSize = true;
            this.lblUlazno.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUlazno.Location = new System.Drawing.Point(12, 15);
            this.lblUlazno.Name = "lblUlazno";
            this.lblUlazno.Size = new System.Drawing.Size(526, 24);
            this.lblUlazno.TabIndex = 3;
            this.lblUlazno.Text = "Dobrodošli u aplikaciju za iznajmljivanje Automobila\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.lblKorIme);
            this.groupBox1.Controls.Add(this.lblDatRodj);
            this.groupBox1.Controls.Add(this.lblImePrezime);
            this.groupBox1.Controls.Add(this.lblIdbrKupca);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 180);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vaši Podaci:";
            // 
            // lblKorIme
            // 
            this.lblKorIme.AutoSize = true;
            this.lblKorIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKorIme.Location = new System.Drawing.Point(217, 142);
            this.lblKorIme.Name = "lblKorIme";
            this.lblKorIme.Size = new System.Drawing.Size(23, 18);
            this.lblKorIme.TabIndex = 8;
            this.lblKorIme.Text = "...";
            // 
            // lblDatRodj
            // 
            this.lblDatRodj.AutoSize = true;
            this.lblDatRodj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatRodj.Location = new System.Drawing.Point(217, 107);
            this.lblDatRodj.Name = "lblDatRodj";
            this.lblDatRodj.Size = new System.Drawing.Size(23, 18);
            this.lblDatRodj.TabIndex = 7;
            this.lblDatRodj.Text = "...";
            // 
            // lblImePrezime
            // 
            this.lblImePrezime.AutoSize = true;
            this.lblImePrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImePrezime.Location = new System.Drawing.Point(217, 71);
            this.lblImePrezime.Name = "lblImePrezime";
            this.lblImePrezime.Size = new System.Drawing.Size(23, 18);
            this.lblImePrezime.TabIndex = 6;
            this.lblImePrezime.Text = "...";
            // 
            // lblIdbrKupca
            // 
            this.lblIdbrKupca.AutoSize = true;
            this.lblIdbrKupca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdbrKupca.Location = new System.Drawing.Point(217, 34);
            this.lblIdbrKupca.Name = "lblIdbrKupca";
            this.lblIdbrKupca.Size = new System.Drawing.Size(23, 18);
            this.lblIdbrKupca.TabIndex = 5;
            this.lblIdbrKupca.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "IDBR Kupca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Korisničko ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Datum rođenja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime i Prezime:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Trenutne Rezervacije:";
            // 
            // lbTrenutneRezervacije
            // 
            this.lbTrenutneRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrenutneRezervacije.FormattingEnabled = true;
            this.lbTrenutneRezervacije.ItemHeight = 16;
            this.lbTrenutneRezervacije.Location = new System.Drawing.Point(17, 307);
            this.lbTrenutneRezervacije.Name = "lbTrenutneRezervacije";
            this.lbTrenutneRezervacije.ScrollAlwaysVisible = true;
            this.lbTrenutneRezervacije.Size = new System.Drawing.Size(723, 196);
            this.lbTrenutneRezervacije.TabIndex = 8;
            // 
            // btnRezervisiNovi
            // 
            this.btnRezervisiNovi.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRezervisiNovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervisiNovi.Image = global::CSProjekatLogin.Properties.Resources.savePravi;
            this.btnRezervisiNovi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRezervisiNovi.Location = new System.Drawing.Point(53, 509);
            this.btnRezervisiNovi.Name = "btnRezervisiNovi";
            this.btnRezervisiNovi.Size = new System.Drawing.Size(252, 50);
            this.btnRezervisiNovi.TabIndex = 9;
            this.btnRezervisiNovi.Text = "Rezervišite novi Automobil";
            this.btnRezervisiNovi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRezervisiNovi.UseVisualStyleBackColor = false;
            // 
            // btnOdjaviSe
            // 
            this.btnOdjaviSe.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOdjaviSe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdjaviSe.Image = global::CSProjekatLogin.Properties.Resources.izlazPravi;
            this.btnOdjaviSe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOdjaviSe.Location = new System.Drawing.Point(608, 9);
            this.btnOdjaviSe.Name = "btnOdjaviSe";
            this.btnOdjaviSe.Size = new System.Drawing.Size(132, 43);
            this.btnOdjaviSe.TabIndex = 4;
            this.btnOdjaviSe.Text = "Odjavite se";
            this.btnOdjaviSe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOdjaviSe.UseVisualStyleBackColor = false;
            // 
            // btnUkiniRezrevaciju
            // 
            this.btnUkiniRezrevaciju.BackColor = System.Drawing.Color.Red;
            this.btnUkiniRezrevaciju.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkiniRezrevaciju.Image = global::CSProjekatLogin.Properties.Resources.deletePravi;
            this.btnUkiniRezrevaciju.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUkiniRezrevaciju.Location = new System.Drawing.Point(448, 509);
            this.btnUkiniRezrevaciju.Name = "btnUkiniRezrevaciju";
            this.btnUkiniRezrevaciju.Size = new System.Drawing.Size(252, 50);
            this.btnUkiniRezrevaciju.TabIndex = 11;
            this.btnUkiniRezrevaciju.Text = "Ukinite Vašu Rezervaciju";
            this.btnUkiniRezrevaciju.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUkiniRezrevaciju.UseVisualStyleBackColor = false;
            // 
            // btnIzmenaSvojihPod
            // 
            this.btnIzmenaSvojihPod.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnIzmenaSvojihPod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmenaSvojihPod.Image = global::CSProjekatLogin.Properties.Resources.updatePravi;
            this.btnIzmenaSvojihPod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIzmenaSvojihPod.Location = new System.Drawing.Point(340, 245);
            this.btnIzmenaSvojihPod.Name = "btnIzmenaSvojihPod";
            this.btnIzmenaSvojihPod.Size = new System.Drawing.Size(163, 40);
            this.btnIzmenaSvojihPod.TabIndex = 12;
            this.btnIzmenaSvojihPod.Text = "Izmeni Podatke";
            this.btnIzmenaSvojihPod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIzmenaSvojihPod.UseVisualStyleBackColor = false;
            // 
            // FormKupac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 578);
            this.Controls.Add(this.btnIzmenaSvojihPod);
            this.Controls.Add(this.btnUkiniRezrevaciju);
            this.Controls.Add(this.btnRezervisiNovi);
            this.Controls.Add(this.lbTrenutneRezervacije);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOdjaviSe);
            this.Controls.Add(this.lblUlazno);
            this.Name = "FormKupac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormKupac";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUlazno;
        private System.Windows.Forms.Button btnOdjaviSe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblKorIme;
        private System.Windows.Forms.Label lblDatRodj;
        private System.Windows.Forms.Label lblImePrezime;
        private System.Windows.Forms.Label lblIdbrKupca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbTrenutneRezervacije;
        private System.Windows.Forms.Button btnRezervisiNovi;
        private System.Windows.Forms.Button btnUkiniRezrevaciju;
        private System.Windows.Forms.Button btnIzmenaSvojihPod;
    }
}