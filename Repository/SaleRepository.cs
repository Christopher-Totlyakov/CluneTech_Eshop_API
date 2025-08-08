using Contracts.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        private readonly RepositoryContext _context;

        public SaleRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetAllWithDetailsAsync()
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .ToListAsync();
        }

        public async Task<Sale?> GetWithDetailsByIdAsync(long id)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
