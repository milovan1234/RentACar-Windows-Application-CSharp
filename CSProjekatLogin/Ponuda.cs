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
    public class Ponuda
    {
        private int idbrAutomobila;
        private int cenaPoDanu;
        private DateTime datumOd;
        private DateTime datumDo;

        public Ponuda(int idbrAutomobila, int cenaPoDanu, DateTime datumOd, DateTime datumDo)
        {
            this.idbrAutomobila = idbrAutomobila;
            this.cenaPoDanu = cenaPoDanu;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
        }
        public Ponuda(int idbrAutomobila, DateTime datumOd, DateTime datumDo)
        {
            this.idbrAutomobila = idbrAutomobila;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
        }
        public int IdbrAutomobila { get { return idbrAutomobila; } set { idbrAutomobila = value; } }
        public int CenaPoDanu { get { return cenaPoDanu; } set { cenaPoDanu = value; } }
        public DateTime DatumOd { get { return datumOd; } set { datumOd = value; } }
        public DateTime DatumDo { get { return datumDo; } set { datumDo = value; } }
        public Ponuda(SerializationInfo info, StreamingContext context)
        {
            idbrAutomobila = info.GetInt32("idbrAutomobila");
            cenaPoDanu = info.GetInt32("cenaPoDanu");
            datumOd = info.GetDateTime("datumOd");
            datumDo = info.GetDateTime("datumDo");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("idbrAutomobila", idbrAutomobila);
            info.AddValue("cenaPoDanu", cenaPoDanu);
            info.AddValue("datumOd", datumOd);
            info.AddValue("datumDo", datumDo);
        }
        public Boolean dodajNovuPonudu()
        {
            Boolean flagAutomobil = false;
            Boolean flagPonuda = true;
            List<Automobil> ListaAutomobila = new List<Automobil>();
            List<Ponuda> ListaPonuda = new List<Ponuda>();
            RadSaDatotekama.citanjePonudeDatoteke(ref ListaPonuda);
            RadSaDatotekama.citanjeAutomobilDatoteke(ref ListaAutomobila);
            foreach (Automobil a in ListaAutomobila)
            {
                if (a.Idbr == idbrAutomobila)
                {
                    flagAutomobil = true;
                }
            }
            foreach (Ponuda p in ListaPonuda)
            {
                if (((this.datumOd.Date >= p.datumOd.Date && this.datumOd.Date <= p.datumDo.Date) ||
                            (this.datumDo.Date >= p.datumOd.Date && this.datumDo.Date <= p.datumDo.Date))
                            && flagAutomobil == true && this.idbrAutomobila == p.idbrAutomobila)
                {
                    flagPonuda = false;
                }
            }
            if (flagAutomobil == true)
            {
                if (flagPonuda == true)
                {
                    ListaPonuda.Add(this);
                    RadSaDatotekama.upisPonudeDatoteke(ref ListaPonuda);
                }
                else
                {
                    MessageBox.Show("Ne možete preklapati datume Ponude za jedan isti automobil!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Traženi IDBR nije dodeljen ni jednom Automobilu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (flagAutomobil == true && flagPonuda == true)
                return true;
            else
                return false;
        }
        public void ukloniPonudu()
        {
            List<Ponuda> ListaPonuda = new List<Ponuda>();
            Boolean flag = false;
            RadSaDatotekama.citanjePonudeDatoteke(ref ListaPonuda);
            for(int i=0;i<ListaPonuda.Count;i++)
            {
                if (ListaPonuda[i].idbrAutomobila == this.idbrAutomobila && ListaPonuda[i].datumOd.Date == this.datumOd.Date &&
                    ListaPonuda[i].DatumDo.Date == this.DatumDo.Date)
                {
                    ListaPonuda.RemoveAt(i);
                    --i;
                    flag = true;
                }
            }
            if (flag == true)
            {
                RadSaDatotekama.upisPonudeDatoteke(ref ListaPonuda);
                MessageBox.Show("Uspešno ste obrisali Ponudu iz sistema!");
            }
            else
            {
                MessageBox.Show("IDBR,DatumOd i DatumDo svi zajedno ne odgovaraju ni jednoj ponudi u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaPonuda.Clear();
        }
        public void azuriranjePonude(DateTime dtpNoviDatumOd,DateTime dtpNoviDatumDo)
        {
            Boolean flagPonuda = false;
            Boolean flagPodaci = true;
            List<Ponuda> ListaPonuda = new List<Ponuda>();
            Ponuda pomocna = null;
            RadSaDatotekama.citanjePonudeDatoteke(ref ListaPonuda);
            foreach (Ponuda p in ListaPonuda)
            {
                if (this.idbrAutomobila == p.idbrAutomobila && this.datumOd.Date == p.datumOd.Date &&
                    this.datumDo.Date == p.DatumDo.Date)
                {
                    flagPonuda = true;
                    pomocna = p;
                    break;
                }
            }
            if (flagPonuda == true)
            {
                foreach (Ponuda p in ListaPonuda)
                {
                    if (p != pomocna && this.idbrAutomobila == p.idbrAutomobila)
                    {
                        if ((dtpNoviDatumOd.Date >= p.datumOd.Date && dtpNoviDatumOd.Date <= p.datumDo.Date) ||
                            (dtpNoviDatumDo.Date >= p.datumOd.Date && dtpNoviDatumDo.Date <= p.DatumDo.Date))
                        {
                            flagPodaci = false;
                        }
                    }
                }
                if (flagPodaci == true)
                {
                    for (int i = 0; i < ListaPonuda.Count; i++)
                    {
                        if (ListaPonuda[i] == pomocna)
                        {
                            this.DatumOd = dtpNoviDatumOd.Date;
                            this.DatumDo = dtpNoviDatumDo.Date;
                            ListaPonuda[i] = this;
                        }
                    }
                    RadSaDatotekama.upisPonudeDatoteke(ref ListaPonuda);
                    MessageBox.Show("Uspešno ste ažurirali Ponudu!");
                }
                else
                {
                    MessageBox.Show("Ne možete preklapati datume za jedan isti Automobil!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Traženi podaci nisu pronađeni u sistemu Ponuda!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ListaPonuda.Clear();
        }
        public override string ToString()
        {
            return "IDBR Automobila: " + this.idbrAutomobila + " Cena po danu: " + this.cenaPoDanu + "rsd Od: "
                + this.datumOd.Day + "." + this.datumOd.Month + "." + this.datumOd.Year + ". "
                + " Do: " + this.datumDo.Day + "." + this.datumDo.Month + "." + this.datumDo.Year + ".";
        }
        public string  IspisPonude()
        {
            string ispis = "";
            ispis += this.datumOd.Day + "." + this.datumOd.Month + "." + this.datumOd.Year + ". "
                + " - " + this.datumDo.Day + "." + this.datumDo.Month + "." + this.datumDo.Year + ".    Cena: " +
                this.cenaPoDanu + " din po danu";
            return ispis;
        }
    }
}
