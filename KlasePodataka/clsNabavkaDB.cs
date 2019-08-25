using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class clsNabavkaDB
    {

        private string pStringKonekcije;

        public string StringKonekcije
        {
            get
            {
                return pStringKonekcije;
            }
        }
    
        public clsNabavkaDB(string NoviStringKonekcije)
     
        {
            pStringKonekcije = NoviStringKonekcije; 
        }


        public DataSet DajSveNabavke()
        {
        
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveNabavke", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            
            return dsPodaci;
        }


        public DataSet DajNabavkuPoNazivuMasine(string NazivMasine)
        {
            
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajNabavkuPoNazivuMasine", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivMasine", SqlDbType.NVarChar).Value = NazivMasine;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public int DajCenuNabavkePoNazivuMasine(string NazivMasine)
        {
            int Cena = 0;
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajCenuNabavkePoNazivuMasine", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivMasine", SqlDbType.NVarChar).Value = NazivMasine;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();
            Cena = int.Parse(dsPodaci.Tables[0].Rows[0].ItemArray[3].ToString());

            return Cena;
        }

        public bool SnimiNovuNabavku(clsNabavka objNovaNabavka)
        {
            int brojSlogova = 0;
            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("DodajNovuNabavku", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivMasine", SqlDbType.VarChar).Value = objNovaNabavka.NazivMasine;
            Komanda.Parameters.Add("@DatumNabavke", SqlDbType.Date).Value = objNovaNabavka.DatumNabavke;
            Komanda.Parameters.Add("@SifraUvoznika", SqlDbType.VarChar).Value = objNovaNabavka.SifraUvoznika;
            Komanda.Parameters.Add("@Cena", SqlDbType.Int).Value = objNovaNabavka.Cena;
            Komanda.Parameters.Add("@Kolicina", SqlDbType.Int).Value = objNovaNabavka.Kolicina;
           

            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();
            return (brojSlogova > 0);
        }

        public bool IzmeniNabavku(clsNabavka objStaraNabavka, clsNabavka objNovaNabavka)
        {

            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniNabavku", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariNaziv", SqlDbType.NVarChar).Value = objStaraNabavka.NazivMasine;
            Komanda.Parameters.Add("@NazivMasine", SqlDbType.NVarChar).Value = objNovaNabavka.NazivMasine;
            Komanda.Parameters.Add("@SifraUvoznika", SqlDbType.NVarChar).Value = objNovaNabavka.SifraUvoznika;
            Komanda.Parameters.Add("@Kolicina", SqlDbType.NVarChar).Value = objNovaNabavka.Kolicina;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public bool ObrisiNabavku(string NazivMasine)
        {
            
            int brojSlogova = 0;

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiNabavku", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivMasine", SqlDbType.NVarChar).Value = NazivMasine;
            brojSlogova = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (brojSlogova > 0);

        }

        public DataSet DajSifruUvoznikaPoNazivuMasine(string NazivMasine)
        {

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSifruUvoznikaPoNazivuMasine", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivMasine", SqlDbType.NVarChar).Value = NazivMasine;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public DataSet DajKolicinuPoNazivuMasine(string NazivMasine)
        {

            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(pStringKonekcije);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajKolicinuPoNazivuMasine", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@NazivMasine", SqlDbType.NVarChar).Value = NazivMasine;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

    }
}
