using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDDD.Jsons.Products
{
    public class UpdatePriceDTO
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
    }
}
