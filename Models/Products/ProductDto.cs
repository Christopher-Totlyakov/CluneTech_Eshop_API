using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Products
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }

    }
}
