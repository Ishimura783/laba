using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace laba1.Views.Shared.Сomponents.Navbar
{

    public class TopbarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            TopbarViewModel vm = new TopbarViewModel()
            {
                IsAdminUser = false
            };
            return View(vm);
        }
    }
}

