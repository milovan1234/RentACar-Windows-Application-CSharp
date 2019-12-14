using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProjekatLogin
{
    public partial class FormRezervacija : Form
    {
        FormKupac kupac;
        Kupac k;
        int idbrAutomobila;
        double cenaRez;
        List<Ponuda> PomocnaListaPonuda = new List<Ponuda>();
        List<Automobil> GlavnaLista = new List<Automobil>();
        public FormRezervacija()
        {
            InitializeComponent();
        }
        public FormRezervacija(ref Korisnik k, FormKupac kupac) : this()
        {
            //this.BackColor = Color.FromArgb(216, 219, 230);
            this.kupac = kupac;
            this.FormClosed += izlazakIzRezervacije;
            this.FormClosed += kupac.ispisRezervacija;
            this.k = k as Kupac;
            txtUkupnaCena.Text = "0";
            //Marka
            this.Load += prikazSvihMarki;
            cbMarka.SelectedIndexChanged += ocistiPolja;
            cbMarka.SelectedIndexChanged += prikazModela;
            //Model
            cbModel.SelectedIndexChanged += prikazOstalih;
            //Godiste
            cbGodiste.SelectedIndexChanged += prikazModela;
            cbGodiste.SelectedIndexChanged += prikazPoGodistu;
            //Kubikaza
            cbKubikaza.SelectedIndexChanged += prikazModela;
            cbKubikaza.SelectedIndexChanged += prikazPoKubikazi;
            //Karoserija
            cbKaroserija.SelectedIndexChanged += prikazModela;
            cbKaroserija.SelectedIndexChanged += prikazPoKaroseriji;
            //BrojVrata
            cbBrojVrata.SelectedIndexChanged += prikazModela;
            cbBrojVrata.SelectedIndexChanged += prikazPoBrojuVrata;
            //Gorivo
            cbGorivo.SelectedIndexChanged += prikazModela;
            cbGorivo.SelectedIndexChanged += prikazPoGorivu;
            //Pogon
            cbPogon.SelectedIndexChanged += prikazModela;
            cbPogon.SelectedIndexChanged += prikazPoPogonu;
            //Menjac
            cbMenjac.SelectedIndexChanged += prikazModela;
            cbMenjac.SelectedIndexChanged += prikazPoMenjacu;
            //PrikazTermina
            btnPrikazDostupnihTermina.Click += prikazPonuda;
            //Rezervacija
            btnRezervisi.Click += dodajRezervaciju;
            btnRezervisi.Click += kupac.ispisRezervacija;
            //Cena
            dtpDatumPreuzimanja.ValueChanged += ispisCene;
            dtpDatumVracanja.ValueChanged += ispisCene;
        }
        public void izlazakIzRezervacije(object sender, EventArgs e)
        {
            this.Hide();
            kupac.Show();
        }
        public void ocistiPolja(object sender, EventArgs e)
        {
            cbModel.Items.Clear();
            cbModel.Text = "";
            cbGodiste.Items.Clear();
            cbGodiste.Text = "";
            cbKubikaza.Items.Clear();
            cbKubikaza.Text = "";
            cbKaroserija.Items.Clear();
            cbKaroserija.Text = "";
            cbBrojVrata.Items.Clear();
            cbBrojVrata.Text = "";
            cbGorivo.Items.Clear();
            cbGorivo.Text = "";
            cbPogon.Items.Clear();
            cbPogon.Text = "";
            cbMenjac.Items.Clear();
            cbMenjac.Text = "";
            txtPrikazTermina.Text = "";
            dtpDatumPreuzimanja.Value = DateTime.Now;
            dtpDatumVracanja.Value = DateTime.Now;
            txtUkupnaCena.Text = "0";
        }
        public void prikazSvihMarki(object sender, EventArgs e)
        {
            Boolean flagNadjen = false;
            List<Automobil> ListaAutomobila = new List<Automobil>();
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            for (int i = 0; i < ListaAutomobila.Count; i++)
            {
                for (int j = i + 1; j < ListaAutomobila.Count; j++)
                {
                    if (ListaAutomobila[i].Marka == ListaAutomobila[j].Marka) { flagNadjen = true; }
                }
                if (flagNadjen == false) { cbMarka.Items.Add(ListaAutomobila[i].Marka); }
                else { flagNadjen = false; }
            }
            ListaAutomobila.Clear();
        }
        public void prikazModela(object sender, EventArgs e)
        {
            Boolean uslov = true;
            object m = cbMarka.SelectedItem;
            string marka = m as string;
            Boolean flagNadjen = false;
            List<Automobil> ListaAutomobila = new List<Automobil>();
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            cbModel.Items.Clear();
            GlavnaLista.Clear();
            for (int i = 0; i < ListaAutomobila.Count; i++)
            {
                if (ListaAutomobila[i].Marka == marka)
                {
                    for (int j = i + 1; j < ListaAutomobila.Count; j++)
                    {
                        if (ListaAutomobila[i].Model == ListaAutomobila[j].Model &&
                            ListaAutomobila[i].Marka == ListaAutomobila[j].Marka)
                        {
                            flagNadjen = true;
                        }
                    }
                    if (flagNadjen == false) { cbModel.Items.Add(ListaAutomobila[i].Model); }
                    else { flagNadjen = false; }
                }
                if (cbMarka.Text != "")
                {
                    if (ListaAutomobila[i].Marka != cbMarka.Text) { uslov = false; }
                }
                if (cbModel.Text != "")
                {
                    if (ListaAutomobila[i].Model != cbModel.Text) { uslov = false; }
                }                
                if (cbGodiste.Text != "")
                {
                    if (ListaAutomobila[i].Godiste != int.Parse(cbGodiste.Text)) { uslov = false; }
                }
                if (cbKubikaza.Text != "")
                {
                    if (ListaAutomobila[i].Kubikaza != int.Parse(cbKubikaza.Text)) { uslov = false; }
                }
                if (cbKaroserija.Text != "")
                {
                    if (ListaAutomobila[i].Karoserija != cbKaroserija.Text) { uslov = false; }
                }
                if (cbBrojVrata.Text != "")
                {
                    if (ListaAutomobila[i].BrojVrata != int.Parse(cbBrojVrata.Text)) { uslov = false; }
                }
                if (cbGorivo.Text != "")
                {
                    if (ListaAutomobila[i].Gorivo != cbGorivo.Text) { uslov = false; }
                }
                if (cbPogon.Text != "")
                {
                    if (ListaAutomobila[i].Pogon != cbPogon.Text) { uslov = false; }
                }
                if (cbMenjac.Text != "")
                {
                    if (ListaAutomobila[i].VrstaMenjaca != cbMenjac.Text) { uslov = false; }
                }
                if (uslov == true) { GlavnaLista.Add(ListaAutomobila[i]); }
                uslov = true;
            }
            ListaAutomobila.Clear();
        }
        public void prikazOstalih(object sender, EventArgs e)
        {
            object m = cbModel.SelectedItem;
            string model = m as string;
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            List<Automobil> ListaAutomobila = new List<Automobil>();
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            Rezervacija.ocistiPolja(ref cbGodiste, ref cbKubikaza, ref cbKaroserija, ref cbBrojVrata, ref cbGorivo, ref cbPogon, ref cbMenjac);
            for (int i = 0; i < ListaAutomobila.Count; i++)
            {
                if (ListaAutomobila[i].Model == model)
                {
                    for (int j = i + 1; j < ListaAutomobila.Count; j++)
                    {
                        if (ListaAutomobila[i].Model == ListaAutomobila[j].Model)
                        {
                            if (ListaAutomobila[i].Godiste == ListaAutomobila[j].Godiste) { flagGodiste = true; }
                            if (ListaAutomobila[i].Kubikaza == ListaAutomobila[j].Kubikaza) { flagKubikaza = true; }
                            if (ListaAutomobila[i].Karoserija == ListaAutomobila[j].Karoserija) { flagKaroserija = true; }
                            if (ListaAutomobila[i].BrojVrata == ListaAutomobila[j].BrojVrata) { flagBrojVrata = true; }
                            if (ListaAutomobila[i].Gorivo == ListaAutomobila[j].Gorivo) { flagGorivo = true; }
                            if (ListaAutomobila[i].Pogon == ListaAutomobila[j].Pogon) { flagPogon = true; }
                            if (ListaAutomobila[i].VrstaMenjaca == ListaAutomobila[j].VrstaMenjaca) { flagMenjac = true; }
                        }
                    }
                    if (flagGodiste == false) { cbGodiste.Items.Add(ListaAutomobila[i].Godiste); }
                    if (flagKubikaza == false) { cbKubikaza.Items.Add(ListaAutomobila[i].Kubikaza); }
                    if (flagKaroserija == false) { cbKaroserija.Items.Add(ListaAutomobila[i].Karoserija); }
                    if (flagBrojVrata == false) { cbBrojVrata.Items.Add(ListaAutomobila[i].BrojVrata); }
                    if (flagGorivo == false) { cbGorivo.Items.Add(ListaAutomobila[i].Gorivo); }
                    if (flagPogon == false) { cbPogon.Items.Add(ListaAutomobila[i].Pogon); }
                    if (flagMenjac == false) { cbMenjac.Items.Add(ListaAutomobila[i].VrstaMenjaca); }
                    flagGodiste = flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
                }
            }
            ListaAutomobila.Clear();
        }
        public void prikazPoGodistu(object sender, EventArgs e)
        {
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            Rezervacija.ocistiPolja(ref cbKubikaza, ref cbKaroserija, ref cbBrojVrata, ref cbGorivo, ref cbPogon, ref cbMenjac);
            for (int i = 0; i < GlavnaLista.Count; i++)
            {
                for (int j = i + 1; j < GlavnaLista.Count; j++)
                {
                    if (GlavnaLista[i].Kubikaza == GlavnaLista[j].Kubikaza) { flagKubikaza = true; }
                    if (GlavnaLista[i].Karoserija == GlavnaLista[j].Karoserija) { flagKaroserija = true; }
                    if (GlavnaLista[i].BrojVrata == GlavnaLista[j].BrojVrata) { flagBrojVrata = true; }
                    if (GlavnaLista[i].Gorivo == GlavnaLista[j].Gorivo) { flagGorivo = true; }
                    if (GlavnaLista[i].Pogon == GlavnaLista[j].Pogon) { flagPogon = true; }
                    if (GlavnaLista[i].VrstaMenjaca == GlavnaLista[j].VrstaMenjaca) { flagMenjac = true; }
                }
                if (flagKubikaza == false) { cbKubikaza.Items.Add(GlavnaLista[i].Kubikaza); }
                if (flagKaroserija == false) { cbKaroserija.Items.Add(GlavnaLista[i].Karoserija); }
                if (flagBrojVrata == false) { cbBrojVrata.Items.Add(GlavnaLista[i].BrojVrata); }
                if (flagGorivo == false) { cbGorivo.Items.Add(GlavnaLista[i].Gorivo); }
                if (flagPogon == false) { cbPogon.Items.Add(GlavnaLista[i].Pogon); }
                if (flagMenjac == false) { cbMenjac.Items.Add(GlavnaLista[i].VrstaMenjaca); }
                flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
            }
        }
        public void prikazPoKubikazi(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            Rezervacija.ocistiPolja(ref cbGodiste, ref cbKaroserija, ref cbBrojVrata, ref cbGorivo, ref cbPogon, ref cbMenjac);
            for (int i = 0; i < GlavnaLista.Count; i++)
            {
                for (int j = i + 1; j < GlavnaLista.Count; j++)
                {
                    if (GlavnaLista[i].Godiste == GlavnaLista[j].Godiste) { flagGodiste = true; }
                    if (GlavnaLista[i].Karoserija == GlavnaLista[j].Karoserija) { flagKaroserija = true; }
                    if (GlavnaLista[i].BrojVrata == GlavnaLista[j].BrojVrata) { flagBrojVrata = true; }
                    if (GlavnaLista[i].Gorivo == GlavnaLista[j].Gorivo) { flagGorivo = true; }
                    if (GlavnaLista[i].Pogon == GlavnaLista[j].Pogon) { flagPogon = true; }
                    if (GlavnaLista[i].VrstaMenjaca == GlavnaLista[j].VrstaMenjaca) { flagMenjac = true; }
                }
                if (flagGodiste == false) { cbGodiste.Items.Add(GlavnaLista[i].Godiste); }
                if (flagKaroserija == false) { cbKaroserija.Items.Add(GlavnaLista[i].Karoserija); }
                if (flagBrojVrata == false) { cbBrojVrata.Items.Add(GlavnaLista[i].BrojVrata); }
                if (flagGorivo == false) { cbGorivo.Items.Add(GlavnaLista[i].Gorivo); }
                if (flagPogon == false) { cbPogon.Items.Add(GlavnaLista[i].Pogon); }
                if (flagMenjac == false) { cbMenjac.Items.Add(GlavnaLista[i].VrstaMenjaca); }
                flagGodiste = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
            }
        }
        public void prikazPoKaroseriji(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            Rezervacija.ocistiPolja(ref cbGodiste, ref cbKubikaza, ref cbBrojVrata, ref cbGorivo, ref cbPogon, ref cbMenjac);
            for (int i = 0; i < GlavnaLista.Count; i++)
            {
                for (int j = i + 1; j < GlavnaLista.Count; j++)
                {
                    if (GlavnaLista[i].Godiste == GlavnaLista[j].Godiste) { flagGodiste = true; }
                    if (GlavnaLista[i].Kubikaza == GlavnaLista[j].Kubikaza) { flagKubikaza = true; }
                    if (GlavnaLista[i].BrojVrata == GlavnaLista[j].BrojVrata) { flagBrojVrata = true; }
                    if (GlavnaLista[i].Gorivo == GlavnaLista[j].Gorivo) { flagGorivo = true; }
                    if (GlavnaLista[i].Pogon == GlavnaLista[j].Pogon) { flagPogon = true; }
                    if (GlavnaLista[i].VrstaMenjaca == GlavnaLista[j].VrstaMenjaca) { flagMenjac = true; }
                }
                if (flagGodiste == false) { cbGodiste.Items.Add(GlavnaLista[i].Godiste); }
                if (flagKubikaza == false) { cbKubikaza.Items.Add(GlavnaLista[i].Kubikaza); }
                if (flagBrojVrata == false) { cbBrojVrata.Items.Add(GlavnaLista[i].BrojVrata); }
                if (flagGorivo == false) { cbGorivo.Items.Add(GlavnaLista[i].Gorivo); }
                if (flagPogon == false) { cbPogon.Items.Add(GlavnaLista[i].Pogon); }
                if (flagMenjac == false) { cbMenjac.Items.Add(GlavnaLista[i].VrstaMenjaca); }
                flagGodiste = flagKubikaza = flagBrojVrata = flagGorivo = flagPogon = flagMenjac = false;
            }
        }
        public void prikazPoBrojuVrata(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            Rezervacija.ocistiPolja(ref cbGodiste, ref cbKubikaza, ref cbKaroserija, ref cbGorivo, ref cbPogon, ref cbMenjac);
            for (int i = 0; i < GlavnaLista.Count; i++)
            {
                for (int j = i + 1; j < GlavnaLista.Count; j++)
                {
                    if (GlavnaLista[i].Godiste == GlavnaLista[j].Godiste) { flagGodiste = true; }
                    if (GlavnaLista[i].Kubikaza == GlavnaLista[j].Kubikaza) { flagKubikaza = true; }
                    if (GlavnaLista[i].Karoserija == GlavnaLista[j].Karoserija) { flagKaroserija = true; }
                    if (GlavnaLista[i].Gorivo == GlavnaLista[j].Gorivo) { flagGorivo = true; }
                    if (GlavnaLista[i].Pogon == GlavnaLista[j].Pogon) { flagPogon = true; }
                    if (GlavnaLista[i].VrstaMenjaca == GlavnaLista[j].VrstaMenjaca) { flagMenjac = true; }
                }
                if (flagGodiste == false) { cbGodiste.Items.Add(GlavnaLista[i].Godiste); }
                if (flagKubikaza == false) { cbKubikaza.Items.Add(GlavnaLista[i].Kubikaza); }
                if (flagKaroserija == false) { cbKaroserija.Items.Add(GlavnaLista[i].Karoserija); }
                if (flagGorivo == false) { cbGorivo.Items.Add(GlavnaLista[i].Gorivo); }
                if (flagPogon == false) { cbPogon.Items.Add(GlavnaLista[i].Pogon); }
                if (flagMenjac == false) { cbMenjac.Items.Add(GlavnaLista[i].VrstaMenjaca); }
                flagGodiste = flagKubikaza = flagKaroserija = flagGorivo = flagPogon = flagMenjac = false;
            }
        }
        public void prikazPoGorivu(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagPogon = false;
            Boolean flagMenjac = false;
            Rezervacija.ocistiPolja(ref cbGodiste, ref cbKubikaza, ref cbKaroserija, ref cbBrojVrata, ref cbPogon, ref cbMenjac);
            for (int i = 0; i < GlavnaLista.Count; i++)
            {
                for (int j = i + 1; j < GlavnaLista.Count; j++)
                {
                    if (GlavnaLista[i].Godiste == GlavnaLista[j].Godiste) { flagGodiste = true; }
                    if (GlavnaLista[i].Kubikaza == GlavnaLista[j].Kubikaza) { flagKubikaza = true; }
                    if (GlavnaLista[i].Karoserija == GlavnaLista[j].Karoserija) { flagKaroserija = true; }
                    if (GlavnaLista[i].BrojVrata == GlavnaLista[j].BrojVrata) { flagBrojVrata = true; }
                    if (GlavnaLista[i].Pogon == GlavnaLista[j].Pogon) { flagPogon = true; }
                    if (GlavnaLista[i].VrstaMenjaca == GlavnaLista[j].VrstaMenjaca) { flagMenjac = true; }
                }
                if (flagGodiste == false) { cbGodiste.Items.Add(GlavnaLista[i].Godiste); }
                if (flagKubikaza == false) { cbKubikaza.Items.Add(GlavnaLista[i].Kubikaza); }
                if (flagKaroserija == false) { cbKaroserija.Items.Add(GlavnaLista[i].Karoserija); }
                if (flagBrojVrata == false) { cbBrojVrata.Items.Add(GlavnaLista[i].BrojVrata); }
                if (flagPogon == false) { cbPogon.Items.Add(GlavnaLista[i].Pogon); }
                if (flagMenjac == false) { cbMenjac.Items.Add(GlavnaLista[i].VrstaMenjaca); }
                flagGodiste = flagKubikaza = flagKaroserija = flagBrojVrata = flagPogon = flagMenjac = false;
            }
        }
        public void prikazPoPogonu(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagMenjac = false;
            Rezervacija.ocistiPolja(ref cbGodiste, ref cbKubikaza, ref cbKaroserija, ref cbBrojVrata, ref cbGorivo, ref cbMenjac);
            for (int i = 0; i < GlavnaLista.Count; i++)
            {
                for (int j = i + 1; j < GlavnaLista.Count; j++)
                {
                    if (GlavnaLista[i].Godiste == GlavnaLista[j].Godiste) { flagGodiste = true; }
                    if (GlavnaLista[i].Kubikaza == GlavnaLista[j].Kubikaza) { flagKubikaza = true; }
                    if (GlavnaLista[i].Karoserija == GlavnaLista[j].Karoserija) { flagKaroserija = true; }
                    if (GlavnaLista[i].BrojVrata == GlavnaLista[j].BrojVrata) { flagBrojVrata = true; }
                    if (GlavnaLista[i].Gorivo == GlavnaLista[j].Gorivo) { flagGorivo = true; }
                    if (GlavnaLista[i].VrstaMenjaca == GlavnaLista[j].VrstaMenjaca) { flagMenjac = true; }
                }
                if (flagGodiste == false) { cbGodiste.Items.Add(GlavnaLista[i].Godiste); }
                if (flagKubikaza == false) { cbKubikaza.Items.Add(GlavnaLista[i].Kubikaza); }
                if (flagKaroserija == false) { cbKaroserija.Items.Add(GlavnaLista[i].Karoserija); }
                if (flagBrojVrata == false) { cbBrojVrata.Items.Add(GlavnaLista[i].BrojVrata); }
                if (flagGorivo == false) { cbGorivo.Items.Add(GlavnaLista[i].Gorivo); }
                if (flagMenjac == false) { cbMenjac.Items.Add(GlavnaLista[i].VrstaMenjaca); }
                flagGodiste = flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagMenjac = false;
            }
        }
        public void prikazPoMenjacu(object sender, EventArgs e)
        {
            Boolean flagGodiste = false;
            Boolean flagKubikaza = false;
            Boolean flagKaroserija = false;
            Boolean flagBrojVrata = false;
            Boolean flagGorivo = false;
            Boolean flagPogon = false;
            Rezervacija.ocistiPolja(ref cbGodiste, ref cbKubikaza, ref cbKaroserija, ref cbBrojVrata, ref cbGorivo, ref cbPogon);
            for (int i = 0; i < GlavnaLista.Count; i++)
            {
                for (int j = i + 1; j < GlavnaLista.Count; j++)
                {
                    if (GlavnaLista[i].Godiste == GlavnaLista[j].Godiste) { flagGodiste = true; }
                    if (GlavnaLista[i].Kubikaza == GlavnaLista[j].Kubikaza) { flagKubikaza = true; }
                    if (GlavnaLista[i].Karoserija == GlavnaLista[j].Karoserija) { flagKaroserija = true; }
                    if (GlavnaLista[i].BrojVrata == GlavnaLista[j].BrojVrata) { flagBrojVrata = true; }
                    if (GlavnaLista[i].Gorivo == GlavnaLista[j].Gorivo) { flagGorivo = true; }
                    if (GlavnaLista[i].Pogon == GlavnaLista[j].Pogon) { flagPogon = true; }
                }
                if (flagGodiste == false) { cbGodiste.Items.Add(GlavnaLista[i].Godiste); }
                if (flagKubikaza == false) { cbKubikaza.Items.Add(GlavnaLista[i].Kubikaza); }
                if (flagKaroserija == false) { cbKaroserija.Items.Add(GlavnaLista[i].Karoserija); }
                if (flagBrojVrata == false) { cbBrojVrata.Items.Add(GlavnaLista[i].BrojVrata); }
                if (flagGorivo == false) { cbGorivo.Items.Add(GlavnaLista[i].Gorivo); }
                if (flagPogon == false) { cbPogon.Items.Add(GlavnaLista[i].Pogon); }
                flagGodiste = flagKubikaza = flagKaroserija = flagBrojVrata = flagGorivo = flagPogon = false;
            }
        }
        public void prikazPonuda(object sender, EventArgs e)
        {
            Boolean flagProvera = true;
            Rezervacija pom = null;
            List<Ponuda> ListaPonuda = new List<Ponuda>();           
            List<Ponuda> GlavnaListaPonuda = new List<Ponuda>();
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            RadSaDatotekama.citanjePonudeDatoteke(ref ListaPonuda);
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            txtPrikazTermina.Text = "";
            PomocnaListaPonuda.Clear();
            if (cbMarka.Text != "" && cbModel.Text != "" && cbGodiste.Text != "" && cbKubikaza.Text != "" && cbKaroserija.Text != ""
                && cbBrojVrata.Text != "" && cbGorivo.Text != "" && cbPogon.Text != "" && cbMenjac.Text != "")
            {
                //Kreiranje Liste Ponuda samo od potrebnih Ponuda
                for (int i = 0; i < ListaPonuda.Count; i++)
                {
                    for (int j = 0; j < GlavnaLista.Count; j++)
                    {
                        if (ListaPonuda[i].IdbrAutomobila == GlavnaLista[j].Idbr)
                        {
                            GlavnaListaPonuda.Add(ListaPonuda[i]);
                        }
                    }
                }
                //Sortiranje Liste Rezervacija
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
                //Ispis Ponuda
                for (int i = 0; i < GlavnaListaPonuda.Count; i++)
                {
                    flagProvera = true;
                    for (int j = 0; j < ListaRez.Count; j++)
                    {
                        if (GlavnaListaPonuda[i].IdbrAutomobila == ListaRez[j].IdbrAutomobila)
                        {
                            if (ListaRez[j].DatumOd.Date < GlavnaListaPonuda[i].DatumOd.Date &&
                                ListaRez[j].DatumDo.Date > GlavnaListaPonuda[i].DatumDo.Date)
                            {
                                flagProvera = false;
                                break;
                            }
                            else if (ListaRez[j].DatumOd.Date >= GlavnaListaPonuda[i].DatumOd.Date && ListaRez[j].DatumOd.Date <= GlavnaListaPonuda[i].DatumDo.Date &&
                                ListaRez[j].DatumDo.Date >= GlavnaListaPonuda[i].DatumOd.Date && ListaRez[j].DatumDo.Date <= GlavnaListaPonuda[i].DatumDo.Date)
                            {
                                PomocnaListaPonuda.Add(new Ponuda(GlavnaListaPonuda[i].IdbrAutomobila, GlavnaListaPonuda[i].CenaPoDanu, GlavnaListaPonuda[i].DatumOd.Date, ListaRez[j].DatumOd.Date.AddDays(-1)));
                                GlavnaListaPonuda[i] = new Ponuda(GlavnaListaPonuda[i].IdbrAutomobila, GlavnaListaPonuda[i].CenaPoDanu, ListaRez[j].DatumDo.Date.AddDays(1), GlavnaListaPonuda[i].DatumDo.Date);

                                if (j == (ListaRez.Count - 1))
                                {
                                    PomocnaListaPonuda.Add(GlavnaListaPonuda[i]);
                                }
                                else if (ListaRez[j + 1].DatumOd.Date > GlavnaListaPonuda[i].DatumDo.Date)
                                {
                                    PomocnaListaPonuda.Add(GlavnaListaPonuda[i]);
                                }
                                else if (GlavnaListaPonuda[i].IdbrAutomobila != ListaRez[j + 1].IdbrAutomobila)
                                {
                                    PomocnaListaPonuda.Add(GlavnaListaPonuda[i]);
                                }
                                flagProvera = false;
                            }
                            else if (ListaRez[j].DatumOd.Date >= GlavnaListaPonuda[i].DatumOd.Date && ListaRez[j].DatumOd.Date <= GlavnaListaPonuda[i].DatumDo.Date &&
                                !(ListaRez[j].DatumDo.Date >= GlavnaListaPonuda[i].DatumOd.Date && ListaRez[j].DatumDo.Date <= GlavnaListaPonuda[i].DatumDo.Date))
                            {
                                PomocnaListaPonuda.Add(new Ponuda(GlavnaListaPonuda[i].IdbrAutomobila, GlavnaListaPonuda[i].CenaPoDanu, GlavnaListaPonuda[i].DatumOd.Date, ListaRez[j].DatumOd.Date.AddDays(-1)));
                                flagProvera = false;
                            }
                            else if (!(ListaRez[j].DatumOd.Date >= GlavnaListaPonuda[i].DatumOd.Date && ListaRez[j].DatumOd.Date <= GlavnaListaPonuda[i].DatumDo.Date) &&
                                ListaRez[j].DatumDo.Date >= GlavnaListaPonuda[i].DatumOd.Date && ListaRez[j].DatumDo.Date <= GlavnaListaPonuda[i].DatumDo.Date)
                            {
                                GlavnaListaPonuda[i] = new Ponuda(GlavnaListaPonuda[i].IdbrAutomobila, GlavnaListaPonuda[i].CenaPoDanu, ListaRez[j].DatumDo.Date.AddDays(1), GlavnaListaPonuda[i].DatumDo.Date);

                                if (j == (ListaRez.Count - 1))
                                {
                                    PomocnaListaPonuda.Add(new Ponuda(GlavnaListaPonuda[i].IdbrAutomobila, GlavnaListaPonuda[i].CenaPoDanu, ListaRez[j].DatumDo.Date.AddDays(1), GlavnaListaPonuda[i].DatumDo.Date));
                                }
                                else if (ListaRez[j + 1].DatumOd.Date > GlavnaListaPonuda[i].DatumDo.Date)
                                {
                                    PomocnaListaPonuda.Add(new Ponuda(GlavnaListaPonuda[i].IdbrAutomobila, GlavnaListaPonuda[i].CenaPoDanu, ListaRez[j].DatumDo.Date.AddDays(1), GlavnaListaPonuda[i].DatumDo.Date));
                                }
                                else if (GlavnaListaPonuda[i].IdbrAutomobila != ListaRez[j + 1].IdbrAutomobila)
                                {
                                    PomocnaListaPonuda.Add(new Ponuda(GlavnaListaPonuda[i].IdbrAutomobila, GlavnaListaPonuda[i].CenaPoDanu, ListaRez[j].DatumDo.Date.AddDays(1), GlavnaListaPonuda[i].DatumDo.Date));
                                }
                                flagProvera = false;
                            }
                        }
                    }
                    if (flagProvera == true)
                    {
                        PomocnaListaPonuda.Add(GlavnaListaPonuda[i]);
                    }
                }
                if (PomocnaListaPonuda.Count > 0)
                {
                    for (int i = 0; i < PomocnaListaPonuda.Count; i++)
                    {
                        if (PomocnaListaPonuda[i].DatumOd.Date <= PomocnaListaPonuda[i].DatumDo)
                        {
                            txtPrikazTermina.Text += "IDBR Automobila: " + PomocnaListaPonuda[i].IdbrAutomobila +
                                "   " + PomocnaListaPonuda[i].IspisPonude() + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    txtPrikazTermina.Text = "Ne postoji ni jedna Ponuda za traženi Automobil!";
                }
            }
            else
            {
                MessageBox.Show("Niste popunili sva polja za odabir Automobila!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaPonuda.Clear();
            ListaRez.Clear();
        }
        public void dodajRezervaciju(object sender, EventArgs e)
        {
            if (cbMarka.Text != "" && cbModel.Text != "" && cbGodiste.Text != "" && cbKubikaza.Text != "" && cbKaroserija.Text != ""
                && cbBrojVrata.Text != "" && cbGorivo.Text != "" && cbPogon.Text != "" && cbMenjac.Text != "" && cenaRez > 0)
            {
                Rezervacija r = new Rezervacija(idbrAutomobila, k.Idbr, dtpDatumPreuzimanja.Value, dtpDatumVracanja.Value, cenaRez);
                r.dodajNovuRezervaciju(PomocnaListaPonuda);
                this.Hide();
                kupac.Show();
            }
            else
            {
                MessageBox.Show("Niste popunili sva polja pri odabiru ili Datumi nisu validni ili" +
                    " već postoji Rezervacija za tražene Datume!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ispisCene(object sender, EventArgs e)
        {
            Boolean provera = ValidacijaPodataka.validacijaNovihDatuma(dtpDatumPreuzimanja.Value, dtpDatumVracanja.Value);
            if (provera == true)
            {
                txtUkupnaCena.Text = "0";
                Rezervacija r = new Rezervacija(idbrAutomobila, k.Idbr, dtpDatumPreuzimanja.Value, dtpDatumVracanja.Value, 0);
                cenaRez = r.racunanjeCene(PomocnaListaPonuda, ref idbrAutomobila);
                txtUkupnaCena.Text = cenaRez.ToString();
            }
            else
            {
                txtUkupnaCena.Text = "0";
            }
        }        
    }
}
