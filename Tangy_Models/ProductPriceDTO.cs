﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class ProductPriceDTO
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Size { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Price must be more than 1 euro")]
        public double Price { get; set; }
    }
}
