﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDDD.Jsons
{
    public class CreateProductDTO
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public long Code { get; set; }

    }
}
