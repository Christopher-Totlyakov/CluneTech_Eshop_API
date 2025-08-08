using Models.Accounts;
using Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Sales
{
    /// <summary>
    /// DTO for returning sale details in responses.
    /// </summary>
    public class SaleResponseDto
    {
        public long Id { get; set; }
        public ClientDto Client { get; set; }
        public ProductSalesDto Product { get; set; }
        public double Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
