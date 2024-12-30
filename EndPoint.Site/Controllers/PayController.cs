using Dto.Payment;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Services.Carts;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayService;
using Online_Store.Application.Services.Finances.Commands.AddRequestPay;
using Online_Store.Application.Services.Orders.Commands.AddNewOrder;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IAddRequestPayService _addRequestPayService;
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IGetRequestPayService _getRequestPayService;
        private readonly IAddNewOrderService _addNewOrderService;


        public PayController(IAddRequestPayService addRequestPayService
            , ICartService cartService
            , IGetRequestPayService getRequestPayService
            , IAddNewOrderService addNewOrderService

             )
        {
            _addRequestPayService = addRequestPayService;
            _cartService = cartService;
            _cookiesManeger = new CookiesManeger();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _getRequestPayService = getRequestPayService;
            _addNewOrderService = addNewOrderService;
        }
        public async Task<IActionResult> Index()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);
            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _addRequestPayService.Execute(cart.Data.SumAmount, UserId.Value);
                // ارسال در گاه پرداخت

                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    CallbackUrl = $"https://localhost:44377/Pay/Verify?guid={requestPay.Data.guid}",
                    Description = "پرداخت فاکتور شماره:" + requestPay.Data.RequestPayId,
                    Email = requestPay.Data.Email,
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");


            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }

        }

        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {

            var requestPay = _getRequestPayService.Execute(guid);

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);


            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

            if (verification.Status == 100)
            {
                _addNewOrderService.Execute(new RequestAddNewOrderSericeDto
                {
                    CartId = cart.Data.CartId,
                    UserId = UserId.Value,
                    RequestPayId = requestPay.Data.Id
                });

                //redirect to orders
                return RedirectToAction("Index", "Orders");
            }
            else
            {

            }

            return View();
        }
    }


    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefID { get; set; }
    }
}
