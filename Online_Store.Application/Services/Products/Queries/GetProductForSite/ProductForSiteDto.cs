using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Products.Queries.GetProductForSite
{
    public class ProductForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public int Star { get; set; }
        public int Price { get; set; }
    }
}
