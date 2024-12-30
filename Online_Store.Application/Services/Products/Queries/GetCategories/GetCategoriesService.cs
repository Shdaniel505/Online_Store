using Microsoft.EntityFrameworkCore;
using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Products.Queries.GetCategories
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoriesDto>> Execute(long? ParentId)
        {
            var categories = _context.Categories
               .Include(p => p.ParentCategory)
               .Include(p => p.SubCategories)
               .Where(p => p.ParentCategoryId == ParentId)
               .ToList()
               .Select(p => new CategoriesDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   Parent = p.ParentCategory != null ? new
                   ParentCategoryDto
                   {
                       Id = p.ParentCategory.Id,
                       name = p.ParentCategory.Name,
                   }
                   : null,
                   HasChild = p.SubCategories.Count() > 0 ? true : false,
               }).ToList();


            return new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };

        }
    }
}
