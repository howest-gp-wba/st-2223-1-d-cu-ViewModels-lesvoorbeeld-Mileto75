using cu.ViewModels.Lesvoorbeeld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;

namespace cu.ViewModels.Lesvoorbeeld.Controllers
{
    public class GamesController : Controller
    {

        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository();
        }
        public IActionResult Index()
        {
            //ViewBag
            ViewBag.PageTitle = "Our coolest games";
            ////ViewData
            //ViewData["PageTitle"] = "Our coolest games";
            //ViewBag.Games = _gameRepository
            //    .GetGames();
            //init model
            var gamesIndexViewModel = new GamesIndexViewModel();
            //get the games
            var games = _gameRepository.GetGames();
            //put games in model aka fill the model
            //loop over games and add to model
            //old skool way
            gamesIndexViewModel.Games = new();
            foreach (var game in games)
            {
                gamesIndexViewModel.Games.Add(game.Title);
            }
            //pass the model to the view
            return View(gamesIndexViewModel);
        }
    }
}
