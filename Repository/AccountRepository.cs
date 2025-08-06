using Contracts.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    protected readonly RepositoryContext _context;
    public AccountRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<Account>> GetAllWithClientAsync()
    {
        return await _context.Accounts
            .Include(a => a.Client)
            .ToListAsync();
    }
    public async Task<Account?> GetWithClientByIdAsync(long id)
    {
        return await _context.Accounts
            .Include(a => a.Client)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
