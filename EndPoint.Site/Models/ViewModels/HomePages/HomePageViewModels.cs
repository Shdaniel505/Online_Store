using Online_Store.Application.Services.Common.Queries.GetHomePageImages;
using Online_Store.Application.Services.Common.Queries.GetSlider;
using Online_Store.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.Site.Models.ViewModels.HomePages
{
    public class HomePageViewModels
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImagesDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }
    }
}
