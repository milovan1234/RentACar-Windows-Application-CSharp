using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace CSProjekatLogin
{
    public class ValidacijaPodataka
    {
        public static Boolean validacijaNovogKupca(ref TextBox ime,ref TextBox prezime,ref TextBox korisnickoIme,ref TextBox lozinka,
            ref TextBox datumRodjenja,ref TextBox idbr,ref TextBox jmbg,ref TextBox telefon)
        {
            string pattern1 = @"^\p{Lu}\p{Ll}*(?:[ ]\p{Lu}\p{Ll}*)*$";
            Match result1 = Regex.Match(ime.Text, pattern1);
            if (!result1.Success) { ime.Text = ""; }
            Match result2 = Regex.Match(prezime.Text, pattern1);
            if (!result2.Success) { prezime.Text = ""; }

            string pattern2 = @"^[a-zA-Z0-9]{4,20}$";
            Match result3 = Regex.Match(korisnickoIme.Text, pattern2);
            if (!result3.Success) { korisnickoIme.Text = ""; }
            Match result4 = Regex.Match(lozinka.Text, pattern2);
            if (!result4.Success) { lozinka.Text = ""; }

            string pattern3 = @"^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19)[0-9][0-9]$";
            Match result5 = Regex.Match(datumRodjenja.Text, pattern3);
            if (!result5.Success) { datumRodjenja.Text = ""; }

            string pattern4 = @"^[0-9]{13}$";
            Match result6 = Regex.Match(jmbg.Text, pattern4);
            if (!result6.Success) { jmbg.Text = ""; }

            string pattern6 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result7 = Regex.Match(idbr.Text, pattern6);
            if (!result7.Success) { idbr.Text = ""; }

            string pattern5 = @"^(06[0-9])[ ]([0-9]{3})[-]([0-9]{3,4})$";
            Match result8 = Regex.Match(telefon.Text, pattern5);
            if (!result8.Success) { telefon.Text = ""; }

            string[] datumi;
            string datumProvera;
            Boolean result9 = false;
            if (result5.Success && result6.Success)
            {
                datumi = datumRodjenja.Text.Split('/');
                datumProvera = datumi[0] + datumi[1] + datumi[2].Remove(0, 1);
                result9 = jmbg.Text.StartsWith(datumProvera);
            }
            if (!result9) { jmbg.Text = ""; }
            if (result1.Success && result2.Success && result3.Success && result4.Success && result5.Success
                && result6.Success && result7.Success && result8.Success && result9)
                return true;
            else
                return false;
        }
        public static Boolean validacijaNovogAutomobila(ref TextBox idbr,ref TextBox marka,ref TextBox model,ref TextBox godiste,
            ref TextBox kubikaza,ref ComboBox pogon,ref ComboBox vrstaMenjaca,ref ComboBox karoserija, ref ComboBox gorivo,
            ref ComboBox brojVrata)
        {
            string pattern1 = @"^\p{Lu}\p{Ll}*(?:[ ]\p{Lu}\p{Ll}*)*$";
            Match result1 = Regex.Match(marka.Text, pattern1);
            if (!result1.Success) { marka.Text = ""; }

            string pattern2 = @"^[a-zA-Z0-9 ]{1,}$";
            Match result2 = Regex.Match(model.Text, pattern2);
            if (!result2.Success) { model.Text = ""; }

            string pattern3 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result3 = Regex.Match(idbr.Text, pattern3);
            if (!result3.Success) { idbr.Text = ""; }

            string pattern4 = @"^20[0-1]{1}[0-9]{1}|19[3-9]{1}[0-9]{1}$";


            Match result4 = Regex.Match(godiste.Text, pattern4);
            if (!result4.Success) { godiste.Text = ""; }

            string pattern5 = @"^([1-5][0-9]{3}|6000)$";
            Match result5 = Regex.Match(kubikaza.Text, pattern5);
            if (!result5.Success) { kubikaza.Text = ""; }

            Boolean result6 = true;
            if (pogon.SelectedIndex == -1) { result6 = false; }

            Boolean result7 = true;
            if (vrstaMenjaca.SelectedIndex == -1) { result7 = false; }

            Boolean result8 = true;
            if (karoserija.SelectedIndex == -1) { result8 = false; }

            Boolean result9 = true;
            if (gorivo.SelectedIndex == -1) { result9 = false; }

            Boolean result10 = true;
            if (brojVrata.SelectedIndex == -1) { result10 = false; }

            if (result1.Success && result2.Success && result3.Success && result4.Success && result5.Success && result6 &&
                result7 && result8 && result9 && result10)
                return true;
            else
                return false;
        }
        public static Boolean validacijaIdbrAzuriranje(ref TextBox noviIdbr)
        {
            string pattern1 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result1 = Regex.Match(noviIdbr.Text, pattern1);
            if (!result1.Success) { noviIdbr.Text = ""; }

            if (result1.Success)
                return true;
            else
                return false;
        }
        public static Boolean validacijaIdbrBrisanje(ref TextBox idbr)
        {
            string pattern1 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result1 = Regex.Match(idbr.Text, pattern1);
            if (!result1.Success) { idbr.Text = ""; }
            if (result1.Success)
                return true;
            else
                return false;
        }
        public static Boolean validacijaNovePonude(ref TextBox idbrAutomobila, ref TextBox cenaPoDanu,
            DateTime datumOd,DateTime datumDo)
        {
            string pattern1 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result1 = Regex.Match(idbrAutomobila.Text, pattern1);
            if (!result1.Success) { idbrAutomobila.Text = ""; }

            string pattern2 = @"^[1-9]{1}[0-9]{2,6}$";
            Match result2 = Regex.Match(cenaPoDanu.Text, pattern2);
            if (!result2.Success) { cenaPoDanu.Text = ""; }

            Boolean result3 = true;
            Boolean result4 = true;
            Boolean result5 = true;
            if (datumOd.Date < DateTime.Now.Date)
            {
                result3 = false;
            }
            if (datumDo.Date < datumOd.Date)
            {
                result4 = false;
            }
            if (datumOd.Date.Year != datumDo.Date.Year)
            {
                result5 = false;
            }

            if (result1.Success && result2.Success && result3 && result4 && result5)
                return true;
            else
                return false;
        }
        public static Boolean validacijaNovihDatuma(DateTime datumOd, DateTime datumDo)
        {
            if ((datumOd.Date >= DateTime.Now.Date) && (datumDo.Date >= datumOd.Date) && (datumDo.Date.Year == datumOd.Date.Year))
                return true;
            else
                return false;
        }
        public static Boolean validacijaAdmina(ref TextBox idbr,ref TextBox ime,ref TextBox prezime,ref TextBox korIme,
            ref TextBox lozinka, ref TextBox datumRodj,ref TextBox titula)
        {
            string pattern1 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result1 = Regex.Match(idbr.Text, pattern1);
            if (!result1.Success) { idbr.Text = ""; }

            string pattern2 = @"^\p{Lu}\p{Ll}*(?:[ ]\p{Lu}\p{Ll}*)*$";
            Match result2 = Regex.Match(ime.Text, pattern2);
            if (!result2.Success) { ime.Text = ""; }
            Match result3 = Regex.Match(prezime.Text, pattern2);
            if (!result3.Success) { prezime.Text = ""; }

            string pattern3 = @"^[a-zA-Z0-9]{4,20}$";
            Match result4 = Regex.Match(korIme.Text, pattern3);
            if (!result4.Success) { korIme.Text = ""; }
            Match result5 = Regex.Match(lozinka.Text, pattern3);
            if (!result5.Success) { lozinka.Text = ""; }

            string pattern4 = @"^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19)[0-9][0-9]$";
            Match result6 = Regex.Match(datumRodj.Text, pattern4);
            if (!result6.Success) { datumRodj.Text = ""; }

            string pattern5 = @"^(Glavni administrator|administrator)$";
            Match result7 = Regex.Match(titula.Text, pattern5);
            if (!result7.Success) { titula.Text = ""; }

            if (result1.Success && result2.Success && result3.Success && result4.Success && result5.Success && result6.Success
                && result7.Success)
                return true;
            else
                return false;
        }
        public static Boolean validacijaPodAdmina(ref TextBox idbr, ref TextBox ime, ref TextBox prezime, ref TextBox korIme,
            ref TextBox lozinka, ref TextBox datumRodj, ref TextBox titula)
        {
            string pattern1 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result1 = Regex.Match(idbr.Text, pattern1);
            if (!result1.Success) { idbr.Text = ""; };
            

            string pattern2 = @"^\p{Lu}\p{Ll}*(?:[ ]\p{Lu}\p{Ll}*)*$";
            Match result2 = Regex.Match(ime.Text, pattern2);
            if (!result2.Success) { ime.Text = ""; };
            Match result3 = Regex.Match(prezime.Text, pattern2);
            if (!result3.Success) { prezime.Text = ""; };

            string pattern3 = @"^[a-zA-Z0-9]{4,20}$";
            Match result4 = Regex.Match(korIme.Text, pattern3);
            if (!result4.Success) { korIme.Text = ""; };
            Match result5 = Regex.Match(lozinka.Text, pattern3);
            if (!result5.Success) { lozinka.Text = ""; };

            string pattern4 = @"^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19)[0-9][0-9]$";
            Match result6 = Regex.Match(datumRodj.Text, pattern4);
            if (!result6.Success) { datumRodj.Text = ""; };

            string pattern5 = @"^(administrator)$";
            Match result7 = Regex.Match(titula.Text, pattern5);
            if (!result7.Success) { titula.Text = ""; };

            if (result1.Success && result2.Success && result3.Success && result4.Success && result5.Success && result6.Success
                && result7.Success)
                return true;
            else
                return false;
        }

        public static Boolean DelegatValidacija(ref TextBox ime, ref TextBox prezime, ref TextBox korIme, ref TextBox lozinka,
         ref TextBox datRodj, ref TextBox idbr, ref TextBox jmbg, ref TextBox telefon)
        {
            string pattern1 = @"^\p{Lu}\p{Ll}*(?:[ ]\p{Lu}\p{Ll}*)*$";
            Match result1 = Regex.Match(ime.Text, pattern1);
            if (!result1.Success)
            {
                ime.Text = "";
            }
            Match result2 = Regex.Match(prezime.Text, pattern1);
            if (!result2.Success)
            {
                prezime.Text = "";
            }

            string pattern2 = @"^[a-zA-Z0-9]{4,20}$";
            Match result3 = Regex.Match(korIme.Text, pattern2);
            if (!result3.Success)
            {
                korIme.Text = "";
            }
            Match result4 = Regex.Match(lozinka.Text, pattern2);
            if (!result4.Success)
            {
                lozinka.Text = "";
            }

            string pattern3 = @"^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19)[0-9][0-9]$";
            Match result5 = Regex.Match(datRodj.Text, pattern3);
            if (!result5.Success)
            {
                datRodj.Text = "";
            }

            string pattern4 = @"^[0-9]{13}$";
            Match result6 = Regex.Match(jmbg.Text, pattern4);
            if (!result6.Success)
            {
                jmbg.Text = "";
            }

            string pattern6 = @"^[1-9]{1}[0-9]{0,4}$";
            Match result7 = Regex.Match(idbr.Text, pattern6);
            if (!result7.Success)
            {
                idbr.Text = "";
            }

            string pattern5 = @"^(06[0-9])[ ]([0-9]{3})[-]([0-9]{3,4})$";
            Match result8 = Regex.Match(telefon.Text, pattern5);
            if (!result8.Success)
            {
                telefon.Text = "";
            }

            string[] datumi;
            string datumProvera;
            Boolean result9 = false;
            if (result5.Success && result6.Success)
            {
                datumi = datRodj.Text.Split('/');
                datumProvera = datumi[0] + datumi[1] + datumi[2].Remove(0, 1);
                result9 = jmbg.Text.StartsWith(datumProvera);
            }
            if (!result9)
            {
                jmbg.Text = "";
            }

            if (result1.Success && result2.Success && result3.Success && result4.Success && result5.Success
                && result6.Success && result7.Success && result8.Success && result9)
                return true;
            else
                return false;
        }
    }
}
