using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

/// <summary>
/// Interface for account repository.
/// </summary>
public interface IAccountRepository : IRepositoryBase<Account>
{

}

