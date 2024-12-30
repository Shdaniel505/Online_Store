using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Products.Queries.GetCategories
{
    public class CategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }

    }
}
