using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsNabavka
    {

        private string pNazivMasine;
        private DateTime pDatumNabavke;
        private string pSifraUvoznika;
        private string pCena;
        private string pKolicina;

        public clsNabavka()
        {
             pNazivMasine = "";
             pDatumNabavke=DateTime.Now;
             pSifraUvoznika = "";
             pCena = "";
             pKolicina = "";
        }

   
        public string NazivMasine
        {
            get { return pNazivMasine; }
            set { pNazivMasine = value; }
        }

        public DateTime DatumNabavke
        {
            get { return pDatumNabavke; }
            set { pDatumNabavke = value; }
        }

        public string SifraUvoznika
        {
            get { return pSifraUvoznika; }
            set { pSifraUvoznika = value; }
        }

        public string Cena
        {
            get { return pCena; }
            set { pCena = value; }
        }

        public string Kolicina
        {
            get { return pKolicina; }
            set { pKolicina = value; }
        }
    }
}

