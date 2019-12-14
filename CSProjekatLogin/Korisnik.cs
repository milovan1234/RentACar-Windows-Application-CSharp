using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace CSProjekatLogin
{
    [Serializable]
    public class Korisnik
    {
        protected string ime;
        protected string prezime;
        protected string korisnickoIme;
        protected string lozinka;
        protected string datumRodjenja;
        protected int idbr;

        public Korisnik()
        {
            this.ime = "Prazno";
            this.prezime = "Prazno";
            this.korisnickoIme = "Prazno";
            this.lozinka = "Prazno";
            this.datumRodjenja = "Prazno";
            this.idbr = 0;
        }
        public Korisnik(string ime, string prezime, string korisnickoIme, string lozinka, string datumRodjenja,int idbr)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.datumRodjenja = datumRodjenja;
            this.idbr = idbr;
        }
        public Korisnik(int idbr)
        {
            this.idbr = idbr;
        }
        public Korisnik(int idbr, string ime, string prezime)
        {
            this.idbr = idbr;
            this.ime = ime;
            this.prezime = prezime;
        }
        public string KorisnickoIme { get { return korisnickoIme; } set { korisnickoIme = value; } }
        public string Lozinka { get { return lozinka; } set { lozinka = value; } }
        public string Ime { get { return ime; } set { ime = value; } }
        public string Prezime { get { return prezime; } set { prezime = value; } }
        public string DatumRodjenja { get { return datumRodjenja; } set { datumRodjenja = value; } }
        public int Idbr { get { return idbr; } set { idbr = value; } }
        public override string ToString()
        {
            return this.idbr + " " + this.ime + " " + this.prezime + " " + this.korisnickoIme + " " + this.lozinka + " " +
                this.datumRodjenja;
        }
    }
}
