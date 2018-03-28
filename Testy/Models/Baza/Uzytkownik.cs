using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testy.Models.Baza
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public bool CzyWykladowca { get; set; }
        public string Haslo { get; set; }
    }
}