using Online_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Domain.Entities.HomePage
{
    public class Slider : BaseEntity
    {
        public string Src { get; set; }
        public string link { get; set; }
    }
}
