using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cu.ViewModels.Lesvoorbeeld.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<HomeGetGameViewModel> Games { get; set; }
    }
}
