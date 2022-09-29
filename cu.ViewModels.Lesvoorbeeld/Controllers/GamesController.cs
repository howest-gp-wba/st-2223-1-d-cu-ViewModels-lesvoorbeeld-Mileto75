using cu.ViewModels.Lesvoorbeeld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;

namespace cu.ViewModels.Lesvoorbeeld.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository
        _gameRepository; 
        public GamesController()
        {
            _gameRepository =
                new GameRepository();
        }
        public IActionResult Index()
        {
            //ViewBag.PageTitle = "Our not so cool Games!";
            ViewData["PageTitle"] = "Our Cool Games!";
            //get all the games
            var games = _gameRepository
                .GetGames();
            //create the model
            GamesIndexViewModel gamesIndexViewModel
                = new();
            //fill the model
            gamesIndexViewModel.Games =
                new List<GamesGetGameViewModel>();
            foreach(var game in games)
            {
                gamesIndexViewModel.Games.Add(
                    new GamesGetGameViewModel
                    {
                        Title = game.Title,
                        Developer = game.Developer.Name
                    }
                    );
            }
                
            return View(gamesIndexViewModel);
        }
        public IActionResult GetGame(int id)
        {
            //Get the game
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //Create the model
            var gamesGetGameViewModel = 
                new GamesGetGameViewModel();
            //fill the model
            gamesGetGameViewModel.Title = 
                game?.Title ?? "No title";
            gamesGetGameViewModel.Developer = 
                game?.Developer.Name ?? "NoDeveloper";
            //pass the model to the view
            return View();
        }
    }
}
