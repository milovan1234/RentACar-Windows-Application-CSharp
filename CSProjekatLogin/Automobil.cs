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
    public class Automobil
    {
        private int idbr;
        private string marka;
        private string model;
        private int godiste;
        private int kubikaza;
        private string pogon;
        private string vrstaMenjaca;
        private string karoserija;
        private string gorivo;
        private int brojVrata;

        public Automobil(int idbr,string marka,string model,int godiste,int kubikaza,string pogon,
            string vrstaMenjaca,string karoserija,string gorivo,int brojVrata)
        {
            this.idbr = idbr;
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.vrstaMenjaca = vrstaMenjaca;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brojVrata = brojVrata;
        }
        public Automobil(int idbr)
        {
            this.idbr = idbr;
        }
        public Automobil(SerializationInfo info, StreamingContext context)
        {
            idbr = info.GetInt32("idbr");
            marka = info.GetString("marka");
            model = info.GetString("model");
            godiste = info.GetInt32("godiste");
            kubikaza = info.GetInt32("kubikaza");
            pogon = info.GetString("pogon");
            vrstaMenjaca = info.GetString("vrstaMenjaca");
            karoserija = info.GetString("karoserija");
            gorivo = info.GetString("gorivo");
            brojVrata = info.GetInt32("brojVrata");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("idbr", idbr);
            info.AddValue("marka", marka);
            info.AddValue("model", model);
            info.AddValue("godiste", godiste);
            info.AddValue("kubikaza", kubikaza);
            info.AddValue("pogon", pogon);
            info.AddValue("vrstaMenjaca", vrstaMenjaca);
            info.AddValue("karoserija", karoserija);
            info.AddValue("gorivo", gorivo);
            info.AddValue("brojVrata", brojVrata);
        }
        public int Idbr { get { return idbr; } set { idbr = value; } }
        public string Marka { get { return marka; } set { marka = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Godiste { get { return godiste; } set { godiste = value; } }
        public int Kubikaza { get { return kubikaza; } set { kubikaza = value; } }
        public string Pogon { get { return pogon; } set { pogon = value; } }
        public string VrstaMenjaca { get { return vrstaMenjaca; } set { vrstaMenjaca = value; } }
        public string Karoserija { get { return karoserija; } set { karoserija = value; } }
        public string Gorivo { get { return gorivo; } set { gorivo = value; } }
        public int BrojVrata { get { return brojVrata; } set { brojVrata = value; } }           
        public Boolean dodajNoviAutomobil()
        {
            Boolean flag = false;
            List<Automobil> ListaAutomobila = new List<Automobil>();
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            foreach (Automobil a in ListaAutomobila)
            {
                if (this.idbr == a.idbr)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                ListaAutomobila.Add(this);
                RadSaDatotekama.upisAutomobilDatoteke(ref ListaAutomobila);
                MessageBox.Show("Uspešno ste dodali novi Automobil u sistem!");
            }
            else
            {
                MessageBox.Show("Uneti IDBR vec postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaAutomobila.Clear();
            return flag;
        }        
        public void ukloniAuto()
        {
            Boolean flag = false;
            List<Ponuda> ListaPonuda = new List<Ponuda>();
            List<Automobil> ListaAutomobila = new List<Automobil>();
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            RadSaDatotekama.citanjePonudeDatoteke(ref ListaPonuda);
            for (int i=0;i<ListaAutomobila.Count;i++)
            {
                if (this.idbr == ListaAutomobila[i].idbr)
                {
                    ListaAutomobila.RemoveAt(i);
                    --i;
                    flag = true;
                }
            }
            for(int i=0;i<ListaPonuda.Count;i++)
            {
                if (this.idbr == ListaPonuda[i].IdbrAutomobila)
                {
                    ListaPonuda.RemoveAt(i);
                    --i;
                }
            }
            if (flag == true)
            {
                RadSaDatotekama.upisAutomobilDatoteke(ref ListaAutomobila);
                RadSaDatotekama.upisPonudeDatoteke(ref ListaPonuda);
                MessageBox.Show("Uspešno ste obrisali Automobil iz sistema!");
            }
            else
            {
                MessageBox.Show("Automobil koji ste hteli da obrišete ne postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaPonuda.Clear();
            ListaAutomobila.Clear();            
        }
        public void azurirajAutomobil(int noviIdbr)
        {
            Boolean flagIdbr = true;
            Boolean flag = false;
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            List<Ponuda> ListaPonuda = new List<Ponuda>();
            List<Automobil> ListaAutomobila = new List<Automobil>();
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            RadSaDatotekama.citanjePonudeDatoteke(ref ListaPonuda);
            foreach (Automobil a in ListaAutomobila)
            {
                if (a.idbr == this.idbr)
                {
                    flag = true;
                }
                if (noviIdbr == a.idbr && a.idbr != this.idbr)
                {
                    flagIdbr = false;
                }
            }
            if (flag == true)
            {
                if (flagIdbr == true)
                {
                    for (int i = 0; i < ListaPonuda.Count; i++)
                    {
                        if (ListaPonuda[i].IdbrAutomobila == this.idbr)
                        {
                            ListaPonuda[i].IdbrAutomobila = noviIdbr;
                        }
                    }
                    for (int i = 0; i < ListaRez.Count; i++)
                    {
                        if (ListaRez[i].IdbrAutomobila == this.idbr)
                        {
                            ListaRez[i].IdbrAutomobila = noviIdbr;
                        }
                    }
                    for (int i=0;i<ListaAutomobila.Count;i++)
                    {
                        if (ListaAutomobila[i].idbr == this.idbr)
                        {
                            this.idbr = noviIdbr;
                            ListaAutomobila[i] = this;
                        }
                    }
                    RadSaDatotekama.upisRezDatoteke(ref ListaRez);
                    RadSaDatotekama.upisPonudeDatoteke(ref ListaPonuda);
                    RadSaDatotekama.upisAutomobilDatoteke(ref ListaAutomobila);
                    MessageBox.Show("Uspešno ste ažurirali podatke o Automobilu!");
                }
                else
                {
                    MessageBox.Show("Novi IDBR koji ste uneli već postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ne možete da ažurirate Automobil koji ne postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaPonuda.Clear();
            ListaAutomobila.Clear();
        }
        public override string ToString()
        {
            return this.idbr + " " + this.marka + " " + this.model + " " + this.godiste + ". " + this.kubikaza + "cm3 " +
                this.pogon + " " + this.vrstaMenjaca + " " + this.karoserija + " " + this.gorivo + " " + this.brojVrata;
        }
    }
}
 