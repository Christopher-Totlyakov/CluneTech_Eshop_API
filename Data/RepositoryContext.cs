using System.Reflection;
using Entities;

/// <summary>
/// Database
/// </summary>
public class RepositoryContext 
{
    /// <summary>
    /// Accounts
    /// </summary>
    public List<Account> Accounts { get; set; } = new();

    /// <summary>
    /// Addressess
    /// </summary>
    public List<Address> Addresses { get; }= new();

    /// <summary>
    /// Clients
    /// </summary>
    public List<Client> Clients { get; }= new();

    /// <summary>
    /// Countries
    /// </summary>
    public List<Country> Countries { get; }= new();

    /// <summary>
    /// Products
    /// </summary>
    public List<Product> Products { get; }= new()
    {
        new()
        {
            Id = 1,
            Name = "Lion King",
            Type = "Book",
            Price = 25.00M
        },
        new()
        {
            Id = 2,
            Name = "Gladiator 2",
            Type = "Movie",
            Price = 30.50M
        },
        new()
        {
            Id = 3,
            Name = "God Of War: Ragnarok",
            Type = "PS5 Game",
            Price = 69.90M
        },
    };

    /// <summary>
    /// Sales
    /// </summary>
    public List<Sale> Sales { get; }= new();
    
    public List<T> Set<T>()
    {
        PropertyInfo propertyInfo = this.GetType()
            .GetProperties()
            .Where(x => x.PropertyType == typeof(List<T>))
            .FirstOrDefault();

        if (propertyInfo == null)
        {
            throw new ArgumentException($"Unable to find Set of Type: {typeof(T)}");
        }

        return propertyInfo.GetValue(this) as List<T>;
    }    
}
