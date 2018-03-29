using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Testy.Models.Baza
{
    public class Dane
    {
        public Uzytkownik PobiezUzytkownika(string nazwa)
        {
            List< Dictionary<string, object>> wyniki = Pobierz($"SELECT Id, Nazwa, Haslo, Imie, Nazwisko, CzyWykladowca from Uzytkownicy where Nazwa = '{nazwa}'");

            if (wyniki.Count == 1)
            {
                Dictionary<string, object> uzytkownik = wyniki[0];
                return new Uzytkownik()
                {
                    Id = (int)uzytkownik["Id"],
                    Nazwa = (string)uzytkownik["Nazwa"],
                    Haslo = (string)uzytkownik["Haslo"],
                    Imie = (string)uzytkownik["Imie"],
                    Nazwisko = (string)uzytkownik["Nazwisko"],
                    CzyWykladowca = (bool)uzytkownik["CzyWykladowca"]
                };
            }
            return null;
        }

        public List<Test> PobiezTesty()
        {
            List<Dictionary<string, object>> wyniki = Pobierz($"SELECT Id, Nazwa, IloscMinNaRozwiazanie from Testy");

            List<Test> testy = new List<Test>();
            foreach (var wynik in wyniki)
            {
                Test test = new Test()
                {
                    Id = (int)wynik["Id"],
                    Nazwa = (string)wynik["Nazwa"],
                    IloscMinNaRozwiazanie = (int)wynik["IloscMinNaRozwiazanie"]
                };

                testy.Add(test);
            }
            return testy;
        }

        private List<Dictionary<string, object>> Pobierz(string sql)
        {
            List< Dictionary<string, object>> output = new List<Dictionary<string, object>> ();

            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|BazaTestow.mdf;Integrated Security=True"))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> record = new Dictionary<string,object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                record.Add(reader.GetName(i), reader.GetValue(i));
                            }
                            output.Add(record);
                        }
                    }
                }
            }
            return output;
        }
    }
}