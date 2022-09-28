using cu.ViewModels.Lesvoorbeeld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.Games.Core;

namespace cu.ViewModels.Lesvoorbeeld.ViewComponents
{
    
    [ViewComponent(Name = "DevelopersMenu")]
    public class DevelopersMenuViewComponent : ViewComponent
    {
        private readonly DeveloperRepository _developerRepository;

        public DevelopersMenuViewComponent()
        {
            _developerRepository = new DeveloperRepository();
        }
        public async Task<IViewComponentResult> Invoke()
        {
            //get the developers from the repo
            //put in viewmodel
            var developersMenuViewModel = new DevelopersMenuViewModel();
            developersMenuViewModel.Developers =
                _developerRepository.GetDevelopers()
                .Select(d => new DeveloperShowDeveloperViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                });
            //send to the view
            return await Task.FromResult(View(developersMenuViewModel));
        }
    }
}
