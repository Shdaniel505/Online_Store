using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestPayController : Controller
    {
        private readonly IGetRequestPayForAdminService _getRequestPayForAdminService;
        public RequestPayController(IGetRequestPayForAdminService getRequestPayForAdminService)
        {
            _getRequestPayForAdminService = getRequestPayForAdminService;
        }
        public IActionResult Index()
        {
            return View(_getRequestPayForAdminService.Execute().Data);
        }
    }
}
