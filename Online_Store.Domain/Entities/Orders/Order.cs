using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Domain.Entities.Commons;
using Online_Store.Domain.Entities.Finances;
using Online_Store.Domain.Entities.Users;

namespace Online_Store.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {

        public virtual User User { get; set; }
        public long UserId { get; set; }

        public virtual RequestPay RequestPay { get; set; }
        public long RequestPayId { get; set; }

        public OrderState OrderState { get; set; }

        public string Address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
