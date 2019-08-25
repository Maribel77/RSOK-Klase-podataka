using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsUvoznik
    {
        private string pIdUvoznika;
        private string pImeUvoznika;

        public string IdUvoznika
        {
            get
            {
                return pIdUvoznika;
            }
            set
            {
                if (this.pIdUvoznika != value)
                    this.pIdUvoznika = value;
            }
        }

        public string ImeUvoznika
        {
            get
            {
                return pImeUvoznika;
            }
            set
            {
                if (this.pImeUvoznika != value)
                    this.pImeUvoznika = value;
            }
        }

        public clsUvoznik()
        {
            pIdUvoznika = "";
            pImeUvoznika = "";
        }
    }
}
