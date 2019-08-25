using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class clsUvoznikDB
    {
        private string pStringKonekcije;

        public string StringKonekcije
        {
            get
            {
                return pStringKonekcije;
            }
            set
            {
                if (this.pStringKonekcije != value)
                    this.pStringKonekcije = value;
            }
        }

        public clsUvoznikDB(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        public DataSet DajSveUvoznike()
        {

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveUvoznike", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public DataSet DajUvoznikaPoSifri(string IdUvoznika)
        {

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajUvoznikaPoSifri", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IdUvoznika", SqlDbType.NVarChar).Value = IdUvoznika;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public string DajNazivUvoznikaPremaSifriUvoznika(string IdUvoznika)
        {
            string ImeUvoznika = "";


            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajUvoznikaPoSifri", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@SifraUvoznika", SqlDbType.NVarChar).Value = IdUvoznika;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            ImeUvoznika = dsPodaci.Tables[0].Rows[0].ItemArray[1].ToString();

            return ImeUvoznika;
        }

        public string DajSifruUvoznikaPoNazivuUvoznika(string ImeUvoznika)
        {

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajUvoznikaPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@ImeUvoznika", SqlDbType.NVarChar).Value = ImeUvoznika;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci.Tables[0].Rows[0].ItemArray[0].ToString();
        }



        public DataSet DajUvoznikaPoNazivu(string ImeUvoznika)
        {

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajUvoznikaPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@ImeUvoznika", SqlDbType.NVarChar).Value = ImeUvoznika;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }


        public DataSet DajUvoznikaPoNazivu(clsUvoznik objUvoznikZaFilter)
        {

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajUvoznikaPoNazivu", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@ImeUvoznika", SqlDbType.NVarChar).Value = objUvoznikZaFilter.ImeUvoznika;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public bool SnimiNovgUvoznika(clsUvoznik objNovUvoznik)
        {

            int brojSlogova = 0;


            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNovgUvoznika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IdUvoznika", SqlDbType.VarChar).Value = objNovUvoznik.IdUvoznika;
            Komanda.Parameters.Add("@ImeUvoznika", SqlDbType.NVarChar).Value = objNovUvoznik.ImeUvoznika;

            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();


            return (brojSlogova > 0);



        }

        public bool ObrisiUvoznika(clsUvoznik objUvoznikZaBrisanje)
        {
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiUvoznika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IdUvoznika", SqlDbType.VarChar).Value = objUvoznikZaBrisanje.IdUvoznika;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool ObrisiUvoznika(string SifraUvoznikaZaBrisanje)
        {
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiUvoznika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@IdUvoznika", SqlDbType.VarChar).Value = SifraUvoznikaZaBrisanje;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool IzmeniUvoznika(clsUvoznik objStariUvoznik, clsUvoznik objNoviUvoznik)
        {

            int brojSlogova = 0;


            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniUvoznika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariId", SqlDbType.VarChar).Value = objStariUvoznik.IdUvoznika;
            Komanda.Parameters.Add("@IdUvoznika", SqlDbType.VarChar).Value = objNoviUvoznik.IdUvoznika;
            Komanda.Parameters.Add("@ImeUvoznika", SqlDbType.NVarChar).Value = objNoviUvoznik.ImeUvoznika;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }


        public bool IzmeniUvoznika(string SifraStarogUvoznika, clsUvoznik objNoviUvoznik)
        {

            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniUvoznika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariId", SqlDbType.VarChar).Value = SifraStarogUvoznika;
            Komanda.Parameters.Add("@IdUvoznika", SqlDbType.VarChar).Value = objNoviUvoznik.IdUvoznika;
            Komanda.Parameters.Add("@ImeUvoznika", SqlDbType.NVarChar).Value = objNoviUvoznik.ImeUvoznika;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);
        }
    }
}
