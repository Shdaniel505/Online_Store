using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Products.Queries.GetProductForSite
{
    public class ResultProductForSiteDto
    {

        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }
}
