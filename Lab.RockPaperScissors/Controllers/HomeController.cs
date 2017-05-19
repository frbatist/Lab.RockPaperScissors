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
            string array = "[[[[\"Armando\", \"P\"],[\"Dave\", \"S\"]],[[\"Richard\", \"R\"],[\"Michael\", \"S\"]],]" +
                ",[[[\"Allen\", \"S\"],[\"Omer\", \"P\"]],[[\"David E.\", \"R\"],[\"Richard X.\", \"P\"]]]]";

            var gamePlay = new GamePlay();
            var winner = gamePlay.rps_tournament_winner(array);

            return View();
        }
    }
}