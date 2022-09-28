using cu.ViewModels.Lesvoorbeeld.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace cu.ViewModels.Lesvoorbeeld.ViewComponents
{
    [ViewComponent(Name = "QuoteComponent")]
    public class QuoteViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //get the data from api
            var httpClient = new HttpClient();
            var request = await httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
            var result = await request.Content.ReadAsStringAsync();
            var quoteComponentViewModel =
                JsonConvert.DeserializeObject<QuoteComponentViewModel>(result);
            //put in viewmodel
            //send to the view
            return View(quoteComponentViewModel);
        }
    }
}
