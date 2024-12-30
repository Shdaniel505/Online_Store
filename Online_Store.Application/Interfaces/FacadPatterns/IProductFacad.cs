using Online_Store.Application.Services.Products.Commands.AddNewCategory;
using Online_Store.Application.Services.Products.Commands.AddNewProduct;
using Online_Store.Application.Services.Products.Queries.GetAllCategories;
using Online_Store.Application.Services.Products.Queries.GetCategories;
using Online_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Online_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Online_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Online_Store.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
