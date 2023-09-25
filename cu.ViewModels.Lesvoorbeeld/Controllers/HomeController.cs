using cu.ViewModels.Lesvoorbeeld.Models;
using cu.ViewModels.Lesvoorbeeld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.Games.Core;

namespace cu.ViewModels.Lesvoorbeeld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameRepository _gameRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _gameRepository = new GameRepository();
        }

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.Games = _gameRepository.GetGames()
                .Select(g => new HomeGetGameViewModel {
                    Id=g?.Id??0,
                    Title=g?.Title??"<NoTitle>",
                    Developer = g?.Developer?.Name??"<NoDeveloper>"});
            return View(homeIndexViewModel);
        }
        public IActionResult GetGame(int id)
        {
            var game = _gameRepository.GetGames()
                .FirstOrDefault(g => g.Id == id);
            HomeGetGameViewModel homeGetGameViewModel = new HomeGetGameViewModel();
            homeGetGameViewModel.Id = game?.Id ?? 0;
            homeGetGameViewModel.Title = game?.Title ?? "<noTitle>";
            homeGetGameViewModel.Developer = game?.Developer?.Name ?? "<noDeveloper>";
            ViewBag.PageTitle = "Game Info";
            return View(homeGetGameViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
