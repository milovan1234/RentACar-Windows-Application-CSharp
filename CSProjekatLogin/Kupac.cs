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
    public class Kupac : Korisnik
    {
        private long jmbg;
        private string telefon;

        public long Jmbg { get { return jmbg; } set { jmbg = value; } }
        public string Telefon { get { return telefon; } set { telefon = value; } }

        public Kupac(string ime, string prezime, string korisnickoIme, string lozinka, string datumRodjenja,int idbr,long jmbg,string telefon)
            : base(ime, prezime, korisnickoIme, lozinka, datumRodjenja,idbr)
        {
            this.jmbg = jmbg;
            this.telefon = telefon;
        }
        public Kupac(int idbr) : base(idbr) { }
        public Kupac(int idbr, string ime, string prezime) : base(idbr, ime, prezime) { }
        public Kupac(SerializationInfo info, StreamingContext context)
        {
            ime = info.GetString("ime");
            prezime = info.GetString("prezime");
            korisnickoIme = info.GetString("korisicko_ime");
            lozinka = info.GetString("lozinka");
            datumRodjenja = info.GetString("datumRodjenja");
            idbr = info.GetInt32("idbr");
            jmbg = info.GetInt64("jmbg");
            telefon = info.GetString("telefon");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ime", ime);
            info.AddValue("prezime", prezime);
            info.AddValue("korisnickoIme", korisnickoIme);
            info.AddValue("lozinka", lozinka);
            info.AddValue("datumRodjenja", datumRodjenja);
            info.AddValue("idbr", idbr);
            info.AddValue("jmbg", jmbg);
            info.AddValue("telefon", telefon);
        }
        public Boolean dodajNoviNalog()
        {
            Boolean flag = false;
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            foreach (Korisnik ko in ListaKorisnika)
            {
                Kupac ku = ko as Kupac;
                if (this.korisnickoIme == ko.KorisnickoIme || this.idbr == ko.Idbr)
                {
                    flag = true;
                    break;
                }
                else if (ko is Kupac)
                {
                    if (this.jmbg == ku.Jmbg || this.telefon == ku.Telefon)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag == false)
            {
                ListaKorisnika.Add(this);
                RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                MessageBox.Show("Uspešno ste dodali novi nalog u sistem!");
            }
            else
            {
               MessageBox.Show("Uneti podaci već postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaKorisnika.Clear();
            return flag;
        }
        public Boolean azurirajSvojePodatke()
        {
            Boolean flagPod = true;
            List<Korisnik> ListaKorisnika = new List<Korisnik>();
            Korisnik pomocni = null;
            RadSaDatotekama.citanjeKorisnikDatoteke(ref ListaKorisnika);
            for (int i = 0; i < ListaKorisnika.Count; i++)
            {
                if (ListaKorisnika[i].Idbr == this.idbr)
                {
                    pomocni = ListaKorisnika[i];
                    break;
                }
            }
            foreach (Korisnik k in ListaKorisnika)
            {
                Kupac ku = k as Kupac;
                if (ku != pomocni)
                {
                    if (k.KorisnickoIme == this.KorisnickoIme)
                    {
                        flagPod = false;
                    }
                    else if (ku is Kupac && ku.Telefon == this.Telefon)
                    {
                        flagPod = false;
                    }
                }
            }
            if (flagPod == true)
            {
                for (int i = 0; i < ListaKorisnika.Count; i++)
                {
                    if (ListaKorisnika[i].Idbr == this.Idbr)
                    {
                        ListaKorisnika[i] = this;
                    }
                }
                RadSaDatotekama.upisKorisnikDatoteke(ref ListaKorisnika);
                MessageBox.Show("Uspešno ste ažurirali svoje Podatke!");
                ListaKorisnika.Clear();
                return true;
            }
            else
            {
                MessageBox.Show("Korisničko ime ili Telefon već postoje u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ListaKorisnika.Clear();
                return false;
            }            
        }
        public override string ToString()
        {
            return this.idbr + " " + this.ime + " " + this.prezime + " " + this.datumRodjenja + " " + this.jmbg +
                " " + this.korisnickoIme + " " + this.lozinka + " " + this.telefon;
        }
    }
}
