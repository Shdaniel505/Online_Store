using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Online_Store.Domain.Entities.Orders;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class OrdersController : Controller
    {
        private readonly IGetOrdersForAdminService _getOrdersForAdminService;
        public OrdersController(IGetOrdersForAdminService getOrdersForAdminService)
        {
            _getOrdersForAdminService = getOrdersForAdminService;
        }
        public IActionResult Index(OrderState orderState)
        {
            return View(_getOrdersForAdminService.Execute(orderState).Data);
        }
    }
}
