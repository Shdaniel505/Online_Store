using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.Orders;

namespace Online_Store.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState);
    }

    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders = _context.Orders
                 .Include(p => p.OrderDetails)
                 .Where(p => p.OrderState == orderState)
                 .OrderByDescending(p => p.Id)
                 .ToList()
                 .Select(p => new OrdersDto
                 {
                     InsetTime = p.InsertTime,
                     OrderId = p.Id,
                     OrderState = p.OrderState,
                     ProductCount = p.OrderDetails.Count(),
                     RequestId = p.RequestPayId,
                     UserId = p.UserId,
                 }).ToList();

            return new ResultDto<List<OrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }
    }
    public class OrdersDto
    {
        public long OrderId { get; set; }
        public DateTime InsetTime { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }

    }
}
