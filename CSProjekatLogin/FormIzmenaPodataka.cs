using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSProjekatLogin
{
    public partial class FormIzmenaPodataka : Form
    {
        FormKupac forma;
        Kupac kupac;
        promenaSvojihPod promenaPod;
        ProveraPodataka provera = new ProveraPodataka(ValidacijaPodataka.DelegatValidacija);
        public FormIzmenaPodataka()
        {            
            InitializeComponent();
        }
        public FormIzmenaPodataka(promenaSvojihPod promenaPod,ref Korisnik kupac, FormKupac forma) : this()
        {
            this.forma = forma;
            this.kupac = kupac as Kupac;
            this.promenaPod = promenaPod;
            prikazSadasnjihPodataka(kupac);
            btnPovratakNaKupca.Click += povratakNaPočetnuStranu;
            this.FormClosed += povratakNaPočetnuStranu;
            btnAzurirajKupca.Click += izmenaSvojihPodataka;            
        }
        public void povratakNaPočetnuStranu(object sender, EventArgs e)
        {
            this.Hide();
            forma.Show();
        }
        public void prikazSadasnjihPodataka(Korisnik k)
        {
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            for (int i = 0; i < ListaKorisnika.Count; i++)
            {
                if (ListaKorisnika[i].Idbr == k.Idbr && ListaKorisnika[i] is Kupac)
                {
                    Kupac kup = ListaKorisnika[i] as Kupac;
                    txtIdbrKupca.Text = kup.Idbr.ToString();
                    txtImeKupca.Text = kup.Ime;
                    txtPrezimeKupca.Text = kup.Prezime;
                    txtJMBGKupca.Text = kup.Jmbg.ToString();
                    txtDatumRođKupca.Text = kup.DatumRodjenja;
                    txtTelefonKupca.Text = kup.Telefon;
                    txtKorImeKupca.Text = kup.KorisnickoIme;
                    txtLozinkaKupca.Text = kup.Lozinka;
                }
            }
            ListaKorisnika.Clear();
        }
        public void izmenaSvojihPodataka(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = provera(ref txtImeKupca, ref txtPrezimeKupca, ref txtKorImeKupca,
                ref txtLozinkaKupca, ref txtDatumRođKupca, ref txtIdbrKupca, ref txtJMBGKupca, ref txtTelefonKupca);
            if (proveraValidnosti == true)
            {
                Kupac kup = new Kupac(txtImeKupca.Text, txtPrezimeKupca.Text, txtKorImeKupca.Text, txtLozinkaKupca.Text,
                    txtDatumRođKupca.Text, int.Parse(txtIdbrKupca.Text), long.Parse(txtJMBGKupca.Text), txtTelefonKupca.Text);
                Boolean provera = kup.azurirajSvojePodatke();
                if (provera == false)
                {
                    txtKorImeKupca.Text = "";
                    txtTelefonKupca.Text = "";
                }
                else
                {
                    promenaPod(kup);
                    prikazSadasnjihPodataka(kup);
                }
            }
            else
            {
                MessageBox.Show("Niste pravilno popunili nove Podatke!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
