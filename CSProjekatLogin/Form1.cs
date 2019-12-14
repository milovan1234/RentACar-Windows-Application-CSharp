using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;

namespace CSProjekatLogin
{
    public partial class Form1 : Form
    {      
        public Form1()
        {            
            InitializeComponent();
            txtKorisnickoIme.Focus();
            this.BackColor = Color.FromArgb(216, 219, 226);
            btnPrijaviSe.Click += prijaviSe;
            btnNoviNalog.Click += napraviNalog;            
            if (File.Exists("login.xml") == false)
            {
                List<Korisnik> ListaKorisnika = new List<Korisnik>();
                ListaKorisnika.Add(new Administrator("Milovan", "Srejić", "admin", "admin", "31/01/1998", 1, "Glavni administrator"));
                try
                {
                    FileStream fs = new FileStream("login.xml", FileMode.Create);
                    SoapFormatter soapform = new SoapFormatter();
                    foreach (Administrator a in ListaKorisnika)
                    {
                        soapform.Serialize(fs, a);
                    }
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void prijaviSe(object sender, EventArgs e)
        {
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            Boolean flag = false;
            foreach (Korisnik k in ListaKorisnika)
            {
                if ((txtKorisnickoIme.Text == k.KorisnickoIme) && (txtLozinka.Text == k.Lozinka))
                {
                    flag = true;
                    if (k is Administrator)
                    {
                        Administrator a = k as Administrator;
                        FormAdmin admin = new FormAdmin(ref a, this);
                        this.Visible = false;
                        admin.Show();
                    }
                    else if (k is Kupac)
                    {
                        Kupac ku = k as Kupac;
                        FormKupac kupac = new FormKupac(ref ku, this);
                        this.Visible = false;
                        kupac.Show();
                    }
                }
            }
            if (flag == false)
            {
                MessageBox.Show("Podatke koje ste uneli ne postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtKorisnickoIme.Text = "";
            txtLozinka.Text = "";
        }
        public void napraviNalog(object sender, EventArgs e)
        {
            NoviNalog nalog = new NoviNalog(this);
            this.Visible = false;
            txtKorisnickoIme.Text = "";
            txtLozinka.Text = "";
            nalog.Show();
        }
    }
}
