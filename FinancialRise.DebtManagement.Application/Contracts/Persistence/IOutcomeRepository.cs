using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialRise.DebtManagement.Domain.Entities;

namespace FinancialRise.DebtManagement.Application.Contracts.Persistence
{
    public interface IOutcomeRepository : IAsyncRepository<Outcome>
    {
        Task<bool> IsOutcomeNameExists(string name);
        Task<IReadOnlyList<Outcome>> ListAllByUserAsync(Guid userId);
    }
}
