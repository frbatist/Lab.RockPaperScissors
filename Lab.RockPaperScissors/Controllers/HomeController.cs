using Lab.RockPaperScissors.BusinessLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.RockPaperScissors.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string array)
        {
            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_tournament_winner(array);
            ViewBag.Winner = winner.Name;
            return View();
        }
    }
}