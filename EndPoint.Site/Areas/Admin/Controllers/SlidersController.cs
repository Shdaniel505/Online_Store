using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Services.HomePages.AddNewSlider;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IAddNewSliderService _addNewSliderService;

        public SlidersController(IAddNewSliderService addNewSliderService)
        {
            _addNewSliderService = addNewSliderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link)
        {
            _addNewSliderService.Execute(file, link);
            return View();
        }
    }
}
