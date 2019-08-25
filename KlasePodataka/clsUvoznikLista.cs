using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsUvoznikLista
    {
        private List<clsUvoznik> pListaUvoznika; 

        public List<clsUvoznik> ListaUvoznika
        {
            get
            {
                return pListaUvoznika;
            }
            set
            {
                if (this.pListaUvoznika != value)
                    this.pListaUvoznika = value;
            }
        }

        
        public clsUvoznikLista()
        {
            pListaUvoznika = new List<clsUvoznik>(); 

        }

        public void DodajElementListe(clsUvoznik objNovUvoznik)
        {
            pListaUvoznika.Add(objNovUvoznik);
        }

        public void ObrisiElementListe(clsUvoznik objUvoznikZaBrisanje)
        {
            pListaUvoznika.Remove(objUvoznikZaBrisanje);  
        }

        public void ObrisiElementNaPoziciji(int pozicija)
        {
            pListaUvoznika.RemoveAt(pozicija);
        }

        public void IzmeniElementListe(clsUvoznik objStariUvoznik, clsUvoznik objNoviUvoznik)
        {
            int indexStarogUvoznika= 0;
            indexStarogUvoznika = pListaUvoznika.IndexOf(objStariUvoznik);  
            pListaUvoznika.RemoveAt(indexStarogUvoznika); 
            pListaUvoznika.Insert(indexStarogUvoznika, objNoviUvoznik);   
        }
    }
}
