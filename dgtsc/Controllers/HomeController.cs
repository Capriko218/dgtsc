using dgtsc.Data;
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
        public ActionResult Index(int id)
        {
            var m = new HomeIndexView();
			//m.Players = new List<PlayerClass>
			//{
			//    new PlayerClass { FirstName = "Colby", LastName = "Slaybaugh" },
			//    new PlayerClass { FirstName = "Johnny", LastName = "Baker" },
			//    new PlayerClass { FirstName = "Nathan", LastName = "Filloon" },
			//    new PlayerClass { FirstName = "Nathan", LastName = "Beaver" },
			//};

			var players = PlayersDB.GetPlayersByGame(id);

			m.Players = players.Select(x => new PlayerClass
			{
				FirstName = x.Name
			}).ToList();

            return View("index", m);
        }
    }
}