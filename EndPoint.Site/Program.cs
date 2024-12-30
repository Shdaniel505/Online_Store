using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Application.Interfaces.FacadPatterns;
using Online_Store.Application.Services.Carts;
using Online_Store.Application.Services.Common.Queries.GetCategory;
using Online_Store.Application.Services.Common.Queries.GetHomePageImages;
using Online_Store.Application.Services.Common.Queries.GetMenuItem;
using Online_Store.Application.Services.Common.Queries.GetSlider;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayService;
using Online_Store.Application.Services.Finances.Commands.AddRequestPay;
using Online_Store.Application.Services.HomePages.AddHomePageImages;
using Online_Store.Application.Services.HomePages.AddNewSlider;
using Online_Store.Application.Services.Orders.Commands.AddNewOrder;
using Online_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Online_Store.Application.Services.Orders.Queries.GetUserOrders;
using Online_Store.Application.Services.Products.FacadPattern;
using Online_Store.Application.Services.Users.Commands.EditUser;
using Online_Store.Application.Services.Users.Commands.RegisterUser;
using Online_Store.Application.Services.Users.Commands.RemoveUser;
using Online_Store.Application.Services.Users.Commands.UserLogin;
using Online_Store.Application.Services.Users.Commands.UserStatusChange;
using Online_Store.Application.Services.Users.Queries.GetRoles;
using Online_Store.Application.Services.Users.Queries.GetUsers;
using Online_Store.Common.Roles;
using Online_Store.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    options.AccessDeniedPath = new PathString("/Authentication/Signin");
});

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();

builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddRequestPayService, AddRequestPayService>();
builder.Services.AddScoped<IGetRequestPayService, GetRequestPayService>();
builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
builder.Services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();

string contectionString = @"Data Source=DESKTOP-A80G61M; Initial Catalog=Online_StoreDb; Integrated Security=True;TrustServerCertificate=True";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
builder.Services.AddControllersWithViews();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
         name: "areas",
         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
