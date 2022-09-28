using cu.ViewModels.Lesvoorbeeld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Wba.Oefening.Games.Core;

namespace cu.ViewModels.Lesvoorbeeld.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly GameRepository _gameRepository;

        public DevelopersController()
        {
            _gameRepository = new GameRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowGames(int id)
        {
            var developersShowGamesViewModel = new HomeIndexViewModel();
            developersShowGamesViewModel.Games
                = _gameRepository.GetGames().Where(
                    g => g.Developer.Id == id)
                .Select(g => new HomeGetGameViewModel {
                    Id = g.Id,
                    Title = g.Title,
                });
            return View(developersShowGamesViewModel);
        }
    }
}
