using Contracts.Repository;
using Entities;
using Repository.Base;

namespace Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }
}
