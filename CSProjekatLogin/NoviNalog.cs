using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CSProjekatLogin
{
    public delegate Boolean ProveraPodataka(ref TextBox ime, ref TextBox prezime, ref TextBox korIme, ref TextBox lozinka,
         ref TextBox datRodj, ref TextBox idbr, ref TextBox jmbg, ref TextBox telefon);    
    public partial class NoviNalog : Form
    {
        Form1 forma;
        ProveraPodataka provera = new ProveraPodataka(ValidacijaPodataka.DelegatValidacija);
        public NoviNalog()
        {
            InitializeComponent();
        }
        public NoviNalog(Form1 forma) : this()
        {
            this.BackColor = Color.FromArgb(216, 219, 226);
            this.forma = forma;
            btnPovratak.Click += povratakNaPrijavu;
            btnKreirajNalog.Click += kreirajNalog;
            this.FormClosed += izlazakIzForme;
        }
        public void povratakNaPrijavu(object sender, EventArgs e)
        {
            forma.Visible = true;
            this.Close();
        }
        public void kreirajNalog(object sender, EventArgs e)
        {            
            Boolean proveraValidnosti = provera(ref txtIme,ref txtPrezime,ref txtKorisnickoIme,ref txtLozinka,
                ref txtDatumRodjenja,ref txtIDBR,ref txtJMBG,ref txtTelefon);
            if(proveraValidnosti == true)
            {
                Kupac k = new Kupac(txtIme.Text, txtPrezime.Text, txtKorisnickoIme.Text, txtLozinka.Text, txtDatumRodjenja.Text,
                    int.Parse(txtIDBR.Text), long.Parse(txtJMBG.Text), txtTelefon.Text);
                Boolean flag = k.dodajNoviNalog();
                if (flag == true)
                {
                    txtIDBR.Text = "";
                    txtJMBG.Text = "";
                    txtKorisnickoIme.Text = "";
                    txtTelefon.Text = "";
                }
                else
                {
                    txtIme.Text = "";
                    txtPrezime.Text = "";
                    txtKorisnickoIme.Text = "";
                    txtLozinka.Text = "";
                    txtDatumRodjenja.Text = "";
                    txtJMBG.Text = "";
                    txtTelefon.Text = "";
                    txtIDBR.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Podaci nisu pravilno popunjeni!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void izlazakIzForme(object sender, EventArgs e)
        {
            forma.Visible = true;
        }
        
    }
}
