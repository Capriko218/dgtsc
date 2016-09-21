using dgtsc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dgtsc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var m = new HomeIndexView();
            m.Players = new List<PlayerClass>
            {
                new PlayerClass { FirstName = "Colby", LastName = "Slaybaugh" },
                new PlayerClass { FirstName = "Johnny", LastName = "Baker" },
                new PlayerClass { FirstName = "Nathan", LastName = "Filloon" },
                new PlayerClass { FirstName = "Nathan", LastName = "Beaver" },
            };

            return View("index", m);
        }
    }
}