using System.Web.Mvc;
using System.Web.Security;
using Testy.Models;
using Testy.Models.Baza;

namespace Testy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        public ActionResult Login(LoginModel model)
        {
            Dane dane = new Dane();

            if (ModelState.IsValid)
            {
                Dane data = new Dane();

                Uzytkownik uzytkownik = dane.PobiezUzytkownika(model.Nazwa);

                if(uzytkownik == null)
                {
                    ModelState.AddModelError("", "Nie ma takiego użytkownika");
                }
                else
                {
                    if(uzytkownik.Haslo != model.Haslo)
                    {
                        ModelState.AddModelError("", "Błędne hasło");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                FormsAuthentication.RedirectFromLoginPage(model.Nazwa, true);
            }

            return View("Index", model);
        }

        public ActionResult Wyloguj()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}