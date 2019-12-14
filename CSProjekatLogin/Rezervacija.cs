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
    public class Rezervacija
    {
        private int idbrAutomobila;
        private int idbrKupca;
        private DateTime datumOd;
        private DateTime datumDo;
        private double cena;

        public int IdbrAutomobila { get => idbrAutomobila; set => idbrAutomobila = value; }
        public int IdbrKupca { get => idbrKupca; set => idbrKupca = value; }
        public DateTime DatumOd { get => datumOd.Date; set => datumOd = value; }
        public DateTime DatumDo { get => datumDo.Date; set => datumDo = value; }
        public double Cena { get => cena; set => cena = value; }

        public Rezervacija(int idbrAutomobila, int idbrKupca, DateTime datumOd, DateTime datumDo, double cena)
        {
            this.IdbrAutomobila = idbrAutomobila;
            this.IdbrKupca = idbrKupca;
            this.DatumOd = datumOd;
            this.DatumDo = datumDo;
            this.Cena = cena;
        }
        public Rezervacija(int idbrAutomobila, int idbrKupca, DateTime datumOd, DateTime datumDo)
        {
            this.IdbrAutomobila = idbrAutomobila;
            this.IdbrKupca = idbrKupca;
            this.DatumOd = datumOd;
            this.DatumDo = datumDo;
        }
        public Rezervacija(SerializationInfo info, StreamingContext context)
        {
            IdbrAutomobila = info.GetInt32("idbrAutomobila");
            IdbrKupca = info.GetInt32("idbrKupca");
            DatumOd = info.GetDateTime("datumOd");
            DatumDo = info.GetDateTime("datumDo");
            Cena = info.GetDouble("cena");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("idbrAutomobila", IdbrAutomobila);
            info.AddValue("idbrKupca", IdbrKupca);
            info.AddValue("datumOd", DatumOd);
            info.AddValue("datumDo", DatumDo);
            info.AddValue("cena", Cena);
        }
        public static void ocistiPolja(ref ComboBox prvi, ref ComboBox drugi, ref ComboBox treci, ref ComboBox cetvrti,
            ref ComboBox peti, ref ComboBox sesti, ref ComboBox sedmi)
        {
            prvi.Items.Clear();
            drugi.Items.Clear();
            treci.Items.Clear();
            cetvrti.Items.Clear();
            peti.Items.Clear();
            sesti.Items.Clear();
            sedmi.Items.Clear();
        }
        public static void ocistiPolja(ref ComboBox prvi, ref ComboBox drugi, ref ComboBox treci, ref ComboBox cetvrti,
            ref ComboBox peti, ref ComboBox sesti)
        {
            prvi.Items.Clear();
            drugi.Items.Clear();
            treci.Items.Clear();
            cetvrti.Items.Clear();
            peti.Items.Clear();
            sesti.Items.Clear();
        }
        public void dodajNovuRezervaciju(List<Ponuda> PravaLista)
        {
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            ListaRez.Add(this);
            RadSaDatotekama.upisRezDatoteke(ref ListaRez);
            MessageBox.Show("Uspešno ste rezervisali Automobil za traženo vreme!");
        }
        public double racunanjeCene(List<Ponuda> PravaLista,ref int IDBR)
        {
            Boolean flagRez = false;
            Boolean flagPod = false;
            int OD = 0;
            int DO = 0;
            int provera1 = 0;
            int provera2 = 0;
            double cena = 0;
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            if ((DatumOd.Date >= DateTime.Now.Date) && (DatumDo.Date >= DatumOd.Date))
            {
                //ISPITIVANJE IZMEDJU KOJIH PONUDA  JE MOGUCE SPAJANJE
                for (int i = 0; i < PravaLista.Count; i++)
                {
                    if (DatumOd.Date >= PravaLista[i].DatumOd.Date && DatumOd.Date <= PravaLista[i].DatumDo.Date)
                    {
                        OD = i;
                        provera1++;
                    }
                    if (DatumDo.Date >= PravaLista[i].DatumOd.Date && DatumDo.Date <= PravaLista[i].DatumDo.Date)
                    {
                        DO = i;
                        provera2++;
                        IDBR = PravaLista[i].IdbrAutomobila;
                        if (provera1 > 0) { break; }
                        else { DO = 0; provera1 = provera2 = 0; }
                    }
                }
                //ISPITIVANJE SPAJANJA DATUMA
                for (int i = OD; i < DO; i++)
                {
                    if ((PravaLista[i + 1].DatumOd.Date - PravaLista[i].DatumDo.Date).TotalDays == 1)
                    {
                        flagPod = true;
                    }
                    else
                    {
                        flagPod = false;
                        break;
                    }
                }
                if (flagPod == true)
                {
                    cena = 0;
                    for (int i = 0; i < PravaLista.Count; i++)
                    {
                        if (i == OD)
                        {
                            cena += ((PravaLista[i].DatumDo.Date - DatumOd.Date).TotalDays + 1) * PravaLista[i].CenaPoDanu;
                        }
                        else if (i == DO)
                        {
                            cena += ((DatumDo.Date - PravaLista[i].DatumOd.Date).TotalDays + 1) * PravaLista[i].CenaPoDanu;
                        }
                        else if (i > OD && i < DO)
                        {
                            cena += ((PravaLista[i].DatumDo.Date - PravaLista[i].DatumOd.Date).TotalDays + 1) * PravaLista[i].CenaPoDanu;
                        }
                    }
                }
                //ISPITIVANJE DA LI VEĆ POSTOJI REZERVACIJA
                for (int i = 0; i < ListaRez.Count; i++)
                {
                    if (((DatumOd.Date >= ListaRez[i].DatumOd.Date && datumOd.Date <= ListaRez[i].datumDo.Date) ||
                        ((DatumDo.Date >= ListaRez[i].DatumOd.Date && datumDo.Date <= ListaRez[i].datumDo.Date))) &&
                        IDBR == ListaRez[i].idbrAutomobila)
                    {
                        flagRez = true;
                    }
                }
                if (flagRez == false)
                {
                    for (int i = 0; i < PravaLista.Count; i++)
                    {
                        if (DatumOd.Date >= PravaLista[i].DatumOd.Date && DatumOd.Date <= PravaLista[i].DatumDo.Date &&
                           DatumDo.Date >= PravaLista[i].DatumOd.Date && DatumDo.Date <= PravaLista[i].DatumDo.Date &&
                           IDBR == PravaLista[i].IdbrAutomobila)
                        {
                            cena = ((DatumDo.Date - datumOd.Date).TotalDays + 1) * PravaLista[i].CenaPoDanu;
                            break;
                        }
                    }
                }                
            }
            ListaRez.Clear();
            return cena;
        }
        public void brisanjeRezervacije()
        {
            List<Rezervacija> ListaRez = new List<Rezervacija>();
            RadSaDatotekama.citanjeRezDatoteke(ref ListaRez);
            Boolean flagNadjen = false;
            for (int i = 0; i < ListaRez.Count; i++)
            {
                if (ListaRez[i].idbrAutomobila == idbrAutomobila && ListaRez[i].IdbrKupca == IdbrKupca &&
                    ListaRez[i].datumOd.Date == datumOd.Date && ListaRez[i].DatumDo.Date == datumDo.Date)
                {
                    ListaRez.RemoveAt(i);
                    i--;
                    flagNadjen = true;
                }
            }
            if (flagNadjen == false)
            {
                MessageBox.Show("Rezervacija sa traženim podacima ne postoji u sistemu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                RadSaDatotekama.upisRezDatoteke(ref ListaRez);
                MessageBox.Show("Uspešno ste obrisali traženu rezervaciju!");
            }
            ListaRez.Clear();
        }
        public override string ToString()
        {
            return "IDBR Kupca: " + IdbrKupca + "   IDBR Automobila: " + IdbrAutomobila + "  " +
                "Datum preuzimanja: " + DatumOd.ToShortDateString() + " " + "Datum vraćanja: " + DatumDo.ToShortDateString() +
                "   Ukupna cena: " + cena;
        }
    }
}
