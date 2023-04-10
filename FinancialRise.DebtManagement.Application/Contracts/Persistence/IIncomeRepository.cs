using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface IIncomeRepository : IAsyncRepository<Income>
    {
        Task<bool> IsIncomeNameExists(string name);
        Task<IReadOnlyList<Income>> ListAllByUserAsync(Guid userId);
    }
}
