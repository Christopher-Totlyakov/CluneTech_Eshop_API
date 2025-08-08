using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Sales
{
    /// <summary>
    /// DTO for creating or updating a sale.
    /// </summary>
    public class SaleDto
    {
        public long ClientId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
