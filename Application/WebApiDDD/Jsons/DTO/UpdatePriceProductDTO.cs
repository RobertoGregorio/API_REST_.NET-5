using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDDD.Jsons
{
    public class UpdatePriceProductDTO
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
    }
}
