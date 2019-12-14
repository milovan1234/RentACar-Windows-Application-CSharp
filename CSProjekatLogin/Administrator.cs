using System; 
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace CSProjekatLogin
{
    [Serializable]
    public class Administrator : Korisnik
    {
        private string titulaAdmina;
        public Administrator(string ime, string prezime, string korisnickoIme, string lozinka, string datumRodjenja,int idbr,string titulaAdmina)
            : base(ime, prezime, korisnickoIme, lozinka, datumRodjenja,idbr)
        {
            this.titulaAdmina = titulaAdmina;
        }
        public Administrator(int idbr)
        {
            this.idbr = idbr;
        }
        public string TitulaAdmina { get { return titulaAdmina; } set { titulaAdmina = value; } }
        public Administrator(SerializationInfo info, StreamingContext context)
        {
            idbr = info.GetInt32("idbr");
            ime = info.GetString("ime");
            prezime = info.GetString("prezime");
            korisnickoIme = info.GetString("korisicko_ime");
            lozinka = info.GetString("lozinka");
            datumRodjenja = info.GetString("datumRodjenja");
            titulaAdmina = info.GetString("titulaAdmina");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("idbr", idbr);
            info.AddValue("ime", ime);
            info.AddValue("prezime", prezime);
            info.AddValue("korisnickoIme", korisnickoIme);
            info.AddValue("lozinka", lozinka);
            info.AddValue("datumRodjenja", datumRodjenja);
            info.AddValue("titulaAdmina", titulaAdmina);
        }
        public static Boolean dodajNovogKupca(ref Kupac k)
        {
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);;
            Boolean flag = false;
            foreach (Korisnik ko in ListaKorisnika)
            {
                Kupac ku = ko as Kupac;
                if (k.KorisnickoIme == ko.KorisnickoIme || k.Idbr == ko.Idbr)
                {
                    flag = true;
                    break;
                }
                else if (ko is Kupac)
                {
                    if (k.Jmbg == ku.Jmbg || k.Telefon == ku.Telefon)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag == false)
            {
                ListaKorisnika.Add(k);
                MessageBox.Show("Uspešno ste dodali novi nalog u sistem!");
                RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
            }
            else
            {
                MessageBox.Show("Uneti podaci već postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaKorisnika.Clear();
            return flag;
        }
        public static void ukloniKupca(ref Kupac ku)
        {
            Boolean flag = false;
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            for (int i= 0;i<ListaKorisnika.Count;i++)
            {
                if (ku.Idbr == ListaKorisnika[i].Idbr && ListaKorisnika[i] is Kupac)
                {
                    ListaKorisnika.RemoveAt(i);
                    flag = true;
                    --i;
                }
            }
            if (flag == true)
            {
                for (int i = 0; i < ListaRez.Count; i++)
                {
                    if (ku.Idbr == ListaRez[i].IdbrKupca)
                    {
                        ListaRez.RemoveAt(i);
                        --i;
                    }
                }
                RadSaDatotekama.upisRezDatoteke(ref ListaRez);
                RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                MessageBox.Show("Uspešno ste obrisali Kupca iz sistema!");
            }
            else
            {
                MessageBox.Show("Kupca kog ste hteli da obrišete ne postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaKorisnika.Clear();
        }
        public static void azurirajKupca(int noviIdbr,ref Kupac kupac)
        {
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            Kupac pomocni = null;
            Boolean flagIdbr = false;
            Boolean flagPod = true;
            Boolean flagNoviIdbr = true;
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            foreach (Korisnik k in ListaKorisnika)
            {
                if (k.Idbr == kupac.Idbr)
                {
                    pomocni = (Kupac)k;
                    flagIdbr = true;
                }
            }
            if (flagIdbr == true)
            {
                foreach (Korisnik k in ListaKorisnika)
                {
                    Kupac ku = k as Kupac;
                    if (ku != pomocni)
                    {
                        if (k.KorisnickoIme == kupac.KorisnickoIme || k.Idbr == kupac.Idbr)
                        {
                            flagPod = false;
                        }
                        else if (ku is Kupac && (ku.Jmbg == kupac.Jmbg || ku.Telefon == kupac.Telefon))
                        {
                            flagPod = false;
                        }
                        else if (k.Idbr == noviIdbr)
                        {
                            flagNoviIdbr = false;
                        }
                    }
                }
                if (flagNoviIdbr == true)
                {
                    if (flagPod == true)
                    {
                        for (int i = 0; i < ListaRez.Count; i++)
                        {
                            if (ListaRez[i].IdbrKupca == kupac.Idbr)
                            {
                                Rezervacija nova = new Rezervacija(ListaRez[i].IdbrAutomobila, noviIdbr,
                                    ListaRez[i].DatumOd.Date, ListaRez[i].DatumDo.Date,ListaRez[i].Cena);
                                ListaRez[i] = nova;
                            }
                        }
                        for (int i=0;i<ListaKorisnika.Count;i++)
                        {
                            if (ListaKorisnika[i].Idbr == kupac.Idbr)
                            {
                                kupac.Idbr = noviIdbr;
                                ListaKorisnika[i] = kupac;
                            }
                        }                        
                        RadSaDatotekama.upisRezDatoteke(ref ListaRez);
                        RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                        MessageBox.Show("Uspešno ste ažurirali podatke Kupca!");
                    }
                    else
                    {
                        MessageBox.Show("IDBR, Korisničko ime, JMBG ili Telefon već postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Novi IDBR koji ste uneli već postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("IDBR ne pripada ni jednom korisniku u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaKorisnika.Clear();
        }        
        public string ispisPodataka()
        {
            return this.ime + " " + this.prezime + ":    " + this.titulaAdmina;
        }
        public Boolean dodajNovogAdmina()
        {
            Boolean flag = false;
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            foreach (Korisnik k in ListaKorisnika)
            {
                if (k.KorisnickoIme == this.korisnickoIme || k.Idbr == this.idbr)
                {
                    flag = true;
                }
            }
            if (flag == false)
            {
                ListaKorisnika.Add(this);
                RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                MessageBox.Show("Uspešno ste dodali novog Admina u sistem!");
            }
            else
            {
                MessageBox.Show("Idbr ili korisničko ime već postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return flag;
        }
        public void azuiranjeAdmina(int noviIdbr)
        {
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            Administrator pomocni = null;
            Boolean flagIdbr = false;
            Boolean flagPod = true;
            Boolean flagNoviIdbr = true;
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            foreach (Korisnik k in ListaKorisnika)
            {
                if (this.idbr == k.Idbr)
                {
                    pomocni = (Administrator)k;
                    flagIdbr = true;
                }
            }
            if (flagIdbr == true)
            {
                foreach (Korisnik k in ListaKorisnika)
                {
                    Administrator a = k as Administrator;
                    if (a != pomocni)
                    {
                        if (k.KorisnickoIme == this.KorisnickoIme || k.Idbr == this.Idbr)
                        {
                            flagPod = false;
                        }
                        else if (k.Idbr == noviIdbr)
                        {
                            flagNoviIdbr = false;
                        }
                    }
                }
                if (flagNoviIdbr == true)
                {
                    if (flagPod == true)
                    {
                        for (int i = 0; i < ListaKorisnika.Count; i++)
                        {
                            if (ListaKorisnika[i].Idbr == this.Idbr)
                            {
                                this.Idbr = noviIdbr;
                                ListaKorisnika[i] = this;
                            }
                        }
                        RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                        MessageBox.Show("Uspešno ste ažurirali podatke Admina!");
                    }
                    else
                    {
                        MessageBox.Show("IDBR ili Korisničko ime već postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Novi IDBR koji ste uneli već postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("IDBR ne pripada ni jednom korisniku u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaKorisnika.Clear();
        }
        public void ukloniAdmina(ref Administrator a)
        {
            Boolean flag = false;
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            for(int i=0;i<ListaKorisnika.Count;i++)
            {
                if (this.Idbr == ListaKorisnika[i].Idbr && ListaKorisnika[i] is Administrator && this.idbr != a.idbr)
                {
                    ListaKorisnika.RemoveAt(i);
                    --i;
                    flag = true;
                }
            }
            if (flag == true)
            {
                RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                MessageBox.Show("Uspešno ste obrisali Administratora iz sistema!");
            }
            else
            {
                MessageBox.Show("Administratora kog ste hteli da obrišete ne postoji u sistemu ili ste pokušali sebe da obrišete!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaKorisnika.Clear();
        }
        public void azuriranjeSvojihPodataka(ref Administrator a,int noviIdbr)
        {
            Boolean flagIdbr = false;
            Boolean flagPod = true;
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            foreach (Korisnik k in ListaKorisnika)
            {
                if (this.idbr == k.Idbr && this.idbr == a.idbr)
                {
                    flagIdbr = true;
                }
            }
            if (flagIdbr == true)
            {
                foreach (Korisnik k in ListaKorisnika)
                {
                    if ((noviIdbr == k.Idbr || this.KorisnickoIme == k.KorisnickoIme) && a.idbr != k.Idbr)
                    {
                        flagPod = false;
                    }
                }
                if (flagPod == true)
                {
                    for (int i = 0; i < ListaKorisnika.Count; i++)
                    {
                        if (this.idbr == ListaKorisnika[i].Idbr)
                        {
                            a.idbr = noviIdbr;
                            this.idbr = noviIdbr;
                            ListaKorisnika[i] = this;
                        }
                    }
                    RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                    MessageBox.Show("Uspešno ste ažurirali svoje podatke!");
                }
                else
                {
                    MessageBox.Show("Novi IDBR ili Korisničko ime već postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("IDBR admina ne postoji u sistemu ili ste hteli da ažurirate admina koji niste Vi!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaKorisnika.Clear();
        }
        public override string ToString()
        {
            return this.idbr + " " + this.ime + " " + this.prezime + " " + this.datumRodjenja + " " + this.titulaAdmina + " " +
                this.korisnickoIme + " " + this.lozinka;
        }
    }
}
