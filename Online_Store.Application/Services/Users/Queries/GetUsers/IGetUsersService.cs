using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}
