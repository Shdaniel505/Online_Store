using Online_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Domain.Entities.Products
{
    public class ProductFeatures : BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
