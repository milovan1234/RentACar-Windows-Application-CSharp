using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSProjekatLogin
{
    public delegate void promenaSvojihPod(Korisnik k);
    public partial class FormKupac : Form
    {
        public FormKupac()
        {
            InitializeComponent();
        }
        Form1 forma;
        Korisnik kupac;
        promenaSvojihPod promenaPod;
        public FormKupac(ref Kupac k, Form1 forma) : this()
        {
            this.BackColor = Color.FromArgb(216, 219, 226);
            this.kupac = k;
            this.forma = forma;            
            this.FormClosing += izlazakIzForme;
            btnOdjaviSe.Click += odjava;
            btnRezervisiNovi.Click += prelazakNaRezervaciju;
            this.Load += ispisRezervacija;
            //Brisanje rezervacije
            btnUkiniRezrevaciju.Click += brisanjeRezervacije;
            btnUkiniRezrevaciju.Click += ispisRezervacija;
            btnIzmenaSvojihPod.Click += prelazakNaIzmenuPodatka;
            //Pocetni Podaci
            popuniPocetnePodatke(k);
            promenaPod += popuniPocetnePodatke;
        }
        public void popuniPocetnePodatke(Korisnik k)
        {
            lblIdbrKupca.Text = k.Idbr.ToString();
            lblImePrezime.Text = k.Ime + " " + k.Prezime;
            lblDatRodj.Text = k.DatumRodjenja;
            lblKorIme.Text = k.KorisnickoIme;
        }
        public void odjava(object sender, EventArgs e)
        {
            forma.Visible = true;
            this.Close();
        }
        public void izlazakIzForme(object sender, EventArgs e)
        {
            forma.Visible = true;
        }
        public void prelazakNaRezervaciju(object sender, EventArgs e)
        {
            this.Hide();
            FormRezervacija rezervacija = new FormRezervacija(ref kupac, this);
            rezervacija.Show();
        }
        public void prelazakNaIzmenuPodatka(object sender, EventArgs e)
        {
            FormIzmenaPodataka izmenaPod = new FormIzmenaPodataka(promenaPod,ref kupac, this);
            izmenaPod.ShowDialog();
        }
        public void ispisRezervacija(object sender, EventArgs e)
        {
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            lbTrenutneRezervacije.Items.Clear();
            Boolean flag = false;
            for (int i = 0; i < ListaRez.Count; i++)
            {
                if (ListaRez[i].IdbrKupca == kupac.Idbr)
                {
                    lbTrenutneRezervacije.Items.Add(ListaRez[i]);
                    flag = true;
                }
            }
            if (flag == false)
            {
                lbTrenutneRezervacije.Items.Add("Trenutno nemate ni jednu zakazanu Rezervaciju!");
            }
            ListaRez.Clear();
        }
        public void brisanjeRezervacije(object sender, EventArgs e)
        {
            if (lbTrenutneRezervacije.SelectedIndex == -1)
            {
                MessageBox.Show("Ne možete da brišete jer niste odabrali ni jednu rezervaciju!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Object rez = lbTrenutneRezervacije.SelectedItem;
                Rezervacija rezervacija = rez as Rezervacija;
                rezervacija.brisanjeRezervacije();
            }
        }
    }
}
