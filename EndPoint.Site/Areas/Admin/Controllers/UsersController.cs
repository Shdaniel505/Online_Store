using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Store.Application.Services.Users.Commands.EditUser;
using Online_Store.Application.Services.Users.Commands.RegisterUser;
using Online_Store.Application.Services.Users.Commands.RemoveUser;
using Online_Store.Application.Services.Users.Commands.UserStatusChange;
using Online_Store.Application.Services.Users.Queries.GetRoles;
using Online_Store.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {

        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        private readonly IEditUserService _editUserService;
        private readonly IRemoveUserService _removeUserService;


        public UsersController(IGetUsersService getUsersService,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IUserStatusChangeService userStatusChangeService,
            IEditUserService editUserService,
            IRemoveUserService removeUserService)

        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _userStatusChangeService = userStatusChangeService;
            _editUserService = editUserService;
            _removeUserService = removeUserService;
        }


        public IActionResult Index(string searchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchkey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult UserStatusChange(long UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }

        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

    }
}
