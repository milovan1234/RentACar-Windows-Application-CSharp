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
    public partial class FormAdmin : Form
    {
        Form1 forma;
        Administrator admin;
        ProveraPodataka provera = new ProveraPodataka(ValidacijaPodataka.DelegatValidacija);
        public FormAdmin()
        {
            InitializeComponent();
        }
        public FormAdmin(ref Administrator a, Form1 forma) : this()
        {
            //Globalno
            btnOdjaviSe.Click += Odjava;
            this.forma = forma;
            this.FormClosed += izlazakIzForme;
            this.BackColor = Color.FromArgb(216, 219, 226);
            lbPrikazRezervacija.BackColor = Color.FromArgb(216, 219, 226);
            //Automobil
            btnDodajNoviAuto.Click += dodajNoviAuto;
            this.Load += prikazTrenutnihAutomobila;
            btnDodajNoviAuto.Click += prikazTrenutnihAutomobila;
            cbSviAutomobili.SelectedIndexChanged += selektujIspisi;
            btnUkloniAuto.Click += brisanjeAutomobila;
            btnUkloniAuto.Click += prikazTrenutnihAutomobila;
            btnUkloniAuto.Click += prikazTrenutnihPonuda;
            btnOcistiPolja.Click += ocistiPolja;           
            btnAzurirajAuto.Click += azuriranjeAutomobila;
            btnAzurirajAuto.Click += prikazTrenutnihAutomobila;
            btnAzurirajAuto.Click += prikazTrenutnihPonuda;
            //Kupac
            this.Load += prikazTrenutnihKupaca;
            btnDodajKupca.Click += dodajKupca;
            cbSviKupci.SelectedIndexChanged += selektujIspisiKupca;
            btnOcistiPolja1.Click += ocistiPoljaKupac;
            btnDodajKupca.Click += prikazTrenutnihKupaca;
            btnUkloniKupca.Click += brisanjeKupca;
            btnUkloniKupca.Click += prikazTrenutnihKupaca;
            btnUkloniKupca.Click += prikazIDBRKupaca;
            btnAzurirajKupca.Click += azuriranjeKupca;
            btnAzurirajKupca.Click += prikazTrenutnihKupaca;
            btnAzurirajKupca.Click += prikazIDBRKupaca;
            //Ponuda
            this.Load += prikazTrenutnihPonuda;
            btnDodajNovuPonudu.Click += dodajNovuPonudu;
            btnDodajNovuPonudu.Click += prikazTrenutnihPonuda;
            btnOcistiPoljaPonuda.Click += ocistiPoljaPonuda;
            cbSvePonude.SelectedIndexChanged += selektujIspisiPonudu;
            btnUkloniPonudu.Click += brisanjePonude;
            btnUkloniPonudu.Click += prikazTrenutnihPonuda;
            chbAzuriranje.CheckedChanged += omoguciAzuriranje;
            btnAzurirajPonudu.Click += azuriranjePonude;
            btnAzurirajPonudu.Click += prikazTrenutnihPonuda;
            //Admin
            admin = a;
            this.Load += prikazTrenutnihAdmina;
            this.Load += prikazPoTituli;
            lblIspisAdmina.Text = a.ispisPodataka();
            btnDodajNovogAdmina.Click += dodajNovogAdmina;
            btnDodajNovogAdmina.Click += prikazTrenutnihAdmina;
            btnOcistiPoljaAdmin.Click += ocistiPoljaAdmin;
            if(admin.TitulaAdmina == "Glavni administrator")
                cbTrenutniAdmini.SelectedIndexChanged += selektujIspisiAdmina;
            btnAzurirajAdmina.Click += azurirajAdmina;
            btnAzurirajAdmina.Click += prikazTrenutnihAdmina;
            btnUkloniAdmina.Click += ukloniAdmina;
            btnUkloniAdmina.Click += prikazTrenutnihAdmina;
            btnAzurirajSvojePo.Click += azuriranjeAdminaSvojiPodaci;
            btnAzurirajSvojePo.Click += prikazTrenutnihAdmina;
            //Rezervacija
            this.Load += prikazIDBRKupaca;
            this.Load += prikazRezervacijaPoIdbr;
            cbSviIDBRKupca.SelectedIndexChanged += prikazRezervacijaPoIdbr;
            btnUkloniRezervaciju.Click += brisanjeRezervacije;
            btnUkloniRezervaciju.Click += prikazRezervacijaPoIdbr;
            btnOcistiPoljaRez.Click += ocistiPoljaRezervacija;
            //Statistika
            this.Load += popuniMesecima;
            cbMeseci.SelectedIndexChanged += iscrtavanjeGrafika;
            cbGodina.SelectedIndexChanged += iscrtavanjeGrafika;
        }
        public void Odjava(object sender, EventArgs e)
        {
            forma.Visible = true;
            this.Close();
        }
        public void izlazakIzForme(object sender, EventArgs e)
        {
            forma.Visible = true;
        }

        //Automobil
        public void dodajNoviAuto(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaNovogAutomobila(ref txtIDBR,ref txtMarka,ref txtModel,
                ref txtGodiste,ref txtKubikaza,ref cbPogon,ref cbVrstaMenjaca,ref cbKaroserija,ref cbGorivo,ref cbBrojVrata);
            if (proveraValidnosti == true)
            {
                Automobil a = new Automobil(int.Parse(txtIDBR.Text), txtMarka.Text, txtModel.Text, int.Parse(txtGodiste.Text),
                    int.Parse(txtKubikaza.Text), cbPogon.Text, cbVrstaMenjaca.Text, cbKaroserija.Text, cbGorivo.Text, int.Parse(cbBrojVrata.Text));
                Boolean flag = a.dodajNoviAutomobil();
                if (flag == true)
                {
                    txtIDBR.Text = "";
                }
                else
                {
                    cbSviAutomobili.Text = "";
                    txtNoviIDBR.Text = "";
                    txtIDBR.Text = "";
                    txtMarka.Text = "";
                    txtModel.Text = "";
                    txtGodiste.Text = "";
                    txtKubikaza.Text = "";
                    cbPogon.SelectedIndex = -1;
                    cbVrstaMenjaca.SelectedIndex = -1;
                    cbKaroserija.SelectedIndex = -1;
                    cbGorivo.SelectedIndex = -1;
                    cbBrojVrata.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Podaci o Automobilu nisu pravilno popunjeni!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void prikazTrenutnihAutomobila(object sender, EventArgs e)
        {
            Automobil pom = null;
            List<Automobil> ListaAutomobila = new List<Automobil>();
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            cbSviAutomobili.Items.Clear();
            for (int i = 0; i < ListaAutomobila.Count - 1; i++)
            {
                for (int j = i + 1; j < ListaAutomobila.Count; j++)
                {
                    if (ListaAutomobila[i].Idbr > ListaAutomobila[j].Idbr)
                    {
                        pom = ListaAutomobila[i];
                        ListaAutomobila[i] = ListaAutomobila[j];
                        ListaAutomobila[j] = pom;
                    }
                }
            }
            foreach (Automobil a in ListaAutomobila)
            {
                cbSviAutomobili.Items.Add(a);
            }
            ListaAutomobila.Clear();
        }
        public void brisanjeAutomobila(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaIdbrBrisanje(ref txtIDBR);
            if (proveraValidnosti == true)
            {
                Automobil a = new Automobil(int.Parse(txtIDBR.Text));
                a.ukloniAuto();
                cbSviAutomobili.Text = "";
                txtNoviIDBR.Text = "";
                txtIDBR.Text = "";
                txtMarka.Text = "";
                txtModel.Text = "";
                txtGodiste.Text = "";
                txtKubikaza.Text = "";
                cbPogon.SelectedIndex = -1;
                cbVrstaMenjaca.SelectedIndex = -1;
                cbKaroserija.SelectedIndex = -1;
                cbGorivo.SelectedIndex = -1;
                cbBrojVrata.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("IDBR Automobila koji želite da obrišete nije lepo popunjen!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void selektujIspisi(object sender, EventArgs e)
        {
            Object auto = cbSviAutomobili.SelectedItem;
            Automobil at = auto as Automobil;
            txtIDBR.Text = at.Idbr.ToString();
            txtMarka.Text = at.Marka.ToString();
            txtModel.Text = at.Model.ToString();
            txtGodiste.Text = at.Godiste.ToString();
            txtKubikaza.Text = at.Kubikaza.ToString();
            cbPogon.Text = at.Pogon.ToString();
            cbVrstaMenjaca.Text = at.VrstaMenjaca.ToString();
            cbKaroserija.Text = at.Karoserija.ToString();
            cbGorivo.Text = at.Gorivo.ToString();
            cbBrojVrata.Text = at.BrojVrata.ToString();
            txtNoviIDBR.Text = "";
        }
        public void ocistiPolja(object sender, EventArgs e)
        {
            txtNoviIDBR.Text = "";
            txtIDBR.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            txtGodiste.Text = "";
            txtKubikaza.Text = "";
            cbPogon.SelectedIndex = -1;
            cbVrstaMenjaca.SelectedIndex = -1;
            cbKaroserija.SelectedIndex = -1;
            cbGorivo.SelectedIndex = -1;
            cbBrojVrata.SelectedIndex = -1;
            cbSviAutomobili.Text = "";
        }
        public void azuriranjeAutomobila(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaNovogAutomobila(ref txtIDBR, ref txtMarka, ref txtModel,
                ref txtGodiste, ref txtKubikaza, ref cbPogon, ref cbVrstaMenjaca, ref cbKaroserija, ref cbGorivo, ref cbBrojVrata);
            Boolean proveraValidnostiNovogIdbr = ValidacijaPodataka.validacijaIdbrAzuriranje(ref txtNoviIDBR);
            if (proveraValidnosti == true && proveraValidnostiNovogIdbr == true)
            {
                Automobil a = new Automobil(int.Parse(txtIDBR.Text), txtMarka.Text, txtModel.Text, int.Parse(txtGodiste.Text),
                    int.Parse(txtKubikaza.Text), cbPogon.Text, cbVrstaMenjaca.Text, cbKaroserija.Text, cbGorivo.Text, int.Parse(cbBrojVrata.Text));
                a.azurirajAutomobil(int.Parse(txtNoviIDBR.Text));
                cbSviAutomobili.Text = "";
                txtNoviIDBR.Text = "";
                txtIDBR.Text = "";
                txtMarka.Text = "";
                txtModel.Text = "";
                txtGodiste.Text = "";
                txtKubikaza.Text = "";
                cbPogon.SelectedIndex = -1;
                cbVrstaMenjaca.SelectedIndex = -1;
                cbKaroserija.SelectedIndex = -1;
                cbGorivo.SelectedIndex = -1;
                cbBrojVrata.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Podaci o Automobilu nisu pravilno popunjeni ili novi IDBR Automobila nije validan!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Kupac
        public void prikazTrenutnihKupaca(object sender, EventArgs e)
        {
            Korisnik pom = null;
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            cbSviKupci.Items.Clear();
            for (int i = 0; i < ListaKorisnika.Count-1; i++)
            {
                for (int j = i + 1; j < ListaKorisnika.Count; j++)
                {
                    if (ListaKorisnika[i].Idbr > ListaKorisnika[j].Idbr)
                    {
                        pom = ListaKorisnika[i];
                        ListaKorisnika[i] = ListaKorisnika[j];
                        ListaKorisnika[j] = pom;
                    }
                }
            }
            foreach (Korisnik k in ListaKorisnika)
            {
                if (k is Kupac)
                {
                    cbSviKupci.Items.Add(k);
                }
            }
            ListaKorisnika.Clear();
        }
        public void selektujIspisiKupca(object sender, EventArgs e)
        {
            Object kupac = cbSviKupci.SelectedItem;
            Kupac ku = kupac as Kupac;
            txtIdbrKupca.Text = ku.Idbr.ToString();
            txtImeKupca.Text = ku.Ime.ToString();
            txtPrezimeKupca.Text = ku.Prezime.ToString();
            txtDatumRođKupca.Text = ku.DatumRodjenja.ToString();
            txtKorImeKupca.Text = ku.KorisnickoIme.ToString();
            txtLozinkaKupca.Text = ku.Lozinka.ToString();
            txtTelefonKupca.Text = ku.Telefon.ToString();
            txtJMBGKupca.Text = ku.Jmbg.ToString();
        }
        public void ocistiPoljaKupac(object sender, EventArgs e)
        {
            txtIdbrKupca.Text = "";
            txtImeKupca.Text = "";
            txtPrezimeKupca.Text = "";
            txtDatumRođKupca.Text = "";
            txtKorImeKupca.Text = "";
            txtLozinkaKupca.Text = "";
            txtTelefonKupca.Text = "";
            txtJMBGKupca.Text = "";
            cbSviKupci.Text = "";
            txtNoviIdbrKupca.Text = "";
        }
        public void dodajKupca(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = provera(ref txtImeKupca,ref txtPrezimeKupca,ref txtKorImeKupca,
                ref txtLozinkaKupca,ref txtDatumRođKupca,ref txtIdbrKupca,ref txtJMBGKupca,ref txtTelefonKupca);
            if (proveraValidnosti == true)
            {
                Kupac k = new Kupac(txtImeKupca.Text, txtPrezimeKupca.Text, txtKorImeKupca.Text, txtLozinkaKupca.Text,
                    txtDatumRođKupca.Text, int.Parse(txtIdbrKupca.Text), long.Parse(txtJMBGKupca.Text), txtTelefonKupca.Text);
                Boolean flag = Administrator.dodajNovogKupca(ref k);
                if (flag == true)
                {
                    txtIdbrKupca.Text = "";
                    txtJMBGKupca.Text = "";
                    txtTelefonKupca.Text = "";
                    txtKorImeKupca.Text = "";                    
                }
                else
                {
                    txtIdbrKupca.Text = "";
                    txtImeKupca.Text = "";
                    txtPrezimeKupca.Text = "";
                    txtDatumRođKupca.Text = "";
                    txtKorImeKupca.Text = "";
                    txtLozinkaKupca.Text = "";
                    txtTelefonKupca.Text = "";
                    txtJMBGKupca.Text = "";
                    cbSviKupci.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Podaci nisu pravilno popunjeni!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void azuriranjeKupca(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = provera(ref txtImeKupca, ref txtPrezimeKupca, ref txtKorImeKupca,
                ref txtLozinkaKupca, ref txtDatumRođKupca, ref txtIdbrKupca, ref txtJMBGKupca, ref txtTelefonKupca);
            Boolean proveraValidnostiNovogIdbr = ValidacijaPodataka.validacijaIdbrAzuriranje(ref txtNoviIdbrKupca);
            if (proveraValidnosti == true && proveraValidnostiNovogIdbr == true)
            {
                Kupac k = new Kupac(txtImeKupca.Text, txtPrezimeKupca.Text, txtKorImeKupca.Text, txtLozinkaKupca.Text,
                    txtDatumRođKupca.Text, int.Parse(txtIdbrKupca.Text), long.Parse(txtJMBGKupca.Text), txtTelefonKupca.Text);
                Administrator.azurirajKupca(int.Parse(txtNoviIdbrKupca.Text),ref k);
                cbSviKupci.Text = "";
                txtIdbrKupca.Text = "";
                txtImeKupca.Text = "";
                txtPrezimeKupca.Text = "";
                txtDatumRođKupca.Text = "";
                txtKorImeKupca.Text = "";
                txtLozinkaKupca.Text = "";
                txtTelefonKupca.Text = "";
                txtJMBGKupca.Text = "";
                cbSviKupci.Text = "";
                txtNoviIdbrKupca.Text = "";
            }
            else
            {
                MessageBox.Show("Podaci o Kupcu nisu pravilno popunjeni ili novi IDBR Kupca nije validan!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void brisanjeKupca(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaIdbrBrisanje(ref txtIdbrKupca);
            if (proveraValidnosti == true)
            {
                Kupac k = new Kupac(int.Parse(txtIdbrKupca.Text));
                Administrator.ukloniKupca(ref k);
                txtIdbrKupca.Text = "";
                txtImeKupca.Text = "";
                txtPrezimeKupca.Text = "";
                txtDatumRođKupca.Text = "";
                txtKorImeKupca.Text = "";
                txtLozinkaKupca.Text = "";
                txtTelefonKupca.Text = "";
                txtJMBGKupca.Text = "";
                cbSviKupci.Text = "";
            }
            else
            {
                MessageBox.Show("IDBR Kupca koji želite da obrišete nije lepo popunjen!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Ponuda
        public void dodajNovuPonudu(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaNovePonude(ref txtIDBRAutPonuda,ref txtCenaPoDanu,
                dtpDatumOd.Value,dtpDatumDo.Value);
            if (proveraValidnosti == true)
            {
                Ponuda p = new Ponuda(int.Parse(txtIDBRAutPonuda.Text), int.Parse(txtCenaPoDanu.Text), 
                    dtpDatumOd.Value, dtpDatumDo.Value);
                Boolean proveraKreiranje = p.dodajNovuPonudu();
                if (proveraKreiranje == true)
                {
                    MessageBox.Show("Uspešno ste dodali novu Ponudu u sistem!");
                    txtIDBRAutPonuda.Text = "";
                    txtCenaPoDanu.Text = "";
                    dtpDatumOd.Value = DateTime.Now;
                    dtpDatumDo.Value = DateTime.Now;
                    cbSvePonude.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Podaci koje ste uneli nisu pravilno popunjeni!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDatumOd.Value = DateTime.Now;
                dtpDatumDo.Value = DateTime.Now;
            }
        }
        public void brisanjePonude(object sender, EventArgs e)
        {
            Boolean proveraValidnostiIDBR = ValidacijaPodataka.validacijaIdbrBrisanje(ref txtIDBRAutPonuda);
            if (proveraValidnostiIDBR == true)
            {
                Ponuda p = new Ponuda(int.Parse(txtIDBRAutPonuda.Text), dtpDatumOd.Value, dtpDatumDo.Value);
                p.ukloniPonudu();
                txtIDBRAutPonuda.Text = "";
                txtCenaPoDanu.Text = "";
                dtpDatumOd.Value = DateTime.Now;
                dtpDatumDo.Value = DateTime.Now;
                cbSvePonude.Text = "";
            }
            else
            {
                MessageBox.Show("IDBR Automobila u Ponudi preko koga brišemo ponudu nije validan!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void azuriranjePonude(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaNovePonude(ref txtIDBRAutPonuda,ref txtCenaPoDanu,
                dtpDatumOd.Value, dtpDatumDo.Value);
            Boolean proveraValidnostiNovihDatuma = ValidacijaPodataka.validacijaNovihDatuma(dtpNoviDatumOd.Value, dtpNoviDatumDo.Value);
            if (proveraValidnosti == true && proveraValidnostiNovihDatuma == true)
            {
                Ponuda p = new Ponuda(int.Parse(txtIDBRAutPonuda.Text),int.Parse(txtCenaPoDanu.Text), dtpDatumOd.Value, dtpDatumDo.Value);
                p.azuriranjePonude(dtpNoviDatumOd.Value,dtpNoviDatumDo.Value);
                txtIDBRAutPonuda.Text = "";
                txtCenaPoDanu.Text = "";
                dtpDatumOd.Value = DateTime.Now;
                dtpDatumDo.Value = DateTime.Now;
                cbSvePonude.Text = "";
            }
            else
            {
                MessageBox.Show("Podaci o Ponudi nisu pravilno popunjeni!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void prikazTrenutnihPonuda(object sender, EventArgs e)
        {
            List<Ponuda> ListaPonuda = new List<Ponuda>();
            Ponuda pom = null;
            RadSaDatotekama.citanjePonudeDatoteke(ref ListaPonuda);
            for (int i = 0; i < ListaPonuda.Count - 1; i++)
            {
                for (int j = i + 1; j < ListaPonuda.Count; j++)
                {
                    if ((ListaPonuda[i].IdbrAutomobila > ListaPonuda[j].IdbrAutomobila) ||
                        ((ListaPonuda[i].IdbrAutomobila == ListaPonuda[j].IdbrAutomobila) &&
                        ListaPonuda[i].DatumOd.Date > ListaPonuda[j].DatumOd.Date))
                    {
                        pom = ListaPonuda[i];
                        ListaPonuda[i] = ListaPonuda[j];
                        ListaPonuda[j] = pom;
                    }
                }
            }
            cbSvePonude.Items.Clear();
            foreach (Ponuda p in ListaPonuda)
            {
                cbSvePonude.Items.Add(p);
            }
            ListaPonuda.Clear();
        }
        public void ocistiPoljaPonuda(object sender, EventArgs e)
        {
            txtIDBRAutPonuda.Text = "";
            txtCenaPoDanu.Text = "";
            dtpDatumOd.Value = DateTime.Now;
            dtpNoviDatumOd.Value = DateTime.Now;
            dtpDatumDo.Value = DateTime.Now;
            dtpNoviDatumDo.Value = DateTime.Now;
            cbSvePonude.Text = "";
        }
        public void selektujIspisiPonudu(object sender, EventArgs e)
        {
            Object ponuda = cbSvePonude.SelectedItem;
            Ponuda p = ponuda as Ponuda;
            txtIDBRAutPonuda.Text = p.IdbrAutomobila.ToString();
            txtCenaPoDanu.Text = p.CenaPoDanu.ToString();
            dtpDatumOd.Value = p.DatumOd;
            dtpDatumDo.Value = p.DatumDo;
        }
        public void omoguciAzuriranje(object sender, EventArgs e)
        {
            if (chbAzuriranje.Checked)
            {
                lblNoviDatumOd.Visible = true;
                lblNoviDatumDo.Visible = true;
                dtpNoviDatumOd.Visible = true;
                dtpNoviDatumDo.Visible = true;
                dtpNoviDatumOd.Value = DateTime.Now;
                dtpNoviDatumDo.Value = DateTime.Now;
                btnAzurirajPonudu.Enabled = true;
                lblAzuriranje1.Show();
                label72.Show();
            }
            else
            {
                lblNoviDatumOd.Visible = false;
                lblNoviDatumDo.Visible = false;
                dtpNoviDatumOd.Visible = false;
                dtpNoviDatumDo.Visible = false;
                btnAzurirajPonudu.Enabled = false;
                lblAzuriranje1.Hide();
                label72.Hide();
            }
        }

        //Admin
        public void prikazPoTituli(object sender, EventArgs e)
        {
            if (admin.TitulaAdmina == "administrator")
            {
                btnDodajNovogAdmina.Hide();
                btnUkloniAdmina.Hide();
                btnAzurirajAdmina.Hide();
                btnAzurirajSvojePo.Show();
                lblGlavni.Hide();
                lblObican.Show();
            }
            else if (admin.TitulaAdmina == "Glavni administrator")
            {
                btnDodajNovogAdmina.Show();
                btnUkloniAdmina.Show();
                btnAzurirajAdmina.Show();
                btnAzurirajSvojePo.Hide();
                lblGlavni.Show();
                lblObican.Hide();
            }
        }
        public void dodajNovogAdmina(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaAdmina(ref txtIDBRAdmina,ref txtImeAdmina,
                ref txtPrezimeAdmina,ref txtKorImeAdmina,ref txtLozinkaAdmina,ref txtDatumRodjenjaAdmina,
                ref txtTitulaAdmina);
            if (proveraValidnosti == true)
            {
                Administrator a = new Administrator(txtImeAdmina.Text, txtPrezimeAdmina.Text, txtKorImeAdmina.Text,
                    txtLozinkaAdmina.Text, txtDatumRodjenjaAdmina.Text, int.Parse(txtIDBRAdmina.Text), txtTitulaAdmina.Text);
                Boolean proveraDodavanja = a.dodajNovogAdmina();
                if (proveraDodavanja == false)
                {
                    txtIDBRAdmina.Text = "";
                    txtImeAdmina.Text = "";
                    txtPrezimeAdmina.Text = "";
                    txtKorImeAdmina.Text = "";
                    txtLozinkaAdmina.Text = "";
                    txtDatumRodjenjaAdmina.Text = "";
                    txtTitulaAdmina.Text = "";
                    txtNoviIDBRAdmina.Text = "";
                    cbTrenutniAdmini.Text = "";
                }
                else
                {
                    txtKorImeAdmina.Text = "";
                    txtIDBRAdmina.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Uneti podaci nisu pravilno popunjeni!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ocistiPoljaAdmin(object sender, EventArgs e)
        {
            txtIDBRAdmina.Text = "";
            txtImeAdmina.Text = "";
            txtPrezimeAdmina.Text = "";
            txtKorImeAdmina.Text = "";
            txtLozinkaAdmina.Text = "";
            txtDatumRodjenjaAdmina.Text = "";
            txtTitulaAdmina.Text = "";
            txtNoviIDBRAdmina.Text = "";
            cbTrenutniAdmini.Text = "";
        }
        public void prikazTrenutnihAdmina(object sender, EventArgs e)
        {
            Korisnik pom = null;
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            cbTrenutniAdmini.Items.Clear();
            for (int i = 0; i < ListaKorisnika.Count - 1; i++)
            {
                for (int j = i + 1; j < ListaKorisnika.Count; j++)
                {
                    if (ListaKorisnika[i].Idbr > ListaKorisnika[j].Idbr)
                    {
                        pom = ListaKorisnika[i];
                        ListaKorisnika[i] = ListaKorisnika[j];
                        ListaKorisnika[j] = pom;
                    }
                }
            }
            foreach (Korisnik k in ListaKorisnika)
            {
                if (k is Administrator)
                {
                    cbTrenutniAdmini.Items.Add(k);
                }
            }
            ListaKorisnika.Clear();
        }
        public void selektujIspisiAdmina(object sender, EventArgs e)
        {
            Object admin = cbTrenutniAdmini.SelectedItem;
            Administrator a = admin as Administrator;
            txtIDBRAdmina.Text = a.Idbr.ToString();
            txtImeAdmina.Text = a.Ime.ToString();
            txtPrezimeAdmina.Text = a.Prezime.ToString();
            txtKorImeAdmina.Text = a.KorisnickoIme.ToString();
            txtLozinkaAdmina.Text = a.Lozinka.ToString();
            txtDatumRodjenjaAdmina.Text = a.DatumRodjenja.ToString();
            txtTitulaAdmina.Text = a.TitulaAdmina.ToString();
        }
        public void azurirajAdmina(object sender, EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaAdmina(ref txtIDBRAdmina,ref txtImeAdmina,
                ref txtPrezimeAdmina,ref txtKorImeAdmina,ref txtLozinkaAdmina,ref txtDatumRodjenjaAdmina,
                ref txtTitulaAdmina);
            Boolean proveraValNovogIdbr = ValidacijaPodataka.validacijaIdbrAzuriranje(ref txtNoviIDBRAdmina);
            if (proveraValidnosti == true && proveraValNovogIdbr == true)
            {
                Administrator a = new Administrator(txtImeAdmina.Text, txtPrezimeAdmina.Text, txtKorImeAdmina.Text,
                    txtLozinkaAdmina.Text, txtDatumRodjenjaAdmina.Text, int.Parse(txtIDBRAdmina.Text), txtTitulaAdmina.Text);
                a.azuiranjeAdmina(int.Parse(txtNoviIDBRAdmina.Text));
                txtIDBRAdmina.Text = "";
                txtImeAdmina.Text = "";
                txtPrezimeAdmina.Text = "";
                txtKorImeAdmina.Text = "";
                txtLozinkaAdmina.Text = "";
                txtDatumRodjenjaAdmina.Text = "";
                txtTitulaAdmina.Text = "";
                txtNoviIDBRAdmina.Text = "";
                cbTrenutniAdmini.Text = "";
            }
            else
            {
                MessageBox.Show("Podaci o Administratoru nisu pravilno popunjeni ili novi IDBR Administratora nije validan!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ukloniAdmina(object sender, EventArgs e)
        {
            Boolean proveraValidnostiIdbr = ValidacijaPodataka.validacijaIdbrBrisanje(ref txtIDBRAdmina);
            if (proveraValidnostiIdbr == true)
            {
                Administrator a = new Administrator(int.Parse(txtIDBRAdmina.Text));
                a.ukloniAdmina(ref admin);
                txtIDBRAdmina.Text = "";
                txtImeAdmina.Text = "";
                txtPrezimeAdmina.Text = "";
                txtKorImeAdmina.Text = "";
                txtLozinkaAdmina.Text = "";
                txtDatumRodjenjaAdmina.Text = "";
                txtTitulaAdmina.Text = "";
                txtNoviIDBRAdmina.Text = "";
                cbTrenutniAdmini.Text = "";
            }
            else
            {
                MessageBox.Show("IDBR Administratora koji ste uneli nije validan!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void azuriranjeAdminaSvojiPodaci(object sender,EventArgs e)
        {
            Boolean proveraValidnosti = ValidacijaPodataka.validacijaPodAdmina(ref txtIDBRAdmina,ref txtImeAdmina,
                ref txtPrezimeAdmina,ref txtKorImeAdmina,ref txtLozinkaAdmina,ref txtDatumRodjenjaAdmina, ref txtTitulaAdmina);
            Boolean proveraValidnostiNoviIdbr = ValidacijaPodataka.validacijaIdbrAzuriranje(ref txtNoviIDBRAdmina);
            if (proveraValidnosti == true && proveraValidnostiNoviIdbr == true)
            {
                Administrator a = new Administrator(txtImeAdmina.Text, txtPrezimeAdmina.Text, txtKorImeAdmina.Text,
                    txtLozinkaAdmina.Text, txtDatumRodjenjaAdmina.Text, int.Parse(txtIDBRAdmina.Text), txtTitulaAdmina.Text);
                a.azuriranjeSvojihPodataka(ref admin, int.Parse(txtNoviIDBRAdmina.Text));
                txtIDBRAdmina.Text = "";
                txtImeAdmina.Text = "";
                txtPrezimeAdmina.Text = "";
                txtKorImeAdmina.Text = "";
                txtLozinkaAdmina.Text = "";
                txtDatumRodjenjaAdmina.Text = "";
                txtTitulaAdmina.Text = "";
                txtNoviIDBRAdmina.Text = "";
                cbTrenutniAdmini.Text = "";
            }
            else
            {
                MessageBox.Show("Podaci o Administratoru nisu pravilno popunjeni ili novi IDBR Administratora nije validan!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Rezervacija
        public void prikazIDBRKupaca(object sender, EventArgs e)
        {
            List<Korisnik> ListaKorisnik = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnik);
            cbSviIDBRKupca.Items.Clear();
            for (int i = 0; i < ListaKorisnik.Count; i++)
            {
                if (ListaKorisnik[i] is Kupac)
                {
                    cbSviIDBRKupca.Items.Add(ListaKorisnik[i]);
                }
            }
            ListaKorisnik.Clear();
        }
        public void prikazRezervacijaPoIdbr(object sender, EventArgs e)
        {            
            lbPrikazRezervacija.Items.Clear();
            if (cbSviIDBRKupca.Text != "")
            {
                Boolean flag = false;
                Rezervacija pom = null;
                Object k = cbSviIDBRKupca.SelectedItem;
                Kupac kupac = k as Kupac;
                int idbrKupca = kupac.Idbr;
                List<Rezervacija> ListaRez = new List<Rezervacija>();
                RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
                for (int i = 0; i < ListaRez.Count - 1; i++)
                {
                    for (int j = i + 1; j < ListaRez.Count; j++)
                    {
                        if ((ListaRez[i].IdbrAutomobila > ListaRez[j].IdbrAutomobila) ||
                            ((ListaRez[i].IdbrAutomobila == ListaRez[j].IdbrAutomobila) &&
                            ListaRez[i].DatumOd.Date > ListaRez[j].DatumOd.Date))
                        {
                            pom = ListaRez[i];
                            ListaRez[i] = ListaRez[j];
                            ListaRez[j] = pom;
                        }
                    }
                }
                for (int i = 0; i < ListaRez.Count; i++)
                {
                    if (ListaRez[i].IdbrKupca == idbrKupca)
                    {
                        lbPrikazRezervacija.Items.Add(ListaRez[i]);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    lbPrikazRezervacija.Items.Add("Ne postoji ni jedna Rezervacija za izabranog Kupca!");
                }
                ListaRez.Clear();
            }
            else
            {
                lbPrikazRezervacija.Items.Add("Trenutno nema ni jedne Rezervacije!");
            }           
        }
        public void brisanjeRezervacije(object sender, EventArgs e)
        {
            if (lbPrikazRezervacija.SelectedIndex == -1)
            {
                MessageBox.Show("Ne možete da brišete jer niste odabrali ni jednu rezervaciju!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Object rez = lbPrikazRezervacija.SelectedItem;
                Rezervacija rezervacija = rez as Rezervacija;
                rezervacija.brisanjeRezervacije();
            }
        }
        public void ocistiPoljaRezervacija(object sender, EventArgs e)
        {
            cbSviIDBRKupca.Text = "";
            lbPrikazRezervacija.Items.Clear();
            lbPrikazRezervacija.Items.Add("Trenutno nema ni jedne Rezervacije!");
        }

        //Statistika
        public void popuniMesecima(object sender, EventArgs e)
        {
            string[] meseci = new string[] { "Januar","Februar","Mart","April","Maj","Jun","Jul","Avugst","Septembar","Oktobar",
            "Novembar","Decembar"};
            cbMeseci.Items.Clear();
            cbGodina.Items.Clear();
            for (int i = 0; i < 12; i++)
            {
                cbMeseci.Items.Add(meseci[i]);
            }
            for (int i = 2010; i <= 2020; i++)
            {
                cbGodina.Items.Add(i);
            }
        }
        public void iscrtavanjeGrafika(object sender, EventArgs e)
        {
            pcbCrtanje.Paint += crtanjeGrafika;
            pcbCrtanje.Invalidate();
        }
        public void crtanjeGrafika(object sender, PaintEventArgs e)
        {
            Boolean flagNadjen = false;
            int redniBrojMeseca = cbMeseci.SelectedIndex + 1;
            int godina = 2010 + cbGodina.SelectedIndex;
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            List<Automobil> ListaAutomobila = new List<Automobil>();
            List<Statistika> ListaStat = new List<Statistika>();
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            int ukupanBrojDanaUMesecu = 0;
            int ukupanBrojDanaAutomobila = 0;
            //Racunanje ukupnog broja dana u mesecu koji su rezervisani
            for (int i = 0; i < ListaRez.Count; i++)
            {
                if (ListaRez[i].DatumOd.Month == redniBrojMeseca && ListaRez[i].DatumDo.Month == redniBrojMeseca &&
                    ListaRez[i].DatumOd.Year == godina && ListaRez[i].DatumDo.Year == godina)
                {
                    ukupanBrojDanaUMesecu += (int)(ListaRez[i].DatumDo.Date - ListaRez[i].DatumOd.Date).TotalDays + 1;
                }
                else if (ListaRez[i].DatumOd.Month == redniBrojMeseca && ListaRez[i].DatumDo.Month != redniBrojMeseca &&
                    ListaRez[i].DatumOd.Year == godina && ListaRez[i].DatumDo.Year == godina)
                {
                    int brojDana = DateTime.DaysInMonth(ListaRez[i].DatumOd.Year, ListaRez[i].DatumOd.Month);
                    DateTime poslednjiDan = new DateTime(ListaRez[i].DatumOd.Year, ListaRez[i].DatumOd.Month, brojDana);
                    ukupanBrojDanaUMesecu += (int)(poslednjiDan.Date - ListaRez[i].DatumOd.Date).TotalDays + 1;
                }
                else if (ListaRez[i].DatumOd.Month != redniBrojMeseca && ListaRez[i].DatumDo.Month == redniBrojMeseca &&
                    ListaRez[i].DatumOd.Year == godina && ListaRez[i].DatumDo.Year == godina)
                {
                    DateTime prviDan = new DateTime(ListaRez[i].DatumDo.Year, ListaRez[i].DatumDo.Month, 1);
                    ukupanBrojDanaUMesecu += (int)(ListaRez[i].DatumDo.Date - prviDan.Date).TotalDays + 1;
                }
                else if (ListaRez[i].DatumOd.Month < redniBrojMeseca && ListaRez[i].DatumDo.Month > redniBrojMeseca &&
                    ListaRez[i].DatumOd.Year == godina && ListaRez[i].DatumDo.Year == godina)
                {
                    DateTime prviDan = new DateTime(godina, redniBrojMeseca, 1);
                    DateTime zadnjiDan = prviDan.AddMonths(1).AddDays(-1);
                    ukupanBrojDanaUMesecu += (int)(zadnjiDan.Date - prviDan.Date).TotalDays + 1;
                }
            }
            //Racunanje broja dana u mesecu za pojedinacne Automobile
            for (int i = 0; i < ListaAutomobila.Count; i++)
            {
                for (int j = 0; j < ListaRez.Count; j++)
                {
                    if (ListaAutomobila[i].Idbr == ListaRez[j].IdbrAutomobila)
                    {
                        if (ListaRez[j].DatumOd.Month == redniBrojMeseca && ListaRez[j].DatumDo.Month == redniBrojMeseca &&
                            ListaRez[j].DatumOd.Year == godina && ListaRez[j].DatumDo.Year == godina)
                        {
                            ukupanBrojDanaAutomobila += (int)(ListaRez[j].DatumDo.Date - ListaRez[j].DatumOd.Date).TotalDays + 1;
                            flagNadjen = true;
                        }
                        else if (ListaRez[j].DatumOd.Month == redniBrojMeseca && ListaRez[j].DatumDo.Month != redniBrojMeseca &&
                            ListaRez[j].DatumOd.Year == godina && ListaRez[j].DatumDo.Year == godina)
                        {
                            int brojDana = DateTime.DaysInMonth(ListaRez[j].DatumOd.Year, ListaRez[j].DatumOd.Month);
                            DateTime poslednjiDan = new DateTime(ListaRez[j].DatumOd.Year, ListaRez[j].DatumOd.Month, brojDana);
                            ukupanBrojDanaAutomobila += (int)(poslednjiDan.Date - ListaRez[j].DatumOd.Date).TotalDays + 1;
                            flagNadjen = true;
                        }
                        else if (ListaRez[j].DatumOd.Month != redniBrojMeseca && ListaRez[j].DatumDo.Month == redniBrojMeseca &&
                            ListaRez[j].DatumOd.Year == godina && ListaRez[j].DatumDo.Year == godina)
                        {
                            DateTime prviDan = new DateTime(ListaRez[j].DatumDo.Year, ListaRez[j].DatumDo.Month, 1);
                            ukupanBrojDanaAutomobila += (int)(ListaRez[j].DatumDo.Date - prviDan.Date).TotalDays + 1;
                            flagNadjen = true;
                        }
                        else if (ListaRez[j].DatumOd.Month < redniBrojMeseca && ListaRez[j].DatumDo.Month > redniBrojMeseca &&
                            ListaRez[j].DatumOd.Year == godina && ListaRez[j].DatumDo.Year == godina)
                        {
                            DateTime prviDan = new DateTime(godina, redniBrojMeseca, 1);
                            DateTime zadnjiDan = prviDan.AddMonths(1).AddDays(-1);
                            ukupanBrojDanaAutomobila += (int)(zadnjiDan.Date - prviDan.Date).TotalDays + 1;
                            flagNadjen = true;
                        }
                    }
                }
                if (flagNadjen == true)
                {
                    double racun = 100.0 / ((double)ukupanBrojDanaUMesecu / (double)ukupanBrojDanaAutomobila);
                    double procenat = Math.Round(racun, 2);
                    ListaStat.Add(new Statistika(ListaAutomobila[i].Idbr, ukupanBrojDanaAutomobila, procenat,
                        ListaAutomobila[i].Marka,ListaAutomobila[i].Model));
                }
                flagNadjen = false;
                ukupanBrojDanaAutomobila = 0;
            }
            //Crtanje
            Rectangle r = new Rectangle(20, 30, 170, 170);
            float ukupniUgao = 0;
            float pocetniUgao = -90f;
            int pomeraj = 0;
            Random rnd = new Random();
            lbPrikazStatistike.Items.Clear();
            for (int i = 0; i < ListaStat.Count; i++)
            {
                int red = rnd.Next(0, 256);
                int green = rnd.Next(0, 256);
                int blue = rnd.Next(0, 256);
                SolidBrush boja = new SolidBrush(Color.FromArgb(red ,green, blue));
                ukupniUgao = 360 / (float)ukupanBrojDanaUMesecu * (float)ListaStat[i].UkupanBrojRezMesec;
                e.Graphics.FillPie(boja, r, pocetniUgao, ukupniUgao);
                pocetniUgao += ukupniUgao;
                e.Graphics.FillRectangle(boja, new Rectangle(250, 5 + pomeraj, 10, 10));
                lbPrikazStatistike.Items.Add(ListaStat[i]);
                pomeraj += 15;
            }
            ListaRez.Clear();
            ListaStat.Clear();
            ListaAutomobila.Clear();
        }
    }
}
