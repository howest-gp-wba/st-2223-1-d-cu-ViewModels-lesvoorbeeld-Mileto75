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
            //init model
            //get the games
            //put games in model aka fill the model
            //loop over games and add to model
            var gamesIndexViewModel = new GamesIndexViewModel
            {
                Games = _gameRepository
                .GetGames()
                .Select(g => new BaseViewModel
                {
                    Id = g.Id,
                    Text = g.Title
                }),
            };
            //pass the model to the view
            return View(gamesIndexViewModel);
        }
        public IActionResult Info(int id) 
        {
            //get the game
            var game = _gameRepository.GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check if exists
            if(game == null)
            {
                return NotFound();
            }
            //create the model
            var gamesInfoViewModel = new GamesInfoViewModel 
            {
                //fill the model
                Title = game.Title,
                Developer = game.Developer.Name,
                Rating = game.Rating
            };
            //pass to the view
            return View(gamesInfoViewModel);
        }
    }
}
