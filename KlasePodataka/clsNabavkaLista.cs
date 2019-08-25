using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsNabavkaLista
    {
        
        private List<clsNabavka> pListaNabavke; 

        public List<clsNabavka> ListaNabavke
        {
            get
            {
                return pListaNabavke;
            }
            set
            {
                if (this.pListaNabavke != value)
                    this.pListaNabavke = value;
            }
        }

        public clsNabavkaLista()
        {
            pListaNabavke = new List<clsNabavka>(); 

        }

        public void DodajElementListe(clsNabavka objNovaNabavka)
        {
            pListaNabavke.Add(objNovaNabavka);
        }

        public void ObrisiElementListe(clsNabavka objNabavkaZaBrisanje)
        {
            pListaNabavke.Remove(objNabavkaZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaNabavke.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsNabavka objStaraNabavka, clsNabavka objNovaNabavka)
        {
            int indexStareNabavke = 0;
            indexStareNabavke = pListaNabavke.IndexOf(objStaraNabavka);
            pListaNabavke.RemoveAt(indexStareNabavke);
            pListaNabavke.Insert(indexStareNabavke, objNovaNabavka);   
        }


    }
}
