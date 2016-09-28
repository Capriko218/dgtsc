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
        [HttpGet]
        public ActionResult Index(int id)
        {
            var m = new HomeIndexView_Model();

            var players = PlayersDB.GetPlayersByGame(id);
            var game = GamesDB.GetSingleGame(id);

            m.Players = players.Select(x => new PlayerClass_Model
            {
                FirstName = x.Name
            }).ToList();

            m.GameCode = game.JoinCode;
            m.GameDateTime = game.GameDateTime;
            m.LocationName = game.LocationName;
            m.GameId = game.Id;

            return View("index_view", m);
        }

        [HttpPost]
        public ActionResult Index(HomeIndexView_Model m)
        {

        }
    }
}