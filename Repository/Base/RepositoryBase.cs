using System.Linq.Expressions;
using Contracts.Repository.Base;

namespace Repository.Base;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Repository Context
    /// </summary>
    private readonly RepositoryContext context;

    public RepositoryBase(RepositoryContext context)
    {
        this.context = context;
    }

    public void Create(T entity)
    {
        context.Set<T>()
            .Add(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>()
            .Remove(entity);
    }

    public T Get(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>()
            .AsQueryable()
            .Where(predicate)
            .FirstOrDefault();
    }

    public IEnumerable<T> GetAll()
    {
        return context.Set<T>();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>()
            .AsQueryable()
            .Where(predicate);
    }

    public void Update(T entity)
    {
        context.Set<T>()
            .Remove(entity);

        context.Set<T>()
            .Add(entity);
    }
}
