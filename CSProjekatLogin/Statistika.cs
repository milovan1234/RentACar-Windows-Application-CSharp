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
    class Statistika
    {
        private int idbrAutomobila;
        private int ukupanBrojRezMesec;
        private double procenat;
        private string marka;
        private string model;
        public Statistika(int idbrAutomobila,int ukupanBrojRezMesec,double procenat,string marka,string model)
        {
            this.idbrAutomobila = idbrAutomobila;
            this.ukupanBrojRezMesec = ukupanBrojRezMesec;
            this.procenat = procenat;
            this.marka = marka;
            this.model = model;
        }
        public int IdbrAutomobila { get => idbrAutomobila; set => idbrAutomobila = value; }
        public int UkupanBrojRezMesec { get => ukupanBrojRezMesec; set => ukupanBrojRezMesec = value; }
        public double Procenat { get => procenat; set => procenat = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public override string ToString()
        {
            return idbrAutomobila + "    " + marka + "  " + model + "       " +
                ukupanBrojRezMesec + "  " + procenat + "%";
        }
    }
}
