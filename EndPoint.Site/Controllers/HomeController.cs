using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Interfaces.FacadPatterns;
using Online_Store.Application.Services.Common.Queries.GetHomePageImages;
using Online_Store.Application.Services.Common.Queries.GetSlider;
using Online_Store.Application.Services.Products.Queries.GetProductForSite;
using System.Diagnostics;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImagesService _homePageImagesService;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger
            , IGetSliderService getSliderService
            , IGetHomePageImagesService homePageImagesService
            , IProductFacad productFacad)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _homePageImagesService = homePageImagesService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModels homePage = new HomePageViewModels()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _homePageImagesService.Execute().Data,
                Camera = _productFacad.GetProductForSiteService.Execute(Ordering.theNewest
                , null, 1, 6, 25).Data.Products,
            };

            return View(homePage);
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
