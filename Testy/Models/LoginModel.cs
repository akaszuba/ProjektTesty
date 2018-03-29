using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testy.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="Nazwa Użytkownika")]
        public string Nazwa { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        public string Haslo { get; set; }
    }
}