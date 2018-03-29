using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testy.Models.Baza;

namespace Testy.Models
{
    public class TestyIndexModel
    {
        public Uzytkownik Uzytkownik { get; set; }
        public List<Test> Testy { get; set; }
    }
}