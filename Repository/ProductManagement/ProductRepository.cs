using Contracts.Repository.ProductManagement;
using Entities;
using Repository.Base;

namespace Repository.ProductManagement;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }
}
