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
            List<Hashtable> uzytkownikcy = Pobierz($"SELECT Id, Nazwa, Haslo, Imie, Nazwisko, CzyWykladowca from Uzytkownicy where Nazwa = '{nazwa}'");

            if (uzytkownikcy.Count == 1)
            {
                Hashtable uzytkownik = uzytkownikcy[0];
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

        private List<Hashtable> Pobierz(string sql)
        {
            List<Hashtable> output = new List<Hashtable>();

            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|BazaTestow.mdf;Integrated Security=True"))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hashtable record = new Hashtable();
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