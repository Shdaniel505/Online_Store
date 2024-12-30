using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.Users;

namespace Online_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin
{
    public interface IGetRequestPayForAdminService
    {
        ResultDto<List<RequestPayDto>> Execute();
    }

    public class GetRequestPayForAdminService : IGetRequestPayForAdminService
    {
        private readonly IDataBaseContext _context;

        public GetRequestPayForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RequestPayDto>> Execute()
        {
            var requestpay = _context.RequestPays.
                Include(p=>p.User).
                ToList().
                Select(p => new RequestPayDto
                {
                    Amount= p.Amount,
                    Authority= p.Authority,
                    Guid= p.Guid,
                    IsPay= p.IsPay,
                    PayDate= p.PayDate,
                    RefId= p.RefId,
                    UserId= p.UserId,
                    UserName=p.User.FullName
                }).ToList();

            return new ResultDto<List<RequestPayDto>>()
            {
                Data = requestpay,
                IsSuccess = true,
            };

        }
    }

    public class RequestPayDto
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public String UserName { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
