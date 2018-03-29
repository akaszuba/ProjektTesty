using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testy.Models;
using Testy.Models.Baza;

namespace Testy.Controllers
{
    [Authorize]
    public class TestyController : Controller
    {
        // GET: Testy
        public ActionResult Index()
        {
            Dane dane = new Dane();
            TestyIndexModel model = new TestyIndexModel();
            model.Uzytkownik = dane.PobiezUzytkownika(User.Identity.Name);
            model.Testy = dane.PobiezTesty();

            return View(model);
        }
    }
}