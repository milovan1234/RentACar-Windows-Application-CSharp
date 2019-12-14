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
    public class RadSaDatotekama
    {
        public static void citanjeKorisnikDatoteke(ref List<Korisnik> korisnik)
        {
            try
            {
                FileStream fs = new FileStream("login.xml", FileMode.Open);
                SoapFormatter soapform = new SoapFormatter();
                while (true)
                {
                    try
                    {
                        Korisnik k = (Korisnik)soapform.Deserialize(fs);
                        korisnik.Add(k);
                    }
                    catch
                    {
                        break;
                    }
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri čitanju podataka iz datoteke login.xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void upisKorisnikDatoteke(ref List<Korisnik> korisnik)
        {
            try
            {
                FileStream fs = new FileStream("login.xml", FileMode.Create);
                SoapFormatter soapform = new SoapFormatter();
                foreach (Korisnik k in korisnik)
                {
                    soapform.Serialize(fs, k);
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri upisivanju podataka u datoteku login.xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void citanjeAutomobilDatoteke(ref List<Automobil> automobil)
        {
            try
            {
                FileStream fs = new FileStream("automobili.xml", FileMode.OpenOrCreate);
                SoapFormatter soapform = new SoapFormatter();
                while (true)
                {
                    try
                    {
                        Automobil a = (Automobil)soapform.Deserialize(fs);
                        automobil.Add(a);
                    }
                    catch
                    {
                        break;
                    }
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri čitanju podataka iz datoteke automobili.xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void upisAutomobilDatoteke(ref List<Automobil> automobil)
        {
            try
            {
                FileStream fs = new FileStream("automobili.xml", FileMode.Create);
                SoapFormatter soapform = new SoapFormatter();
                foreach (Automobil a in automobil)
                {
                    soapform.Serialize(fs, a);
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri upisivanju podataka u datoteku automobili.xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void citanjePonudeDatoteke(ref List<Ponuda> ponuda)
        {
            try
            {
                FileStream fs = new FileStream("ponude.xml", FileMode.OpenOrCreate);
                SoapFormatter soapform = new SoapFormatter();
                while (true)
                {
                    try
                    {
                        Ponuda p = (Ponuda)soapform.Deserialize(fs);
                        ponuda.Add(p);
                    }
                    catch
                    {
                        break;
                    }
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri čitanju podataka iz datoteke ponude" +
                    ".xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void upisPonudeDatoteke(ref List<Ponuda> ponuda)
        {
            try
            {
                FileStream fs = new FileStream("ponude.xml", FileMode.Create);
                SoapFormatter soapform = new SoapFormatter();
                foreach (Ponuda p in ponuda)
                {
                    soapform.Serialize(fs, p);
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri upisivanju podataka u datoteku ponude.xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void citanjeRezDatoteke(ref List<Rezervacija> rezervacija)
        {
            try
            {
                FileStream fs = new FileStream("rezervacije.xml", FileMode.OpenOrCreate);
                SoapFormatter soapform = new SoapFormatter();
                while (true)
                {
                    try
                    {
                        Rezervacija r = (Rezervacija)soapform.Deserialize(fs);
                        rezervacija.Add(r);
                    }
                    catch
                    {
                        break;
                    }
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri čitanju podataka iz datoteke rezervacije" +
                    ".xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void upisRezDatoteke(ref List<Rezervacija> rezervacija)
        {
            try
            {
                FileStream fs = new FileStream("rezervacije.xml", FileMode.Create);
                SoapFormatter soapform = new SoapFormatter();
                foreach (Rezervacija r in rezervacija)
                {
                    soapform.Serialize(fs, r);
                }
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Greška pri upisivanju podataka u datoteku rezervacije.xml!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
