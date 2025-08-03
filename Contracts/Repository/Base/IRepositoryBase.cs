using System.Linq.Expressions;

namespace Contracts.Repository.Base;

/// <summary>
/// Repository Base
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepositoryBase<T> where T : class
{
    /// <summary>
    /// Get All
    /// </summary>
    /// <returns></returns>
    IEnumerable<T> GetAll();

    /// <summary>
    /// Get All by condition
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Get By Condition
    /// </summary>
    /// <param name="preducate"></param>
    /// <returns></returns>
    T Get(Expression<Func<T, bool>> preducate);

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="entity"></param>
    void Create(T entity);

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="entity"></param>
    void Delete(T entity);
}
