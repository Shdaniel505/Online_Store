using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;

        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new RolesDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
